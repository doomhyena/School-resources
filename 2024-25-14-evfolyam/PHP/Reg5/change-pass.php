<?php  

	require "config.php";
	
	require "functions.php";
	
	$code = $_GET['code'];
	
	$lekerdezes = "SELECT * FROM codes WHERE code='$code'";
	$talalt_kod = $conn->query($lekerdezes);
	
	if(mysqli_num_rows($talalt_kod) == 1){
	
		$kod = $talalt_kod->fetch_assoc();
		
		if($kod['used'] == 0){
			
			echo "<form method='post'>";
			echo "	<input type='password' name='pass1' placeholder='Jelszó'><br><br>";
			echo "	<input type='password' name='pass2' placeholder='Jelszó újra'><br><br>";
			echo "	<input type='submit' name='change-pass-btn' value='Jelszó megváltoztatása'>";
			echo "</form>";
			
		}
		else{
			
			echo "<h1>A link lejárt!</h1>";
		
			echo "<a href='index.php'>Főoldal</a>";
			
		}
	
	}
	else{
		
		echo "<h1>A link révénytelen!</h1>";
		
		echo "<a href='index.php'>Főoldal</a>";
		
	}

	if(isset($_POST['change-pass-btn'])){
		
		if($_POST['pass1'] == $_POST['pass2']){
			
			$lekerdezes = "SELECT * FROM users WHERE id=$kod[userid]";
			$talalt_felhasznalo = $conn->query($lekerdezes);
			$felhasznalo = $talalt_felhasznalo->fetch_assoc();
			
			if(!password_verify($_POST['pass1'], $felhasznalo['password'])){
				
				$titkositott_jelszo = password_hash($_POST['pass1'], PASSWORD_DEFAULT);
				
				$conn->query("UPDATE users SET password='$titkositott_jelszo' WHERE id=$felhasznalo[id]");
				
				$conn->query("UPDATE codes SET used=1 WHERE code='$code'");
				
				Message("Sikeresen megváltoztattad a jelszavadat!");
				
				echo "<a href='login.php'>Bejelentkezés</a>";
				
			}
			else{
				
				Message("Az új jelszavad nem egyezhet a régivel!");
				
			}
			
		}
		else{
			
			Message("A két jelszó nem egyezik!");
			
		}
		
	}

?>