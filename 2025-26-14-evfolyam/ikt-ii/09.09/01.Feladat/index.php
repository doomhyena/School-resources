<?php

    require "assets/php/config.php";

    if(isset($_POST['sub-btn'])) {

        $sql = "SELECT title, author FROM books";
        $result = $conn->query($sql);
        $row = $result->fetch_assoc();
        $konyvcim = $row['title'];
        $name = $_POST['yourname'];
        $konyvtar = 0;
        $kolcsonzes = 1;
        $today = date("Y-m-d");
        $ameddig = $_POST['ameddig'];

        if ($_POST['status'] == '1') {
            if (mysqli_num_rows($conn->query("SELECT * FROM kolcsonzes WHERE name = '`$name`' AND book = '`$konyvcim`' AND status = '`$konyvtar`'")) > 0) {
                $conn->query("UPDATE kolcsonzes SET status = '`$konyvtar`', ameddig = NULL WHERE name = '`$name`' AND book = '`$konyvcim`' AND status = '`$konyvtar`'");
               // header("Location: index.php");
            } else {
                // header("Location: index.php");
            }
        } elseif ($_POST['status'] == '2') {
            if(mysqli_num_rows($conn->query("SELECT * FROM kolcsonzes WHERE name = '`$name`' AND book = '`$konyvcim`' AND status = '$kolcsonzes'")) > 0) {
                $conn->query("UPDATE kolcsonzes SET status = 'kölcsönözve', ameddig = '`$ameddig`' WHERE name = '`$name`' AND book = '`$konyvcim`' AND status = '$kolcsonzes'");
                // header("Location: index.php");
            } else {
                $conn->query("INSERT INTO kolcsonzes VALUES (id, `$name`, `$konyvcim` `$kolcsonzes`, `$today`, `$ameddig`)");
                // header("Location: index.php");
            }
        }
    }

?>

<!DOCTYPE html>
<html lang='hu'>
   <head>
       <title>Könyvtár</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Csontos Kincső'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
        <h1>Könyvtár</h1>
        <h2>Kivehető könyvek: </h2>
            <form method="post">
                <label>Könyv címe:</label>
                <br>
                <select name="book_title" required>
                <?php
                $sql = "SELECT title, author FROM books";
                $result = $conn->query($sql);
                if ($result && $result->num_rows > 0) {
                    while($row = $result->fetch_assoc()) {
                        echo '<option value="' . $row['title'] . '">' . $row['title'] . ' - ' . $row['author'] . '</option>';
                    }
                } else {
                    echo '<option disabled>Nincs elérhető könyv</option>';
                }
                ?>
                </select>
                <br>
                <br>
                <label>Neved:</label>
                <br>
                <input type="text" name="yourname" required>
                <br>
                <br>
                <label>Státusz:</label>
                <br>
                <select>
                    <option value="" disabled selected>Válassz</option>
                    <option value="1" name="status">Könyvtárban</option>
                    <option value="2" name="status">Kölcsönzés</option>
                </select>
                <br>
                <br>
                <label>Meddig kölcsönzöd:</label>
                <br>
                <input type="date" name="ameddig">
                <br>
                <br>
                <input type="submit" name="sub-btn" value="Beküldés">
            </form>
   </body>
</html>