Ez a második oldal
<br><br>
<a href="index.php">Index oldal</a>

<?php 

	session_start();

	echo $_SESSION['valtozonev'];
	
	echo "<br><br>";
	
	// Minden alkalommal amikor ez az oldal nyílik meg, hozzáadunk 10 random számot a listához
	for($i=0;$i<10;$i++){
		
		$szam = rand(1, 10);
		
		array_push($_SESSION['lista'], $szam);
		
	}
	
	print_r($_SESSION['lista']);
	
	echo "<br><br>";
	
	echo $_SESSION['osztaly'];	
	

?>