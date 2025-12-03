<?php 

	require "config.php";
	
	if(isset($_POST['btn'])){
		header("Location: rendelesed.php?code=$_POST[code]");
	}
	
	if(isset($_GET['code'])){
		
		echo "<h1>Rendelésedhez tartizó kód: $_GET[code]</h1>";
		
		$lekerdezes = "SELECT * FROM rendelesek WHERE code='$_GET[code]'";
		$talalt_rendeles = $conn->query($lekerdezes);
		$rendeles = $talalt_rendeles->fetch_assoc();
		
		echo "Rendelésed állapota: $rendeles[status]";
		
	}
	else{
		
		echo "<form method='post' action='rendelesed.php'>
				<input name='code' type='text' placeholder='Kódod'>
				<input name='btn' type='submit' value='Keresés'>
			</form>";
		
	}

?>