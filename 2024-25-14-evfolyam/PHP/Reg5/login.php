<?php 

	require "config.php";
	
	if(isset($_POST['login-btn'])){
		
	}

?>

<h1>Bejelentkezés</h1>

<form method="post">

	<input type="email" name="email" placeholder="pelda@pelda.hu">
	
	<br><br>
	
	<input type="password" name="password" placeholder="Jelszó">
	
	<br><br>
	<br><br>
	
	<input type="submit" name="login-btn" value="Bejelentkezem!">

</form>

<a>Még nincs fiókod?</a> <a href="reg.php">Regisztrálj!</a>

<br><br>

<a href="forgotpass.php">Elfelejtettem a jelszavamat</a>