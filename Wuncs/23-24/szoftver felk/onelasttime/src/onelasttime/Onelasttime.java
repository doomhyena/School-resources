/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package onelasttime;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

class Ember{
    String nev;
    int mag;
    boolean nem;

    public Ember(String nev, int mag, boolean nem) {
        this.nev = nev;
        this.mag = mag;
        this.nem = nem;
    }

    @Override
    public String toString() {
        return "Ember{" + "nev=" + nev + ", mag=" + mag + ", nem=" + nem + '}';
    }
    
    
    
}




public class Onelasttime {

    static ArrayList<Ember> emberek = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        System.out.println(emberek);
        
        atlag();
        stat();
        
    }

    private static void feltolt() {
        File f = new File("konzol.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor ;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                if (adatok[2].equals("1"))
                    emberek.add(new Ember(adatok[0],
                            Integer.parseInt(adatok[1]), true));
                else
                    emberek.add(new Ember(adatok[0],
                            Integer.parseInt(adatok[1]), false));
            }
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void atlag() {
        double avg = 0;
        
        for (Ember n : emberek) {
            avg += n.mag;
        }
        
        avg /= emberek.size();
        //String formázás!!!!
        System.out.printf("Átlag: %.2f \n",avg); //Kiírás 2 tizedesre kerekítve
        //Formázás eltárolása
        String s = String.format("Átlag: %.2f", avg);
        
        
        
        
        
    }

    private static void stat() {
        HashMap<Boolean, Integer> nemek = new HashMap<>();
        
        for (Ember n : emberek) {
            if (!nemek.containsKey(n.nem))
                nemek.put(n.nem, 1);
            else
                nemek.put(n.nem, nemek.get(n.nem)+1);
            
        }
        
        System.out.println(nemek);
    }
    
}
