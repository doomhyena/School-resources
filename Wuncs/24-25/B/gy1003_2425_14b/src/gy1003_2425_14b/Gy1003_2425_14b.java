/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1003_2425_14b;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Dij{
    private int ev;
    private String tip;
    private String kn;
    private String vn;

    public Dij(int ev, String tip, String kn, String vn) {
        this.ev = ev;
        this.tip = tip;
        this.kn = kn;
        this.vn = vn;
    }

    public String getVn() {
        return vn;
    }

    public void setVn(String vn) {
        this.vn = vn;
    }

    public int getEv() {
        return ev;
    }

    public void setEv(int ev) {
        this.ev = ev;
    }

    public String getTip() {
        return tip;
    }

    public void setTip(String tip) {
        this.tip = tip;
    }

    public String getKn() {
        return kn;
    }

    public void setKn(String kn) {
        this.kn = kn;
    }

    @Override
    public String toString() {
        return ev + ": " + kn + " " + vn;
    }
    
    
    
    
}


public class Gy1003_2425_14b {

    static ArrayList<Dij> dijak = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        _f7();
        _f8();
        
    }

    private static void feltolt() {
        File f = new File("nobel.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                
                if (adatok.length == 4){
                    dijak.add(
                    new Dij(Integer.parseInt(adatok[0]),
                            adatok[1],adatok[2], adatok[3]));
                }
                else{
                    dijak.add(
                    new Dij(Integer.parseInt(adatok[0]),
                            adatok[1],adatok[2], "-"));
                }
                
            }
            
            
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void _f7() {
        HashMap<String, Integer> tipusok =
                new HashMap<>();
        
        for (Dij n : dijak) {
            if (!tipusok.containsKey(n.getTip())){
                tipusok.put(n.getTip(), 1);
            }
            else{
                tipusok.put(n.getTip(), tipusok.get(n.getTip())+1);
            }
            
        }
        
        System.out.println(tipusok);
    }

    private static void _f8() {
        try {
            FileWriter fw = new FileWriter("orvosi.txt");
            Collections.reverse(dijak);
            for (Dij n : dijak) {
                if (n.getTip().equals("orvosi")){
                    fw.write(n+"\n");
                }
            }
            
            fw.close();
        } catch (IOException ex) {
            System.out.println(ex);
        }
    }
    
}
