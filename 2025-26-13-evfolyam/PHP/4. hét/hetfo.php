<?php 

	$lista = [];

	// array_push($lista, 1);
	
	// print_r($lista);
	
	for($i=0;$i<10;$i++){
		
		$szam = rand(1, 10);
	
		array_push($lista, $szam);
		
	}
	
	print_r($lista);

?>