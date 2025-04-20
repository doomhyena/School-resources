<?php 

	$gameid = $_GET['gameid'];

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
	<div id="game"></div>
	
</body>
</html>
<script>

	setInterval(function(){
		
		$("#game").load("loadgame.php?gameid="+<?= $gameid; ?>);
		
	}, 1000);

</script>