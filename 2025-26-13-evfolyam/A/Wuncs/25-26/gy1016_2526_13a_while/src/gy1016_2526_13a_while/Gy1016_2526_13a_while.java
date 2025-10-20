/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1016_2526_13a_while;

import java.util.Random;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy1016_2526_13a_while {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
//        int a = rnd.nextInt(120-80+1)+80;
//        while(a < 100){
//            System.out.println(a);
//            a = rnd.nextInt(120-80+1)+80;
//        }
//        System.out.println(a);
//        int a;
//        do{
//           a = rnd.nextInt(120-80+1)+80;
//            System.out.println(a);
//        }while(a < 100);
        
        Scanner be = new Scanner(System.in);
//        System.out.print("Kérek egy számot 1 és 100 között: ");
//        int szam = be.nextInt();
//        while(szam < 1 || szam > 100){
//            System.out.print("1 és 100 között!!!:  ");
//            szam = be.nextInt();
//        }
//        int szam;
//        do{
//            System.out.print("Kérek egy számot 1 és 100 között: ");
//            szam = be.nextInt();
//        }while(szam < 1 || szam > 100);
//        int gsz = rnd.nextInt(100-1+1)+1;
//        System.out.println("Gondoltam egy számra 1 és 100 között. Találd ki!");
//        int szam;
//        int db = 0;
//        do{
//            System.out.print("Tipp: ");
//            szam = be.nextInt();
//            db++;
//            if (gsz > szam)
//                System.out.println("A gondolt szám nagyobb!");
//            else if (gsz < szam)
//                System.out.println("A gondolt szám kisebb!");
//        }while(szam != gsz);
//        System.out.println("Gratulálok! "+db+" tipped volt.");
        
        //Feladat: Kérjen be egész számot a felhasználótól 0 végjelig!
        /*
            Írja ki a beadott számok összegét.
            Írja ki a legkisebb beadott számot.
            Írja ki, hogy hány darab számot adott be a felhasználó
            Írja ki a beadott számok átlagát.
        */
        int szam;
        int db = 0;
        double ossz = 0;
        int min = Integer.MAX_VALUE;
        
        do{
            System.out.print("Kérek egész számot (0 kilépés): ");
            szam = be.nextInt();
            if (szam != 0){
                ossz += szam;
                db++;
                if (szam < min)
                    min = szam;
            }
        }while(szam != 0);
        double avg = ossz/db;
        System.out.println("Összeg: "+ossz);
        System.out.println("Min: "+min);
        System.out.println("Db: "+db);
        System.out.println("Átlag: "+avg);
        
        
        
        
    }
    
}
