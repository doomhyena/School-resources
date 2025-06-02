<?php 

    require "config.php";

        if(date('D') == "Mon"){
            $ma = "Hétfő";
        }
        else if(date('D') == "Tue"){
            $ma = "Kedd";
        }
        else if(date('D') == "Wed"){
            $ma = "Szerda";
        }
        else if(date('D') == "Thu"){
            $ma = "Csütörtök";
        }
        else if(date('D') == "Fri"){
            $ma = "Péntek";
        }

        $lekerdezes = "SELECT * FROM schedule WHERE day='$ma'";
        $talalt_orak = $conn->query($lekerdezes);
        while($ora = $talalt_orak->fetch_assoc()){

            $ido = date("h:i:s");

            if($ora['name'] != "Tanítás Nélküli Nap"){

                if($ido < $ora['end'] && $ido > $ora['start']){

                    echo "<div class='box'>";
                    echo "<h1>$ora[name]</h1>";
                    echo "<h2>$ora[teacher]</h2>";
                    echo "<h3>$ora[start] - $ora[end]</h2>";
                    echo "</div>";

                }

            }
            else{

                echo "<div class='box'>";
                echo "<h1>$ora[name]</h1>";
                echo "</div>";

            }

        }

?>