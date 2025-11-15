<?php 

	require "config.php";
	
	$teamid = $_GET['teamid'];
	
	// GET TASK
	if(isset($_POST['get-task'])){
		$conn->query("UPDATE tasks SET status='folyamatban', memberid=$_COOKIE[id] WHERE id=$_GET[taskid]");
	}
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
		<link rel="stylesheet" href="css/team-style.css">
		
		<!-- REFRESHER -->
		<!-- <meta http-equiv="refresh" content="2"> -->

	</head>

	<body>

		<!-- NAV -->
		<nav>
			<ul>
				<li><a class="left-menu">Csapatok</a></li>
				<li><a class="left-menu">Feladataim</a></li>
			</ul>
		</nav>
		
		<section id="content">
		
			<div class="boxes">
				
				<div class="inner-box">
					<div class="box-header" id="idea">
						<a class="box-header-text">Ötlet</a>
					</div>
					
					<?php 
						$lekerdezes = "SELECT * FROM tasks WHERE teamid=$teamid AND status='otlet'";
						$tasks = $conn->query($lekerdezes);
						while($task=$tasks->fetch_assoc()){
					?>
							<form class="new-idea" method="post" action="team.php?teamid=<?= $teamid; ?>&taskid=<?= $task['id']; ?>">
								<label><?= $task['name']; ?></label>
								<input type="submit" name="get-task" value="Elkezdem">
							</form>
					<?php } ?>
					
				</div>
				
				<div class="inner-box">
					<div class="box-header" id="inprogress">
						<a class="box-header-text">Folyamatban</a>
					</div>
					<table>
					
						<?php 
							$lekerdezes = "SELECT * FROM tasks WHERE teamid=$teamid AND status='folyamatban'";
							$tasks = $conn->query($lekerdezes);
							while($task=$tasks->fetch_assoc()){
						?>
					
						<tr>
							<td><?= $task['name']; ?></td>
							
							<?php 
								$lekerdezes = "SELECT * FROM users WHERE id=$task[memberid]";
								$talalt_felhasznalo = $conn->query($lekerdezes);
								$felhasznalo = $talalt_felhasznalo->fetch_assoc();
							?>
							
							<td style="text-align: right;"><?= $felhasznalo['username']; ?></td>
							
						</tr>
						<?php } ?>
					
					</table>
				</div>
				
				<div class="inner-box">
					<div class="box-header" id="testing">
						<a class="box-header-text">TESZTELÉS ALATT</a>
					</div>
					<table>
					
						<?php 
							$lekerdezes = "SELECT * FROM tasks WHERE teamid=$teamid AND status='teszteles'";
							$tasks = $conn->query($lekerdezes);
							while($task=$tasks->fetch_assoc()){
						?>
							<tr>
								<td><?= $task['name']; ?></td>
							
								<?php 
									$lekerdezes = "SELECT * FROM users WHERE id=$task[memberid]";
									$talalt_felhasznalo = $conn->query($lekerdezes);
									$felhasznalo = $talalt_felhasznalo->fetch_assoc();
								?>
								<td style="text-align: right;"><?= $felhasznalo['username']; ?></td>
							</tr>
							
						<?php } ?>
						
					</table>
				</div>
				
				<div class="inner-box">
					<div class="box-header" id="done">
						<a class="box-header-text">KÉSZ</a>
					</div>
					<table>
					
						<?php 
							$lekerdezes = "SELECT * FROM tasks WHERE teamid=$teamid AND status='kesz'";
							$tasks = $conn->query($lekerdezes);
							while($task=$tasks->fetch_assoc()){
						?>
					
							<tr>
								<td><?= $task['name']; ?></td>
							
								<?php 
									$lekerdezes = "SELECT * FROM users WHERE id=$task[memberid]";
									$talalt_felhasznalo = $conn->query($lekerdezes);
									$felhasznalo = $talalt_felhasznalo->fetch_assoc();
								?>
								<td style="text-align: right;"><?= $felhasznalo['username']; ?></td>
							</tr>
						<?php } ?>
					</table>
				</div>
				
			</div>
		
		</section>

	</body>

</html>