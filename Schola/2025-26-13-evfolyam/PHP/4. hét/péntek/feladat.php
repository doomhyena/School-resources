<?php 
	
	// Feladat:
	
	// Készíts egy formot egy text mezővel és egy gombbal.
		
	// A form elküldése után add hozzá az inputba beírt adatot egy session listához.
		
	session_start();
	
	if(isset($_POST['gomb'])){
		array_push($_SESSION['lista'], $_POST['szoveg']);
	}
	
	if(isset($_SESSION['lista'])){
		print_r($_SESSION['lista']);
	}
	else{
		$_SESSION['lista'] = [];
	}
		
?>

<form method="post">

	<input type="text" name="szoveg" placeholder="Szöveg">
	
	<input type="submit" name="gomb">

</form>