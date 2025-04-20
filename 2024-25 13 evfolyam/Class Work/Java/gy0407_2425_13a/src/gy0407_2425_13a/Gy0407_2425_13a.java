package gy0407_2425_13a;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class Gy0407_2425_13a {
    
    static int szam;
    static ArrayList<Integer> szamok1 = new ArrayList<>();
    static ArrayList<Integer> szamok2 = new ArrayList<>();
    static ArrayList<Szemely> szemelyek = new ArrayList<>();
    public static void main(String[] args) {
        System.out.println("-- Első fájl --");
        feltolt1();
        System.out.println(szam);
        System.out.println("-- Második fájl --");
        feltolt2();
        System.out.println("-- Harmadik fájl --");
        feltolt3();
        System.out.println(szamok2);
        System.out.println("-- Negyedik fájl --");
        feltolt4();
        // System.out.println(szemelyek);
        for (Szemely n : szemelyek) {
            System.out.println(n);
        }
    }

    private static void feltolt1() {
        File f = new File("elso.txt");
        try{
        Scanner be = new Scanner(f,"UTF-8"); //ISO-8859-2
        String elem = be.nextLine();
            //System.out.println(elem);
            szam = Integer.parseInt(elem);
        }
        catch(FileNotFoundException e){
            System.out.println("Hiba: "+ e);
        }
    }
    private static void feltolt2() {
        File f = new File("masodik.txt");
        try{
            Scanner be = new Scanner(f, "UTF8");
            while (be.hasNext()) {

                String sor = be.nextLine();
                String[] elemek = sor.split(",");
                for (String elem : elemek) {
                    System.out.println(elem);
                }
            }
        } catch(FileNotFoundException e) {
            System.out.println("Hiba: "+ e);
        }
    }
    private static void feltolt3() {
        File f = new File("harmadik.txt");
        try{
            Scanner be = new Scanner(f,"UTF-8");
            String sor;
            while (be.hasNextLine()) {
                sor = be.nextLine();
                szamok2.add(Integer.parseInt(sor));
            }
        } catch(FileNotFoundException e) {
            System.out.println("Hiba: "+ e);
        }
    }
    private static void feltolt4() {
        File f = new File("negyedik.txt");
        try{
            Scanner be = new Scanner(f,"UTF-8");
            String sor;
            String[] adatok;
            Szemely sz;
            while (be.hasNextLine()) {
                sor = be.nextLine();
                adatok = sor.split(",");
                //System.out.println(Arrays.toString(adatok));
                sz = new Szemely(adatok[0], Integer.parseInt(adatok[1]));
                //System.out.println(sz);
                szemelyek.add(sz);
                //System.out.println(szemelyek);
            }
        } catch(FileNotFoundException e) {
            System.out.println("Hiba: "+ e);
        }
    }
    
}
