<?php 

	$szoveg = "szöveg"; // string -> szöveg
	$a = 3; // int -> szám
	$b = 4;
	$c = 8;
	$d = rand(1, 20);
	$e = rand(1, 30);
	
	// Kiírás
	echo $a;
	echo "<br>";
	echo $b;
	echo "<br>";
	echo $c;
	echo "<br>";
	echo $d;
	echo "<br>";
	echo $e;
	echo "<br>";
	
	$osszeg = $a + $b;
	
	if($osszeg % 2 == 0){
		
		echo "Az összeg páros<br>";
		
	}
	else{
		
		echo "Az összeg páratlan<br>";
		
	}
	
	/*
		+ - összeadás
		- - kivonás
		* - szorzás
		/ - osztás
		% - mennyi a maradék
	*/
	
	$szorzat = $d * $e;
	
	if($szorzat > 100){
		echo "A szorzat nagyobb mint 100";
	}
	else{
		echo "A szorzat kisebb, mint 100";
	}
	
	/*
		== - egyenlő
		!= - nem egyenlő
		> - nagyobb
		< - kisebb
		>= - nagyobb egyenlő
		<= - kisebb egyenlő
	*/
	echo "<br>";
	echo "<br>";
	
	// Hármas elágazás
	
	$szam = 2;
	
	if($szam == 0){
		echo 0;
		echo "<br>";
	}
	else if($szam == 1){
		echo 1;
		echo "<br>";
	}else if($szam == 2){
		echo 2;
		echo "<br>";
	}
	else{
		echo "nem 0, 1 vagy 2";
		echo "<br>";
	}

	// Feladat:
	// Hozz létre egy változót, amibe random szám generálódik 1 és 3 között.
	// Nézd meg, hogy a szám 3-mal elosztva mennyi maradékot ad.
	// A vizsgálat után mindig a megfelelő szöveg jelenjen meg.
	// pl: szám osztva 3-mal 0 maradékot ad.
	// pl: szám osztva 3-mal 1 maradékot ad.
	// ...
	
	$szam = rand(1, 100);
	
	// ---------------------
	if($szam % 3 == 0){
		echo "$szam osztva 3-mal 0 maradékot ad.";
	}
	else if($szam % 3 == 1){
		echo "$szam osztva 3-mal 1 maradékot ad.";
	}
	else{
		echo "$szam osztva 3-mal 2 maradékot ad.";
	}

?>