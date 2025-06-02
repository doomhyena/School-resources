### **Dolgozat: Dinamikus órarend webalkalmazás**

#### **Feladat:**
Készíts egy webalkalmazást, amely egy iskolai órarendet jelenít meg. Az órarendet egy adatbázisból (MySQL) kell feltölteni, és a rendszernek képesnek kell lennie az adatok lekérésére és megjelenítésére. A felületnek tartalmaznia kell egy dinamikusan változó mondatot, amely megjeleníti a felhasználónak az aktuális időpontban esedékes órát, annak helyszínét és típusát.

---

#### **Követelmények:**

1. **Frontend**:
   - HTML és CSS segítségével tervezd meg az órarend megjelenését.
   - A felhasználói felület legyen reszponzív, áttekinthető és esztétikus.
   - Javascript segítségével jelenjen meg egy dinamikusan változó mondat az órarend alatt, amely tartalmazza:
     - Az aktuális óra nevét.
     - Az óra helyszínét (pl. teremszám).
     - Az óra típusát (pl. elmélet, gyakorlat).
     - Ha nincs óra, jelezze, hogy jelenleg szünet van.

2. **Backend**:
   - PHP-t használj az adatbázisból való adatok lekérésére.
   - Az adatok lekérése és megjelenítése AJAX hívással történjen, hogy az oldal ne töltődjön újra minden változáskor.

3. **Adatbázis (MySQL)**:
   - Készíts egy adatbázist `orarend` néven, amely tartalmazza az alábbi táblázatot:
     - `tantargyak` tábla:
       - `id` (egyetlen kulcs, automatikusan növekvő szám).
       - `tantargy_nev` (a tantárgy neve, pl. "Matematika").
       - `tipus` (az óra típusa, pl. "Elmélet" vagy "Gyakorlat").
       - `terem` (helyszín, pl. "203-as terem").
       - `nap` (a hét napja, pl. "Hétfő").
       - `idopont` (óra kezdési időpontja, pl. "08:00").
       - `idopont_vege` (óra vége, pl. "09:30").

4. **Dinamikus funkciók**:
   - Javascript segítségével az oldal folyamatosan figyelje az aktuális időt, és az órarend alatt automatikusan megjelenjen a megfelelő mondat (pl. *"Jelenleg **Informatika és távközlési alapok II.** óra van, tanár: **Hujber Balázs**, teremszám: **30**."*).
   - Ha épp nincs óra, jelenjen meg a következő szöveg: *"Jelenleg szünet van."*

---

#### **Működés menete**:

1. **Adatok feltöltése**:
   - Az órarend adatait adminisztrátorként (vagy manuálisan) az adatbázisba kell feltölteni.

2. **Adatok megjelenítése**:
   - Az alkalmazás induláskor lekéri az adatbázisból a teljes órarendet és megjeleníti táblázatos formában.

3. **Dinamikus mondat frissítése**:
   - Javascript (pl. `setInterval`) segítségével az oldal 1 perces időközönként frissíti az aktuális órára vonatkozó információkat, amit az adatbázisból kér le.

---

#### **Használható Programnyelvek**:
- **Frontend**: HTML, CSS, Javascript
- **Backend**: PHP
- **Adatbázis**: MySQL
- **Kommunikáció**: AJAX

--

### Segítség:

```SQL

-- Hétfő
INSERT INTO schedule (day, start, end, name, teacher, room) VALUES
('Hétfő', '08:30', '10:00', 'Programozási Alapok I.', 'Kiss Ádám', '28'),
('Hétfő', '10:15', '11:45', 'Programozási Alapok I.', 'Kiss Ádám', '28'),
('Hétfő', '12:00', '13:30', 'Asztali Alkalmazások I.', 'Hujber Balázs', '30'),
('Hétfő', '13:45', '15:15', 'Asztali Alkalmazások II.', 'Wuncs Dávid', '30'),
('Hétfő', '15:30', '17:00', 'Asztali Alkalmazások I.', 'Hujber Balázs', '30');

-- Kedd
INSERT INTO schedule (day, start, end, name, teacher, room) VALUES
('Kedd', '08:30', '10:00', 'Tanítás Nélküli Nap', NULL, NULL),
('Kedd', '10:15', '11:45', 'Tanítás Nélküli Nap', NULL, NULL),
('Kedd', '12:00', '13:30', 'Tanítás Nélküli Nap', NULL, NULL),
('Kedd', '13:45', '15:15', 'Tanítás Nélküli Nap', NULL, NULL),
('Kedd', '15:30', '17:00', 'Tanítás Nélküli Nap', NULL, NULL);

-- Szerda
INSERT INTO schedule (day, start, end, name, teacher, room) VALUES
('Szerda', '08:30', '10:00', 'Szakmai Angol', 'Kövesdiné Lám Zsuzsánna', '23'),
('Szerda', '10:15', '11:45', 'Adatbázis', 'Kiss Ádám', '30'),
('Szerda', '12:00', '13:30', 'IKT I.', 'Kiss Ádám', '30'),
('Szerda', '13:45', '15:15', 'Szoftvertesztelés', 'Kiss Ádám', '30');

-- Csütörtök
INSERT INTO schedule (day, start, end, name, teacher, room) VALUES
('Csütörtök', '08:30', '10:00', 'Nincs óra', NULL, NULL),
('Csütörtök', '10:15', '11:45', 'Webprogramozás I.', 'Kiss Ádám', '25'),
('Csütörtök', '12:00', '13:30', 'Webprogramozás II.', 'Varga József', '25'),
('Csütörtök', '13:45', '15:15', 'Webprogramozás II.', 'Varga József', '25'),
('Csütörtök', '15:30', '17:00', 'Informatika és távközlési alapok I.', 'Kumpera Ferenc', '11');

-- Péntek
INSERT INTO schedule (day, start, end, name, teacher, room) VALUES
('Péntek', '08:30', '10:00', 'Nincs óra', NULL, NULL),
('Péntek', '10:15', '11:45', 'Informatika és távközlési alapok III.', 'Varga József', '28'),
('Péntek', '12:00', '13:30', 'Informatika és távközlési alapok II.', 'Hujber Balázs', '30'),
('Péntek', '13:45', '15:15', 'Nincs óra', NULL, NULL),
('Péntek', '15:30', '17:00', 'Nincs óra', NULL, NULL);


```
