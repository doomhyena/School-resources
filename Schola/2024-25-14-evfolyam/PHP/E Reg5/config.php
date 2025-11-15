<?php 

	$conn = new mysqli("localhost", "root", "", "schola_14a_reg5");
	
	if($conn->connect_error){
		echo "Sikertelen kapcsolódás! ".$conn->connect_error;
	}

?>