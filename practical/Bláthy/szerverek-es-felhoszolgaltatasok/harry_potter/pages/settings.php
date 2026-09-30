<?php

    $sql=$db->prepare("SELECT * FROM admins");
    $sql->execute(array());

    $sql4=$db->prepare("SELECT * FROM books");
    $sql4->execute(array());

    $sql7=$db->prepare("SELECT * FROM films");
    $sql7->execute(array());

    $sql9=$db->prepare("SELECT * FROM actors");
    $sql9->execute(array());

?>

<div class="container  text-center">
    <h1 class="display-1">Beállítások</h1>
    <div class="row text-center">

        <h1>Admin</h1>
        <div class="col-sm-4">

        </div>
        <div class="col-sm-4">
            <form method="post" action="?s=settings">
            <table class="table table-bordered hatter house_font">
            <?php
            foreach ($sql as $item) {
                    echo "<tr>";
                    echo "<td>".$item['id']."</td><td>".$item['email']."</td><td><button value='".$item['id']."' name='delete' class='btn btn-dark'>Töröl</button></td>";
                    echo "</tr>";
                }


            if (isset($_POST['delete'])){
                $id = $_POST['delete'];
                $sql2 = $db->prepare("DELETE FROM admins WHERE id=:uid");

                if ($sql2->execute(array(":uid" =>$id))){
                    echo "<alert class='alert alert-success'>Sikeres törlés!</alert>";
                    echo "<meta http-equiv='refresh' content='2'>";
                }else{
                    echo "<alert class='alert alert-danger'>Sikertelen törlés!</alert>";
                }



            }
            ?>

            </table>
            <button name="add" class="btn btn-dark">Új Admin Felvétele</button>

                <?php

                    if (isset($_POST["add"])){
                        echo "<br><input type='email' name='email' placeholder='E-mail'><input placeholder='Jelszó' type='password' name='password'>";
                        echo "<br> <input type='submit' name='new' class='btn btn-dark' value='Felvétel' >";
                    }

                    if (isset($_POST['new'])){
                        $email = $_POST['email'];
                        $pw = $_POST['password'];
                        $hash = password_hash($pw,PASSWORD_DEFAULT);

                        $sql3 = $db->prepare("INSERT INTO admins (email,password) VALUES (:uemail,:upw)");

                        if ($sql3->execute(array(":uemail" => $email, ":upw" => $hash))){
                            echo "<alert class='alert alert-success'>Sikeres felvétel!</alert>";
                            echo "<meta http-equiv='refresh' content='2'>";
                        }else{
                            echo "<alert class='alert alert-danger'>Sikertelen felvétel!</alert>";
                        }

                    }
                ?>
            </form>
        </div>
        <div class="col-sm-4">

        </div>
    </div>


    <div class="row">
        <h1>Könyvek</h1>
        <div class="col-sm-1">

        </div>
        <div class="col-sm-10">
            <form method="post" action="?s=settings">
                <div class="table-responsive">
            <table class="table table-bordered hatter house_font">
                <?php
                foreach ($sql4 as $item) {
                    echo "<tr>";
                    echo "<td>".$item['id']."</td><td>".$item['title']."</td><td>".$item['publication_date']."</td><td>".$item['pages']."</td><td>".$item['img_url']."</td><td><button value='".$item['id']."' name='bdelete' class='btn btn-dark'>Töröl</button></td>";
                    echo "</tr>";
                }


                if (isset($_POST['bdelete'])){
                    $id = $_POST['bdelete'];
                    $sql5 = $db->prepare("DELETE FROM books WHERE id=:uid");

                    if ($sql5->execute(array(":uid" =>$id))){
                        echo "<alert class='alert alert-success'>Sikeres törlés!</alert>";
                        echo "<meta http-equiv='refresh' content='2'>";
                    }else{
                        echo "<alert class='alert alert-danger'>Sikertelen törlés!</alert>";
                    }



                }
                ?>

            </table>
                </div>
                <button name="badd" class="btn btn-dark">Új Könyv Felvétele</button>

                <?php

                if (isset($_POST["badd"])){
                    echo "<br><input type='text' name='title' placeholder='Cím'><input type='date' name='public'><input type='number' name='pages'><input type='text' name='img_url' placeholder='URL'>";
                    echo "<br> <input type='submit' class='btn btn-dark' name='bnew' value='Felvétel' >";
                }

                if (isset($_POST['bnew'])){
                    $title = $_POST['title'];
                    $date = $_POST['public'];
                    $pages = $_POST['pages'];
                    $img = $_POST['img_url'];

                    $sql6 = $db->prepare("INSERT INTO books (title,publication_date,pages,img_url) VALUES (:utitle,:upd,:upages,:uimg)");

                    if ($sql6->execute(array(":utitle" => $title, ":upd" => $date, ":upages"=>$pages, ":uimg"=>$img))){
                        echo "<alert class='alert alert-success'>Sikeres felvétel!</alert>";
                        echo "<meta http-equiv='refresh' content='2'>";
                    }else{
                        echo "<alert class='alert alert-danger'>Sikertelen felvétel!</alert>";
                    }

                }
                ?>
            </form>

        </div>
        <div class="col-sm-1">

        </div>
    </div>



    <div class="row">
        <h1>Filmek</h1>
        <div class="col-sm-12">
            <form method="post" action="?s=settings">
                <div class="table-responsive">
                    <table class="table table-bordered hatter house_font">
                        <?php
                        foreach ($sql7 as $item) {
                            echo "<tr>";
                            echo "<td>".$item['id']."</td><td>".$item['title']."</td><td>".$item['premier']."</td><td>".$item['director']."</td><td>".$item['income']."</td><td>".$item['img_url']."</td><td><button value='".$item['id']."' name='fdelete' class='btn btn-dark'>Töröl</button></td>";
                            echo "</tr>";
                        }


                        if (isset($_POST['fdelete'])){
                            $id = $_POST['fdelete'];
                            $sql5 = $db->prepare("DELETE FROM films WHERE id=:uid");

                            if ($sql5->execute(array(":uid" =>$id))){
                                echo "<alert class='alert alert-success'>Sikeres törlés!</alert>";
                                echo "<meta http-equiv='refresh' content='2'>";
                            }else{
                                echo "<alert class='alert alert-danger'>Sikertelen törlés!</alert>";
                            }



                        }
                        ?>

                    </table>
                </div>
                <button name="fadd" class="btn btn-dark">Új Film Felvétele</button>

                <?php

                if (isset($_POST["fadd"])){
                    echo "<br><input type='text' name='ftitle' placeholder='Cím'><input type='date' name='premier'><input type='text' name='director' placeholder='Név'><input type='number' name='income'><input type='text' name='actors' placeholder='Színészek'><input type='text' name='fimg_url' placeholder='URL'>";
                    echo "<br> <input type='submit' class='btn btn-dark' name='fnew' value='Felvétel' >";
                }

                if (isset($_POST['fnew'])){
                    $ftitle = $_POST['ftitle'];
                    $fdate = $_POST['premier'];
                    $director = $_POST['director'];
                    $income = $_POST['income'];
                    $actors = $_POST['actors'];
                    $fimg = $_POST['fimg_url'];

                    $sql8 = $db->prepare("INSERT INTO films (title,premier,director,income,actors_id,img_url) VALUES (:utitle,:upd,:udirector,:uincome,:uactors,:uimg)");

                    if ($sql8->execute(array(":utitle" => $ftitle, ":upd" => $fdate, ":udirector"=>$director, ":uincome" => $income, ":uactors" => $actors ,":uimg"=>$fimg))){
                        echo "<alert class='alert alert-success'>Sikeres felvétel!</alert>";
                        echo "<meta http-equiv='refresh' content='2'>";
                    }else{
                        echo "<alert class='alert alert-danger'>Sikertelen felvétel!</alert>";
                    }

                }
                ?>
            </form>

        </div>
    </div>




    <div class="row">
        <h1>Színészek</h1>
        <div class="col-sm-12">
            <form method="post" action="?s=settings">
                <div class="table-responsive">
                    <table class="table table-bordered hatter house_font">
                        <?php
                        foreach ($sql9 as $item) {
                            echo "<tr class='hatter'>";
                            echo "<td>".$item['id']."</td><td>".$item['name']."</td><td>".$item['film_character']."</td><td><button value='".$item['id']."' name='cdelete' class='btn btn-dark'>Töröl</button></td>";
                            echo "</tr>";
                        }


                        if (isset($_POST['cdelete'])){
                            $id = $_POST['cdelete'];
                            $sql5 = $db->prepare("DELETE FROM actors WHERE id=:uid");

                            if ($sql5->execute(array(":uid" =>$id))){
                                echo "<alert class='alert alert-success'>Sikeres törlés!</alert>";
                                echo "<meta http-equiv='refresh' content='2'>";
                            }else{
                                echo "<alert class='alert alert-danger'>Sikertelen törlés!</alert>";
                            }



                        }
                        ?>

                    </table>
                </div>
                <button name="cadd" class="btn btn-dark">Új Színész Felvétele</button>

                <?php

                if (isset($_POST["cadd"])){
                    echo "<br><input type='text' name='name' placeholder='Név'><input type='text' name='character' placeholder='Karakter'>";
                    echo "<br> <input type='submit' class='btn btn-dark' name='cnew' value='Felvétel' >";
                }

                if (isset($_POST['cnew'])){
                    $name = $_POST['name'];
                    $character = $_POST['character'];

                    $sql8 = $db->prepare("INSERT INTO actors (name,film_character) VALUES (:uname,:ucharacter)");

                    if ($sql8->execute(array(":uname" => $name, ":ucharacter" => $character))){
                        echo "<alert class='alert alert-success'>Sikeres felvétel!</alert>";
                        echo "<meta http-equiv='refresh' content='2'>";
                    }else{
                        echo "<alert class='alert alert-danger'>Sikertelen felvétel!</alert>";
                    }

                }
                ?>
            </form>

        </div>
    </div>

</div>
