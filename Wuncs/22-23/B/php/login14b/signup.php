<?php
session_start();

	include("connection.php");
	include("functions.php");
	
	if($_SERVER['REQUEST_METHOD'] == "POST")
	{
		
		$user_name = $_POST['user_name'];
		$password = $_POST['password'];
		$pw2 = $_POST['pw2'];
		
		if(preg_match('/[A-Z]/',$password) &&
		   preg_match('/[a-z]/',$password) &&
		   preg_match('/[0-9]/',$password) &&
		   strlen($password) > 8)
		{
		
		if (!empty($user_name) &&
			!empty($password) && 
			!is_numeric($user_name) &&
			$password === $pw2)
		{
			$hash = password_hash($password,PASSWORD_DEFAULT);
			$user_id = rnd(20);
			$query = "insert into felhasznalok(user_id,user_name,password)
					  values('$user_id','$user_name','$hash')";
			mysqli_query($con,$query);
			
			header("Location: login.php");
			die;
		}else
		{
			echo "Hibás adatok! (Két jelszó nem egyezik meg pl..)";
		}
		}else
		{
			echo "Jelszónak tartalmaznia kell kis-
			és nagybetűket,
			illetve legalább nyolc hosszúnak kell lennie.
			És szám is legyen benne. :-$";
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
		<input id="button" type="submit" value="Regisztráció"><br><br>
		<a href="login.php">Bejelentkezés</a>
		</form>
	</div>

</body>
</html>