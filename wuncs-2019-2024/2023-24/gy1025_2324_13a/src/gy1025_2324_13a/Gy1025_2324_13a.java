/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1025_2324_13a;

import java.util.Arrays;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1025_2324_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
//        //<editor-fold defaultstate="collapsed" desc="For ciklus">
        //for (int i = 0; i < 10; i++) {
//            System.out.println(i);
//        }
//        System.out.println("----------------------");
//        for (int i = -5; i <= 10; i+=2) {
//            System.out.println(i);
//        }
//        System.out.println("---------------");
//        for (int i = 0; i < 100; i++) {
//            if (i%2 == 0 && i%5 == 0)
//                System.out.println(i);
//        }
//        System.out.println("-------------------");
//</editor-fold>
        
        int [] t = new int[10];
        Random rnd = new Random();
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(100-1+1)+1; //Tömb feltöltése
        }
        
        System.out.println(Arrays.toString(t));
        for (int i = 0; i < t.length; i++) {
            System.out.println("Tömb "+(i+1)+". eleme: "+t[i]);
            //Tömb elemeinek kiírása
        }
        //Írja ki a tömb páros értékeit.
        
        for (int i = 0; i < t.length; i++) {
            if (t[i] % 2 == 0)
                System.out.println("Páros: "+t[i]);
            
        }
        
        //Hány db páros eleme van a tömbnek?
        int db = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i] % 2 == 0)
                db++;
        }
        System.out.println(db+" páros szám van.");
        
    }
    
}
