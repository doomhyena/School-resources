/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1113_2526_14;

import java.awt.Event;
import java.io.File;
import java.io.FileNotFoundException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;

class Pilota{
    private String nev;
    private Date szul;
    private String nat;
    private int rsz;

    public Pilota(String nev, Date szul, String nat, int rsz) {
        this.nev = nev;
        this.szul = szul;
        this.nat = nat;
        this.rsz = rsz;
    }

    public int getRsz() {
        return rsz;
    }

    public void setRsz(int rsz) {
        this.rsz = rsz;
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

    public String getNat() {
        return nat;
    }

    public void setNat(String nat) {
        this.nat = nat;
    }

    @Override
    public String toString() {
        return "Pilota{" + "nev=" + nev + ", szul=" + szul + ", nat=" + nat + ", rsz=" + rsz + '}';
    }
    
    
    
    
    
}


public class Gy1113_2526_14 {

    static ArrayList<Pilota> pilotak = new ArrayList<>();
    static SimpleDateFormat sdf = new SimpleDateFormat("yyyy.MM.dd");
    public static void main(String[] args) {
        feltolt();
//        for (Pilota n : pilotak)
//            System.out.println(n);
//        
        _f5();
        System.out.println(TimeUnit.MINUTES.convert(pilotak.get(0).getSzul().getTime(), TimeUnit.MILLISECONDS));
        
    }

    private static void feltolt() {
        File f = new File("pilotak.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                if (adatok.length == 3)
                    pilotak.add( new Pilota(
                            adatok[0],
                            sdf.parse(adatok[1]),
                            adatok[2],
                            0)  );
                else
                    pilotak.add( new Pilota(
                            adatok[0],
                            sdf.parse(adatok[1]),
                            adatok[2] ,
                            Integer.parseInt(adatok[3]))  );
            }
            
            
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void _f5() {
        try{
        for (Pilota n : pilotak) {
            if (n.getSzul().before(sdf.parse("1901.01.01")))
                System.out.println(n.getNev()+": "+sdf.format(n.getSzul()));
        }
        } catch(Exception e){
            System.out.println(e);
        }
    }
    
}
