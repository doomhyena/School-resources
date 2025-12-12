/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1210_2425_14a_nevek;

/**
 *
 * @author wuncs.david
 */
public class Szemely {
    private String nev;
    private int kor;
    private int nem;

    public Szemely(String nev, int kor, int nem) {
        this.nev = nev;
        this.kor = kor;
        this.nem = nem;
    }

    public int getNem() {
        return nem;
    }

    public void setNem(int nem) {
        this.nem = nem;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public int getKor() {
        return kor;
    }

    public void setKor(int kor) {
        this.kor = kor;
    }

    @Override
    public String toString() {
        return nev;
    }
    
    
}
