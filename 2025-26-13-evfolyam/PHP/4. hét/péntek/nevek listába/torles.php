<a href="index.php">Index oldal</a>
<br><br>
<?php 

	session_start();
	
	$_SESSION['lista'] = []; // Lista törlése --> átállítás üres listává
	
	print_r($_SESSION['lista']);

?>