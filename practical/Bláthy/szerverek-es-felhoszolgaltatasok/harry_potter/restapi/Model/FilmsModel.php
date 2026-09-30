<?php
require_once PROJECT_ROOT_PATH . "/Model/Database.php";

class FilmsModel extends Database
{
    public function getFilms(){
        return $this->select("SELECT * FROM films ORDER BY id ASC");
    }
}