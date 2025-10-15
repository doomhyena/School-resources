<?php 

	require "config.php";
	
	session_start();
	
	if(!isset($_SESSION['kosar'])){
		$_SESSION['kosar'] = [];
	}
	
	echo "<a href='index.php'>Főoldal</a> ";
	echo "<a href='cart.php'>Kosár ".count($_SESSION['kosar'])." </a>";
	echo "<br><br>";
	
	if(empty($_SESSION['kosar'])) {
		echo "<h2>Kosár üres</h2>";
	} else {
		$osszeg = 0;
		echo "<h2>Kosár tartalma:</h2>";
		for ($i = 0; $i < count($_SESSION['kosar']); $i++) {
			$termek_id = $termek['id'];
			$termekszam = $termek['darabszam'];

			$lekerdezes = "SELECT * FROM termeks WHERE id = $termek_id";
			$eredmeny = $conn->query($lekerdezes);
            if ($eredmeny->num_rows > 0) {
                $termek = $eredmeny->fetch_assoc();
                $ar = ($termek['sale_ar'] > 0) ? $termek['sale_ar'] : $termek['ar'];
                $reszosszeg = $ar * $darabszam;
                $osszeg += $reszosszeg;

                echo "<div>";
                echo "  <h3>" . $termek['name'] . "</h3>";
                echo "  <p>Mennyiség: " . $darabszam . "</p>";
                echo "  <p>Egységár: " . $ar . " Ft</p>";
                echo "  <p>Részösszeg: " . $reszossszeg . " Ft</p>";
                echo "</div><br>";
            }
		
        }
        echo "<h3>Összesen: " . $osszeg . " Ft</h3>";	
	}

	if (isset($_SESSION['del-btn'])) {
		$_SESSION['kosar'] = [];
	}
?>
<!DOCTYPE html>
<html>
   <head>
	   <title>Kosár</title>
	   <meta charset='UTF-8'>
	   <meta name='description' content='Rövid leírás az oldal tartalmáról'>
	   <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
	   <meta name='author' content='Csontos Kincső'>
	   <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
	<form method="post">
		<input type="submit" name="del-btn" value="Kosár törlése">
		<input type="submit" name="order-btn" value="Megrendelés">
	</form>
   </body>
</html>