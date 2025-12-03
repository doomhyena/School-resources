<?php 

	session_start();
	
	// Szerkezet:
	//
	// Nevek tömb:
	// 		Kisebb tömb:
	//            Név
	// 			  Jegyek tömb:
	//                  4, 5, 3, 4, 5 ...
	
	$_SESSION['nevek'] = [
		["Attila", []],
		["Bogi", []],
		["Cecília", []],
		["Dénes", []],
		["Emese", []],
		["Feri", []],
		["Gábor", []]
	];
	
	for($i=0;$i<count($_SESSION['nevek']);$i++){
		
		echo "<a href='diak.php?index=$i'>".$_SESSION['nevek'][$i][0]."</a><br>";
		
	}

?>