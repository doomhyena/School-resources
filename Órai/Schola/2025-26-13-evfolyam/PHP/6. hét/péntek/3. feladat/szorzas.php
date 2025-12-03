<a href="index.php">index</a>
<br><br>
<?php 

	session_start();
	
	for($i=0;$i<count($_SESSION['lista']);$i++){
		
		if($_SESSION['lista'][$i] % 3 == 0){
			
			echo $_SESSION['lista'][$i]." * 15 = ".($_SESSION['lista'][$i]*15)."<br>";
			
		}
		
	}


?>