<?php 

	require "config.php";
	
	if(isset($_POST['reg-btn'])){
		
		$username = $_POST['username'];
		$password = $_POST['password'];
		
		$lekerdezes = "SELECT * FROM users WHERE username='$username'";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_felhasznalo) == 0){
			
			$conn->query("INSERT INTO users VALUES(id, '$username', '$password')");
			
			header("Location: login.php");
			
		}
		else{
			
			echo "Már létezik ilyen felhasználó!";
			
		}
		
	}

?>

<h1>Regisztráció</h1>

<form method="post">

	<input type="text" name="username" placeholder="Felhasználónév">
	
	<br><br>
	
	<input type="password" name="password" placeholder="Jelszó">
	
	<br><br>
	
	<input type="submit" name="reg-btn" value="Regisztráció">

</form>