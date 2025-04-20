<?php 

	require "config.php";
	
	//reg
	if(isset($_POST['reg-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE username='$_POST[username]'";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_felhasznalo) == 0){
			
			if($_POST['password'] == $_POST['password2']){
				
				$titkos = password_hash($_POST['password'], PASSWORD_DEFAULT);
				
				$conn->query("INSERT INTO users VALUES(id, '$_POST[username]', '$titkos', 0)");
				
			}
			else{
				echo "<script>alert('A két jelszó nem egyezik!')</script>";
			}
			
		}
		else{
			echo "<script>alert('Már van ilyen felhasználó!')</script>";
		}
		
	}
	
	// login
	if(isset($_POST['login-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE username='$_POST[username]'";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_felhasznalo) > 0){
			
			$felhasznalo = $talalt_felhasznalo->fetch_assoc();
			
			if(password_verify($_POST['password'], $felhasznalo['password'])){
				
				setcookie("id", $felhasznalo['id'], time()+3600, "/");
				
				header("Location: index.php");
				
			}
			else{
				echo "<script>alert('Hibás jelszó!')</script>";
			}
			
		}
		else{
			echo "<script>alert('Még nincs ilyen felhasználó!')</script>";
		}
		
	}

?>

<h1>reg</h1>
<form method="post">
	<input type="text" name="username" placeholder="Felhasználónév"><br>
	<input type="password" name="password" placeholder="Jelszó"><br>
	<input type="password" name="password2" placeholder="Jelszó újra"><br>
	<input type="submit" name="reg-btn" value="reg">
</form>

<h1>login</h1>
<form method="post">
	<input type="text" name="username" placeholder="Felhasználónév"><br>
	<input type="password" name="password" placeholder="Jelszó"><br>
	<input type="submit" name="login-btn" value="login">
</form>