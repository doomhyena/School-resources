//Mind a 7 elem tartalma ID alapján legyen kikeresve:
const egyenlegElem = document.getElementById("egyenleg");
const pluszElem = document.getElementById("moneyPlus");
const minuszElem = document.getElementById("moneyMinus");
const formElem = document.getElementById("form");
const szovegesElem = document.getElementById("userText");
const arElem = document.getElementById("bevetel");
const listaElem = document.getElementById("list");

let szerkesztesModban = false;
let szerkeszto = null;

let adatok = HelyitLeker();

function ListaElemKreal(bevetel) {
  const liElem = document.createElement("li");//Tartalomnak hozz létre egy "li" elemet.

  const attr = document.createAttribute(`bevetel-id`);
  attr.value = bevetel.id;

  liElem.setAttributeNode(attr);

  liElem.classList.add(bevetel.bevetel < 0 ? `kiadas` : `bevetel`);
  const liLeft = document.createElement("div")//Tartalomnak hozz létre egy "div" elemet.

  liLeft.classList.add("liLeft");
  const liLeftPara = document.createElement("p");//Tartalomnak hozz létre egy "p" elemet.
  liLeftPara.innerHTML = bevetel.text;
  liLeft.appendChild(liLeftPara);

  liElem.appendChild(liLeft);

  const liRight = document.createElement("div");//Tartalomnak hozz létre egy "div" elemet.
  liRight.classList.add("liRight");
  const textContent = document.createElement("div");//Tartalomnak hozz létre egy "div" elemet.
  textContent.classList.add("textContent");
  const szovegesP = document.createElement("p");//Tartalomnak hozz létre egy "p" elemet.
  szovegesP.innerHTML =
    bevetel.bevetel > -1 ? `+ HUF${bevetel.bevetel}` : `- HUF${Math.abs(bevetel.bevetel)}`;
  textContent.appendChild(szovegesP);
  liRight.appendChild(textContent);
  const beallitasokElem = document.createElement("div");//Tartalomnak hozz létre egy "div" elemet.
  beallitasokElem.classList.add("controls");
  const szerkesztGomb = document.createElement("button");//Tartalomnak hozz létre egy gomb elemet.
  szerkesztGomb.classList.add("edit");
  szerkesztGomb.innerHTML = `<ion-icon name="create"></ion-icon>`;
  beallitasokElem.appendChild(szerkesztGomb);
  const torlesGomb = document.createElement("button");//Tartalomnak hozz létre egy gomb elemet.
  torlesGomb.classList.add("delete");
  torlesGomb.innerHTML = `<ion-icon name="trash"></ion-icon>`;
  beallitasokElem.appendChild(torlesGomb);
  liRight.appendChild(beallitasokElem);
  liElem.appendChild(liRight);
  listaElem.appendChild(liElem);

  szerkesztGomb.addEventListener("click", (e) => {//A szerkesztGomb elemre rakj egy kattintásfigyelőt
    szerkesztesModban = true;
    szerkeszto = liElem;
    szovegesElem.value = bevetel.text;
    arElem.value = bevetel.bevetel;
  });

  torlesGomb.addEventListener("click", (e) => {//A torlesGomb elemre rakj egy kattintásfigyelőt
    liElem.remove();
    adatok = adatok.filter((elem) => elem.id !== attr.value);
    ListaKreal();
    Frissites();
    HelyitTorol(attr.value);
  });
}

function ListaKreal() {
  listaElem.innerHTML = ``;//A listaElem html szöveges tartalma legyen üres.
  if (adatok.length) {
    adatok.forEach((bevetel) => {//Az alábbi művelet az adatok lista minden elemére fusson le
      ListaElemKreal(bevetel);
    });
    Frissites();
  }
}

function Frissites() {
  const osszegek = adatok.map((bevetel) => bevetel.bevetel);

  const egyenleg = osszegek.reduce((akk, ert) => akk + ert, 0).toFixed(2);

  const bevetel = osszegek
    .filter((value) => value > 0)
    .reduce((akk, ert) => akk + ert, 0)
    .toFixed(2);

  const kiadas = (
    osszegek.filter((value) => value < 0).reduce((akk, ert) => akk + ert, 0) * -1
  ).toFixed(2);

  egyenlegElem.innerHTML = egyenleg > -1 ? `HUF${egyenleg}` : `-HUF${Math.abs(egyenleg)}`;
  pluszElem.innerHTML = `HUF${bevetel}`;
  minuszElem.innerHTML = `HUF${kiadas}`;
}

ListaKreal();

formElem.addEventListener("submit", HozzaadSeged);//A formElem-en történő submit esemény hatására hívódjon meg a HozzaadSeged függvény.

function HozzaadSeged(e) {
  e.preventDefault();
  if (szovegesElem.value.trim() && arElem.value.trim()) {
    if (!szerkesztesModban) {
      const bevittAdat = {
        id: RandIdKer(),
        text: szovegesElem.value,
        bevetel: JSON.parse(arElem.value),
      };
      adatok.unshift(bevittAdat);
      Helyibe(bevittAdat);
      ListaKreal();
      szovegesElem.value = ``;
      arElem.value = ``;
    }
    if (szerkesztesModban && szerkeszto) {
      szerkesztesModban = false;
      let szovegElem = szerkeszto.querySelector(".liLeft p");
      let osszegElem = szerkeszto.querySelector(".liRight .textContent p");
      let id = szerkeszto.dataset.id;
      szovegElem.innerHTML = szovegesElem.value;
      osszegElem.innerHTML = arElem.value;

      adatok = adatok.map((elem) => {
        if (elem.id === id) {
          elem.text = szovegesElem.value;
          elem.bevetel = JSON.parse(arElem.value);//Az elem.bevetel tartalma legyen az arElem értéke, JSON formátumban.
        }
        return elem;
      });

      let egytetel = { id, text: szovegesElem.value, bevetel: arElem.value };

      HelyitFrissit(egytetel);

      szovegesElem.value = ``;
      arElem.value = ``;
      szerkeszto = null;
      ListaKreal();
    }
  } else alert("Ez a mező nem lehet üres");//Ebben az esetben az oldal dobjon egy figyelmeztetést, hogy a mező nem lehet üres.
}

function RandIdKer() {
  return Math.floor(Math.random() * 10000000).toString(16);//Az eredmény lefelé kerekített egész szám legyen.
}

function HelyitLeker() {
  return localStorage.getItem("Kiadas Koveto")
    ? JSON.parse(localStorage.getItem("Kiadas Koveto"))
    : [];
}

function Helyibe(egytetel) {
  let lokalisan = HelyitLeker();
  lokalisan.unshift(egytetel);//unshift() = a tömb elejére rak be elemeket
  localStorage.setItem("Kiadas Koveto", JSON.stringify(lokalisan));
}

function HelyitFrissit(egytetel) {
  let lokalisan = HelyitLeker();
  lokalisan = lokalisan.map((elem) => {
    if (elem.id === egytetel.id) {
      elem.text = egytetel.text;
      elem.bevetel = JSON.parse(egytetel.bevetel);
    }
    return elem;
  });
  localStorage.setItem("Kiadas Koveto", JSON.stringify(lokalisan));
}

function HelyitTorol(id) {
  let lokalisan = HelyitLeker();
  lokalisan = lokalisan.filter((elem) => elem.id !== id);
  localStorage.setItem("Kiadas Koveto", JSON.stringify(lokalisan));
}
