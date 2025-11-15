<?php

    require "assets/php/config.php";

    $id = $_GET['id'];
    $sql = "SELECT * FROM szoba WHERE id = $id";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        $szoba = $result->fetch_assoc();
    } else {
        echo "<script>alert('Ilyen szoba nem létezik!')</script>";
        header("Location: index.php");
    }

        if(isset($_POST['foglalas-btn'])) {
            $conn->query("INSERT INTO foglalas VALUES(id, '$_POST[felhasznalonev]', '$_POST[email]', NOW())");
        }
?>
<!DOCTYPE html>
<html lang="hu">
   <head>
       <title><?= $szoba['name'] ?></title>
       <meta charset='UTF-8'>
       <meta name='author' content='Csontos Kincső'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
    <form method="post">
        <input type="text" name="felhasznalonev" id="felhasznalonev" placeholder="Felhasználónév"><br><br>
        <input type="email" name="email" id="email" placeholder="Email"><br><br>
        <input type="submit" name="foglalas-btn" id="foglalas-btn" value="Foglalás">
    </form>
   <body>
   <script src="assets/js/script.js"></script>
   </body>