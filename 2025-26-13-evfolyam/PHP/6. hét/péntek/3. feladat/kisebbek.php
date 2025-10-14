<a href="index.php">index</a>
<br><br>
<?php 

	session_start();
	
	for($i=0;$i<count($_SESSION['lista']);$i++){
		
		if($_SESSION['lista'][$i] < 50){
			
			echo $_SESSION['lista'][$i]."<br>";
			
		}
		
	}

?>