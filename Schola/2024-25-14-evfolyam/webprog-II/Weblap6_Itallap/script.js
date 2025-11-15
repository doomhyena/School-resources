"use strict";
let kosar = JSON.parse(localStorage.getItem("kosar")) || [];

const kosarElem = document.querySelector(".kosar");
const hozzaadGombok = document.querySelectorAll(
  '[data-action="ADD_TO_kosar"]'
);

if (kosar.length > 0) {
  kosar.forEach((kosarElem) => {
    const termek = kosarElem;
    termekBerakas(termek);
    kosarOsszegzes();
    hozzaadGombok.forEach((kosarhozAdGomb) => {
      const termekDOM = kosarhozAdGomb.parentNode;
      if (
        termekDOM.querySelector(".termek__name").innerText === termek.name
      ) {
        gombKezelo(kosarhozAdGomb, termek);
      }
    });
  });
}

hozzaadGombok.forEach((kosarhozAdGomb) => {
  kosarhozAdGomb.addEventListener("click", () => {//Kattintásfigxelő az adott gombra
    const termekDOM = kosarhozAdGomb.parentNode;
    const termek = {
      image: termekDOM.querySelector(".termek__image").getAttribute("src"),
      name: termekDOM.querySelector(".termek__name").innerText,
      price: termekDOM.querySelector(".termek__price").innerText,
      quantity: 1,
    };
    const bekerult =
      kosar.filter((kosarElem) => kosarElem.name === termek.name).length > 0;
    if (!bekerult) {
      kosar.push(termek);
      termekBerakas(termek);
      kosarMentese();
      gombKezelo(kosarhozAdGomb, termek);
    }
  });
});

function termekBerakas(termek) {
  kosarElem.insertAdjacentHTML(//HTML szegmens berakása a JS kódba
    "beforeend",
    `
    <div class="kosar__item">
      <img class="kosar__item__image" src="${termek.image}" alt="${
      termek.name
    }" />
      <h3 class="kosar__item__name">${termek.name}</h3>
      <h3 class="kosar__item__price">${termek.price}</h3>
      <button class="btn btn--primary btn--small ${
        termek.quantity === 1 ? " btn--danger" : ""
      }" data-action="DECREASE_ITEM">&minus;</button>
      <h3 class="kosar__item__quantity">${termek.quantity}</h3>
      <button class="btn btn--primary btn--small" data-action="INCREASE_ITEM">&plus;</button>
      <button class="btn btn--danger btn--small" data-action="REMOVE_ITEM">&times;</button>
    </div>`
  );
  labreszKezelo();
}

function gombKezelo(kosarhozAdGomb, termek) {
  kosarhozAdGomb.innerText = "Kosárban";//Kombon megjelenő új szöveg
  kosarhozAdGomb.disabled = true;//Ne lehessen rákattintani

  const kosarElemek = kosarElem.querySelectorAll(".kosar__item");
  kosarElemek.forEach((kosarElemDOM) => {
    if (
      kosarElemDOM.querySelector(".kosar__item__name").innerText === termek.name
    ) {
      kosarElemDOM
        .querySelector('[data-action="INCREASE_ITEM"]')
        .addEventListener("click", () => mennyNoveles(termek, kosarElemDOM));

      kosarElemDOM
        .querySelector('[data-action="DECREASE_ITEM"]')
        .addEventListener("click", () =>
          mennyCsokkentes(termek, kosarElemDOM, kosarhozAdGomb)
        );

      kosarElemDOM
        .querySelector('[data-action="REMOVE_ITEM"]')
        .addEventListener("click", () =>
          termekEltavolitasa(termek, kosarElemDOM, kosarhozAdGomb)
        );
    }
  });
}

function mennyNoveles(termek, kosarElemDOM) {
  kosar.forEach((kosarElem) => {
    if (kosarElem.name === termek.name) {
      kosarElemDOM.querySelector(
        ".kosar__item__quantity"
      ).innerText = ++kosarElem.quantity;//++ elől: előbba művelet, uána a megjelenítés
      kosarElemDOM
        .querySelector('[data-action="DECREASE_ITEM"]')
        .classList.remove("btn--danger");
      kosarMentese();
    }
  });
}

