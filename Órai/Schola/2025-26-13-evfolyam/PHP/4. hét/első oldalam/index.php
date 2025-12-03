Ez az index oldal.
<br><br>
<a href="masodik.php">Másik oldal</a>

<?php 

	$nev = "Balázs";
	
	// SESSION VÁLTOZÓK
	
	session_start(); // Minden oldalon el kell indítani, ahol session változóval dolgozol!
	
	// Session változó
	$_SESSION['valtozonev'] = "Első session adatom.";
	
	// Vizsgálat, hogy létezik-e a lista
	// Ha még nem, akkor létrehozzuk (else ág)
	// Ha létezik, kiírjuk a tartalmát
	// Ezzel a vizsgálattal biztosítjuk azt, hogy egy változónak ne törlődjön az értéke
	
	// Létezik ág
	if(isset($_SESSION['lista'])){
		print_r($_SESSION['lista']); // Ha létezik a változó, kiírjuk
	}
	// Nem létezik ág
	else{
		$_SESSION['lista'] = []; // Akkor hozzuk létre a változót, ha még nem létezik
	}
	
	// isset($valtozo) --> megvizsgálja, hogy létre lett-e hozva a $valtozo
	
	
	
	// Feladat:
	// Hozz létre session-ben egy változót "osztaly" néven. Értéknek add meg a saját osztályodat! A masodik.php oldalon írd ki ennek a változónak az értékét!
	
	echo "<br>";
	echo "<br>";
	echo "<br>";
	
	$_SESSION['osztaly'] = "13.a";
	
	// Feladat:
	// Készíts egy vizsgálatot, ami megvizsgálja, hogy van e "nap" nevű változó a session-ben. Ha van, írja ki az értékét, ha nincs, akkor add meg neki a "Hétfő értéket".
	
	if(isset($_SESSION['nap'])){
		echo $_SESSION['nap'];
	}
	else{
		$_SESSION['nap'] = "Hétfő";
	}

?>