/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0914_2324_14a;

import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy0914_2324_14a {

    static ArrayList<Vizsga> sikeres = new ArrayList<>();
    static ArrayList<Vizsga> sikertelen = new ArrayList<>();
    public static void main(String[] args) {
        feltolt(sikeres,"sikeres.csv");
        feltolt(sikertelen,"sikertelen.csv");
        kiir();
        _f6();
    }

    private static void feltolt(ArrayList<Vizsga> lista, String fn) {
        File f = new File(fn);
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            while(be.hasNextLine()){
               lista.add(new Vizsga(be.nextLine()));
            }
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void kiir() {
        for (Vizsga n : sikeres) {
            System.out.println(n.getNyelv());
            System.out.println(n.getEred());
            System.out.println(n.getOssz());
        }
        
        
    }

    private static void _f6() {
        try {
            FileWriter fw = new FileWriter("osszesites.csv");
            double o;
            for (int i = 0; i < sikeres.size(); i++) {
                o = sikeres.get(i).getOssz()+sikertelen.get(i).getOssz();
                fw.write(String.format(" %s ; %f ; %.2f \n",sikeres.get(i).getNyelv(),o,sikeres.get(i).getOssz()/o*100));
            }
            fw.close();
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }
    
}
