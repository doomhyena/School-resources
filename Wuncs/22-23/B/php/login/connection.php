<?php

$dbhost = "localhost";
$dbuser = "root";
$dbpass = "";
$dbname = "reg_db";

if(!$con = mysqli_connect($dbhost,$dbuser,$dbpass,$dbname))
{
		die("Nem sikerült csatlakozni.");
}