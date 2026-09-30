<?php
require_once PROJECT_ROOT_PATH . "/Model/Database.php";

class ActorsModel extends Database
{
    public function getActors(){
        return $this->select("SELECT * FROM actors ORDER BY id ASC");
    }
}