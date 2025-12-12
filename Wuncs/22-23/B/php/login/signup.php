<?php
session_start();

	include("connection.php");
	include("functions.php");
	
	if($_SERVER['REQUEST_METHOD'] == "POST")
	{
		
		$user_name = $_POST['user_name'];
		$password = $_POST['password'];
		
		if (!empty($user_name) &&
			!empty($password) && 
			!is_numeric($user_name))
		{
			$user_id = rnd(20);
			$query = "insert into users(user_id,user_name,password)
					  values('$user_id','$user_name','$password')";
			mysqli_query($con,$query);
			
			header("Location: login.php");
			die;
		}else
		{
			echo "Hibás adatok!";
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
		<input id="button" type="submit" value="Regisztráció"><br><br>
		<a href="login.php">Bejelentkezés</a>
		</form>
	</div>

</body>
</html>