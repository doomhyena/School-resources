/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0327_2223;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Eredmeny{
    String nev;
    int mat;
    int ang;
    int inf;

    public Eredmeny(String nev, int mat, int ang, int inf) {
        this.nev = nev;
        this.mat = mat;
        this.ang = ang;
        this.inf = inf;
    }
    
    public double avg(){
        double atlag = mat+ang+inf;
        return atlag/3;
    }

    @Override
    public String toString() {
        return nev + "\n\tMatek: " + mat + "\n\tAngol: " + ang + "\n\tInformatika: " + inf;
    }
    
    
}

public class Gy0327_2223 {

    static ArrayList<Eredmeny> eredmenyek =
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir();
        //Kik buktak meg valamilyen tárgyból?
        bukottak();
        //Mennyi lett az osztály átlaga matekból?
        matekavg();
        //Mennyi lett az osztály átlaga a három tárgyból
        //összesen?
        fullavg();
        //Hányan kaptak ötöst angolból? Kik voltak?
        otosok();
    }

    private static void feltolt() {
        File f = new File("adatok.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                eredmenyek.add(new Eredmeny(
                        adatok[0],
                        Integer.parseInt(adatok[1]),
                        Integer.parseInt(adatok[2]),
                        Integer.parseInt(adatok[3])));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void kiir() {
        for (Eredmeny n : eredmenyek) {
            System.out.println(n);
        }
    }

    private static void bukottak() {
        System.out.println("Bukottak: ");
        for (Eredmeny n : eredmenyek) {
            if (n.mat == 1 || n.ang == 1 || n.inf == 1)
                System.out.println(n.nev);
        }
    }

    private static void matekavg() {
        double matavg = 0;
        for (Eredmeny n : eredmenyek)
            matavg += n.mat;
        matavg /= eredmenyek.size();
        System.out.println("Átlag: "+matavg);
    }

    private static void fullavg() {
        double full = 0;
        for (Eredmeny n : eredmenyek)
            full+=n.avg();
        full /= eredmenyek.size();
        System.out.println("Teljes átlag: "+full);
    }

    private static void otosok() {
        int db = 0;
        System.out.println("Ötösök: ");
        for (Eredmeny n : eredmenyek){
            if (n.ang == 5){
                db++;
                System.out.println(n.nev);
            }
        }
    }
    
}
