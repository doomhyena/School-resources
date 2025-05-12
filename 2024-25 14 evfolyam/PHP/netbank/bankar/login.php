<?php 

    require "config.php";

    require "functions.php";

    // BANKÁT TEST FIÓK
    // username: test
    // password: test

    if(isset($_POST['login-btn'])){

        $lekerdezes = "SELECT * FROM bankar_users WHERE username='$_POST[username]'";
        $talalt_bankar = $conn->query($lekerdezes);

        if(mysqli_num_rows($talalt_bankar) > 0){

            $bankar = $talalt_bankar->fetch_assoc();

            if(password_verify($_POST['password'], $bankar['password'])){

                setcookie("id", $bankar['id'], time()+3600, "/");

                header("Location: index.php");

            }

        }
        else{

            Message("Nincs ilyen felhasználó!");

        }


    }
    
?>

<h1>Bankár belépés</h1>
<form method="post" action="login.php">
    <input type='text' name="username" placeholder="Felhasználónév">
    <br><br>
    <input type='password' name="password" placeholder="Jelszó">
    <br><br>
    <input type='submit' name="login-btn" value="Belépés">
</form>