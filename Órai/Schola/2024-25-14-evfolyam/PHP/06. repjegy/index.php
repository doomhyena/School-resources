<?php 

	require "config.php";
	
?>

<form method="post">

	<label>Induló reptér</label>
	
	<br><br>
	
	<select name="from_city">
		<?php 
			// Városok kilistázása lekérdezéssel
			$lekerdezes = "SELECT * FROM utak GROUP BY from_city";
			$talalt_varosok = $conn->query($lekerdezes);
			while($varos=$talalt_varosok->fetch_assoc()){
		?>
		
			<option value="<?= $varos['from_city']; ?>"><?= $varos['from_city']; ?></option>
			
		<?php 
			}
		?>
	</select>
	
	<br><br>
	
	<label>Cél reptér</label>
	
	<br><br>
	
	<select name="to_city">
		<?php 
			// Városok kilistázása lekérdezéssel
			$lekerdezes = "SELECT * FROM utak GROUP BY from_city";
			$talalt_varosok = $conn->query($lekerdezes);
			while($varos=$talalt_varosok->fetch_assoc()){
		?>
		
			<option value="<?= $varos['from_city']; ?>"><?= $varos['from_city']; ?></option>
			
		<?php 
			}
		?>
	</select>
	
	<br><br>
	
	<input type="submit" name="search-btn" value="Keresés">

</form>

<?php 

	if(isset($_POST['search-btn'])){
		
		$lekerdezes = "SELECT * FROM utak WHERE from_city='$_POST[from_city]' AND to_city='$_POST[to_city]' OR from_city='$_POST[to_city]' AND to_city='$_POST[from_city]'";
		$talalt_utak = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt_utak) > 0){
			
			$ut = $talalt_utak->fetch_assoc();
			
			for($i=0;$i<2;$i++){
				
				$price = $ut['price'] - rand(10000, $ut['price']/2);
				
				echo $_POST['from_city']." - ".$_POST['to_city']." - ".$price." Ft<br>";
				
			}
			
			echo $_POST['from_city']." - ".$_POST['to_city']." - ".$ut['price']." Ft<br>";
			
			for($i=0;$i<2;$i++){
				
				$price = $ut['price'] + rand(10000, $ut['price']/2);
				
				echo $_POST['from_city']." - ".$_POST['to_city']." - ".$price." Ft<br>";
				
			}
			
		}
		else{
			
			echo "<script>alert('Sajnos nem találtunk ilyen utat...')</script>";
			
		}
		
	}

?>