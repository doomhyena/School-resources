<?php 

	require "config.php";
	
	session_start();
	
	if(isset($_POST['login-btn'])){
		
		$username = $_POST['username'];
		$password = $_POST['password'];
		
		$lekerdezes = "SELECT * FROM users WHERE username='$username'";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_felhasznalo) > 0){
			
			$felhasznalo = $talalt_felhasznalo->fetch_assoc();
			
			if($felhasznalo['password'] == $password){
			
				$_SESSION['id'] = $felhasznalo['id'];
				
				header("Location: index.php");
			
			}
			else{
				
				echo "Helytelen jelszó!";
				
			}
			
		}
		else{
			
			echo "Nincs ilyen felhasználó!";
			
		}
		
	}

?>

<h1>Bejelentkezés</h1>

<form method="post">

	<input type="text" name="username" placeholder="Felhasználónév">
	
	<br><br>
	
	<input type="password" name="password" placeholder="Jelszó">
	
	<br><br>
	
	<input type="submit" name="login-btn" value="Bejelentkezés">

</form>