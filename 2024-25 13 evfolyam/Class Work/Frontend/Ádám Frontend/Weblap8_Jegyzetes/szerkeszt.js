//A megnyitott jegyzet szerkesztését oldjuk meg itt:
'use strict'

const cimSzegmens = document.querySelector('#jegyzet-cim');
const idoSzegmens = document.querySelector('#ido-belyeg');
const bodySzegmens = document.querySelector('#jegyzet-body');
const jegyzetId = location.hash.substr(1);
let jegyzetlista = mentettJegyzetListazas();
let jegyzet = jegyzetlista.find( (jegyzet) => jegyzet.id === jegyzetId);
//Ha nincs ilyen jegyzet, akkor térjen vissza a főoldalra:
if (!jegyzet){
    location.assign('./index.html');
}
//Már létező tartalom megnyitása szerkesztésre:
idoSzegmens.textContent = utoljaraSzerkKiiras(jegyzet.szerkD);
cimSzegmens.value = jegyzet.jcim;
bodySzegmens.value = jegyzet.body;
//Cím szerkesztése:
cimSzegmens.addEventListener('input', () => {
    jegyzet.jcim = cimSzegmens.value;
    jegyzet.szerkD = moment().valueOf();
    idoSzegmens.textContent = utoljaraSzerkKiiras(jegyzet.szerkD);
    jegyzetMentes(jegyzetlista);
})
//Tartalom szerkesztése:
bodySzegmens.addEventListener('input', () => {
    jegyzet.body = bodySzegmens.value;
    jegyzet.szerkD = moment().valueOf();
    idoSzegmens.textContent = utoljaraSzerkKiiras(jegyzet.szerkD);
    jegyzetMentes(jegyzetlista);
})
//Jegyzet törlése és visszairányítás a főoldalra:
document.querySelector('#jegyzet-torlese').addEventListener('click', () =>{
    jegyzetTorol(jegyzet.id);
    jegyzetMentes(jegyzetlista);
    location.assign('./index.html');
})

window.addEventListener('storage', (e) =>{
    if (e.key === 'jegyzetlista'){
        jegyzetlista = JSON.parse(e.newValue);
        jegyzet = jegyzetlista.find( (jegyzet) => jegyzet.id === jegyzetId);
        
        if (!jegyzet){
            location.assign('./index.html');
        }
        idoSzegmens.textContent = `Utoljára szerk. ${moment(jegyzet.szerkD).fromNow()}`;
        cimSzegmens.value = jegyzet.jcim;
        bodySzegmens.value = jegyzet.body;
    }
})

