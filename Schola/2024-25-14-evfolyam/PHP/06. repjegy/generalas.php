<?php 

	require "config.php";

	$varosok = array("London", "New York", "Tokió", "Sanghaj", "Los Angeles", "Párizs", "Atlanta", "Chicago", "Peking", "Dubaj", "Bangkok", "Isztambul", "Moszkva", "Szöul", "Dallas", "Miami", "San Francisco", "Washington", "Hongkong", "Jakarta	Indonézia", "São Paulo", "Amszterdam", "Frankfurt", "Kuangcsou", "Delhi", "Szingapúr", "Kuala Lumpur", "Denver", "Houston", "Madrid");
	
	// GENERÁLÁS
	for($i=0;$i<count($varosok);$i++){
		
		$varoshoz_cel = 0;
		
		while($varoshoz_cel < 5){
		
			$from = $varosok[$i];
			
			$to = $varosok[rand(0, count($varosok)-1)];
			
			while($from == $to){
				
				$to = $varosok[rand(0, count($varosok)-1)];
				
			}
			
			// Létezik-e már az út oda vagy vissza
			$lekerdezes = "SELECT * FROM utak WHERE from_city='$from' AND to_city='$to' OR from_city='$to' AND to_city='$from'";
			$talalt_ut = $conn->query($lekerdezes);
			
			if(mysqli_num_rows($talalt_ut) == 0){
				
				$price = rand(50000, 500000);
				
				$conn->query("INSERT INTO utak VALUES(id, '$from', '$to', $price)");
				
				$varoshoz_cel++;
				
			}
		
		}
		
	}

?>