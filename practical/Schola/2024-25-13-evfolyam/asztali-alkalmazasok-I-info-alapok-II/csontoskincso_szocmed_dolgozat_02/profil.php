<?php 

	require "config.php";
	
	session_start();
	
	$userid = $_GET['userid'];
	$lekerdezes = "SELECT * FROM users WHERE id=$userid";
	$talalt_felhasznalo = $conn->query($lekerdezes);
	$felhasznalo = $talalt_felhasznalo->fetch_assoc();
	
	
	echo "<h1>$felhasznalo[username] profilja</h1>";

	echo '<a href="index.php">Főoldal</a>';
		
?>

<h3>Posztok</h3>

<?php 

	$lekerdezes = "SELECT * FROM posztok WHERE userid=$userid ORDER BY id DESC";
	$talalt_poszt = $conn->query($lekerdezes);
	while($poszt=$talalt_poszt->fetch_assoc()){
		
		echo '<p>';
		
		echo $poszt['szoveg'];
	
		
		$lekerdezes = "SELECT * FROM likes WHERE postid=$poszt[id]";
		$talalt_kedvelesek = $conn->query($lekerdezes);
		
		$like_szam = mysqli_num_rows($talalt_kedvelesek);
		
		echo "<br>";
		echo "$like_szam kedvelés";
		
		echo "</p>";
		
	}
	
?>