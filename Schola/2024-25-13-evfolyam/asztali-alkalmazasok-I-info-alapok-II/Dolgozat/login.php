<?php

	require "cfg.php";
	
	if(isset($_POST['login-btn'])) {
		$username = $_POST['username'];
		$password = $_POST['password'];
		$sql = "SELECT * FROM users";
		$founded_user = $conn->query($sql);
		$user = $founded_user->fetch_assoc();
		
		if(mysql_num_rows($username) > 0) {
			if(password_verify($password, DEFAULT_PASSWORD)) {
				setcookie();
				header("Location: index.php");
			} else {
				echo "Nem jó a jelszó!";
			}
		} else {
			echo "Nincs ilyen felhasználó!";
		}
	}

?>

<form method="POST">
	<label>Felhasználónév:</label>
	<input type="text" name="felhasznalonev">
	<label>Jelszó:</label>
	<input type="password" name="password">
	<input type="button" name="login-btn" placeholder="Bejelentkezés">
</form>