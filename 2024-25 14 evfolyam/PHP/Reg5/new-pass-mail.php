<?php 

	require "config.php";
	
	require "functions.php";
	
	$kinek = $_GET['email'];
	$targy = "Új jelszó";
	
	$lekerdezes = "SELECT * FROM users WHERE email='$kinek'";
	$talalt_felhasznalo = $conn->query($lekerdezes);
	$felhasznalo = $talalt_felhasznalo->fetch_assoc();
	
	$code = CodeChecker();
	$conn->query("INSERT INTO codes VALUES(id, $felhasznalo[id], '$code', 0)");
	
	$uzenet = "<h2>Új jelszó kérelem</h2>
				<br><br>
				A következő linkre kattintva tudod megváltoztatni a jelszavadat: <a href='localhost/14a/Reg5/change-pass.php?code=$code'>Jelszó megváltoztatása</a>";
	
	$fejlec = "From: Reg5 oldal"."\r\n";
	$fejlec .= "MIME-Version: 1.0"."\r\n";
	$fejlec .= "Content-type: text/html; charset=UTF-8"."\r\n";
	
	if(mail($kinek, $targy, $uzenet, $fejlec)){
		header("Location: login.php");
	}
	else{
		Message("Valami hiba történt, próbálkozz újra!");
	}

?>