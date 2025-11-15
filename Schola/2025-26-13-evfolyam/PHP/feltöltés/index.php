<?php 

	// kapcsolódáshoz szükséges fájl behívása
	require "config.php";
	
	session_start();
	
	$szoveg = "Balázs";
	
	// INSERT INTO szovegek VALUES(id, '$szoveg') -> feltöltés parancs
	
	// $conn->query("INSERT INTO szovegek VALUES(id, '$szoveg')");

	// adat feltöltése formból
	if(isset($_POST['gomb'])){
		
		$beirt = $_POST['szoveg'];
		
		$nev = $_SESSION['nev'];
		
		$conn->query("INSERT INTO szovegek VALUES(id, '$nev', '$beirt')");
		
	}
	
	if(isset($_SESSION['nev'])){
		
		echo "<h3>Üdv, $_SESSION[nev]!</h3>";
		
	}

?>

<a href="nev.php">Név</a>

<form method="post">

	<input type="text" name="szoveg">
	
	<input type="submit" name="gomb">

</form>

<?php 

	// Egy soros lekérdezés
	$lekerdezes = "SELECT * FROM szovegek WHERE id = 1";
	$talalt_sor = $conn->query($lekerdezes);
	$sor = $talalt_sor->fetch_assoc();
	
	// print_r($sor);

	// Több soros lekérdezés
	$lekerdezes = "SELECT * FROM szovegek";
	$talalt_sorok = $conn->query($lekerdezes);
	while($sor=$talalt_sorok->fetch_assoc()){
		
		// print_r($sor);
		echo $sor['name'].": ".$sor['text']."<br>";
		
	}
?>