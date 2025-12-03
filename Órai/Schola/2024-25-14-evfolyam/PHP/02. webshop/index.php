<?php 

	require "config.php";
	
	session_start();
	
	if(!isset($_SESSION['kosar'])){
		$_SESSION['kosar'] = array();
	}
	
	$kosar_tartalma = count($_SESSION['kosar']);
	
	echo "<a href='cart.php'>A kosaradban $kosar_tartalma termék található.</a><br><br>";
	
	// RENDEZÉS
	
	// Alap rendezési szempont
	$rendezes = "default";
	
	if($_SERVER['REQUEST_METHOD'] == "POST"){
		$rendezes = $_POST['sorter'];
	}
	
	if($rendezes == "default"){
		$lekerdezes = "SELECT * FROM termekek ORDER BY ordered DESC";
	}
	else if($rendezes == "price_up"){
		$lekerdezes = "SELECT * FROM termekek ORDER BY price";
	}
	else if($rendezes == "price_down"){
		$lekerdezes = "SELECT * FROM termekek ORDER BY price DESC";
	}
	else if($rendezes == "name_down"){
		$lekerdezes = "SELECT * FROM termekek ORDER BY name";
	}
	else if($rendezes == "name_up"){
		$lekerdezes = "SELECT * FROM termekek ORDER BY name DESC";
	}
	
	$termekek = $conn->query($lekerdezes);
	while($termek=$termekek->fetch_assoc()){
		
		if($termek['on_sale'] == 0){
			
			echo "<a href='product.php?productid=$termek[id]'>$termek[name] - $termek[price] Ft</a><br>";
		
		}
		else{
			
			echo "<a href='product.php?productid=$termek[id]'>$termek[name] - <del>$termek[price] Ft</del> - $termek[sale_price] Ft</a><br>";
			
		}
	}

?>
<br>
<br>
<form method="post">
	<select name="sorter" selected="selected" onchange="this.form.submit()">
		<option value="default"
		<?php 
			if($rendezes == "default"){
				echo " selected";
			}
		?>
		>Népszerűség szerint</option>
		<option value="price_up"
		<?php 
			if($rendezes == "price_up"){
				echo " selected";
			}
		?>
		>Ár szerint növekvő</option>
		<option value="price_down"
		<?php 
			if($rendezes == "price_down"){
				echo " selected";
			}
		?>
		>Ár szerint csökkenő</option>
		<option value="name_down"
		<?php 
			if($rendezes == "name_down"){
				echo " selected";
			}
		?>
		>A-Z</option>
		<option value="name_up"
		<?php 
			if($rendezes == "name_up"){
				echo " selected";
			}
		?>
		>Z-A</option>
	</select>
</form>