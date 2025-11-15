/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0226_2324_13a;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

class Szemely{
    private String nev;
    private int magassag;

    public Szemely(String nev, int magassag) {
        this.nev = nev;
        this.magassag = magassag;
    }
    
    @Override
    public String toString() {
        return nev + ", magasság: " + magassag + " cm.";
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public int getMagassag() {
        return magassag;
    }

    public void setMagassag(int magassag) {
        this.magassag = magassag;
    }
    
    
}

public class Gy0226_2324_13a {

    static ArrayList<Szemely> szemelyek = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir();
        //Határozza meg a személyek átlagmagasságát
        atlag();
       // Írja ki, hogy alacsonyabbak 160 centiméternél.
        alacsony();
        
        //printf, dátumok --> rendezés
        // szótár
        
    }

    private static void feltolt() {
        File f = new File("nevek.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8"); //ISO-8859-2
            String sor;
            String [] adatok;
            Szemely sz;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                sz = new Szemely(adatok[0], Integer.parseInt(adatok[1]));
                szemelyek.add(sz);
                //szemelyek.add(new Szemely(adatok[0],Integer.parseInt(adatok[1])));
            }
            
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void kiir() {
        for (Szemely n : szemelyek) {
            System.out.println(n);
        }
    }

    private static void atlag() {
        double avg = 0;
        for (Szemely n : szemelyek) {
            avg += n.getMagassag(); 
        }
        avg /= szemelyek.size();
        System.out.println("Átlagmagasság: "+avg+" cm.");
    }

    private static void alacsony() {
        System.out.println("160 centinél alacsonyabbak: ");
        for (Szemely n : szemelyek) {
            if (n.getMagassag() < 160)
                System.out.println("\t"+n);
        }
    }
    
}
