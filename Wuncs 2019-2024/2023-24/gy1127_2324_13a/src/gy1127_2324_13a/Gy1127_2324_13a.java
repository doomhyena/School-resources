/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1127_2324_13a;

import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy1127_2324_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        Scanner be = new Scanner(System.in);
        
        int [] t = new int[5];
        
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(50-5+1)+5;
        }
        System.out.println(Arrays.toString(t));
        
//        int sz1;
//        int sz2;
//        
//        System.out.println("Kérek két számot ami 1 és 5 között van.");
//        do{
//            System.out.print("Első szám: ");
//            sz1 = be.nextInt();
//            if (sz1<1)
//                System.out.println("Ez kisebb mint 1. NEM JÓ!");
//            else if (sz1>t.length)
//                System.out.println("Ez nagyobb mint 5. NEM JÓ!");
//            
//        }while(sz1<1 || sz1>t.length);
//        
//        do{
//            System.out.print("Második szám: ");
//            sz2 = be.nextInt();
//        }while(sz2<1 || sz2>t.length);
//        
//        
//        System.out.println("Kicserélem a(z) "+sz1+". és "+sz2+". helyen lévő elemeket.");
//        int csere = t[sz1-1];
//        t[sz1-1] = t[sz2-1];
//        t[sz2-1] = csere;
//        System.out.println(Arrays.toString(t));
        
        int min1 = 100;
        int min2 = 100;
        
        int [] kicsik = {100,100};
        
        for (int i = 0; i < t.length; i++) {
            if (t[i] < min1)
                min1 = t[i];
        }
        System.out.println("Min1: "+min1);
        
        for (int i = 0; i < t.length; i++) {
            if (t[i] < min2 && t[i] != min1)
                min2 = t[i];
        }
        System.out.println("Min2: "+min2);
        
        
        
    }
    
}
