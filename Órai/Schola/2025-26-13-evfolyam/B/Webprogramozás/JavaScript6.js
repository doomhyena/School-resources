//Példa1: Az adott szöveg visszafele is ugyanaz-e?
//Pl.: console.log(odavissza('Géza kék az ég!')) --> true 

function odavissza(s) {
	let szoveg = s.toLowerCase().replace(/[^a-z0-9]/g, '');
							//változóNév.recplace(Mit,Mire)
	let kezdes = 0;
	let vegzodes = szoveg.length-1;
	//While ciklus: addig megy, amig a benne megadott feltétel még teljesül
	while (kezdes < vegzodes) {
		if (szoveg[kezdes] !== szoveg[vegzodes]) return false;
		kezdes++;
		vegzodes--; //csökken 1-el 
	}
	return true; //Ide csak akkor jut el, ha a while egyszer sem teljesült
};
//--------------------------------------------------
//Példa2: Adott szöveg megfordítása a reverse() parancs nélkül.
//Pl.: console.log(szomegforditas('szia') --> 'aizs'

function szomegforditas(szo) {
	let megoldas = '';
	for (let char of szo) { //A szó minden egyes karakterére
		megoldas = char + megoldas; //Az elejére kerüljön az új dolog
	}
	return megoldas;
}
console.log(szomegforditas('szia');
//--------------------------------------------------
//Példa3: A szöveg karaktereit '(' és ')' jelekre akarom kicserélni.
//	'(' ha az adott karakter csak egyszer fodul elő, ')' ha többször.
//Pl: 	console.log(zarojeles('asd') --> '((('
//		console.log(zarojeles('(( @') --> '))(('

function zarojeles(szo) {
	const kisbetusSzo = szo.toLowerCase();
	let eredmeny = '';
	for (const char of kisbetusSzo) {
		kisbetusSzo.indexOf(char) !== kisbetusSzo.lastIndexOf(char)
			? (eredmeny += ')')
			: (eredmeny += '(')
		//Alternatív if-else: (LogikaiFeltétel) ? HaTeljesül : HaNemTeljesül
	}
	return eredmeny;
};
console.log(zarojeles('alma'); //')(()'
//--------------------------------------------------
Feladat1: Igaz-e, hogy a megadott szövegben nincsenek ismétlődő karakterek?
	- true/false válasz
	- kis/nagy betű eltérés nem számít
	- Pl.: 'Felett' --> false 		'Iskola' --> true
	- Használnám: karaktergyűjtemények, toLowerCase()

function mindegyedi(str) {
  const kisbetusSzo = str.toLowerCase();
  return str.length === new Set(kisbetusSzo).size;
  //Set(változó): a változóban lévő karakterek gyűjtemény (pl. alma set-je az "alm")
};
//--------------------------------------------------
Feladat2: A függvény rakja a számtömb 0-it a végére, a többi sorrend ne változzon.
	- Pl.: [0,1,0,3,12] --> [1,3,12,0,0]
	- Használnám: length, for, if, indexek, !==

function nullarendez(szamok) {
  const hossz = szamok.length;
  let index = 0;
  for (let i = 0; i < hossz; i++) {
    if (szamok[i] !== 0) {
      szamok[index] = szamok[i];
      if (index !== i) {
        szamok[i] = 0;
      }
      index++;
    }
  }
  return szamok;
};
