<?php 

	require "config.php";
	
	$keresett = $_GET['keresett'];
	
	if($keresett != ""){
		
		$lekerdezes = "SELECT * FROM music WHERE name LIKE '%$keresett%' ORDER BY name";
		$talalatok = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalatok) > 0){
			
			while($zene=$talalatok->fetch_assoc()){
				
				echo "<a href='music.php?musicid=$zene[id]'>$zene[name]</a>";
				
			}
			
		}
		else{
			
			echo "Nincs találat...";
			
		}
		
	}
	else{
		
		echo "Itt jelennek meg a talált zenék...";
		
	}

?>