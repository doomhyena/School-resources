<?php 

	require "config.php";
	
	require "functions.php";
	
	$code = $_GET['code'];
	
	$lekerdezes = "SELECT * FROM codes WHERE code='$code'";
	$talalt_kerelem = $conn->query($lekerdezes);
	$kerelem = $talalt_kerelem->fetch_assoc();
	
	if(isset($_POST['pass-btn'])){
		
		if($_POST['pass1'] == $_POST['pass2']){
			
			$titkos = password_hash($_POST['pass1'], PASSWORD_DEFAULT);
			
			$conn->query("UPDATE users SET password='$titkos' WHERE id=$kerelem[userid]");
			
			$conn->query("UPDATE codes SET used = 1 WHERE id=$kerelem[id]");
			
			header("Location: login.php");
			
		}
		else{
			Message("A két jelszó nem egyezik!");
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
		
		<?php 
			if($kerelem['used'] == 0){
		?>
		
				<section id="reg">
				
					<form method="post">
						<label class="form-header">Jelszó megváltoztatása</label>
						<input type="password" name="pass1" placeholder="Jelszó">
						<input type="password" name="pass2" placeholder="Jelszó űjra">
						<input type="submit" name="pass-btn" value="Jelszó megváltoztatása" style="margin-bottom: 0 !important;">
					</form>
				
				</section>
		<?php }
			else{
		?>
				<section id="reg">
				
					<form method="post" style="max-width: 550px !important;">
						<label class="form-header" style="margin-bottom: 0px !important;">Már felhaszáltad ezt a linket!</label>
					</form>
				
				</section>
		<?php } ?>
		
	</body>
</html>