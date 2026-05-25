<?php 

	require "config.php";
	
	if(!isset($_COOKIE['id'])){
		header("Location: index.php");
	}
	else{
		$lekerdezes = "SELECT * FROM users WHERE id=$_COOKIE[id]";
		$talalt = $conn->query($lekerdezes);
		$felh = $talalt->fetch_assoc();
	}
	
	if(isset($_POST['file-btn'])){
		
		$file_name = $_FILES['file-name']['name'];
		$tmp_name = $_FILES['file-name']['tmp_name'];
		
		$mappa = getcwd();
		
		$eleres = $mappa."//users//".$felh['username']."//".$file_name;
		
		if(move_uploaded_file($tmp_name, $eleres)){
			echo "<script>alert('A fájl feltöltése sikeres!')</script>";
		}
		else{
			echo "<script>alert('A fájl feltöltése sikertelen!')</script>";
		}
		
	}

?>
<h1>Üdv, <?= $felh['username']; ?>!</h1>

<form method="post" enctype="multipart/form-data">
	
	<input type="file" name="file-name">
	
	<input type="submit" name="file-btn" value="Feltöltés">
	
</form>