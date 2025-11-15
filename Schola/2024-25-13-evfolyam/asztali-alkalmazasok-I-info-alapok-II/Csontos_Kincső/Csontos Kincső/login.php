<?php

    require "config.php";

    session_start();

    if(isset($_POST['login-btn'])){

        $username = $_POST['username'];
        $password = $_POST['password'];

        $lekerdezes = "SELECT * FROM users WHERE username='$username'";
        $talalt_felhasznalo = $conn->query($lekerdezes);

        if(mysqli_num_rows($talalt_felhasznalo) == 1){
        
            $felhasznalo = $talalt_felhasznalo->fetch_assoc();
        
            if($password == $felhasznalo['password']){
                
                $_SESSION['id'] = $felhasznalo['id'];
                $_SESSION['username'] = $felhasznalo['username'];
                $_SESSION['name'] = $felhasznalo['name'];
                
                header("Location: index.php");
                
            } else {
                echo "Hibás jelszó!";
            }
        } else {
            echo "Nem letezik ilyen felhasználó!";
        }
    }

?>

<!DOCTYPE html>
<html>
   <head>
       <title>Bejelentkezés</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Csontos Kincső'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
       <h1>Bejelentkezés</h1>
       <form method="post">
           <input type="text" name="username" placeholder="Felhasználónév">
           <br><br>
           <input type="password" name="password" placeholder="Jelszó">
           <br><br>
           <input type="submit" name="login-btn" value="Bejelentkezés">
       </form>
       <a href="reg.php">Regisztráció</a>
   </body>
</html>