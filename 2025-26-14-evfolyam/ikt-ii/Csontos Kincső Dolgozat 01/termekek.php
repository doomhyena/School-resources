<?php

	require "config.php";
	$sql = "SELECT * FROM termekek";
	$termek = $conn->query($sql);
	$termekek = $termek->fetch_assoc();
	
	echo "<a href='termek.php?='".$termek.">" . $termekek . "</a>";
?>