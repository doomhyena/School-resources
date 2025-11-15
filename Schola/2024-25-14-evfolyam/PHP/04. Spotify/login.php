<?php 

    require "config.php";

    // REGISZTRÁCIÓ
    if(isset($_POST['regist-btn'])){

        $lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
        $talalt_email = $conn->query($lekerdezes);

        if(mysqli_num_rows($talalt_email) == 0){

            if($_POST['pass1'] == $_POST['pass2']){

                $titkositott_jelszo = password_hash($_POST['pass1'], PASSWORD_DEFAULT);

                $conn->query("INSERT INTO users VALUES(id, '$_POST[email]', '$_POST[username]', '$titkositott_jelszo')");

                $lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
                $talalt_felhasznalo = $conn->query($lekerdezes);
                $felhasznalo = $talalt_felhasznalo->fetch_assoc();

                setcookie("id", $felhasznalo['id'], time()+3600, "/");

                header("Location: index.php");

            }
            else{

                echo "<script>alert('A jelszaval nem egyeznek!')</script>";

            }

        }
        else{

            echo "<script>alert('Ez az email cím már foglalt!')</script>";

        }

    }

    // BEJELENTKEZÉS
    if(isset($_POST['login-btn'])){

        $lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
        $talalt_email = $conn->query($lekerdezes);

        if(mysqli_num_rows($talalt_email) > 0){

            $felhasznalo = $talalt_email->fetch_assoc();

            if(password_verify($_POST['password'], $felhasznalo['password'])){

                setcookie("id", $felhasznalo['id'], time()+3600, "/");

                header("Location: index.php");

            }
            else{

                echo "<script>alert('Helytelen jelszó!')</script>";

            }

        }
        else{

            echo "<script>alert('Nincs ilyen felhasználó!')</script>";

        }

    }

?>
<!-- JQuery -->
<script src="http://code.jquery.com/jquery-latest.js"></script>

<!-- CONTENT -->
<h1>Bejelentkezés</h1>
<form method="post" action="login.php">
    <input name="email" type='email' placeholder="Email" require><br><br>
    <input name="password" type='password' placeholder="Jelszó" require><br><br>
    <input name="login-btn" type='submit' value="Bejelentkezem!">
</form>
<hr>
<h1>Regisztráció</h1>
<form method="post" action="login.php">
    <input id="email" name="email" type='email' placeholder="Email" require>
    <label id="emailcheck"></label><br><br>
    <input name="username" type='text' placeholder="Felhasználónév" require><br><br>
    <input name="pass1" type='password' placeholder="Jelszó" require><br><br>
    <input name="pass2" type='password' placeholder="Jelszó újra" require><br><br>
    <input name="regist-btn" type='submit' value="Regisztrálok!">
</form>
<script>

    // Email keresése
    document.getElementById("email").addEventListener('keyup', (e)=>{

        const email = e.target.value.toLowerCase();
        $("#emailcheck").load("findemail.php?keresett="+email);

    });

</script>