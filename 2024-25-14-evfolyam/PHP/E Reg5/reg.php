<?php 

	require "config.php";
	
	if(isset($_POST['reg-btn'])){
		
	}

?>

<h1>Regisztráció</h1>

<form method="post">

	<input type="email" name="email" placeholder="pelda@pelda.hu">
	
	<br><br>
	
	<input type="text" name="username" placeholder="Felhasználónév">
	
	<br><br>
	
	<input type="password" name="pass1" placeholder="Jelszó">
	
	<br><br>
	
	<input type="password" name="pass2" placeholder="Jelszó újra">
	
	<br><br>
	
	<input type="submit" name="reg-btn" value="Regisztrálok!">

</form>

<a>Már van fiókod?</a> <a href="login.php">Jelentkezz be!</a>