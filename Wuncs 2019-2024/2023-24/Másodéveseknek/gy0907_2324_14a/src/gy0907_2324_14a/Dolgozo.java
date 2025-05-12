/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0907_2324_14a;

/**
 *
 * @author wuncs.david
 */
public class Dolgozo {
    private String nev;
    private String nem;
    private String reszleg;
    private int belepes;
    private int ber;

    public Dolgozo(String nev, String nem, String reszleg, int belepes, int ber) {
        this.nev = nev;
        this.nem = nem;
        this.reszleg = reszleg;
        this.belepes = belepes;
        this.ber = ber;
    }

    public int getBer() {
        return ber;
    }

    public void setBer(int ber) {
        this.ber = ber;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public String getNem() {
        return nem;
    }

    public void setNem(String nem) {
        this.nem = nem;
    }

    public String getReszleg() {
        return reszleg;
    }

    public void setReszleg(String reszleg) {
        this.reszleg = reszleg;
    }

    public int getBelepes() {
        return belepes;
    }

    public void setBelepes(int belepes) {
        this.belepes = belepes;
    }

    @Override
    public String toString() {
        return "Dolgozo{" + "nev=" + nev + ", nem=" + nem + ", reszleg=" + reszleg + ", belepes=" + belepes + ", ber=" + ber + '}';
    }
    
    
}
