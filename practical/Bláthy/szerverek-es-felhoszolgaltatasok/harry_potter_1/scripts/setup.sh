#!/usr/bin/env bash
# Telepites az EC2-n: adatbazis, Python, systemd, Nginx, vegpontok.
set -Eeuo pipefail

APP_DIR=/opt/harry_potter
CONFIG="$APP_DIR/config/exam.conf"
ENV_FILE=/etc/harry-potter.env

die() { printf 'HIBA: %s\n' "$*" >&2; exit 1; }
step() { printf '\n== %s ==\n' "$*"; }

(( EUID == 0 )) || die 'Futtassa sudo-val: sudo bash /opt/harry_potter/scripts/setup.sh'
[[ -f "$CONFIG" ]] || die "Hianyzik a parameterfajl: $CONFIG"
[[ -f "$APP_DIR/schema.sql" && -f "$APP_DIR/requirements.txt" ]] || die 'Hianyos a kicsomagolt forras.'
for cmd in aws psql python3 nginx systemctl curl; do
    command -v "$cmd" >/dev/null || die "Hianyzik a telepitett csomag/parancs: $cmd"
done

# A parameterfajlt adatkent olvassuk, root joggal sem futtatjuk shell kodkent.
while IFS='=' read -r key value || [[ -n "$key" ]]; do
    [[ -z "$key" || "$key" == \#* ]] && continue
    case "$key" in
        S3_BUCKET|DB_HOST|DB_PORT|DB_NAME|DB_USER) printf -v "$key" '%s' "$value" ;;
        *) die "Ismeretlen parameter vagy ervenytelen sor: $key" ;;
    esac
