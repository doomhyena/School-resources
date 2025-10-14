<?php 

	// Random szám generálása
	// $szam = rand(0, 10);
	
	// echo $szam;

	// Feladat: 
	
	// Generáltass két random számot, majd írd ki velük a öt tanult műveletet és a végeredményt is.
	
	// pl:
	
	// x + y = z
	// x - y = z
	// x * y = z
	// ...
	
	$a = rand(0, 50);
	$b = rand(0, 50);
	
	$o = $a+$b;
	$k = $a-$b;
	$sz = $a*$b;
	$h = $a/$b;
	$m = $a%$b;
	
	echo "$a + $b = $o<br>";
	echo "$a - $b = $k<br>";
	echo "$a * $b = $sz<br>";
	echo "$a / $b = $h<br>";
	echo "$a % $b = $m<br>";
	
	echo "<br>";
	
	// Feladat:
	
	// Generáltass két random számot.
	// Ha az első szám nagyobb mint a második, akkor vondd ki az elsőből a második számot, az összes többi esetben pedig szorozd össze őket, majd írd ki a végeredményt.
	
	$szam1 = rand(0, 50);
	$szam2 = rand(0, 50);
	
	if($szam1 > $szam2){
		echo "$szam1 - $szam2 = ".$szam1-$szam2;
	}
	else{
		echo "$szam1 * $szam2 = ".$szam1*$szam2;
	}

?>