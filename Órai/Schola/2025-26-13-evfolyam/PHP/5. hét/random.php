<a href="index.php">Főoldal</a>
<br><br>
<?php 

	session_start();
	
	for($i=0;$i<10;$i++){
		
		$szam = rand(1, 50);
		
		array_push($_SESSION['lista'], $szam);
		
	}
	
	print_r($_SESSION['lista']);


?>