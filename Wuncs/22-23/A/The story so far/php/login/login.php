<?php
session_start();

	include("connectioin.php");
	include("functions.php");
	
	if($_SERVER['REQUEST_METHOD'] == "POST")
	{
		
		$user_name = $_POST['user_name'];
		$password = $_POST['password'];
		
		if (!empty($user_name) && !empty($password) && !is_numeric($user_name))
		{
			
			$query = "select * from user where user_name = '$user_name' limit 1";
			
			$result = mysqli_query($con,$query);
			if ($result)
			{
				if ($result && mysqli_num_rows($result) > 0)
				{
					$user_data = mysqli_fetch_assoc($result);
					if (password_verify($password,$user_data['password']))
					{
						$_SESSION['user_ID'] = $user_data['user_ID'];
						header("Location: index.php");
						die;
					}
				}
			}
			echo "Hibás felhasználó vagy jelszó.";
		}else
		{
			echo "Hibás adatok!";
		}
	}

?>

<!DOCTYPE html>
<html>
<head>
	<title>Bejelentkezés</title>
</head>
<body>
	<div id="box">
		<form method="post">
		Felhasználónév<br>
		<input id="text" type="text" name="user_name"><br><br>
		Jelszó<br>
		<input id="text" type="password" name="password"><br><br>
		<input id="button" type="submit" value="Bejelentkezés"><br><br>
		<a href="signup.php">Regisztrálás</a>
		</form>
	</div>
	
</body>
</html>