let root = document.getElementById("root");

let xhr = new XMLHttpRequest();

xhr.open("GET", "http://localhost/harry_potter/restapi/index.php/books/list");
xhr.onload = (function (){
   let dataSend = JSON.parse(xhr.responseText);
   renderHTML(dataSend);
});
xhr.send();


function renderHTML(data) {
    let htmlString = "";


    for (let i = 0; i < data.length; i++){
        htmlString += "<div class='row'>";
        htmlString += "<div class='col-sm-3'></div>";
        htmlString += "<div class='col-sm-6'><div class='card hatter mt-2'> <div class='card-header'><div class='card-title'>";
        htmlString += "<h2 class='text-center'>" + data[i].title +"</h2></div></div><div class='card-body'><div class='card-img text-center'>";
        htmlString += "<img src='"+ data[i].img_url +"' class='img-fluid jkr'></div>";
        htmlString += "<div class='card-footer mt-4'><p class='text-center'>Publikálása: " + data[i].publication_date + "</p>";
        htmlString += "<p class='text-center'>Oldalszám: "+ data[i].pages +"</p></div>";
        htmlString += "<div class='col-sm-3'></div>";
        htmlString += "</div></div></div></div>";
    }


    root.insertAdjacentHTML("beforeend", htmlString);
}