const apiKulcs = "cbe3dd267a18f6c89943b3eff94f1ed7"; /*j) feladat*/

const varostLekerdez = async (varos) => {

    const alapLink = 'http://api.openweathermap.org/data/2.5/weather'
    const query = `?q=${varos}&appid=${apiKulcs}`;/*l) feladat*/
    const eredmeny = await fetch(alapLink + query);
    const adatok = await eredmeny.json();/*k) feladat*/

    return adatok;
}