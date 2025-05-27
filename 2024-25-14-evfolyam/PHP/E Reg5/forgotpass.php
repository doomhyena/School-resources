<?php 

	require "config.php";
	
	require "functions.php";
	
	if(isset($_POST['send-mail-btn'])){
		
		$lekerdezes = "SELECT * FROM users WHERE email='$_POST[email]'";
		$talalt_email = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_email) == 1){
			
			header("Location: new-pass-mail.php?email=$_POST[email]");
			
		}
		else{
			
			Message("Nincs ilyen email cím!");
			
		}
		
	}

?>

<form method="post">

	<input type="email" name="email" placeholder="pelda@pelda.hu">
	
	<input type="submit" name="send-mail-btn">

</form>