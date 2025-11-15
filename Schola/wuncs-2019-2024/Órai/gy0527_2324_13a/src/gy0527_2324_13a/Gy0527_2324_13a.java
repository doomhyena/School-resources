/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0527_2324_13a;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

class Citromos{
    private String nev;
    private int ar;
    private String kateg;

    public Citromos(String nev, int ar, String kateg) {
        this.nev = nev;
        this.ar = ar;
        this.kateg = kateg;
    }

    public String getKateg() {
        return kateg;
    }

    public void setKateg(String kateg) {
        this.kateg = kateg;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public int getAr() {
        return ar;
    }

    public void setAr(int ar) {
        this.ar = ar;
    }
    
    
}


public class Gy0527_2324_13a {

    static ArrayList<Citromos> cit = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        _f4();
    }

    private static void feltolt() {
        File f = new File("citrom.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                cit.add(new Citromos(adatok[0],
                        Integer.parseInt(adatok[1]), adatok[2]));
            }
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void _f4() {
        double avg = 0;
        
        for (Citromos n : cit) {
            avg += n.getAr();
        }
        
        
        //avg/=cit.size();
        System.out.println("4. Feladat: "+avg/cit.size());
        
    }
    
}
