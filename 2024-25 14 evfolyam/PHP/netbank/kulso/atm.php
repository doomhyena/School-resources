<?php 

    require "config.php";

    require "functions.php";

    if(isset($_POST['cash-btn'])){

        if($_POST['osszeg'] > 0){

            $lekerdezes = "SELECT * FROM kartyak WHERE kartyaszam='$_POST[kartyaszam]'";
            $talalt_kartya = $conn->query($lekerdezes);

            if(mysqli_num_rows($talalt_kartya) == 1){

                $kartya = $talalt_kartya->fetch_assoc();

                if(password_verify($_POST['pin'], $kartya['pin'])){

                    if($kartya['allapot'] == 'aktiv'){

                        if($kartya['lejarat'] > date("Y-m-d")){

                            $lekerdezes = "SELECT * FROM szamlak WHERE id=$kartya[szamlaid]";
                            $talalt_szamla = $conn->query($lekerdezes);

                            if(mysqli_num_rows($talalt_szamla) > 0){
                                $szamla = $talalt_szamla->fetch_assoc();

                                if($szamla['egyenleg'] >= $_POST['osszeg']){

                                    $conn->query("UPDATE szamlak SET egyenleg = egyenleg - $_POST[osszeg] WHERE id=$szamla[id]");

                                    $datum = date("Y-m-d H:i:s");

                                    $conn->query("INSERT INTO tranzakciok VALUES(id, '$szamla[szamlaszam]', '$_POST[kartyaszam]', $_POST[osszeg], 'atm', '$datum')");

                                    Message("Sikeresen felvettél $_POST[osszeg] Ft-ot!");

                                }
                                else{

                                    Message("Nincs elegendő fedezet!");

                                }
                            }
                            else{

                                Message("A kártyához tatozó számla megszűnt!");

                            }

                        }
                        else{

                            Message("A kártya lejárt!");

                        }

                    }
                    else{

                        Message("A kártya le van tiltva!");

                    }

                }
                else{

                    Message("Érvénytelen PIN kód!");

                }

            }
            else{

                Message("Helytelen kártyaszám!");

            }

        }
        else{

            Message("Érvénytelen összeg!");

        }

    }

?>

<h1>ATM</h1>

<form method="post" action="atm.php">

    <input type='number' name="osszeg" placeholder="Összeg">

    <br><br>

    <input type='text' name="kartyaszam" placeholder="0000-0000-0000-0000">

    <br><br>

    <input type='password' name="pin" placeholder="PIN">

    <br><br>

    <input type='submit' name="cash-btn" value="Pénz felvétele">

</form>