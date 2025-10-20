//JavaScript tömbök:
var tömb = [4,3,2,1];
var tömbNő = tömb.sort((a,b) => a - b); //Tartalom növekvőbe rendezése
						//Nyílfüggvény
var tömbCsökken = tömb.sort((a,b) => b - a);//Ez csökkenőbe rendezi
//-----------------
//A függvény 2 paramétert várjon: a tömb és a rendezés iránya:
//Pl.: rendezmod([4,2,1,3], "Asc") --> [1,2,3,4];

function rendezmod(tomb, mod){
	if (mod === "Asc") {
		return tomb.sort((a,b) => a - b);
	}
	if (mod === "Des") {
		return tomb.sort((a,b) => b - a);
	}
	return tomb; //Módosult tömb visszakérése
}
//Ellenőrzés:
console.log(rendezmod([4,2,1,3], "Asc"));
//---VAGY---
function rendezmod2(tömb,mod) {
	switch(mod){ //Switch függvény: olyan, mint az if-else
		case 'Asc': //case = abban az esetben
			return tömb.sort((a,b) => a - b);
		case 'Des':
			return tömb.sort((a,b) => b - a);
		default: //olyan, mint az else ág
			return tömb;
	}
}
//-----------------
//Egy betűs tömböt úgy rendezzünk át, hogy a nagybetűk legyenek elől.
//Pl.: ("vaLAMi") --> ("LAMvai")
function szórendez(szo) {
	let betutomb = szo.split(""); //Egy tömb lesz, egyenként betűelemekkel
	let kist = []; //segédtömb a kisbetűknek
	let nagyt = []; //segédtömb a nagybetűknek
	//Mindegyik betűről eldöntjük, hogy melyikbe kerüljön:
	for (i=0;i<betutomb.length;i++) {
		if (betutomb[i] == betutomb[i].toUpperCase()){
			nagyt.push(betutomb[i]);
		} else {
			kist.push(betutomb[i]);
		}
	}
	return nagyt.concat(kist).join("");
}
console.log(szórendez("vaLAMi"));
//-----------------
//Dobozok együttes térfogatát akarjuk kiszámítani.
//Pl.: dobozos([4,2,4], [3,3,3], [1,1,2], [2,1,1]) --> 63
//	   dobozos([1,1,1]) --> 1
function dobozos(...dobozok) {//... = határozatlan elemszám
	let össztérfogat = 0;
	for (i=0;i<dobozok.length;i++) {
		let doboz = dobozok[i]; //aktuális doboz számai
		let térfogat = 1; //Egy adott doboz térfogata lesz
		for (x = 0; x < doboz.length; x++) {
			térfogat = doboz[x] * térfogat;
		}
		össztérfogat += térfogat;
	}
	return össztérfogat;
}

console.log(dobozos([4,2,4], [3,3,3], [1,1,2], [2,1,1]));
//---VAGY---
function dobozos2(...dobozok) {
	let össztérfogat = 0;
	//forEach ciklus: egy konkrét tömbön megy végig
	dobozok.forEach(doboz => { //El kell nevezni a talált elemeket (itt: doboz)
		össztérfogat = össztérfogat + (doboz[0]*doboz[1]*doboz[2]);
	})
	return össztérfogat;
}
console.log(dobozos2([4,2,4], [3,3,3], [1,1,2], [2,1,1]));
//-----------------
//Számoljuk ki egy lista számainak a reciprokának összegét,
//az eredménynek is reciprokát.
//Pl.: [6,3,6] --> 1/6+1/3+1/6 = 2/3 --> 3/2 = 1.5
function reciprok(számok) {
	var összeg = 0;
	for (const elem of számok) { //"A számok lista minden elemére"
		összeg += (1/elem);
	}
	var megoldás = 1/összeg;
	megoldás = megoldás.toFixed(1); //Kerekítés 1 tizedesre
	return megoldás;
}
console.log(reciprok([6,3,6]));
//-----------------
//Egy számtömb legnagyobb elemét keressük:
//Pl.: maxkeres[0,12,87,4] --> 87
function maxkeres(számtömb) {
	//Ez az if csak a legutolsó körben fog aktiválódni:
	if (számtömb.length === 1) {//Ha 1 elem a tömb, akkor azt adjuk vissza
		return számtömb[0];
	}
	//A nagyobbik elem duplikálása az első 2 szám közül:
	if (számtömb[0] > számtömb[1]) {
		számtömb[1] = számtömb[0]; //akkor a [1] tartalma legyen a [0] tartalma
	}
	//Levágjuk az 1-es indexen lévő elemet (tömbnév.splice(index)):
	számtömb = számtömb.splice(1);
	return maxkeres(számtömb);
}
console.log(maxkeres([0,12,87,4]));
/*Ameddig több elem is van a listában, addig folyamatosan
	összeveti egymással az első 2 elemet. Ha a második elem 
	kisebb az elsőnél, akkor változzon meg az első elem a 
	második értékére. Előbb-utóbb eljutunk oda, hogy csak 
	1 elem marad a listában. Akkor aktiválódik a fenti if ág,
	ami visszaadja azt az egy elemet.
*/
