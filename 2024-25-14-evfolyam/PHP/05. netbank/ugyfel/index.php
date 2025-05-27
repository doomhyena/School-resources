<?php 

    require "config.php";

    if(isset($_COOKIE['id'])){

        $lekerdezes = "SELECT * FROM ugyfel_users WHERE id=$_COOKIE[id]";
        $talalt_ugyfel = $conn->query($lekerdezes);
        $ugyfel = $talalt_ugyfel->fetch_assoc();

    }
    else{

        header("Location: login.php");

    }


?>

<h1>Ügyfél: <?= $ugyfel['name']; ?></h1>

<a href="kerelmek.php">Fizetési kérelmek</a>

<hr>

<?php 

    $lekerdezes = "SELECT * FROM szamlak WHERE ugyfelid=$ugyfel[id] AND allapot='aktiv'";
    $talalt_szamlak = $conn->query($lekerdezes);
    while($szamla = $talalt_szamlak->fetch_assoc()){
    
        echo "<a href='szamla.php?szamlaid=".$szamla['id']."'>".$szamla['szamlaszam']." - ".$szamla['egyenleg']." Ft</a><br>";

    }

?>