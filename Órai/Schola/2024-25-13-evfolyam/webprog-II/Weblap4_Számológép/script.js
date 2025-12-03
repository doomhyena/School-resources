"use strict";

var input = document.getElementById('input'),
  szamertek = document.querySelectorAll('.n'),
  operator = document.querySelectorAll('.o'),
  megoldas = document.getElementById('megoldas'),
  urit = document.getElementById('urit'),
  megjelenoEredmeny = false;

function szamKezelo(event) {
  var jelenlegiErtek = input.innerHTML;
  var utolsoKarakter = jelenlegiErtek[jelenlegiErtek.length - 1];

  if (megjelenoEredmeny === false) {
    input.innerHTML += event.target.innerHTML;
  } else if (megjelenoEredmeny === true && utolsoKarakter === "+" || utolsoKarakter === "-" || utolsoKarakter === "×" || utolsoKarakter === "÷") {
    megjelenoEredmeny = false;
    input.innerHTML += event.target.innerHTML;
  } else {
    megjelenoEredmeny = false;
    input.innerHTML = "";
    input.innerHTML += event.target.innerHTML;
  }

}
for (var i = 0; i < szamertek.length; i++) {
  szamertek[i].addEventListener("click",szamKezelo );
}

function muveletKezelo(event) {
  var jelenlegiErtek = input.innerHTML;
  var utolsoKarakter = jelenlegiErtek[jelenlegiErtek.length - 1];

  if (utolsoKarakter === "+" || utolsoKarakter === "-" || utolsoKarakter === "x" || utolsoKarakter === "÷") {
    var ujString = jelenlegiErtek.substring(0, jelenlegiErtek.length - 1) + event.target.innerHTML;
    input.innerHTML = ujString;
  } else if (jelenlegiErtek.length == 0) {
    console.log("előbb adj meg egy számot");
  } else {
    input.innerHTML += event.target.innerHTML;
  }

}
for (var i = 0; i < operator.length; i++) {
  operator[i].addEventListener("click",muveletKezelo );
}

function OS_kezelo(event){
  if (parseInt(event.key)<=9 || parseInt(event.key)>=0) {
  var jelenlegiErtek = input.innerHTML;
  var utolsoKarakter = jelenlegiErtek[jelenlegiErtek.length - 1];

  if (megjelenoEredmeny === false) {
    input.innerHTML += parseInt(event.key);
  } else if (megjelenoEredmeny === true && utolsoKarakter === "+" || utolsoKarakter === "-" || utolsoKarakter === "×" || utolsoKarakter === "÷") {
    megjelenoEredmeny = false;
    input.innerHTML += parseInt(event.key);
  } else {
    megjelenoEredmeny = false;
    input.innerHTML = "";
    input.innerHTML += parseInt(event.key);
  }
  }
  else if(event.key === "+" || event.key === "-" || event.key === "x" || event.key === "÷" || event.key === "/"  ||  event.key === "*" ){
  var jelenlegiErtek = input.innerHTML;
  var utolsoKarakter = jelenlegiErtek[jelenlegiErtek.length - 1];
  var s=event.key;
  if(s=="/"){
    s="÷"
  }
  if(s=="*"){
    s=document.querySelector('.multiply_sign').textContent;
  }
  if (utolsoKarakter === "+" || utolsoKarakter === "-" || utolsoKarakter === "x" || utolsoKarakter === "÷") {
    var ujString = jelenlegiErtek.substring(0, jelenlegiErtek.length - 1) + s;
    input.innerHTML = ujString;
  } else if (jelenlegiErtek.length == 0) {
    console.log(".......");
  } else {
    input.innerHTML +=  s;
  }
  }
}
window.addEventListener("keypress",OS_kezelo);

function eredmeny(){
  var inputString = input.innerHTML;

  var szamLista = inputString.split(/\+|\-|\×|\÷/g);

  var muveletiJelek = inputString.replace(/[0-9]|\./g, "").split("");

  var osztas = muveletiJelek.indexOf("÷");
  while (osztas != -1) {
    szamLista.splice(osztas, 2, szamLista[osztas] / szamLista[osztas + 1]);
    muveletiJelek.splice(osztas, 1);
    osztas = muveletiJelek.indexOf("÷");
  }

  var szoroz = muveletiJelek.indexOf("×");
  while (szoroz != -1) {
    szamLista.splice(szoroz, 2, szamLista[szoroz] * szamLista[szoroz + 1]);
    muveletiJelek.splice(szoroz, 1);
    szoroz = muveletiJelek.indexOf("×");
  }

  var kivon = muveletiJelek.indexOf("-");
  while (kivon != -1) {
    szamLista.splice(kivon, 2, szamLista[kivon] - szamLista[kivon + 1]);
    muveletiJelek.splice(kivon, 1);
    kivon = muveletiJelek.indexOf("-");
  }

  var osszead = muveletiJelek.indexOf("+");
  while (osszead != -1) {
    szamLista.splice(osszead, 2, parseFloat(szamLista[osszead]) + parseFloat(szamLista[osszead + 1]));
    muveletiJelek.splice(osszead, 1);
    osszead = muveletiJelek.indexOf("+");
  }

  input.innerHTML = szamLista[0];

  megjelenoEredmeny = true;
}
megoldas.addEventListener("click",eredmeny );

urit.addEventListener("click", function() {
  input.innerHTML = "";
})

window.onkeydown = function(event){
  let key = event.key;
  if (key === "Backspace") {
    input.innerHTML = "";
  }
  else if(key==="Enter"){
    eredmeny()
  }
}
