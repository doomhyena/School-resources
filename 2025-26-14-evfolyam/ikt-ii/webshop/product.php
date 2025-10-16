<?php 

	require "config.php";
	
	session_start();
	
	if(!isset($_SESSION['kosar'])){
		$_SESSION['kosar'] = [];
	}
	
	echo "<a href='index.php'>Főoldal</a> ";
	echo "<a href='cart.php'>Kosár ".count($_SESSION['kosar'])." </a>";
	echo "<br><br>";
	
	// termék lekérdezése
	$lekerdezes = "SELECT * FROM products WHERE id=$_GET[id]";
	$talalt = $conn->query($lekerdezes);
	$termek = $talalt->fetch_assoc();
	
	// termék elhelyezése a kosárba
	if(isset($_POST['cart-btn'])){
		
		$uj_termek = ["id" => $termek['id'], "db" => $_POST['db']];
		
		array_push($_SESSION['kosar'], $uj_termek);
		
	}
	
	echo $termek['name']."<br>";
	
	if($termek['sale_price'] == 0){
		echo $termek['price']." Ft<br>";
	}
	else{
		echo "<del>".$termek['price']." Ft</del><br>".$termek['sale_price']." Ft<br>";
	}
	
	echo $termek['quantity']." db raktáron.<br><br>";

?>
<form method="post">
	<input type="number" name="db" value="1" min="1" max="<?= $termek['quantity']; ?>">
	<input type="submit" name="cart-btn" value="Kosárba">
<form>