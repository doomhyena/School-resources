<?php

    if(isset($_POST['upload-btn'])){

        $title = $_POST['title'];
        $description = $_POST['description'];

        if($title != "" && $description != ""){
            $file_name = $_FILES['new-file']['name'];
            $tmp_name = $_FILES['new-file']['tmp_name'];
            $mappa = getcwd();
            $eleresi_ut = $mappa."\\users\\".$_SESSION['username']."\\".$file_name;
            $adtitle = $_POST['title'];
            $addescription = $_POST['description'];
            
            if(move_uploaded_file($tmp_name, $eleresi_ut)){
                echo "Fájl sikeresen feltöltve!";
                $conn->query("INSERT INTO users VALUES(id, '$adtitle', '$addescription')");

            } else {
                echo "Fájl feltöltés sikertelen!";
            }
    } else {
        echo "Nem töltöttél ki minden mezőt!";
    }
}

?>

<!DOCTYPE html>
<html>
   <head>
       <title>Feltöltés</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Csontos Kincső'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
    <form method="post" enctype="multipart/form-data">
        <h1>Fájl feltöltés</h1>
        <input type="text" name="title" placeholder="Hirdetés neve">
        <br><br>
        <input type="text" name="description" placeholder="Hirdetés leírása">
        <input type="file" name="new-file">
        <br><br>
        <input type="submit" name="upload-btn" value="Fájl feltöltés">
    </form>
    <a href="index.php">Főoldal</a>
   </body>
</html>