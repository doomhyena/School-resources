/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1014_2526_13b;

import java.util.Arrays;
import java.util.Random;



/**
 *
 * @author wuncs.david
 */
public class Gy1014_2526_13b {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       Random rnd = new Random();
       int [] t = new int[5];
       
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(55-5+1)+5;
        }
        System.out.println("Tömb: "+Arrays.toString(t));
        //Összegzés
        int ossz = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i] > 30 && t[i] < 50){
                ossz += t[i];
            }
        }
        System.out.println("Összeg: "+ossz);
        
        //Töltse fel újra a tömböt... 1 és 100 közötti PÁROS számokkal
        for (int i = 0; i < t.length;) {
            t[i] = rnd.nextInt(100-1+1)+1;
            if (t[i]%2 == 0){
                i++;
            }
        }
        System.out.println(Arrays.toString(t));
        //Megszámlálás tétele: Megszámolja, hogy hányszor teljesül a feltétel.
        //Feltétel: 70-nél nagyobb számok
        int db = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i] > 70) //Ha az elágazásom 1 sorral rendelkezik, akkor a kapcsoszárójel elhagyható
                db++; // db = db+1; db += 1
        }
        
        System.out.println(db+" db 70-nél nagyobb szám van");
        
        //Kiválogatás tétele: Kiírja azokat a számokat amik megfelelnek a feltételnek
        //Feltétel: 70-nél nagyobb számok
        int volt = 0;
        System.out.print("70-nél nagyobb számok: ");
        for (int i = 0; i < t.length; i++) {
            if (t[i] > 70 && volt == 0){
                System.out.print(t[i]);
                volt++;
            }
            else if (t[i] > 70)
                System.out.print(", "+t[i]);
        }
        
        System.out.println("");
        
       
       
    }
    
}
