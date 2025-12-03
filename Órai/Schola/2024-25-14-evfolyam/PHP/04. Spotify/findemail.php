<?php 

    require "config.php";

    // Linken kapott email elmentése
    $email = $_GET['keresett'];

    // Lekérdezzük, hogy szerepel-e már ilyen email az adatbázisban
    $lekerdezes = "SELECT * FROM users WHERE email='$email'";
    $tatalt_email = $conn->query($lekerdezes);

    // Ha nem, akkor jelezzük a felhasználónak
    if(mysqli_num_rows($tatalt_email) == 0){
        echo "<a style='color: green'>Az email megfelelő!</a>";
    }
    // Ha igen, akkor jelezzük a felhasználónak
    else{
        echo "<a style='color: red'>Ez az email már foglalt!</a>";
    }

?>