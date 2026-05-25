/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package gy1009_2526_14;

import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;

class Nobel implements Comparable<Nobel>{
    private int ev;
    private String tip;
    private String kn;
    private String vn;

    public Nobel(int ev, String tip, String kn, String vn) {
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
        return ev + ", " + tip + ", " + kn + ", " + vn;
    }

    @Override
    public int compareTo(Nobel o) {
        return ev-o.ev;
    }

    
    
    
    
}


public class Gy1009_2526_14 {

    static ArrayList<Nobel> dijak = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        _f3();
        _f4();
        _f5();
        _f6();
        _f7();
        Collections.sort(dijak);
        _f8();
       
    }

    private static void feltolt() {
        File f = new File("nobel.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String adatok[];
            
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                
                if (adatok.length == 4)
                    dijak.add(new Nobel(Integer.parseInt(adatok[0]),
                    adatok[1],adatok[2],adatok[3]));
                else
                    dijak.add(new Nobel(Integer.parseInt(adatok[0]),
                    adatok[1],adatok[2],"-"));
                
                
            }
            
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void _f3() {
       
        for (Nobel n : dijak) {
            if (n.getKn().equals("Arthur B.")){
                System.out.println("3. Feladat: "+n.getTip());
            }
        }
        
    }

    private static void _f4() {
        for (Nobel n : dijak) {
            if (n.getEv() == 2017 && n.getTip().equals("irodalmi"))
                System.out.println("4. F.:"+n.getKn()+" "+n.getVn());
                
        }
    }

    private static void _f5() {
        System.out.println("5. Feladat: ");
        for (Nobel n : dijak) {
            if (n.getEv() > 1989 && n.getVn().equals("-") && n.getTip().equals("béke"))
                System.out.println(n.getKn());
            
        }
    }

    private static void _f6() {
        for (Nobel n : dijak) {
            if (n.getVn().contains("Curie"))
                System.out.println(n);
        }
    }

    private static void _f7() {
        HashMap<String, Integer> tipek = new HashMap<>();
        
        for (Nobel n : dijak) {
            if (!tipek.containsKey(n.getTip()))
                tipek.put(n.getTip(), 1);
            else
                tipek.put(n.getTip(), tipek.get(n.getTip())+1);
        }
        
        System.out.println(tipek);
        for (String k: tipek.keySet() ) {
            System.out.println(k+": "+tipek.get(k));
        }
        
    }

    private static void _f8() {
        try {
            FileWriter fw = new FileWriter("orvosi.txt");
            
            for (Nobel n : dijak) {
                if (n.getTip().equals("orvosi"))
                    fw.write(String.format("%d: %s %s \n",
                            n.getEv(),n.getKn(),n.getVn()));
            }
            
            fw.close();
        } catch (Exception e) {
            System.out.println(e);
        }
    }
    
}
