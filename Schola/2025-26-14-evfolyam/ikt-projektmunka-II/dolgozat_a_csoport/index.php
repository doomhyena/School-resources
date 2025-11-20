<?php

    require "assets/php/config.php";

    /*
    
        $hashedPassword = password_hash('WebAdmin25', PASSWORD_DEFAULT);
        echo $hashedPassword;
    
    */

    if (isset($_POST['add_product'])) {
        $name = $_POST['name'];
        $price = $_POST['price'];
        $quantity = $_POST['quantity'];
        $admin_pass = $_POST['admin_pass'];
        $sql = $conn->query("SELECT password FROM admin LIMIT 1");
        $admin = $sql->fetch_assoc();

        if ($admin && password_verify($admin_pass, $admin['password'])) {
            $image = '';
            if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                $target_dir = "products/";
                if (!is_dir($target_dir)) {
                    mkdir($target_dir, 0777, true);
                }
                $target_file = $target_dir . basename($_FILES["image"]["name"]);
                move_uploaded_file($_FILES["image"]["tmp_name"], $target_file);
                $image = $target_file;
            }

            $stmt = $conn->prepare("INSERT INTO products (name, price, quantity, image) VALUES (?, ?, ?, ?)");
            $stmt->bind_param("sdss", $name, $price, $quantity, $image);
            $stmt->execute();
        } else {
            echo "Hibás admin jelszó!";
        }
    } elseif (isset($_POST['add_quantity'])) {
        $id = $_POST['id'];
        $add_qty = $_POST['add_qty'];
        $sql = $conn->query("UPDATE products SET quantity = quantity + $add_qty WHERE id = $id");
    }

    $sql = $conn->query("SELECT * FROM products");
    $products = [];
    while ($row = $sql->fetch_assoc()) {
        $products[] = $row;
    }
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="refresh" content="5">
    <title>Raktár Készlet</title>
</head>
<body>
    <h1>Új termék hozzáadása</h1>
    <form method="post" enctype="multipart/form-data">
        Név: <input type="text" name="name" required><br>
        Ár: <input type="number" step="0.01" name="price" required><br>
        Mennyiség: <input type="number" name="quantity" required><br>
        Kép: <input type="file" name="image"><br>
        Admin jelszó: <input type="password" name="admin_pass" required><br>
        <input type="submit" name="add_product" value="Hozzáadás">
    </form>
    <h1>Termékek</h1>
    <p>Név, Ár, Mennyiség</p>
    <?php foreach ($products as $product): ?>
        <p>
            <?php echo $product['name']; ?> - <?php echo $product['price']; ?> - <?php echo $product['quantity']; ?>
            <form method="post" style="display:inline;">
                <input type="hidden" name="id" value="<?php echo $product['id']; ?>">
                <input type="number" name="add_qty" min="1" required>
                <input type="submit" name="add_quantity" value="Hozzáadás">
            </form>
        </p>
    <?php endforeach; ?>
</body>
</html>
