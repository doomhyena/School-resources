<?php
    $nev = $_POST['felhasznalonev'];

    $cel_mappa = 'users/' . $nev;

    if (!is_dir($cel_mappa)) {
        mkdir($cel_mappa, 0777, true);
    }

    if (isset($_FILES['feltoltott_fajl'])) {
        $eredeti_nev = $_FILES['feltoltott_fajl']['name'];
        $ideiglenes = $_FILES['feltoltott_fajl']['tmp_name'];
        
        $cel_utvonal = $cel_mappa . '/' . basename($eredeti_nev);
        
        if (move_uploaded_file($ideiglenes, $cel_utvonal)) {
            echo "Sikeres feltöltés!";
        } else {
            echo "Hiba történt a fájl mentésénél.";
        }
    } else {
        echo "Nem érkezett fájl vagy hiba történt.";
    }
?>
<form method="POST" enctype="multipart/form-data">
    <label>Felhasználónév: <input type="text" name="felhasznalonev"></label><br><br>
    <label>Fájl feltöltése: <input type="file" name="feltoltott_fajl"></label><br><br>
    <input type="submit" value="Feltöltés">
</form>