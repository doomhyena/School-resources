<?php

    $conn = new mysqli("localhost", "root", "", "hirdetes");

    if($conn->connect_error){
    die("Connection failed! ".$conn->connect_error);
    }

?>