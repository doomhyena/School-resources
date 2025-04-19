<?php 

    require "config.php";

    $rendelesid = $_GET['rendelesid'];

    $lekerdezes = "SELECT * FROM rendelesek WHERE id=$rendelesid";
    $talalt_rendeles = $conn->query($lekerdezes);
    $rendeles = $talalt_rendeles->fetch_assoc();

    // Rendelt termékek listája
    $termekek = explode(";", $rendeles['termekek']);

    $vegosszeg = 0;

    for($i=0;$i<count($termekek);$i++){

        $adatok = explode("-", $termekek[$i]);

        // Adatok felépítése
        //    index     adott tulajdonság
        //      0             termék id
        //      1             méret id
        //      2             darabszám
        //      3             ár/db

        // Termék lekérdezése
        $lekerdezes = "SELECT * FROM termekek WHERE id = $adatok[0]";
        $talalt_termek = $conn->query($lekerdezes);
        $termek = $talalt_termek->fetch_assoc();

        echo $termek['name'];

        if($adatok[1] == 0){
            echo " -";
        }
        else{

            $lekerdezes = "SELECT * FROM meretek WHERE id=$adatok[1]";
            $talalt_meret = $conn->query($lekerdezes);
            $meret = $talalt_meret->fetch_assoc();

            echo " ".$meret['size_name'];

        }

        echo " ".$adatok[2]." db ";

        $osszeg = $adatok[2]*$adatok[3];

        echo $osszeg." Ft<br>";

        $vegosszeg += $osszeg;

    }

    echo "<hr>";
    echo "Végösszeg: $vegosszeg";

?>