/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0915_2223_14b_2;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Lift{
    private String ido;
    private int az;
    private int kezdo;
    private int cel;

    public Lift(String ido, int az, int kezdo, int cel) {
        this.ido = ido;
        this.az = az;
        this.kezdo = kezdo;
        this.cel = cel;
    }

    public int getCel() {
        return cel;
    }

    public void setCel(int cel) {
        this.cel = cel;
    }

    public String getIdo() {
        return ido;
    }

    public void setIdo(String ido) {
        this.ido = ido;
    }

    public int getAz() {
        return az;
    }

    public void setAz(int az) {
        this.az = az;
    }

    public int getKezdo() {
        return kezdo;
    }

    public void setKezdo(int kezdo) {
        this.kezdo = kezdo;
    }
    
    
}
public class Gy0915_2223_14b_2 {

    static ArrayList<Lift> hasznalatok = new ArrayList<>();
    public static void main(String[] args) {
        fel();
        System.out.println("3. Feladat: "+hasznalatok.size());
        System.out.println("4. Feladat:\n "+hasznalatok.get(0).getIdo()+" - "+
                hasznalatok.get(hasznalatok.size()-1).getIdo());
        _f5();
        _f8();
    }

    private static void fel() {
        File f = new File("lift.txt");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(" ");
                hasznalatok.add(new Lift(adatok[0],
                Integer.parseInt(adatok[1]), Integer.parseInt(adatok[2]),
                Integer.parseInt(adatok[3])));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);        }
    }

    private static void _f5() {
        int max = hasznalatok.get(0).getCel();
        
        for (Lift n : hasznalatok) {
            if (n.getCel()>max)
                max = n.getCel();
        }
        
        System.out.println("5. Feladat: "+max);
    }

    private static void _f8() {
        ArrayList<String> napok = new ArrayList<>();
        for (Lift n : hasznalatok) {
            if (!napok.contains(n.getIdo()))
                napok.add(n.getIdo());
        }
        
        int db;
        
        for (String nap : napok) {
            db = 0;
            for (Lift n : hasznalatok){
                if (n.getIdo().equals(nap))
                    db++;
            }
            System.out.println(nap+": "+db);
        }
    }
    
}
