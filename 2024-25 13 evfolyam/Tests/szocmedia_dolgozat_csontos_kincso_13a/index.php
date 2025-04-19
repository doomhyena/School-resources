<?php

    require_once('cgf.php');
	session_start();
	
	if(!isset($_SESSION['id'])){
		
		header("Location: reg.php");
		
	} else {
		
		$id = $_SESSION['id'];
		
		$lekerdezes = "SELECT * FROM users WHERE id=$id";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		$felhasznalo = $talalt_felhasznalo->fetch_assoc();
		
		echo "<h1>Üdv, $felhasznalo[username]!</h1>";

    }
?>