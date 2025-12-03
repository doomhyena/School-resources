<?php 

	require "config.php";
	
	$lekerdezes = "SELECT * FROM texts WHERE TEXT LIKE '%$_GET[keresett]%'";
	$finded_text = $conn->query($lekerdezes);
	while($felhasznalo = $talalt_felhasznalo->fetch_assoc()){
	
		echo '<form class="user" method="post" action="search.php?userid='.$felhasznalo['id'].'">
				<label>'.$felhasznalo['username'].'</label>';
		
		echo '</form>';
	
	}

?>