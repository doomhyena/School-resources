<?php 

	session_start();
	
	$index = $_GET['index'];

	echo "A listám ".$_GET['index'].". indexű eleme: ".$_SESSION['lista'][$_GET['index']];

?>