function mennyCsokkentes(termek, kosarElemDOM, kosarhozAdGomb) {
  kosar.forEach((kosarElem) => {
    if (kosarElem.name === termek.name) {
      if (kosarElem.quantity > 1) {
        kosarElemDOM.querySelector(
          ".kosar__item__quantity"
        ).innerText = --kosarElem.quantity;
        kosarMentese();
      } else {
        termekEltavolitasa(termek, kosarElemDOM, kosarhozAdGomb);
      }
      if (kosarElem.quantity === 1) {
        kosarElemDOM
          .querySelector('[data-action="DECREASE_ITEM"]')
          .classList.add("btn--danger");
      }
    }
  });
}

function termekEltavolitasa(termek, kosarElemDOM, kosarhozAdGomb) {
  kosarElemDOM.classList.add("kosar__item--removed");
  setTimeout(() => kosarElemDOM.remove(), 300);
  kosar = kosar.filter((kosarElem) => kosarElem.name !== termek.name);//Szűrjük ki a felesleges terméket
  kosarMentese();
  kosarhozAdGomb.innerText = "Hozzáad";
  kosarhozAdGomb.disabled = false;
  if (kosar.length < 1) {
    document.querySelector(".kosar-footer").remove();
  }
}

function labreszKezelo() {
  if (document.querySelector(".kosar-footer") === null) {//Null: Ha nem talál ilyen elemet
    kosarElem.insertAdjacentHTML(//HTML szegmens berakása JS kódba
      "afterend",
      `
  <div class="kosar-footer">
      <button class="btn btn--danger" data-action="CLEAR_kosar">Ürít</button>
      <button class="btn btn--primary" data-action="fizetes">Fizess</button>
  </div>
  `
    );
    document
      .querySelector('[data-action="CLEAR_kosar"]')
      .addEventListener("click", () => kosarUrites());
    document
      .querySelector('[data-action="fizetes"]')
      .addEventListener("click", () => fizetes());
  }
}

function kosarUrites() {
  kosarElem.querySelectorAll(".kosar__item").forEach((kosarElemDOM) => {
    kosarElemDOM.classList.add("kosar__item--removed");
    setTimeout(() => kosarElemDOM.remove(), 300);//Késleltetés 3 tizedMp-vel
  });
  kosar = [];
  localStorage.termekEltavolitasa("kosar");
  document.querySelector(".kosar-footer").remove();
  hozzaadGombok.forEach((kosarhozAdGomb) => {
    kosarhozAdGomb.innerText = "Hozzáad";
    kosarhozAdGomb.disabled = false;
  });
}

function fizetes() {
  let paypalFormHTML = `
  <form id="paypal-form" action="BankiLinkIde" method="post">
    <input type="hidden" name="cmd" value="_kosar">
    <input type="hidden" name="upload" value="1">
    <input type="hidden" name="business" value="EmailünkIde">
`;
  kosar.forEach((kosarElem, index) => {
    ++index;
    paypalFormHTML += `
    <input type="hidden" name="item_name_${index}" value=${kosarElem.name}>
    <input type="hidden" name="amount_${index}" value=${kosarElem.price}>
    <input type="hidden" name="quantity_${index}" value=${kosarElem.quantity}>
 
  `;
  });

  paypalFormHTML += `
    <input type="submit" value="PayPal">
    <div class="overlay"></div>
</form>
  `;
  document
    .querySelector("body")
    .insertAdjacentHTML("beforeend", paypalFormHTML);
  document.getElementById("paypal-form").submit();//Mögöttes adatkezelésre
}
function kosarOsszegzes() {
  let kosarSzumma = 0;
  kosar.forEach((kosarElem) => {
    kosarSzumma += kosarElem.quantity * kosarElem.price;
  });
  document.querySelector(
    '[data-action="fizetes"]'
  ).innerText = `Végösszeg: $${kosarSzumma}`;//Kiírjuk a Fizetés gombra a végösszeget is
}
function kosarMentese() {
  localStorage.setItem("kosar", JSON.stringify(kosar));//JSON stringként mentjük
  kosarOsszegzes();
}
