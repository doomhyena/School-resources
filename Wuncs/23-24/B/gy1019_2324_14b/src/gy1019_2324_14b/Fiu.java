/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1019_2324_14b;

/**
 *
 * @author wuncs.david
 */
public class Fiu {
    private String nev;
    private String szul;

    public Fiu(String nev, String szul) {
        this.nev = nev;
        this.szul = szul;
    }

    public String getSzul() {
        return szul;
    }

    public void setSzul(String szul) {
        this.szul = szul;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    @Override
    public String toString() {
        return "Fiu{" + "nev=" + nev + ", szul=" + szul + '}';
    }
    
    
}
