<?php 

	$conn = new mysqli("localhost", "root", "", "2024_a13_gyakorlas");

	if($conn->connect_error){
		die("Sikertelen kapcsolódás! ".$conn->connect_error);
	}

?>