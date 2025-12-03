<?php
    require "assets/php/config.php";

    $product = null;
    if (isset($_GET['id'])) {
        $id = $_GET['id'];
        $sql = $conn->query("SELECT * FROM products WHERE id = $id");
        $product = $sql->fetch_assoc();

        $message = '';
        if (isset($_POST['order'])) {
            $order_qty = $_POST['order_qty'];
            if ($product['quantity'] >= $order_qty) {
                $sql = $conn->query("UPDATE products SET quantity = quantity - $order_qty WHERE id = $id");
                $product['quantity'] -= $order_qty;
                $message = "Rendelés sikeres!";
            } else {
                $message = "Nincs elég termék a raktárban!";
            }
        }
    }
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <title><?php echo $product['name']; ?></title>
</head>
<body>
    <h1><?php echo $product['name']; ?></h1>
    <p>Ár: <?php echo $product['price']; ?> Ft</p>
    <p>Mennyiség: <?php echo $product['quantity']; ?></p>

    <?php if ($product['quantity'] > 0): ?>
        <form method="post">
            <input type="number" name="order_qty" min="1" max="<?php echo $product['quantity']; ?>" required>
            <input type="submit" name="order" value="Rendelés">
        </form>
    <?php else: ?>
        <p>Elfogyott</p>
    <?php endif; ?>

    <?php if ($message): ?>
        <p><?php echo $message; ?></p>
    <?php endif; ?>
</body>
</html>
