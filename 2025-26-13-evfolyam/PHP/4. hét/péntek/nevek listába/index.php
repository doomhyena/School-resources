<?php 

	session_start();
	
	// Adat kinyerése form-ből és hozzáadása a listához
	if(isset($_POST['gomb'])){
		
		array_push($_SESSION['lista'], $_POST['szoveg']);
		
	}
	
	// HA már van session listám
	if(isset($_SESSION['lista'])){
		
		// Akkor kiírom a tartalmát
		print_r($_SESSION['lista']);
		
	}
	// Ellenkező esetben / HA NINCS
	else{
		
		// Akkor létrehozom
		$_SESSION['lista'] = [];
		
	}

?>

<br><br>

<form method="post">

	<input type="text" name="szoveg" placeholder="Írj be egy nevet...">
	
	<br><br>
	
	<input type="submit" name="gomb">

</form>

<br><br>

<a href="torles.php">Törlés oldal</a>

<br><br>

<a href="nevsor.php">Névsor oldal</a>