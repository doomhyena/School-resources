<?php 

	header('Content-Type: application/json');

	$conn = new mysqli("localhost", "root", "", "2025_14b_godot");
	
	$username = $_GET['username'];
	$password = $_GET['password'];
	
	$lekerdezes = "SELECT * FROM users WHERE username='$username'";
	$talalt = $conn->query($lekerdezes);
	
	if(mysqli_num_rows($talalt) == 1){
		
		$fiok = $talalt->fetch_assoc();
		
		if(password_verify($password, $fiok['password'])){
			
			echo json_encode($fiok);
			
		}
		else{
			$error['id'] = -2;
			echo json_encode($error);
		}
		
	}
	else{
		$error['id'] = -1;
		echo json_encode($error);
	}

?>