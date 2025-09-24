<?php 
	/*
	Hozz létre 6 változót
	a = random szám 1 és 10 között
	b = random szám 10 és 20 között
	c = random szám 30 és 50 között
	d = random szám 1 és 5 között
	e = random szám 4 és 40 között
	f = random szám 2 és 20 között
	*/
	
	$a = rand(1, 10);
	$b = rand(10, 20);
	$c = rand(30, 50);
	$d = rand(1, 5);
	$e = rand(4, 40);
	$f = rand(2, 20);
	
	// Írd ki, hogy f néggyel elosztva mennyi maradékot ad!
	echo ($f % 4)." maradékot kaptunk.<br>";
	
	// Szorozd össze az összes változót, és írd ki a végeredményt!
	echo $a*$b*$c*$d*$e*$f."<br>";
	
	// Vizsgáld meg, hogy e nagyobb-e mint b. Írd ki, hogy nagyobb, vagy nem nagyobb!
	if($e > $b){
		echo "$e nagyobb mint $b.<br>";
	}
	else{
		echo "$e nem nagyobb mint $b<br>";
	}
	
	// Vizsgáld meg, hogy c és e közül melyik a nagyobb, és írd ki (ha egyenlőek, akkor azt írd ki)!
	if($c > $e){
		echo "$c nagyobb<br>";
	}
	else if($c < $e){
		echo "$e nagyobb<br>";
	}
	else{
		echo "Egyenlőek<br>";
	}
	
	// Írd ki, hogy c páros szám-e!
	if($c % 2 == 0){
		echo "$c páros<br>";
	}
	else{
		echo "$c páratlan";
	}
	
	// Ha d páros, add össze e-vel, és írd ki a végeredményt!
	if($d % 2 == 0){
		echo "Végeredmény: ".($d+$e)."<br>";
	}
	else{
		echo "$d nem páros.<br>";
	}
	
	// Írd ki, hogy c nagyobb-e, mint e és f összege!
	if($c > $e + $f){
		echo "$c nagyobb mint ".($e+$f);
	}
	else{
		echo "$c nem nagyobb mint ".($e+$f);
	}

	/* 
	Feladat:
	
		Hozz létre egy random számot tartalmazó változót.
		A random szám 1 és 7 között generálódjon.
		Ha a szám = 1, akkor írd ki, hogy hétfő
		Ha a szám = 2, akkor írd ki, hogy kedd
		Ha a szám = 3, akkor írd ki, hogy szerda
		.
		.
		.
	*/
	
	echo "<br>";
	echo "<br>";
	echo "<br>";
	
	$szam = rand(1, 7);
	
	if($szam == 1){
		echo "Hétfő";
	}
	else if($szam == 2){
		echo "Kedd";
	}
	else if($szam == 3){
		echo "Szerda";
	}
	else if($szam == 4){
		echo "Csütörtök";
	}
	else if($szam == 5){
		echo "Péntek";
	}
	else if($szam == 6){
		echo "Szombat";
	}
	else{
		echo "Vasárnap";
	}

	Feladat: Generáltass egy dátumot 1950 és 2025 között.
	
	Év, Hónap, nap
	
	Majd írd ki.

?>
	
	