/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0202_2223_14a_kemia;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Elem{
    private String ev;
    private String nev;
    private String vegyjel;
    private int rsz;
    private String felfedezo;

    public Elem(String ev, String nev, String vegyjel, int rsz, String felfedezo) {
        this.ev = ev;
        this.nev = nev;
        this.vegyjel = vegyjel;
        this.rsz = rsz;
        this.felfedezo = felfedezo;
    }

    public String getFelfedezo() {
        return felfedezo;
    }

    public void setFelfedezo(String felfedezo) {
        this.felfedezo = felfedezo;
    }

    public String getEv() {
        return ev;
    }

    public void setEv(String ev) {
        this.ev = ev;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public String getVegyjel() {
        return vegyjel;
    }

    public void setVegyjel(String vegyjel) {
        this.vegyjel = vegyjel;
    }

    public int getRsz() {
        return rsz;
    }

    public void setRsz(int rsz) {
        this.rsz = rsz;
    }

    @Override
    public String toString() {
        return ev + ", " + nev + ", " + vegyjel + ", " + rsz + ", " + felfedezo;
    } 
}

public class Gy0202_2223_14a_kemia {

    static ArrayList<Elem> elemek = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        
        for (Elem n : elemek)
            System.out.println(n);
        
        System.out.println("3. Feladat: "+elemek.size());
        _f4();
        System.out.println(_f6(_f5()));
        _f7();
        _f8();
    }

    private static void feltolt() {
        File f = new File("felfedezesek.csv");
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            String sor;
            String [] adatok;
            be.nextLine();
            while(be.hasNext()){
                sor = be.nextLine();
                adatok = sor.split(";");
                elemek.add(new Elem(adatok[0], adatok[1],
                        adatok[2],
                        Integer.parseInt(adatok[3]),
                        adatok[4]));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void _f4() {
        int db = 0;
        for (Elem n : elemek) {
            if (n.getEv().equals("Ókor"))
                db++;
        }
        System.out.println("Ókor: "+db);
    }

    private static String _f5() {
        String k;
        Scanner be = new Scanner(System.in);
        do{
            System.out.print("Kérek egy vegyjelet: ");
            k = be.next();
        } while(!k.matches("[A-Za-z]+") || k.length()>2);
        return k;
    }

    private static String _f6(String vj) {
        for (Elem n : elemek) {
            if (n.getVegyjel().equalsIgnoreCase(vj)){
                return n.getVegyjel()+"\n"
                      +n.getFelfedezo()+"\n"+
                       n.getRsz()+"\n"+n.getEv()+"\n"+
                       n.getNev();
            }
        }
        return "Nincs ilyen elem.";
    }

    private static void _f7() {
        int max = 0;
        for (int i = 0; i < elemek.size()-1; i++) {   
        try {
            if (Integer.parseInt(elemek.get(i+1).getEv())-
                Integer.parseInt(elemek.get(i).getEv())
                > max)
            max = Integer.parseInt(elemek.get(i+1).getEv())-
                  Integer.parseInt(elemek.get(i).getEv());
   
        } catch (Exception e) {
        }
        }
        System.out.println("7. feladat: "+max);
    }

    private static void _f8() {
//        //<editor-fold defaultstate="collapsed" desc="Klasszik">
//Klasszikus
//        ArrayList<String> evek = new ArrayList<>();
//        for (Elem n : elemek) {
//            if (!evek.contains(n.getEv()) &&
//                !n.getEv().equals("Ókor"))
//                evek.add(n.getEv());
//        }
//        System.out.println(evek);
//
//        int db;
//
//        for (String ev : evek) {
//            db = 0;
//            for (Elem n : elemek){
//                if (ev.equals(n.getEv()))
//                    db++;
//            }
//            if (db>3)
//                System.out.println(ev+": "+db);
//        }
//</editor-fold>
        
        HashMap<String,Integer> eves =
                new HashMap<>();
        
        for (Elem n : elemek){
            if (!n.getEv().equals("Ókor") &&
                eves.containsKey(n.getEv()))
       eves.put(n.getEv(), eves.get(n.getEv())+1);
            else if (!n.getEv().equals("Ókor"))
                eves.put(n.getEv(), 1);
        }
        System.out.println(eves);
        
        for (String ev : eves.keySet())
           if (eves.get(ev) > 3)
            System.out.println(ev+": "+eves.get(ev));
    }
    
}
