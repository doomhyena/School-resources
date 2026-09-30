<?php
$server = "localhost";
$username = "root";
$password = "";

try {
    $db = new PDO("mysql:host=$server;dbname=harry_potter", $username, $password);
    $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    //echo "Connected Succesfully";
} catch (PDOException $e) {
    echo "Connection Failed: " . $e->getMessage();
}

