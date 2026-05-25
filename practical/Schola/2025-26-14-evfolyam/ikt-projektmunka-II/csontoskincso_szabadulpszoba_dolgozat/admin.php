<?php

    require "assets/php/config.php";

    /*
    
        $titkositottjelszo = password_hash("SzabSzoba2025", PASSWORD_DEFAULT);
        echo $titkositottjelszo;

    */


    if(isset($_POST['szobareg-btn'])) {

        $sql = "SELECT * FROM szoba";
        $talaltszoba = $conn->query($sql);
        $szoba = $talaltszoba->fetch_assoc();

        if($szoba['name'] != $_POST['szobanev']) {
            if($_POST['megoldasiido'] >= 0) {
                if($_POST['letszam'] >= 0) {
                    if($_POST['ar'] >= 0) {

                        $adminjelszo = "SELECT * admin WHERE id = 1";
                        $talatjelszo = $conn->query($sql);
                        $jelszo = $talatjelszo->fetch_assoc();

                        if (password_verify($_POST['password'], $jelszo['password'])) {

                            $conn->query("INSERT INTO szoba VALUES(id, '$_POST[szobanev]', '$_POST[megoldasiido]', '$_POST[letszam]', '$_POST[ar]')");
                            echo "<script>alert('A szoba feltöltése sikers volt!')</script>";

                        } else {
                            echo "<script>alert('A jelszavak nem egyeznek meg!')</script>";
                        }
                    } else {
                        echo "<script>alert('A megoldási idő nem lehet 0 vagy annál kevesebb!')</script>";
                    }
                } else {
                    echo "<script>alert('A létszám nem lehet 0 vagy annál kevesebb!')</script>";
                }
            } else {
                echo "<script>alert('A ár nem lehet 0 vagy annál kevesebb!')</script>";
            }
        } else {
            echo "<script>alert('Ilyen szoba már létezik!')</script>";
        }
    }


?>
<!DOCTYPE html>
<html lang="hu">
   <head>
       <title>Admin oldal</title>
       <meta charset='UTF-8'>
       <meta name='author' content='Csontos Kincső'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
    <form method="post">
        <input type="text" name="szobanev" id="szobanev" placeholder="Szoba neve"><br><br>
        <input type="number" name="megoldasiido" id="megoldasiido" placeholder="Megoldás ideje"><br><br>
        <input type="number" name="letszam" id="letszam" placeholder="Maxmimális létszám"><br><br>
        <input type="number" name="ar" id="ar" placeholder="Ár"><br><br>
        <input type="password" name="password" id="password" placeholder="Admin jelsző"><br><br>
        <input type="submit" name="szobareg-btn" id="szobareg-btn" value="Szoba feltöltése">
    </form>
   <script src="assets/js/script.js"></script>
   </body>
</html>