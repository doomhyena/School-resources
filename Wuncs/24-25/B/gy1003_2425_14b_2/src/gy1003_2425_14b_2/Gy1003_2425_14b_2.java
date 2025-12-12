/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1003_2425_14b_2;

import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;

class Versenyzo implements Comparable<Versenyzo> {

    private String nev;
    private String ok;
    private double tech;
    private double komp;
    private int hiba;
    private double ossz;

    public Versenyzo(String nev, String ok, double tech, double komp, int hiba) {
        this.nev = nev;
        this.ok = ok;
        this.tech = tech;
        this.komp = komp;
        this.hiba = hiba;
        this.ossz = tech + komp - hiba;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public String getOk() {
        return ok;
    }

    public void setOk(String ok) {
        this.ok = ok;
    }

    public double getTech() {
        return tech;
    }

    public void setTech(double tech) {
        this.tech = tech;
    }

    public double getKomp() {
        return komp;
    }

    public void setKomp(double komp) {
        this.komp = komp;
    }

    public int getHiba() {
        return hiba;
    }

    public void setHiba(int hiba) {
        this.hiba = hiba;
    }

    public double getOssz() {
        return ossz;
    }

    public void setOssz(double ossz) {
        this.ossz = ossz;
    }

    @Override
    public String toString() {
        return nev+";" + ok+";"+ossz;
    }

    @Override
    public int compareTo(Versenyzo t) {
        return Double.compare(t.ossz, ossz);
    }

}

public class Gy1003_2425_14b_2 {

    static ArrayList<Versenyzo> rovid = new ArrayList<>();
    static ArrayList<Versenyzo> donto = new ArrayList<>();

    public static void main(String[] args) {
        feltolt("rovidprogram.csv", rovid);
        feltolt("donto.csv", donto);
        System.out.println("2. Feladat: "+rovid.size());
        System.out.println(_f3());
        _f4(_f5());
        _f7();
        _f8();
        
    }

    private static void feltolt(String fname, ArrayList<Versenyzo> lista) {
        File f = new File(fname);
        try {
            Scanner be = new Scanner(f,"UTF-8");
            String sor;
            String [] adatok;
            be.nextLine();
            while (be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                lista.add(new Versenyzo(adatok[0], adatok[1],
                 Double.parseDouble(adatok[2]),
                 Double.parseDouble(adatok[3]),
                 Integer.parseInt(adatok[4])));
            }
            
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static String _f3() {
        for (Versenyzo n : donto) {
            if (n.getOk().equals("HUN"))
                return "Bejutott.";
        }
        
        return "Nem jutott be.";
    }

    private static void _f4(String nev) {
        double osszesen = 0;
        
        for (Versenyzo n : rovid) {
            if (n.getNev().equals(nev))
                osszesen += n.getOssz();
        }
        
        for (Versenyzo n : donto) {
            if (n.getNev().equals(nev))
                osszesen += n.getOssz();
        }
        
        if (osszesen > 0)
            System.out.println("Pontszám: "+osszesen);
        
    }

    private static String _f5() {
        Scanner be = new Scanner(System.in).useDelimiter("\n");
        System.out.print("Kérek egy nevet: ");
        String nev = be.next();
        
        for (Versenyzo n : rovid) {
            if (n.getNev().equals(nev))
                return nev;
        }
        
        System.out.println("Nincs ilyen versenyzõ!");
        return nev;
        
        
    }

    private static void _f7() {
        HashMap <String,Integer> orszagok = new HashMap<>();
        
        for (Versenyzo n : donto) {
            if (!orszagok.containsKey(n.getOk()))
                orszagok.put(n.getOk(),1);
            else
                orszagok.put(n.getOk(), orszagok.get(n.getOk())+1);   
        }
        
        for (String ok : orszagok.keySet()){
            if (orszagok.get(ok) > 1)
                System.out.println(ok+": "+orszagok.get(ok));
             
        }
        
        
    }

    private static void _f8() {
//        Collections.sort(donto);
//        
//        for (Versenyzo n : donto){
//            System.out.println(n);
//        }
        
        ArrayList<Versenyzo> veg = new ArrayList<>();
        
        Versenyzo v;
        
        for (Versenyzo d : donto){
            v = new Versenyzo(d.getNev(),d.getOk(),
            d.getTech(),d.getKomp(),d.getHiba());
            
            for (Versenyzo r : rovid){
                if (d.getNev().equals(r.getNev())){
                    v.setOssz(d.getOssz()+r.getOssz());
                }
            
            }
            veg.add(v);
        }
        
        Collections.sort(veg);
        
        try{
            FileWriter fw = new FileWriter("vegeredmeny.csv");
            int h = 1;
            for (Versenyzo n : veg){
                fw.write(h+";"+n+"\n");
                h++;
            }
            fw.close();
        }
        catch (Exception e){
            System.out.println(e);
        }
        
    }

}
