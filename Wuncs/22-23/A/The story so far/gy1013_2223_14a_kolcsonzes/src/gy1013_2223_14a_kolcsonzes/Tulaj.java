/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1013_2223_14a_kolcsonzes;

/**
 *
 * @author wuncs.david
 */
public class Tulaj {
    private String nev;
    private int kor;
    private String tul;

    public Tulaj(String nev, int kor, String tul) {
        this.nev = nev;
        this.kor = kor;
        this.tul = tul;
    }

    public String getTul() {
        return tul;
    }

    public void setTul(String tul) {
        this.tul = tul;
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
