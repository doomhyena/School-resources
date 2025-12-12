/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0116_2425_14b;

/**
 *
 * @author wuncs.david
 */
public class Futo implements Comparable<Futo>{
    private String rsz;
    private String nev;
    private String szul;
    private String orsz;
    private String ido;

    public Futo(String rsz, String nev, String szul, String orsz, String ido) {
        this.rsz = rsz;
        this.nev = nev;
        this.szul = szul;
        this.orsz = orsz;
        this.ido = ido;
    }

    public String getIdo() {
        return ido;
    }

    public void setIdo(String ido) {
        this.ido = ido;
    }

    public String getRsz() {
        return rsz;
    }

    public void setRsz(String rsz) {
        this.rsz = rsz;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public String getSzul() {
        return szul;
    }

    public void setSzul(String szul) {
        this.szul = szul;
    }

    public String getOrsz() {
        return orsz;
    }

    public void setOrsz(String orsz) {
        this.orsz = orsz;
    }

    @Override
    public String toString() {
        return nev;
    }

    @Override
    public int compareTo(Futo t) {
        return ido.compareTo(t.ido);
    }
    
    
}
