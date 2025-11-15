/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1015_2526_13a;

import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy1015_2526_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        /*Hozzon létre egy inteket tároló tömböt.
        A tömb méretét a felhasználó adhassa meg!
        Töltse fel a tömböt 1 és 100 közötti számokkal!
        Írja ki a tömböt az outputra.
        Határozza meg a tömb PÁRATLAN INDEXEIN szereplõ értékek összegét
        Határozza meg a tömb legnagyobb páros számát.
        Határozza meg, hogy hány 50-nél nagyobb 3-mal osztható szám van a tömbben.
        
        */
        Random rnd = new Random();
        Scanner be = new Scanner(System.in);
        
//        System.out.print("Hány eleme legyen a tömbnek: ");
        int [] t = new int[10];
        
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(100-1+1)+1;
        }
//        
        System.out.println(Arrays.toString(t));
//        
//        int o = 0;
//        
//        for (int i = 0; i < t.length; i++) {
//            if ( i%2 == 1 )
//                o += t[i];
//            
//        }
//        System.out.println("Összeg: "+o);
//        
//        int max = Integer.MIN_VALUE;
//        
//        for (int i = 0; i < t.length; i++) {
//            if (t[i] > max && t[i]%2 == 0)
//                max = t[i];
//        }
//        if ( max != Integer.MIN_VALUE)
//            System.out.println("Legnagyobb páros szám: "+max);
//        else
//            System.out.println("Nincs páros szám!");
//        
//        int db = 0;
//        
//        for (int i = 0; i < t.length; i++) {
//            if ( t[i] > 50 && t[i]%3 == 0)
//                db++;
//        }
//        
//        System.out.println(db+" db 50-nél nagyobb 3-mal osztható szám van.");
        int a = 5;
        int b = 17;
        int csere;
        System.out.println(a+", "+b);
        csere = a;
        a = b;
        b = csere;
        System.out.println(a+", "+b);
        
        
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
        System.out.println(Arrays.toString(t));
        
        
    }
    
}
