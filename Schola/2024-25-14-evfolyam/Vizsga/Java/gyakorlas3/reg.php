<?php 

	require "config.php";
	
	if(isset($_POST['reg-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_felhasznalo) == 0){
			
			if($_POST['pass1'] == $_POST['pass2']){
				
				$titkositott = password_hash($_POST['pass1'], PASSWORD_DEFAULT);
				
				$conn->query("INSERT INTO users VALUES(id, '$_POST[email]', '$_POST[username]', '$titkositott')");
				
				header("Location: login.php");
				
			}
			else{
				echo "<script>alert('A jelszavak nem egyeznek!')</script>";
			}
			
		}
		else{
			echo "<script>alert('Az email cím már foglalt!')</script>";
		}
		
	}

?>

<form method="post">

	<input type="email" name="email" placeholder="Email">
	
	<br><br>

	<input type="text" name="username" placeholder="Felhasználónév">
	
	<br><br>

	<input type="password" name="pass1" placeholder="Jelszó">
	
	<br><br>

	<input type="password" name="pass2" placeholder="Jelszó újra">
	
	<br><br>

	<input type="submit" name="reg-btn" value="Regisztráció">

</form>