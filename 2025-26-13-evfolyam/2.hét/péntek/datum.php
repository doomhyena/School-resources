<?php 

	// Dátum 1950 és 2025 között
	
	$ev = rand(1950, 2025);
	$honap = rand(1, 12);
	
	if($honap == 1){
		$nap = rand(1, 31);
	}
	else if($honap == 2){
		
		if($ev % 4 == 0){
			$nap = rand(1, 29);
		}
		else{
			$nap = rand(1, 28);
		}
		
	}
	else if($honap == 3){
		
		$nap = rand(1, 31);
		
	}
	else if($honap == 4){
		
		$nap = rand(1, 30);
		
	}
	else if($honap == 5){
		
		$nap = rand(1, 31);
		
	}
	else if($honap == 6){
		
		$nap = rand(1, 30);
		
	}
	else if($honap == 7){
		
		$nap = rand(1, 31);
		
	}
	else if($honap == 8){
		
		$nap = rand(1, 31);
		
	}
	else if($honap == 9){
		
		$nap = rand(1, 30);
		
	}
	else if($honap == 10){
		
		$nap = rand(1, 31);
		
	}
	else if($honap == 11){
		
		$nap = rand(1, 30);
		
	}
	else{
		
		$nap = rand(1, 31);
		
	}
	
	if($honap <10){
		echo "$ev.0$honap.$nap";
	}
	else{
		echo "$ev.$honap.$nap";
	}

?>