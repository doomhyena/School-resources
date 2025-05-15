/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1018_2324_13a;

import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy1018_2324_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in);
        int a = 5;
        int b = 6;
        System.out.println("Szeretnéd összeadni a két számot? (igen v. nem)");
        String valasz = be.next();
        
        if (valasz.equalsIgnoreCase("igen"))
            System.out.println("A két szám összege: "+(a+b));
        else if (valasz.equalsIgnoreCase("nem"))
            System.out.println("A két szám különbsége: "+(a-b));
        
        int [] t = new int[3];
        Random rnd = new Random();
        System.out.print("Kérem a tömb első elemét: ");
        t[0] = be.nextInt();
        t[1] = rnd.nextInt(100-1+1)+1;
        t[2] = t[0]*t[1];
        System.out.println(Arrays.toString(t));
        
        int seged = t[1];
        t[1] = t[0];
        System.out.println(Arrays.toString(t)+" itt van nem veszett el-->"+seged);
        t[0] = seged;
        System.out.println(Arrays.toString(t));
        
        int [] t2 = new int[3];
        t2[0] = 100;
        t2[1] = 15;
        t2[2] = 7;
        System.out.println("Második tömb: "+Arrays.toString(t2));
        if (t2[0] > t2[1] && t2[0] > t2[2])
            System.out.println("Legnagyobb: "+t2[0]);
        else if (t2[1] > t2[0] && t2[1] > t2[2])
            System.out.println("Legnagyobb: "+t2[1]);
        else
            System.out.println("Legnagyobb: "+t2[2]);
        
    }
    
}
