<?php

if (ISSET($_POST['login'])) {
    $email = $_POST['email'];
    $password = $_POST['password'];

    try {
        $select_stmt=$db->prepare("SELECT * FROM admins WHERE email=:uemail");
        $select_stmt->execute(array(':uemail'=>$email));
        $row=$select_stmt->fetch(PDO::FETCH_ASSOC);

        if($select_stmt->rowCount() > 0)
        {
            if($email==$row["email"])
            {
                if(password_verify($password, $row['password']))
                {

                    $_SESSION["admin"] = $row["id"];
                    header("Location: ?s=settings");
                }
                else {
                    header('Location: ?s=admin');
                }
            }
            else
            {
                header('Location: ?s=admin');
            }
        }
    }
    catch (PDOException $e) {
        $e->getMessage();
    }
}

?>

<div class="container admin mt-5 text-center">
    <div class="row mt-5 ">
        <div class="col-sm-4">
        </div>
        <div class="col-sm-4 hatter">
            <h1>Admin Login</h1>

            <form method="post">
                <label for="email">E-mail:</label>
                <br>
                <input type="email" id="email" name="email" placeholder="E-mail"/>
                <br><br>
                <label for="password">Jelszó:</label>
                <br>
                <input type="password" id="password" name="password" placeholder="Jelszó"/>
                <br><br>
                <input class="button" type="submit" name="login" value="Bejelentkezés" />
                </br></br>
            </form>
        </div>
        <div class="col-sm-4">
        </div>
    </div>
</div>