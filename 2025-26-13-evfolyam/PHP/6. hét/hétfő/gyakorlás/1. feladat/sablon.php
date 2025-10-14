<?php 

	session_start();
	
	// Érték lementése a linkből
	$index = $_GET['index'];
	
	// Kiírás
	echo "A lista $index. indexű eleme: ".$_SESSION['lista'][$index];

?>