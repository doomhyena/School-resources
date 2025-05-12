let MaiNap = new Date();
let mostaniHonap = MaiNap.getMonth();
let mostaniEv = MaiNap.getFullYear();
let ValasztottEv = document.getElementById("year");
let ValasztottHonap = document.getElementById("month");

let HonapLista = ["Január", "Február", "Március", "Április", "Május", "Június", "Július", "Augusztus", "Szeptember", "Október", "November", "December"];

let HonapEsEv = document.getElementById("HonapEsEv");
NaptarMutat(mostaniHonap, mostaniEv);

//Előző hónapra ugrás gomb:
function elozo() {
    mostaniEv = (mostaniHonap === 0) ? mostaniEv - 1 : mostaniEv;
    mostaniHonap = (mostaniHonap === 0) ? 11 : mostaniHonap - 1;
    NaptarMutat(mostaniHonap, mostaniEv);
}
//Következő hónapra ugrás gomb:
function kovetkezo() {
    mostaniEv = (mostaniHonap === 11) ? mostaniEv + 1 : mostaniEv;
    mostaniHonap = (mostaniHonap + 1) % 12;
    NaptarMutat(mostaniHonap, mostaniEv);
	//(LogikaiFeltétel) ? HaIgaz : HaHamis;
}
//Ugrás tetszőleges dátumra:
function ugras() {
    mostaniEv = parseInt(ValasztottEv.value);
    mostaniHonap = parseInt(ValasztottHonap.value);
    NaptarMutat(mostaniHonap, mostaniEv);
};

function NaptarMutat(month, year) {
    let ElsoNap = (new Date(year, month)).getDay();
    let NapokSzama = 32 - new Date(year, month, 32).getDate();
    let tablazat = document.getElementById("naptar-torzs");

    tablazat.innerHTML = "";

    HonapEsEv.innerHTML = HonapLista[month] + " " + year;
    ValasztottEv.value = year;
    ValasztottHonap.value = month;

    let datum = 1;
	//Naptár táblázat felépítése sorontént (azok meg cellánként):
    for (let i = 0; i < 6; i++) {
        let sor = document.createElement("tr");
        for (let j = 0; j < 7; j++) {
            if (i === 0 && j < ElsoNap) {
                let cella = document.createElement("td");
                let cellaSzoveg = document.createTextNode("");
				//Cellaszöveg logikai hozzárendelése a cellához:
                cella.appendChild(cellaSzoveg);
				//Cella hozzárendelése a sorhoz:
                sor.appendChild(cella);
//Egy elem logikai alárendelése egy másikhoz: FőElem.appendChild(AlElem)
            }  else if (datum > NapokSzama) {
                break;
            } else {
                let cella = document.createElement("td");
                let cellaSzoveg = document.createTextNode(datum);
				//Mai dátum cellájának kiemelése:
                if (datum === MaiNap.getDate() && year === MaiNap.getFullYear() && month === MaiNap.getMonth()) {
                    cella.classList.add("bg-info");
                }
                cella.appendChild(cellaSzoveg);
                sor.appendChild(cella);
                datum++;
            }
        }
        tablazat.appendChild(sor); //Sor hozzárendelése a táblához
    }
}