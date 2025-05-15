<?php 

	require "config.php";
	
	require "functions.php";
	
	if(isset($_POST['send-btn'])){
		
		$lekerdezes = "SELECT * FROM codes WHERE code='$_POST[code]'";
		$talalt_kod = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_kod) == 1){
			
			$kod = $talalt_kod->fetch_assoc();
			
			if($kod['userid'] == $_COOKIE['id']){
				
				$conn->query("UPDATE users SET status='active' WHERE id=$_COOKIE[id]");
				
				Message("Sikeresen aktiváltad a fiókodat!");
				
				echo "<a href='index.php'>Főoldal</a>";
				
			}
			else{
				
				Message("Helytelen kód!");
				
			}
			
		}
		else{
			
			Message("Helytelen kód!");
			
		}
		
	}

?>
<form method="post">

	<input type="text" name="code" placeholder="Aktiváló kódod">
	
	<input type="submit" name="send-btn">

</form>