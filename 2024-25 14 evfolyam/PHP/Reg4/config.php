<?php 

    $conn = new mysqli("localhost", "root", "", "schola_14a_reg1");
    
    if($conn->connect_error){
       die("Connection failed! ".$conn->connect_error);
    }

?>