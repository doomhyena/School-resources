/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0304_2324_13a;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

class Eredmeny{
    private String h_nev;
    private String v_nev;
    private int h_pont;
    private int v_pont;
    private String helyszin;
    private String idopont;

    public Eredmeny(String h_nev, String v_nev, int h_pont, int v_pont, String helyszin, String idopont) {
        this.h_nev = h_nev;
        this.v_nev = v_nev;
        this.h_pont = h_pont;
        this.v_pont = v_pont;
        this.helyszin = helyszin;
        this.idopont = idopont;
    }

    public String getIdopont() {
        return idopont;
    }

    public void setIdopont(String idopont) {
        this.idopont = idopont;
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

    public String getHelyszin() {
        return helyszin;
    }

    public void setHelyszin(String helyszin) {
        this.helyszin = helyszin;
    }

    @Override
    public String toString() {
        return "Eredmeny{" + "h_nev=" + h_nev + ", v_nev=" + v_nev + ", h_pont=" + h_pont + ", v_pont=" + v_pont + ", helyszin=" + helyszin + ", idopont=" + idopont + '}';
    }   
}
public class Gy0304_2324_13a {

    static ArrayList <Eredmeny> eredmenyek = 
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir();
        rm();
        System.out.println("4. Feladat: Volt döntetlen? "+dontetlen());
        System.out.println("5. Feladat: "+barcelona());
    }

    private static void feltolt() {
        File f = new File("eredmenyek.csv");
        try {
            Scanner be = new Scanner(f,"ISO-8859-2"); //ISO-8859-2
            String sor;
            String [] adatok;
            Eredmeny e;
            be.nextLine();
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                e = new Eredmeny(adatok[0], adatok[1],
                        Integer.parseInt(adatok[2]),
                        Integer.parseInt(adatok[3]),
                        adatok[4], adatok[5]);
                eredmenyek.add(e);
//                eredmenyek.add(new Eredmeny(adatok[0], adatok[1],
//                        Integer.parseInt(adatok[2]),
//                        Integer.parseInt(adatok[3]),
//                        adatok[4], adatok[5]));
            }
            
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void kiir() {
        for (Eredmeny n : eredmenyek) {
            System.out.println(n);
        }
    }

    private static void rm() {
        int hazai = 0;
        int vendeg = 0;
        
        for (Eredmeny n : eredmenyek){
            if (n.getH_nev().equals("Real Madrid")){
                hazai++;
            }
            
            if (n.getV_nev().equals("Real Madrid"))
                vendeg++;
        }
        
        System.out.println("Hazai: "+hazai+" Vendég: "+vendeg);
    }

    private static String dontetlen() {
        for (Eredmeny n : eredmenyek) {
            if (n.getH_pont() == n.getV_pont())
                return "Igen.";
        }
        return "Nem";
    }

    private static String barcelona() {
        for (Eredmeny n : eredmenyek) {
            if (n.getH_nev().contains("Barcelona"))
                return n.getH_nev();
        }
        return "Nincs ilyen csapata!";
    }
    
}
