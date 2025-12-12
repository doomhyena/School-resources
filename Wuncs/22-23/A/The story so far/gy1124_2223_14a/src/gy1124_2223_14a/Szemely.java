/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1124_2223_14a;

/**
 *
 * @author wuncs.david
 */
public class Szemely {
    String nev;
    int kor;
    int szam = 0;

    public Szemely(String nev, int kor) {
        this.nev = nev;
        this.kor = kor;
    }

    @Override
    public String toString() {
        return nev + ", " + szam;
    }
    
    
}
