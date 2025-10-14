<a href="feltoltes.php">Feltöltés</a>
<a href="torles.php">Törlés</a>
<a href="kisebbek.php">Kisebbek</a>
<a href="szorzas.php">Szorzás</a>
<br><br>
<?php 

	session_start();

	if(isset($_SESSION['lista'])){
		print_r($_SESSION['lista']);
	}
	else{
		$_SESSION['lista'] = [];
	}

?>