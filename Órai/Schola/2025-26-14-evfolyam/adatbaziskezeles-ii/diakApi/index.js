const express = require('express');
const app = express();

app.use(express.static('public'));

app.listen(3000, () => {
  console.log('Server is running on port 3000');
});

let diakok = [
    {azonosito: 1, nev:'Roy Miller', email: 'kiss.adam@scholaeu.hu', szak:"Szoftverfejlesztő"},
    {azonosito: 2, nev:'Caitlyn Wilkinson', email: 'csontoskincso@doomhyena.hu', szak:"Szoftverfejlesztő"}
];

function ujAzonosito() {
    return diakok.length > 0 ? Math.max(...diakok.map(diak => diak.azonosito)) : 1;
}

app.get('/diakok', (req, res) => {
    res.json(diakok);
})

app.get('/diakok/:azonosito', (req, res) => {
    const azonosito =parseInt(req.params.azonosito);
    const diak = diakok.find(diak => diak.azonosito === azonosito);
    if (!diak) {
        res.status(404).json({ error: 'Nincsen ilyen diák!' });
        return;
    }
    res.json(diak);
})

app.post('/diakok', (req, res) => {
    const {nev, email, szak} = req.body;
    if(!nev) {
        res.status(400).json({ error: 'A név megadása kötelező!' });
        return;
    }
    const diak = {
        azonosito: ujAzonosito(),
        nev,
        email: email || "",
        szak: szak || ""
    };
    diakok.push(diak);
    res.status(201).json(diak);
})

app.put('/diakok/:azonosito', (req, res) => {
    const azonosito = parseInt(req.params.azonosito);
    const index = diakok.findIndex(diak => diak.azonosito === azonosito);
    if (index === -1) {
        res.status(404).json({ error: 'Nincsen ilyen diák!' });
        return;
    }
    const {nev, email, szak} = req.body;
    if (nev !== undefined) diak.nev = nev;
    if (email !== undefined) diak.email = email || "";
    if (szak !== undefined) diak.szak = szak || "";
    res.json(diak);
})

app.delete('/diakok/:azonosito/tanulok', (req, res) => {
    const azonosito = parseInt(req.params.azonosito);
    const diak = diakok.find(diak => diak.azonosito === azonosito);
    if (index === -1) {
        res.status(404).json({ error: 'Nincsen ilyen diák!' });
        return;
    }
    res.json(diak);
})
