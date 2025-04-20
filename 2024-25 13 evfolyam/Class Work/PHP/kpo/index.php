<?php 

	require "config.php";
	
	if(!isset($_COOKIE['id'])){
		header("Location: reglog.php");
	}
	
	if(isset($_POST['new-game'])){
		
		$conn->query("INSERT INTO games VALUES(id, $_COOKIE[id], $_GET[userid], '-', '-', 0)");
		
	}

?>
<!DOCTYPE html>
<html lang="hu">
<head>
	
	<!-- TITLE -->
	<title>Főoldal</title>
	
	<!-- CSS -->
	<link rel="stylesheet" href="css/style.css">
	
	<!-- JQUery -->
	<script src="http://code.jquery.com/jquery-latest.js"></script>
	
</head>
<body>

	<nav>
		<ul>
			<li><a href="index.php">Főoldal</a></li>
		</ul>
	</nav>
	
	<!-- CONTENT -->
	<div class="content">
	
		<input type="text" id="search-box" placeholder="Felhasználó keresése...">
		
		<div class="users" id="users"></div>
	
	</div>
	
	<h2>Aktív játékaid</h2>
	
	<?php 
		// Bejelentkezett felhasználó aktív játékainak lekérdezése
		$lekerdezes = "SELECT * FROM games WHERE user1_id=$_COOKIE[id] AND win=0 OR user2_id=$_COOKIE[id] AND win=0";
		$talalt_jatekok = $conn->query($lekerdezes);
		while($jatek=$talalt_jatekok->fetch_assoc()){
			
			// Ellenfél lekérdezése
			if($jatek['user1_id'] == $_COOKIE['id']){
				$ellenfelid = $jatek['user2_id'];
			}
			else{
				$ellenfelid = $jatek['user1_id'];
			}
			
			$lekerdezes = "SELECT * FROM users WHERE id=$ellenfelid";
			$talalt_ellenfel = $conn->query($lekerdezes);
			$ellenfel = $talalt_ellenfel->fetch_assoc();
	?>
		<a href="game.php?gameid=<?= $jatek['id']; ?>"><?= $ellenfel['username']; ?></a><br>
	<?php } ?>

</body>
<script>

	document.getElementById("search-box").addEventListener('keyup', (e) => {
		
		var ertek = e.target.value;
		
		$("#users").load("findusers.php?keresett="+ertek);
		
	});

	

</script>