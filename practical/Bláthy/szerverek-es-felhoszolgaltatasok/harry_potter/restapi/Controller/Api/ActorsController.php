<?php

class ActorsController extends BaseController
{

    public function listAction(){
        $strErrorDesc = "";
        $requestMethod = $_SERVER['REQUEST_METHOD'];

        if (strtoupper($requestMethod) == "GET"){
            try {
                $actorsModel = new ActorsModel();
               
                $arrActors = $actorsModel->getActors();
                $responseData = json_encode($arrActors);

            }catch (Error $e){

                $strErrorDesc = $e->getMessage().'Hiba a szerverrel';
                $strErrorHeader = 'HTTP/1.1 500 Internal Server Error';
            }
        }else{
            $strErrorDesc = 'Ez a Method nem támogatott';
            $strErrorHeader = "HTTP/1.1 422 Unprocessable Entity";
        }

        if (!$strErrorDesc){
            $this->sendOutput($responseData, array('Content-Type: application/json', 'HTTP/1.1 200 OK'));
        }else {
            $this->sendOutput(json_encode(array('error' => $strErrorDesc)), array('Content-Type: apllication/json', $strErrorHeader));
        }
    }

}