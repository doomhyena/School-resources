<?php 

	require "config.php";
	
	if(isset($_POST['reg-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_email = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_email) == 0){
			
			if($_POST['pass1'] == $_POST['pass2']){
				
				$mappa = getcwd();
				
				$eleres = $mappa."//users//".$_POST['username'];
				
				if(mkdir($eleres, 0777)){
				
					$titkos = password_hash($_POST['pass1'], PASSWORD_DEFAULT);
					
					$conn->query("INSERT INTO users VALUES(id, '$_POST[email]', '$_POST[username]', '$titkos')");
					
					$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
					$talalt_email = $conn->query($lekerdezes);
					$felhasznalo = $talalt_email->fetch_assoc();
					
					setcookie("id", $felhasznalo['id'], time() + 3600, "/");
					
					header("Location: index.php");
				
				}
				
			} else {
				echo "<script>alert('A két jelszó nem egyezik!')</script>";
			}
			
		} else {
			echo "<script>alert('Már regisztrálták ezt az email címet!')</script>";
		}
		
	}
	
	if(isset($_POST['login-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_email = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_email) == 1){
			
			$felhasznalo = $talalt_email->fetch_assoc();
			
			if(password_verify($_POST['password'], $felhasznalo['password'])){
				
				setcookie("id", $felhasznalo['id'], time() + 3600, "/");
				
				header("Location: index.php");
				
			} else {
				echo "<script>alert('Helytelen jelszó!')</script>";
			}
			
		} else {
			echo "<script>alert('Nincs ilyen felhasználó!')</script>";
		}
	}

?>
<!DOCTYPE html>
<html>
   <head>
       <title>Reglog</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Neved'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
        <h1>Reg</h1>
        <form method="post">
            <input type="email" name="email" placeholder="email">
            <br><br>
            <input type="test" name="username" placeholder="felhasználónév">
            <br><br>
            <input type="password" name="pass1" placeholder="jelszó">
            <br><br>
            <input type="password" name="pass2" placeholder="jelszó újra">
            <br><br>
            <input type="submit" value="Regisztráció!" name="reg-btn">
        </form>

        <h1>Log</h1>
        <form method="post">
            <input type="email" name="email" placeholder="email">
            <br><br>
            <input type="password" name="password" placeholder="jelszó">
            <br><br>
            <input type="submit" value="Regisztráció!" name="login-btn">
        </form>
   </body>
</html>