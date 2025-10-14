<?php

	// Feladat:
	// for ciklussal generáltass 10x egy  listát kettő darab 1 és 50 közötti random számmal. Ezeket a listákat add hozzá egy nagy listához. Generáltass olyan linkeket, amikkel ki lehet választani a nagy listából a kis listákat. A link a sablon.php oldalra vezessen át. A sablon oldal a megkapott index alapján nézze meg, hogy a kisebb listának melyik eleme a nagyobb, vagy hogy egyenlőek-e.
	
	session_start();
	
	$_SESSION['lista'] = [];
	
	// Listák lérehozása és hozzáadása a nagy listához
	for($i=0;$i<10;$i++){
		
		$szam1 = rand(1, 50);
		$szam2 = rand(1, 50);
		
		$lista = [$szam1, $szam2];
		
		array_push($_SESSION['lista'], $lista);
		
	}
	
	// linkek generálása
	for($i=0;$i<count($_SESSION['lista']);$i++){
		
		echo "<a href='sablon.php?index=$i'>$i. lista</a><br>";
		
	}
	
?>	
