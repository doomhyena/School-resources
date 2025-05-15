<?php

    $conn = new mysqli("localhost", "root", "","dolgozat_elso");
    
    if($conn->connect_error){
       die("Connection failed! ".$conn->connect_error);
    }

?>