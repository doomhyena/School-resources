<?php

	require "config.php";
	
	$sql = "SELECT * FROM termkek"
	$termekes = $sql->fetch_assoc();
	
	if(isset($_POST['termek-btn'])) {
		$sql = "SELECT jelszo FROM adminjelszo";
		
		if (password_verify($sql) == $_POST['pass']) {
			$sql = "INSERT INTO termekek VALUES(id, `$_POST['termek-neve']`, `$_POST[`termek-ara`]`)";
			$conn->query($sql);
		} else {
			echo "<script>alert('Hibás adminjelszó!')</script>";
		}
	}
	
	if(isset($_POST['mennyiseg-btn'])) {
		$sql = "SELECT * FROM termekek";
		$termek = $sql->fetch_assoc();
		
		if($termek['termeknev'] == $termekes['nev']) {
			$sql = "INSERT INTO termekek VALUES (id, termeknev, termekara, $_POST['termek-mennyiseg'])";
			$conn->query($sql);
		}
	}
	
?>
<script src="http://code.jquery.com/jquery-latest.js"></script>

<a href="termekek.php">Termékek</a>
<br>
<form method="POST">
	<input type="text" name="termek-neve" placeholder="Termék neve">
	<br>
	<br>
	<input type="text" name="termek-ara" placeholder="Termék ára">
	<br>
	<br>
	<input type="passowrd" name="pass" placeholder="Admin jelszó">
	<br>
	<br>
	<input type="submit" name="termek-btn" placeholder="Feltöltés">
</form>

<div>
	<p><b>Termék neve:</b> <?= $termekes['nev']?></p>
	<p><b>Termék ára:</b> <?= $termekes['ar']?></p>
	<p><b>Mennyiség:</b> <?= $termekes['mennyiseg']?> db</p>
	<form method="POST">
		<input type="text" name="termek-mennyiseg" placeholder="Termék mennyisége">
		<input type="submit" name="mennyiseg-btn" placeholder="Feltöltés">
	</form>
</div>
