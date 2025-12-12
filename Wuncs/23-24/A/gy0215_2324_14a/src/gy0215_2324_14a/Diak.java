/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0215_2324_14a;

/**
 *
 * @author wuncs.david
 */
public class Diak {
    private String nev;
    private int kor;
    private String nem;

    public Diak(String nev, int kor, String nem) {
        this.nev = nev;
        this.kor = kor;
        this.nem = nem;
    }

    public String getNem() {
        return nem;
    }

    public void setNem(String nem) {
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
