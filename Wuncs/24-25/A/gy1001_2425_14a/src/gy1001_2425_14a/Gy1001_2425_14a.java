/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1001_2425_14a;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

class Versenyzo{
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
        this.ossz = tech+komp-hiba;
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
        return "Versenyzo{" + "nev=" + nev + ", ok=" + ok + ", tech=" + tech + ", komp=" + komp + ", hiba=" + hiba + ", ossz=" + ossz + '}';
    }

    
    
    
    
    
    
}





public class Gy1001_2425_14a {

    static ArrayList<Versenyzo> rovid = new ArrayList<>();
    static ArrayList<Versenyzo> donto = new ArrayList<>();
    public static void main(String[] args) {
        feltolt("rovidprogram.csv",rovid);
        feltolt("donto.csv",donto);
        System.out.println("2. feladat: "+rovid.size());
        System.out.println(_f3());
        //_f4("Mai MIHARA");
        _f4(_f5());
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
                lista.add(new Versenyzo(
                adatok[0],adatok[1],
                Double.parseDouble(adatok[2]),
                Double.parseDouble(adatok[3]),
                Integer.parseInt(adatok[4])
                ));
            }
            
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static String _f3() {
//        int index = 0;
//        while (index != donto.size()){
//            if (donto.get(index).getOk().equals("HUN"))
//                return "Bejutott";
//            index++;
//        }
//        return "Nem jutott be";
        
        for (Versenyzo n: donto){
            if (n.getOk().equals("HUN"))
                return "Bejutott.";
        }
        return "Nem jutott be.";  
    }

    private static void _f4(String nev) {
        double osszesen = 0;
        
        for (Versenyzo rov : rovid){
            if (rov.getNev().equals(nev))
                osszesen += rov.getOssz();
        }
        for (Versenyzo don : donto){
            if (don.getNev().equals(nev))
                osszesen += don.getOssz();
        }
        System.out.println(nev+": "+osszesen);
    }

    private static String _f5() {
        Scanner be = new Scanner(System.in).useDelimiter("\n");
        System.out.print("Kérek egy nevet: ");
        String nev = be.next();
        
        for (Versenyzo n : rovid){
            if (n.getNev().equals(nev))
                return nev;
        }
        
        System.out.println("NEM VOLT BENNE!");
        return nev;
    }
    
}
