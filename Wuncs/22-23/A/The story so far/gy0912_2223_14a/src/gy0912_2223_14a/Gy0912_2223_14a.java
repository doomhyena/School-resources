/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0912_2223_14a;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

class Pilota{
    private String nev;
    private String szul;
    private String csapat;
    private int futam;
    private int gyozelem;
    private String nemzet;

    public Pilota(String nev, String szul, String csapat, int futam, int gyozelem, String nemzet) {
        this.nev = nev;
        this.szul = szul;
        this.csapat = csapat;
        this.futam = futam;
        this.gyozelem = gyozelem;
        this.nemzet = nemzet;
    }

    public String getNemzet() {
        return nemzet;
    }

    public void setNemzet(String nemzet) {
        this.nemzet = nemzet;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public String getSzul() {
        return szul;
    }

    public void setSzul(String szul) {
        this.szul = szul;
    }

    public String getCsapat() {
        return csapat;
    }

    public void setCsapat(String csapat) {
        this.csapat = csapat;
    }

    public int getFutam() {
        return futam;
    }

    public void setFutam(int futam) {
        this.futam = futam;
    }

    public int getGyozelem() {
        return gyozelem;
    }

    public void setGyozelem(int gyozelem) {
        this.gyozelem = gyozelem;
    }

    @Override
    public String toString() {
        return "Pilota{" + "nev=" + nev + ", szul=" + szul + ", csapat=" + csapat + ", futam=" + futam + ", gyozelem=" + gyozelem + ", nemzet=" + nemzet + '}';
    }
    
    
}
/**
 *
 * @author wuncs.david
 */
public class Gy0912_2223_14a {

    static ArrayList<Pilota> pilotak = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir();
        _f5();
        _f6();
    }

    private static void feltolt() {
        File f = new File("Mezony.csv");
        try{
        Scanner be = new Scanner(f,"UTF-8");
        be.nextLine();
        String sor;
        String [] adatok;
        while (be.hasNextLine()){
            sor = be.nextLine();
            adatok = sor.split(";");
            if (adatok[4].equals(""))
                pilotak.add(new Pilota(adatok[0],adatok[1],adatok[2],
                Integer.parseInt(adatok[3]),0,adatok[5]));
            else
                pilotak.add(new Pilota(adatok[0],adatok[1],adatok[2],
                Integer.parseInt(adatok[3]),Integer.parseInt(adatok[4]),
                        adatok[5]));
        }
        }
        catch(FileNotFoundException fnf){
            System.out.println("Hiba: "+fnf);
        }
    }

    private static void kiir() {
        for (Pilota n : pilotak) {
            System.out.println(n);
        }
    }

    private static void _f5() {
        Pilota max = pilotak.get(0);
        
        for (Pilota n : pilotak) {
            if (n.getFutam()>max.getFutam())
                max = n;
        }
        System.out.println("5. Feladat: "+max.getNev()+", "+max.getFutam());
    }

    private static void _f6() {
        ArrayList<String> csapatok = new ArrayList<>();
        
        for (Pilota n : pilotak){
            if (!csapatok.contains(n.getCsapat()))
                csapatok.add(n.getCsapat());
        }
        
        for (String cs : csapatok){
            System.out.print(cs+": ");
            for (Pilota n : pilotak){
                if (n.getCsapat().equals(cs))
                    System.out.print(n.getNev()+" ");
            }
            System.out.println();
        }
    }
    
}
