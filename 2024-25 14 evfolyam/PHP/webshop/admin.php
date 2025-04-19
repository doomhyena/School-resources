<?php 

    require "config.php";

    require "functions.php";

    // Termék feltöltése
    if(isset($_POST['upload-item-btn'])){
        $conn->query("INSERT INTO termekek VALUES(id, '$_POST[name]', $_POST[quantity], $_POST[price], 0, 0)");
    }

    // Rendelés mentése
    if(isset($_POST['save-btn'])){

        $rendelesid = $_GET['rendelesid'];

        $conn->query("UPDATE rendelesek SET status='$_POST[status]' WHERE id=$rendelesid");

    }

    echo "<form method='post' action='admin.php'>
            <input name='name' type='text' placeholder='Termék neve'>
            <input name='quantity' type='number' placeholder='Termék mennyisége'>
            <input name='price' type='number' placeholder='Termék ára'>
            <input name='upload-item-btn' type='submit' placeholder='Termék feltöltése'>
        </form><hr>";

    $lekerdezes = "SELECT * FROM termekek";
    $talalt_termekek = $conn->query($lekerdezes);
    while($termek = $talalt_termekek->fetch_assoc()){
    
        // Nem akciós
        if($termek['on_sale'] == 0){

            echo $termek['name']." ".$termek['price']." nem ".$termek['sale_price']." <a href='editproduct.php?productid=$termek[id]'>Szerkesztés</a><br>";

        }
        // Akciós
        else{

            echo $termek['name']." ".$termek['price']." igen ".$termek['sale_price']." <a href='editproduct.php?productid=$termek[id]'>Szerkesztés</a><br>";
        }

    }

    echo "<hr>";
    echo "<h1>Rendelések</h1>";

    echo "<h3>Új rendelések</h3>";

    generateOrder('új');
    
    echo "<h3>Feldolgozva</h3>";

    generateOrder('feldolgozva');

    echo "<h3>Szállítás alatt</h3>";

    generateOrder('szallitas');

    echo "<h3>Kiszállítva</h3>";

    generateOrder('kiszallitva');

?>