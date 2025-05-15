//Ezeket ID alapján keressük meg:
const draggableList = document.getElementById("draggable-list");
const check = document.getElementById("check");

const richestPeople = [ //A tömb megfelelően legyen jelölve
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

const listItems = [];

let dragStartIndex;

function createList() {
  const newList = [...richestPeople];
  newList
    .map((person) => ({ value: person, sort: Math.random() }))//Egy random szám legyen
    .sort((a, b) => a.sort - b.sort)
    .map((person) => person.value)
    .forEach((person, index) => {
      const listItem = document.createElement("li");//Jöjjön létre egy listaelem az oldalon
      listItem.setAttribute("data-index", index);
      listItem.innerHTML = `
        <span class="number">${index + 1}</span>
        <div class="draggable" draggable="true">
          <p class="person-name">${person}</p>
          <i class="fas fa-grip-lines"></i>
        </div>
      `;
      listItems.push(listItem);//A listItems listához fűzzük hozzá a listItem elemet
      draggableList.appendChild(listItem);
    });
  addListeners();
}

function dragStart() {
  dragStartIndex = +this.closest("li").getAttribute("data-index");
}

function dragEnter() {
  this.classList.add("over");//Ezen elemre kerüljön fel az "over" formázás.
}

function dragLeave() {
  this.classList.remove("over");//Itt pedig vegyük le az "over" formázást.
}

function dragOver(e) {
  e.preventDefault();//akadályozd meg az alapraméretezett események futását.
}

function dragDrop() {
  const dragEndIndex = +this.getAttribute("data-index");
  swapItems(dragStartIndex, dragEndIndex);
  this.classList.remove("over");//Itt is vegyük le az "over" formázást.
}

function swapItems(fromIndex, toIndex) {
  const itemOne = listItems[fromIndex].querySelector(".draggable");
  const itemTwo = listItems[toIndex].querySelector(".draggable");
  listItems[fromIndex].appendChild(itemTwo);
  listItems[toIndex].appendChild(itemOne);
}

function checkOrder() {
  listItems.forEach((listItem, index) => {//Egészítsd ki a foreach utasítást
    const personName = listItem.querySelector(".draggable").innerText.trim();
    if (personName !== richestPeople[index]) listItem.classList.add("wrong");
    else {
      listItem.classList.remove("wrong");//Vegyük le a "wrong" formázást.
      listItem.classList.add("right");//Kerüljön fel a "right" formázás.
    }
  });
}

function addListeners() {
  const draggables = document.querySelectorAll(".draggable");
  const dragListItems = document.querySelectorAll(".draggable-list li");
  draggables.forEach((draggable) => {//Egészítsd ki a foreach utasítást
    draggable.addEventListener("dragstart", dragStart);
  });
  dragListItems.forEach((item) => {
    item.addEventListener("dragover", dragOver);
    item.addEventListener("drop", dragDrop);
    item.addEventListener("dragenter", dragEnter);
    item.addEventListener("dragleave", dragLeave);
  });
}

check.addEventListener("click", checkOrder);

createList();//A végén hívjuk meg a listát létrehozó függvényünket.
