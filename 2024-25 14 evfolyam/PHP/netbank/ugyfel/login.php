<?php 

    require "config.php";

    require "functions.php";

    // Ügyfél felhasználó
    // azonosító: 13590765
    // jelszó: test

    if(isset($_POST['login-btn'])){

        $lekerdezes = "SELECT * FROM ugyfel_users WHERE netbankid='$_POST[azonosito]'";
        $talalt_ugyfek = $conn->query($lekerdezes);

        if(mysqli_num_rows($talalt_ugyfek) > 0){

            $ugyfel = $talalt_ugyfek->fetch_assoc();

            if(password_verify($_POST['password'], $ugyfel['password'])){

                setcookie("id", $ugyfel['id'], time()+3600, "/");

                header("Location: index.php");

            }
            else{

                Message("Helytelen jelszó!");

            }

        }
        else{

            Message("Nem találtunk ilyen azonosítót!");

        }

    }

?>


<?php 

    $lekerdezes = "SELECT * FROM karbantartas";
    $talalt_karbantartas = $conn->query($lekerdezes);
    $karbantartas = $talalt_karbantartas->fetch_assoc();

    if($karbantartas['allapot'] == 'karbantartas'){

        echo "Az oldal jelenleg karbantartás alatt van, próbálkozz újra később!";

    }
    else{
?>

<h1>Ügyfél bejelentkezés</h1>

<form method="post" action="login.php">

    <input type='text' name="azonosito" placeholder="Azonosító">

    <br><br>

    <input type='password' name="password" placeholder="Jelszó">

    <br><br>

    <input type='submit' name="login-btn" value="Bejelentkezés">

</form>

<?php } ?>