<?php 

	// változó kiindulási érték
	// 	$i = 0;
	
	// Meddig fusson a ciklus
	// 	$i<10;
	
	// $i érték növelése
	//	 $i++ ----> $i = $i + 1
	
	/*for($i=0;$i<10;$i++){
		if($i % 2 == 0){
			echo $i."<br>";
		}
	}*/
	
	// Számok 1-től 100-ig
	/*for($i=1;$i<101;$i++){
		echo $i."<br>";
	}*/
	
	// Írd ki az összes olyan számot 0 és 50 között, ami hárommal elosztva 0 maradékot ad
	/*for($i=0;$i<50;$i++){
		if($i % 3 == 0){
			echo $i."<br>";
		}
	}*/
	
	// Szorzótábla
	/*for($i=0;$i<31;$i++){
		
		if($i % 3 == 0){
			$ertek = $i/3;
			echo "3 x $ertek = ".$i."<br>";
		}
		
	}*/
	
	// Dupla for ciklus
	/*for($i=0;$i<10;$i++){
		
		for($j=0;$j<10;$j++){
			
			echo "i: ".$i." j:".$j."<br>";
			
		}
		
	}*/
	
	/*for($i=0;$i<10;$i++){
		for($j=0;$j<10;$j++){
			echo rand(0, 1);
		}
		echo "<br>";
	}*/
	
	// Lista létrehozása
		// $lista = [1, 2, 3];
		// $lista2 = array(1, 2, 3, 4, 5);
	
	// Lista elemeinek kiírása
		// print_r($lista2);
	
		// $lista = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13];
	
	// Lista elem kiírása
		// echo $lista[8];
	
	// Lista hossza
		// $hossz = count($lista);
	
	// For ciklussal végigmegyünk a lista összes elemén
		// for($i=0;$i<$hossz;$i++){
			// echo $lista[$i]."<br>";
		// }
	
	// Elem hozzáadása a listához
	// melyik tömbbe, mit
		// array_push($lista, 14);
		
		// print_r($lista);
	
	// Új anyag
	// for ciklus
	// lista létrehozása
	// lista kiírása print_r()
	// lista elemének kiírása
	// lista hossza
	// elem hozzáadása a listához
	// lista elemeinek kiírása for ciklussal
	
	// Feladatok
	// Tölts fel egy üresen létrehozott listát számokkal 1-10-ig
	
		// $lista = [];
		
		// for($i=1;$i<11;$i++){
			
			// array_push($lista, $i);
			
		// }
		// print_r($lista);
	
	// Lista feltöltése 20 darab random számmal
	
	$lista = [];
	
	for($i=1;$i<21;$i++){
		array_push($lista, rand(0, 10));
	}
	
	print_r($lista);
	
	// Lista random elemének kiírása
	$randomIndex = rand(0, count($lista)-1);
	
	// Ahhoz, hogy egy lista elemei közül egy randomot tudjunk kiválasztani, ismernünk kell a lista határait.
	// Mivel a lista indexelése 0-val indul, a random szám generálásnál 0 lesz az alső érték.
	// A felső értéket a lista hosszával (elemeinek darabszámával) kell megoldanunk.
	// A count() parancs mindig az utolsó index+1 értéket adja meg, ezért a random szám választásnál ki kell vonnunk belőle egyet. 
	// példa
	// lista hossza/elemeinek száma: 10
	// első index: 0 ---> mindig!
	// utolsó index: 9
	// random index generálásához a tartomány 0-9 kell, hogy legyen
	// count() parancs 10-et, azaz a lista hosszát adja vissza.
	// A random index tartománya 0-9, ezért kell a count() paranccsal kapott 10-ből egyet kivonni, hogy a megfelelő számot adhassuk meg felső értéknek.
	
	// Mindig minden lista utolsó elemének az indexe a list ahossza-1 érték
	
	echo $lista[$randomIndex];

	echo "<br>";
	echo "<br>";
	echo "<br>";

	// Lista elemeinek összege
	$lista = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
	
	$osszeg = 0;
	
	// Végigmegyünk a listán, és mindig hozzáadjuk az összeghez az éppen vizsgált elem értékét
	for($i=0;$i<count($lista);$i++){
		
		$osszeg = $osszeg + $lista[$i];
		
	}
	
	echo $osszeg;
?>