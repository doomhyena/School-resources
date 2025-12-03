<?php 

	require "config.php";
	
	require "functions.php";
	
	session_start();
	
	$code = codeGenerator();
	
	while(mysqli_num_rows($talalt=$conn->query("SELECT * FROM codes WHERE code='$code'")) == 1){
		
		$code = codeGenerator();
		
	}
	
	$kinek = $_SESSION['email'];
	$targy = "Elfelejtett jelszó";
	$uzenet = '<body style="margin: 0;padding: 0;">

	<div style="padding: 10px;background: black;text-align: center;">
		<h2 style="color: white;font-family: sans-serif;">Elfelejtett jelszó</h2>
	</div>
	
	<div style="padding: 10px;">
	
		<h2 style="font-family: sans-serif;">Kedves '.$_SESSION['username'].'!</h2>
		
		<p style="font-family: sans-serif;">Jelszava megváltoztatásáért kérem kattintson az alábbi linkre:</p>
		
		<a href="localhost/14b/email%20reg/new-pass.php?code='.$code.'" style="font-family: sans-serif;">Jelszó megváltoztatása</a>
		
		<p style="font-family: sans-serif;">Amennyiben nem ön kérte ezt az emailt, hagyja figyelmen kívül.</p>
	
	</div>

</body>';
	
	$fejlec = "From: Oldalam Noreply"."\r\n";
	$fejlec .= "MIME-Version: 1.0\r\n";
	$fejlec .= "Content-type: text/html; charset=UTF-8"."\r\n";
	
	if(mail($kinek, $targy, $uzenet, $fejlec)){
		
		$conn->query("INSERT INTO codes VALUES(id, $_SESSION[id], '$code', 0)");
		
		session_destroy();
		
		header("Location: login.php");
		
	}
	else{
		header("Location: forgot-pass.php");
	}

?>