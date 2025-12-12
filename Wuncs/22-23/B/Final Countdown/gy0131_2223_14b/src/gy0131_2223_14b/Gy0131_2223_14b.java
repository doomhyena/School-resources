/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0131_2223_14b;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Elem{
    private String ev;
    private String nev;
    private String vegyjel;
    private int rendszam;
    private String felfedezo;

    public Elem(String ev, String nev, String vegyjel, int rendszam, String felfedezo) {
        this.ev = ev;
        this.nev = nev;
        this.vegyjel = vegyjel;
        this.rendszam = rendszam;
        this.felfedezo = felfedezo;
    }

    public String getFelfedezo() {
        return felfedezo;
    }

    public void setFelfedezo(String felfedezo) {
        this.felfedezo = felfedezo;
    }

    public String getEv() {
        return ev;
    }

    public void setEv(String ev) {
        this.ev = ev;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public String getVegyjel() {
        return vegyjel;
    }

    public void setVegyjel(String vegyjel) {
        this.vegyjel = vegyjel;
    }

    public int getRendszam() {
        return rendszam;
    }

    public void setRendszam(int rendszam) {
        this.rendszam = rendszam;
    }

    @Override
    public String toString() {
        return ev + "," + nev +
              "," + vegyjel + ","
              + rendszam + "," + felfedezo;
    }
    
    
}

public class Gy0131_2223_14b {

    static ArrayList<Elem> elemek =
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        for (Elem n : elemek)
            System.out.println(n);
        System.out.println("3. Feladat: "+elemek.size());
        _f4();
        String vj = _f5();
        
        Elem mo = _f6(vj);
        if (mo != null){
            System.out.println(mo);
        }
        else{
            System.out.println("Nincs ilyen elem.");
        }
        
        _f7();
    }

    private static void feltolt() {
        File f = new File("felfedezesek.csv");
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNext()){
                sor = be.nextLine();
                adatok = sor.split(";");
                elemek.add(new Elem(adatok[0], adatok[1],
                adatok[2],Integer.parseInt(adatok[3]),
                        adatok[4]));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void _f4() {
        int db = 0;
        for (Elem n : elemek){
            if (n.getEv().equals("Ókor"))
                db++;
        }
        System.out.println("4. Feladat: "+db);
    }

    private static String _f5() {
        Scanner be = new Scanner(System.in);
        String vegy;
        do{
        System.out.print("Kérek egy vegyjelet: ");
        vegy = be.next();
        }while(!vegy.matches("[A-Za-z]+") ||
                vegy.length() > 2);
        
        return vegy;
        
        
    }

    private static Elem _f6(String vegyjel) {
        for (Elem n : elemek){
            if (n.getVegyjel().equalsIgnoreCase(vegyjel))
                return n;
        }
        return null;
    }

    private static void _f7() {
        int max = 0;
        int ev1;
        int ev2;
        for (int i = 0; i < elemek.size()-1; i++) {
            if (!elemek.get(i).getEv().equals("Ókor")){
                ev1 = Integer.parseInt(elemek.get(i).getEv());
                ev2 = Integer.parseInt(elemek.get(i+1).getEv());                
                if (ev2-ev1 > max)
                    max = ev2-ev1;                
            }  
        }
        System.out.println(max);
    }
    
}
