<?php 

    require "config.php";

    if(isset($_POST['btn'])){

        $datum = date("Y-m-d H-i-s");

        $conn->query("INSERT INTO datum VALUES(id, '$_POST[text]', '$datum')");

    }

    echo "Feltöltött szövegek:<br></br>";

    $lekerdezes = "SELECT * FROM datum";
    $talalt_szovegek = $conn->query($lekerdezes);
    while($szoveg = $talalt_szovegek->fetch_assoc()){
    
        echo $szoveg['text']." ";

        if(date('d', strtotime($szoveg['date'])) == date('d')){
            echo date('H:i:s', strtotime($szoveg['date']));
        }
        else{
           
            if(date('Y', strtotime($szoveg['date'])) < date('Y')){
                echo date('Y.m.d', strtotime($szoveg['date']));
            }
            else{
                echo date('m.d', strtotime($szoveg['date']));
            }

        }

        echo "<br>";

    }

?>
<form method="post" action="feladat.php">
    <input name="text" type='text'>
    <input name="btn" type='submit'>
</form>