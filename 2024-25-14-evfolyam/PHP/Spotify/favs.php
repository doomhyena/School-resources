<?php 

	require "config.php";

?>
<!DOCTYPE html>
<html lang="hu">
	<head>
		<!-- TITLE -->
		<title>Scholafy</title>
		
		<!-- METAS -->
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		
		<!-- STYLE -->
		<link rel="stylesheet" href="css/style.css">
		
		<!-- GOOGLE FONTS -->
		<link rel="preconnect" href="https://fonts.googleapis.com">
		<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
		<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Sans+Arabic:wght@100&family=Nunito+Sans:opsz@6..12&display=swap" rel="stylesheet">
		
		<!-- FONT AWESOME -->
		<script src="https://kit.fontawesome.com/086e7cefb3.js" crossorigin="anonymous"></script>
		
		<!-- REFRESHER -->
		<!-- <meta http-equiv="refresh" content="2"> -->
	</head>
	<body>
		<div class="side-menu">
			 <div class="menu">
				<ul>
					<li><a href="index.php"><i class="fa-solid fa-house"></i></a></li>
					<li><a href="#"><i class="fa-solid fa-magnifying-glass"></i></a></li>
				</ul>
			 </div>
			 <div class="playlists">
				<ul>
					<li><a href="#"><i class="fa-solid fa-book"></i></a></li>
					<li><a href="favs.php"><i class="fa-solid fa-heart"></i></a></li>
					<li><a href="#"><i class="fa-solid fa-plus"></i></a></li>
				</ul>
			 </div>
		</div>
		<div class="content-box">
			<div class="content-header">
				<h1>Kedvenceid</h1>
				<div class="musics">
					<?php 
						$lekerdezes = "SELECT * FROM favs WHERE userid=$_COOKIE[id]";
						$talalt_kedvencek = $conn->query($lekerdezes);
						while($kedvenc=$talalt_kedvencek->fetch_assoc()){
							
							$lekerdezes = "SELECT * FROM music WHERE id=$kedvenc[musicid]";
							$talalt_zene = $conn->query($lekerdezes);
							$zene = $talalt_zene->fetch_assoc();
							
							$lekerdezes = "SELECT * FROM artists WHERE id=$zene[artistid]";
							$talalt_muvesz = $conn->query($lekerdezes);
							$muvesz = $talalt_muvesz->fetch_assoc();
					?>
					<div class="music">
						<p><?= $muvesz['name']; ?> - <?= $zene['name']; ?></p>
						<audio controls>
							<source src="files/<?= $zene['file_name']; ?>" type="audio/mp3">
						</audio>
					</div>
						<?php } ?>
				</div>
			</div>
		</div>
	</body>
</html>