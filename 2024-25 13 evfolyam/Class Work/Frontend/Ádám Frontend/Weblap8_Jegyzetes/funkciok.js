'use strict' //hogy ne ütközzünk hibákba az esetleges rossz változókkal
/*Megnyitáskor először ellenőrizzük, hogy vannak-e jegyzetek 
	egy korábbi futtatásról: */
const mentettJegyzetListazas = () => {
    const jegyzetlistaJSON = localStorage.getItem('jegyzetlista');

    try{ //"Próbálja meg az alábbi műveletet":
		/*Olvassa be a jegyzetek tartalmát. Ha nem talál
		semmi használhatót, akkor üres listával kezdjen: */
        return jegyzetlistaJSON ? JSON.parse(jegyzetlistaJSON) : [];
		//Rövidített if-else: (LogikaiFeltétel) ? TeljesülésEset : ElseEset;
    } catch (e){
		/*Ha a 'try' részre hibát dobna, akkor ahelyett
					az itt megadott dolog fusson le.*/
        return [];
    }   
}
//Funkció a jegyzetek elmentésére (local storage-ba):
const jegyzetMentes = (jegyzetlista) => {
    localStorage.setItem('jegyzetlista', JSON.stringify(jegyzetlista));
}
//Egy adott jegyzet törlése a listából:
const jegyzetTorol = (id) => {
    const index = jegyzetlista.findIndex((jegyzet) => jegyzet.id === id)

    if (index > -1) {
        jegyzetlista.splice(index,1);
		//"A jegyzetlista-ból az index-edik helyen vágjon le 1 elemet".
		//ListaNév.splice(HolVágjonLe,HányElemet)
    }
}
//Megjelenő jegyzet felépítése:
const jegyzetKrealDOM = (jegyzet) => {
    const jegyzetEl = document.createElement('a'); //hiperlivatkozás
    const szovegEl = document.createElement('p');
    const statuszEl = document.createElement('p')
    //Van-e tárolt cím?
    if (jegyzet.jcim.length > 0){
        szovegEl.textContent = jegyzet.jcim;
    } else { //Alapraméretezett címadás, ha nincs:
        szovegEl.textContent = 'Nevtelen jegyzet';
    }
    szovegEl.classList.add('list-item__jcim')
    jegyzetEl.appendChild(szovegEl);

    jegyzetEl.setAttribute('href', `./szerkeszt.html#${jegyzet.id}`)
    jegyzetEl.classList.add('list-item')

    statuszEl.textContent = utoljaraSzerkKiiras(jegyzet.szerkD)
    statuszEl.classList.add('lista-elem__felirat')
    jegyzetEl.appendChild(statuszEl)

    return jegyzetEl;
}
//Rendezés elvégzése a megadott mód alapján:
const jegyzetRendez = (jegyzetlista, miAltal) => {
    if (miAltal === 'szerkAlapjan'){
        return jegyzetlista.sort((a,b) => { //Rendezési elv
			//a és b 2 adott elemet jelölnek (amit épp talál)
            if (a.szerkD > b.szerkD){
                return -1;
            } else if (a.szerkD < b.szerkD){
                return 1;
            } else {
                return 0;
            }
        })
    } else if (miAltal === 'letrAlapjan') {
        return jegyzetlista.sort( (a,b) => {
            if (a.letrehozD > b.letrehozD){
                return -1;
            } else if (a.letrehozD < b.letrehozD){
                return 1;
            } else {
                return 0;
            }
        })
    } else if (miAltal === 'abcAlapjan'){
        return jegyzetlista.sort( (a,b) => {
            if (a.jcim.toLowerCase() < b.jcim.toLowerCase()){
                return -1;
            } else if (a.jcim.toLowerCase() > b.jcim.toLowerCase()){
                return 1;
            } else {
                return 0;
            }
        })
    } else {
        return jegyzetlista;
    }
}
//Szöveges tartalom szerinti szűrés:
const jegyzetMegjelenites = (jegyzetlista, filters) => { 
    const jegyzetlistaEl = document.querySelector('#jegyzetlista') 
    jegyzetlista = jegyzetRendez(jegyzetlista, filters.miAltal);
    const rendezettJgeyzetek = jegyzetlista.filter( (jegyzet) => {
        const jcim = jegyzet.jcim.toLowerCase();
        const filter = filters.kerSzoveg.toLowerCase();
        return jcim.includes(filter);
    })

    jegyzetlistaEl.innerHTML = '';

    if (rendezettJgeyzetek.length > 0){
        rendezettJgeyzetek.forEach( (jegyzet) => {
            const p = jegyzetKrealDOM(jegyzet);
            jegyzetlistaEl.appendChild(p);
        })
    } else {
        const uresUzenet = document.createElement('p')
        uresUzenet.textContent = 'Nincs semmi'
        uresUzenet.classList.add('ures-uzenet')
        jegyzetlistaEl.appendChild(uresUzenet)
    }
};

const utoljaraSzerkKiiras = (timestamp) => `Utoljára szerk. ${moment(timestamp).fromNow()}`;
	//Kiírja, hogy hány perce szerkeszettük utoljára.
	//Angol nyelven jelenik meg.