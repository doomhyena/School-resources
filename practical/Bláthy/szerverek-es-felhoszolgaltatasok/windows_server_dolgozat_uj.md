# Windows Server gyakorlati dolgozat (2. verzió)

**Téma:** DHCP, DNS, IIS (HTTP/HTTPS, több weboldal), FTP és tűzfal konfiguráció

## Kiindulási helyzet

Egy középvállalat informatikai rendszerét kell kialakítanod egy Windows
Server segítségével. A cégnek egy publikus weboldalra és egy belső
(intranet) oldalra egyaránt szüksége van, emellett fájlmegosztást is
biztosítani kell FTP-n keresztül.

-   Hálózat: 192.168.70.0/24
-   Domain: vallalat.local

**Fontos:** A konkrét IP címeket, a DHCP-tartományt és a kizárásokat
(exclusion) neked kell megterveznie és dokumentálnia.

------------------------------------------------------------------------

## 1. feladat -- Hálózat megtervezése

-   Adj statikus IP címet a szervernek.
-   Határozz meg DHCP tartományt (legalább 60 cím).
-   Jelölj ki egy külön, DHCP-ből kizárt (exclusion) tartományt a
    jövőbeli statikus eszközök számára (pl. nyomtatók, switchek).
-   Állíts be gateway-t és DNS-t.
-   Indokold meg a választott lízingidőt (lease time) a hálózat
    jellege alapján.

Dokumentáld a választásaidat és az indoklásaidat.

------------------------------------------------------------------------

## 2. feladat -- DHCP szerver

-   DHCP szerepkör telepítése.
-   Scope létrehozása a megtervezett tartomány alapján.
-   Exclusion tartomány beállítása.
-   Gateway, DNS, domain (DNS suffix) beállítása a scope opciói között.
-   Foglalás (reservation) létrehozása legalább egy géphez MAC cím
    alapján.
-   Dokumentáld a fontosabb lépéseket és a scope beállításait
    képernyőképekkel.

------------------------------------------------------------------------

## 3. feladat -- DNS szerver

-   DNS szerepkör telepítése.
-   Forward keresési zóna létrehozása: vallalat.local
-   Rekordok létrehozása:
    -   www.vallalat.local (A rekord)
    -   intra.vallalat.local (A rekord, belső weboldalhoz)
    -   ftp.vallalat.local (A rekord vagy CNAME a www-re)
-   Reverse (fordított) keresési zóna létrehozása a hálózathoz.
-   Tesztelés `nslookup` és `ping` paranccsal, mind a négy névre.
-   Dokumenáld a fontosabb lépéseket és a teszteredményeket.

------------------------------------------------------------------------

## 4. feladat -- IIS (két weboldal, HTTP + HTTPS)

-   IIS szerepkör telepítése.
-   Két különálló weboldal létrehozása, saját mappával:
    -   **Publikus oldal** -- www.vallalat.local
    -   **Belső oldal** -- intra.vallalat.local

### HTTP

-   Mindkét oldal érje el port 80-on.
-   Az azonosítás host header (állomásfejléc) alapján történjen, mivel
    egy IP-címen fut mindkét oldal.
-   Készíts mindkét oldalhoz egy egyszerű, egymástól megkülönböztethető
    HTML kezdőlapot.

### HTTPS

-   Hozz létre önaláírt tanúsítványt mindkét névhez (vagy egy közös,
    több nevet tartalmazó tanúsítványt, SAN mezővel).
-   Állíts be HTTPS binding-ot port 443-on mindkét oldalhoz.
-   Ellenőrizd, hogy a böngésző a megfelelő oldalt jeleníti-e meg mind
    a két domainnél.

Tesztelés böngészőből, mindkét oldal esetén HTTP-n és HTTPS-en is.

------------------------------------------------------------------------

## 5. feladat -- FTP szerver

-   FTP szerepkör (szolgáltatás) telepítése.
-   FTP site létrehozása, cím: ftp.vallalat.local.
-   Basic Authentication engedélyezése.
-   Két felhasználó létrehozása:
    -   egy felhasználó **olvasás + írás** joggal,
    -   egy felhasználó **csak olvasás** joggal.
-   Állíts be FTP user isolation-t (felhasználói mappa-elkülönítést),
    ha lehetséges.
-   Dokumenáld a fontosabb lépéseket és a jogosultsági beállításokat.

------------------------------------------------------------------------

## 6. feladat -- Tűzfal beállítása

-   Ellenőrizd, hogy a Windows Defender tűzfal engedélyezi-e a
    szükséges portokat/szolgáltatásokat:
    -   DHCP (UDP 67/68)
    -   DNS (UDP/TCP 53)
    -   HTTP (TCP 80) és HTTPS (TCP 443)
    -   FTP (TCP 21 és a passzív port tartomány)
-   Ha szükséges, hozz létre bejövő szabályt a hiányzó szolgáltatáshoz.
-   Dokumenáld, mely szabályokat találtad meg, illetve melyeket kellett
    létrehoznod.

------------------------------------------------------------------------

## 7. feladat -- Tesztelés

-   DHCP működik, a kliens a megtervezett tartományból kap címet.
-   A foglalás (reservation) a megfelelő géphez a megfelelő címet
    rendeli.
-   DNS feloldás működik mind a négy rekordra.
-   A publikus és a belső weboldal is elérhető HTTP-n és HTTPS-en,
    mind IP-cím, mind domain név alapján.
-   FTP-n keresztül igazolni kell a bejelentkezést mindkét
    felhasználóval, valamint legalább egy fájl fel- és letöltését.
-   A tűzfalszabályok nem akadályozzák egyik szolgáltatás elérését sem.

Dokumentáld a teszteredményeket képernyőképekkel.

------------------------------------------------------------------------

## Beadandó dokumentáció

-   A hálózattervezés (IP-cím, DHCP-tartomány, exclusion, lease time)
    rövid indoklása.
-   A DHCP szolgáltatás működésének igazolása (scope, reservation).
-   A DNS névfeloldás működésének igazolása mind a négy rekordra.
-   Mindkét IIS weboldal elérésének igazolása HTTP-n és HTTPS-en.
-   Az FTP szolgáltatás működésének igazolása mindkét felhasználóval.
-   A tűzfalbeállítások rövid összefoglalása.
-   Képernyőképek minden szolgáltatás állapotáról és a kliensoldali
    tesztekről.

------------------------------------------------------------------------

## Értékelési szempontok

| Szempont | Pontszám |
|---|---|
| Hálózattervezés (IP, DHCP-tartomány, exclusion, indoklás) | 10 pont |
| DHCP szolgáltatás (scope, reservation) | 15 pont |
| DNS szolgáltatás (zónák, rekordok, reverse zóna, tesztelés) | 20 pont |
| IIS -- két weboldal HTTP-n | 15 pont |
| IIS -- HTTPS beállítása mindkét oldalhoz | 15 pont |
| FTP szolgáltatás (két felhasználó, jogosultságok) | 15 pont |
| Tűzfalbeállítás | 5 pont |
| Tesztelés és dokumentáció minősége | 5 pont |
| **Összesen** | **100 pont** |

------------------------------------------------------------------------

## Megjegyzés

A feladatkiírás szándékosan nem tartalmaz kész IP-címtervet és
DHCP-tartományt; ezeket a tanulónak kell meghatároznia és a beadandó
dokumentációban bemutatnia, a saját döntéseinek rövid indoklásával
együtt.
