<a href="index.php">Index oldal</a>

<?php 

	session_start();
	
	echo "<br><br>";

	for($i=0;$i<count($_SESSION['lista']);$i++){
		
		echo $_SESSION['lista'][$i]."<br>";
		
	}

?>