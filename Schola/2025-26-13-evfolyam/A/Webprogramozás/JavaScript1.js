//egysoros komment
/*
többsoros
kommentek
*/
var Nevem = "Adam"; //magától tudja, hogy ez egy string 
Nevem = 7; //magától átállítódik az adattípus számra
/*3 féle adattípus a JS-ben:
	- var: sima változó
	- let: csak helyileg elérhető
	- const: állandó értékű változó, utólag nem módosulhat
*/
/*Eredmények kiíratása JS-ben:
console.log(KiírandóÉrték);
	- tényleges szövegnél ""-be rajkuk
	- változónál simán a változó neve kell
	- Pl.: console.log("abc")
		   console.log(Nevem) --> Ezesetben 7 lenne az eredmény
*/
let NevemUj = "Adam"; //most nincs érdemi eltérés a let miatt
const pi = 3.14; //PI értéke állandó, így itt jó a const 
var a; //nem kell feltétlenül azonnal értéked adni nekik
var b = 2; //b nevű változó, amely értéke 2 lett
a = 7; //utólag adtam értéket a-nak 
b = a; //b értéke legyen az, ami a-nak az értéke (7)
console.log(b); --> 7-et fog kiírni
//Szumma változó mögöttesen tárolt értéke: 20 lesz
var szumma = 10 + 10
console.log(szumma);
var kivon = 10 - 5;
console.log(kivon);
//Inkrementálás: önmagához képest módosítson
var inkrementált = 4;
//Egyel meg akarom növelni az értékét:
inkrementált = inkrementált + 1 //értéke = önmaga + 1
//Mögöttesen: inkrementált = 4 + 1 (=5)
console.log(inkrementált);
//Szövegrészletek összeadása/összefűzése:
var kombo = "első fele " + "masodik fele";
var extraszoveg = "külön szöveg";
//3 string értéket rak egybe, 2 konkrét + 1 változó tartalom:
var kombo2 = "első fele " + "masodik fele " + extraszoveg;
//Egy darab egybefüggő szövegként kell megjelennie:
console.log(kombo);
console.log(kombo2);
/*-------------------------------------*/
FELADAT 1: "A nevem XY és X órakor keltem fel."
//1-1 változó a név és óra tartalmának:
nev = "Adam";
ora = 7;
//Egy sablon mondatban összefűzöm a részeket:
var mondat = "A nevem " + nev + " és " + ora + " órakor keltem fel."
console.log(mondat);
/*-------------------------------------*/
FELADAT 2: "A régi iskolában az XY volt a kedvenc tantárgyam."
var tantargy = "matek";
var mondat = "A régi iskolában a " + tantargy + " volt a kedvencem.";
console.log(mondat);
/*-------------------------------------*/
var a = 5;
var b = 3;
var c = a * b; //15 lesz
console.log(c);

FELADAT 3: Legyen 3 tetszőleges szám. Az első 2-t összeadjuk.
	Az eredményt megszorozzuk a 3. számmal.
var e = 1;
var f = 2;
var g = 3;
var h = e + f;
var i = h * g;
console.log(i);
/*-------------------------------------*/
FELADAT 4: 3 újabb tetszőleges szám.
	- A 2.-at kivonom a 1.-ből
	- A 3.-at megnövelem 1-el 
	- Eredmény az 1. és 3. szám összege (új értékekkel)
var j = 9;
var k = 5;
var l = 6;
var m = j - k;
l = l + 1; //l növelése 1-el
var n = m + l;
console.log(n);
