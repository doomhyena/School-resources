/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0320_2223_13a;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author wuncs.david
 */
public class Gy0320_2223_13a {

    static ArrayList<String> nevek =
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir();
        beker();
        bovites();
    }

    private static void feltolt() {
        File f = new File("nevek.txt");
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(",");
                for (String adat : adatok)
                    nevek.add(adat);
                
            }
            
            
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void kiir() {
        for (String n : nevek) {
            System.out.println(n);
        }
    }

    private static void beker() {
        Scanner be = new Scanner(System.in);
        System.out.print("Kérek egy nevet: ");
        String nev = be.next();
        
        while(nevek.contains(nev)){
            System.out.println("Ez a név már benne van.");
            System.out.print("Kérek egy nevet: ");
            nev = be.next();
        }
        
        nevek.add(nev);
        kiir();
    }

    private static void bovites() {
        try {
            FileWriter fw = new FileWriter("nevek.txt");
            for (String n : nevek) {
                if (!n.equals(nevek.get(nevek.size()-1)))
                    fw.write(n+",");
                else
                    fw.write(n);
            }
            fw.close();
        } catch (IOException ex) {
            System.out.println("Hiba: "+ex);
        }
    }
    
}
