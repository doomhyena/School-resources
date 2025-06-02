<?php
    require "config.php";

    $day = date("l");  
    $current_time = date("H:i");

    $sql = "SELECT * FROM schedule WHERE day='$day' AND start <= '$current_time' AND end > '$current_time' LIMIT 1";
    $result = $conn->query($sql);

    $currentClass = null;
    if ($result->num_rows > 0) {
        $currentClass = $result->fetch_assoc();
        $currentClass['type'] = $currentClass['name'] ? 'Elmélet' : 'Nincs óra';
    }

    echo json_encode(["currentClass" => $currentClass]);

    $conn->close();
?>
