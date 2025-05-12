<!-- JQuery -->
<script src="http://code.jquery.com/jquery-latest.js"></script>

<!-- Kereső mező -->
<input id="kereso" type="text" placeholder="Zene keresése">

<!-- Találatok betöltése -->
<div id="talalatok"></div>

<script>

	document.getElementById("kereso").addEventListener('keyup', (e)=>{
		
		const keresett = e.target.value.toLowerCase();
		
		$("#talalatok").load("findmusic.php?keresett="+keresett);
		
	});

</script>