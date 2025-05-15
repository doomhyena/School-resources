/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0422_2324_13a;

import java.io.File;
import java.io.FileNotFoundException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

class Eredmeny{
    private String h_csapat;
    private String v_csapat;
    private int h_pont;
    private int v_pont;
    private String helyszin;
    private Date idopont;

    public Eredmeny(String h_csapat, String v_csapat, int h_pont, int v_pont, String helyszin, Date idopont) {
        this.h_csapat = h_csapat;
        this.v_csapat = v_csapat;
        this.h_pont = h_pont;
        this.v_pont = v_pont;
        this.helyszin = helyszin;
        this.idopont = idopont;
    }

    public Date getIdopont() {
        return idopont;
    }

    public void setIdopont(Date idopont) {
        this.idopont = idopont;
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
        return "Eredmeny{" + "h_csapat=" + h_csapat + ", v_csapat=" + v_csapat + ", h_pont=" + h_pont + ", v_pont=" + v_pont + ", helyszin=" + helyszin + ", idopont=" + idopont + '}';
    }
    
    
}

public class Gy0422_2324_13a {

    static ArrayList<Eredmeny> eredmenyek =
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        
        for (Eredmeny e : eredmenyek)
            System.out.println(e);
        
    }

    private static void feltolt() {
        File f = new File("eredmenyek.csv");
        try{
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            String sor;
            String [] adatok;
            Eredmeny e;
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                e = new Eredmeny(adatok[0], adatok[1],
                        Integer.parseInt(adatok[2]),
                        Integer.parseInt(adatok[3]),
                        adatok[4], sdf.parse(adatok[5]));
                eredmenyek.add(e);
            }
        }
        catch (FileNotFoundException | ParseException fnf){
            System.out.println("Hiba: "+fnf);
        }
    }
    
}
