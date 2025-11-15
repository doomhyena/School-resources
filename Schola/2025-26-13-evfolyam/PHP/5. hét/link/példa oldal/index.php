<?php 

	session_start();
	
	$_SESSION['lista'] = [3, 7, 2, 5, 8, 5, 3, 1, 4, 6, 8];
	
	for($i=0;$i<count($_SESSION['lista']);$i++){
		
		echo "<a href='sablon.php?index=$i'>sablon oldal</a><br>";
		
	}

?>