/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0519_2223;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

class Pilota{
private String nev;
private Date szul;
private String csap;
private int gp;
private int win;
private String nem;

    public Pilota(String nev, Date szul, String csap, int gp, int win, String nem) {
        this.nev = nev;
        this.szul = szul;
        this.csap = csap;
        this.gp = gp;
        this.win = win;
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

    public Date getSzul() {
        return szul;
    }

    public void setSzul(Date szul) {
        this.szul = szul;
    }

    public String getCsap() {
        return csap;
    }

    public void setCsap(String csap) {
        this.csap = csap;
    }

    public int getGp() {
        return gp;
    }

    public void setGp(int gp) {
        this.gp = gp;
    }

    public int getWin() {
        return win;
    }

    public void setWin(int win) {
        this.win = win;
    }



}


public class Gy0519_2223 {

    
    static ArrayList<Pilota> pilotak =
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
    }

    private static void feltolt() {
        File f = new File("Mezony.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            SimpleDateFormat sdf =
                    new SimpleDateFormat("yyyy.MM.dd");
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                if (adatok[4].equals("")){
                    pilotak.add(new Pilota(
                            adatok[0],
                            sdf.parse(adatok[1]), adatok[2],
                            Integer.parseInt(adatok[3]),
                            0, adatok[5]));
                }
                else{
                    pilotak.add(new Pilota(
                            adatok[0],
                            sdf.parse(adatok[1]), adatok[2],
                            Integer.parseInt(adatok[3]),
                            Integer.parseInt(adatok[4]),
                            adatok[5]));
                }
                    
                    
            }
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

}
