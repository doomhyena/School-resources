<?php 

	session_start();

	if(isset($_POST['reg-btn'])){
		
		// A formba beírt adatokat eltároljuk egy "uj_felhasznalo" tömbben.
		$uj_felhasznalo = [$_POST['felhasznalonev'], $_POST['jelszo']];
		
		//Az "uj_felhasznalo" tömböt hozzáadjuk a "felhasznalok" session tömbhöz
		array_push($_SESSION['felhasznalok'], $uj_felhasznalo);
		
	}

?>

<form method="post">

	<input type="text" name="felhasznalonev" placeholder="Felhasználónév">
	
	<br><br>
	
	<input type="text" name="jelszo" placeholder="Jelszó">
	
	<br><br>
	
	<input type="submit" name="reg-btn" value="Regisztráció">

</form>