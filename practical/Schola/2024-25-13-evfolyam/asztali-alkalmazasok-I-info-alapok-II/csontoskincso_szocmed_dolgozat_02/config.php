<?php 

	$conn = new mysqli("localhost", "root", "", "013_csontoskincso_2");

	if($conn->connect_error){
		die("Sikertelen kapcsolódás! ".$conn->connect_error);
	}

?>