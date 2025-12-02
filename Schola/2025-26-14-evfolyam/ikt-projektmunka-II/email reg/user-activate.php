<?php 

	require "config.php";

	$userid = $_GET['userid'];
	
	$lekerdezes = "SELECT * FROM users WHERE id=$userid";
	$talalt_fiok = $conn->query($lekerdezes);
	$felhasznalo = $talalt_fiok->fetch_assoc();
	
	if($felhasznalo['active'] == 0){
		
		$conn->query("UPDATE users SET active=1 WHERE id=$userid");
		
	}
	
	header("Location: index.php");

?>