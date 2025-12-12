/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0903_2425_14a;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

class Citromos{
    private String megnev;
    private int ar;
    private String kat;

    public String getMegnev() {
        return megnev;
    }

    public void setMegnev(String megnev) {
        this.megnev = megnev;
    }

    public int getAr() {
        return ar;
    }

    public void setAr(int ar) {
        this.ar = ar;
    }

    public String getKat() {
        return kat;
    }

    public void setKat(String kat) {
        this.kat = kat;
    }

    public Citromos(String megnev, int ar, String kat) {
        this.megnev = megnev;
        this.ar = ar;
        this.kat = kat;
    }

    @Override
    public String toString() {
        return "Citromos{" + "megnev=" + megnev + ", ar=" + ar + ", kat=" + kat + '}';
    }
    
    
    
}



public class Gy0903_2425_14a {

    static ArrayList<Citromos> citromok = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        atlag();
        System.out.println(citromok);
    }

    private static void feltolt() {
        File f = new File("citrom.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            Citromos c;
            
            while (be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                c = new Citromos(adatok[0],
                        Integer.parseInt(adatok[1]), adatok[2]);
                citromok.add(c);
            }
            
        } catch (FileNotFoundException e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void atlag() {
        double atl = 0;
        
        for (Citromos n : citromok){
            atl += n.getAr();
        }
        
        atl /= citromok.size();
        
        System.out.println("Átlag: "+atl);
    }
    
}
