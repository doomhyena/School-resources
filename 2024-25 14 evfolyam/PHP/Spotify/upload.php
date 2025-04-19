<?php 

    require "config.php";

    // Megvizsgáljuk, hogy van-e művész bejelentkezve
    if(isset($_COOKIE['artistid'])){

        $lekerdezes = "SELECT * FROM artists WHERE id=$_COOKIE[artistid]";
        $talalt_muvesz = $conn->query($lekerdezes);
        $muvesz = $talalt_muvesz->fetch_assoc();

    }
    // Ha nincs -> átirányítás a bejelentkezés oldalra
    else{

        header("Location: artistlogin.php");

    }

    // FELTÖLTÉS
    if(isset($_POST['upload-btn'])){

        // TÁROLÓ MAPPÁK
        $img_target_dir = "img/";
        $file_target_dir = "files/";

        // FELTÖLTENDŐ FÁJLOK -> ELÉRÉSI ÚT
        $target_img = $img_target_dir.$_FILES['img-to-upload']['name'];
        $target_file = $file_target_dir.$_FILES['file-to-upload']['name'];

        // MEGVIZSGÁLJUK, HOGY VAN-E ILYEN NEVŰ KÉP
        if(file_exists($target_img)){
            echo "<script>alert('Ilyen kép már van a mappában!')</script>";
        }
        else if(file_exists($target_file)){
            echo "<script>alert('Már létezik ilyen nevű fájl!')</script>";
        }
        else{
            $name = $_POST['name'];
            $img_name = $_FILES['img-to-upload']['name'];
            $file_name = $_FILES['file-to-upload']['name'];
			$date = $_POST['datum'];
            $conn->query("INSERT INTO music VALUES(id, $_COOKIE[artistid], '$name', '$img_name', '$file_name', '$date')");
            move_uploaded_file($_FILES['img-to-upload']['tmp_name'], $target_img);
            move_uploaded_file($_FILES['file-to-upload']['tmp_name'], $target_file);
        }


    }

?>
<form method="post" action="upload.php" enctype="multipart/form-data">
    <label>Zene neve</label><br>
    <input name="name" type="text" placeholder="Zene neve"><br><br>
    <label>Kép fájl</label><br>
    <input name="img-to-upload" type="file"><br><br>
    <label>Zene fájl</label><br>
    <input name="file-to-upload" type="file"><br><br>
	<input name="datum" type="date" required><br><br>
    <input name="upload-btn" type='submit' value="Feltöltés">
</form>