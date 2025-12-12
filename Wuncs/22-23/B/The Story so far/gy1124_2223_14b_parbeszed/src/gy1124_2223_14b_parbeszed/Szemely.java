/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1124_2223_14b_parbeszed;

/**
 *
 * @author wuncs.david
 */
public class Szemely {
    String nev;
    boolean foglalt = false;

    public Szemely(String nev) {
        this.nev = nev;
    }

    @Override
    public String toString() {
        return nev;
    }
    
    
}
