/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author wuncs.david
 */
public class Film {
    private String nev;
    private String fran;
    private int ev;
    private double imdb;

    public Film(String nev, String fran, int ev, double imdb) {
        this.nev = nev;
        this.fran = fran;
        this.ev = ev;
        this.imdb = imdb;
    }

    public double getImdb() {
        return imdb;
    }

    public void setImdb(double imdb) {
        this.imdb = imdb;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public String getFran() {
        return fran;
    }

    public void setFran(String fran) {
        this.fran = fran;
    }

    public int getEv() {
        return ev;
    }

    public void setEv(int ev) {
        this.ev = ev;
    }
    
    
}
