<?php 

	session_start();
	
	$kinek = $_SESSION['email'];
	$targy = "Sikeres regisztráció!";
	$uzenet = '<body style="margin: 0;padding: 0;">

	<div style="padding: 10px;background: black;text-align: center;">
		<h2 style="color: white; font-family: sans-serif;">Sikeres regisztráció</h2>
	</div>
	
	<div style="padding: 10px;">
	
		<h2 style="font-family: sans-serif;">Kedves '.$_SESSION['username'].'!</h2>
		
		<p style="font-family: sans-serif;">Regisztrációja aktiválásáért kérem kattintson az alábbi linkre:</p>
		
		<a href="#" style="font-family: sans-serif;">Regisztráció befejezése</a>
		
	</div>

</body>';
	
	$fejlec = "From: Oldalam\r\n";
	$fejlec .= "MIME-Version: 1.0\r\n";
	$fejlec .= "Content-type: text/html; charset=UTF-8\r\n";
	
	if(mail($kinek, $targy, $uzenet, $fejlec)){
		session_destroy();
		header("Location: index.php");
	}
	else{
		header("Location: reg.php");
	}

?>