<?php
$con = mysqli_connect("localhost","root","","kiadasok");
if (mysqli_connect_errno())
  {
  echo "Sikertelen MySQL csatlakozás: " . mysqli_connect_error() ." | Hiányzó adatbázis.";
  }
?>