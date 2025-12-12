/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1116_2324_14a;

import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author wuncs.david
 */
public class Ember {
    private String nev;
    private int emelet;

    public Ember(String nev, int emelet) {
        this.nev = nev;
        this.emelet = emelet;
    }

    public int getEmelet() {
        return emelet;
    }

    public void setEmelet(int emelet) {
        this.emelet = emelet;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }
    
    public void utazas(int hova) {
        //Random rnd = new Random();
        //hova = rnd.nextInt(10-1+1)+1;
        if (hova == emelet)
            System.out.println("Gyula nem túl okos és arra az emeletre menne ahol van");
        else {
            if (hova != 0)
                System.out.println("Gyula megy a "+hova+". emeletre. "+ (Math.abs(hova-emelet)*3)+" mp lesz");
            else
                System.out.println("Gyula a földszintre megy, szóval kilép.");
            try {
                Thread.sleep(Math.abs(hova-emelet)*3000);
            } catch (InterruptedException ex) {
            }
            emelet = hova;
        }
        
    }

    @Override
    public String toString() {
        if (emelet != 0)
            return nev + ": " + emelet + ". emelet.";
        else
            return nev + ": Fsz";
    }
    
    
}
