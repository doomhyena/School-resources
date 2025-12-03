<?php 

    $conn = new mysqli("localhost", "root", "", "schola_14b_netbank");
    
    if($conn->connect_error){
       die("Connection failed! ".$conn->connect_error);
    }

?>