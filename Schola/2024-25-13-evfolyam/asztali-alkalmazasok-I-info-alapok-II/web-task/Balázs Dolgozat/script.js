var betolto = document.getElementById("megjelenito");

setInterval(
    function () {

        $("#megjelenito").load("orarend.php");

    },

    60000);