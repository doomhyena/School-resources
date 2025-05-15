<?php 

	session_start();
	
	if(!isset($_SESSION['felhasznalok'])){
		
		$_SESSION['felhasznalok'] = array();
		
	}
	
	if(!isset($_SESSION['felhasznalo'])){
		
		header("Location: reg.php");
		
	}
	echo "<h1>Szia, $_SESSION[felhasznalo]!</h1>";
?>