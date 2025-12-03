<?php 

	require "functions.php";
	
	$kinek = $_GET['email'];
	$code = $_GET['code'];
	$targy = "Sikeres regisztráció!";
	$uzenet = "<b>Sikeres regisztráció!</b>
				<br><br>
				A regisztráció érvényesítéséhez szükséged lesz a következő kódra: <b>$code</b>";
	
	$fejlec = "From: REG 4 Oldal"."\r\n";
	$fejlec .= "MIME-Version: 1.0"."\r\n";
	$fejlec .= "Content-type: text/html; charset=UTF-8"."\r\n";

	if(mail($kinek, $targy, $uzenet, $fejlec)){
		
		header("Location: login.php");
		
	}
	else{
		
		Message("Hiba történt az email küldésekor...");
		
	}

?>