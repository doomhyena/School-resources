<a href="index.php">Index</a>
<br><br>
<?php 

	session_start();
	
	for($i=0;$i<count($_SESSION['lista']);$i++){
		
		if($_SESSION['lista'][$i] % 2 == 0){
			
			echo $_SESSION['lista'][$i]."<br>";
			
		}
		
	}

?>
