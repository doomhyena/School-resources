<?php 

	// phpora2024@gmail.com
	
	$kinek = "phpora2024@gmail.com";
	$targy = "HujberB - Első email";
	$uzenet = '<img src="https://www.google.com/imgres?q=alma&imgurl=https%3A%2F%2Fstatic.starkl.com%2Ffiles%2Fpic%2Fpic_zbozi%2F160320.webp&imgrefurl=https%3A%2F%2Fwww.starkl.hu%2Fflorina-teli-alma-7010352000000104838%3Fsrsltid%3DAfmBOooRC-JZeH0ohiGcK6TOkPT0LXdisjf1hs4iRvQ_JCwetdHD_upz&docid=BU8HNAecm1ifvM&tbnid=sDDDpeHFIRGyQM&vet=12ahUKEwikgsjspvuQAxU_gf0HHTsYDOoQM3oECBoQAA..i&w=500&h=600&hcb=2&ved=2ahUKEwikgsjspvuQAxU_gf0HHTsYDOoQM3oECBoQAA">';
	
	$fejlec = "From: Hujber Balázs"."\r\n";
	$fejlec .= "MIME-Version: 1.0"."\r\n";
	$fejlec .= "Content-type: text/html; charset=UTF-8"."\r\n";
	
	if(mail($kinek, $targy, $uzenet, $fejlec)){
		echo "Email sikeresen elküldve!";
	}
	else{
		echo "Valami hiba történt...";
	}

?>