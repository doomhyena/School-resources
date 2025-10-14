<?php 

	session_start();
	
	// Bejelentkezés
	if(isset($_POST['login-btn'])){
		
		// Végigmegyünk a felhasználók tömbbön
		for($i=0;$i<count($_SESSION['felhasznalok']);$i++){
			
			//print_r($_SESSION['felhasznalok'][$i]);
			// 0. index: Felhasználónév
			// 1. index: Jelszó
			
			// Minden belső tömb 0. indexét megnézi, hogy egyezik-e a formba beírt felhasználónévvel
			if($_SESSION['felhasznalok'][$i][0] == $_POST['felhasznalonev']){
				
				// Ha a felhasználónév jó, ugyanabban a listában megnézi az 1. indexű elemet, hogy megegyezik-e a felhasználó által megadott jelszóval
				if($_SESSION['felhasznalok'][$i][1] == $_POST['jelszo']){
					
					// Ha mind a két adat helyes, elmentjük a felhasználót
					$_SESSION['bejelentkezett'] = $_POST['felhasznalonev'];
					
					// Átnavigálás helyes bejelentkezés esetén az indexre
					header("Location: index.php");
					
				}
				else{
					echo "Helytelen jelszó!";
				}
				
			}
			
		}
		
	}


?>

<form method="post">

	<input type="text" name="felhasznalonev" placeholder="Felhasználónév">
	
	<br><br>
	
	<input type="text" name="jelszo" placeholder="Jelszó">
	
	<br><br>
	
	<input type="submit" name="login-btn" value="Bejelentkezés">

</form>