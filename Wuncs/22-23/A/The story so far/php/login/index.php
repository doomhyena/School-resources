<?php
session_start();
	
	include("connectioin.php");
	include("functions.php");
	
	$user_data = check_login($con);
?>

<!DOCTYPE html>
<html>
<head>
	<title>Főoldal</title>
</head>
<body>
	<a href="logout.php">Kijelentkezés</a>
	<h1>Főoldal</h1><br>
	<?php echo $user_data['user_name'];?>
</body>
</html>