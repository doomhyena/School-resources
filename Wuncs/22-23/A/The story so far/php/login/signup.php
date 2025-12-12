<?php
session_start();

	include("connectioin.php");
	include("functions.php");
	
	if($_SERVER['REQUEST_METHOD'] == "POST")
	{
		
		$user_name = $_POST['user_name'];
		$password = $_POST['password'];
		$pw2 = $_POST['pw2'];
		
		if(preg_match('/[A-Z]/',$password) &&
		   preg_match('/[a-z]/',$password) &&
		   preg_match('/[0-9]/',$password) &&
		   strlen($password) > 4)
		{
		if (!empty($user_name) &&
			!empty($password) &&
			!is_numeric($user_name) &&
			$password === $pw2)
		{
			$hash = password_hash($password,PASSWORD_DEFAULT);
			$user_ID = rnd(20);
			$query = "insert into user (user_ID,user_name,password) values ('$user_ID','$user_name','$hash')";
			
			mysqli_query($con,$query);
			header("Location:login.php");
			die;
		}else
		{
			echo "Hibás adatok! (Két jelszó nem egyezik pl..)";
		}
		}else
		{
			echo "Jelszónak tartalmaznia kell kis- és nagybetűket,
			számokat és legalább 5 karakter hosszúnak kell lennie.";
		}
	}

?>

<!DOCTYPE html>
<html>
<head>
	<title>Regisztráció</title>
</head>
<body>
	<div id="box">
		<form method="post">
		Felhasználónév<br>
		<input id="text" type="text" name="user_name"><br><br>
		Jelszó<br>
		<input id="text" type="password" name="password"><br><br>
		Jelszó újra<br>
		<input id="text" type="password" name="pw2"><br><br>
		<input id="button" type="submit" value="Regisztrálás"><br><br>
		<a href="login.php">Bejelentkezés</a>
		</form>
	</div>
	
</body>
</html>