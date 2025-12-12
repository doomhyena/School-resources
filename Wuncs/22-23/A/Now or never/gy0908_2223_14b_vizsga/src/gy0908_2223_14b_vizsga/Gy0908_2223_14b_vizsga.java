/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0908_2223_14b_vizsga;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Pilota implements Comparable<Pilota>{
    private String nev;
    private String szul;
    private String csapat;
    private int futamok;
    private int gyozelmek;
    private String nemzet;

    public Pilota(String nev, String szul, String csapat, int futamok, int gyozelmek, String nemzet) {
        this.nev = nev;
        this.szul = szul;
        this.csapat = csapat;
        this.futamok = futamok;
        this.gyozelmek = gyozelmek;
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

    public int getFutamok() {
        return futamok;
    }

    public void setFutamok(int futamok) {
        this.futamok = futamok;
    }

    public int getGyozelmek() {
        return gyozelmek;
    }

    public void setGyozelmek(int gyozelmek) {
        this.gyozelmek = gyozelmek;
    }

    @Override
    public String toString() {
        return nev + ", " + szul + ", " + csapat + ", " + futamok + ", " + gyozelmek + ", " + nemzet;
    }

    @Override
    public int compareTo(Pilota t) {
        if (gyozelmek > t.getGyozelmek()) return -1;
        else if (gyozelmek == t.getGyozelmek()) return 0;
        else return 1;
    }
    
    
}
/**
 *
 * @author wuncs.david
 */
public class Gy0908_2223_14b_vizsga {

    /**
     * @param args the command line arguments
     */
    static ArrayList<Pilota> pilotak = new ArrayList<>();
    public static void main(String[] args) throws IOException {
        feltolt();
        kiir();
        _f5();
        _f6();
        _f7();
    }

    private static void feltolt() {
        File f = new File("Mezony.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                if (adatok[4].equals(""))
                    pilotak.add(new Pilota(adatok[0],adatok[1],
                    adatok[2],Integer.parseInt(adatok[3]),0,adatok[5]));
                else
                    pilotak.add(new Pilota(adatok[0],adatok[1],
                    adatok[2],Integer.parseInt(adatok[3]),
                    Integer.parseInt(adatok[4]),adatok[5]));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
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
            if (n.getFutamok()>max.getFutamok())
                max = n;
        }
        System.out.println("5. Feladat: "+max.getNev()+", Futamok: "+max.getFutamok());
        
    }

    private static void _f6() {
        ArrayList<String> csapatok = new ArrayList<>();
        for (Pilota n : pilotak) {
            if (!csapatok.contains(n.getCsapat()))
                csapatok.add(n.getCsapat());
        }
        
        for (String cs : csapatok){
            System.out.print("\n"+cs+": ");
            for (Pilota n : pilotak){
                if (n.getCsapat().equals(cs))
                    System.out.print(n.getNev()+" ");
            }
        }
    }

    private static void _f7() throws IOException {
        Collections.sort(pilotak);
        
        FileWriter fw = new FileWriter("Gyoztesek.txt");
        
        for (Pilota n : pilotak) {
            if (n.getGyozelmek()>0)
                fw.write(n.getNev()+" - "+n.getGyozelmek()+"\n");
        }
        fw.close();
    }
    
}
