/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1108_2324_13a;

import java.util.Arrays;
import java.util.Collections;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1108_2324_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        int [] t = new int[rnd.nextInt(15-5+1)+5];
        
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(100-1+1)+1;
        }
        System.out.println(Arrays.toString(t));
        
        int max = t[0];
        for (int i = 0; i < t.length; i++) {
            if (max < t[i]){
                max = t[i];
            }
        }
        System.out.println("Max: "+max);
        
        int db = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i] > 70 && t[i] % 2 == 0)
                db++;
        }
        System.out.println(db+" 70-nél nagyobb páros szám van.");
        
        boolean van_e = false;
        
        for (int i = 0; i < t.length; i++) {
            if (t[i]%2 == 0)
                van_e = true;
        }
        
        if (van_e){
            int min = 101;
            for (int i = 0; i < t.length; i++) {
                if (t[i]%2 == 0 && t[i]<min)
                    min = t[i];
            }
            System.out.println("Legkisebb páros: "+min);
        }
        else
            System.out.println("Nincs páros szám.");
        
        
    }
    
}