done < "$CONFIG"
[[ ${S3_BUCKET:-} =~ ^[a-z0-9][a-z0-9.-]{1,61}[a-z0-9]$ ]] || die 'Adjon meg ervenyes S3_BUCKET erteket a config/exam.conf fajlban.'
[[ ${DB_HOST:-} =~ ^[A-Za-z0-9.-]+$ && ${DB_HOST:-} == *.* ]] || die 'Adjon meg ervenyes DB_HOST RDS vegpontot a config/exam.conf fajlban.'
[[ ${DB_PORT:-} =~ ^[0-9]{1,5}$ ]] || die 'DB_PORT: ervenytelen port.'
(( 10#$DB_PORT >= 1 && 10#$DB_PORT <= 65535 )) || die 'DB_PORT: a port 1 es 65535 kozott legyen.'
[[ ${DB_NAME:-} =~ ^[a-z][a-z0-9_]*$ && ${DB_USER:-} =~ ^[a-z][a-z0-9_]*$ ]] || die 'DB_NAME vagy DB_USER: ervenytelen nev.'

step '1. EC2 jogosultsag es privat S3 objektum'
aws sts get-caller-identity --query Arn --output text
aws s3api head-object --bucket "$S3_BUCKET" --key harry_potter_flask_pg.tar.gz --query ContentLength --output text >/dev/null \
    || die 'Az S3 objektum nem erheto el az EC2 szerepkorevel. Ellenorizze a bucket nevet es a jogosultsagot.'
printf 'S3 objektum: elerheto (%s)\n' "$S3_BUCKET"

step '2. RDS jelszo es kapcsolat'
printf 'RDS jelszo (bevitel rejtve): ' > /dev/tty
IFS= read -r -s DB_PASSWORD < /dev/tty || die 'A jelszo beolvasasa sikertelen; interaktiv Session Manager terminal szukseges.'
printf '\n' > /dev/tty
[[ ${#DB_PASSWORD} -ge 16 && "$DB_PASSWORD" =~ ^[A-Za-z0-9]+$ && "$DB_PASSWORD" =~ [A-Za-z] && "$DB_PASSWORD" =~ [0-9] ]] \
    || die 'A jelszo legalabb 16 karakterbol, angol betukbol es szamokbol alljon.'
trap 'unset DB_PASSWORD' EXIT

db_psql() {
    PGPASSWORD="$DB_PASSWORD" PGSSLMODE=require PGCONNECT_TIMEOUT=8 \
        psql -X -v ON_ERROR_STOP=1 -w -h "$DB_HOST" -p "$DB_PORT" -U "$DB_USER" "$@"
}
db_psql -d postgres -Atqc 'SELECT 1' >/dev/null \
    || die 'Nem lehet csatlakozni az RDS-hez. Ellenorizze a vegpontot, jelszot, VPC-t es az 5432/TCP biztonsagi csoport szabalyat.'
printf 'RDS kapcsolat: sikeres (%s:%s)\n' "$DB_HOST" "$DB_PORT"

step '3. Adatbazis es mintaadatok'
db_exists=$(db_psql -d postgres -Atqc "SELECT 1 FROM pg_database WHERE datname = '$DB_NAME'") \
    || die 'Az adatbazisok lekerdezese sikertelen.'
if [[ "$db_exists" != 1 ]]; then
    db_psql -d postgres -c "CREATE DATABASE $DB_NAME"
else
    printf 'A %s adatbazis mar letezik.\n' "$DB_NAME"
fi
db_psql -d "$DB_NAME" -f "$APP_DIR/schema.sql" >/dev/null
counts=$(db_psql -d "$DB_NAME" -Atqc 'SELECT (SELECT count(*) FROM books), (SELECT count(*) FROM films)')
[[ "$counts" == '7|8' ]] || die "Varatlan rekordszam: $counts (elvart: 7 konyv, 8 film)."
printf 'Adatbazis: %s; konyvek: 7; filmek: 8\n' "$DB_NAME"

step '4. Python kornyezet es vedett beallitasfajl'
python3 -m venv "$APP_DIR/.venv"
"$APP_DIR/.venv/bin/pip" install -r "$APP_DIR/requirements.txt"
umask 077
temp_env=$(mktemp /etc/harry-potter.env.XXXXXX)
trap 'rm -f "${temp_env:-}"; unset DB_PASSWORD' EXIT
{
    printf 'DB_HOST=%s\n' "$DB_HOST"
    printf 'DB_PORT=%s\n' "$DB_PORT"
    printf 'DB_NAME=%s\n' "$DB_NAME"
    printf 'DB_USER=%s\n' "$DB_USER"
    printf 'DB_PASSWORD=%s\n' "$DB_PASSWORD"
    printf 'DB_SSLMODE=require\n'
} > "$temp_env"
chown root:www-data "$temp_env"
chmod 0640 "$temp_env"
mv -f "$temp_env" "$ENV_FILE"
temp_env=''
unset DB_PASSWORD
stat -c 'Vedett beallitasfajl: %U:%G %a %n' "$ENV_FILE"

step '5. systemd es Nginx'
install -m 0644 "$APP_DIR/deploy/harry-potter.service" /etc/systemd/system/harry-potter.service
install -m 0644 "$APP_DIR/deploy/harry-potter.nginx" /etc/nginx/sites-available/harry-potter
rm -f /etc/nginx/sites-enabled/default
ln -sfn /etc/nginx/sites-available/harry-potter /etc/nginx/sites-enabled/harry-potter
systemctl daemon-reload
nginx -t
systemctl enable --now harry-potter nginx
systemctl restart harry-potter
systemctl reload nginx
systemctl is-active --quiet harry-potter && systemctl is-active --quiet nginx \
    || die 'Az alkalmazas vagy az Nginx nem fut. Ellenorizze a systemd naplot.'
printf 'Szolgaltatasok: harry-potter active, nginx active\n'

step '6. Helyi vegpontok ellenorzese'
bash "$APP_DIR/scripts/check.sh"
printf '\nKESZ: a telepites es a helyi ellenorzes sikeres.\n'
