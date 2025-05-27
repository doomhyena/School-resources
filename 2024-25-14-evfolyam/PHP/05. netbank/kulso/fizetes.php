<?php 

    require "config.php";

    require "functions.php";

    $lekerdezes = "SELECT * FROM kerelem WHERE id=$_GET[id]";
    $talalt_kerelem = $conn->query($lekerdezes);
    $kerelem = $talalt_kerelem->fetch_assoc();

    if($kerelem['allapot'] == 'kerelem'){

        echo "Várakozás a fizetés feldolgozására...";

    }
    else if($kerelem['allapot'] == 'elfogadva'){

        echo "Sikeres fizetés!";

    }
    else{

        echo "Fizetés elutasítva!";

    }

?>
<meta http-equiv="refresh" content="2">