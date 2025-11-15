$("#text").load("findtext.php?keresett=");
	
document.getElementById("search-box").addEventListener('keyup', (e) => {
		
	var ertek = e.target.value;
		
	$("#users").load("findtext.php?keresett="+ertek);
		
});