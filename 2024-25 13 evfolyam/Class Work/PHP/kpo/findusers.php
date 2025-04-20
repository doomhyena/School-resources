<?php 

	require "config.php";
	
	$keresett = $_GET['keresett'];
	
	if($keresett != ""){

		$lekerdezes = "SELECT * FROM users WHERE username LIKE '%$keresett%' AND id != $_COOKIE[id]";
		$talalt_felhasznalok = $conn->query($lekerdezes);
		while($talalt=$talalt_felhasznalok->fetch_assoc()){
			
			echo "<form method='post' action='index.php?userid=$talalt[id]'>";
			echo "	<input type='submit' name='new-game' value='$talalt[username]'>";
			echo "</form>";
			
		}
	
	}

?>