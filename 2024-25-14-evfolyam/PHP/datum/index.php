<?php 

	require "config.php";

	// Mai dátum feltöltése
	$datum = date("Y-m-d");
	
	$conn->query("INSERT INTO datum VALUES(id, '$datum')");
	
	// DATE FORMÁTUM: ÉÉÉÉ-HH-NN
	
	// DATETIME FORMÁTUM: ÉÉÉÉ-HH-NN ÓÓ-PP-MM
	
	$datum = date("Y-m-d H-i-s");
	
	$conn->query("INSERT INTO idopontok VALUES(id, '$datum')");
	
	$lekerdezes = "SELECT * FROM idopontok ORDER BY date DESC";
	$talalt_datumok = $conn->query($lekerdezes);
	while($datum = $talalt_datumok->fetch_assoc()){
		
		echo $datum['date']."<br>";
		
	}

?>