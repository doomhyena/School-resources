<?php
    require "assets/php/config.php";

    $sql = $conn->query("SELECT id, name FROM products");
    $products = [];
    while ($row = $sql->fetch_assoc()) {
        $products[] = $row;
    }
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <title>Termékek</title>
</head>
<body>
    <h1>Termékek</h1>
    <?php foreach ($products as $product): ?>
        <p><a href="termek.php?id=<?php echo $product['id']; ?>"><?php echo $product['name']; ?></a></p>
    <?php endforeach; ?>
</body>
</html>
