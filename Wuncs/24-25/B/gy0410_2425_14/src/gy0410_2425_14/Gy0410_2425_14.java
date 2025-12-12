/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0410_2425_14;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;

class Film implements Comparable<Film>{
    private String cim;
    private String fran;
    private int ev;
    private double imdb;

    public Film(String cim, String fran, int ev, double imdb) {
        this.cim = cim;
        this.fran = fran;
        this.ev = ev;
        this.imdb = imdb;
    }

    public double getImdb() {
        return imdb;
    }

    public void setImdb(double imdb) {
        this.imdb = imdb;
    }

    public String getCim() {
        return cim;
    }

    public void setCim(String cim) {
        this.cim = cim;
    }

    public String getFran() {
        return fran;
    }

    public void setFran(String fran) {
        this.fran = fran;
    }

    public int getEv() {
        return ev;
    }

    public void setEv(int ev) {
        this.ev = ev;
    }

    @Override
    public String toString() {
        return cim + ", " + fran + ", " + ev + "," + imdb;
    }

    @Override
    public int compareTo(Film t) {
        return ev-t.ev;
    }
    
    
}


public class Gy0410_2425_14 {

    static ArrayList<Film> filmek = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        //Legnagyobb imdb pontszám Avengers filmnél.
        imdb_max();
        stat();
        kiir();
    }

    private static void feltolt() {
        File f = new File("movies.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            String sor;
            be.nextLine();
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                filmek.add(new Film(
                        adatok[0],
                        adatok[1],
                        Integer.parseInt(adatok[2]),
                        Double.parseDouble(adatok[3])));
            }
            
        } catch (FileNotFoundException ex) {
            System.out.println(ex);
        }
    }

    private static void imdb_max() {
        //a megoldás
        Film max = new Film("-", "-", 0, 0);
        for (Film n : filmek){
            if (n.getFran().equals("Avengers") &&
                    n.getImdb()>max.getImdb())
                max = n;
            
        }
        System.out.println("Legjobb avengers film: "+max.getCim());
        System.out.println("Pontszám: "+max.getImdb());
        
        //b megoldás
        String cim = "-";
        double p = 0;
        for (Film n : filmek) {
            if (n.getFran().equals("Avengers") &&
                    n.getImdb()>p){
                cim = n.getCim();
                p = n.getImdb();
            }
        }
        System.out.println("Film: "+cim);
        System.out.println("pont: "+p);
    }

    private static void stat() {
        HashMap<String,Integer> fr = new HashMap<>();
        for (Film n : filmek) {
            if (!fr.containsKey(n.getFran())){
                fr.put(n.getFran(), 1);
            }
            else{
                fr.put(n.getFran(), fr.get(n.getFran())+1);
            }
        }
        for (String franchise : fr.keySet()){
            System.out.println(franchise+": "+fr.get(franchise));
        }
    }

    private static void kiir() {
        Collections.sort(filmek);
        try {
            FileWriter fw = new FileWriter("filmek.txt");
            
            for (Film n : filmek) {
                fw.write(n+"\n");
            }
            fw.close();
        } catch (Exception e) {
            System.out.println(e);
        }
    }
}
