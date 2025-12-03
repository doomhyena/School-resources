<?php 

    require "config.php";

    require "functions.php";

    if(isset($_COOKIE['id'])){

        $lekerdezes = "SELECT * FROM bankar_users WHERE id=$_COOKIE[id]";
        $talalt_bankar = $conn->query($lekerdezes);
        $bankar = $talalt_bankar->fetch_assoc();

    }
    else{

        header("Location: login.php");

    }

    // Új ügyfél
    if(isset($_POST['new-c'])){

        $netbankid = netbankId();

        $titkositott_jelszo = password_hash($_POST['password'], PASSWORD_DEFAULT);

        $conn->query("INSERT INTO ugyfel_users VALUES(id, $netbankid, '$titkositott_jelszo', '$_POST[name]')");

        Message("Új ügyfél azonosítója: $netbankid");
    
    }

?>
<head>
    <!-- JQuery -->
    <script src="http://code.jquery.com/jquery-latest.js"></script>
</head>

<h1>BANKÁR: <?= $bankar['name']; ?></h1>
<hr>
    <form method="post" action="index.php">
        <input type='text' name="name" placeholder="Ügyfél neve">
        <input type='password' name="password" placeholder="Jelszó">
        <input type='submit' name="new-c" value="+ Új ügyfél">
    </form>
<hr>
<input type="number" id="kereso" placeholder="Ügyfél keresése">
<hr>
<div id="ugyfelek"></div>

<script>

    $("#ugyfelek").load("findugyfel.php?keresett=");

    document.getElementById("kereso").addEventListener('keyup', (e)=>{

        const adat = e.target.value;

        $("#ugyfelek").load("findugyfel.php?keresett="+adat);

    });

</script>