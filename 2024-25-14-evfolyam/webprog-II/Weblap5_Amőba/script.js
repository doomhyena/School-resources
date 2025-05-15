"use strict";//Hívd be a strict módot.

window.addEventListener('load', app);//Rakj egy eseményfigyelőt az ablakra, ami 'load' esemény hatására behívja az app függvényt.

let jatekTere = ['', '', '', '', '', '', '', '', '']; 
let fordulo = 0;
let nyertes = false;

const player = (name) => {
  name = name;
  return {name};
 };

 let jatekos1 = player("");
 let jatekos2 = player("");

function app() {
  let beviteliMezo = document.querySelector('.input-field').focus();

  const jatekosHozzaadoForm = document.getElementById('player-form');
  jatekosHozzaadoForm.addEventListener('submit', jatekosHozzaadas);

  let ujJatekGomb = document.querySelector('.replay-btn');
  ujJatekGomb.addEventListener('click', visszaallitas);//Rakj egy kattintásfigyelőt a ujJatekGomb elemre, ami behívja a visszaallitas függvényt.
}

function jatekosHozzaadas(event) {
  event.preventDefault();

  if (this.player1.value === '' || this.player2.value === '') {
    alert('Mindkét mezőt ki kell tölteni!');//Egy üzenet figyelmeztesse a játékost, hogy mindenképp meg kell adnia egy nevet.
    return;
  }

  const jatekosTartoja = document.querySelector('.enter-players');
  const tablaAlap = document.querySelector('.board__main');
  jatekosTartoja.classList.add('hide-container');
  tablaAlap.classList.remove('hide-container');

  jatekos1.name = this.player1.value;
  jatekos2.name = this.player2.value;
  jatekterRender();
}

function aktualisJatekos() {
  return fordulo % 2 === 0 ? 'X' : 'O';
}

window.addEventListener("resize", atmeretezeshez);
function atmeretezeshez() {
  let osszesCella = document.querySelectorAll('.board__cella');
  let cellaMagassag = osszesCella[0].offsetWidth;
  
  osszesCella.forEach( cella => {
    cella.style.height = `${cellaMagassag}px`; //Ez az érték a 'cella' elem stíluselemei közül a magasságra vonatkozzon.
  });
}

function jatekterRender() {
  let alapbaAllitas = document.querySelector('.reset');
  alapbaAllitas.classList.remove('reset--hidden');//A 'alapbaAllitas' elem osztálylistájából vedd le a 'reset--hidden' formázást.

  atmeretezeshez();
  cellaaFigyelo();
  fejNevValtas();
}

function ujLepes(event) {  
  let jelenlegiCella = parseInt(event.currentTarget.firstElementChild.dataset.id);
  let cellaTokenek = document.querySelector(`[data-id='${jelenlegiCella}']`);
  
  if (cellaTokenek.innerHTML !== '') {
    console.log('Ez a cella már foglalt');
    return;
  } else {
    if (aktualisJatekos() === 'X') {
      cellaTokenek.textContent = aktualisJatekos();
      jatekTere[jelenlegiCella] = 'X';
    } else {
      cellaTokenek.textContent = aktualisJatekos();
      jatekTere[jelenlegiCella] = 'O';
    }
  }
    
  NyertesE();
    
  fordulo ++;

  fejNevValtas();
}

function dontetlenEll() {
//Ha a lépések száma 7 fölé megy, akkor döntetlen a játék eredménye:
  if (fordulo > 7) {
    alert('Döntetlen');
  }
}

function NyertesE() {
  const nyeroKombok = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
  ];

  nyeroKombok.forEach( nyertesKombok => {
    let cella1 = nyertesKombok[0];
    let cella2 = nyertesKombok[1];
    let cella3 = nyertesKombok[2];
    if (
      jatekTere[cella1] === aktualisJatekos() &&
      jatekTere[cella2] === aktualisJatekos() &&
      jatekTere[cella3] === aktualisJatekos()
    ) {

      
      const cellas = document.querySelectorAll('.board__cella');
      let letterId1 = document.querySelector(`[data-id='${cella1}']`);
      let letterId2 = document.querySelector(`[data-id='${cella2}']`);
      let letterId3 = document.querySelector(`[data-id='${cella3}']`);
      
      cellas.forEach( cella => {
        let cellaId = cella.firstElementChild.dataset.id;	

        if (cellaId == cella1 || cellaId == cella2 || cellaId == cella3 ) {
          cella.classList.add('board__cella--nyertes');
        }
      });

      let aktualisJatekosText = document.querySelector('.board___player-fordulo');
      if (aktualisJatekos() === 'X') {
        aktualisJatekosText.innerHTML = `
          <div class="congratulations">Gratulálok ${jatekos1.name}</div>
          <div class="u-r-nyertes">Nyertél!</div>
        `;
        nyertes = true;
        cellaaFigyeloTorlese();
        return true;
      } else {
        aktualisJatekosText.innerHTML = `
          <div class="congratulations">Gratulálok ${jatekos2.name}</div>
          <div class="u-r-nyertes">Nyertél!</div>
        `;
        nyertes = true;
        cellaaFigyeloTorlese();
        return true;
      }
    }
  });

  if (!nyertes) {
    dontetlenEll();
  }
  
  return false;
}

function fejNevValtas() {
  if (!nyertes) {
    let aktualisJatekosText = document.querySelector('.board___player-fordulo');
    if (aktualisJatekos() === 'X') {
      aktualisJatekosText.innerHTML = `
        <span class="name--style">${jatekos1.name}</span>, te jössz!
        <div class="u-r-nyertes"></div>
      `
    }  else {
      aktualisJatekosText.innerHTML = `
        <span class="name--style">${jatekos2.name}</span>, te jössz.
        <div class="u-r-nyertes"></div>
      `
    }
  }
}

function visszaallitas() {
  jatekTere = ['', '', '', '', '', '', '', '', '']; 
  
  let cellaTokenek = document.querySelectorAll('.letter');
  cellaTokenek.forEach( square => {
    square.textContent = '';
    square.parentElement.classList.remove('board__cella--nyertes');
  });

  fordulo = 0;
  nyertes = false;

  let aktualisJatekosText = document.querySelector('.board___player-fordulo');
  aktualisJatekosText.innerHTML = `
    <span class="name--style">${jatekos1.name}</span>, te jössz!
    <div class="u-r-nyertes"></div>
  `

  cellaaFigyelo();
}

function cellaaFigyelo() {
  const cellas = document.querySelectorAll('.board__cella');
  cellas.forEach( cella => {
    cella.addEventListener('click', ujLepes);
  });
}

function cellaaFigyeloTorlese() {
  let osszesCella = document.querySelectorAll('.board__cella');
  osszesCella.forEach( cella => {
    cella.removeEventListener('click', ujLepes);
  });
}

