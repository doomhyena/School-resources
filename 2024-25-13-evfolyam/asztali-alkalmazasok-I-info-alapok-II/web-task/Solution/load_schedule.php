<?php
    require "config.php";

    $sql = "SELECT * FROM schedule ORDER BY day, start";
    $result = $conn->query($sql);

    $schedule = [];
    if ($result->num_rows > 0) {
        while($row = $result->fetch_assoc()) {
            $schedule[] = [
                "day" => $row["day"],
                "start" => $row["start"],
                "end" => $row["end"],
                "name" => $row["name"],
                "teacher" => $row["teacher"],
                "room" => $row["room"],
                "type" => $row["name"] ? ($row["name"] == 'Tanítás Nélküli Nap' ? null : 'Elmélet') : null
            ];
        }
    }

    echo json_encode($schedule);
    $conn->close();
?>
