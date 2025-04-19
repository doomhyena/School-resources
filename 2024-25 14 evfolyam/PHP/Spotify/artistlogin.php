<?php 

    require "config.php";

    // TEST ARTIST
    // username: test
    // password: testpass

    // BEJELENTKEZÉS
    if(isset($_POST['login-btn'])){

        // Lekérdezzük, hogy van-e olyan fiók, amibe be akarnak lépni
        $lekerdezes = "SELECT * FROM artists WHERE name='$_POST[username]'";
        $talalt_felhasznalo = $conn->query($lekerdezes);

        // Ha találunk -> Bejelentkezés
        if(mysqli_num_rows($talalt_felhasznalo) > 0){

            $felhasznalo = $talalt_felhasznalo->fetch_assoc();

            // Megvizsgáljuk, hogy helyes jelszót írtak-e be
            if(password_verify($_POST['password'], $felhasznalo['password'])){

                setcookie("artistid", $felhasznalo['id'], time()+3600, "/");

                header("Location: artist.php");

            }
            // Ha nem -> Hibaüzenet
            else{

                echo "<script>alert('A jelszó helytelen!')</script>";

            }

        }
        // Ha nem -> Hibaüzenet
        else{

            echo "<script>alert('Nincs ilyen felhasználó!')</script>";

        }

        

    }

?>
<form method="post" action="artistlogin.php">
    <input name="username" type='text' placeholder="Felhasználónév" required><br><br>
    <input name="password" type='password' placeholder="Jelszó" required><br><br>
    <input name="login-btn" type='submit' value="Belépek!">
</form>