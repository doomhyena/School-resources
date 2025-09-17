<!-- JQUery -->
<script src="http://code.jquery.com/jquery-latest.js"></script>

<input type="text" placeholder="Keresés..." id="kereso">

<div id="talalatok"></div>

<?php

	require "config.php";

	if(isset($_GET['keresett'])){
		require "findpost.php";
	}


?>


<script>

	document.getElementById("kereso").addEventListener('keyup', (e) => {
		
		var ertek = e.target.value;
		
		$("#talalatok").load("findpost.php?keresett="+ertek)
		
	});

</script>