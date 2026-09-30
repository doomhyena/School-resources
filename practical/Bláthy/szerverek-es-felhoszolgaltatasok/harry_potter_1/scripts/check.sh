#!/usr/bin/env bash
# A Gunicorn es az Nginx kulon ellenorzese a Session Manager terminaljabol.
set -Eeuo pipefail

scratch=$(mktemp)
trap 'rm -f "$scratch"' EXIT

check_url() {
    local label="$1" url="$2" kind="$3" status
    if ! status=$(curl --silent --show-error --max-time 10 --output "$scratch" --write-out '%{http_code}' "$url"); then
        printf 'HIBA: %s nem erheto el: %s\n' "$label" "$url" >&2
        return 1
    fi
    if [[ "$status" != 200 ]]; then
        printf 'HIBA: %s, HTTP %s: %s\n' "$label" "$status" "$url" >&2
        return 1
    fi
    if [[ "$kind" == health ]]; then
        python3 - "$scratch" <<'PY'
import json
import sys

with open(sys.argv[1], encoding="utf-8") as stream:
    data = json.load(stream)
if (data.get("status"), data.get("books"), data.get("films")) != ("ok", 7, 8):
    raise SystemExit(f"HIBA: varatlan /health eredmeny: {data}")
print("  status: ok, konyvek: 7, filmek: 8")
PY
    fi
    printf 'OK: %s (HTTP 200)\n' "$label"
}

check_url 'Gunicorn /health' 'http://127.0.0.1:8000/health' health
check_url 'Gunicorn /books' 'http://127.0.0.1:8000/books' html
check_url 'Gunicorn /films/1' 'http://127.0.0.1:8000/films/1' html
check_url 'Nginx /health' 'http://127.0.0.1/health' health
check_url 'Nginx /books' 'http://127.0.0.1/books' html
check_url 'Nginx /films/1' 'http://127.0.0.1/films/1' html
printf 'A helyi vegpontok megfelelnek.\n'
