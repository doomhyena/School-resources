/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0403_2223_13a;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Eredmeny{
    private String date;
    private String gp;
    private int pos;
    private int laps;
    private int pts;
    private String team;
    private String status;

    public Eredmeny(String date, String gp, int pos, int laps, int pts, String team, String status) {
        this.date = date;
        this.gp = gp;
        this.pos = pos;
        this.laps = laps;
        this.pts = pts;
        this.team = team;
        this.status = status;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getGp() {
        return gp;
    }

    public void setGp(String gp) {
        this.gp = gp;
    }

    public int getPos() {
        return pos;
    }

    public void setPos(int pos) {
        this.pos = pos;
    }

    public int getLaps() {
        return laps;
    }

    public void setLaps(int laps) {
        this.laps = laps;
    }

    public int getPts() {
        return pts;
    }

    public void setPts(int pts) {
        this.pts = pts;
    }

    public String getTeam() {
        return team;
    }

    public void setTeam(String team) {
        this.team = team;
    }

    @Override
    public String toString() {
        return "Eredmeny{" + "date=" + date + ", gp=" + gp + ", pos=" + pos + ", laps=" + laps + ", pts=" + pts + ", team=" + team + ", status=" + status + '}';
    }
    
    
}

public class Gy0403_2223_13a {

    static ArrayList<Eredmeny> eredmenyek = 
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        System.out.println("3. Feladat: "+eredmenyek.size());
        _f4();
        _f5();
    }

    private static void feltolt() {
        File f = new File("schumacher.csv");
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                eredmenyek.add(new Eredmeny(adatok[0], adatok[1],
                        Integer.parseInt(adatok[2]), Integer.parseInt(adatok[3]),
                        Integer.parseInt(adatok[4]), adatok[5], adatok[6]));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void _f4() {
        System.out.println("4. Feladat: ");
        for (Eredmeny n : eredmenyek) {
            if (n.getGp().contains("Hungarian") && n.getPos() != 0)
                System.out.println(n.getDate()+": "+n.getPos()+". hely");
        }
    }

    private static void _f5() {
        System.out.println("5. Feladat: ");
        ArrayList<String> hibak =
                new ArrayList<>();
        for (Eredmeny n : eredmenyek){
            if (n.getPos() == 0 && !hibak.contains(n.getStatus()))
                hibak.add(n.getStatus());
        }
        
        int db;
        
        for (String hiba : hibak){
            db = 0;
            for (Eredmeny n : eredmenyek){
                if (n.getStatus().equals(hiba))
                    db++;
            }
            
            if (db>2)
                System.out.println(hiba+": "+db);
        }
    }
    
}
