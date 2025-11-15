<?php 

	require "config.php";
	
	require "functions.php";
	
	session_start();
	
	if(!isset($_SESSION['kosar'])){
		$_SESSION['kosar'] = [];
	}
	
	// Kosár törlése
	if(isset($_POST['del-btn'])){
		$_SESSION['kosar'] = [];
	}
	
	// rendelés
	if(isset($_POST['order-btn'])){
		
		$rendeles = "";
		
		$rendeles = $_SESSION['kosar'][0]['id']."-".$_SESSION['kosar'][0]['db'];
		
		if(count($_SESSION['kosar']) > 1){
			
			for($i=1;$i<count($_SESSION['kosar']);$i++){
			
				$rendeles .= ";";
				
				$termek = $_SESSION['kosar'][$i]['id']."-".$_SESSION['kosar'][$i]['db'];
				
				$rendeles .= $termek;
			
			}
		}
		
		$code = codeGenerator();
		
		$conn->query("INSERT INTO orders VALUES(id, '$rendeles', '$code')");
		
		$_SESSION['kosar'] = [];
		
		echo "<script>alert('A rendelésed azonosítója: $code')</script>";
		
	}
	
	echo "<a href='index.php'>Főoldal</a> ";
	echo "<a href='cart.php'>Kosár ".count($_SESSION['kosar'])." </a> ";
	echo "<a href='order.php'>Rendelés követése</a>";
	echo "<br><br>";
	
	$vegosszeg = 0;
	
	if(count($_SESSION['kosar']) > 0){
	
		for($i=0;$i<count($_SESSION['kosar']);$i++){
			
			$id = $_SESSION['kosar'][$i]['id'];
			
			$lekerdezes = "SELECT * FROM products WHERE id = $id";
			$talalt = $conn->query($lekerdezes);
			$termek = $talalt->fetch_assoc();
			
			echo $termek['name']." ";
			
			if($termek['sale_price'] == 0){
				echo $termek['price']*$_SESSION['kosar'][$i]['db']." Ft<br>";
				$vegosszeg += $termek['price']*$_SESSION['kosar'][$i]['db'];
			}
			else{
				echo $termek['sale_price']*$_SESSION['kosar'][$i]['db']." Ft<br>";
				$vegosszeg += $termek['sale_price']*$_SESSION['kosar'][$i]['db'];
			}   
			
		}
		
		echo "Végösszeg: ".$vegosszeg." Ft";
	
	}else{
		echo "A kosár üres.";
	}
	
	echo "<br><br>";
	
	
	if(count($_SESSION['kosar']) > 0){
?>
<form method="post">
	<input type="submit" name="order-btn" value="Megrendelés">
	<input type="submit" name="del-btn" value="Kosár törlése">
</form>

<?php } ?>