<?php
require __DIR__."/inc/routes.php";

$uri = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
$uri = explode('/', $uri);

if ($uri[4] == 'books'){
    require PROJECT_ROOT_PATH . "/Controller/Api/BooksController.php";
    $objFeedController = new BooksController();
    $strMethodName = $uri[5].'Action';
    $objFeedController->{$strMethodName}();
}
else if ($uri[4] == 'films'){
    require PROJECT_ROOT_PATH . "/Controller/Api/FilmsController.php";
    $objFeedController2 = new FilmsController();
    $strMethodName2 = $uri[5].'Action';
    $objFeedController2->{$strMethodName2}();
}
else if ($uri[4] == 'actors'){
    require PROJECT_ROOT_PATH . "/Controller/Api/ActorsController.php";
    $objFeedController2 = new ActorsController();
    $strMethodName2 = $uri[5].'Action';
    $objFeedController2->{$strMethodName2}();
}
else
{
    header("HTTP/1.1 404 Not Found");
    exit();
}




