<?php 

	require "config.php";

	$linkValtozo = $_GET['keresett'];
	
	//echo $linkenBelulKapottErtek;
	
	if($linkValtozo != ""){
	
		$lekerdezes = "SELECT * FROM telefonszamok WHERE telefonszam LIKE '%$linkValtozo%'";
		$talalt_szam = $conn->query($lekerdezes);
		while($telefonszam=$talalt_szam->fetch_assoc()){
			
			echo $telefonszam['telefonszam']."<br>";
			
		}
	
	}

?>