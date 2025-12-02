<?php 

	require "config.php";
	
	require "functions.php";
	
	session_start();
	
	if(isset($_POST['pass-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_fiok = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_fiok) == 1){
			
			$felhasznalo = $talalt_fiok->fetch_assoc();
			
			$lekerdezes = "SELECT * FROM codes WHERE userid=$felhasznalo[id] AND used=0";
			$talalt_kodok = $conn->query($lekerdezes);
			
			if(mysqli_num_rows($talalt_kodok) == 0){
		
				$_SESSION['id'] = $felhasznalo['id'];
				$_SESSION['email'] = $felhasznalo['email'];
				$_SESSION['username'] = $felhasznalo['username'];
				
				header("Location: mail-forgot-pass.php");
			
			}
			else{
				Message("Már kértél jelszó változtató linket!");
			}
		
		}
		else{
			Message("Nem találtunk fiókot ilyen email címmel.");
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
				<label class="form-header">Elfelejtett jelszó</label>
				<input type="email" name="email" placeholder="pelda@pelda.hu">
				<input type="submit" name="pass-btn" value="Link igénylése" style="margin-bottom: 0 !important;">
			</form>
		
		</section>
		
	</body>
</html>