/*
Példa1: duplikátumok kiszedése a számlistából és sorba rendezés.
Pl.: átrendez([1,4,4,4,4,4,3,2,1,2]) --> [1,2,3,4]
*/
function átrendez(lista) {
	//Elemek növekvő sorba rendezése:
	let rendezett = lista.sort(function(a,b) {return a-b});
	//Duplikátumok kiszedése az új tömbből:
	return Array.from(new Set(rendezett));
		//Array = tömb 
		//from, mert belőle nyerünk ki valamit
		//Set = karaktergyűjtemény (minden egyedi elem csak egyszer lehet benne)
}
//--------------------------------
/*
Példa2: Egy string-ben ugyanannyi X és O van-e?
	- Kis-nagy betű eltérése nem számít
	- Az egyéb karakterekkel nem törődünk
	- Pl.: XO("oooxxoXX") --> true
*/
function XO(szöveg) {
	var x = 0, o = 0; //Ezekbe számoljuk a talált x és o betűket
	//Végigmegy a bekért szövegen és minden karakterről eldönti, hogy x vagy o-e:
	for (var i = 0; i < szöveg.length; i++) {
		if (szöveg[i].toLowerCase() === 'x') { //Talált X esetén az a számláló nő
			x += 1;
		} else if (szöveg[i].toLowerCase() === 'o') { //O esetén a másik nő
			o += 1;
		}
	}
	return x === o; //A végén visszakérjük a választ az egyezésvizsgálatra (true/false)
}

console.log(XO("oooxxoXX"))
//----
function XOalt(szoveg) {
	var x = 0, o = 0;
	szöveg.split('').forEach(function(c) { //c = az adott karakter/betű
		x += (c.toLowerCase() === 'x') ? 1 : 0; // (LogikaiFeltétel) ? HaTeljesült : HaNemTeljesült
		o += (c.toLowerCase() === 'o') ? 1 : 0;
	});
	return x === o;
}
console.log(XOalt("oooxxoXX"))
//--------------------------------
/*
map() függvény:
	- listaNév.map(művelet)
	- A lista minden elemére elvégez egy megadott műveletet
	- Az eredményeket egy új listában adja vissza (az eredeti változatlan marad)

Példa3: Egy betűről megmondjuk, hogy az ABC-ben melyik magánhangzóhoz esik a legközelebb.
	- Ha magánhangzót adunk meg, akkor önmaga a megoldás
	- Ha egyforma messze van 2-től, akkor a hamarabb lévő lesz a megoldás 
*/
function lkmh(betű) {
	let mhlista = ['a','e','i','o','u'];
	//Ha magánhangzót talál, akkor az maga a megoldás:
	if (mhlista.includes(betű)) return betű; //listaNév.includes(keresettElem)
	//Mássalhanzgzó megadása esetén nehezebb dolgunk van:
	//Csinál egy új listát, ahol a mh. és a megadott betű karakterkódjának különbsége lesz:
	let ujLista = mhlista.map(elem => Math.abs(elem.charCodeAt() - betű.charCodeAt(0)));
	return mhlista[ujLista.indexOf(Math.min(...ujLista))];
	//indexOf() = mi az indexe egyadott elemnek; ... = határozatlan elemszám jelölése
}
//--------------------------------
/*
Példa4: Egy sakktáblán a futóval eljuthatunk-e A-ból B-be X lépésből?
Pl.: futó("a1","b4",2) --> true
*/
function futó(kezd,cél,n) {
	//Tudnunk kell, hogy egyenként mennyit kell menni a sorokban és oszlopokban:
	var xkülönbség = Math.abs(cél[0].charCodeAt(0)-kezd[0].charCodeAt(0));
	var ykülönbség = Math.abs(parseInt(cél[1])-parseInt(kezd[1]));
	//Ha a kezdő és célhely különböző színű, akkor sehogy nem juthatunk el oda:
	if ((xkülönbség+ykülönbség) % 2 === 1) return false;
	//Ha van legalább 2 lépés, akkor bárhova eljuthatunk a táblán:
	if (n >= 2) return true;
	//Ha ugyanaz a kiinduló és a célhely:
	if (kezd === cél) return true;
	if (n === 1) {
		if (xkülönbség != ykülönbség) return false;
		else return true;
	}
	return false;
}
//--------------------------------
/*
Példa5: Két számot kérünk be. A második jegyeivel kell minél nagyobbá tenni az elsőt.
Pl.: nagyobbátesz(9328,456) --> 9658
	- Egy jegyet csak egyszer lehet felhasználni
	- A módosított első szám a megolás
*/
function nagyobbátesz(n1,n2) {
	//Az első szám jegyeit simán berakom egy karaktertömbbe:
	let tömb1 = n1.toString().split('');
	//A második szám jegyeit csökkenő sorrendben tömbösítem:
	let tömb2 = n2.toString().split('').sort((a,b) => b-a);
	//Tömb1 összes elemén megnézem, hogy tömb2 bármely eleme nagyobb-e (kicserélhető-e):
	for (let i in tömb1) {
		for (let j in tömb2) {
			if (tömb1[i] < tömb2[j]){ //Ha az eredeti szám kisebb
				tömb1[i] = tömb2[j]; //Akkor kicseréljük az alternatívra
				//De mivel egy alternatív szám csak egyszer használható...
				tömb2.splice(j,1); //...ezért levágjuk azt az alternatív listáról
				//Levágás: listaNeve.splice(Hol,HányElemet)
			}
		}
	}
	//A megoldást egy többjegyű számmá összefűzve kérem vissza, 10-es számrendszerben:
	return parseInt(tömb1.join(''), 10);
}

console.log(nagyobbátesz(9328,456)) //Eredmény: 9658
