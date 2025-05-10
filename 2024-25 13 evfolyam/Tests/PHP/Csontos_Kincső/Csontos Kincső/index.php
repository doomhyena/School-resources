<?php

    require "config.php";

    session_start();


        $lekerdezes = "SELECT * FROM users WHERE id=".$_SESSION['id'];
        $talalt_felhasznalo = $conn->query($lekerdezes);

        if(mysqli_num_rows($talalt_felhasznalo) == 1){
        
            $felhasznalo = $talalt_felhasznalo->fetch_assoc();

            echo "<h1> Szia, ".$felhasznalo['username']."! </h1>";
            echo "<a href='feltoltes.php'>Feltöltés</a>";
        }

?>
<!DOCTYPE html>
<html>
   <head>
       <title>Főoldal</title>
       <meta charset='UTF-8'> 
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Csontos Kincső'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
    <div>
        <ul>
            <?php 
                $eleresi_ut = "users/".$_SESSION['username']."/";
                foreach($files as $file){
                    echo "<li><a href='".$eleresi_ut.$file."' download>$file</a></li>";
                }
            ?>
        </ul>
    </div>
   </body>
</html>