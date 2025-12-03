
document.addEventListener("DOMContentLoaded", function() { //az oldalra rakjuk rá, azt figyeli, hogy betöltődött-e a tartalom
  const pdfGeneralasGomb = document.getElementById("pdfGeneralas");//ID alapján keresi ki az oldalon lévő elemet
  
  pdfGeneralasGomb.addEventListener("click", function() {
    // Önéletrajz adatok lekérése a mezőkből
    const nev = document.getElementById("nev").value;
    const email = document.getElementById("email").value;
    const telefon = document.getElementById("telefon").value;
    const cim = document.getElementById("cim").value;
    const bemutatkozas = document.getElementById("bemutatkozas").value;
    const oktatas = document.getElementById("oktatas").value;
    const tapasztalat = document.getElementById("tapasztalat").value;
    const keszsegek = document.getElementById("keszsegek").value;
    
    // jsPDF példány létrehozása
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    let yPozicio = 20;
    // Címsor
    doc.setFontSize(22);
    doc.text("Önéletrajz", 105, yPozicio, { align: "center" });
    
    yPozicio += 10;
    doc.setFontSize(16);
    doc.text("Személyes adatok", 20, yPozicio);
    yPozicio += 10;
    doc.setFontSize(12);
    doc.text("Név: " + nev, 20, yPozicio);
    yPozicio += 7;
    doc.text("Email: " + email, 20, yPozicio);
    yPozicio += 7;
    doc.text("Telefonszám: " + telefon, 20, yPozicio);
    yPozicio += 7;
    doc.text("Cím: " + cim, 20, yPozicio);
    yPozicio += 10;
    doc.text("Bemutatkozás:", 20, yPozicio);
    yPozicio += 7;
    // Több soros szöveg kezelése
    const bemutatkozasSorok = doc.splitTextToSize(bemutatkozas, 170);
    doc.text(bemutatkozasSorok, 20, yPozicio);
    yPozicio += bemutatkozasSorok.length * 7 + 5;

    // Oktatás
    doc.setFontSize(16);
    doc.text("Oktatás", 20, yPozicio);
    yPozicio += 10;
    doc.setFontSize(12);
    const oktatasSorok = doc.splitTextToSize(oktatas, 170);
    doc.text(oktatasSorok, 20, yPozicio);
    yPozicio += oktatasSorok.length * 7 + 5;

    // Szakmai tapasztalat
    doc.setFontSize(16);
    doc.text("Szakmai tapasztalat", 20, yPozicio);
    yPozicio += 10;
    doc.setFontSize(12);
    const tapasztalatSorok = doc.splitTextToSize(tapasztalat, 170);
    doc.text(tapasztalatSorok, 20, yPozicio);
    yPozicio += tapasztalatSorok.length * 7 + 5;

    // Készségek
    doc.setFontSize(16);
    doc.text("Készségek", 20, yPozicio);
    yPozicio += 10;
    doc.setFontSize(12);
    doc.text("Készségek: " + keszsegek, 20, yPozicio);
    
    // PDF mentése
    doc.save("oneletrajz.pdf");
  });
});
