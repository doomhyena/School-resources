/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0907_2324_14a;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy0907_2324_14a {

    static ArrayList<Dolgozo> dolgozok =
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        System.out.println("3. Feladat: "+dolgozok.size());
        _f4();
    }

    private static void feltolt() {
        File f = new File("citrom.txt");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                dolgozok.add(new Dolgozo(adatok[0], adatok[1],
                        adatok[2], Integer.parseInt(adatok[3]),
                        Integer.parseInt(adatok[4])));
            }
            
        } catch (Exception e) {
            System.out.println("Hiba");
        }
    }

    private static void _f4() {
        double atlag = 0;
        for (Dolgozo n : dolgozok) {
            atlag+=n.getBer();
        }
        atlag/=dolgozok.size();
        atlag/=1000;
        System.out.printf("Átlagbér: %.1f eFt.\n",atlag);
    }
    
}
