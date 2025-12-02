<?php 

	require "config.php";
	
	require "functions.php";
	
	session_start();
	
	if(isset($_POST['reg-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_fiok = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_fiok) == 0){
			
			if($_POST['pass1'] == $_POST['pass2']){
				
				$titkos = password_hash($_POST['pass1'], PASSWORD_DEFAULT);
				
				$conn->query("INSERT INTO users VALUES(id, '$_POST[email]', '$_POST[username]', '$titkos')");
				
				$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
				$talalt_fiok = $conn->query($lekerdezes);
				$felhasznalo = $talalt_fiok->fetch_assoc();
				
				$_SESSION['email'] = $felhasznalo['email'];
				$_SESSION['username'] = $felhasznalo['username'];
				
				setcookie("id", $felhasznalo['id'], time() + 3600, "/");
				
				header("Location: mail-reg.php");
				
			}
			else{
				Message('A jelszavak nem egyeznek!');
			}
			
		}
		else{
			Message('Az email cím foglalt!');
		}
		
	}

?>
<!DOCTYPE html>
<html lang="hu">
	<head>
		<!-- Title -->
		<title>Főoldal</title>
		
		<!-- Metas -->
		<meta charset="UTF-8">
		<meta name="description" content="Free Web tutorials">
		<meta name="keywords" content="HTML, CSS, JavaScript">
		<meta name="author" content="John Doe">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		
		<!-- CSS -->
		<link rel="stylesheet" href="css/style.css">
		
		<!-- REFRESHER -->
		<!-- <meta http-equiv="refresh" content="2"> -->
	</head>
	<body>
		
		<nav>
			<ul>
				<li><a class="menu-left" href="index.php">Oldal neve</a></li>
			</ul>
		</nav>
		
		<section id="reg">
		
			<form method="post">
				<label class="form-header">Regisztráció</label>
				<input type="email" name="email" placeholder="pelda@pelda.hu">
				<input type="text" name="username" placeholder="felhasználónév">
				<input type="password" name="pass1" placeholder="Jelszó">
				<input type="password" name="pass2" placeholder="Jelszó újra">
				<input type="submit" name="reg-btn" value="Regisztrálok!">
			</form>
		
		</section>
		
	</body>
</html>