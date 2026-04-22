<?php 
	
	$conn = new mysqli("localhost", "root", "", "2025_14b_godot");
	
	if($conn->connect_error){
		die("Sikertelen kapcsolat!".$conn->connect_error);
	}

?>