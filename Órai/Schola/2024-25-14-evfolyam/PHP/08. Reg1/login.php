<?php 

	require "config.php";
	
	require "functions.php";
	
	if(isset($_POST['login-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_felhasznalo) == 1){
			
			$felhasznalo = $talalt_felhasznalo->fetch_assoc();
			
			// Jelszó vizsgálat
			if(password_verify($_POST['password'], $felhasznalo['password'])){
				
				// Felhasználó aktiválása
				if($felhasznalo['status'] == "not active"){
					
					$conn->query("UPDATE users SET status='active' WHERE id=$felhasznalo[id]");
					
				}
				
				// Bejelentkezés
				setcookie("id", $felhasznalo['id'], time()+3600, "/");
				
				header("Location: index.php");
				
				
			}
			else{
				
				Message("Helytelen jelszó");
				
			}
			
		}
		else{
			
			Message("Nincs ilyen email cím");
			
		}
		
	}

?>

<h1>Bejelentkezés</h1>

<form method="post">

	<input type="email" name="email" placeholder="Email címed">
	
	<br><br>
	
	<input type="password" name="password" placeholder="Jelszó">
	
	<br><br>
	
	<input type="submit" name="login-btn" value="Bejelentkezem!">

</form>

<br><br>

<a>Még nincs fiókod?</a> <a href="reg.php">Regisztrálj!</a>