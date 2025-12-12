/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Cukraszda;

/**
 *
 * @author Wuncs.David
 */
public class Suti {
   private String nev;
   private int ar;

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public int getAr() {
        return ar;
    }

    public void setAr(int ar) {
        this.ar = ar;
    }

    public Suti(String nev, int ar) {
        this.nev = nev;
        this.ar = ar;
    }

    @Override
    public String toString() {
        return String.format("%s (%d ft)", nev,ar);
    }
   
   
}
