<?php 

	// Elágazások
	
	$a = 3;
	$b = 9;
	
	// Kisebb
	if($a < $b){
		
		echo "$a kisebb mint $b";
		
	}
	else{
		
		echo "$a nem kisebb mint $b";
		
	}
	
	echo "<br>";
	
	// Nagyobb
	if($a > $b){
		
		echo "$a nagyobb mint $b";
		
	}
	else{
		
		echo "$a nem nagyobb mint $b";
		
	}
	
	echo "<br>";
	
	// Egyenlő
	if($a == $b){
		
		echo "$a egyenlő $b";
		
	}
	else{
		
		echo "$a nem egyenlő $b";
		
	}
	
	echo "<br>";
	
	// Nem egyenlő
	if($a != $b){
		
		echo "$a nem egyenlő $b";
		
	}
	else{
		
		echo "$a egyenlő $b";
		
	}
	
	echo "<br>";
	
	// Kisebb-egyenlő
	if($a <= $b){
		
		echo "$a kisebb vagy egyenlő $b";
		
	}
	else{
		
		echo "$a nagyobb mint $b";
		
	}
	
	echo "<br>";
	
	// Nagyobb-egyenlő
	if($a >= $b){
		
		echo "$a nagyobb vagy egyenlő $b";
		
	}
	else{
		
		echo "$a kisebb mint $b";
		
	}
	
	echo "<br>";

	// Vizsgáljuk meg, hogy az általunk megadott szám páros-e.
	
	$szam = 122;
	$maradek = $szam % 2;
	
	if($maradek == 0){
		echo "$szam páros";
	}
	else{
		echo "$szam páratlan";
	}
	

?>