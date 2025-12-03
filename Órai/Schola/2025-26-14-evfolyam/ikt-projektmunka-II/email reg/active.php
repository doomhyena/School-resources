<?php 

	require "config.php";
	
	require "functions.php";
	
	session_start();
	
	if(isset($_POST['login-btn'])){
		
		$lekerdezes = "SELECT * FROM logincode WHERE userid=$_SESSION[id] AND code='$_POST[code]' ANd used=0";
		$talalt_kod = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_kod) == 1){
			
			$conn->query("UPDATE logincode SET used=1 WHERE userid=$_SESSION[id] AND code='$_POST[code]'");
			
			$conn->query("DELETE FROM logincode WHERE userid=$_SESSION[id] AND used=0");
			
			setcookie("id", $_SESSION['id'], time()+3600, "/");
			
			session_destroy();
			
			header("Location: index.php");
			
		}
		else{
			Message("Sikertelen bejelentkezés!");
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
				<label style="margin-bottom: 20px;display: block;">Add meg az emailben kapott 6 számjegyű kódot!</label>
				<input type="text" name="code" placeholder="123456" style="text-align: center;">
				<input type="submit" name="login-btn" value="Bejelentkezés" style="margin-bottom: 0 !important;">
			</form>
		
		</section>
		
	</body>
</html>