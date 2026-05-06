const express = require('express');
const { v4: uuidv4 } = require('uuid');
const app = express();
app.use(express.json());

//Alapadatok:
let felhasznalok = [
    { azonosito: 1, nev: "Admin Anna", email: "admin@pmp.hu", jelszo_hash: "admin", szerep: "admin", token: uuidv4() }
];
let projektek = [];
let feladatok = [];
let kommentek = [];
let cimkek = [
    { azonosito: 1, nev: "Sürgős", szin: "#ff0000" },
    { azonosito: 2, nev: "UI", szin: "#0055cc" }
];

function hashJelszo(jelszo) { return jelszo; }
function keresFelhasznaloToken(token) { return felhasznalok.find(f => f.token === token); }
function keresFelhasznaloId(id) { return felhasznalok.find(f => f.azonosito === id); }
function ujId(lista) { return lista.length ? Math.max(...lista.map(x => x.azonosito)) + 1 : 1; }
function keresProjekt(id) { return projektek.find(p => p.azonosito === id); }
function keresFeladat(id) { return feladatok.find(f => f.azonosito === id); }
function jogosultProjekt(p, user) {
    return user.szerep === "admin" ||
        p.létrehozó_id === user.azonosito ||
        (p.tagok && p.tagok.includes(user.azonosito));
}

//Autentikáció:
app.post('/regisztracio', (req, res) => {
    const { nev, email, jelszo } = req.body;
    if (!nev || !email || !jelszo) return res.status(400).json({ hiba: "Hiányzó adatok." });
    if (felhasznalok.some(f => f.email === email)) return res.status(400).json({ hiba: "Már létezik ilyen email." });
    const user = {
        azonosito: ujId(felhasznalok), nev, email, jelszo_hash: hashJelszo(jelszo),
        szerep: "tag", token: uuidv4()
    };
    felhasznalok.push(user);
    res.status(201).json({ token: user.token });
});
app.post('/bejelentkezes', (req, res) => {
    const { email, jelszo } = req.body;
    const user = felhasznalok.find(f => f.email === email && f.jelszo_hash === hashJelszo(jelszo));
    if (!user) return res.status(401).json({ hiba: "Hibás email vagy jelszó!" });
    user.token = uuidv4();
    res.json({ token: user.token });
});
function auth(req, res, next) {
    const token = req.headers["token"];
    const user = keresFelhasznaloToken(token);
    if (!user) return res.status(401).json({ hiba: "Bejelentkezés szükséges!" });
    req.user = user;
    next();
}

app.get('/felhasznalok', auth, (req, res) => {
    if (req.user.szerep !== "admin") return res.status(403).json({ hiba: "Csak admin!" });
    res.json(felhasznalok);
});

//Projektek:
app.post('/projektek', auth, (req, res) => {
    const { nev, leiras } = req.body;
    if (!nev) return res.status(400).json({ hiba: "Név kötelező!" });
    const projekt = {
        azonosito: ujId(projektek), nev, leiras, létrehozó_id: req.user.azonosito,
        tagok: [req.user.azonosito], statusz: "aktív"
    };
    projektek.push(projekt);
    res.status(201).json(projekt);
});
app.get('/projektek', auth, (req, res) => {
    const projs = req.user.szerep === "admin" ? projektek
        : projektek.filter(p => p.tagok.includes(req.user.azonosito));
    res.json(projs);
});
app.post('/projektek/:pid/tagok', auth, (req, res) => {
    const projekt = keresProjekt(Number(req.params.pid));
    if (!projekt) return res.status(404).json({ hiba: "Nincs ilyen projekt." });
    if (req.user.szerep !== "admin" && projekt.létrehozó_id !== req.user.azonosito)
        return res.status(403).json({ hiba: "Csak projektvezető vagy admin vehet fel tagot!" });
    const { felhasznalo_id } = req.body;
    if (!felhasznalo_id || !keresFelhasznaloId(felhasznalo_id)) return res.status(400).json({ hiba: "Hibás felhasználó." });
    if (!projekt.tagok.includes(felhasznalo_id)) projekt.tagok.push(felhasznalo_id);
    res.json(projekt);
});

//Feladatok:
app.post('/feladatok', auth, (req, res) => {
    const { projekt_id, cim, leiras, felelos_id, hatarido, cimkek: cimkeidk } = req.body;
    const projekt = keresProjekt(projekt_id);
    if (!projekt || !jogosultProjekt(projekt, req.user))
        return res.status(403).json({ hiba: "Nincs jogosultságod ehhez a projekthez!" });
    if (!cim) return res.status(400).json({ hiba: "Cím kötelező!" });
    const feladat = {
        azonosito: ujId(feladatok), projekt_id, cim, leiras, felelos_id: felelos_id || null,
        statusz: "új", hatarido: hatarido || null, cimkek: cimkeidk || [], kommentek: []
    };
    feladatok.push(feladat);
    res.status(201).json(feladat);
});
app.get('/projektek/:pid/feladatok', auth, (req, res) => {
    const projekt = keresProjekt(Number(req.params.pid));
    if (!projekt || !jogosultProjekt(projekt, req.user))
        return res.status(403).json({ hiba: "Nincs jogosultság!" });
    res.json(feladatok.filter(f => f.projekt_id === projekt.azonosito));
});
app.put('/feladatok/:fid/statusz', auth, (req, res) => {
    const feladat = keresFeladat(Number(req.params.fid));
    if (!feladat) return res.status(404).json({ hiba: "Nincs ilyen feladat!" });
    const projekt = keresProjekt(feladat.projekt_id);
    if (!jogosultProjekt(projekt, req.user))
        return res.status(403).json({ hiba: "Nincs jogosultság!" });
    const { statusz } = req.body;
    if (!["új", "folyamatban", "kész"].includes(statusz)) return res.status(400).json({ hiba: "Érvénytelen státusz!" });
    feladat.statusz = statusz;
    res.json(feladat);
});

//Kommentek:
app.post('/feladatok/:fid/kommentek', auth, (req, res) => {
    const feladat = keresFeladat(Number(req.params.fid));
    if (!feladat) return res.status(404).json({ hiba: "Nincs ilyen feladat!" });
    const projekt = keresProjekt(feladat.projekt_id);
    if (!jogosultProjekt(projekt, req.user))
        return res.status(403).json({ hiba: "Nincs jogosultság!" });
    const { szoveg } = req.body;
    if (!szoveg) return res.status(400).json({ hiba: "Szöveg kötelező!" });
    const komment = {
        azonosito: ujId(kommentek), feladat_id: feladat.azonosito, szerzo_id: req.user.azonosito,
        szoveg, idopont: new Date().toISOString()
    };
    kommentek.push(komment);
    feladat.kommentek.push(komment.azonosito);
    res.status(201).json(komment);
});
app.get('/feladatok/:fid/kommentek', auth, (req, res) => {
    const feladat = keresFeladat(Number(req.params.fid));
    if (!feladat) return res.status(404).json({ hiba: "Nincs ilyen feladat!" });
    res.json(kommentek.filter(k => k.feladat_id === feladat.azonosito));
});

//Címkék:
app.get('/cimkek', (req, res) => res.json(cimkek));

//Keresés:
app.get('/kereses/feladatok', auth, (req, res) => {
    const { kulcsszo } = req.query;
    const eredm = feladatok.filter(f => (f.cim + " " + (f.leiras || "")).toLowerCase().includes((kulcsszo || "").toLowerCase()));
    res.json(eredm);
});

//Szerver indítása:
const port = 5000;
app.listen(port, () => {
    console.log(`Projektmenedzsment API fut: http://localhost:${port}/`);
});
