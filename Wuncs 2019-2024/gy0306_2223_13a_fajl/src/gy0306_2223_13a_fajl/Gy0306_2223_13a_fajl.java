/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0306_2223_13a_fajl;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;





/**
 *
 * @author wuncs.david
 */
public class Gy0306_2223_13a_fajl {

    //static String szo;
    //static int szam;
    static ArrayList<String> gyumolcsok =
            new ArrayList<>();
    static ArrayList<Integer> szamok =
            new ArrayList<>();
    public static void main(String[] args) {
        beolvas();
        System.out.println(gyumolcsok);
        szam_beolvas();
        System.out.println(szamok);
    }

    private static void beolvas() {
        File f = new File("feladatra.txt");
        try{
            Scanner be = new Scanner(f,"ISO-8859-2"); //"ISO-8859-2"
            String sor;
            while(be.hasNextLine()){ //Több sor beolvasásához
                sor = be.nextLine();
                gyumolcsok.add(sor); //gyumolcsok.add(be.nextLine());
                
            }  
        }
        catch (FileNotFoundException fnf){
            System.out.println("Hiba: "+fnf);
        }
    }

    private static void szam_beolvas() {
        File f = new File("szam.txt");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                for (int i = 0; i < adatok.length; i++) {
                    szamok.add(Integer.parseInt(adatok[i]));
                }
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }
    
    
}
