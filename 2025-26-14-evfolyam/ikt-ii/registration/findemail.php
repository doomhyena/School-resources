<?php

    require 'assets/php/config.php';

    $email = $_POST['keresett'];

    $sql = "SELECT * FROM users WHERE email = '$email'";
    $result = $conn->query($sql);

    if(mysqli_num_rows($result) > 0){
        echo "Az email már foglalt!";
    } else {
        echo "Megfelelő az email!";
    }

?>