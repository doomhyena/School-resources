<?php

    $conn = new mysqli("localhost", "root", "", "search");

    if($conn->connect_error){
    die("Sikertelen csatlakozás! ".$conn->connect_error);
    }

?>