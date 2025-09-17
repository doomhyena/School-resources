<?php

    require "assets/db/db.php";

    if(isset($_POST['reg-btn'])) {
        $username = $_POST['username'];
        $email = $_POST['email'];
        $password = $_POST['password'];
        $password2 = $_POST['password2'];

        $founded_user = $conn->query("SELECT * FROM users WHERE username='$username'");

        if(mysql_num_rows($founded_user) > 0) {
            echo "Ilyen felhasználónév már létezik!";
        } else if($email == $founded_user['email']) {
            echo "Ilyen email cím már létezik!";
        } else if($password != $password2) {
            echo "A jelszavak nem egyeznek!";
        } else {
            $folder = getcwd();
            $elereresi_ut = $folder."/users/".$username;
            mkdir($elereresi_ut);

            $hashed_password = password_hash($password, PASSWORD_DEFAULT);
            $insert_sql = "INSERT INTO users (username, email, password) VALUES ($username, $email, $hashed_password)";
            echo "Sikeres regisztráció!";
            $conn->query($insert_sql);
        }
    }

    if(isset($_POST['login-btn'])) {
        $email = $_POST['email'];
        $password = $_POST['password0'];

        $sql = "SELECT * FROM users WHERE email = $email";
        $founded_user = $conn->query($sql);

        if(mysql_num_rows($founded_user) == 1) {
            $user = $founded_user->fetch_assoc();
            if(password_verify($pasword, $user['password'])) {
                setcookie("id", $user['id'], time() + 3600, "/");
                header("Location: index.php");
            } else {
                echo "<script>Hibás jelszó!</script>";
            }
        } else {    
            echo "<script>Nincs ilyen email cím regisztrálva!</script>";
        }
    }

?>

<!DOCTYPE html>
<html lang='hu'>
   <head>
       <title>Reglog</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Neved'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
    <!-- Reg -->
    <h1>Regisztráció</h1>
    <form method="POST">
        <label>Felhasználónév:</label>
        <input type="text" name="username" required>
        <br>
        <label>Email:</label>
        <input type="email" name="email" required>
        <br>        
        <label>Jelszó:</label>
        <input type="password" name="password" required>
        <br>
        <label>Jelszó újra:</label>
        <input type="password" name="password2" required>
        <button type="submit" name="reg-btn">Regisztráció</button>
    </form>
    <!-- Log -->
    <h1>Bejelentkezés</h1>
    <form method="POST">
        <label>Email:</label>
        <input type="email" name="email" required>
        <br>    
        <label>Jelszó:</label>
        <input type="password" name="password0" required>
        <br>
        <button type="submit" name="login-btn">Bejelentkezés</button>
    </form>
   </body>
</html>