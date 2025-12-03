<?php 

	$conn = new mysqli("localhost", "root", "", "a13_gyakorlas");
	
	if($conn->connect_error){
		echo "Sikertelen kapcsolódás! ".$conn->connect_error;
	}

?>