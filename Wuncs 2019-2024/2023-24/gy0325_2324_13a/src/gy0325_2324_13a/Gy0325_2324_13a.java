/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0325_2324_13a;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

class Hegy{
    private String h_neve;
    private String h;
    private int magas;

    public Hegy(String h_neve, String h, int magas) {
        this.h_neve = h_neve;
        this.h = h;
        this.magas = magas;
    }

    public int getMagas() {
        return magas;
    }

    public void setMagas(int magas) {
        this.magas = magas;
    }

    public String getH_neve() {
        return h_neve;
    }

    public void setH_neve(String h_neve) {
        this.h_neve = h_neve;
    }

    public String getH() {
        return h;
    }

    public void setH(String h) {
        this.h = h;
    }

    @Override
    public String toString() {
        return h_neve + ", " + h + ", " + magas;
    }
    
    
}

public class Gy0325_2324_13a {

    static ArrayList<Hegy> hegyek = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir();
        System.out.println("3. Feladat: "+hegyek.size());
        _f4();
        _f5();
    }

    private static void feltolt() {
        File f = new File("hegyekMo.txt");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            Hegy he;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                he = new Hegy(adatok[0], adatok[1],Integer.parseInt(adatok[2]));
                hegyek.add(he);
            }
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void kiir() {
        for (Hegy n : hegyek) {
            System.out.println(n);
        }
    }

    private static void _f4() {
        double avg = 0;
        for (Hegy n : hegyek) {
            avg += n.getMagas();
        }
        
        avg /= hegyek.size();
        System.out.println("4. Feladat: "+avg);
    }

    private static void _f5() {
        Hegy max = hegyek.get(0);
        
        for (Hegy n : hegyek) {
            if (n.getMagas() > max.getMagas())
                max = n;
        }
        
        System.out.println("Legmagasabb: "+max);
    }
    
}
