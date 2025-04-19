<?php 

	require "config.php";
	
	session_start();
	
	$productid = $_GET['productid'];
	
	// Termék elhelyezése a Kosárba
	if(isset($_POST['add-to-cart-btn'])){
		
		// Ha nincs megadott méret, beállítjuk a $_POST['size']-t 0-ra
		if(!isset($_POST['size'])){
			$_POST['size'] = 0;
		}
		
		$elerhetoe = true;
		
		if($_POST['size'] == 0){
			
			$lekerdezes = "SELECT * FROM termekek WHERE id=$productid";
			$talalt_termek = $conn->query($lekerdezes);
			$termek = $talalt_termek->fetch_assoc();
			
			if($termek['quantity'] < $_POST['quantity']){
				
				$elerhetoe = false;
				
			}
			
		}
		else{
			
			$lekerdezes = "SELECT * FROM meretek WHERE id=$_POST[size]";
			$talalt_termek = $conn->query($lekerdezes);
			$termek = $talalt_termek->fetch_assoc();
			
			if($termek['quantity'] < $_POST['quantity']){
				
				$elerhetoe = false;
				
			}
			
		}
		
		if($elerhetoe == true){
			
			$vane = false;
			
			for($i=0;$i<count($_SESSION['kosar']);$i++){
				
				if($_SESSION['kosar'][$i]['id'] == $productid && $_SESSION['kosar'][$i]['sizeid'] == $_POST['size']){
					
					$_SESSION['kosar'][$i]['quantity'] += $_POST['quantity'];
					$vane = true;
					
				}
				
			}
			
			if($vane == false){
			
				// Termék feltöltése
				array_push($_SESSION['kosar'], array("id" => $productid, "sizeid" => $_POST['size'], "quantity" => $_POST['quantity']));
			
			}
			
		}
		else{
			echo "<script>A termékből nincs ennyi raktáron!</script>";
		}
	}
	
	if(!isset($_SESSION['kosar'])){
		$_SESSION['kosar'] = array();
	}
	
	// Kosár tartalmának kiírása
	$kosar_tartalma = count($_SESSION['kosar']);
	
	echo "<a href='cart.php'>A kosaradban $kosar_tartalma termék található.</a><br><br>";
	
	// Leékrdezzük a megfelelő termék adatait
	$lekerdezes = "SELECT * FROM termekek WHERE id=$productid";
	$talalt_termek = $conn->query($lekerdezes);
	$termek = $talalt_termek->fetch_assoc();
	
	if($termek['on_sale'] != 1){
		echo "$termek[name]<br>$termek[price] Ft<br><br>";
	}
	else{
		echo "$termek[name]<br><del>$termek[price] Ft</del><br>$termek[sale_price] Ft<br><br>";
	}
	
	// Űrlap a kosárba helyezéshez
	echo "<form method='post' action='product.php?productid=$productid'>";
	
	// Megvizsgáljuk, hogy van-e mérete a terméknek, és csak akkor jelenik meg a select menü, ha találtunk
	$lekerdezes = "SELECT * FROM meretek WHERE productid=$productid";
	$talalt_meretek = $conn->query($lekerdezes);
	
	if(mysqli_num_rows($talalt_meretek)>0){
	
		echo "<label>Válassz méretet!</label><br>";
		echo "<select name='size'>";
		
			$lekerdezes = "SELECT * FROM meretek WHERE productid=$productid";
			$talalt_meretek = $conn->query($lekerdezes);
			while($meret=$talalt_meretek->fetch_assoc()){
				
				if($meret['quantity'] > 0){
					echo "<option value='$meret[id]'>".$meret['size_name']."</option>";
				}
				
			}
			
		echo "</select><br><br>";
		
	}
	
	// Termék darabszámának a megadása
	echo "<input name='quantity' type='number' value='1'><br><br>";
	echo "<input name='add-to-cart-btn' type='submit' value='Kosárba!'>";
		
	echo "</form>";


?>