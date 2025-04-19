<?php 

    require "config.php";

    require "functions.php";

    // Elfogadás
    if(isset($_POST['ok-btn'])){

        $conn->query("UPDATE kerelem SET allapot='elfogadva' WHERE id=$_GET[id]");

    }

    // Elutasítás
    if(isset($_POST['not-btn'])){

        $conn->query("UPDATE kerelem SET allapot='elutasitva' WHERE id=$_GET[id]");

    }

    $lekerdezes = "SELECT * FROM kerelem WHERE ugyfelid=$_COOKIE[id] AND allapot='kerelem'";
    $talalt_kerelmek = $conn->query($lekerdezes);
    while($kerelem = $talalt_kerelmek->fetch_assoc()){
    
        echo "<form method='post' action='kerelmek.php?id=$kerelem[id]'>
                <label>$kerelem[osszeg] Ft</label>
                <input type='submit' name='ok-btn' value='Elfogadás'>
                <input type='submit' name='not-btn' value='Elutasítás'>
        </form>";

    }

?>