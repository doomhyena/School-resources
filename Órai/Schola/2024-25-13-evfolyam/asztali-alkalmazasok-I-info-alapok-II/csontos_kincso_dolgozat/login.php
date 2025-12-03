<?php

    session_start();

    if(isset($_POST['login-btn'])){
        for ($i = 0; $i < count($_SESSION['felhasznalok']); $i++) {
            if ($_SESSION['felhasznalok'][$i]['nev'] == $_POST['nev']) {
                if ($_SESSION['felhasznalok'][$i]['jelszo'] == $_POST['jelszo']) {
                    header("Location: index.php");
                }
            } else {
                echo "Hibás felhasználónev vagy jelszó!";
            }
        }
    }

?>

<h1>Bejelentkezés</h1>

<form method="post">
	<input type="text" name="username" placeholder="Felhasználónév">	
	<input type="text" name="password" placeholder="Jelszó">
	<input type="submit" name="rlgoin-btn" value="Regisztráció">

</form>

<a href="reg.php">Nincs fiókod? Regisztrálj!</a>