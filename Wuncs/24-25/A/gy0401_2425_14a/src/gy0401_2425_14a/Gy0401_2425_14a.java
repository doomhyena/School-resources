/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0401_2425_14a;

class Dolgozo{
    private String nev;
    private String nem;
    private String poz;
    private int ev;
    private int ber;

    public Dolgozo(String nev, String nem, String poz, int ev, int ber) {
        this.nev = nev;
        this.nem = nem;
        this.poz = poz;
        this.ev = ev;
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

    public String getPoz() {
        return poz;
    }

    public void setPoz(String poz) {
        this.poz = poz;
    }

    public int getEv() {
        return ev;
    }

    public void setEv(int ev) {
        this.ev = ev;
    }

    @Override
    public String toString() {
        return "Dolgozo{" + "nev=" + nev + ", nem=" + nem + ", poz=" + poz + ", ev=" + ev + ", ber=" + ber + '}';
    }
    
    
    
}

public class Gy0401_2425_14a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
    }
    
}
