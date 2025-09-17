<?php

    $conn = new mysqli("localhost", "root", "" , "konyvtar");
    
    if($conn->connect_error){
       die("Sikertelen csatlakozás! ".$conn->connect_error);
    }

?>