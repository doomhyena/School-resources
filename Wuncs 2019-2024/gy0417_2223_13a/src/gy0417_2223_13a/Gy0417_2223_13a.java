/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0417_2223_13a;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Fuvar{
    private int id;
    private String date;
    private int ido;
    private double tav;
    private double dij;
    private double tip;
    private String fiz;

    public Fuvar(int id, String date, int ido, double tav, double dij, double tip, String fiz) {
        this.id = id;
        this.date = date;
        this.ido = ido;
        this.tav = tav;
        this.dij = dij;
        this.tip = tip;
        this.fiz = fiz;
    }

    public String getFiz() {
        return fiz;
    }

    public void setFiz(String fiz) {
        this.fiz = fiz;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public int getIdo() {
        return ido;
    }

    public void setIdo(int ido) {
        this.ido = ido;
    }

    public double getTav() {
        return tav;
    }

    public void setTav(double tav) {
        this.tav = tav;
    }

    public double getDij() {
        return dij;
    }

    public void setDij(double dij) {
        this.dij = dij;
    }

    public double getTip() {
        return tip;
    }

    public void setTip(double tip) {
        this.tip = tip;
    }
  
}


public class Gy0417_2223_13a {

    static ArrayList<Fuvar> fuvarok = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
    }

    private static void feltolt() {
        File f = new File("fuvar.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine().replace(",", ".");
                adatok = sor.split(";");
                fuvarok.add(new Fuvar(Integer.parseInt(adatok[0]),
                        adatok[1],
                        Integer.parseInt(adatok[2]),
                        Double.parseDouble(adatok[3]),
                        Double.parseDouble(adatok[4]),
                        Double.parseDouble(adatok[5]), adatok[6]));
            }
            
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }
    
}
