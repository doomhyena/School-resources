<a href="feltoltes.php">Feltöltés</a>
<a href="torles.php">Törlés</a>
<br><br>
<?php 

	session_start();
	
	if(isset($_SESSION['lista'])){
		print_r($_SESSION['lista']);
	}
	else{
		$_SESSION['lista'] = [];
	}


?>