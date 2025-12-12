/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author wuncs.david
 */
public class Ember {
   String nev;
   boolean ideges;

    public Ember(String nev, boolean ideges) {
        this.nev = nev;
        this.ideges = ideges;
    }

    
    //Ha azt szeretném, hogy csak a név látszódjon
    //a listadobozban.
    @Override
    public String toString() {
        return nev; 
    }
   
   
}
