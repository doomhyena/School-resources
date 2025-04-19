<?php 

	//MEGADJUK A BELÉPÉSI ADATOKAT
	$conn = new mysqli("localhost", "root", "", "schola_14a_webshop");
	
	//MEGNÉZZÜK, HOGY LEHET-E KAPCSOLÓDNI
	if($conn->connect_error){
		die("Connection failed! ".$conn->connect_error);
	}

?>