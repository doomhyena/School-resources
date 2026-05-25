<!-- JQUery -->
<script src="http://code.jquery.com/jquery-latest.js"></script>

<input type="text" placeholder="Keresés" id="kereso">

<br><br>

<div id="divBetoltesre"></div>

<script>

	document.getElementById("kereso").addEventListener('keyup', (e) => {
		
		var bevitt_szoveg = e.target.value;
		
		$("#divBetoltesre").load("findszam.php?keresett="+bevitt_szoveg);
		
		// bevitt szoveg = 456
		
		// --> load("findszam.php?keresett=456")
		
	});

</script>