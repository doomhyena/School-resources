/*JavaScript függvények:
	- újrafelhasználható kódok/funkciók, amiket a nevük 
		által meghívhatunk konkrét értékekre
	- így elég csak egyszer megírni, aztán akárhonnan akárhányszor meghívhatjuk

Példa séma:

function függvénynév(paraméterek){
	érdemo kód, műveletek...
	return parancs
}

	- function parancs inicializál
	- a függvénynév mögé ()-be kerülnek a kezelt értékek
	- a {}-en belüli részt tekintjük a függvény érdemi részének
	- a végén visszakérjük a megoldást egy return parancs segítségével

Kiíratás séma:

console.log(függvénynév(konkrétÉrtékek));
*/
//----------------------------------------------
//Példa1: a függvény megnézi, hogy 2 adott érték teljesen egyezik-e?
function egyeznek(a,b) {
	//A függvény neve "egyeznek" lesz.
	//2 paramétert fog kezelni (a és b változók)
	if (a === b) { //"Ha a és b tartalma és típusa is egyezik..."
		return true; //"Akkor egy true (igaz) érték legyen a megoldás" 
	} else { //"Egyéb esetben..."
		return false; //"Akkor a válasz egy false (hamis) érték legyen
	} //if-else leezárása
} //a teljes függvény lezárása

console.log(egyeznek(3,"3")) //Ez false (hamis) lesz
//----------------------------------------------
/*Példa2: A 2 bekért érték ugyanannyi karakterből áll-e?
karsz("AB","CD") --> true
karsz("AB","CDE") --> false
*/
function karsz(str1,str2) { //karsz nevű függvény, 2 változóval
	if (str1.length == str2.length) { //"Ha a 2 változó hossza egyenlő..."
		//length parancs: hány karakterből áll az adott szöveg tartalma
		//VáltozóNeve.ParancsNeve
		return true; //"Akkor igaz értéket adjon"
	} else { //"Egyéb esetben..."
		return false; //"Hamis értéket adjon"
	}
}
//Ellenárzés egy példával:
console.log(karsz("AB","CD")) //ahol "AB" lesz str1 tartalma
//Alternatív rövid megoldás:
function karsz2(str1,str2) {
	return str1.length === str2.length;
}	//Ez egyből visszaadja a művelet eredményét.
//----------------------------------------------
/*
Listák/Tömbök:
	- egy változó tárol egy egész értékláncot
	- akárhány eleműek lehetnek
	- a listán belül az indexek alapján navigálunk
	- az indexek 0-val kezdődnek (1. elem)
	- Pl.: var listaA = [2,3,4];
		   var listaElem = listaA[0] --> a 2 lesz a tartalom
	- Az indexeket bármely többelemű értéknél lehet használni (pl. szó)
*/
//A függvény írassa ki egy adott lista 1. elemét:
function elsoelem(lista) {
	var egyes = lista[0]; //Az 1. elem elrakása egy külön változóba
	return egyes; //Ezen elem visszakérése
}

console.log(elsoelem([1,2,3]))
//----------------------------------------------
/*Matematikai műveletek:
	- Összeadás: + 
	- Kivonás: - 
	- Szorzás: *
	- Sima osztás: /
	- Osztás (csak egész rész nézése): //
	- Osztás (csak a maradék nézése): % (pl.: 9%4 = 1)
	- Hatványozás: ** (pl.: 2*2*2 = 2**3)
*/
/*
Feladat 1: függvény, ami bevesz 2 számot. Az elsőt elosztja a 
		   másodikkal és kiírja az osztás maradékát.
*/
function oszt(szam1,szam2) {
	var mo = szam1 % szam2; //Maradékos osztás eredmény tárolása
	return mo;
}

console.log(oszt(9,2)); //Ez 1 lesz 
//----------------------------------------------
/*
Feladat2: A függvény segítsen kiszámolni egy n oldalszámú
		alakzat csúcsfokainak összegét.
	Képlet: (n-2)*180	(ahol n az oldalak száma)
	1 vagy 2 oldalú alakzat nincs, erre írjon ki egy szöveget.
*/
function fokosszeg(oldalszam) {
	//Alapesetben, ha van legalább 3 él:
	if (oldalszam > 2) {
		var mo = (oldalszam-2)*180;
		return mo;
	//Nincs 3-nál kevesebb élű alakzat:
	else {
		return "Nincs ilyen alakzat";
	}
}

console.log(fokosszeg(4));
//----------------------------------------------
/*
Feladat3: 
	- Pl.: szamitas(10,3) --> 80	(mert 80 = 10*2^3)
	- 2 számot kér be
	- MO: első szám szorozva 2 a másik számadikonnal
*/
function szamitas(a,b) {
	return a * (2**b);
}
//VAGY 
function szamitas2(a,b) {
	return a * Math.pow(2,b);
}
//Hatványozó parancs: Math.pow(AlapSzám,Hatványkitevő)

console.log(szamitas(10,3));
console.log(szamitas2(10,3));
//----------------------------------------------
