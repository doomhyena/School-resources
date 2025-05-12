<?php 

    $conn = new mysqli("localhost", "root", "", "schola_14a_webshop");

    function generateOrder($status){

        global $conn;

        $lekerdezes = "SELECT * FROM rendelesek WHERE status='$status'";
        $talalt_rendelesek = $conn->query($lekerdezes);
        while($rendeles = $talalt_rendelesek->fetch_assoc()){
        
            echo "<form method='post' action='admin.php?rendelesid=$rendeles[id]'>
                    <label>#$rendeles[id] - <a href='szamla.php?rendelesid=$rendeles[id]'>Számla</a></label>
                    <select name='status' selected='selected'>
                        <option value='új'";

            if($rendeles['status'] == 'új'){
                echo " selected";
            }
                        
            echo ">Új</option>
                        <option value='feldolgozva'";
                        
            if($rendeles['status'] == 'feldolgozva'){
                echo " selected";
            }
                        
            echo ">Feldolgozva</option>
                        <option value='szallitas'";
                        
            if($rendeles['status'] == 'szallitas'){
                echo " selected";
            }
                        
            echo ">Szállítás alatt</option>
                        <option value='kiszallitva'";
                        
            if($rendeles['status'] == 'kiszallitva'){
                echo " selected";
            }
                        
            echo ">Kiszállítva</option>
                    </select>
                    <input name='save-btn' type='submit' value='Mentés'>
                </form>";

        }

    }
	
	function codeGenerator(){
		
		$karakterek = array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z");
		
		$code = "";
		
		for($i=0;$i<7;$i++){
			
			$code .= $karakterek[rand(0, count($karakterek)-1)];
			
		}
		
		return $code;
		
	}

?>