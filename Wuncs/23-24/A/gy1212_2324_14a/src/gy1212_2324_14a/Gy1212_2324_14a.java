/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1212_2324_14a;

import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;

class Feherje implements Comparable<Feherje>{
    String nev;
    String rov;
    int c;
    int h;
    int o;
    int n;
    int s;
    int rel;

    public Feherje(String nev, String rov, int c, int h, int o, int n, int s) {
        this.nev = nev;
        this.rov = rov;
        this.c = c;
        this.h = h;
        this.o = o;
        this.n = n;
        this.s = s;
        this.rel = c*12+h*1+o*16+n*14+s*32;
    }

    @Override
    public int compareTo(Feherje t) {
        return rel-t.rel;
    }
    
    
}


public class Gy1212_2324_14a {

    static ArrayList<Feherje> feherjek =
            new ArrayList<>();
    static String bsa = "";
    static int kapcsolatok;
    public static void main(String[] args) {
        feltolt();
        Collections.sort(feherjek);
        kiir_f2();
        fel_bsa();
        System.out.println(bsa);
        kapcsolatok = bsa.length()-1;
        _f4();
    }

    private static void feltolt() {
        File f = new File("aminosav.txt");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            
            String [] adatok = new String[7];
            while(be.hasNextLine()){
                for (int i = 0; i < adatok.length; i++) {
                    adatok[i] = be.nextLine();
                }
                feherjek.add(new Feherje(adatok[0], adatok[1],
                        Integer.parseInt(adatok[2]),
                        Integer.parseInt(adatok[3]),
                        Integer.parseInt(adatok[4]),
                        Integer.parseInt(adatok[5]),
                        Integer.parseInt(adatok[6])));
            }
            
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void kiir_f2() {
        for (Feherje n : feherjek) {
            System.out.println(n.nev+": "+n.rel);
        }
    }

    private static void fel_bsa() {
        File f = new File("bsa.txt");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            
            while (be.hasNextLine()){
                bsa += be.nextLine();
            }
        } catch (Exception e) {
        }
    }

    private static void _f4() {
        HashMap<String,Integer> savak = new HashMap<>();
        
        for (String b : bsa.split("")) {
            if (!savak.containsKey(b))
                savak.put(b, 1);
            else
                savak.put(b, savak.get(b)+1);
        }
        int [] sz = new int [5];
        for (String rov : savak.keySet()){
            
        }
        
        System.out.println(savak);
    }
    
}
