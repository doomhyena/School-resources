/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1026_2324_14a;

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
    private String date;

    public Eredmeny(String h_nev, String v_nev, int h_pont, int v_pont, String hely, String date) {
        this.h_nev = h_nev;
        this.v_nev = v_nev;
        this.h_pont = h_pont;
        this.v_pont = v_pont;
        this.hely = hely;
        this.date = date;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
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
        return String.format(
    "%s %d : %d %s ",
    h_nev,h_pont,v_pont,v_nev);
    }
    
    
}
