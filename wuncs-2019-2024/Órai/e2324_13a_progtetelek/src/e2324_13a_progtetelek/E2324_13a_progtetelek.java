/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package e2324_13a_progtetelek;

import java.util.Arrays;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class E2324_13a_progtetelek {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int [] t = new int[10];
        Random rnd = new Random();
        
        //Tömb feltöltése
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(100-1+1)+1;
        }
        
        System.out.println("Tömb: "+Arrays.toString(t));
        
        //Összegzés tétele: Összeadja a tömb elemeinek értékét.
        int osszeg = 0;
        for (int i = 0; i < t.length; i++) {
            osszeg += t[i];
        }
        System.out.println("Összeg: "+osszeg);
        
        //Maximum kiválasztás tétele: Kiválasztja a tömb legnagyobb értékét.
        int max = t[0]; // A 0 is tökéletes.
        for (int i = 0; i < t.length; i++) {
            if (t[i] > max)
                max = t[i];
        }
        System.out.println("Max: "+max);
        
        //Minimum kiválasztás tétele:
        int min = t[0]; // A 101 is tökéletes.
        for (int i = 0; i < t.length; i++) {
            if (t[i] < min)
                min = t[i];
        }
        System.out.println("Min: "+min);
        System.out.println("---------------------");
        //Feladat: Megszámlálás a páros számokra.
        int paros = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i]%2 == 0)
                paros++;
        }
        
        //Kiválogatás tétele: Páros számok
        int volt = 0;
        System.out.print("A tömb páros számai:");
        for (int i = 0; i < t.length; i++) {
            if (t[i] % 2 == 0){
                volt++;
                if (volt<paros)
                    System.out.print(t[i]+",");
                else
                    System.out.print(t[i]);
            }  
        }
        System.out.println("");
        //Megszámlálás: Hány db elem felel meg a feltételnek.
        //Feltétel: Páratlan számok
        int db = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i]%2 != 0)
                db++;
        }
        System.out.println(db+" páratlan szám van.");
        
        //Eldöntés tétele: A feltétel teljesül-e. Igen van nem.
        //Feltétel: Van 70-nél nagyobb szám?
        boolean van = false;
        
        for (int i = 0; i < t.length; i++) {
            
            if (t[i]>70){
                van = true;
            }
            
        }
        if (van) //tagadás !van
        System.out.println("70-nél van nagyobb szám.");
        else{
        System.out.println("70-nél nincs nagyobb szám.");
        }
        
        
    }
    
}
