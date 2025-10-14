<?php 

	// <input type="text" name="szoveg"> ---> $_POST['szoveg'] = (a felhasználó által az input boxba beírt adat)
	// <input type="submit" name="gomb"> ---> $_POST['gomb']
	
	if(isset($_POST['gomb'])){
		
		echo $_POST['szoveg'];
	
	}

?>

<form method="post"> <!-- method="post" minden esetben! -->

	<label>Írj be valamit a szövegdobozba</label>
	
	<br><br>

	<input type="text" name="szoveg" placeholder="Írj ide valamit...">
	
	<br><br>
	
	<input type="submit" name="gomb">

</form>