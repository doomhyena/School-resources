<?php 

	require "config.php";
	
	if(!isset($_COOKIE['id'])){
		header("Location: reglog.php");
	} else {
		$lekerdezes = "SELECT * FROM users WHERE id=$_COOKIE[id]";
		$talalt = $conn->query($lekerdezes);
		$felh = $talalt->fetch_assoc();
	}

    if(isset($_POST['send-btn'])){
		$conn->query("INSERT INTO posts VALUES(id, '$_POST[text]')");
	}



?>
<!DOCTYPE html>
<html>
   <head>
       <title>Főoldal</title>
       <meta charset='UTF-8'>
       <meta name='description' content='Rövid leírás az oldal tartalmáról'>
       <meta name='keywords' content='Keresést, Segítő, Szavak, Vesszővel, Elválasztva'>
       <meta name='author' content='Neved'>
       <meta name='viewport' content='width=device-width, initial-scale=1.0'>
   </head>
   <body>
    <h1>Üdv <?= $felh['username'] ?>!</h1>
    <a href="kereso.php">Kereső</a><br><br>
    <form method="post">
        <textarea name="text" placeholder="Írj valamit..." cols="50" rows="5"></textarea><br><br>
        <input type="submit" name="send-btn">
    </form>
    <?php
    	$keresett = $_GET['keresett'];

        $lk = "SELECT * FROM posts WHERE text LIKE '%$keresett%'";
		$talaltok = $conn->query($lk);
		while($szoveg=$talaltok->fetch_assoc()){
			
			$poszt_szavai = explode(" ", $szoveg['text']);
			
			echo "<p>";
			
			for($i=0;$i<count($poszt_szavai);$i++){
				
				if($poszt_szavai[$i][0] != "#"){
				
					echo $poszt_szavai[$i]." ";
				
				} else {
					$szo = str_replace("#", "", $poszt_szavai[$i]);
					echo "<a href='#'>".$szo."</a> ";					
				}
				
			}
			
			echo "</p>";
			
		}
    
    ?>
   </body>
</html>