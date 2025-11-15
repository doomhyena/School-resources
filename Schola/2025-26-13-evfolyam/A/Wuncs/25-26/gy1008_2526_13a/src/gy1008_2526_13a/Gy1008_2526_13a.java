/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1008_2526_13a;

import java.util.Arrays;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1008_2526_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        int t[] = new int[5];
        
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
        //--------------Programozási tételek--------------------
        //I. Összegzés tétele: Összegzi a tömb elemeinek értékét!
        // [5,10,7]  0-->5, ossz = 0+5=5 --->10, ossz = 5+10=15-->7, ossz=15+7=22
        int ossz = 0;
        for (int i = 0; i < t.length; i++) {
            ossz = ossz+t[i];
        }
        
        System.out.println("Összeg: "+ossz);
        //II. Maximum/minimum kiválasztás tétele: Kiválasztja a tömb legkisebb/legnagyobb értékét
        int max = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i] > max)
                max = t[i];
            
        }
        System.out.println("Max: "+max);
        int min = t[0];
        for (int i = 0; i < t.length; i++) {
            if (t[i] < min)
                min = t[i];
        }
        System.out.println("Min: "+min);
    }
    
}
