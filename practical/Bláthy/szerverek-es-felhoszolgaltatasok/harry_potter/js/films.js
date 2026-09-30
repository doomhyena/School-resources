let filmek = document.getElementById('filmek');
let filmContent = document.getElementById('film');

let film = new XMLHttpRequest();

const filmsList = [];
const actorsList = [];

film.open("GET", "http://localhost/harry_potter/restapi/index.php/films/list", false);
film.onload = (function (){
    let dataSend = JSON.parse(film.responseText);
    renderFilms(dataSend);
    filmsList.push(dataSend);
});
film.send();


let actor = new XMLHttpRequest();

actor.open("GET", "http://localhost/harry_potter/restapi/index.php/actors/list", false);
actor.onload = (function (){
    let dataSend = JSON.parse(actor.responseText);
    actorsList.push(dataSend);
});
actor.send();


function renderFilms(data) {
    let htmlString = "";
    htmlString += "<table class='table table-bordered '><thead><tr class='text-center'>";

    for (let i = 0; i < data.length; i++){
        htmlString += "<th class='hatter'><h4>"+ data[i].title +"</h4></th>";
    }
    htmlString += "</tr></thead><tbody><tr class='text-center'>";

    for (let i = 0; i < data.length; i++){
        htmlString += "<td class='hatter'><img onclick='films("+ i +")' class='jkr' src='"+ data[i].img_url +"'></td>";
    }

    htmlString += "</tr></tbody></table>";

    filmek.insertAdjacentHTML("beforeend", htmlString);
}


function films(x) {
    filmContent.innerHTML = "";
    let filmActors = [];

    for (let i = 0; i <filmsList.length; i++) {
        filmActors.push(filmsList[0][x].actors_id.split(';'));
    }

    let htmlString = "";

    htmlString += "<div class='col-sm-3 text-center'>";
    htmlString += "<h1>"+ filmsList[0][x].title +"</h1>";
    htmlString += "<img class='jkr img-fluid' src='"+ filmsList[0][x].img_url +"' ></div>";
    htmlString += "<div class='col-sm-6 text-center'>";
    htmlString += "<h1>Szereplők</h1>";
    htmlString += "<table class='table table-bordered text-center'>";
    htmlString += "<tr class='house_font'><th class='hatter'>Színész</th><th class='hatter'>Szereplő</th></tr>";
    for (let i = 0; i < filmActors[0].length; i++) {
        for (let j = 0; j < actorsList[0].length; j++) {
            if (parseInt(filmActors[0][i]) === actorsList[0][j].id){
                htmlString += "<tr class='house_font'><td class='hatter'>"+ actorsList[0][j].name +"</td><td class='hatter'>"+ actorsList[0][j].film_character +"</td></tr>";
            }

        }

    }


    htmlString += "</table></div>";
    htmlString += "<div class='col-sm-3 text-center'>";
    htmlString += "<h1>Adatok</h1><ul>";
    htmlString += "<li><h3>Bemutatása: "+ filmsList[0][x].premier.replaceAll('-','.') +"</h3></li>";
    htmlString += "<li><h3>Rendező: "+ filmsList[0][x].director +"</h3></li>";

    if (Math.round(filmsList[0][x].income / 1000000) < 1000){
        htmlString += "<li><h3>Bevétel: "+ Math.round(filmsList[0][x].income / 1000000) +" millió $</h3></li>";
    }
    else {
        htmlString += "<li><h3>Bevétel: "+ Math.round(filmsList[0][x].income / 1000000000) +" billió $</h3></li>";
    }
    htmlString += "</ul>";
    filmContent.insertAdjacentHTML("beforeend", htmlString);
}