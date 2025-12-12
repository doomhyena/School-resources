/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0914_2324_14b_nyelv;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

class Vizsga{
    private String nyelv;
    private HashMap<Integer,Integer> er = new HashMap<>();
    private int ossz = 0;

    public Vizsga(String sor) {
        String [] adatok = sor.split(";");
        nyelv = adatok[0];
        int ev = 2009;
        for (int i = 1; i < adatok.length; i++) {
            er.put(ev, Integer.parseInt(adatok[i]));
            ev++;
            ossz += Integer.parseInt(adatok[i]);
        }
    }
    
    

    public String getNyelv() {
        return nyelv;
    }

    public void setNyelv(String nyelv) {
        this.nyelv = nyelv;
    }

    public HashMap<Integer,Integer> getEr() {
        return er;
    }

    public void setEr(HashMap<Integer,Integer> er) {
        this.er = er;
    }

    public int getOssz() {
        return ossz;
    }

    public void setOssz(int ossz) {
        this.ossz = ossz;
    }
    
    
    
    
    
}



public class Gy0914_2324_14b_nyelv {

    static ArrayList<Vizsga> sikeres = new ArrayList<>();
    static ArrayList<Vizsga> sikertelen = new ArrayList<>();
    
    public static void main(String[] args) {
        feltolt(sikeres,"sikeres.csv");
        feltolt(sikertelen,"sikertelen.csv");
        _f6();
    }

    private static void feltolt(ArrayList<Vizsga> lista, String fn) {
        File f = new File(fn);
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            while(be.hasNextLine()){
                lista.add(new Vizsga(be.nextLine()));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void _f6() {
        double o;
        try {
            FileWriter fw = new FileWriter("osszesites.csv");
            for (int i = 0; i < sikeres.size(); i++) {
                o = sikeres.get(i).getOssz() + sikertelen.get(i).getOssz();
                fw.write(String.format("%s ; %f ; %.2f \n",
                sikeres.get(i).getNyelv(),o,sikeres.get(i).getOssz()/o*100));
            }
            fw.close();
        } catch (IOException ex) {
            System.out.println("Hiba: "+ex);
        }
    }
    
}
