<?php 

	session_start();
	
	// Létezik-e a változó vizsgálat
	if(isset($_SESSION['felhasznalok'])){
		
		echo "Regisztrált felhasználók száma: ".count($_SESSION['felhasznalok']);
		
	}
	else{
		
		$_SESSION['felhasznalok'] = [];
		
	}
	
	echo "<br><br>";
	
	// Megvizsgáljuk, hogy bejelentkezett-e valaki
	if(isset($_SESSION['bejelentkezett'])){
		echo "Üdv, $_SESSION[bejelentkezett]!";
	}
	
	// echo "<br><br>";
	// print_r($_SESSION['felhasznalok']);

?>
<br><br>
<a href="reg.php">Regisztráció</a> / 
<a href="login.php">Bejelentkezés</a>