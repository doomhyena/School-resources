<?php 



?>

<!-- JQUery -->
<script src="http://code.jquery.com/jquery-latest.js"></script>

<!-- FONT AWESOME -->
<script src="https://kit.fontawesome.com/086e7cefb3.js" crossorigin="anonymous"></script>

<h1>Regisztráció</h1>

<form>

	<input type="email" id="email-input" placeholder="pelda@pelda.hu">
	
	<br>
	<label id="email-msg"></label>
	<br>
	
	<input type="text" placeholder="Felhasználónév">
	
	<br><br>
	
	<input type="password" id="pass1" placeholder="Jelszó">
	
	<br><br>
	
	<label id="length"><span id="length-check"></span> A jelszó legyen minimum 8 karakter hosszú!</label>
	
	<br>
	
	<label id="upper"><span id="upper-check"></span> A jelszó tartalmazzon minimum egy nagybetűt!</label>
	
	<br>
	
	<label id="number"><span id="number-check"></span> A jelszó tartalmazzon minimum egy számot!</label>
	
	<br><br>
	
	<input type="password" id="pass2" placeholder="Jelszó újra">
	
	<br><br>
	
	<input type="checkbox" onchange="showPass()"> <label>Jelszó megjelenítése</label>
	
	<br><br>
	
	<input type="submit" value="Regisztrálok!">

</form>

<script>

	// Nagybetű vizsgálat
	function containsUpper(str){
		return /[A-Z]/.test(str);
	}
	
	// Számok vizsgálata
	function containsNumber(str){
		return /\d/.test(str);
	}

	document.getElementById("email-input").addEventListener('keyup', (e)=>{
		
		const email = e.target.value.toLowerCase();
		$("#email-msg").load("findemail.php?keresett="+email);
		
	});
	
	document.getElementById("pass1").addEventListener('keyup', (e)=>{
		
		var password = e.target.value;
		var lengthText = document.getElementById("length");
		var upperText = document.getElementById("upper");
		var numberText = document.getElementById("number");
		
		// Hossz 
		if(password.length >= 8){
			
			document.getElementById("length-check").innerHTML = '<i class="fa-solid fa-check"></i>';
			lengthText.style.color = "green";
			
		}
		else{
			
			document.getElementById("length-check").innerHTML = '<i class="fa-solid fa-x"></i>';
			lengthText.style.color = "red";
			
		}
		
		// Nagybetű
		if(containsUpper(password)){
			
			document.getElementById("upper-check").innerHTML = '<i class="fa-solid fa-check"></i>';
			upperText.style.color = "green";
			
		}
		else{
			
			document.getElementById("upper-check").innerHTML = '<i class="fa-solid fa-x"></i>';
			upperText.style.color = "red";
			
		}
		
		// Szám
		if(containsNumber(password)){
			
			document.getElementById("number-check").innerHTML = '<i class="fa-solid fa-check"></i>';
			numberText.style.color = "green";
			
		}
		else{
			
			document.getElementById("number-check").innerHTML = '<i class="fa-solid fa-x"></i>';
			numberText.style.color = "red";
			
		}
		
		passCheck();
		
	});
	
	document.getElementById('pass2').addEventListener('keyup', (e)=>{
		
		passCheck();
		
	});
	
	function passCheck(){
		
		var passBox = document.getElementById('pass1');
		var passreBox = document.getElementById('pass2');
		
		var password = document.getElementById('pass1').value;
		var passwordre = document.getElementById('pass2').value;
		
		if(password == passwordre){
			
			passBox.style.border = "2px solid green";
			passreBox.style.border = "2px solid green";
			
		}
		else{
			
			passBox.style.border = "2px solid red";
			passreBox.style.border = "2px solid red";
			
		}
		
	}
	
	function showPass(){
		
		var passBox = document.getElementById('pass1');
		var passreBox = document.getElementById('pass2');
		
		if(passBox.type == "password"){
			passBox.type = "text";
			passreBox.type = "text";
		}
		else{
			passBox.type = "password";
			passreBox.type = "password";
		}
		
	}

</script>