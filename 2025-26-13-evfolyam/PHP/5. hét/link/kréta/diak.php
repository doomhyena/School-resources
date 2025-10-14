<?php 

	session_start();
	
	$index = $_GET['index'];
	
	if(isset($_POST['gomb'])){
		
		array_push($_SESSION['nevek'][$index][1], $_POST['jegy']);
		
	}
	
	echo "<h3> Kiválasztott diák: ".$_SESSION['nevek'][$index][0]."</h3>";

	echo "<h4>Jegyek:</h4>";
	
	if(count($_SESSION['nevek'][$index][1]) == 0){
		
		echo "Még nincsenek beírt jegyek";
		
	}
	else{
		
		for($i=0;$i<count($_SESSION['nevek'][$index][1]);$i++){
			
			echo $_SESSION['nevek'][$index][1][$i]." ";
			
		}
		
		$osszeg = 0;
		
		// Átlag számítás
		for($i=0;$i<count($_SESSION['nevek'][$index][1]);$i++){
			
			$osszeg += $_SESSION['nevek'][$index][1][$i];
			
		}
		
		echo "Átlag: ".($osszeg/count($_SESSION['nevek'][$index][1]));
		
	}

?>
<br><br>
<form method="post">

	<input type="number" name="jegy" placeholder="Írj be egy jegyet">
	
	<input type="submit" name="gomb">

</form>

