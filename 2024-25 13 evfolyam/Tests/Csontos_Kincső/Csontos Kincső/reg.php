<?php

    require "config.php";

    if(!isset($_POST['reg-btn'])){

        $username = $_POST['username'];
        $password = $_POST['password'];
        $password2 = $_POST['password2'];

        $lekerdezes = "SELECT * FROM users WHERE username='$username'";
        $talalt_felhasznalo = $conn->query($lekerdezes);

        if(mysqli_num_rows($talalt_felhasznalo) == 0){
            
            if($password == $password2){
                
                $conn->query("INSERT INTO users VALUES(id, '$username', '$password')");
                $mappa = getcwd();
                $eleresi_ut = $mappa."\\users\\".$username;
                if(mkdir($eleresi_ut, 0777)){
                    echo "Tárhely sikeresen létrehozva!";
                } else {
                    echo "Nem sikerült létrehozni a tárhelyet!";
                }                
            } else {
                
                echo "A jelszavak nem egyeznek!";
                
            }
            
        } else {
            
            echo "Már van ilyen nevű felhasználó!";
            
        }


    }


?>

<!DOCTYPE html>
<html>
   <head>
       <title>Regisztráció</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Csontos Kincső'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
       <h1>Regisztráció</h1>
       <form method="post">
           <input type="text" name="username" placeholder="Felhasználó">
           <br><br>
           <input type="password" name="password" placeholder="Jelszó">
           <br><br>
           <input type="password" name="password2" placeholder="Jelszó mégegyszer">
           <br><br>
           <input type="submit" name="reg-btn" value="Regisztrálok!">
       </form>
       <a href="login.php">Bejelentkezés</a>
   </body>
</html>