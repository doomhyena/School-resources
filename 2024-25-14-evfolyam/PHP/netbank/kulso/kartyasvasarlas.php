<?php 

    require "config.php";

    require "functions.php";

    if(isset($_POST['pay-btn'])){

        $lekerdezes = "SELECT * FROM kartyak WHERE kartyaszam='$_POST[number]'";
        $talalt_kartya = $conn->query($lekerdezes);

        if(mysqli_num_rows($talalt_kartya) == 1){
        
                $kartya = $talalt_kartya->fetch_assoc();

                if($kartya['allapot'] == 'aktiv'){

                    $ev = date("y", strtotime($kartya['lejarat']));

                    $honap = date("m", strtotime($kartya['lejarat']));

                    if($ev == $_POST['y'] && $honap == $_POST['m'] && $kartya['kod'] == $_POST['code']){

                        $lekerdezes = "SELECT * FROM szamlak WHERE id='$kartya[szamlaid]'";
                        $talalt_szamla = $conn->query($lekerdezes);
                        $szamla = $talalt_szamla->fetch_assoc();

                        if($szamla['allapot'] == 'aktiv'){

                            if($szamla['egyenleg'] >= $_POST['osszeg']){

                                if($kartya['type'] == 'MasterCard'){

                                    $datum = date("Y-m-d H:i:s");

                                    $conn->query("UPDATE szamlak SET egyenleg = egyenleg - $_POST[osszeg] WHERE id=$szamla[id]");

                                    $conn->query("INSERT INTO tranzakciok VALUES(id, '$szamla[szamlaszam]', '$kartya[kartyaszam]', $_POST[osszeg], 'online', '$datum')");

                                }
                                else{

                                    $conn->query("INSERT INTO kerelem VALUES(id, $szamla[ugyfelid], '$kartya[kartyaszam]', $_POST[osszeg], 'kerelem')");

                                    $lekerdezes = "SELECT * FROM kerelem WHERE ugyfelid=$szamla[ugyfelid] AND kartyaszam='$kartya[kartyaszam]' AND allapot='kerelem' ORDER BY id DESC LIMIT 1";
                                    $talalt_keres = $conn->query($lekerdezes);
                                    $keres = $talalt_keres->fetch_assoc();

                                    header("Location: fizetes.php?id=$keres[id]");

                                }

                            }
                            else{

                                Message("Nincs elég fedezet!");

                            }

                        }
                        else{

                            Message("Nem sikerült feldolgozni a fizetést!");

                        }

                    }
                    else{

                        Message("Hibás adatok!");

                    }

                }
                else{

                    Message("A kártya letiltásra került!");

                }

        }
        else{

            Message("Hibás kártyaszám!");

        }

    }

?>

<h1>Kártyás vásárlás</h1>

<form method="post" action="kartyasvasarlas.php">

    <input type="number" name="osszeg" placeholder="Összeg">
    <br><br>
    <input type="text" maxlength="19" name="number" placeholder="0000-0000-0000-0000">
    <br>
    <br>
    <input type="text" maxlength="2" name="m" placeholder="HH">
    <label> / </label>
    <input type="text" maxlength="2" name="y" placeholder="ÉÉ">
    <input style="margin-left: 20px;" type="text" name="code" placeholder='123'>
    <br><br>
    <input type="submit" name="pay-btn" value="Fizetés!">

</form>