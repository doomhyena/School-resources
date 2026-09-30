<?php
session_start();
require_once("config.php");
?>

<!doctype html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">

    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css">

    <title>Harry Potter</title>
</head>
<body>


<nav class="navbar navbar-dark bg-dark fixed-top">
    <div class="container-fluid">
        <a class="navbar-brand harryFont" href="index.php" ><img src="img/brand.png" class="brand" /></a>
        <span class="harryFont text-white">Harry Potter</span>
        <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasDarkNavbar" aria-controls="offcanvasDarkNavbar">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="offcanvas offcanvas-end text-bg-dark" tabindex="-1" id="offcanvasDarkNavbar" aria-labelledby="offcanvasDarkNavbarLabel">
            <div class="offcanvas-header">
                <h5 class="offcanvas-title harryFont" id="offcanvasDarkNavbarLabel">Harry Potter</h5>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="offcanvas" aria-label="Close"></button>
            </div>
            <div class="offcanvas-body">
                <ul class="navbar-nav justify-content-end flex-grow-1 pe-3 house_font">
                    <li class="nav-item">
                        <a class="nav-link" aria-current="page" href="?s=home">Főoldal</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="?s=books">Könyvek</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="?s=films">Filmek</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="?s=houses">Házak</a>
                    </li>
                    <?php
                        if (isset($_SESSION["admin"])){?>
                            <li class="nav-item">
                                <a class="nav-link" href="?s=settings">Beállítások</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="?s=logout">Kijelentkezés</a>
                            </li>
                        <?php }?>

                </ul>
            </div>
        </div>
    </div>
</nav>


<!-- Content Start -->
<div id="content">

    <?php
    $includeDir = ".".DIRECTORY_SEPARATOR."pages".DIRECTORY_SEPARATOR;
    $includeDefault = $includeDir."home.php";

    if(isset($_GET['s']) && !empty($_GET['s']))
    {

        $_GET['s'] = str_replace("\0", '', $_GET['s']);
        $includeFile = basename(realpath($includeDir.$_GET['s'].".php"));
        $includePath = $includeDir.$includeFile;

        if(!empty($includeFile) && file_exists($includePath))
        {
            include($includePath);
        }
        else
        {
            include('pages/404.php');
        }

    }
    else
    {
        include($includeDefault);
    }
    ?>

</div>

<!-- Content End -->



<script src="js/bootstrap.min.js"></script>



</body>
</html>
