# Dinamikus Órarend Webalkalmazás

## Funkcionalitás

- **Órarend megjelenítése**: A felhasználók számára a nap órarendje táblázatos formában jelenik meg.
- **Dinamikus mondat**: Az alkalmazás az aktuális időpontnak megfelelő órát jeleníti meg, amely tartalmazza:
  - Az óra nevét,
  - A tanár nevét,
  - A terem számát.
- Ha nincs óra, akkor a rendszer "Jelenleg szünet van" üzenetet jelenít meg.
- Az alkalmazás automatikusan frissíti az aktuális információkat 1 perces időközönként.

## Használat

1. **Előfeltételek**:
   - PHP és MySQL telepítése szükséges a rendszer futtatásához.
   - Egy webszerver (pl. Apache vagy Nginx) kell a PHP futtatásához.

   - Az adatok feltöltéséhez használd az alábbi SQL parancsokat, amelyeket a feladat tartalmaz.

2. **Fájlok telepítése**:
   - Töltsd fel a `orarend.php`, `style.css` és `script.js` fájlokat a webszerver megfelelő könyvtárába.

3. **Futtatás**:
   - Nyisd meg az alkalmazást a böngészőben. A rendszer automatikusan lekéri az adatokat az adatbázisból, és megjeleníti a napi órarendet.
   - A dinamikus mondat az aktuális órát mutatja, és minden percben frissül.

## Technológiai háttér

- **Frontend**:
  - **HTML**: Az oldal felépítése.
  - **CSS**: A reszponzív design biztosítása és esztétikus megjelenés.
  - **JavaScript**: A dinamikus frissítés és az AJAX kommunikáció az adatbázissal.

- **Backend**:
  - **PHP**: Az adatbázisból történő lekérdezés és a válasz JSON formátumban történő küldése.

- **Adatbázis**:
  - **MySQL**: Az órarend és egyéb szükséges adatok tárolása.


## Fejlesztési lépések

1. **Adatbázis konfigurálása**:
   - A `schedule` tábla létrehozása és az adatok feltöltése.
   
2. **Backend implementálása**:
   - Az `orarend.php` fájl létrehozása, amely a MySQL adatbázisból lekéri az adatokat az aktuális nap és időpont alapján, és JSON válaszként visszaküldi őket.

3. **Frontend implementálása**:
   - HTML és CSS segítségével megjelenítjük az órarendet és a dinamikus mondatot.
   - JavaScript segítségével frissítjük a mondatot és az órarendet egy perces időközönként az `AJAX` hívás segítségével.

## Fejlesztési eszközök

- **Webszerver**: Apache vagy Nginx
- **PHP**: Backend logika és adatbázis kezelés
- **MySQL**: Adatbázis a tanórák adatainak tárolására
- **Böngésző**: Az alkalmazás használatához bármilyen modern böngésző szükséges

## Hibaelhárítás

- **Adatbázis kapcsolat**: Ha a PHP nem tud csatlakozni az adatbázishoz, ellenőrizd a `orarend.php` fájlban a MySQL kapcsolatot.
- **JavaScript hibák**: Ha a dinamikus mondat nem frissül, győződj meg arról, hogy a böngésző konzoljában nincs JavaScript hiba (F12 -> Console).