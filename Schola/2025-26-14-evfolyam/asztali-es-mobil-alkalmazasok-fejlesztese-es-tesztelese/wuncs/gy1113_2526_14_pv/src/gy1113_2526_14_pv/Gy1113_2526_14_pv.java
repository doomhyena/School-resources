/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1113_2526_14_pv;

import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;

class Film implements Comparable<Film>{
    private String cim;
    private String fr;
    private int ev;
    private double imdb;

    public Film(String cim, String fr, int ev, double imdb) {
        this.cim = cim;
        this.fr = fr;
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

    public String getFr() {
        return fr;
    }

    public void setFr(String fr) {
        this.fr = fr;
    }

    public int getEv() {
        return ev;
    }

    public void setEv(int ev) {
        this.ev = ev;
    }

    @Override
    public String toString() {
        return cim + ", "+ev;
    }

    @Override
    public int compareTo(Film lajos) {
        return ev-lajos.ev;
    }
    
    
}

public class Gy1113_2526_14_pv {

    static ArrayList<Film> filmek =
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        System.out.println("4. Feladat: "+filmek.size());
        _f5();
        _f6();
        Collections.sort(filmek);
        _f7();
        
    }

    private static void feltolt() {
        File f = new File("movies.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor; 
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                filmek.add(new Film(adatok[0], adatok[1],
                        Integer.parseInt(adatok[2]),
                        Double.parseDouble(adatok[3])));
            }
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void _f5() {
        Film max = filmek.get(0);
        
        for (Film n : filmek) {
            if (n.getImdb()>max.getImdb())
                max = n;
        }
        System.out.printf("5. Feladat: %s, %.1f \n",max.getCim(),max.getImdb());
        
    }

    private static void _f6() {
        HashMap<String,Integer> fran = new HashMap<>();
        
        for (Film n : filmek) {
            if (!fran.containsKey(n.getFr()))
                fran.put(n.getFr(), 1);
            else
                fran.put(n.getFr(), fran.get(n.getFr())+1);
        }
        
        for (String key : fran.keySet()){
            System.out.println(key+": "+fran.get(key));
        }
        
        
    }

    private static void _f7() {
        try{
            FileWriter fw = new FileWriter("filmek.txt");
            for (Film n : filmek) {
                fw.write(n+"\n");
            }
            fw.close();
        }
        catch(Exception e){
            System.out.println(e);   
        }
    }
    
}
