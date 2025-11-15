/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1007_2526_13b_2;

import java.util.Arrays;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1007_2526_13b_2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        /*
        Feladat: Hozzon létre egy 5 elemû tömböt és töltse fel
        1 és 100 közötti véletlen generált számokkal!
        Írja ki az outputra
        
        Döntse el a tömb összes elemérõl, hogy páros e vagy sem.
        Írja ki az outputra, hogy az adott szám páros e...
        
        */
        
        int t[] = new int[5];
        Random rnd = new Random();
        
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(100-1+1)+1;
        }
        
        System.out.println(Arrays.toString(t));
        
        for (int i = 0; i < t.length; i++) {
            if (t[i]%2 == 0){
                System.out.println(t[i]+" páros");
            }
            else{
                System.out.println(t[i]+" páratlan");
            }
        }
        //---------------Programozási tételek-----------------
        //I. összegzés tétele: Összegzi a tömb elemeinek értékét!
        int osszeg = 0;
        for (int i = 0; i < t.length; i++) {
            osszeg += t[i];
        }
        System.out.println("Összeg: "+osszeg);
        
        //II. Maximum/minimum kiválasztás tétle: Kiválasztja a tömb legkisebb/legnagyobb elemét.
        int max = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i] > max){
                max = t[i];
            }
        }
        System.out.println("Max: "+max);
        int min = 101; //Az egyik legjobb kezdõérték a t[0]
        for (int i = 0; i < t.length; i++) {
            if (t[i] < min){
                min = t[i];
            }
        }
        System.out.println("Min: "+min);
        System.out.println("----------------------------------------------");
        //Feladat: Összegezze a tömb páratlan számait. Írja ki az outputra.
        int p_osszeg = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i]%2 == 1){
                p_osszeg += t[i];
            }
        }
        System.out.println("Páratlan számok összege: "+p_osszeg);
       
    }
    
}
