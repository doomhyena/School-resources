/*c) feladat*/
const keresoMezo = document.querySelector('.kereses-mezo');
const varosTartalom = document.querySelector('.kereses-mezo input');
const varosNeve = document.querySelector('.varos-nev p');
const feluletElem = document.querySelector('.torzs-resz');
const idoKep = document.querySelector('.csucs-resz img');
const adatElem = document.querySelector('.mogottes-resz');

const HomersekletAtvaltas = (kelvin) => {
    celcius = Math.round(kelvin - 273.15);
    return celcius;
}
const NappalVan = (ikon) => {
    if (ikon.includes('d')) { return true }
    else { return false }
}
AllapotFrissites = (varos) => {
    console.log(varos);
    const kepNeve = varos.weather[0].icon;
    const ikonforras = `http://openweathermap.org/img/wn/${kepNeve}@2x.png`
    varosNeve.textContent = varos.name;
    /*d) feladat*/
    feluletElem.innerHTML = `
    <div class="doboz-kozep row">
            <div class="col-8 text-center temp">
              <span>${HomersekletAtvaltas(varos.main.temp)}&deg;C</span>
            </div>
            <div class="col-4 condition-temp">
              <p class="leiras">${varos.weather[0].description}</p>
              <p class="high">${HomersekletAtvaltas(varos.main.temp_max)}&deg;C</p>
              <p class="low">${HomersekletAtvaltas(varos.main.temp_min)}&deg;C</p>
            </div>
          </div>
          <div class="ikon-helye card shadow mx-auto">
            <img src="${ikonforras}" alt="" />
          </div>
          <div class="doboz-also px-5 py-4 row">
            <div class="col text-center">
              <p>${HomersekletAtvaltas(varos.main.feels_like)}&deg;C</p>
              <span>Érzésre</span>
            </div>
            <div class="col text-center">
              <p>${varos.main.humidity}%</p>
              <span>Páratartalom</span>
            </div>
          </div>
    `;
    if (NappalVan(kepNeve)) {
        idoKep.setAttribute('src', 'kepek/nappal.svg');/*e) feladat*/
        if (varosNeve.classList.contains('text-white')) {
            varosNeve.classList.remove('text-white');/*f) feladat*/
        } else {
            varosNeve.classList.add('text-black');
        }
    } else {
        idoKep.setAttribute('src', 'ejjel.svg');/*e) feladat*/
        if (varosNeve.classList.contains('text-black')) {
            varosNeve.classList.remove('text-black');/*g) feladat*/
        } else {
            varosNeve.classList.add('text-white');
        }
    }
    adatElem.classList.remove('d-none');
}

keresoMezo.addEventListener('submit', e => {/*h) feladat*/
    e.preventDefault();
    const keresettVaros = varosTartalom.value.trim();
    console.log(keresettVaros);
    keresoMezo.reset();
    varostLekerdez(keresettVaros)
        .then((adatok) => {
            AllapotFrissites(adatok);
        })
        .catch((error) => { 
            console.log(error) 
        })/*i) feladat*/
})