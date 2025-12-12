/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1015_2425_14a;

import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;


class Merkozes implements Comparable<Merkozes>{
    private String h_nev;
    private String v_nev;
    private int h_pont;
    private int v_pont;
    private String hely;
    private String ido;

    public Merkozes(String h_nev, String v_nev, int h_pont, int v_pont, String hely, String ido) {
        this.h_nev = h_nev;
        this.v_nev = v_nev;
        this.h_pont = h_pont;
        this.v_pont = v_pont;
        this.hely = hely;
        this.ido = ido;
    }

    public String getIdo() {
        return ido;
    }

    public void setIdo(String ido) {
        this.ido = ido;
    }

    public String getH_nev() {
        return h_nev;
    }

    public void setH_nev(String h_nev) {
        this.h_nev = h_nev;
    }

    public String getV_nev() {
        return v_nev;
    }

    public void setV_nev(String v_nev) {
        this.v_nev = v_nev;
    }

    public int getH_pont() {
        return h_pont;
    }

    public void setH_pont(int h_pont) {
        this.h_pont = h_pont;
    }

    public int getV_pont() {
        return v_pont;
    }

    public void setV_pont(int v_pont) {
        this.v_pont = v_pont;
    }

    public String getHely() {
        return hely;
    }

    public void setHely(String hely) {
        this.hely = hely;
    }

    @Override
    public String toString() {
        return h_nev + " - " + v_nev + ", " + h_pont + " : " + v_pont;
    }

    @Override
    public int compareTo(Merkozes t) {
        return h_nev.compareTo(t.h_nev); //String
        //return h_pont-t.h_pont; //Integer
        //return Double.compare(h_pont, v_pont); //Double
    }
    
    
    
    
}




public class Gy1015_2425_14a {

    static ArrayList<Merkozes> merkozesek = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        //Stadionok alapján
        stat_stadion();
        //Idõpontok alapján. Egyes dátumokon hány mérkõzést
        stat_ido();
        //Csapatonként, az egyes csapatok hány pontot szereztek összesen hazai mérkõzéseken
        //Csak azokat írjuk ki, akik 1500 felett vannak
        stat_hazai();
        
        //Írjuk ki egy külsõ fájlba a mérkõzéseket (haza-vendég,pontok) hazai csapat szerint abc rendben.
        fajlba();
        
        //Rendezés!
        Collections.sort(merkozesek);
    }

    private static void feltolt() {
       File f = new File("eredmenyek.csv");
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                merkozesek.add(new Merkozes(
                        adatok[0], adatok[1],
                        Integer.parseInt(adatok[2]),
                        Integer.parseInt(adatok[3]),
                        adatok[4], adatok[5]));
                
            }
        } catch (Exception e) {
            System.out.println(e);
        }
        
    }

    private static void stat_stadion() {
        HashMap<String,Integer> stadionok = new HashMap<>();
        
        for (Merkozes n : merkozesek) {
            if (!stadionok.containsKey(n.getHely())){
                stadionok.put(n.getHely(), 1);
            }
            else{
                stadionok.put(n.getHely(), stadionok.get(n.getHely())+1);
            }
        }
        
        for (String key : stadionok.keySet()){
            System.out.println(key+": "+stadionok.get(key));
        }
        
    }

    private static void stat_ido() {
        HashMap<String,Integer> idok = new HashMap<>();
        
        for (Merkozes n : merkozesek) {
            if (!idok.containsKey(n.getIdo()))
                idok.put(n.getIdo(), 1);
            else
                idok.put(n.getIdo(), idok.get(n.getIdo())+1);
        }
        for (String key : idok.keySet())
            System.out.println(key+": "+idok.get(key));
    }

    private static void stat_hazai() {
        HashMap<String,Integer> hazai = new HashMap<>();
        
        for (Merkozes n : merkozesek) {
            if (!hazai.containsKey(n.getH_nev()))
                hazai.put(n.getH_nev(), n.getH_pont());
            else
                hazai.put(n.getH_nev(), hazai.get(n.getH_nev())+n.getH_pont());
            
        }
        
        for (String key : hazai.keySet())
            if (hazai.get(key) > 1500)
                System.out.println(key+": "+hazai.get(key));
    }

    private static void fajlba() {
        try {
            FileWriter fw = new FileWriter("meccsek.txt");
            for (Merkozes n : merkozesek) {
                fw.write(n+"\n");
            }
            fw.close();
        } catch (Exception e) {
            System.out.println(e);
        }
    }
    
}
