/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1016_2526_tetelek_of;

import java.util.Arrays;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1016_2526_tetelek_of {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        int [] t = new int[10]; //10 elemû tömb létrehozása
        
        //Tömb feltöltése 1 és 100 közötti számokkal
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(100-1+1)+1;
        }
        System.out.println("Tömb: "+Arrays.toString(t));
        //Programozási tételek
        //I. Összegzés tétele
        int ossz = 0;
        for (int i = 0; i < t.length; i++) {
            ossz += t[i];
        }
        System.out.println("Összeg: "+ossz);
        
        //II. Minimum/Maximum kiválasztás tétele
        int min = t[0];
        
        for (int i = 0; i < t.length; i++) {
            if (t[i] < min)
                min = t[i];
        }
        System.out.println("Minimum: "+min);
        //III. Megszámlálás tétele
        //Feltétel: Héttel osztható számok
        int db = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i]%7 == 0)
                db++;
        }
        System.out.println(db+" db héttel osztható szám van.");
        
        //IV. Kiválogatás tétele
        //Feltétel: Páros számok
        System.out.print("Páros számok: ");
        for (int i = 0; i < t.length; i++) {
            if (t[i]%2 == 0)
                System.out.print(t[i]+" ");
        }
        System.out.println("");
        
        //V. Rendezés
        int cs;
        for (int i = 0; i < t.length; i++) {
            for (int j = i+1; j < t.length; j++) {
                if (t[i] > t[j]){
                    cs = t[i];
                    t[i] = t[j];
                    t[j] = cs;
                }
            }
        }
        System.out.println("Rendezett tömb: "+Arrays.toString(t));
        
        
    }
    
}
