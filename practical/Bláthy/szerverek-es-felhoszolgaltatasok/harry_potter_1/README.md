# Harry Potter vizsgaforrás PostgreSQL és Flask változat

Az eredeti oldal főoldalát, könyv- és filmlistáját, szereplőit és roxforti
házait tartja meg. A PHP és MySQL helyén Flask, Gunicorn és PostgreSQL van.
Az alkalmazás olvasási műveleteket használ.

## A csomag tartalma

- `schema.sql`: idempotensen betölthető táblák és adatok (7 könyv, 8 film).
- `app.py`, `templates/`, `static/`, `requirements.txt`: webalkalmazás.
- `config/exam.conf`: kitöltendő, jelszót **nem** tartalmazó paraméterfájl.
- `scripts/setup.sh`: S3 jogosultságellenőrzés, PostgreSQL adatbázis és import,
  Python környezet, védett jelszófájl, systemd és Nginx telepítés, teszt.
- `scripts/check.sh`: a Gunicorn és Nginx végpontok külön ellenőrzése.
- `deploy/`: a systemd és az Nginx telepítendő konfigurációja.

## A munkamenet az EC2 Session Manager termináljában

1. A konzolban hozza létre a privát S3 bucketet, az RDS példányt és az EC2
   példányt. Az RDS bejövő 5432/TCP portjára az EC2 biztonsági csoportját
   állítsa be forrásként. Töltse fel az archívumot az S3 bucketbe.
2. Frissítse a csomaglistát; telepítse az `awscli`, `nginx`, `python3`,
   `python3-venv`, `python3-pip`, `postgresql-client` és `curl` csomagokat.
3. A csomaghoz hozzáférés miatt egyszer le kell tölteni és ki kell bontani:

   ```bash
   aws s3 cp s3://SAJAT_BUCKET/harry_potter_flask_pg.tar.gz /tmp/harry_potter_flask_pg.tar.gz
   sudo tar -xzf /tmp/harry_potter_flask_pg.tar.gz -C /opt
   ```

4. A `/opt/harry_potter/config/exam.conf` fájlban írja át a `S3_BUCKET` és
   `DB_HOST` értékét. A `DB_PORT=5432`, `DB_NAME=harry_potter` és
   `DB_USER=labadmin` alapértékek egyezzenek meg az RDS beállításaival.
   A jelszó ne kerüljön ebbe a fájlba.
5. Futtassa az automatizált telepítést. A jelszó bekérése nem írja ki a
   beütött karaktereket. A jelszó csak a helyi, `root:www-data` tulajdonú,
   `0640` jogosultságú `/etc/harry-potter.env` fájlba kerül.

   ```bash
   sudo bash /opt/harry_potter/scripts/setup.sh
   ```

6. A helyi tesztet újra lehet futtatni a Session Manager termináljából:

   ```bash
   bash /opt/harry_potter/scripts/check.sh
   ```

   A script HTTP 200 választ és a `/health` végponton `status=ok`, 7 könyv,
   8 film adatot vár a 8000-es közvetlen és a 80-as Nginx útvonalon.
   Saját gépének böngészőjében az EC2 aktuális publikus IP-címével nyissa meg
   a `/books` és `/films/1` útvonalat.

## Újrafuttatás és hibakeresés

A `setup.sh` újrafuttatható: a már létező adatbázist és az importált rekordokat
megtartja, az alkalmazás és az Nginx beállításait ellenőrzi és betölti. Újra
bekéri az RDS jelszavát. A jelszót ne adja át parancssori paraméterként,
ne fotózza le, és ne töltse fel S3-ba.

Ha a PostgreSQL kapcsolódás időtúllépéssel áll meg, ellenőrizze, hogy az EC2
és az RDS ugyanabban a VPC-ben van-e, valamint az RDS 5432/TCP szabályának
forrása az EC2 biztonsági csoportja-e. Ha a közvetlen 8000-es port működik,
de a 80-as 404-et ad, a `setup.sh` ismételt futtatása eltávolítja a gyári
Nginx oldalt és újratölti a mellékelt konfigurációt.

A forrás nem tartalmaz AWS hozzáférési kulcsot vagy RDS jelszót. Az S3 objektum
maradjon privát; az EC2 a `LabInstanceProfile` szerepkörén keresztül töltse le.
