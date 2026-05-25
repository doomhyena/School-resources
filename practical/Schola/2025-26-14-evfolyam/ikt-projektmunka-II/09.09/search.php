<?php

    require "assets/php/config.php";
    $sql = "SELECT * FROM texts";
    $result = $conn->query($sql);
    $texts = $result->fetch_assoc();

?>
<!DOCTYPE html>
<html lang='hu'>
   <head>
       <title>Keresés</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Neved'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
       <script src="http://code.jquery.com/jquery-latest.js"></script>
   </head>
   <body>
        <a href="index.php">Vissza</a>
        <br>
        <br>
	    <input type="text" id="search-box" placeholder="Felhasználó keresése...">
	    <div id="text"></div>
        </div>
        <script src="assets/js/script.js"></script>
   </body>
</html>