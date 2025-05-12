<?php 

    require "config.php";

    require "functions.php";

    $lekerdezes = "SELECT * FROM szamlak WHERE id=$_GET[szamlaid]";
    $talalt_szamla = $conn->query($lekerdezes);
    $szamla = $talalt_szamla->fetch_assoc();

    // Utalás
    if(isset($_POST['send-btn'])){

        $lekerdezes = "SELECT * FROM szamlak WHERE szamlaszam='$_POST[szamlaszam]' AND allapot='aktiv'";
        $talalt_cel_szamla = $conn->query($lekerdezes);

        if(mysqli_num_rows($talalt_cel_szamla) == 1 && $_POST['szamlaszam'] != $szamla['szamlaszam']){

            $cel_szamla = $talalt_cel_szamla->fetch_assoc();

            if($szamla['egyenleg'] > $_POST['osszeg']){

                $conn->query("UPDATE szamlak SET egyenleg = egyenleg - $_POST[osszeg] WHERE id=$szamla[id]");

                $conn->query("UPDATE szamlak SET egyenleg = egyenleg + $_POST[osszeg] WHERE id=$cel_szamla[id]");

                $datum = date("Y-m-d H:i:s");

                $conn->query("INSERT INTO tranzakciok VALUES(id, '$szamla[szamlaszam]', '$cel_szamla[szamlaszam]', $_POST[osszeg], 'utalas', '$datum')");

                header("Location: szamla.php?szamlaid=$szamla[id]");

            }
            else{

                Message("Nincs elég egyenleg!");

            }

        }
        else{

            Message("Hibás számlaszám!");

        }

    }

    // Kártya letiltása

    if(isset($_POST['dis-card'])){

        $conn->query("UPDATE kartyak SET allapot='letiltva' WHERE id=$_GET[kartyaid]");

        header("Location: szamla.php?szamlaid=$_GET[szamlaid]");

    }

    // Havi költés
    $lekerdezes = "SELECT * FROM tranzakciok WHERE kuldo='$szamla[szamlaszam]'";
    $talalt_tranzakciok = $conn->query($lekerdezes);
    $osszeg = 0;
    while($tranzakcio = $talalt_tranzakciok->fetch_assoc()){
    
        if(date("Y-m", strtotime($tranzakcio['idopont']) == date("Y-m"))){

            $osszeg -= $tranzakcio['osszeg'];          

        }

    }

?>

<h2><?= $szamla['szamlaszam']?></h2>

<h3>Egyenleg: <?= $szamla['egyenleg']; ?> Ft</h3>

<h3>Havi költés: <?= $osszeg; ?> Ft</h3>

<hr>

    <form method="post" action="szamla.php?szamlaid=<?= $_GET['szamlaid']; ?>">
    
        <input type='text' name="szamlaszam" placeholder="Számlaszám">

        <input type='number' name="osszeg" placeholder="Összeg">

        <input type='submit' name="send-btn" value="Utalás">

    </form>

<hr>

<h3>Bankkártyák</h3>

<?php 

    $lekerdezes = "SELECT * FROM kartyak WHERE szamlaid=$_GET[szamlaid] AND allapot='aktiv' OR allapot='letiltva'";
    $talalt_kartyak = $conn->query($lekerdezes);
    while($kartya = $talalt_kartyak->fetch_assoc()){
    
        $ev = date("y", strtotime($kartya['lejarat']));
        $honap = date("m", strtotime($kartya['lejarat']));

        if($kartya['allapot'] == 'aktiv'){

        echo "<form method='post' action='szamla.php?szamlaid=".$_GET['szamlaid']."&kartyaid=".$kartya['id']."'>
                <label><a><b>Kártyaszám:</b> ".$kartya['kartyaszam']." <b>Típus:</b> $kartya[type] <b>Lejárat:</b> ".$honap."/".$ev."</label>
                <input type='submit' name='dis-card' value='Kártya letiltása'>
            </form>";

        }
        else if($kartya['allapot'] == 'letiltva'){

            echo "<form>
                <label><a><b>Kártyaszám:</b> ".$kartya['kartyaszam']." <b>Típus:</b> $kartya[type] <b>Lejárat:</b> ".$honap."/".$ev."</label>
                <label><b style='color: red'>LETILTVA</b></label>
            </form>";

        }
        else{

            echo "<form>
                <label><a><b>Kártyaszám:</b> ".$kartya['kartyaszam']." <b>Típus:</b> $kartya[type] <b>Lejárat:</b> ".$honap."/".$ev."</label>
                <label><b style='color: red'>TÖRÖLVE</b></label>
            </form>";

        }

    }

?>

<h3>Tranzakciók</h3>

<?php 

    $lekerdezes = "SELECT * FROM tranzakciok WHERE kuldo='$szamla[szamlaszam]' OR cel='$szamla[szamlaszam]' ORDER BY idopont DESC";
    $talalt_tranzakciok = $conn->query($lekerdezes);
    while($tranzakcio = $talalt_tranzakciok->fetch_assoc()){

        if($tranzakcio['tipus'] == "utalas"){
    
            if($tranzakcio['kuldo'] == $szamla['szamlaszam']){

                echo "<a style='color: red'><b>Típus:</b> Utalás <b>Számlaszám:</b> ".$tranzakcio['cel']." <b>Összeg:</b> -".$tranzakcio['osszeg']." Ft <b>Időpont: </b>".$tranzakcio['idopont']."</a><br>";

            }
            else{

                echo "<a style='color: green'><b>Típus:</b> Utalás <b>Számlaszám:</b> ".$tranzakcio['cel']." <b>Összeg:</b>   ".$tranzakcio['osszeg']." Ft <b>Időpont: </b>".$tranzakcio['idopont']."</a><br>";

            }

        }
        else if($tranzakcio['tipus'] == "atm"){

            echo "<a style='color: blue'><b>Típus:</b> ATM <b>Kártyaszám: </b>".$tranzakcio['cel']." <b>Összeg: </b>-".$tranzakcio['osszeg']." Ft</a><br>";

        }
        else{

            echo "<a style='color: orange'><b>Típus:</b> Online Fizetés <b>Kártyaszám: </b>".$tranzakcio['cel']." <b>Összeg: </b>-".$tranzakcio['osszeg']." Ft</a><br>";

        }

    }

?>