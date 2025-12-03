<?php 

	$conn = new mysqli("localhost", "root", "", "2025_14a_gyakorlas");
	
	if($conn->connect_error){
		die("Connection failed!".$conn->connect_error);
	}


?>