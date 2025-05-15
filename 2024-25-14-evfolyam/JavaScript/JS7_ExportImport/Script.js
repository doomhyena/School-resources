let CSV = document.getElementById('csv'); //Id alapján keresés
let button = document.getElementById('btn');
CSV.addEventListener('change', (event) => { //'change' = állapotváltozás esemény
    const file = event.target.files[0]; //even.target = az esemény tárgy-eleme
    const reader = new FileReader();

    reader.onload = (e) => { //onload = a betöltéskor
        const content = e.target.result;
        const rows = content.split('\n')
            .map(row => row.split(','));

        const table = 
            document.getElementById('table');
        table.innerHTML = '';
//Szöveges tartalom lehet: innerHTML, innerText, textContent
		//Táblázat felépítése: külső for = sorok felépítése, belső for = cellák berakása
        for (let i = 0; i < rows.length; i++) {
            let tr = document.createElement('tr');
            for (let j = 0; j < rows[i].length; j++) {
                let td = document.createElement('td'); //megjelenő elem létrehozás az aoldalon
                td.textContent = rows[i][j]; //Tömbökből álló tömbnél a dupla index: i. altömb j. eleme
                tr.appendChild(td);} //gyermek-elemként jelölés
            table.appendChild(tr);}
        CSV.style.display = 'none';
        button.style.display = 'block';}; //A button elem stíluselemei közül a megjelenítést állítgatom
    reader.readAsText(file);
});

button.addEventListener('click', () => {
	//Elemek kiválasztása az oldalon:
		//getElementById() --> elem ID-je alapján 1-et
		//querySelector() --> elem neve alapján egyet
		//querySelectorAll() --> elem neve alapján az összesen (tárolás: tömbben)
    const rows = document.querySelectorAll('#table tr');
    let csvContent = '';

    for (let i = 0; i < rows.length; i++) {
        let row = rows[i];
        let cols = row.querySelectorAll('td');
        let rowContent = '';

        for (let j = 0; j < cols.length; j++) {
            let col = cols[j];
            rowContent += col.textContent + ',';}

        csvContent += rowContent.slice(0, -1) + '\n';}

    const blob = new Blob([csvContent], 
        { type: 'text/csv' });
    const url = window.URL.createObjectURL(blob);

    const a = document.createElement('a'); //hiperhivatkozás létrehozása az oldalon
    a.href = url;
    a.download = 'exported_data.csv';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    window.URL.revokeObjectURL(url);
	//document vagy window? --> csak a tartalmat vagy az egész ablakot nézzük-e?
});
