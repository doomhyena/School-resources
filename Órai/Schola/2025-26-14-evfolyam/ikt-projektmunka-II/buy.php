<?php 

	$conn = new mysqli("localhost", "root", "", "2025_14b_godot");
	
	$conn->query("UPDATE users SET credit=credit-$_GET[price], perk=$_GET[perk] WHERE id=$_GET[id]");

?>