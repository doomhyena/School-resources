<?php 

	if(isset($_POST['reg-btn'])){
		
		echo "Felhasználónév: ".$_POST['felhasznalonev']."<br>";
		echo "Jelszó: ".$_POST['jelszo']."<br><br>";
		
	}

?>

<form method="post">

	<input type="text" name="felhasznalonev" placeholder="Felhasználónév">
	
	<br><br>
	
	<input type="text" name="jelszo" placeholder="Jelszó">
	
	<br><br>
	
	<input type="submit" name="reg-btn" value="Regisztráció">

</form>