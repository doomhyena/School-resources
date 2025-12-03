/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package gy1002_2526_14;

import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;



class Pilota implements Comparable<Pilota>{
    private String nev;
    private String dat;
    private String team;
    private int gp;
    private int win;
    private String nat;

    public Pilota(String nev, String dat, String team, int gp, int win, String nat) {
        this.nev = nev;
        this.dat = dat;
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

    public String getDat() {
        return dat;
    }

    public void setDat(String dat) {
        this.dat = dat;
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
        return nev + " - " + win;
    }

    @Override
    public int compareTo(Pilota o) {
//        return o.nev.compareTo(nev); //Stringek rendezése
        return o.win-win; //Számok rendezése
    }

}





public class Gy1002_2526_14 {

    static ArrayList<Pilota> pilotak = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        
        
        Collections.sort(pilotak);
        for (Pilota n : pilotak) {
            System.out.println(n);
        }
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
            String adatok[];
            
            while (be.hasNextLine()) {
                sor = be.nextLine();
                
                adatok = sor.split(";");
                
                if (adatok[4].equals("")){
                    pilotak.add(new Pilota(adatok[0],adatok[1],adatok[2],
                Integer.parseInt(adatok[3]),0,adatok[5]));
                }
                else{
                     pilotak.add(new Pilota(adatok[0],adatok[1],adatok[2],
                Integer.parseInt(adatok[3]),Integer.parseInt(adatok[4]),adatok[5]));
                }
               
            }
            
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void _f5() {
        Pilota max = pilotak.get(0);
        
        for (Pilota n : pilotak) {
            if (n.getGp() > max.getGp())
                max = n;
        }
        System.out.println("5. Feladat: ");
        System.out.printf("%s, Futamok: %d \n",max.getNev(),max.getGp());
    }

    private static void _f6() {
        HashMap<String, String> csapatok = new HashMap<>();
        
        for (Pilota n : pilotak) {
            if (!csapatok.containsKey(n.getTeam()))
                csapatok.put(n.getTeam(), n.getNev()+" ");
            else
                csapatok.put(n.getTeam(), csapatok.get(n.getTeam())+n.getNev()+" ");
            
        }
        
        for (String k : csapatok.keySet()) {
            System.out.println(k+": "+csapatok.get(k));
        }
        
        
        
    }

    private static void _f7() {
        try {
            FileWriter fw = new FileWriter("Gyoztesek.txt");
            for (Pilota n : pilotak) {
                if (n.getWin()>0)
                    fw.write(n+"\n");
            }
            fw.close();
        } catch (Exception e) {
            System.out.println(e);
        }
    }
    
}
