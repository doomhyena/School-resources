/*
codepen.io --> JS fül
//-------------------------
Függvények/metódusok:
  - olyan újrafelhasználható kódrész, amely minden meghívás során végrehajt 
	egy előre meghatározott műveletet, mindig az adott értékkel
//Áltlános séma:
function metódusnév(paraméterek) {
	Végrehajtandó műveletek kódja;
	De a végén mindig return statement kell;
}

console.log(metódusnév(konkrétÉrték)); //meghívás konkrét esetre
*/
//-------------------------
//Példa1: A metódus mondja meg egy számról, hogy páros vagy páratlan számú osztója van-e:
function hányosztó(num) {
	var r = []; //Üres lista létrehozása (ebbe kerülnek majd a talált osztók)
	for (var i = 1; i <= num; i++) {
		if (num%i === 0) {
			r.push(i); //r listához adja hozzá az adott számot
		}
	}
	return r.length % 2 === 1 ? 'páratlan' : 'páros';
	//Alternatív if-else: (LogikaiÁllítás) ? MűveletHaTeljesül : MűveletHaNemTeljesül
}
//Meghívás egy knkrét példára:
console.log(hányosztó(4));
//-------------------------
/*Példa2: A metódus vizsgáljon meg egy számlistát, és mindja meg, hogy hány 
	alkalommal van az előzőnél nagyobb szám benne.
Pl.: console.log(egyreNagyobb([10,11,12,9,10])) --> 3	*/
function egyreNagyobb(számok) {
	var eredmény = 0; //Ez lesz a végén kiíratva
	//A ciklus 1-től a lista elemszámáig menjen:
	for (i=1; számol.length; i++) {
//	for (KezdőSzám, MeddigMenjen, Irány)
		//Ha az aktuális listaelem nagyobb, mint az előző elem..."
		if (számok[i]>számok[i-1]) {
			eredmény++; //Akkor az eredmény szám növekedjen 1-el
		}
	}
	return eredmény;
}
console.log(egyreNagyobb([10,11,12,9,10]));
//-------------------------

/*Példa3: váltakozó igaz/hamis lista.
Pl.: console.log(váltakozó(["thsf","dhs","vált","hjz","vált"])) 
	--> [true,true,false,false,true]	*/
function váltakozó(lista) {
	let megoldás = [];//Ebbe kerülnek majd a true/false értékek
	let állapot = true; //Alapesetben true-val kezdünk
	//A ciklus végigmegy a lista hosszán:
	for (let i = 0; i < lista.length; i++) {
		if (lista[i] === "vált") { //"Ha az aktuális elem "vált" tartalmú..."
			állapot = !állapot //Akkor állapot forduljon meg (!)
		}
		megoldás.push(állapot); //Aztán ígyis-úgyis kerüljön be a listába
	}
	return megoldás;
}
console.log(váltakozó(["thsf","dhs","vált","hjz","vált"]));
//-------------------------
Feladat1: A 2 vizsgált lista egyezik-e?
function egyezőListák(lista1,lista2) { //Itt 2 dolgot vártunk be
	//A ciklus végigmegy az egyik lista hosszán:
	for (let i = 0; lista1.length; i++) {
//Ha a lista adott eleme nem egyezik a másik lista ugyanannyiadik elemével:
		if (lista1[i] !== lista2[i]) {
			return false; //Ekkor ezzel ér véget a futás
		}
	}
	return true; //Eddig csak akkor jut el, ha az if egyszer sem teljesült
	//(A futás az első return-ig tart)
}
//Használnám: length, indexek
console.log(egyezőListák([2,3],[2,3]));
//-------------------------
/*
Feladat2: Egy listában minden elem egyezik-e?
Pl.: ["abc","abc","abc","abc"] --> true
	 ["abc","abc","ab","abc"] --> false	*/
function azonos(értékek) {
	let alap =  értékek[0];
	for (let i=0; i<értékek.length;i++) {
		if (értékek[i] !== alap) {
			return false;
		}
	}
	return true;
}
console.log(azonos(["abc","abc","ab","abc"]));
//-------------------------
//Feladat3: X számú félbehajtás után milyen vastag lesz a papírlap?
function félbehajt(n) {
	//n = kívánt félbehajtások száma
	let vastagság = 0.0005; //Alap papírvastagság (méterben)
	for (let i = 0; i<n; i++) {
		vastagság *= 2; //A tartalmát a kétszeresére növeli
	}
	//Sablonszöveg, amelyben szerepel egy változó dinamikus értéke:
	return `Végleges vastagság: ${vastagság} méter.` //AltGr+7 féle idézőjelek
}
console.log(félbehajt(10));
