/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0907_2324_14b;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Eredmeny{
    private String gp;
    private int start;
    private int finish;
    private int pts;

    public Eredmeny(String gp, int start, int finish, int pts) {
        this.gp = gp;
        this.start = start;
        this.finish = finish;
        this.pts = pts;
    }

    public int getPts() {
        return pts;
    }

    public void setPts(int pts) {
        this.pts = pts;
    }

    public String getGp() {
        return gp;
    }

    public void setGp(String gp) {
        this.gp = gp;
    }

    public int getStart() {
        return start;
    }

    public void setStart(int start) {
        this.start = start;
    }

    public int getFinish() {
        return finish;
    }

    public void setFinish(int finish) {
        this.finish = finish;
    }

    @Override
    public String toString() {
        return "Eredmeny{" + "gp=" + gp + ", start=" + start + ", finish=" + finish + ", pts=" + pts + '}';
    }
      
}


public class Gy0907_2324_14b {

    static ArrayList<Eredmeny> ric = new ArrayList<>();
    static ArrayList<Eredmeny> ros = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir(ric);
        kiir(ros);
        _f6();
        _f7();
        _f8();
        _f9();
    }

    private static void feltolt() {
        File f = new File("eredmenyek2016.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                ric.add(new Eredmeny(adatok[0],Integer.parseInt(adatok[1]),
                                    Integer.parseInt(adatok[2]),
                                    Integer.parseInt(adatok[3])));
                ros.add(new Eredmeny(adatok[0],Integer.parseInt(adatok[4]),
                                    Integer.parseInt(adatok[5]),
                                    Integer.parseInt(adatok[6])));
                
            }
            
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void kiir(ArrayList<Eredmeny> lista) {
        for (Eredmeny n : lista) {
            System.out.println(n);
        }
    }

    private static void _f6() {
        int ricpts = 0;
        int rospts = 0;
        
        for (int i = 0; i < ric.size(); i++) {
            ricpts += ric.get(i).getPts();
            rospts += ros.get(i).getPts();
        }
        
        System.out.println("Ricciardo: "+ricpts);
        System.out.println("Rosberg: "+rospts);
    }

    private static void _f7() {
        int atlag = 0;
        for (Eredmeny n : ros) {
            atlag += n.getStart();
        }
        atlag/=ros.size();
        System.out.println("Átlag rajt: "+atlag);
    }

    private static void _f8() {
        for (int i = 0; i < ric.size(); i++) {
            if (ric.get(i).getFinish()<=3 && ros.get(i).getFinish()<=3)
                System.out.println(ric.get(i).getGp()+": "+
                        ric.get(i).getFinish()+" - "+ros.get(i).getFinish());
        }
    }

    private static void _f9() {
        HashMap<Integer,Integer> ric_ered =
                new HashMap<>();
        
        for (Eredmeny n : ric) {
            if (!ric_ered.containsKey(n.getFinish()))
                ric_ered.put(n.getFinish(), 1);
            else
                ric_ered.put(n.getFinish(), ric_ered.get(n.getFinish())+1);                
        }
        
        System.out.println(ric_ered);
        
        try {
            FileWriter fw = new FileWriter("ricstat.txt");
            for (int poz : ric_ered.keySet()){
                fw.write(poz+". hely: "+ric_ered.get(poz)+" db\n");
            }
            fw.close();
        } catch (IOException ex) {
            System.out.println("Hiba: "+ex);
        }
    }
    
}
