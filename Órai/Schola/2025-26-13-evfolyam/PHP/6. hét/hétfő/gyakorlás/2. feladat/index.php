<?php

	// Feladat:
	
	// for ciklussal generáltass 10 linket. mindegyik link egy sablon.php oldalra vezesses át. Linken belül add át $i értékét.
	// A sablon.php oldalon írd ki, hogy 10 elosztva a linken belül megkapott értékkel mennyi maradékot ad!
		
	for($i=1;$i<11;$i++){
		
		echo "<a href='sablon.php?oszto=$i'>$i Link</a><br>";
		
	}
		
?>