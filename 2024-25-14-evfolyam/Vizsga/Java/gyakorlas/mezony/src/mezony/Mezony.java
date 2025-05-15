/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package mezony;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;



class Pilota implements Comparable<Pilota>{
    private String nev;
    private String szul;
    private String csapat;
    private int fut;
    private int win;
    private String nemzet;

    public Pilota(String nev, String szul, String csapat, int fut, int win, String nemzet) {
        this.nev = nev;
        this.szul = szul;
        this.csapat = csapat;
        this.fut = fut;
        this.win = win;
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

    public int getFut() {
        return fut;
    }

    public void setFut(int fut) {
        this.fut = fut;
    }

    public int getWin() {
        return win;
    }

    public void setWin(int win) {
        this.win = win;
    }

    @Override
    public String toString() {
        return "Pilota{" + "nev=" + nev + ", szul=" + szul + ", csapat=" + csapat + ", fut=" + fut + ", win=" + win + ", nemzet=" + nemzet + '}';
    }

    @Override
    public int compareTo(Pilota o) {
        return o.win-win; //Számok rendezésénél
        // return nev.compareTo(o.nev) Szöveg rendezésénél
    }
    
    
    
}


public class Mezony {

    static ArrayList<Pilota> pilotak = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        _f5();
        _f6();
        _f7();
    }

    private static void feltolt() {
        File f = new File("mezony.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                
                if (!adatok[4].equals(""))
                    pilotak.add(new Pilota(
                                adatok[0],adatok[1],
                                adatok[2],
                                Integer.parseInt(adatok[3]),
                                Integer.parseInt(adatok[4]),adatok[5]));
                else
                    pilotak.add(new Pilota(
                                adatok[0],adatok[1],
                                adatok[2],
                                Integer.parseInt(adatok[3]),
                                0,adatok[5]));
                
            }
            
        } catch (FileNotFoundException ex) {
            System.out.println(ex);
        }
    }

    private static void _f5() {
        Pilota max = pilotak.get(0);
        
        for (Pilota n : pilotak){
            if (n.getFut() > max.getFut() )
                max = n;
        }
        System.out.println("5. Feladat: ");
        System.out.println(max.getNev()+", Futamok száma: "+max.getFut());
        
    }

    private static void _f6() {
        HashMap<String,String> csapatok = new HashMap<>();
        
        for (Pilota n : pilotak) {
            if (!csapatok.containsKey(n.getCsapat()))
                csapatok.put(n.getCsapat(), n.getNev());
            else
                csapatok.put(n.getCsapat(), csapatok.get(n.getCsapat())+" "+n.getNev());
        }
        
        System.out.println("6. Feladat: ");
        for (String cs : csapatok.keySet()){
            System.out.println("\t"+cs+": "+csapatok.get(cs));
        }
            
        
        
    }

    private static void _f7() {
        Collections.sort(pilotak);
        
        try {
            FileWriter fw = new FileWriter("Gyoztesek.txt");
            for (Pilota n : pilotak) {
                if (n.getWin() > 0)
                    fw.write(n.getNev()+" - "+n.getWin()+"\n");
            }
            fw.close();
        } catch (IOException ex) {
            System.out.println(ex);
        }
        
    }
    
}
