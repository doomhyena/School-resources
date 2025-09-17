<?php

    require "assets/php/config.php";

    if(isset($_POST['text-btn'])){
        $text = $_POST['text'];
        $conn->query("INSERT INTO texts VALUES (id, `$text`)");
    }

?>

<!DOCTYPE html>
<html lang='hu'>
   <head>
       <title>Főoldal</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Csontos Kincső'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
        <a href="szovegfeltoltes.php">Szövegfeltöltés</a>
        <div id=szovegek></div>
   </body>
   <script> src="assets/js/script.js"></script>
</html>
