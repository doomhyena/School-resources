<?php 

    require "config.php";

    // Megvizsgáljuk, hogy van-e művész bejelentkezve
    if(isset($_COOKIE['artistid'])){

        $lekerdezes = "SELECT * FROM artists WHERE id=$_COOKIE[artistid]";
        $talalt_muvesz = $conn->query($lekerdezes);
        $muvesz = $talalt_muvesz->fetch_assoc();

    }
    // Ha nincs -> átirányítás a bejelentkezés oldalra
    else{

        header("Location: artistlogin.php");

    }

?>
<h1><?= $muvesz['name']; ?></h1>
<hr>
<a href="upload.php">Zene feltöltése</a>