document.addEventListener('DOMContentLoaded', function() {
	//DOMContentLoaded --> oldal tartalmának betöltésekor aktiválódik
    function debounce(fuggveny, kesleltetes) {
        let ido;
        return function() {
            clearTimeout(ido);//Időzítés törlése: clearTimeout(MiÁlljonMeg);
            ido = setTimeout(() => fuggveny.apply(this, arguments), kesleltetes); //this --> az aktuálisan kezelt objektum
			//Időzítés: setTimeout(MiTörténjen,Ezredmásodpercek);
        };
    }
    
    function throttle(fuggveny, limit) {
        let utolsoIdo = 0;
        return function() {
            const jelenIdo = Date.now(); //Aktuális időt tartalmazó dátum objektum 
            if (jelenIdo - utolsoIdo >= limit) {
                fuggveny.apply(this, arguments);
                utolsoIdo = jelenIdo;
            }
        };
    }
   /*Változó típusok:
	const: értéke állandó
	var: tágabban értelmezett változó típus
	let: szűkebben (általában a függvényen belül értelmezett) változó típus
   */
    const gombHozzaadElem = document.getElementById('gombHozzaadElem');
    const dinamikusLista = document.getElementById('dinamikusLista');
	//Tartalom keresése ID alapján: document.getElementById('id');

    const ujListaElemEsemeny = new CustomEvent('ujListaElemHozzaadva', {
        detail: { uzenet: 'Új listaelem hozzáadva!' }
    });

    if (gombHozzaadElem) {
        gombHozzaadElem.addEventListener('click', function() {
            const ujElem = document.createElement('li'); //li = lista
		//Új elem felvitele az oldalra: document.createElement('elemTípus');
            ujElem.textContent = 'Listaelem ' + (dinamikusLista.children.length + 1);
//Egy oldalelem szöveges tartalma lehet: textContent, innerText, innerHTML.
			ujElem.classList.add('listaElem');
//Oldalelem felruházása egy adott formázással: elemNeve.classList.add('osztályNeve');
//Ennek levétele: elemNeve.classList.remove('osztályNeve');
            dinamikusLista.appendChild(ujElem);
//Egy elem alárendelése a másiknak: FőElemNeve.appendChild(alElemNeve);
//(ezt az oldalon egybetartozó elemeknél szoktuk (pl. doboz + benne a szöveg))
            dinamikusLista.dispatchEvent(ujListaElemEsemeny);
        });
    }

    dinamikusLista.addEventListener('ujListaElemHozzaadva', function(e) {
	//(e) = a kapcsolódó esemény (event) paramétere
        console.log(e.detail.uzenet); //konzolos ellenőrzéshez
    });

    dinamikusLista.addEventListener('click', function(e) { //kattintás figyelő
        if (e.target && e.target.nodeName === 'LI') {
			//e.target --> az az objetum/elem, amit érint az aktuális esemény 
			//&& --> ÉS feltétel
			//|| --> VAGY feltétel 
			// = --> deklaráció, == --> tartalomegyezés vizsgálata, === --> tartalom- és típusegyezés vizsgálata
            e.target.classList.toggle('kiemel');
			//elemNeve.classList.toggle('osztályNeve') --> 
			//--> az osztályt az ellentétére állítja (ha eddig aktív volt, akkor leveszi, ha nem volt aktív, akkor felruházza vele)
        }
    });
    
    const inputSzoveg = document.getElementById('inputSzoveg');
    inputSzoveg.addEventListener('keydown', function(e) {
		//'keydown' --> billentyű lenyomás eseménye
        console.log('Lenyomva: ' + e.key); //e.key --> amelyik billentyű volt
    });
    inputSzoveg.addEventListener('keyup', function(e) {
		//'keyup' --> billentyű felengedés eseménye
        console.log('Felengedve: ' + e.key);
    });

    const interaktivDivPlus = document.getElementById('interaktivDivPlus');
    interaktivDivPlus.addEventListener('mouseenter', function() {
		//'mouseenter' --> az egérkurzor belép a nézett mezőbe
        interaktivDivPlus.style.backgroundColor = '#ffeeba';
		//elemNeve.stíluselemek.tulajdonsg = 'újÉrték';
    });
    interaktivDivPlus.addEventListener('mouseleave', function() {
		//'mouseleave' --> az egérkurzor elhagyja a mezőt
        interaktivDivPlus.style.backgroundColor = '#ffffff';
    });
    interaktivDivPlus.addEventListener('click', function() {
        interaktivDivPlus.textContent = 'Kattintottál az interaktív divre!';
    });
    interaktivDivPlus.addEventListener('dblclick', function() {
		//'dblclick' --> dupla kattintás eseménye
        interaktivDivPlus.textContent = 'Dupla kattintás történt!';
    });
    interaktivDivPlus.addEventListener('contextmenu', function(e) {
		//'contextmenu' --> jobb egérgomb kattintása
        e.preventDefault(); //letilt bizonyos alapeseményeket, hogy azok ne kavarjanak be
        interaktivDivPlus.textContent = 'Jobb egérgombos esemény tiltva!';
    });

    const dragElem = document.getElementById('dragElem');
    let dragFolyamatban = false;
    let dragOffsetX = 0, dragOffsetY = 0;

    dragElem.addEventListener('mousedown', function(e) {
		//'mousedown' --> egérgomb lenyomva tartása
        dragFolyamatban = true;
        dragOffsetX = e.offsetX;
        dragOffsetY = e.offsetY;
        dragElem.style.cursor = 'grabbing'; //a nyilat kicseréli a kis fogó kézre
		//a stíluselemek (style) tartalmazzák a különböző megjelenési formázásokat
    });
    document.addEventListener('mousemove', function(e) {
		//'mousemove' --> egér mozgatása
        if (dragFolyamatban) {
            dragElem.style.position = 'absolute';
            dragElem.style.left = (e.pageX - dragOffsetX) + 'px';
            dragElem.style.top = (e.pageY - dragOffsetY) + 'px';
        }
    });
    document.addEventListener('mouseup', function() {
		//'mouseup' --> egér felengedése
        if (dragFolyamatban) {
            dragFolyamatban = false;
            dragElem.style.cursor = 'grab';
        }
    });

    window.addEventListener('resize', debounce(function() {
		//'resize' --> az ablak átméretezése
	/*Mire is rakjuk rá az eseményfigyelőt:
		window --> magát az ablakot nézi 
		document --> az oldal tartalmát nézi
	*/
        console.log('Ablak átméretezve: ' + window.innerWidth + 'x' + window.innerHeight);
    }, 300));

    window.addEventListener('scroll', throttle(function() {
		//'scroll' --> görgetés
        console.log('Görgetési pozíció: ' + window.scrollY);
    }, 200)); //ez a kiírás pl. 2 tizedmásodperces késleltetéssel jelenik meg


    const szuloDiv = document.getElementById('szuloDiv');

    szuloDiv.addEventListener('click', function(e) {
        console.log('Bubbling: Szülő div esemény - ' + e.target.textContent);
    });

    szuloDiv.addEventListener('click', function(e) {
        console.log('Capturing: Szülő div esemény (elsőként) - ' + e.target.textContent);
    }, true);

    const mozgoDoboz = document.getElementById('mozgoDoboz');
    mozgoDoboz.addEventListener('mousemove', throttle(function(e) {
        mozgoDoboz.textContent = 'Egér pozíció: ' + e.offsetX + ', ' + e.offsetY;
    }, 100));

    window.addEventListener('focus', function() {
        console.log('Az ablak fókuszban van.');
    });
    window.addEventListener('blur', function() {
        console.log('Az ablak elvesztette a fókuszt.');
    });
	//Függvény célja: Ha Ctrl+S-et nyomunk, az ne csinálhasson semmit:
    document.addEventListener('keydown', function(e) {
        if (e.ctrlKey && e.key === 's') {
            e.preventDefault();
            console.log('Ctrl+S billentyűkombináció megakadályozva.');
        }
    });
});
