<?php 

	require "config.php";
	
	$keresett = $_GET['keresett'];
	
	if($keresett != ""){
	
		$lk = "SELECT * FROM posts WHERE text LIKE '%$keresett%'";
		$talaltok = $conn->query($lk);
		while($szoveg=$talaltok->fetch_assoc()){
			
			$poszt_szavai = explode(" ", $szoveg['text']);
			
			echo "<p>";
			
			for($i=0;$i<count($poszt_szavai);$i++){
				
				if($poszt_szavai[$i][0] != "#"){
				
					echo $poszt_szavai[$i]." ";
				
				} else {
					
					echo "<a href='#'>".$poszt_szavai[$i]."</a> ";
					
				}
				
			}
			
			echo "</p>";
			
		}
	
	}

?>