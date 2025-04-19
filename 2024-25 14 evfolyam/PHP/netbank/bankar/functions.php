<?php 

    function Message($text){

        echo "<script>alert('$text')</script>";

    }

    function netbankId(){

        $conn = new mysqli("localhost", "root", "", "schola_14b_netbank");

        $id = rand(10000000, 99999999);

        while(mysqli_num_rows($talalt_id = $conn->query("SELECT * FROM ugyfel_users WHERE netbankid=$id")) > 0){

            $id = rand(10000000, 99999999);

        }

        return $id;

    }

    function ujSzamla($ugyfelid){

        $conn = new mysqli("localhost", "root", "", "schola_14b_netbank");

        $szamlaszam = "";

        $szam = rand(10000000, 99999999);

        $szamlaszam .= $szam;

        for($i=0;$i<2;$i++){

            $szam = rand(10000000, 99999999);

            $szamlaszam .= "-";

            $szamlaszam .= $szam;

        }

        while(mysqli_num_rows($talalt_id = $conn->query("SELECT * FROM szamlak WHERE szamlaszam='$szamlaszam'")) > 0){

            $szamlaszam = "";

            $szam = rand(10000000, 99999999);

            $szamlaszam .= $szam;

            for($i=0;$i<2;$i++){

                $szam = rand(10000000, 99999999);

                $szamlaszam .= "-";

                $szamlaszam .= $szam;

            }

        }

        $conn->query("INSERT INTO szamlak VALUES(id, $ugyfelid, '$szamlaszam', 0)");
    }

    function UjKartya($szamlaid, $pin, $type){

        $conn = new mysqli("localhost", "root", "", "schola_14b_netbank");

        $kartyaszam = "";

        $szamok = rand(1000, 9999);

        $kartyaszam .= $szamok;

        for($i=0;$i<3;$i++){

            $kartyaszam .= "-";

            $szamok = rand(1000, 9999);

            $kartyaszam .= $szamok;

        }

        while(mysqli_num_rows($talalt_kartya=$conn->query("SELECT * FROM kartyak WHERE kartyaszam='$kartyaszam'")
        ) != 0){

            $kartyaszam = "";

            $szamok = rand(1000, 9999);

            $kartyaszam .= $szamok;

            for($i=0;$i<3;$i++){

                $kartyaszam .= "-";

                $szamok = rand(1000, 9999);

                $kartyaszam .= $szamok;

            }

        }

        $lejarat = date('Y-m-t', strtotime('+10 year'));

        $kod = rand(100, 999);

        $pin = password_hash($pin, PASSWORD_DEFAULT);

        if($type == "mc"){

            $conn->query("INSERT INTO kartyak VALUES(id, $szamlaid, '$kartyaszam', '$lejarat', '$kod', '$pin', 'MasterCard', 'aktiv')");

        }
        else{

            $conn->query("INSERT INTO kartyak VALUES(id, $szamlaid, '$kartyaszam', '$lejarat', '$kod', '$pin', 'Visa', 'aktiv')");

        }
    }

?>