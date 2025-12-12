/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Orszagok;

/**
 *
 * @author Wuncs.David
 */
public class Orszag {
    private String nev;
    private int nepesseg;

    public Orszag(String nev, int nepesseg) {
        this.nev = nev;
        this.nepesseg = nepesseg;
    }

    public int getNepesseg() {
        return nepesseg;
    }

    public void setNepesseg(int nepesseg) {
        this.nepesseg = nepesseg;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    @Override
    public String toString() {
        return nev + ", Népesség: " + nepesseg+"e fő";
    }
    
    
}
