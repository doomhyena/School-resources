/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0331_2223_13b;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Eredmeny{
    private String h_csapat;
    private String v_csapat;
    private int h_pont;
    private int v_pont;
    private String helyszin;
    private String datum;

    public Eredmeny(String h_csapat, String v_csapat, int h_pont, int v_pont, String helyszin, String datum) {
        this.h_csapat = h_csapat;
        this.v_csapat = v_csapat;
        this.h_pont = h_pont;
        this.v_pont = v_pont;
        this.helyszin = helyszin;
        this.datum = datum;
    }

    public String getDatum() {
        return datum;
    }

    public void setDatum(String datum) {
        this.datum = datum;
    }

    public String getH_csapat() {
        return h_csapat;
    }

    public void setH_csapat(String h_csapat) {
        this.h_csapat = h_csapat;
    }

    public String getV_csapat() {
        return v_csapat;
    }

    public void setV_csapat(String v_csapat) {
        this.v_csapat = v_csapat;
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
        return h_csapat + " - " + v_csapat + ", " + h_pont + " : " + v_pont;
    }
    
    
}


public class Gy0331_2223_13b {

    static ArrayList<Eredmeny> eredmenyek =
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        _f3();
        System.out.println("4. Feladat: "+_f4());
        System.out.println("5. Feladat: "+_f5());
        _f6();
        _f7();
    }

    private static void feltolt() {
        File f = new File("eredmenyek.csv");
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            String sor;
            String [] adatok;
            while (be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                eredmenyek.add(new Eredmeny(
                               adatok[0], adatok[1], 
                               Integer.parseInt(adatok[2]), 
                               Integer.parseInt(adatok[3]),
                               adatok[4], adatok[5]));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
        
    }

    private static void _f3() {
        int hdb = 0;
        int vdb = 0;
        
        for (Eredmeny n : eredmenyek){
            if (n.getH_csapat().contains("Real Madrid")) hdb++;
            else if (n.getV_csapat().contains("Real Madrid")) vdb++;
            
        }
        System.out.println("3. Feladat: ");
        System.out.println("\tHazai: "+hdb);
        System.out.println("\tVendég: "+vdb);
    }

    private static String _f4() {
        for (Eredmeny n : eredmenyek) {
            if (n.getH_pont() == n.getV_pont())
                return "Volt döntetlen.";
        }
        return "Nem volt döntetlen.";
    }

    private static String _f5() {
        for (Eredmeny n : eredmenyek) {
            if (n.getH_csapat().contains("Barcelona"))
                return n.getH_csapat();
        }
        return "Nincs barcelonai csapat.";
    }

    private static void _f6() {
        for (Eredmeny n : eredmenyek) {
            if (n.getDatum().equals("2004-11-21"))
                System.out.println(n);
        }
    }

    private static void _f7() {
        ArrayList<String> stadionok =
                new ArrayList<>();
        for (Eredmeny n : eredmenyek){
            if (!stadionok.contains(n.getHelyszin()))
                stadionok.add(n.getHelyszin());
        }
        int db;
        for (String stadion : stadionok){
            db = 0;
            for (Eredmeny n : eredmenyek){
                if (stadion.equals(n.getHelyszin())) db++;
            }
            if (db>20)
                System.out.println(stadion+": "+db);
        }
    }
    
}
