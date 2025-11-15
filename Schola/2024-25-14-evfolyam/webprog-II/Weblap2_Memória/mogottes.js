document.addEventListener('DOMContentLoaded', () => { //Ha betöltődtek az oldal dolgai
//A kártyák adatait (név, képforrás) egy szótártömbben tároljuk:
  const kartyaLista = [
    {
      kartyanev: 'sultkrumpli',
      kep: 'kepek/sultkrumpli.png'
    },
    {
      kartyanev: 'sajtburger',
      kep: 'kepek/sajtburger.png'
    },
    {
      kartyanev: 'jegkrem',
      kep: 'kepek/jegkrem.png'
    },
    {
      kartyanev: 'pizza',
      kep: 'kepek/pizza.png'
    },
    {
      kartyanev: 'turmix',
      kep: 'kepek/turmix.png'
    },
    {
      kartyanev: 'hotdog',
      kep: 'kepek/hotdog.png'
    },
    {
      kartyanev: 'sultkrumpli',
      kep: 'kepek/sultkrumpli.png'
    },
    {
      kartyanev: 'sajtburger',
      kep: 'kepek/sajtburger.png'
    },
    {
      kartyanev: 'jegkrem',
      kep: 'kepek/jegkrem.png'
    },
    {
      kartyanev: 'pizza',
      kep: 'kepek/pizza.png'
    },
    {
      kartyanev: 'turmix',
      kep: 'kepek/turmix.png'
    },
    {
      kartyanev: 'hotdog',
      kep: 'kepek/hotdog.png'
    }
  ]
//Azért van minden betabulátorozva, mert az egész a fenti eseményfigyelőhöz tartozik:
	//Minden megnyitáskor randomra helyezze el a kártyákat:
	kartyaLista.sort(() => 0.5 - Math.random())
	//Néhány segédváltozó:
	const racs = document.querySelector('.racs');
	const eredmenyMutat = document.querySelector('#result'); //pontszám mező
	let valasztottKartyak = [] //Az épp kiválasztás alatt lévő kártyákhoz
	let valasztottKartyakId = [] //és azok ID-ihez
	let megnyertKartyak = [] //A már megtalált pároknak
	//Játékmező megalkotása (minden kártyaelem kap egy mezőt):
	function megrajzolas() {
		for (let i = 0; i < kartyaLista.length; i++) {
			const kartya = document.createElement('img');//Egyenháttér
			kartya.setAttribute('src','kepek/sima.png');//Képforrás megadása
			//(a sima.png az a kezdeti mintázat képe)
			kartya.setAttribute('data-id', i);//ID: ahol épp tart a ciklus
			kartya.addEventListener('click', felfordit); //megnézéző funkció
			racs.appendChild(kartya); //kártyaelem hozzárendelése a rács-elemhez
		}
	}
	//Ellenőrizzük, hogy épp találtunk-e egy párt:
	function egyezestNez() {
		const kartyak = document.querySelectorAll('img');//Minden kép típusó elem kiválasztása
		//Melyik 2 kártyát kezeljük épp:
		const egyikID = valasztottKartyakId[0]
		const masikID = valasztottKartyakId[1]
		//Ha 2x ugyanazt a kártyát jelölik ki:
		if (egyikID == masikID) {
			kartyak[egyikID].setAttribute('src', 'kepek/sima.png');
			kartyak[masikID].setAttribute('src', 'kepek/sima.png');
			//Ahol az 'src' tulajdonság a képforrász jelöli.
			alert('Próbálj egy másik képet!'); //Felugró üzenet
		}
		//Ha talált egy párt:
		else if (valasztottKartyak[0] === valasztottKartyak[1]) {
			alert('Találtál egy párt!');
			kartyak[egyikID].setAttribute('src','kepek/feher.png');
			//A feher.png színe megyezik az oldal háttér színével. Ezzel "eltűnik".
			kartyak[masikID].setAttribute('src','kepek/feher.png');
			//Eseményfigyelő eltávolítása:
			kartyak[egyikID].removeEventListener('click', felfordit);
			kartyak[masikID].removeEventListener('click', felfordit);
			megnyertKartyak.push(valasztottKartyak);
		} else {//Ha a 2 megjelölt kártya eltér:
			kartyak[egyikID].setAttribute('src','kepek/sima.png');
			kartyak[masikID].setAttribute('src','kepek/sima.png');
			alert('Próbáld újra');
		}
		//Minden próbálkozásnál frissen indulnak a választottak listái:
		valasztottKartyak = []
		valasztottKartyakId = []
		//Kiírjuk, hogy eddig hányat vittünk el:
		eredmenyMutat.textContent = megnyertKartyak.length;
		//Ha nyertünk:
		if (megnyertKartyak.length === kartyaLista.length/2) {
			//A pontszám mező helyére írjuk ki:
			eredmenyMutat.textContent = 'Mindet megtaláltad';
		}
	}
	//Kártyák felfordítása:
	function felfordit() {
		let kartyaId = this.getAttribute('data-id');
		//a this az az épp aktuálisan kezelt elemre hivatkozik
		//getAttribute(): valamely tulajdonság beolvasása
		valasztottKartyak.push(kartyaLista[kartyaId].kartyanev)
		valasztottKartyakId.push(kartyaId)
		this.setAttribute('src', kartyaLista[kartyaId].kep);
		//Ha épp 2 kártya van kiválasztva, akkor fél MP múlva ellenrizze az egyezést:
		if (valasztottKartyak.length === 2) {
			setTimeout(egyezestNez, 500)
			//Késleltetés: setTimeout(MiTörténjen, HányEzredMpMúlva)
		}
	}
	megrajzolas() //Elvégezzük a játékmező megrajzolását
})
