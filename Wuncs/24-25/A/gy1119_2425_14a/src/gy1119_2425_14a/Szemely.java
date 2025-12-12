/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1119_2425_14a;

/**
 *
 * @author wuncs.david
 */
public class Szemely {
    private String nev;
    private int kor;

    public Szemely(String nev, int kor) {
        this.nev = nev;
        this.kor = kor;
    }

    public int getKor() {
        return kor;
    }

    public void setKor(int kor) {
        this.kor = kor;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    @Override
    public String toString() {
        return nev;
    }
    
    
}
