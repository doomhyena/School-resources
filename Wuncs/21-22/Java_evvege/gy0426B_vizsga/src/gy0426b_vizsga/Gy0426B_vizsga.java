/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0426b_vizsga;

import java.io.File;
import java.io.FileNotFoundException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Wuncs.David
 */
public class Gy0426B_vizsga {

    /**
     * @param args the command line arguments
     */
    static ArrayList<Ad> ads;
    static SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
    public static void main(String[] args) throws ParseException {
        ads = loadFromCsv("realestates.csv");
        
        for (Ad n : ads) {
            System.out.println(n); 
        }
        
    }

    private static ArrayList<Ad> loadFromCsv(String f_name) throws ParseException {
        ArrayList<Ad> lista = new ArrayList<>();
        File f = new File(f_name);
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                lista.add(new Ad(Integer.parseInt(adatok[0]),
                Integer.parseInt(adatok[1]),adatok[2],
                Integer.parseInt(adatok[3]),
                Integer.parseInt(adatok[4]),adatok[5],adatok[6],
                adatok[7],sdf.parse(adatok[8]),
                Integer.parseInt(adatok[9]),adatok[10],adatok[11],
                Integer.parseInt(adatok[12]),adatok[13]));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
        
        
        return lista;
    }
    
}
