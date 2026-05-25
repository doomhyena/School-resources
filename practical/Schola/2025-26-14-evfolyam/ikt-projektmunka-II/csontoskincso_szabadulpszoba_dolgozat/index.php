<?php

    require "assets/php/config.php";

        $sql = "SELECT id, name FROM szoba";
        $talalt_szoba = $conn->query($sql);

?>
<!DOCTYPE html>
<html lang="hu">
   <head>
       <title>Főoldal</title>
       <meta charset='UTF-8'>
       <meta name='author' content='Csontos Kincső'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
    <h1>Elérhető szabadulószobák</h1>
        <?php
        if ($talalt_szoba->num_rows > 0) {
            while($szoba = $talalt_szoba->fetch_assoc()) {
                echo '<a href="szoba.php?id=' . $szoba['id'] . '">' . $szoba['name'] . '</a>';
            }
        } else {
            echo '<p>Jelenleg nincsen elérhető szoba!</p>';
        }
        ?>
   <script src="assets/js/script.js"></script>
   </body>
   </html>