/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0921_2324_14a;

/**
 *
 * @author wuncs.david
 */
public class Fajta {
    String nev;
    String eredeti;

    public Fajta(String nev, String eredeti) {
        this.nev = nev;
        this.eredeti = eredeti;
    }

    @Override
    public String toString() {
        return "Fajta{" + "nev=" + nev + ", eredeti=" + eredeti + '}';
    }
    
    
}
