<?php 

	require "config.php";
	
	if(isset($_POST['login-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE username='$_POST[username]'";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_felhasznalo) > 0){
		
			$felhasznalo = $talalt_felhasznalo->fetch_assoc();
			
			if($_POST['password'] == $felhasznalo['password']){
				
				setcookie("id", $felhasznalo['id'], time() + 3600, "/");
				
				// Lekérdezzük, hogy melyik csapat tagja a felhasználó
				$lekerdezes = "SELECT * FROM teams WHERE member1id=$felhasznalo[id] OR  member2id=$felhasznalo[id] OR member3id=$felhasznalo[id]";
				$talalt_csapat = $conn->query($lekerdezes);
				$csapat = $talalt_csapat->fetch_assoc();
				
				header("Location: team.php?teamid=$csapat[id]");
				
			}
			else{
			
				echo "<script>alert('Helytelen jelszó!')</script>";
				
			}
		
		}
		else{
			
			echo "<script>alert('Nincs ilyen Felhasználó!')</script>";
			
		}

	}

?>
<!DOCTYPE html>
<html lang="hu">
	<head>
		<!-- TITLE -->
		<title>Végzős csapatok</title>

		<!-- METAS -->
		<meta charset='UTF-8'>
		<meta name='description' content='Végzős csapatok munkái'>
		<meta name='author' content='Hujber Balázs'>
		<meta name='viewport' content='width=device-width, initial-scale=1.0'>

		<!-- STYLE -->
		<link rel="stylesheet" href="css/all-style.css">
		<link rel="stylesheet" href="css/login-style.css">
		
		<!-- REFRESHER -->
		<!-- <meta http-equiv="refresh" content="2"> -->

	</head>

	<body>

		<!-- NAV -->
		<nav>
			<ul>
				<li><a class="left-menu">Csapatok</a></li>
			</ul>
		</nav>
		
		<form id="reg" method="post" action="login.php">
			<label>Bejelentkezés</label>
			<input type="text" name="username" placeholder="Felhasználónév">
			<input type="password" name="password" placeholder="Jelszó">
			<input type="submit" name="login-btn" value="Bejelentkezés">
		</form>
		


	</body>

</html>