<?php

    require "assets/db/db.php";

    if(!isset($_COOKIE['id'])){
		header("Location: reglog.php");
	}
?>
<!DOCTYPE html>
<html lang="hu">
   <head>
       <title>Főoldal</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Neved'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
    <h1>Főoldal</h1>
    <a href="logout.php">Kijelentkezés</a>
    <p>Apád!</p>
   </body>
</html>