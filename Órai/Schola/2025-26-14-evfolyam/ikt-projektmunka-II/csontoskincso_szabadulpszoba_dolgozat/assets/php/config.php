<?php

    $conn = new mysqli("localhost", "root", "", "csontoskincso_szabaduloszoba");
    
    if($conn->connect_error){
       die("Sikertelen csatlakozás! ".$conn->connect_error);
    }

?>