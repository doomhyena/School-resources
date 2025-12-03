<?php 

	require "config.php";
	
	require "functions.php";
	
	session_start();
	
	$code = rand(100000, 999999);
	
	$kinek = $_SESSION['email'];
	$targy = "Bejelentkezés";
	$uzenet = '<body style="margin: 0;padding: 0;">

	<div style="padding: 10px;background: black;text-align: center;">
		<h2 style="color: white;font-family: sans-serif;">Bejelentkezés</h2>
	</div>
	
	<div style="padding: 10px;">
	
		<h2 style="font-family: sans-serif;">Kedves '.$_SESSION['username'].'!</h2>
		
		<p style="font-family: sans-serif;">A bejelentkezéshez szükséges kódod:</p>
		
		<a style="font-family: sans-serif;font-weight: bold;">'.$code.'</a>
		
		<p style="font-family: sans-serif;">Amennyiben nem ön kérte ezt az emailt, hagyja figyelmen kívül.</p>
	
	</div>

</body>';
	
	$fejlec = "From: Oldalam Noreply"."\r\n";
	$fejlec .= "MIME-Version: 1.0\r\n";
	$fejlec .= "Content-type: text/html; charset=UTF-8"."\r\n";
	
	if(mail($kinek, $targy, $uzenet, $fejlec)){
		
		$conn->query("INSERT INTO logincode VALUES(id, $_SESSION[id], '$code', 0)");
		
		header("Location: active.php");
		
	}
	else{
		header("Location: login.php");
	}

?>