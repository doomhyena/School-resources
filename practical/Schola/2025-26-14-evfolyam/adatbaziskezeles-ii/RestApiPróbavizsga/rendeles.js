const express = require('express');
const app = express();


let betegek = [
    { azonosito: 1, nev: "Krechl Éva", szuldatum: "1992-06-13", taj: "656437371" }
];

let orvosok = [
    { azonosito: 1, nev: "Dr. Kovács Elek", szak: "Ideggyógyászat", email: "drkovacs@email.com", jelszo: "valami123" }
];
let vizitek = [];
let rendelesek = [
    { azonosito: 1, orvosID: 1, nap: "Szerda", tol: "09:00", ig: "13:00" }
];

app.use(express.json());

function ujAzonosito(lista) {
    return lista.length > 0 ? Math.max(...lista.map(e => e.azonosito)) + 1 : 1;
}

function betegKereses(azonosito) {
    return betegek.find(b => b.azonosito === azonosito);
}

function orvosKereses(azonosito) {
    return orvosok.find(o => o.azonosito === azonosito);
}

//1. Feladat
function vizitKereses(azonosito) {
    return vizitek.find(v => v.azonosito === azonosito);
}


function orvosBejelentkezes(email, jelszo) {
    return orvosok.find(o => o.email === email && o.jelszo === jelszo);
}

let orvosTokenek = {};

const { v4: uuidv4 } = require('uuid');

app.post('/orvosok/bejelentkezes', (req, res) => {
    const { email, jelszo } = req.body;
    const orvos = orvosBejelentkezes(email, jelszo);
    if (!orvos) return res.status(401).json({ hiba: "Hibás adatok!" });
    const token = uuidv4();
    orvosTokenek[token] = orvos.azonosito;
    res.json({ token, orvosID: orvos.azonosito });
});

function jelenlegiOrvos(req) {
    const token = req.headers["token"];
    const id = orvosTokenek[token];
    //2. Feladat
    return id ? orvosKereses(id) : null;

}

app.get('/betegek', (req, res) => res.json(betegek));

app.get('/betegek/:azonosito', (req, res) => {
    const b = betegKereses(Number(req.params.azonosito));
    if (!b) return res.status(404).json({ hiba: "Nincs ilyen beteg!" });
    res.json(b);
});

app.post('/betegek', (req, res) => {
    const { nev, szuldatum, taj } = req.body;
    // 4. Feladat
    if (!nev || !szuldatum || !taj)
        return res.status(400).json({ hiba: "A név, születési dátum és TAJ megadása kötelező." });
    const beteg = { azonosito: ujAzonosito(betegek), nev, szuldatum, taj };
    betegek.push(beteg);
    res.status(201).json(beteg);
});

app.put('/betegek/:azonosito', (req, res) => {
    const b = betegKereses(Number(req.params.azonosito));
    if (!b) return res.status(404).json({ hiba: "Nincs ilyen beteg!" });
    if (req.body.nev !== undefined) b.nev = req.body.nev;
    if (req.body.szuldatum !== undefined) b.szuldatum = req.body.szuldatum;
    if (req.body.taj !== undefined) b.taj = req.body.taj;
    res.json(b);
});

//5. Feladat
app.delete('/betegek/:azonosito', (req, res) => {
    const index = betegek.findIndex(b => b.azonosito === Number(req.params.azonosito));
    if (index === -1) return res.status(404).json({ hiba: "Nincs ilyen beteg!" });
    betegek.splice(index, 1);
    res.json({ eredmeny: true });
});

app.get('/orvosok', (req, res) => res.json(orvosok));

app.get('/rendelesek/:orvosID', (req, res) => {
    const lista = rendelesek.filter(r => r.orvosID === Number(req.params.orvosID));
    res.json(lista);
});
app.post('/rendelesek', (req, res) => {
    const { orvosID, nap, tol, ig } = req.body;
    if (!orvosID || !nap || !tol || !ig)
        return res.status(400).json({ hiba: "Minden mező kötelező." });
    const rendel = { azonosito: ujAzonosito(rendelesek), orvosID, nap, tol, ig };
    rendelesek.push(rendel);
    res.status(201).json(rendel);
});

app.post('/vizitek/foglalas', (req, res) => {
    const { beteg_id, orvosID, idopont } = req.body;
    if (!betegKereses(beteg_id) || !orvosKereses(orvosID) || !idopont)
        return res.status(400).json({ hiba: "Hibás adatok!" });
    if (vizitek.some(v => v.orvosID === orvosID && v.idopont === idopont))
        return res.status(400).json({ hiba: "Ez az időpont már foglalt ennél az orvosnál!" });
    const vizit = {
        azonosito: ujAzonosito(vizitek),
        beteg_id,
        orvosID,
        idopont,
        lelet_szoveg: "",
        statusz: "folyamatban"
    };
    vizitek.push(vizit);
    res.status(201).json(vizit);
});

app.put('/vizitek/:azonosito/lezar', (req, res) => {
    const orvos = jelenlegiOrvos(req);
    if (!orvos) return res.status(401).json({ hiba: "Csak bejelentkezett orvos írhat leletet!" });
    const vizit = vizitKereses(Number(req.params.azonosito));
    if (!vizit) return res.status(404).json({ hiba: "Nincs ilyen vizit!" });
    if (vizit.orvosID !== orvos.azonosito)
        return res.status(403).json({ hiba: "Csak a saját vizitedet zárhatod le!" });
    vizit.lelet_szoveg = req.body.lelet_szoveg || "";
    vizit.statusz = "lezárt";
    res.json(vizit);
});

app.get('/betegek/:azonosito/leletek', (req, res) => {
    const lista = vizitek
        .filter(v => v.beteg_id === Number(req.params.azonosito) && v.statusz === "lezárt")
        .map(v => ({ idopont: v.idopont, lelet_szoveg: v.lelet_szoveg, orvosID: v.orvosID }));
    res.json(lista);
});

app.get('/orvosok/:azonosito/vizitek', (req, res) => {
    const lista = vizitek.filter(v => v.orvosID === Number(req.params.azonosito) && v.statusz === "folyamatban");
    res.json(lista);
});

//6. Feladat
app.get('/orvosok/:azonosito/regivizitek', (req, res) => {
    const lista = vizitek
        .filter(v => v.orvosID === Number(req.params.azonosito) && v.statusz === "lezárt")
        .map(v => ({ idopont: v.idopont, lelet_szoveg: v.lelet_szoveg, beteg_id: v.beteg_id }));
    res.json(lista);
});

//7. Feladat
const PORT = 6700;
app.listen(PORT, () => {
    console.log(`A kórházi API-ja a http://localhost:${PORT}/betegek linken fut.`);
});
