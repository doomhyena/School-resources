//script.js
document.addEventListener("DOMContentLoaded", function() {
	const pdfGeneralasGomb = document.getElementById("pdfGeneralas");
	pdfGeneralasGomb.addEventListener("click", function() {
		//Önéletrajz adatok lekérése a mezőkből:
		const nev = document.getElementById("nev").value;
		const email = document.getElementById("email").value;
		const telefon = document.getElementById("telefon").value;
		const cim = document.getElementById("cim").value;
		const bemutatkozas = document.getElementById("bemutatkozas").value;
		const oktatas = document.getElementById("oktatas").value;
		const tapasztalat = document.getElementById("tapasztalat").value;
		const keszsegek = document.getElementById("keszsegek").value;
		
		//jsPDF példány létrehozása:
		const { jsPDF } = window.jspdf;
		const doc = new jsPDF();
		
		//A PDF doc felépítése:
		//(függőlegesen haladunk lefelé és adjuk hozzá az újabb elemeket)
		let yPozicio = 20; //Függőleges haladás értéke
		//Címsor:
		doc.setFontSize(22); //betűméret beállítása
		doc.text("Önéletrajz", 105, yPozicio, { align: "center" });
		//További szegmensek:
		yPozicio += 10; //Lejjebb megyünk
		doc.setFontSize(16); //betűméret átállítása
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
		doc.text("Bemutatkozás: " + bemutatkozas, 20, yPozicio);
		yPozicio += 7;
		//Több soros szöveg kezelése:
		const bemutatkozasSorok = doc.splitTextToSize(bemutatkozas, 170);
		doc.text(bemutatkozasSorok,20,yPozicio);
		yPozicio += bemutatkozasSorok.length * 7 + 5;
		//Oktatás szegmens:
		doc.setFontSize(16);
		doc.text("Oktatás", 20, yPozicio);
		yPozicio += 10;
		doc.setFontSize(12);
		const oktatasSorok = doc.splitTextToSize(oktatas, 170);
		doc.text(oktatasSorok, 20, yPozicio);
		yPozicio += oktatasSorok.length * 7 + 5;
		//Szakmai tapasztalat szegmens:
		doc.setFontSize(16);
		doc.text("Szakmai tapasztalat", 20, yPozicio);
		yPozicio += 10;
		doc.setFontSize(12);
		const tapasztalatSorok = doc.splitTextToSize(tapasztalat, 170);
		doc.text(tapasztalatSorok, 20, yPozicio);
		yPozicio += tapasztalatSorok.length * 7 + 5;
		//Készségek:
		doc.setFontSize(16); //16-os betűméret
		doc.text("Készségek", 20, yPozicio); //Készségek címsor 
		yPozicio += 10; //yPozicio 10-el lejjebb megy 
		doc.setFontSize(12); //12-es betűméret
		doc.text("Készségek: " + keszsegek, 20, yPozicio); //Készégek felirat +  a változó tartalma, 20, yPozicio.
		
		//PDF mentése:
		doc.save("oneletrajz.pdf");
	});
});
