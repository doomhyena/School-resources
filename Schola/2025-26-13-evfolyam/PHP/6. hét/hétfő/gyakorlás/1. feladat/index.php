<?php

	// Feladat:
	// Hozz létre egy session listát 10 darab értékkel (lehet szám, név vagy bármi)		
	// Az indexen készíts egy for ciklust, ami annyi linket generál a listából a sablon.php oldalra, ahány érték szerepel benne. A linkekben helyezz el egy index változót, és mindig az $i értékével legyen egyenlő. Próbáld meg kiírni a linkre, hogy hányadik elemre vonatkozik az a link. (ha nem megy, elég csak a "link" szót kiírni)	
	// Az sablon.php oldalon írd ki a linken belül megkapott index alapján a lista megfelelő elemét.

	session_start();
	
	$_SESSION['lista'] = [6, 4, 2, 8, 5, 2, 0, 4, 8, 9];
	
	for($i=0;$i<count($_SESSION['lista']);$i++){
		
		// Link létrehozása változóval és értékkel
		// oldalNeve.php?valtozoneve=ertek
		echo "<a href='sablon.php?index=$i'>".($i+1).". elem</a><br>";
		
	}


?>