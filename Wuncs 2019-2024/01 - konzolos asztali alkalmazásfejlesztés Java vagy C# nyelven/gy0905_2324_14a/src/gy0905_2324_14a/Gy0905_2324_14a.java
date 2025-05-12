/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0905_2324_14a;

import java.awt.Event;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author wuncs.david
 */
public class Gy0905_2324_14a {

    static ArrayList<Eredmeny> ric = new ArrayList<>();
    static ArrayList<Eredmeny> ros = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir(ros);
        kiir(ric);
        f6();
        f7();
        f8();
        _f9();
    }

    private static void feltolt() {
        File f = new File("eredmenyek2016.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                ric.add(new Eredmeny(adatok[0],Integer.parseInt(adatok[1]),
                                    Integer.parseInt(adatok[2]),
                                    Integer.parseInt(adatok[3])));
                ros.add(new Eredmeny(adatok[0],Integer.parseInt(adatok[4]),
                                    Integer.parseInt(adatok[5]),
                                    Integer.parseInt(adatok[6])));
            }
            
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void kiir(ArrayList<Eredmeny> lista) {
        for (Eredmeny n : lista) {
            System.out.println(n);
        }
    }

    private static void f6() {
        int rospts = 0;
        int ricpts = 0;
        
        for (int i = 0; i < ric.size(); i++) {
            rospts += ros.get(i).getPts();
            ricpts += ric.get(i).getPts();
        }
        
        System.out.println("Ricciardo: "+ricpts);
        System.out.println("Rosberg: "+rospts);
    }

    private static void f7() {
        int atl = 0;
        
        for (Eredmeny n : ros) {
            atl += n.getStart();
        }
        
        atl /= ros.size();
        
        System.out.println("Rosberg átlag: "+atl);
    }

    private static void f8() {
        for (int i = 0; i < ric.size(); i++) {
            if (ros.get(i).getFinish() <= 3 && ric.get(i).getFinish() <= 3)
                System.out.println(ros.get(i).getGp()+": Rosberg - "+
                        ros.get(i).getFinish()+
                        " ; Ricciardo - "+ric.get(i).getFinish());
        }
    }

    private static void _f9() {
        HashMap <Integer,Integer> ric_ered = new HashMap<>();
        
        for (Eredmeny n : ric){
            if (!ric_ered.containsKey(n.getFinish())){
                ric_ered.put(n.getFinish(), 1);
            }
            else{
                ric_ered.put(n.getFinish(), ric_ered.get(n.getFinish())+1);
            }
        }
        
        System.out.println(ric_ered);
    }
    
}
