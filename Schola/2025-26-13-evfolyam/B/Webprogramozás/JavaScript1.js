Weblapok:
	- HTML: menü elemek elhelyezése
	- CSS: formázás
	- JS: mögöttes funkcionalitás
----------------------------------
console.log("Hello világ");
//egysoros komment
/*
többsoros
komment
*/
Változótípusok:
	- var: bárhonnan elérhető típus
	- let: lokálisan elérhető változó 
	- const: utolag nem változtatható értékű elem 

var Nevem = "Adam"; //automatikusan tudja, hogy szöveg (string)
let Nevem2 = "Adam";
const pi = 3.14; //autoatikusan tudja, hogy ez tört szám érték
Nevem = "Béla";
var a; //mögöttes érték nélkül is létrehozható
var b = 2;
a = 7;
b = a; //b mögöttesen tárolt értéke 2-ről 7-re változik
console.log(b); //Nem kell "" jel, mert ez változónév
var szumma = 10 + 10; //már az értékadásnál végezhetünk műveleteket
var kivon = 10 - 6; //kivon tartalma így 4 lesz
Inkrementálás (önmaga növelése/változtatása):
var inkrementalt = 4;
inkrementalt = inkrementalt + 1; //az értékétől függetlenül nőjön 1-el 
var tizedes = 1.5; //tizedes törtet ponttal jelöljük
//Szövegek összefűzése:
var kombo = "Első fele " + "Második fele ";
console.log(kombo);
var x = "Külön szöveg";
var kombo2 = kombo + x; //szöveges változók tartalmának kiírása egyben
console.log(kombo2);
var kombo3 = kombo + "Extra szöveg";
console.log(kombo3);
/*------------------------------------*/
FELADAT 1: "A régi iskolámban az XY volt a kedvenc tárgyam."
var tantargy = "matek";
var mondat = "A régi iskolámban a " + tantargy + " volt a kedvencem.";
--VAGY--
var eleje = "A régi iskolámban a ";
var tantargy = "matek";
var vege = " volt a kedvencem.";
var megoldas = eleje + tantargy + vege;
console.log(mondat);
console.log(megoldas);
/*------------------------------------*/
FELADAT 2: "A nevem XY és ma X órakor keltem fel."
var nev = "Adam";
var ora = 7;
var mondat = "A nevem " + nev + " és ma " + ora + " órakor keltem.";
console.log(mondat);
/*------------------------------------*/
FELADAT 3:
	- 3 tetszőleges szám 
	- az első 2 összeadása
	- ezen összeg megszorzása a 3.-kal (*)
var c = 3;
var d = 4;
var e = 5;
var összeg = c + d;
var végeredmény = összeg * e;
console.log(végeredmény);
//var megoldas = (c + d) * e; //egyben a 2 művelet 
/*------------------------------------*/
FELADAT 4:
	- 3 tetszőleges szám 
	- az 1.-ből vonjuk ki a 2.-at 
	- egy 4. változó, ami 1-el nagyobb a kivonás eredményénél
	- az eredményhez adjuk hozzá a 3. számot 

var f = 10;
var g = 7;
var h = 4;
var kivonas = f - g;
var nagyobb = kivonas + 1; //vagy: kivonas = kivonas + 1;
var eredmeny = nagyobb + h;
console.log(eredmeny);
