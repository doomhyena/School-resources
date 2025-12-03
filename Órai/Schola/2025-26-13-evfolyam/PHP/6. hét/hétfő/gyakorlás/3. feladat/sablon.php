<?php 

	session_start();
	
	$index = $_GET['index'];
	
	// Kiválasztott kis lista 0. és 1. elemének összehasonlítása
	if($_SESSION['lista'][$index][0] > $_SESSION['lista'][$index][1]){
		
		echo $_SESSION['lista'][$index][0]." nagyobb mint ".$_SESSION['lista'][$index][1];
		
	}
	else if($_SESSION['lista'][$index][0] < $_SESSION['lista'][$index][1]){
		
		echo $_SESSION['lista'][$index][0]." kisebb mint ".$_SESSION['lista'][$index][1];
		
	}
	else{
		echo "Egyenlőek";
	}

?>