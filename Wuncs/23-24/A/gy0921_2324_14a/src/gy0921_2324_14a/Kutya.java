/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0921_2324_14a;

/**
 *
 * @author wuncs.david
 */
public class Kutya {
    private int id;
    private String fajta;
    private String nev;
    private int kor;
    private String datum;

    public Kutya(int id, String fajta, String nev, int kor, String datum) {
        this.id = id;
        this.fajta = fajta;
        this.nev = nev;
        this.kor = kor;
        this.datum = datum;
    }

    public String getDatum() {
        return datum;
    }

    public void setDatum(String datum) {
        this.datum = datum;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getFajta() {
        return fajta;
    }

    public void setFajta(String fajta) {
        this.fajta = fajta;
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
        return "Kutya{" + "id=" + id + ", fajta=" + fajta + ", nev=" + nev + ", kor=" + kor + ", datum=" + datum + '}';
    }
    
    
}
