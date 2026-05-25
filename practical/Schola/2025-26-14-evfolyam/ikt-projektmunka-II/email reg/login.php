<?php 

	require "config.php";
	
	require "functions.php";
	
	session_start();
	
	if(isset($_POST['login-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_fiok = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_fiok) == 1){
			
			$felhasznalo = $talalt_fiok->fetch_assoc();
			
			if(password_verify($_POST['password'], $felhasznalo['password'])){
				
				// setcookie("id", $felhasznalo['id'], time() + 3600, "/");
				
				$_SESSION['id'] = $felhasznalo['id'];
				$_SESSION['email'] = $felhasznalo['email'];
				$_SESSION['username'] = $felhasznalo['username'];
				
				header("Location: mail-login.php");
				
			}
			else{
				Message("Helytelen jelszó!");
			}
			
		}
		else{
			Message("Nincs ilyen fiók!");
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
				<label class="form-header">Bejelentkezés</label>
				<input type="email" name="email" placeholder="pelda@pelda.hu">
				<input type="password" name="password" placeholder="Jelszó">
				<label class="forgot-pass"><a href="forgot-pass.php">Elfelejtettem a jelszavamat</a></label>
				<input type="submit" name="login-btn" value="Bejelentkezem!">
				<label class="form-link1">Még nincs fiókod?</label>
				<label class="form-link2"><a href="login.php">Regisztrálj!</label>
			</form>
		
		</section>
		
	</body>
</html>