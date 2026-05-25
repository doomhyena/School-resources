<?php 

	$conn = new mysqli("localhost", "root", "", "2025_14a_reg");
	
	if($conn->connect_error){
		die("Connection failed! ".$conn->connect_error);
	}


?>