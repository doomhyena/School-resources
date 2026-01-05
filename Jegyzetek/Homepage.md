## 👋 Helló, Kincső!

> [!quote] „A kód olyan, mint a humor. Ha magyarázni kell, rossz.” – Cory House

---

# 🏫 Iskolák

> [!info|class:section-card] **Schola – Szoftverfejlesztő**
>
> ```button
> name 🚀 Nyisd meg a Schola területet
> type link
> action [[Schola Szoftver]]
> ```
>
> ```button
> name 📝 Új Schola jegyzet
> type command
> action QuickAdd: Run QuickAdd (ha van létrehozott template)
> ```
>
> **Gyors linkek:**
> - [[Schola Szoftver]]

---

> [!tip|class:section-card] **Bláthy – Rendszergazda**
>
> ```button
> name 🖧 Nyisd meg a Bláthy területet
> type link
> action [[Bláthy rendszergazda]]
> ```
>
> ```button
> name 🧰 Új Bláthy jegyzet
> type command
> action QuickAdd: Run QuickAdd
> ```
>
> **Gyors linkek:**
> - [[Bláthy rendszergazda]]

---

# 🎯 Mai fókusz

> [!important|class:section-card]
> - [ ] Tanulás 💡  
> - [ ] Kódolás 💻  
> - [ ] Pihenés ☕

---

# 📅 Mai naplóbejegyzés

```dataview
LIST
FROM "napló"
WHERE file.day = date(today)
````

---

# 🧾 Taskok

> [!todo|class:section-card] **Aktuális feladataid**

```dataview
TASK
WHERE !completed
GROUP BY file.link
```

---

# 📝 Legutóbbi jegyzeteim

```dataview
LIST
FROM ""
SORT file.ctime DESC
LIMIT 5
```

---

# 🌱 Projektek státusz

```dataview
TABLE status AS "Státusz"
FROM "projektek"
WHERE status
```

---

# 🌌 Random inspiráció

> [!note|class:section-card] Válassz ki egy régi jegyzetet, és frissítsd ma! 🔄

