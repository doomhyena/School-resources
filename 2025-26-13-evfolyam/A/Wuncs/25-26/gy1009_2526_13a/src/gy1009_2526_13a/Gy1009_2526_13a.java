/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1009_2526_13a;

import java.io.PrintWriter;
import java.util.Arrays;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1009_2526_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        
        int t[] = new int[7];
        
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(30-5+1)+5;
        }
        System.out.println("Tömb: "+Arrays.toString(t));
        
        int p_osszeg = 0;
        
        for (int i = 0; i < t.length; i++) {
            if (t[i]%2 == 1)
                p_osszeg += t[i];
            
        }
        System.out.println("Páratlan számok összege: "+p_osszeg);
        
        //III. Megszámlálás tétele: Megszámolja, hogy hány elem felel a megadott feltételnek!
        //Feltétel: Hány db 3-mal osztható szám van?
        int db = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i]%3 == 0)
                db++; // db = db+1;
        }
        System.out.println(db+" db 3-mal osztható szám van");
        
        //IV. Kiválogatás tétele: Kiírja a feltételnek megfelelõ elemeket
        //Feltétel: 25-nél nagyobb számok
        System.out.print("25-nél nagyobb számok: ");
        int x = 0;
        
        for (int i = 0; i < t.length; i++) {
            if (t[i] > 25 && x == 0){
                x++;
                System.out.print(t[i]);
            }
            
            else if (t[i] > 25 && x == 1 )
                System.out.print(", "+t[i]);
        }
        System.out.println("");
        
        int a = 25;
        
        
    }
    
}
