<?php 

	require "config.php";
	
	session_start();
	
	if(!isset($_SESSION['kosar'])){
		$_SESSION['kosar'] = [];
	}
	
	echo "<a href='index.php'>Főoldal</a> ";
	echo "<a href='cart.php'>Kosár ".count($_SESSION['kosar'])." </a>";
	echo "<br><br>";
	
	$rendezes = "default";
	
	if($_SERVER['REQUEST_METHOD'] == "POST"){
		$rendezes = $_POST['sorter'];
	}

?>
<!DOCTYPE html>
<html lang="hu">
   <head>
	   <title>Főoldal</title>
	   <meta charset='UTF-8'>
	   <meta name='description' content='Rövid leírás az oldal tartalmáról'>
	   <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
	   <meta name='author' content='Csontos Kincső'>
	   <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
		<form method="post">
			<label>Rendezés: </label>
			<select name="sorter" selected="selected" onchange="this.form.submit()">
				<option value="default"
				<?php 
					if($rendezes == "default"){
						echo " selected";
					}
				?>>-</option>
				<option value="name"
				<?php 
					if($rendezes == "name"){
						echo " selected";
					}
				?>>Név szerint</option>
				<option value="cheap"
				<?php 
					if($rendezes == "cheap"){
						echo " selected";
					}
				?>>Olcsók elől</option>
				<option value="exp"
				<?php 
					if($rendezes == "exp"){
						echo " selected";
					}
				?>>Drágák elől</option>
				<option value="ordered"
				<?php 
					if($rendezes == "ordered"){
						echo " selected";
					}
				?>>Nepszerűség szerint</option>
			</select>
		</form>
   </body>
</html>
<?php 

	if($rendezes == "default"){
		$lekerdezes = "SELECT * FROM products";
	}
	else if($rendezes == "name"){
		$lekerdezes = "SELECT * FROM products ORDER BY name";
	}
	else if($rendezes == "cheap"){
		$lekerdezes = "SELECT * FROM products ORDER BY price";
	} else if($rendezes == "exp") {
		$lekerdezes = "SELECT * FROM products ORDER BY price DESC";
	} else {
		$lekerdezes = "SELECT * FROM products ORDER BY sold DESC";
	}
	$talalt = $conn->query($lekerdezes);
	while($termek=$talalt->fetch_assoc()){
		
		echo "<a href='product.php?id=$termek[id]'>";
		
		echo $termek['name']." ";
		
		if($termek['sale_price'] == 0){
			echo $termek['price']." Ft";
		}
		else{
			echo "<del>".$termek['price']." Ft</del> ".$termek['sale_price']." Ft";
		}
		
		echo "</a><br>";
		
	}


?>