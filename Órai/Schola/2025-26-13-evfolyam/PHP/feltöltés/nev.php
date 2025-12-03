<?php 

	session_start();
	
	if(isset($_POST['gomb'])){
		
		$_SESSION['nev'] = $_POST['nev'];
		
		header("Location: index.php");
		
	}

?>

<form method="post">

	<input type="text" name="nev">
	
	<input type="submit" name="gomb">

</form>