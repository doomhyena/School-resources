<?php 

	session_start();
	// Lista létrehozása a felhasználóknak
	if(!isset($_SESSION['lista'])){
		$_SESSION['lista'] = [];
	}

	// Új felhasználó adatainak elmentése
	if(isset($_POST['reg-gomb'])){
		
		// Új felhasználó létrehozása
		$user = ["username" => $_POST['felhnev'], "password" => $_POST['jelszo']];
		
		// Új felhasználó hozzáadása a listához
		array_push($_SESSION['lista'], $user);
		
		print_r($_SESSION['lista']);
		
	}
	print_r($_SESSION['lista']);

?>

<form method="post">

	<input type="text" name="felhnev" placeholder="Felhasználónév">
	
	<br><br>
	
	<input type="text" name="jelszo" placeholder="Jelszó">
	
	<br><br>
	
	<input type="submit" name="reg-gomb">

</form>