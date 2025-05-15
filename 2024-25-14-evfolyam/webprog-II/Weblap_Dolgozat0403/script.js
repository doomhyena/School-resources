let CSV = ... //Tartalomnak válasszuk ki a 'csv' ID-jű elemet
let button = ... //Tartalomnak válasszuk ki a 'btn' ID-jű elemet
CSV.addEventListener('change', (event) => {
    const file = event.target.files[...]; //Ez a lista 1. elemére mutasson
    const reader = new FileReader();

    reader.onload = ... => { //sablon esemény paraméter
        const content = e.target.result;
        const rows = content.split('\n')
            .map(row => row.split(','));

        const table = ...//Tartalomnak válasszuk ki a 'table' ID-jű elemet...
        ... //...és állítsunk be neki egy üres HTML tartalmat

        for ... { //for ciklus 0-tól a rows hosszáig növekedve
            let tr = ... //Jöjjön létre egy 'tr' típusú elem az oldalon
            for ... { //for ciklus a rows aktuális elemének hozzáig
                let td = ... //Jöjjön létre egy 'td' típusú elem az oldalon
                td.... = ...; //td szöveges tartalma legyen az adott sor (rows) adott indexű eleme
                ...;} //td legyen tr gyermek-eleme
            ...;} //tr legyen table gyermek-eleme
        CSV.style.display = 'none';
        button.style.display = 'block';};

    reader.readAsText(file);
});

button.addEventListener('click', () => {
    const rows = ...; //Tartalomnak válasszuk ki az összes '#table tr' elemet
    let csvContent = '';

    for ... { //for ciklus 0-tól a rows hosszáig növekedve
        let row = rows[i];
        let cols = row....; //Tartalomnak válassza ki a 'row' elem összes 'td' nevű elemét
        let rowContent = '';

        for ... { //for ciklus 0-tól a cols hosszáig növekedve
            let col = cols[j];
            rowContent += ...;} //rowContent tartalma: az eddigi tartalom + a col szöveges tartalma + egy sima vessző

        csvContent += rowContent.slice(0, -1) + '\n';}

    const blob = new Blob([csvContent], 
        { type: 'text/csv' });
    const url = ....URL.createObjectURL(blob); //ez az utasítás az ablakra van felruházva

    const a = ...; //jöjjön létre az oldalon egy hperhivatkozás elem
    a.href = url;
    a.download = 'exportalt_adatok.csv';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    ....URL.revokeObjectURL(url);//ez az utasítás az ablakra van felruházva
});
