/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1109_2324_14b;

/**
 *
 * @author wuncs.david
 */
public class Eredmeny {
    String h_nev;
    String v_nev;
    int h_pont;
    int v_pont;
    String hely;
    String datum;

    public Eredmeny(String h_nev, String v_nev, int h_pont, int v_pont, String hely, String datum) {
        this.h_nev = h_nev;
        this.v_nev = v_nev;
        this.h_pont = h_pont;
        this.v_pont = v_pont;
        this.hely = hely;
        this.datum = datum;
    }

    @Override
    public String toString() {
        return h_nev + " - " + v_nev;
    }
    
    
}
