/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1205_2425_14b_acbgrafikus;

/**
 *
 * @author wuncs.david
 */
public class Eredmeny {
    private String h_nev;
    private String v_nev;
    private int h_pont;
    private int v_pont;
    private String hely;
    private String datum;

    public Eredmeny(String h_nev, String v_nev, int h_pont, int v_pont, String hely, String datum) {
        this.h_nev = h_nev;
        this.v_nev = v_nev;
        this.h_pont = h_pont;
        this.v_pont = v_pont;
        this.hely = hely;
        this.datum = datum;
    }

    public String getDatum() {
        return datum;
    }

    public void setDatum(String datum) {
        this.datum = datum;
    }

    public String getH_nev() {
        return h_nev;
    }

    public void setH_nev(String h_nev) {
        this.h_nev = h_nev;
    }

    public String getV_nev() {
        return v_nev;
    }

    public void setV_nev(String v_nev) {
        this.v_nev = v_nev;
    }

    public int getH_pont() {
        return h_pont;
    }

    public void setH_pont(int h_pont) {
        this.h_pont = h_pont;
    }

    public int getV_pont() {
        return v_pont;
    }

    public void setV_pont(int v_pont) {
        this.v_pont = v_pont;
    }

    public String getHely() {
        return hely;
    }

    public void setHely(String hely) {
        this.hely = hely;
    }

    @Override
    public String toString() {
        return h_nev + " - " + v_nev;
    }
    
    
    
}
