# Sulis Jegyzetek — [ Informatikából ]

> Egy rendezett, közösségi GitHub-repozitórium a sulihoz: jegyzetek, példák, feladatok és rövid megoldások. Használd, bővítsd, és ne félj PR-t küldeni — mindenki jobban tanul együtt.

---

## Tartalomjegyzék
1. [Leírás](#leírás)  
2. [Mappa struktúra](#mappa-struktúra)  
3. [Használat — gyorsan](#használat---gyorsan)  
4. [Hozzájárulás (Contributing)](#hozzájárulás-contributing)  
5. [Szabályok a jegyzetekhez](#szabályok-a-jegyzetekhez)  
6. [Licenc](#licenc)  
7. [Kapcsolat](#kapcsolat)  
8. [Roadmap / Tervek](#roadmap--tervek)

---

## Leírás
Ez a repo a A teljes Szoftverfejlesztő és -Tesztelő szakmában használt jegyzetek gyűjteménye illetve a főbb érettségi tantárgyakból. Cél: **átlátható, könnyen kereshető és közösségileg karbantartott** forrás létrehozása, ami segít vizsgára készülni, gyakorolni és tanulni.

---

## Mappa struktúra
Ajánlott struktúra — igazítsd a saját tantárgyaidhoz:

/ Jegyzetek
├─ Bláthy/  
│ ├─ adatbazis-kezeles-I/
│ ├─ halozatok-I/
│ ├─ /halozatok-II/
│ ├─ halozatok-programozasa-es-iot/
│ ├─ ikt-projektmunka-I/
│ ├─ ikt-projektmunka-II/
│ ├─ info-alapok-I/
│ ├─ info-alapok-II/
│ ├─ munkavallaloi-idegen-nyelv/
│ ├─ munkavallaloi-ismeretek/
│ ├─ prog-alapok/
│ ├─ szakmai-angol/
│ └─ szerverek-es-felhoszolgaltatasok/
├─ Schola/  
│ ├─ 13/
│ ├─ 14/
│ ├─ Kövesdiné/
│ ├─ Projekt/
├─ [[Homepage]]
├─ LINCESE
└─ Readme

---

## Használat — gyorsan
Kliens oldalon (git telepítve):
```bash
# klónozás
git clone https://github.com/doomhyena/lesson-notes.git

# új tartalom hozzáadása (lokálisan)
git checkout -b feat/uj-jegyzet
# szerkesztés...
git add .
git commit -m "Hozzáadva: 03_feladatok.md a Tantárgy-X-hez"
git push origin feat/uj-jegyzet
# majd nyiss PR-t a GitHubon

Markdown szabályok: használj `#` headingeket, rövid bekezdéseket, és kódblokkoknál ` ```lang ` jelölést.
```
---

## Hozzájárulás (Contributing)

Nagyon szeretjük az ötleteket! Kövesd ezt:

1. Fork-old a repót.

2. Hozz létre feature branch-et (`feat/…` vagy `fix/…`).
3. Tegyél egy tiszta commit üzenetet.
4. Nyiss Pull Request-et — írj rövid leírást, mi változott.

Kérjük, kerüld a nagy, mindent egyszerre megváltoztató PR-eket — inkább kisebb, atomikus változtatások. Ha bizonytalan vagy, írj egy issue-t először.

---

## Licenc

**MIT License** 

---

## Kapcsolat

Ha kérdésed van, vagy szeretnéd, hogy segítsek integrálni CI-t / automatikus formázást / README személyre szabását:

- E-mail: `[doomhyena.contact@proton.me](mailto:doomhyena.contact@proton.me)`
- GitHub profil: `https://github.com/doomhyena

---

## Roadmap / Tervek

-  Több tantárgy hozzáadása
-  Kvíz/gyakorló feladatok (automata értékeléssel)
-  Összefoglalók vizsgára (1-oldalas cheat sheet-ek)
-  Offline PDF exportálás minden tantárgyról