/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0921_2324_14a;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy0921_2324_14a {

    static HashMap<Integer,String> qtyanevek = 
            new HashMap<>();
    static HashMap<Integer,Fajta> qtyafajtak =
            new HashMap<>();
    static ArrayList<Kutya> qtyak = new ArrayList<>();
    
    public static void main(String[] args) {
        q_nev();
        q_fajtak();
        q();
        
        kiir();
        
        System.out.println("3. Feladat: "+qtyanevek.size());
        _f6();
        _f7();
        _f8();
    }

    private static void q_nev() {
        File f = new File("KutyaNevek.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            String sor;
            String [] adatok;
            be.nextLine();
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                qtyanevek.put(
                   Integer.parseInt(adatok[0]),adatok[1]);
            }
            
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void q_fajtak() {
        File f = new File("KutyaFajtak.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            String sor;
            String [] adatok;
            be.nextLine();
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                if (adatok.length == 3)
                    qtyafajtak.put(
                   Integer.parseInt(adatok[0]),
                   new Fajta(adatok[1], adatok[2]));
                else
                    qtyafajtak.put(
                   Integer.parseInt(adatok[0]),
                   new Fajta(adatok[1], "-"));
            }
            
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void q() {
        File f = new File("Kutyak.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            String sor;
            String [] adatok;
            be.nextLine();
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                qtyak.add(new Kutya(Integer.parseInt(adatok[0]),
                qtyafajtak.get(Integer.parseInt(adatok[1])).nev,
                qtyanevek.get(Integer.parseInt(adatok[2])),
                Integer.parseInt(adatok[3]),adatok[4]));
            }
            
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void kiir() {
        for (Kutya n : qtyak) {
            System.out.println(n);
        }
    }

    private static void _f6() {
        double atlag = 0;
        for (Kutya n : qtyak) {
            atlag += n.getKor();
        }
        atlag/=qtyak.size();
        System.out.printf("6. Feladat: %.2f \n",atlag);
    }

    private static void _f7() {
        Kutya max = qtyak.get(0);
        
        for (Kutya n : qtyak) {
            if (n.getKor()>max.getKor())
                max = n;
        }
        
        System.out.println("7. Feladat: "+max);
    }

    private static void _f8() {
        HashMap<String,Integer> kf = new HashMap<>();
        
        for (Kutya n : qtyak) {
            if (n.getDatum().equals("2018.01.10") &&
                !kf.containsKey(n.getFajta())){
                kf.put(n.getFajta(), 1);
            }
            else if (n.getDatum().equals("2018.01.10")){
                kf.put(n.getFajta(),
                        kf.get(n.getFajta())+1);
            }
        }
        
        System.out.println("8. Feladat:\n"+kf);
    }
    
}
