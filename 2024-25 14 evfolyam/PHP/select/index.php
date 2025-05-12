<?php 

	require "config.php";
	
	$rendezes = "a_z";
	
	// Ha változtatás történt a select menübek
	if($_SERVER["REQUEST_METHOD"] == "POST"){
		
		$rendezes = $_POST['rendezes_szempont'];
		
	}
	
	// Megfelelő lekérdezés beállítása a kiválasztott rendezés alapján
	if($rendezes == "a_z"){
		$lekerdezes = "SELECT from_city FROM utak GROUP BY from_city ORDER BY from_city";
	}
	else if($rendezes == "z_a"){
		$lekerdezes = "SELECT from_city FROM utak GROUP BY from_city ORDER BY from_city DESC";
	}

?>

<form method="post">
	
	<label>Rendezés:</label>
	
	<select name="rendezes_szempont" selected="selected" onchange="this.form.submit()">

		<option value="-">-</option>

		<option value="a_z"
		<?php 
			if($rendezes == "a_z"){
				echo "selected";
			}
		?>>A - Z</option>
		<option value="z_a"
		<?php 
			if($rendezes == "z_a"){
				echo "selected";
			}
		?>>Z - A</option>
	
	</select>
	
</form>

<?php 

	$talalt_varosok = $conn->query($lekerdezes);
	while($varos=$talalt_varosok->fetch_assoc()){
		
		echo $varos['from_city']."<br>";
		
	}

?>