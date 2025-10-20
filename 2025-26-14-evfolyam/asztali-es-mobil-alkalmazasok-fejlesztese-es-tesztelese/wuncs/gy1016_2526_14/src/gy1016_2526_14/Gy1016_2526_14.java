/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package gy1016_2526_14;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Scanner;

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


public class Gy1016_2526_14 {

    static ArrayList<Eredmeny> eredmenyek = new ArrayList<>();
    public static void main(String[] args) {
       feltolt();
        System.out.println("3. Feladat: "+eredmenyek.size());
        _f4();
        _f5();
    }

    private static void feltolt() {
        File f = new File("schumacher.csv");
        
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while (be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                eredmenyek.add(new Eredmeny(
                adatok[0],adatok[1],
                Integer.parseInt(adatok[2]),
                Integer.parseInt(adatok[3]),
                Integer.parseInt(adatok[4]),
                        adatok[5],adatok[6]
                ));
                
            }
            
            
        } catch (Exception ex) {
            System.out.println(ex);
        }
        
        
    }

    private static void _f4() {
        for (Eredmeny n : eredmenyek) {
            if (n.getGp().contains("Hungarian") && n.getPos() != 0)
                System.out.println(n.getDate()+": "+n.getPos());
        }
    }

    private static void _f5() {
        HashMap<String,Integer> er =new HashMap<>();
        
        for (Eredmeny n : eredmenyek) {
            if (!er.containsKey(n.getStatus()) && n.getPos() == 0)
                er.put(n.getStatus(), 1);
            else if (n.getPos() == 0)
                er.put(n.getStatus(), er.get(n.getStatus())+1);
        }
        
        for (String key : er.keySet()){
            if (er.get(key) > 2)
                System.out.println(key+": "+er.get(key));
        }
        
        
    }
    
}
