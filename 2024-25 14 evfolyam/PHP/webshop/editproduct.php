<?php 

    require "config.php";

    $productid = $_GET['productid'];


    if(isset($_POST['save-product-btn'])){
        $conn->query("UPDATE termekek SET name='$_POST[name]', quantity=$_POST[quantity], price=$_POST[price], on_sale=$_POST[on_sale], sale_price=$_POST[sale_price] WHERE id=$productid");
        header("Location: admin.php");
    }

    $lekerdezes = "SELECT * FROM termekek WHERE id=$productid";
    $talalt_termek = $conn->query($lekerdezes);
    $termek = $talalt_termek->fetch_assoc();

?>
<form method="post" action="editproduct.php?productid=<?= $productid; ?>">
    <input name='name' type='text' value='<?= $termek['name']; ?>'><br><br>
    <input name='quantity' type='number' value='<?= $termek['quantity']; ?>'><br><br>
    <input name='price' type='number' value='<?= $termek['price']; ?>'><br><br>
    <select name='on_sale' selected="selected">
        <option value='1' 
        <?php 
            if($termek['on_sale']==1){
                echo "selected";
            }
        ?>
        >Akciós</option>
        <option value='0'
        <?php 
            if($termek['on_sale']==0){
                echo "selected";
            }
        ?>
        >Nem akciós</option>
    </select><br><br>
    <input name='sale_price' type='number' value='<?= $termek['sale_price']; ?>'><br><br>
    <input name='save-product-btn' type='submit' value='Mentés'>
</form>