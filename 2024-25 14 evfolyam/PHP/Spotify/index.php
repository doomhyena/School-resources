<?php 

	require "config.php";

	if(isset($_COOKIE['id'])){

		$lekerdezes = "SELECT * FROM users WHERE id=$_COOKIE[id]";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		$felhasznalo = $talalt_felhasznalo->fetch_assoc();

		// Idő vizsgálata
		if(date("H") < 12){

			$szoveg = "Szép napot!";

		}
		else{

			$szoveg = "Szép estét!";

		}

	}
	else{

		header("Location: login.php");

	}

	// Új lista fefltöltése
	if(isset($_GET['playlistname'])){
		$conn->query("INSERT INTO playlists VALUES(id, $_COOKIE[id], '$_GET[playlistname]')");
		header("Location: index.php");
	}

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
					<li><a href="#"><i class="fa-solid fa-house"></i></a></li>
					<li><a href="search.php"><i class="fa-solid fa-magnifying-glass"></i></a></li>
				</ul>
			 </div>
			 <div class="playlists">
				<ul>
					<li><a href="#"><i class="fa-solid fa-book"></i></a></li>
					<li><a href="favs.php" title="Kedvencek"><i class="fa-solid fa-heart"></i></a></li>
					<li><a href="#" onclick="newPlaylist()"><i class="fa-solid fa-plus"></i></a></li>
					<?php 
						$lekerdezes = "SELECT * FROM playlists WHERE userid=$_COOKIE[id] ORDER BY id";
						$talalt_listak = $conn->query($lekerdezes);
						while($lista = $talalt_listak->fetch_assoc()){
					?>
						<li><a href="playlist.php?playlistid=<?= $lista['id']; ?>" title="<?= $lista["name"]; ?>"><i class="fa-solid fa-heart"></i></a></li>
					<?php } ?>
				</ul>
			 </div>
		</div>
		<div class="content-box">
			<div class="content-header">
				<h1><?= $szoveg; ?> <a><?= $felhasznalo['username']; ?></a></h1>
				<div class="user-playlists">
					<div class="playlist">
						<img src="img/fav.png">
						<div class="playlist-name">
							<a>Kedvencek</a>
						</div>
					</div>
					<?php 
						$lekerdezes = "SELECT * FROM playlists WHERE userid=$_COOKIE[id] ORDER BY id DESC LIMIT 2";
						$talalt_listak = $conn->query($lekerdezes);
						while($lista = $talalt_listak->fetch_assoc()){
					?>
							<div class="playlist">
								<img src="img/playlist.png">
								<div class="playlist-name">
									<a href="playlist.php?playlistid=<?= $lista['id']; ?>"><?= $lista['name']; ?></a>
								</div>
							</div>
					<?php } ?>
				</div>
			</div>
			<div class="news">
				<h1>Újdonságok</h1>
				<div class="new-songs">
					<?php 
						// Zenék lekérdezése
						$lekerdezes = "SELECT * FROM music ORDER BY id DESC";
						$talalt_zenek = $conn->query($lekerdezes);
						while($zene=$talalt_zenek->fetch_assoc()){
							
							// Alkotó lekérdezése
							$lekerdezes = "SELECT * FROM artists WHERE id=$zene[artistid]";
							$talalt_muvesz = $conn->query($lekerdezes);
							$muvesz = $talalt_muvesz->fetch_assoc();
							
							if($zene['date'] <= date("Y-m-d")){
							
					?>
						<a href="music.php?musicid=<?= $zene['id']; ?>"><div class="new-song">
							<img src="img/<?= $zene['img_name']; ?>">
							<div class="info">
								<p class="name"><?= $zene['name']; ?></p>
								<p class="artist"><?= $muvesz['name']; ?></p>
							</div>
						</div></a>
						<?php } } ?>
				</div>
			</div>
		</div>
	</body>
</html>
<script>

	function newPlaylist(){

		let playlistName = prompt("Add meg az új listád nevét:", "Új lista");

		if(playlistName == null || playlistName == ""){
			alert("Kérlek adj meg egy érvényes nevet!");
		}
		else{
			window.open("index.php?playlistname="+playlistName, target="_self");
		}

	}

</script>