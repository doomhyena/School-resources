let sajatKonyvtar = []; // Lokálisan értelmezett, sajatKonyvtar nevű üres lista

function Konyv(kcim, iro, oldalak, read) {
    // Ezen tulajdonságokat az aktuálisan kezelt elem kapja:
    this.kcim = kcim;
    this.iro = iro;
    this.oldalak = oldalak;
    this.read = read;
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
    // Ezen objektumok számára hozzuk létre a megfelelő elemeket az oldalon:
    ujKonyv = document.createElement('div'); // div
    ujKonyvFejlec = document.createElement('div'); // div
    ujKonyvSzerkeszt = document.createElement('img'); // img
    ujKonyvLeszed = document.createElement('img'); // img
    ujKonyvCim = document.createElement('h2'); // h2
    ujKonyviro = document.createElement('h4'); // h4
    ujKonyvoldalak = document.createElement('p'); // p
    ujKonyvGomb = document.createElement('div'); // div
    ujKonyvGombKor = document.createElement('div'); // div

    // Tulajdonságok beállítása:
    ujKonyv.className = 'Konyv';
    ujKonyvFejlec.id = 'Konyv-fejlec';
    ujKonyvLeszed.src = 'kepek/TorlesIkon.svg'; // forrás = a TorlesIkon a kepek mappában;
    ujKonyvLeszed.id = 'icon';
    ujKonyvLeszed.addEventListener("click", KonyvTorles, false);
    ujKonyvSzerkeszt.src = 'kepek/SzerkesztIkon.svg'; // forrás = a SzerkesztIkon a kepek mappában
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

    KonyvTarto.removeChild(KonyvekKartya); // Vegyük le a KonyvTarto-ról a KonyvekKartya gyermek-elemet
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
    // Ezen objektumok számára hozzuk létre a megfelelő elemeket az oldalon:
    KonyvFormHatter = document.createElement('div'); // div
    KonyvForm = document.createElement('div'); // div
    KonyvFormGombDiv = document.createElement('div'); // div
    KonyvFormNev = document.createElement('h2'); // h2
    KonyvInputCim = document.createElement('input'); // input elem
    KonyvInputiro = document.createElement('input'); // input elem
    KonyvInputoldalak = document.createElement('input'); // input elem
    KonyvInputMentes = document.createElement('img'); // img
    KonyvInputTorles = document.createElement('img'); // img
    KonyvFormError = document.createElement('p'); // p
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
    KonyvInputCim.type = 'text'; // szöveges adattípust várjon el
    KonyvInputiro.type = 'text'; // szöveges adattípust várjon el
    KonyvInputoldalak.type = 'number'; // szám adattípust várjon el
    KonyvInputMentes.src = 'kepek/MentesIkon.svg'; // forrás = a MentesIkon a kepek mappában
    KonyvInputTorles.src = 'kepek/TorlesIkon.svg'; // forrás = a TorlesIkon a kepek mappában
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
        if (KonyvInputCim.value.trim() === '') { // Ha a KonyvInputCim üres
            KonyvFormError.textContent = 'Kérjük, adja meg a könyv címét!'; // Akkor a KonyvFormError szöveges tartalma szóljon ránk
        } else if (KonyvInputiro.value.trim() === '') { // Ha pedig a KonyvInputiro üres
            KonyvFormError.textContent = 'Kérjük, adja meg az író nevét!'; // Akkor a KonyvFormError szöveges tartalma szóljon erről is
        } else if (KonyvInputoldalak.value.trim() === '') { // Ha a KonyvInputoldalak üres
            KonyvFormError.textContent = 'Kérjük, adja meg az oldalak számát!'; // Akkor a KonyvFormError szöveges tartalma szóljon erről
        } else {
            KonyvCim.textContent = KonyvInputCim.value;
            Konyviro.textContent = KonyvInputiro.value;
            Konyvoldalak.textContent = KonyvInputoldalak.value + " oldalak";

            document.body.removeChild(KonyvFormHatter);
        }
    }
    // Itt legyen egy SzVisszavon nevű függvény, ami leveszi a document body-járól a KonyvFormHatter gyermek-elemet:
    function SzVisszavon() {
        document.body.removeChild(KonyvFormHatter);
    }
}
