/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package konz0530_gyak;

import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

class Eredmeny{
    String h_nev,v_nev;
    int h_pont,v_pont;
    String hely,ido;

    public Eredmeny(String h_nev, String v_nev,
                    int h_pont, int v_pont,
                    String hely, String ido) {
        this.h_nev = h_nev;
        this.v_nev = v_nev;
        this.h_pont = h_pont;
        this.v_pont = v_pont;
        this.hely = hely;
        this.ido = ido;
    }
    
    
}


public class Konz0530_gyak {

    static ArrayList<Eredmeny> eredmenyek =
            new ArrayList<>();
    
    public static void main(String[] args) {
        feltolt();
        statisztika();
    }

    private static void feltolt() {
        File f = new File("eredmenyek.csv");
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine(); // Az egész sort beolvassa és stringként tárolja.
                adatok = sor.split(";"); //A sort feldarabolja a pontosvesszők mentén,
                // így egy tömb keletkezik (adatok).
                //Ennek a tömbnek az indexeiben vannak az adataink.
                eredmenyek.add(new Eredmeny(
                        adatok[0]/*első oszlop*/,
                        adatok[1]/*második oszlop*/,
                        Integer.parseInt(adatok[2]) /*harmadik oszlop*/,
                        Integer.parseInt(adatok[3])/*negyedik oszlop*/,
                        adatok[4]/*ötödik oszlop*/,
                        adatok[5]/*hatodik oszlop*/));
                
            }
            
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void statisztika() {
        /*Az egyes csapatok hány hazai mérkőzést játszottak*/
        HashMap<String,Integer> csapatok =
                new HashMap<>();
        
        for (Eredmeny n : eredmenyek){
            if (!csapatok.containsKey(n.h_nev))
                csapatok.put(n.h_nev, 1);
            else
                csapatok.put(n.h_nev, csapatok.get(n.h_nev)+1);
        }
        
        for (String csap : csapatok.keySet())
            System.out.println(csap+": "+csapatok.get(csap));
        
        //Ha ezt fájlba kell
        try {
            FileWriter fw = new FileWriter("stat.txt");
            for (String csap : csapatok.keySet())
                fw.write(csap+": "+csapatok.get(csap)+"\n");
            fw.close();
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
        
        //Listás megoldás
        try {
            FileWriter fw2 = new FileWriter("stat2.txt");
            ArrayList<String> csapatok2 = new ArrayList<>();
            
            for (Eredmeny n : eredmenyek){
                if (!csapatok2.contains(n.h_nev))
                    csapatok2.add(n.h_nev);
            }
            
            int db;
            for (String csapat : csapatok2){
                db = 0;
                for (Eredmeny n : eredmenyek){
                    if (n.h_nev.equals(csapat))
                        db++;
                }
                
                fw2.write(csapat+": "+db+"\n");
            }
            fw2.close();
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
        
    }
    
}
