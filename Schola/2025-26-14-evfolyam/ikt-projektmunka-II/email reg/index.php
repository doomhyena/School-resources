<?php 

	if(!isset($_COOKIE['id'])){
		header("Location: reg.php");
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
				<li><a class="menu-left" href="index.php">Főoldal</a></li>
				<li><a class="menu-right" href="logout.php">Kijelentkezés</a></li>
			</ul>
		</nav>
		
	</body>
</html>