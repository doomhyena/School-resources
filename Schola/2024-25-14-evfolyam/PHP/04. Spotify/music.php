<?php 

	require "config.php";

	$musicid = $_GET['musicid'];
	
	$lekerdezes = "SELECT * FROM music WHERE id=$musicid";
	$talalt_zene = $conn->query($lekerdezes);
	$zene = $talalt_zene->fetch_assoc();
	
	// Hozzáadás a kedvencekhez
	if(isset($_POST['add-fav-btn'])){
		$conn->query("INSERT INTO favs VALUES(id, $_COOKIE[id], $musicid)");
	}
	
	// Törlés a kedvencek közül
	if(isset($_POST['del-fav-btn'])){
		$conn->query("DELETE FROM favs WHERE userid=$_COOKIE[id] AND musicid=$musicid");
	}

	if(isset($_POST['add-m-btn'])){
		$conn->query("INSERT INTO musics_in_playlist VALUES(id, $_COOKIE[id], $_POST[list], $musicid)");
	}

?>
<p><?= $zene['name']; ?></p>
<audio controls>
	<source src="files/<?= $zene['file_name']; ?>" type="audio/mp3">
</audio>
<br>
<br>
<form method="post" action="music.php?musicid=<?= $musicid; ?>">
	<?php 
		$lekerdezes = "SELECT * FROM favs WHERE userid=$_COOKIE[id] AND musicid=$musicid";
		$talalt_kedvenc = $conn->query($lekerdezes);
		if(mysqli_num_rows($talalt_kedvenc) == 0){
			echo "<input type='submit' name='add-fav-btn' value='Hozzáadás a kedvencekhez!'>";
		}
		else{
			echo "<input type='submit' name='del-fav-btn' value='Törlés a kedvencek közül!'>";
		}
	?>
</form>
<br><br>
<form method="post" action="music.php?musicid=<?= $musicid; ?>">
	<select name="list">
		<?php 
			$lekerdezes = "SELECT * FROM playlists WHERE userid=$_COOKIE[id]";
			$talalt_listak = $conn->query($lekerdezes);
			while($lista = $talalt_listak->fetch_assoc()){
		?>
			<option value="<?= $lista['id']; ?>"><?= $lista['name']; ?></option>
		<?php } ?>
	</select>
	<input name="add-m-btn" type='submit' value="Hozzáadás a listához!">
</form>