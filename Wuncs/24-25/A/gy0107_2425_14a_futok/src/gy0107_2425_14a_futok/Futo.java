/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0107_2425_14a_futok;

/**
 *
 * @author wuncs.david
 */
public class Futo implements Comparable<Futo>{
    String rsz,nev,szul,or,ido;

    public Futo(String rsz, String nev, String szul, String or, String ido) {
        this.rsz = rsz;
        this.nev = nev;
        this.szul = szul;
        this.or = or;
        this.ido = ido;
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
