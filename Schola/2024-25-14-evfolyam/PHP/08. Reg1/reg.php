<?php 

	require "config.php";

	require "functions.php";
	
	if(isset($_POST['reg-btn'])){
		
		// Lekérdezzük, hogy volt-e már regisztrálva a megadott email cím
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_email = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_email) == 0){
			
			// Megvizsgáljuk, hogy egyezik-e a két beírt jelszó
			if($_POST['pass1'] == $_POST['pass2']){
				
				$titkositott_jelszo = password_hash($_POST['pass1'], PASSWORD_DEFAULT);
				
				$conn->query("INSERT INTO users VALUES(id, '$_POST[email]', '$_POST[username]', '$titkositott_jelszo', 'not active')");
				
				header("Location: login.php");
				
			}
			else{
				
				Message("A jelszavak nem egyeznek!");
				
			}
			
		}
		else{
			
			Message("Ez az email cím már foglalt!");
			
		}
		
		
	}

?>

<h1>Regisztráció</h1>

<form method="post">

	<input type="email" name="email" placeholder="Email címed">
	
	<br><br>
	
	<input type="text" name="username" placeholder="Felhasználónév">
	
	<br><br>
	
	<input type="password" name="pass1" placeholder="Jelszó">
	
	<br><br>
	
	<input type="password" name="pass2" placeholder="Jelszó újra">
	
	<br><br>
	
	<input type="submit" name="reg-btn" value="Regisztrálok!">

</form>

<br><br>

<a>Már van fiókod?</a> <a href="login.php">Jelentkezz be!</a>