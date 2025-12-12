/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0426_vizsga;

import java.awt.Event;
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
public class Gy0426_vizsga {

    /**
     * @param args the command line arguments
     */
    static ArrayList<Ad> ads;
    static SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
    public static void main(String[] args) throws ParseException {
        ads = loadFromCsv("realestates.csv");
        
//        for (Ad n : ads) {
//            System.out.println(n);
//        }
        f6();
        f8();
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
                Integer.parseInt(adatok[3]),Integer.parseInt(adatok[4]),
                adatok[5],adatok[6],adatok[7],sdf.parse(adatok[8]),
                Integer.parseInt(adatok[9]),adatok[10],adatok[11],
                Integer.parseInt(adatok[12]),adatok[13]));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
        
        return lista;
    }

    private static void f6() {
        double atlag = 0;
        int db = 0;
        
        for (Ad n : ads) {
            if (n.floors==0){
                db++;
                atlag+=n.area;
            }
        }
        
        System.out.printf("Földszinti ingatlanok átlagos alapterülete: %.2fm^2 \n",(atlag/db));
    }

    private static Double distanceTo(String gps, Ad ingatlan) {
        String [] s_gps = gps.split(",");
        String [] s_ingatlan = ingatlan.latlong.split(",");
        double [] d_gps = {Double.parseDouble(s_gps[0]),Double.parseDouble(s_gps[1])};
        double [] d_ingatlan = {Double.parseDouble(s_ingatlan[0]),Double.parseDouble(s_ingatlan[1])};
        
        return Math.sqrt(Math.pow(d_gps[0]-d_ingatlan[0], 2)+
               Math.pow(d_gps[1]-d_ingatlan[1], 2));
    }

    private static void f8() {
        double min = 10000000;
        Ad min_inf = null;
        
        for (Ad n : ads) {
            if (n.freeofcharge && distanceTo("47.4164220114023,19.066342425796986", n)<min){
                min = distanceTo("47.4164220114023,19.066342425796986", n);
                min_inf = n;
            }
        }
        System.out.println("Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai: ");
        System.out.println("\tEladó neve\t: "+min_inf.seller.name);
        System.out.println("\tEladó telefonja\t: "+min_inf.seller.phone);
        System.out.println("\tAlapterület\t: "+min_inf.area);
        System.out.println("\tSzobák száma\t: "+min_inf.rooms);
    }
    
}
