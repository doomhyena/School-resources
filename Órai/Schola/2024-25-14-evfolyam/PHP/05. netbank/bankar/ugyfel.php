<?php 

    require "config.php";

    require "functions.php";

    $lekerdezes = "SELECT * FROM ugyfel_users WHERE netbankid='$_GET[netbankid]'";
    $talalt_ugyfel = $conn->query($lekerdezes);
    $ugyfel = $talalt_ugyfel->fetch_assoc();

    // Új számla
    if(isset($_POST["new-sz"])){

        ujSzamla($ugyfel['id']);

    }

    // Összeg feltöltése
    if(isset($_POST['add-m'])){

        $conn->query("UPDATE szamlak SET egyenleg=egyenleg+$_POST[osszeg] WHERE id=$_GET[szamlaid]");

        header("Location: ugyfel.php?netbankid=$_GET[netbankid]");

    }

    // Új kártya
    if(isset($_POST['new-card'])){

        if(strlen($_POST['pin']) == 4){
        
            UjKartya($_GET['szamlaid'], $_POST['pin'], $_POST['card-type']);

            header("Location: ugyfel.php?netbankid=$_GET[netbankid]");

        }
        else{

            Message("Helytelen PIN kód!");

        }

    }

    // Kártya letiltása
    if(isset($_POST['dis-card'])){

        $conn->query("UPDATE kartyak SET allapot='letiltva' WHERE id=$_GET[kartyaid]");

        header("Location: ugyfel.php?netbankid=$_GET[netbankid]");

    }

    // Kártya törlése
    if(isset($_POST['del-card'])){

        $conn->query("UPDATE kartyak SET allapot='torolve' WHERE id=$_GET[kartyaid]");

        header("Location: ugyfel.php?netbankid=$_GET[netbankid]");

    }

    // Számla törlése
    if(isset($_POST['del-sz'])){

        $conn->query("UPDATE szamlak SET allapot='torolve' WHERE id=$_GET[szamlaid]");

        $conn->query("UPDATE kartyak SET allapot='torolve' WHERE szamlaid=$_GET[szamlaid]");

    }

?>
<h1>Ügyfél: <?= $ugyfel['name']; ?></h1>
<hr>
<form method="post" action="ugyfel.php?netbankid=<?= $_GET['netbankid']; ?>">
    <input type='submit' name="new-sz" value="+ Új számla">
</form>
<hr>
<h3>Számlák</h3>
<?php 

    $lekerdezes = "SELECT * FROM szamlak WHERE ugyfelid=$ugyfel[id]";
    $talalt_szamlak = $conn->query($lekerdezes);
    while($szamla = $talalt_szamlak->fetch_assoc()){

        if($szamla['allapot'] == 'aktiv'){
    
            echo "<form method='post' action='ugyfel.php?netbankid=".$_GET['netbankid']."&szamlaid=$szamla[id]'>
                    <label>".$szamla['szamlaszam']." - ".$szamla['egyenleg']." Ft</label>
                    <input type='number' name='osszeg' placeholder='osszeg'>
                    <input type='submit' name='add-m' value='Feltöltés'>
                    <input type='password' name='pin' placeholder='PIN'>
                    <select name='card-type'>
                        <option value='mc'>MasterCard</option>
                        <option value='v'>Visa</option>
                    </select>
                    <input type='submit' name='new-card' value='+ Új bankkártya'>
                    <input style='color: white; background: red; padding: 3px; border: none; border-radius: 3px;' type='submit' name='del-sz' value='Számla törlése'>
            </form>";

        }
        else{

            echo "<form method='post' action='ugyfel.php?netbankid=".$_GET['netbankid']."&szamlaid=$szamla[id]'>
                    <label>".$szamla['szamlaszam']." - ".$szamla['egyenleg']." Ft</label>
                   <label><b style='color: red'>TÖRÖLVE</b></label>
            </form>";

        }

        $lekerdezes = "SELECT * FROM kartyak WHERE szamlaid=$szamla[id]";
        $talalt_kartyak = $conn->query($lekerdezes);
        while($kartya= $talalt_kartyak->fetch_assoc()){

            if($kartya['allapot'] == 'aktiv'){

                echo "<form style='margin-left: 50px;' method='post' action='ugyfel.php?netbankid=$_GET[netbankid]&kartyaid=$kartya[id]'>
                        <label>Kártyaszám: $kartya[kartyaszam] Típus: $kartya[type] </label>
                        <input type='submit' name='dis-card' value='Kártya letiltása'>
                        <input style='color: white; background: red; padding: 3px; border: none; border-radius: 3px;' type='submit' name='del-card' value='Kártya törlése'>
                </form>";

            }
            else if($kartya['allapot'] == 'letiltva'){

                echo "<form style='margin-left: 50px;' method='post' action='ugyfel.php?netbankid=$_GET[netbankid]&kartyaid=$kartya[id]'>
                        <label>Kártyaszám: $kartya[kartyaszam] Típus: $kartya[type] </label>
                        <label><b style='color: red;'>LETILTVA</b></label>
                        <input style='color: white; background: red; padding: 3px; border: none; border-radius: 3px;' type='submit' name='del-card' value='Kártya törlése'>
                    </form>";

            }
            else{

                echo "<form style='margin-left: 50px;' method='post' action='ugyfel.php?netbankid=$_GET[netbankid]&kartyaid=$kartya[id]'>
                        <label>Kártyaszám: $kartya[kartyaszam]</label>
                        <label><b style='color: red;'>TÖRÖLVE</b></label>
                    </form>";

            }
        
        }

    }

?>