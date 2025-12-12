<?php

$dbhost = "localhost";
$dbuser = "root";
$dbpass = "";
$dbname = "regisztral14b";

if(!$con = mysqli_connect($dbhost,$dbuser,$dbpass,$dbname))
{
		die("Nem sikerült csatlakozni.");
}