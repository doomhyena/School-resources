<?php 

    require "config.php";

    if(isset($_POST['k'])){
        $conn->query("UPDATE karbantartas SET allapot='karbantartas' WHERE id=1");
    }

    if(isset($_POST['not-k'])){
        $conn->query("UPDATE karbantartas SET allapot='' WHERE id=1");
    }

    $lekerdezes = "SELECT * FROM karbantartas WHERE id=1";
    $talalt_sor = $conn->query($lekerdezes);
    $sor = $talalt_sor->fetch_assoc();

    echo "<form method='post'>";

    if($sor['allapot'] == ''){
           echo "<input type='submit' name='k' value='Karbantartás bekapcsolása'>";

    }
    else{
           
        echo "<input type='submit' name='not-k' value='Karbantartás kikapcsolása'>";

    }
       echo "</form>";

?>