/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0314_2223_14b_kutya;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy0314_2223_14b_kutya {

    static HashMap<Integer,String> nevek =
            new HashMap<>();
    static HashMap<Integer,Elnevezes> fajtak =
            new HashMap<>();
    static ArrayList<Kezeles> kezelesek =
            new ArrayList<>();
    
    public static void main(String[] args) {
        _f2();
        System.out.println("3. Feladat: "+nevek.size());
        _f4();
        _f5();
        _f6();
        _f7();
        _f8();
        
    }

    private static void _f2() {
        File f = new File("KutyaNevek.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                
                nevek.put(Integer.parseInt(adatok[0]),
                        adatok[1]);
            }
            
        } catch (Exception e) {
        }
    }

    private static void _f4() {
        File f = new File("KutyaFajtak.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                
                fajtak.put(Integer.parseInt(adatok[0]),
                        new Elnevezes(adatok[1], adatok[2]));
            }
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void _f5() {
        File f = new File("Kutyak.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                kezelesek.add(new Kezeles(
                        Integer.parseInt(adatok[0]),
                        Integer.parseInt(adatok[1]),
                        Integer.parseInt(adatok[2]),
                        Integer.parseInt(adatok[3]), adatok[4]));
            }
            
            
        } catch (Exception e) {
        }
    }

    private static void _f6() {
        
    }

    private static void _f7() {
        Kezeles max = kezelesek.get(0);
        
        for (Kezeles n : kezelesek) {
            if (n.kor>max.kor)
                max = n;
        }
        System.out.println("7. Feladat: ");
        System.out.println("\tLegidősebb neve: "+nevek.get(max.nev_id));
        System.out.println("\tLegidősebb fajtája: "+fajtak.get(max.fajta_id).magyar);
    }

    private static void _f8() {
        int db;
        for (int id : fajtak.keySet()){
            db = 0;
            for (Kezeles n : kezelesek){
                if (n.datum.equals("2018.01.10")
                    && n.fajta_id == id)
                    db++;
            }
            if (db>0)
            System.out.println(
             fajtak.get(id).magyar+": "+db);
        }
    }
    
}
