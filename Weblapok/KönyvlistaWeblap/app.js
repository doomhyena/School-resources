...; //Lokálisan értelmezett, sajatKonyvtar nevű üres lista

function Konyv(kcim, iro, oldalak, read) {
	//Ezen tulajdonságokat az aktuálisan kezelt elem kapja:
    ....kcim = kcim;
    ....iro = iro;
    ....oldalak = oldalak;
    ....read = read;
}

Konyv.prototype.userInfo = function() {
    if (this.read) {
        console.log(this.read);
        return this.kcim + " Tőle: " + this.iro + ", " + this.oldalak + " oldal, El van olvasva.";
    } else {
        console.log(this.read);
        return this.kcim + " Tőle: " + this.iro + ", " + this.oldalak + " oldal, Nincs elolvasva.";
    }
}

function KonyvHozzaad() {
    console.log("Konyv hozzaadva");
    KonyvTarto = document.getElementById('Konyv-tarto');
	//Ezen objektumok számára hozzuk létre a megfelelő elemeket az oldalon:
    ujKonyv = ...; //div
    ujKonyvFejlec = ...; //div
    ujKonyvSzerkeszt = ...; //img
    ujKonyvLeszed = ...; //img
    ujKonyvCim = ...; //h2
    ujKonyviro = ...; //h4
    ujKonyvoldalak = ...; //p
    ujKonyvGomb = ...; //div
    ujKonyvGombKor = ...; //div

    //Tulajdonságok beállítása:
    ujKonyv.className = 'Konyv';
    ujKonyvFejlec.id = 'Konyv-fejlec';
    ujKonyvLeszed.src = ...; //forrás = a TorlesIkon a kepek mappában
    ujKonyvLeszed.id = 'icon';
    ujKonyvLeszed.addEventListener("click", KonyvTorles, false);
    ujKonyvSzerkeszt.src = ...; //forrás = a SzerkesztIkon a kepek mappában
    ujKonyvSzerkeszt.id = 'icon';
    ujKonyvSzerkeszt.addEventListener("click", KonyvSzerkesztes, false);
    ujKonyvCim.id = 'Konyv-text';
    ujKonyvCim.textContent = "Konyv címe";
    ujKonyviro.id = 'Konyv-text';
    ujKonyviro.textContent = "Konyv iro";
    ujKonyvoldalak.id = 'Konyv-text';
    ujKonyvoldalak.textContent = "Konyv oldalak";
    ujKonyvGomb.className = 'toggle-button'
    ujKonyvGombKor.className = 'inner-circle';

    KonyvTarto.appendChild(ujKonyv);
    ujKonyv.appendChild(ujKonyvFejlec);
    ujKonyvFejlec.appendChild(ujKonyvLeszed);
    ujKonyvFejlec.appendChild(ujKonyvSzerkeszt);
    ujKonyv.appendChild(ujKonyvCim);
    ujKonyv.appendChild(ujKonyviro);
    ujKonyv.appendChild(ujKonyvoldalak);
    ujKonyv.appendChild(ujKonyvGomb);
    ujKonyvGomb.appendChild(ujKonyvGombKor);
}

function KonyvTorles() {
    console.log("Konyv eltavolitva");
    KonyvTarto = document.getElementById('Konyv-tarto');

    let KonyvekFejlec = event.target.parentNode;
    let KonyvekKartya = KonyvekFejlec.parentNode;

    ...; //Vegyük le a KonyvTarto-ról a KonyvekKartya gyermek-elemet
}

function KonyvSzerkesztes() {
    console.log("Konyv szerkesztve");
    let KonyvekFejlec = event.target.parentNode;
    let KonyvekKartya = KonyvekFejlec.parentNode;

    KonyvCim = KonyvekKartya.children[1];
    Konyviro = KonyvekKartya.children[2];
    Konyvoldalak = KonyvekKartya.children[3];

    console.log(KonyvCim);
    console.log(Konyviro);
    console.log(Konyvoldalak);
	//Ezen objektumok számára hozzuk létre a megfelelő elemeket az oldalon:
    KonyvFormHatter = ...; //div
    KonyvForm = ...; //div
    KonyvFormGombDiv = ...; //div
    KonyvFormNev = ...; //h2
    KonyvInputCim = ...; //input elem
    KonyvInputiro = ...; //input elem
    KonyvInputoldalak = ...; //input elem
    KonyvInputMentes = ...; //img
    KonyvInputTorles = ...; //img
    KonyvFormError = ...; //p
    KonyvInputMentes.addEventListener("click", KonyvInfoMentes, false);
    KonyvInputTorles.addEventListener("click", SzVisszavon, false);

    KonyvFormHatter.className = 'form-background';
    KonyvForm.className = 'form';
    KonyvFormGombDiv.className = 'button-div';
    KonyvFormNev.textContent = "Konyv szerkesztő"
    KonyvInputCim.className = 'input';
    KonyvInputiro.className = 'input';
    KonyvInputoldalak.className = 'input';
    KonyvInputCim.placeholder = "Konycím";
    KonyvInputiro.placeholder = "Író neve";
    KonyvInputoldalak.placeholder = "oldal";
    KonyvInputCim.type = ...; //szöveges adattípust várjon el
    KonyvInputiro.type = ...; //szöveges adattípust várjon el
    KonyvInputoldalak.type = ...; //szám adattípust várjon el
    KonyvInputMentes.src = ... //forrás = a MentesIkon a kepek mappában
    KonyvInputTorles.src = ... //forrás = a TorlesIkon a kepek mappában
    KonyvInputMentes.id = 'icon';
    KonyvInputTorles.id = 'icon';

    document.body.appendChild(KonyvFormHatter);
    KonyvFormHatter.appendChild(KonyvForm);
    KonyvForm.appendChild(KonyvFormNev);
    KonyvForm.appendChild(KonyvInputCim);
    KonyvForm.appendChild(KonyvInputiro);
    KonyvForm.appendChild(KonyvInputoldalak);
    KonyvForm.appendChild(KonyvFormGombDiv);
    KonyvFormGombDiv.appendChild(KonyvInputMentes);
    KonyvFormGombDiv.appendChild(KonyvInputTorles);
    KonyvForm.appendChild(KonyvFormError);

    function KonyvInfoMentes() {
        if (...) { //Ha a KonyvInputCim üres
            ...; //Akkor a KonyvFormError szöveges tartalma szóljon ránk
        } else if (...) { //Ha pedig a KonyvInputiro üres
            ...; //Akkor a KonyvFormError szöveges tartalma szóljon erről is
        } else if (...) { //Ha a KonyvInputoldalak üres
            ...; //Akkor a KonyvFormError szöveges tartalma szóljon erről
        } else {
            KonyvCim.textContent = KonyvInputCim.value;
            Konyviro.textContent = KonyvInputiro.value;
            Konyvoldalak.textContent = KonyvInputoldalak.value + " oldalak";

            document.body.removeChild(KonyvFormHatter);
        }
    }
	//Itt legyen egy SzVisszavon nevű függvény, ami leveszi a document body-járól a KonyvFormHatter gyermek-elemet:
    ... {
        ...
    }
}