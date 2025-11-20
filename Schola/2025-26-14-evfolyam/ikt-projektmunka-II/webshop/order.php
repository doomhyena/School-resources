<?php 

	require "config.php";
	
	session_start();
	
	if(!isset($_SESSION['kosar'])){
		$_SESSION['kosar'] = [];
	}

	echo "<a href='index.php'>Főoldal</a> ";
	echo "<a href='cart.php'>Kosár ".count($_SESSION['kosar'])." </a> ";
	echo "<a href='order.php'>Rendelés követése</a>";
	echo "<br><br>";


?>
<form method="post">
	<input type="text" name="code" placeholder="Rendelésed kódja">
	<input type="submit" name="code-btn">
</form>
<?php 

	if(isset($_POST['code-btn'])){
		
		header("Location: order.php?ordercode=$_POST[code]");
		
	}
	
	if(isset($_GET['ordercode'])){
		
		echo "<b>Rendelés kódja: ".$_GET['ordercode']."</b><br><br>";
		
		$lekerdezes = "SELECT * FROM orders WHERE code = '$_GET[ordercode]'";
		$talalt = $conn->query($lekerdezes);
		
		if(mysqli_num_rows($talalt) > 0){
			
			$rendeles = $talalt->fetch_assoc();
			
			$termekek = explode(";", $rendeles['products']);
			
			print_r($termekek);
			
		}
		else{
			echo "<b style='color: red'>Nincs rendelés ilyen azonosítóval!</b>";
		}
		
	}

?>