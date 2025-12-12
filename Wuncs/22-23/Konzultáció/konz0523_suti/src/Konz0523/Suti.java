/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Konz0523;

/**
 *
 * @author wuncs.david
 */
public class Suti {
    String nev;
    int ar;

    public Suti(String nev, int ar) {
        this.nev = nev;
        this.ar = ar;
    }

    @Override
    public String toString() {
        return nev + " (" + ar + " ft)";
    }
    
    
}
