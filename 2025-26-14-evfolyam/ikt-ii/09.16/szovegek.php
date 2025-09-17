<?php

    require "assets/php/config.php";

    $sql = "SELECT * FROM texts";
    $result = $conn->query($sql);
    while($text = $result->fetch_assoc()){
        echo '<p>'.$text['text'].'</p>';
    }