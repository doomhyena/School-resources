<?php 

	require "config.php";
	
	if(isset($_POST['login-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_felhasznalo) == 1){
			
			$felhasznalo = $talalt_felhasznalo->fetch_assoc();
			
			if(password_verify($_POST['password'], $felhasznalo['password'])){
				
				setcookie("id", $felhasznalo['id'], time() + 3600, "/");
				
				header("Location: index.php");
				
			}
			else{
				echo "<script>alert('Hibás jelszó!')</script>";
			}
			
		}
		else{
			echo "<script>alert('Nincs ilyen felhasználó!')</script>";
		}
		
	}

?>

<form method="post">

	<input type="email" name="email" placeholder="Email">
	
	<br><br>
	
	<input type="password" name="password" placeholder="Jelszó">
	
	<br><br>
	
	<input type="submit" name="login-btn" value="Bejelentkezés">

</form>