let jegyzetlista = mentettJegyzetListazas();
/*Az összes jegyzetet egy nagy listában tároljuk.
	Mind a cím, mind pedig a tartalom szerepelni fog.*/
/*A mentettJegyzetListazas() függvény most nem lejjebb lesz 
	található, hanem konkrétan egy másik JavaScript 
	fájlból fogjuk behívni.*/
/*Kell egy idő-néző változó, amit később meghívva 
	elmenthetjük majd a létrehozás/legutóbbi 
	szerkesztés pontos idejét:*/
const idoPont = moment().valueOf();
const rendezesek = {
    kerSzoveg: '',
    miAltal: 'szerkAlapjan'
};

jegyzetMegjelenites(jegyzetlista, rendezesek);
'use strict'

document.querySelector('#jegyzet-letrehoz').addEventListener('click', () => {
    const id = uuidv4(); //Ez generál egy megfelelő azonosítót a jegyzetnek.
    jegyzetlista.push({
        id: id,
        jcim: '',
        body: '',
        letrehozD: idoPont,
        szerkD: idoPont,
    });
    jegyzetMentes(jegyzetlista);
    location.assign(`./szerkeszt.html#${id}`);
	/*	- Alapraméretezett hely: a projekt gyökérkönyvtára
		- Idézőjel: az AltGr+7 fajta
		- Itt kellett az id is, hogy tudja, melyik jegyzetet szerkesztem épp.
	*/
});

//Keresés a jegyzetek között szöveg alapján:
	//Először kikerestem a szövegdobozt. 
	//Aztán ráraktam egy eseményfigyelőt, ami ezúttal az inputot nézi.
	//Itt az input esemény alatt a gépelést/szövegbevitelt értem.
	//Ehhez alapból kell egy (e) (event) paraméter:
document.querySelector('#keresett-szoveg').addEventListener('input', (e) => {
    rendezesek.kerSzoveg = e.target.value;
    jegyzetMegjelenites(jegyzetlista, rendezesek);
});
/*Volt egy legördülő lista, amiben 3 rendezési mód közül lehetett
	választani a meglévő jegyzeteink sorba rendezésére.*/
document.querySelector('#szures-mod').addEventListener('change', (e) => {
    /*'change' esemény: amikor a legördülő listában kiválasztunk 
		egy másik elemet, amely eltér a jelenlegitől.*/
	rendezesek.miAltal = e.target.value;
    jegyzetMegjelenites(jegyzetlista, rendezesek);
})
/*Tárolási esemény. Azért, hogy ha bezárjuk az appot, akkor 
a jegyzetlistánk ne vesszen el: */
window.addEventListener('storage', (e) => {
    if (e.key === 'jegyzetlista'){
        jegyzetlista = JSON.parse(e.newValue);
        jegyzetMegjelenites(jegyzetlista, rendezesek);
    }
})
