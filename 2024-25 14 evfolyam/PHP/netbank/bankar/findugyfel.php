<?php 

    require "config.php";

    $lekerdezes = "SELECT * FROM ugyfel_users WHERE netbankid LIKE '%$_GET[keresett]%'";
    $talalt_ugyfelek = $conn->query($lekerdezes);
    while($ugyfel = $talalt_ugyfelek->fetch_assoc()){
    
        echo "<a href='ugyfel.php?netbankid=".$ugyfel['netbankid']."'>".$ugyfel['netbankid']." - ".$ugyfel['name']."</a><br>";

    }

?>