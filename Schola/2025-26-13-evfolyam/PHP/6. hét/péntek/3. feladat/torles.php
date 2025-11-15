<a href="index.php">index</a>
<br><br>
<?php 

	session_start();
	
	$_SESSION['lista'] = [];
	
	print_r($_SESSION['lista']);

?>