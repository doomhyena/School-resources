<?php

    $conn = new mysqli("localhost", "root", "", "2025_14a_gyakorlas");
    
    if($conn->connect_error){
       die("Sikertelen csatlakozás! ".$conn->connect_error);
    }

?>