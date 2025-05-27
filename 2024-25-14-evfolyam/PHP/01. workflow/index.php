<?php

	require "config.php";

?>
<!DOCTYPE html>
<html lang="hu">
	<head>
		<!-- TITLE -->
		<title>Végzős csapatok</title>

		<!-- METAS -->
		<meta charset='UTF-8'>
		<meta name='description' content='Végzős csapatok munkái'>
		<meta name='author' content='Hujber Balázs'>
		<meta name='viewport' content='width=device-width, initial-scale=1.0'>

		<!-- STYLE -->
		<link rel="stylesheet" href="css/all-style.css">
		<link rel="stylesheet" href="css/index-style.css">
		
		<!-- REFRESHER -->
		<!-- <meta http-equiv="refresh" content="2"> -->

	</head>

	<body>

		<!-- NAV -->
		<nav>
			<ul>
				<li><a class="left-menu">Csapatok</a></li>
			</ul>
		</nav>
		
		<section id="teams">
		
			<div class="box">
				
				<div id="teams-header">
				
					<h1>Csapatok listája</h1>
					
					<form id="new-team">
						<input type="submit" value="+ CSAPAT HOZZÁADÁSA">
					</form>
					
				</div>
				
				<hr>
				
				<table>
					<tr>
						<th>Csapat</th>
						<th colspan="3">Tagok</th>
						<th>Projekt megnevezése</th>
						<th>Állapot</th>
					</tr>
					
					<?php 
						$lekerdezes = "SELECT * FROM teams";
						$csapatok = $conn->query($lekerdezes);
						while($csapat=$csapatok->fetch_assoc()){
					?>
					
						<tr>
							<th><?= $csapat['name']; ?></th>
							
							<?php 
								$lekerdezes = "SELECT * FROM users WHERE id=$csapat[member1id]";
								$felhasznalo = $conn->query($lekerdezes);
								$tag = $felhasznalo->fetch_assoc();
							?>
							<th><?= $tag['username']; ?></th>
							
							<?php 
								$lekerdezes = "SELECT * FROM users WHERE id=$csapat[member2id]";
								$felhasznalo = $conn->query($lekerdezes);
								$tag = $felhasznalo->fetch_assoc();
							?>
							<th><?= $tag['username']; ?></th>
							
							<?php 
								$lekerdezes = "SELECT * FROM users WHERE id=$csapat[member3id]";
								$felhasznalo = $conn->query($lekerdezes);
								$tag = $felhasznalo->fetch_assoc();
							?>
							<th><?= $tag['username']; ?></th>
							
							
							<th><?= $csapat['about']; ?></th>
							<th>
								<progress value="32" max="100"></progress> 50%
							</th>
						</tr>
					<?php } ?>
					
				</table>
				
			</div>
		
		</section>

	</body>

</html>