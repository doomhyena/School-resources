<?php 

	require "config.php";
	
	if(isset($_COOKIE['id'])){
		
		$lekerdezes = "SELECT * FROM users WHERE id=$_COOKIE[id]";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		$felhasznalo = $talalt_felhasznalo->fetch_assoc();
		
	}
	else{
		header("Location: reg.php");
	}


?>