<?php 

	// For ciklus
	for($i=0;$i<10;$i++){
		
		echo rand(1, 10)."<br>";
		
	}
	echo "<br>";
	
	// Lista
	$lista = [];
	$lista = array();
	
	// Elemek megadása
	$lista = [1, 2, 3, 4, 5];
	
	// Elem kiírása (pl.: 1. elem);
	echo $lista[0];
	echo "<br>";
	
	// Teljes lista kiírása
	print_r($lista);
	echo "<br>";
	
	// Lista hossza
	$hossz = count($lista);
	echo $hossz;
	
	// Elem hozzáadása listához
	array_push($lista, 6);
	echo "<br>";
	print_r($lista);

?>