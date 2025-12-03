/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0227_2223_13b;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;

class Szemely implements Comparable<Szemely>{
    String nev;
    int ev;
    int mag;

    public Szemely(String a) {
        if (a.contains(",")){
            String [] adatok = a.split(",");
            this.nev = adatok[0];
            this.ev = Integer.parseInt(adatok[1]);
            this.mag = Integer.parseInt(adatok[2]);
        }
        else{
            Random rnd = new Random();
            this.nev = a;
            this.ev = rnd.nextInt(2005-1995+1)+1995;
            this.mag = rnd.nextInt(200-150+1)+150;
        }
    }
    
    public String szok(){
        if (ev%4 == 0) return "Szökõév";
        return "";
    }

    @Override
    public String toString() {
        return nev + ", " + ev + ", " + mag + " cm, "+szok();
    }

    @Override
    public int compareTo(Szemely t) {
        return t.szok().compareTo(szok());
    }
    
    
    
    
}

public class Gy0227_2223_13b {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ArrayList<Szemely> szemelyek
                = new ArrayList<>();
        
        Szemely sz1 = new Szemely("Lajos,2000,170");
        Szemely sz2 = new Szemely("Anna,2006,190");
        szemelyek.add(sz2);
        szemelyek.add(sz1);
        
        feltolt(szemelyek);
        kiir(szemelyek);
        Collections.sort(szemelyek);
        System.out.println("---Rendezés---");
        kiir(szemelyek);
        
    }

    private static void feltolt(ArrayList<Szemely> lista) {
        for (int i = 0; i < 30; i++) {
            lista.add(new Szemely("Ember"+i));
        }
    }

    private static void kiir(ArrayList<Szemely> lista) {
        for (Szemely n : lista) {
            System.out.println(n);
        }
    }

    
}
