<?php 

	require "config.php";
	
	require "functions.php";
	
	session_start();
	
	if(!isset($_SESSION['kosar'])){
		$_SESSION['kosar'] = array();
	}

	// Kosár törlése
	if(isset($_POST['del-cart-btn'])){
		$_SESSION['kosar'] = array();
	}
	
	// Rendelés véglegesítése
	if(isset($_POST['finish-btn'])){
		
		$rendelt_termekek = "";
		
		$rendelt_termekek .= $_SESSION['kosar'][0]['id']."-";
		
		$rendelt_termekek .= $_SESSION['kosar'][0]['sizeid']."-";
		
		$rendelt_termekek .= $_SESSION['kosar'][0]['quantity']."-";
		
		$productid = $_SESSION['kosar'][0]['id'];
		
		$sizeid = $_SESSION['kosar'][0]['sizeid'];
		
		$quantity = $_SESSION['kosar'][0]['quantity'];
		
		$conn->query("UPDATE termekek SET ordered=ordered+$quantity WHERE id=$productid");
		
		if($sizeid == 0){
			$conn->query("UPDATE termekek SET quantity=quantity-$quantity WHERE id=$productid");
		}
		else{
			$conn->query("UPDATE meretek SET quantity=quantity-$quantity WHERE id=$sizeid");
		}
		
		$lekerdezes = "SELECT * FROM termekek WHERE id=$productid";
		$talalt_termek = $conn->query($lekerdezes);
		$termek = $talalt_termek->fetch_assoc();
		
		if($termek['on_sale'] == 1){
			
			$rendelt_termekek .= $termek['sale_price'];
			
		}
		else{
			
			$rendelt_termekek .= $termek['price'];
			
		}
		
		for($i=1;$i<count($_SESSION['kosar']);$i++){
			
			$rendelt_termekek .= ";";
			
			$rendelt_termekek .= $_SESSION['kosar'][$i]['id']."-";
		
			$rendelt_termekek .= $_SESSION['kosar'][$i]['sizeid']."-";
			
			$rendelt_termekek .= $_SESSION['kosar'][$i]['quantity']."-";
			
			$productid = $_SESSION['kosar'][$i]['id'];
		
			$sizeid = $_SESSION['kosar'][$i]['sizeid'];
			
			$quantity = $_SESSION['kosar'][$i]['quantity'];
			
			$conn->query("UPDATE termekek SET ordered=ordered+$quantity WHERE id=$productid");
			
			if($sizeid == 0){
				$conn->query("UPDATE termekek SET quantity=quantity-$quantity WHERE id=$productid");
			}
			else{
				$conn->query("UPDATE meretek SET quantity=quantity-$quantity WHERE id=$sizeid");
			}
			
			$productid = $_SESSION['kosar'][$i]['id'];
			
			$lekerdezes = "SELECT * FROM termekek WHERE id=$productid";
			$talalt_termek = $conn->query($lekerdezes);
			$termek = $talalt_termek->fetch_assoc();
			
			if($termek['on_sale'] == 1){
				
				$rendelt_termekek .= $termek['sale_price'];
				
			}
			else{
				
				$rendelt_termekek .= $termek['price'];
				
			}
			
		}
		
		$code = codeGenerator();
		
		$conn->query("INSERT INTO rendelesek VALUES(id, '$code', '$rendelt_termekek', 'új')");
		
		$_SESSION['kosar'] = array();
		
		header("Location: rendelesed.php?code=$code");
		
	}

	echo "<h1>A kosarad tartalma</h1>";
	
	$tartalom = count($_SESSION['kosar']);
	
	if($tartalom > 0){
		
		$vegosszeg = 0;
		
		foreach($_SESSION['kosar'] as $termek){
			
			$lekerdezes = "SELECT * FROM termekek WHERE id=$termek[id]";
			$talalt_termek = $conn->query($lekerdezes);
			$lekerdezett_termek = $talalt_termek->fetch_assoc();
			
			$osszeg = $lekerdezett_termek['price']*$termek['quantity'];
			
			$vegosszeg += $osszeg;
			
			if($termek['sizeid'] != 0){
			
				$lekerdezes = "SELECT * FROM meretek WHERE id=$termek[sizeid]";
				$talalt_meret = $conn->query($lekerdezes);
				$meret = $talalt_meret->fetch_assoc();
			
				echo $lekerdezett_termek['name']." ".$meret['size_name']." ".$termek['quantity']." ".$osszeg." Ft<br>";
			
			}
			else{
				
				echo $lekerdezett_termek['name']." - ".$termek['quantity']." ".$osszeg." Ft<br>";
				
			}
			
		}
		
		echo "Végösszeg: $vegosszeg Ft<br><br>";
		
		echo "<form method='post' action='cart.php'>
					<input name='finish-btn' type='submit' value='vásárlás véglegsítése'><br><br>
					<input name='del-cart-btn' type='submit' value='Kosár tötlése'>
				</form>";
		
	}
	else{
		
		echo "Üres a kosarad...";
		
	}

?>