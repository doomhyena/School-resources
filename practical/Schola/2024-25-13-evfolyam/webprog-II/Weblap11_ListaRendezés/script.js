const huzhatoLista = document.getElementById("huzhato-lista");
const csekkol = document.getElementById("csekkol");

const leggazdagabbakListaja = [
  "Jeff Bezos",
  "Bill Gates",
  "Bernard Arnault",
  "Warren Buffett",
  "Larry Ellison",
  "Amancio Ortega",
  "Mark Zuckerberg",
  "Jim Walton",
  "Alice Walton",
  "S. Robson Walton",
];

const listaelemek = [];

let kezdoIndex;

function listaLetrehoz() {
  const ujLista = [...leggazdagabbakListaja];
  ujLista
    .map((szemely) => ({ value: szemely, sort: Math.random() }))
    .sort((a, b) => a.sort - b.sort)
    .map((szemely) => szemely.value)
    .forEach((szemely, index) => {
      const listaElem = document.createElement("li");
      listaElem.setAttribute("data-index", index);
      listaElem.innerHTML = `
        <span class="number">${index + 1}</span>
        <div class="draggable" draggable="true">
          <p class="szemely-neve">${szemely}</p>
          <i class="fas fa-grip-lines"></i>
        </div>
      `;
      listaelemek.push(listaElem);
      huzhatoLista.appendChild(listaElem);
    });
  esemenyfigyelok();
}

function huzasKezd() {
  kezdoIndex = +this.closest("li").getAttribute("data-index");
}

function huzasBelep() {
  this.classList.add("over");
}

function huzasKimegy() {
  this.classList.remove("over");
}

function huzasVege(e) {
  e.preventDefault();
}

function leejt() {
  const VegIndex = +this.getAttribute("data-index");
  csere(kezdoIndex, VegIndex);
  this.classList.remove("over");
}

function csere(indexTol, indexIg) {
  const egyikElem = listaelemek[indexTol].querySelector(".draggable");
  const masikElem = listaelemek[indexIg].querySelector(".draggable");
  listaelemek[indexTol].appendChild(masikElem);
  listaelemek[indexIg].appendChild(egyikElem);
}

function ellenoriz() {
  listaelemek.forEach((listaElem, index) => {
    const szemelyNeve = listaElem.querySelector(".draggable").innerText.trim();
    if (szemelyNeve !== leggazdagabbakListaja[index]) listaElem.classList.add("wrong");
    else {
      listaElem.classList.remove("wrong");
      listaElem.classList.add("right");
    }
  });
}

function esemenyfigyelok() {
  const huzhatoak = document.querySelectorAll(".draggable");
  const listaElemHuzas = document.querySelectorAll(".huzhato-lista li");
  huzhatoak.forEach((huzhatoelem) => {
    huzhatoelem.addEventListener("dragstart", huzasKezd);
  });
  listaElemHuzas.forEach((item) => {
    item.addEventListener("dragover", huzasVege);
    item.addEventListener("drop", leejt);
    item.addEventListener("dragenter", huzasBelep);
    item.addEventListener("dragleave", huzasKimegy);
  });
}

csekkol.addEventListener("click", ellenoriz);
listaLetrehoz();
