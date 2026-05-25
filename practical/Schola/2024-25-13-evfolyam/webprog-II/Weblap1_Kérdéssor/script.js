//Mögöttes változók az oldalelemek kezelésére:
const kezdGomb = document.getElementById('start-gomb');
/*Ahol:
	- const kezdGomb: mögöttes változó, hogy funkciókat csatolhassunk hozzá
	- document: magát weblapot jelöli
	- getElementById('elemID'): az ID-je alapján találja meg az elemet
*/
const kovetkezoGomb = document.getElementById('kovi-gomb');//Mert a másik fájlban 'kovi-gomb' ID-vel szerepel.
const kerdesTarto = document.getElementById('kerdes-doboza');
const kerdesElem = document.getElementById('kerdes');
const valaszGombElem = document.getElementById('egyediValasz-gombok');
//2 további segédváltozó: egy a randomizált kérdéseknek, egy a sorrend nyomonkövetésére:
let megkevertKerdesek, jelenlegiKerdesIndex;
//Ha a "Játék kezdése" gombra kattintanak, akkor kezdődjön el a kérdéssor:
kezdGomb.addEventListener('click', jatekKezdes);
//	- ElemNeve.addEventListener('esemény', MiTörténjen)
//	- A jatekKezdes függvény lejjebb lesz megírva, itt csak behívakozzuk
//	- Paraméter nélküli függvény meghívásakor nem kötelező a zárójel
//A "Következő gomb" viselkedése:
kovetkezoGomb.addEventListener('click', () => { //ez egy nyílfüggvény forma
	jelenlegiKerdesIndex++; //Számon tartjuk, hogy épp hanyadik kérdés jön
	koviKerdes(); //A következő kérdés betöltéséért felelős függvény lesz lejjebb
});
//A játék elkezdéséért felelős függvény:
function jatekKezdes() {
	//Elrejtjük a "Játék kezdése" gombot:
	kezdGomb.classList.add('hide');
	/*Ahol:	- classList: az elemre vonatkozó formázások listája
			- add('formázásNeve'): egy CSS osztály behivatkozása	*/
	//Beolvassuk a kérdések (és válaszok) listájából a dolgokat, de random sorrendben:
	megkevertKerdesek = kerdesek.sort(() => Math.random() - .5);
	//A kérdéssorszám számolása mindenképp előről kezdődjön:
	jelenlegiKerdesIndex = 0;
	//Levesszük az elrejtést a kérdéstartó dobozról:
	kerdesTarto.classList.remove('hide'); //remove() = levétel
	//Behívjuk az első kérdést:
	koviKerdes(); //ez a függvény szintén alább lesz megírva
};
//Következő kérdés behívása:
function koviKerdes() {
	visszallit();
	kerdesMutat(megkevertKerdesek[jelenlegiKerdesIndex]);
}
//Új kérdés tartalmának betöltése:
function kerdesMutat(kerdes) {
	kerdesElem.innerText = kerdes.kerdes //A kérdés szövegének kiírása
	//Menjen végig a kérdéshez tartozó válaszlehetőségeken és...
	kerdes.valaszok.forEach(egyediValasz => {
		const vGomb = document.createElement('button');//...hozzon létre nekik 1-1 gombot
		vGomb.innerText = egyediValasz.text //...a válaszlehetőség gomb szövege
		vGomb.classList.add('btn') //rá is húzzuk a kellő formázást a gombokra
		//Helyes-e az adott válaszlehetőség:
		if (egyediValasz.helyes) {
			vGomb.dataset.helyes = egyediValasz.helyes;
		}
		//Válaszlehetőség bejelölésének feldolgozása:
		vGomb.addEventListener('click', valasztJelol);
		valaszGombElem.appendChild(vGomb); //Gombok hozzárendelése a válasz mezőhjöz
	})
}
//A megválaszolás utáni formázás levétele:
function visszallit() {
	statuszUrit(document.body) //Mögöttes paraméterek visszaállítása
	kovetkezoGomb.classList.add('hide'); //elrejtjük a Következő gombot
	while (valaszGombElem.firstChild) { //vegye le a hozzárendelt elemeket
		valaszGombElem.removeChild(valaszGombElem.firstChild)
	}
}
//Kezeljük le a válaszlehetőség megjelölésének működését:
function valasztJelol(e) { //e = event = esemény
	const megjeloltGomb = e.target;
	const helyes = megjeloltGomb.dataset.helyes;
	statuszJel(document.body, helyes) //Ez színezi ki az oldalt zöldre/pirosra
	Array.from(valaszGombElem.children).forEach(vGomb => {
		statuszJel(vGomb,vGomb.dataset.helyes)
	})
	//A kérdéssor végére értünk?
	if (megkevertKerdesek.length > jelenlegiKerdesIndex + 1) { //Ha még van hátra kérdés
		kovetkezoGomb.classList.remove('hide');
	} else {//Ha elfogytak a kérdések:
		kezdGomb.innerText = 'Újrakezd'; //Az Újrakezd gomb igazából csak egy átfogalmazott Kezdés gomb
		kezdGomb.classList.remove('hide');
	}
}
//Piros/zöld megjelenés felruházása a válasz helyességétől függően:
function statuszJel(elem, helyes) {
	statuszUrit(elem) //Levesszük az esetleges korábbi formázástokat
	if (helyes) { //Ha a helyesség értéke true:
		elem.classList.add('helyes'); //akkor rárakjuk az igaz válaszhoz illő formázást
	} else { //egyéb esetben a helytelen válasz formázását kapja meg:
		elem.classList.add('helytelen');
	}
}
//Helyesség jelzésének levétele, bármely esetben:
function statuszUrit(elem) {
	elem.classList.remove('helyes');
	elem.classList.remove('helytelen');
}
//Kérdések listája:
const kerdesek = [
//(ez egy összetett szótárlista, nagyon figyeljünk a zárójelezésre)
	{
		kerdes: 'Mi 2 + 2?', //a kérdés megjelenő szövege
		valaszok: [ //válaszlehetőségek szövege és hogy helyes-e az adott válasz:
			{text: '4', helyes: true},
			{text: '22', helyes: false}
		]
	},
	{
		kerdes: 'Mi 7 * 7?',
		valaszok: [
			{text: '7', helyes: false},
			{text: '21', helyes: false},
			{text: '49', helyes: true},
			{text: '42', helyes: false}
		]
	},
	{
		kerdes: 'Ez melyik programnyelv?',
		valaszok: [
			{text: 'C', helyes: false},
			{text: 'C#', helyes: false},
			{text: 'JS', helyes: true},
			{text: 'SQL', helyes: false}
		]
	}
]
