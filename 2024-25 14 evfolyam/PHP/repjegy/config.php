<?php 

    $conn = new mysqli("localhost", "root", "", "schola_14a_repjegy");
    
    if($conn->connect_error){
       die("Connection failed! ".$conn->connect_error);
    }

?>