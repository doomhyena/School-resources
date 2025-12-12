/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0906_2223_14a;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Acb{
    private String hazai_nev;
    private String vendeg_nev;
    private int h_pont;
    private int v_pont;
    private String helyszin;
    private String idopont;

    public Acb(String hazai_nev, String vendeg_nev, int h_pont, int v_pont, String helyszin, String idopont) {
        this.hazai_nev = hazai_nev;
        this.vendeg_nev = vendeg_nev;
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

    public String getHazai_nev() {
        return hazai_nev;
    }

    public void setHazai_nev(String hazai_nev) {
        this.hazai_nev = hazai_nev;
    }

    public String getVendeg_nev() {
        return vendeg_nev;
    }

    public void setVendeg_nev(String vendeg_nev) {
        this.vendeg_nev = vendeg_nev;
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
        return hazai_nev + " - " + vendeg_nev + ", " + h_pont + " : " + v_pont + ", Helyszín: " + helyszin + ", Időpont: " + idopont;
    }
    
    
}

/**
 *
 * @author Wuncs.David
 */
public class Gy0906_2223_14a {

    /**
     * @param args the command line arguments
     */
    static ArrayList<Acb> ered = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir();
    }

    private static void feltolt() {
        File f = new File("eredmenyek.csv");
        try {
            Scanner be = new Scanner(f,"iso-8859-2");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                ered.add(new Acb(adatok[0],adatok[1],
                Integer.parseInt(adatok[2]),Integer.parseInt(adatok[3]),
                adatok[4],adatok[5]));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void kiir() {
        for (Acb n : ered) {
            System.out.println(n);
        }
    }
    
}
