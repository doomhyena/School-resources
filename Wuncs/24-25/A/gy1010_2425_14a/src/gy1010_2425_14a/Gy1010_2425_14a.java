/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1010_2425_14a;

import java.io.File;
import java.io.FileWriter;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Date;
import java.util.HashMap;
import java.util.Scanner;

class Pilota implements Comparable<Pilota>{
    private String nev;
    private Date szul;
    private String team;
    private int gp;
    private int win;
    private String nat;

    public Pilota(String nev, Date szul, String team, int gp, int win, String nat) {
        this.nev = nev;
        this.szul = szul;
        this.team = team;
        this.gp = gp;
        this.win = win;
        this.nat = nat;
    }

    public String getNat() {
        return nat;
    }

    public void setNat(String nat) {
        this.nat = nat;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public Date getSzul() {
        return szul;
    }

    public void setSzul(Date szul) {
        this.szul = szul;
    }

    public String getTeam() {
        return team;
    }

    public void setTeam(String team) {
        this.team = team;
    }

    public int getGp() {
        return gp;
    }

    public void setGp(int gp) {
        this.gp = gp;
    }

    public int getWin() {
        return win;
    }

    public void setWin(int win) {
        this.win = win;
    }

    @Override
    public String toString() {
        return "Pilota{" + "nev=" + nev + ", szul=" + szul + ", team=" + team + ", gp=" + gp + ", win=" + win + ", nat=" + nat + '}';
    }

    @Override
    public int compareTo(Pilota t) {
        return t.win-win;
    }
    
    
}



public class Gy1010_2425_14a {

    static ArrayList<Pilota> pilotak = new ArrayList<>();
    static SimpleDateFormat sdf = new SimpleDateFormat("yyyy.MM.dd");
    public static void main(String[] args) {
        feltolt();
        _f5();
        _f6();
        _f7();
    }

    private static void feltolt() {
        File f = new File("Mezony.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                
                if (!adatok[4].equals("")){
                    pilotak.add(new Pilota(
                            adatok[0],
                            sdf.parse(adatok[1]),
                            adatok[2],
                            Integer.parseInt(adatok[3]),
                            Integer.parseInt(adatok[4]),
                            adatok[5]));
                }
                else{
                    pilotak.add(new Pilota(
                            adatok[0],
                            sdf.parse(adatok[1]),
                            adatok[2],
                            Integer.parseInt(adatok[3]),
                            0,
                            adatok[5]));
                }
            }
            
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void _f6() {
        HashMap<String,String> csapatok = new HashMap<>();
        
        for (Pilota n : pilotak) {
            if (!csapatok.containsKey(n.getTeam()))
                csapatok.put(n.getTeam(), n.getNev());
            else
                csapatok.put(n.getTeam(), csapatok.get(n.getTeam())+", "+n.getNev());
        }
        
        for (String csapat: csapatok.keySet()){
            System.out.println(csapat+": "+csapatok.get(csapat));
        }
        
        HashMap<String,ArrayList<String>> cspt = new HashMap<>();
        
        for (Pilota n : pilotak) {
            if (!cspt.containsKey(n.getTeam()))
                cspt.put(n.getTeam(), new ArrayList<>(Arrays.asList(n.getNev())));
            else{
                cspt.get(n.getTeam()).add(n.getNev());
                cspt.put(n.getTeam(), cspt.get(n.getTeam()));
            }
                
        }
        
        System.out.println(cspt);
        
    }

    private static void _f7() {
        Collections.sort(pilotak);
        
        try {
            FileWriter fw = new FileWriter("Gyoztesek.txt");
            for (Pilota n : pilotak) {
                if (n.getWin()>0)
                    fw.write(n.getNev()+" - "+n.getWin()+"\n");
            }
            
            fw.close();
        } catch (Exception e) {
        }
    }

    private static void _f5() {
        Pilota min = pilotak.get(0);
        
        for (Pilota n : pilotak) {
            if (n.getGp()>min.getGp())
                min = n;
        }
        System.out.println(min.getNev()+": "+min.getGp());
    }
    
}
