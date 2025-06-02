# **Értékelés**

---

## **1. Felhasználói felület (Frontend)**

### Feladatleírás elvárása:
- Az alkalmazás HTML és CSS segítségével készüljön.
- A felület legyen reszponzív és esztétikus.
- Egy dinamikus szöveg jelenjen meg, amely az aktuális óráról ad információt.

### Megvalósítás:
- A mellékelt `style.css` fájl biztosít alapvető stílusokat, de reszponzivitás nem került implementálásra. 
- A dinamikus szöveg megjelenítése az aktuális óráról részben teljesült:
  - Az órák adatainak lekérése megtörténik (`orarend.php`).
  - A megjelenítés nincs kifejezetten reszponzívra tervezve.
  - Nincs explicit funkció a "Jelenleg szünet van" szöveg megjelenítésére.

### Hiányosságok:
- Reszponzív dizájn teljes hiánya.
- A dinamikus szöveghez nem tartalmaz külön mezőt vagy kiemelt megjelenítést.

### Értékelés:
**6/10 pont**

---

## **2. Backend funkciók**

### Feladattleírás elvárása:
- Az adatok PHP segítségével érkezzenek az adatbázisból.
- Az adatok AJAX segítségével jelenjenek meg újratöltés nélkül.

### Megvalósítás:
- Az `orarend.php` helyesen lekérdezi az adatokat az adatbázisból.
- A JavaScript (`script.js`) AJAX-hívással frissíti az adatokat (`setInterval` használata).
- Az aktuális idő figyelése nem pontos, mert az adatbázisból kikerülő órákhoz nincs hozzárendelve az óra típusa vagy teremszám.

### Hiányosságok:
- A `orarend.php` nem teljesíti a szövegben elvárt összes adat megjelenítését (pl. terem, típus).
- Nincs biztonsági ellenőrzés az SQL lekérdezéseknél (pl. SQL injection).

#### Értékelés:
**7/10 pont**

---

Ha az adatbázis jól van felépítve, akkor a **Backend** szekciót magasabb pontszámmal lehet értékelni, mivel az adatbázis a rendszer alapvető része. A pontos pontozás azonban attól függ, hogy a többi követelmény milyen mértékben teljesül. A következő módosított értékelés alkalmazható:

---

## **3. Adatbázis-struktúra**

### Feladatleírás elvárása:
- Az adatbázis `tantargyak` táblát tartalmazzon, megfelelő mezőkkel (pl. `tantargy_nev`, `tipus`, `terem`, stb.).
- Az adatbázis támogassa az órarend teljes funkcionalitását.

### Megvalósítás:
- Az adatbázis megfelelő szerkezettel rendelkezik, amely lefedi a tantárgyak, típusok, időpontok és helyszínek tárolását.
- Minden szükséges adat elérhető a megjelenítéshez és az aktuális óra követéséhez.

### Értékelés (módosítva):
- **10/10 pont**, ha a teljes struktúra helyes, és a lekérdezések jól használják.

---

## **4. Dinamikus frissítés és mondat**

### Feladatleírás elvárása:
- Dinamikus szöveg jelenjen meg, amely tartalmazza:
  - Az aktuális óra nevét, helyszínét, típusát.
  - Jelezze, ha szünet van.

### Megvalósítás:
- A frissítés megvalósul a `script.js` segítségével.
- A mondat nem teljes, csak az óra neve és időszaka kerül megjelenítésre.

### Hiányosságok:
- Nincs "Jelenleg szünet van" üzenet.
- Az aktuális óra helyszíne és típusa nem kerül megjelenítésre.

### Értékelés:
**5/10 pont**

---
### **Összesített pontszám**

| Funkció | Pontszám |
| --- | --- |
| Felhasználói felület (Frontend) | 6/10 |
| Backend funkciók (AJAX, PHP) | 8/10 |
| Adatbázis-struktúra | 10/10 |
| Dinamikus frissítés és mondat | 5/10 |
| **Összesen** | **29/40** |

---

### **Végső százalék:**

- **72,50%**

### **Osztályzatok Eloszlása:**

- 1-es (elégtelen): 0–59%
- 2-es (elégséges): 60–74%
- 3-as (közepes): 75–84%
- 4-es (jó): 85–94%
- 5-ös (jeles): 95–100%
