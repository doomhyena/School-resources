/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0220_2223_13a;

/**
 *
 * @author wuncs.david
 */
public class Szemely {
    String nev;
    int ev;
    int magassag;

    public Szemely(String s) {
        String [] adatok = s.split(",");
        this.nev = adatok[0];
        this.ev = Integer.parseInt(adatok[1]);
        this.magassag = Integer.parseInt(adatok[2]);
    }
    
    public String szok(){
        if (ev%4 ==0)
            return "Szökőév";
        else
            return "";
    }

    @Override
    public String toString() {
        return nev + ", " + ev + ", " + magassag + " cm, "+szok();
    }
    
    
    
    
}
