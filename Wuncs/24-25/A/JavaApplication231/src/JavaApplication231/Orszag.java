/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package JavaApplication231;

/**
 *
 * @author wuncs.david
 */
public class Orszag {
    private String nev;
    private int fo;
    private String kontinens;

    public Orszag(String nev, int fo, String kontinens) {
        this.nev = nev;
        this.fo = fo;
        this.kontinens = kontinens;
    }

    public String getKontinens() {
        return kontinens;
    }

    public void setKontinens(String kontinens) {
        this.kontinens = kontinens;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public int getFo() {
        return fo;
    }

    public void setFo(int fo) {
        this.fo = fo;
    }

    @Override
    public String toString() {
        return nev;
    }
    
    
}
