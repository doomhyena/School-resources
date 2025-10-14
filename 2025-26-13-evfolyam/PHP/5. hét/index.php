<?php

	session_start();

	if(isset($_POST['gomb'])){
		
		array_push($_SESSION['lista'], $_POST['szoveg']);
		
	}
	
	// 1. feladat:
	// Készíts egy listát sessionben, és a formba bevitt adatot add hozzá.
	
	if(isset($_SESSION['lista'])){
		
		print_r($_SESSION['lista']);
		
	}
	else{
	
		$_SESSION['lista'] = [];

	}
	
	// 2. feladat:
	// Készíts egy torles.php oldalt és hozzá egy linket.
	// Ez az oldal feleljen a tömb tartalmának törléséért.
	
	// 3. feladat:
	// Készíts egy random.php oldalt és hozzá egy linket.
	// A random.php oldal adjon hozzá a listához 10 darab 1 és 50 közötti random számot.
	
	// 4. feladat:
	// Készíts egy parosak.php oldalt és hozzá egy linket.
	// A parosak.php oldal jelenítse meg a lista összes páros számát/elemét.

?>

<br><br>

<a href="torles.php">Törlés oldal</a>
<a href="random.php">Random oldal</a>
<a href="parosak.php">Páros elemek oldal</a>

<br><br>

<form method="post">

	<input type="text" name="szoveg">
	
	<br><br>
	
	<input type="submit" name="gomb">

</form>
<br><br>
<?php 

	// Legnagyobb elem megkeresése
	$legnagyobb = $_SESSION['lista'][0];
	
	echo "A kiinduló szám: $legnagyobb<br>";
	
	for($i=0;$i<count($_SESSION['lista']);$i++){
		
		// Ha az éppen vizsgált elem értéke nagyobb, mint az ismert legnagyobb érték, lecseréljük
		if($_SESSION['lista'][$i] > $legnagyobb){
			
			echo $_SESSION['lista'][$i]." nagyobb, mint $legnagyobb, lecserélem.<br>";
			$legnagyobb = $_SESSION['lista'][$i];
			
		}
		
	}

	echo "A talált legnagyobb elem: $legnagyobb";

?>