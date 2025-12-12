/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1008_2425_14a;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

class Stadion {
    private String varos;
    private String n1;
    private String n2;
    private int fh;

    public Stadion(String varos, String n1, String n2, int fh) {
        this.varos = varos;
        this.n1 = n1;
        this.n2 = n2;
        this.fh = fh;
    }

    public int getFh() {
        return fh;
    }

    public void setFh(int fh) {
        this.fh = fh;
    }

    public String getVaros() {
        return varos;
    }

    public void setVaros(String varos) {
        this.varos = varos;
    }

    public String getN1() {
        return n1;
    }

    public void setN1(String n1) {
        this.n1 = n1;
    }

    public String getN2() {
        return n2;
    }

    public void setN2(String n2) {
        this.n2 = n2;
    }

    @Override
    public String toString() {
        return "Stadion{" + "varos=" + varos + ", n1=" + n1 + ", n2=" + n2 + ", fh=" + fh + '}';
    }
    
    
}



public class Gy1008_2425_14a {

    static ArrayList<Stadion> stadionok = new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        System.out.println("3. Feladat: "+stadionok.size());
        _f4();
        _f5();
        _f6();
        _f7();
    }

    private static void feltolt() {
        File f = new File("vb2018.txt");
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            String sor;
            String [] adatok;
            
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                stadionok.add(new Stadion(adatok[0], adatok[1], adatok[2],
                Integer.parseInt(adatok[3])));
            }
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void _f4() {
        Stadion min = stadionok.get(0);
        for (Stadion n : stadionok) {
            if (n.getFh() < min.getFh())
                min = n;
        }
        System.out.println(min);
        //-----------------------------
        int m = Integer.MAX_VALUE;
        String ms = "";
        for (Stadion n : stadionok) {
            if (n.getFh() < m){
                m = n.getFh();
                ms = n.getN1();
            }
        }
        System.out.println(ms+": "+m);
    }

    private static void _f5() {
        double avg = 0;
        
        for (Stadion n : stadionok) {
            avg += n.getFh();
        }
        
        System.out.printf("5.: %.1f átlagos befogadószám\n",avg/stadionok.size());
    }

    private static void _f6() {
        int db = 0;
        
        for (Stadion n : stadionok) {
            if (!n.getN2().equals("n.a."))
                db++;
        }
        System.out.println("6.: "+db);
    }

    private static void _f7() {
        String varos;
        Scanner be = new Scanner(System.in);
        do{
            System.out.print("Kérek egy városnevet: ");
            varos = be.next();
        }while(varos.length() < 3);
    }
    
}
