<?php 

	// Változó a kapcsolódáshoz
	// Fontos adatok: localost, root, "" -> (nincs jelszó), adatbázis neve
	$conn = new mysqli("localhost", "root", "", "2025_13a_elso");
	
	// Kapcsolat ellenőrzése
	if($conn->connect_error){
		die("Sikertelen kapcsolódás! ".$conn->connect_error);
	}

?>