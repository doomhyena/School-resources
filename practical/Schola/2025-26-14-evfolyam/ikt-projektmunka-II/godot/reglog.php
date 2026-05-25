<?php 

	require "config.php";
	
	if(isset($_POST['reg-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE username='$_POST[username]'";
		$talalt = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt) == 0){
			
			if($_POST['pass1'] == $_POST['pass2']){
				
				$titkos = password_hash($_POST['pass1'], PASSWORD_DEFAULT);
				
				$conn->query("INSERT INTO users VALUES(id, '$_POST[username]', '$titkos', 0, 1)");
				
			}
			else{
				Message("A két jelszó nem egyezik!");
			}
			
		}
		else{
			Message("Már van ilyen nevű felhasználó!");
		}
		
	}
	
	function Message($text){
		echo "<script>alert('$text')</script>";
	}

?>

<h1>Regisztráció</h1>

<form method="post">
	<input type="text" name="username" placeholder="Felhasználónév"><br><br>
	<input type="password" name="pass1" placeholder="Jelszó"><br><br>
	<input type="password" name="pass2" placeholder="Jelszó újra"><br><br>
	<input type="submit" name="reg-btn" value="Regisztráció">
</form>