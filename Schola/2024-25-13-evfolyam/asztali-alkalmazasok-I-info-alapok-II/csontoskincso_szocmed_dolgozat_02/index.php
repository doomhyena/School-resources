<?php 

	require "config.php";
	
	session_start();
	
	if(!isset($_SESSION['id'])){
		
		header("Location: reg.php");
		
	} else {
	
		$id = $_SESSION['id'];
		$lekerdezes = "SELECT * FROM users WHERE id=$id";
		$talalt_felhasznalo = $conn->query($lekerdezes);
		$felhasznalo = $talalt_felhasznalo->fetch_assoc();
		
		echo "<h1>Üdv, $felhasznalo[username]!</h1>";
		
	}
	
	if(isset($_POST['post-btn'])){
		
		$userid = $_SESSION['id'];
		$szoveg = $_POST['szoveg'];
		
		$conn->query("INSERT INTO posztok VALUES(id, '$userid', '$szoveg')");
		
	}
	
	if(isset($_POST['like-btn'])){
		
		$posztid = $_GET['posztid'];
		
		$conn->query("INSERT INTO likes VALUES(id, $id, $posztid)");
		
	}
	
	if(isset($_POST['dislike-btn'])){
		
		$posztid = $_GET['posztid'];
		
		$conn->query("DELETE FROM likes WHERE postid=$posztid AND userid=$id");
		
	}

?>

<hr>

	<form method="post">
		<input type="text" name="szoveg" placeholder="Írj egy posztot">
		<input type="submit" name="post-btn">
	</form>

<h2>Posztok</h2>

<?php 

	$lekerdezes = "SELECT * FROM posztok ORDER BY id DESC";
	$talalt_posztok = $conn->query($lekerdezes);
	while($poszt=$talalt_posztok->fetch_assoc()){
			
		$lekerdezes = "SELECT * FROM users WHERE id=$poszt[userid]";
		$talalt_iro = $conn->query($lekerdezes);
		$iro = $talalt_iro->fetch_assoc();
		
		echo '<p>';
		echo "<a href='profil.php?userid=$iro[id]'>".$iro['username']."</a>: ";
		echo $poszt['szoveg'];		
		
		$lekerdezes = "SELECT * FROM likes WHERE postid=$poszt[id]";
		$talalt_kedveles = $conn->query($lekerdezes);
		
		$likeok_szama = mysqli_num_rows($talalt_kedveles);
		
		echo "<br>";
		echo "$likeok_szama kedvelés";
		
		echo "<form method='post' action='index.php?posztid=$poszt[id]'>";
							
				$lekerdezes = "SELECT * FROM likes WHERE userid=$id AND postid=$poszt[id]";
				$talalt_kedveles = $conn->query($lekerdezes);
				
				if(mysqli_num_rows($talalt_kedveles) == 0){
					
					echo "<input type='submit' name='like-btn' value='Like'>";
					
				} else {
					
					echo "<input type='submit' name='dislike-btn' value='Dislike'>";
				
				}
			echo "</form>";
			echo "</p>";
	}
	
?>