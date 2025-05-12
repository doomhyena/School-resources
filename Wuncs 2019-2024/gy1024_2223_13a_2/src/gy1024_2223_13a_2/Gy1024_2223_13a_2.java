/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1024_2223_13a_2;

import java.util.Arrays;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1024_2223_13a_2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int t [] = new int [10];
        Random rnd = new Random();
        //1.
        for (int i = 0; i < t.length; i++) {
            do{
                t[i] = rnd.nextInt(100-1+1)+1;
            }while(t[i]%2!=0);
        }
        System.out.println(Arrays.toString(t));
        //2.
        int ot = 0;
        for (int i = 0; i < t.length; i++) {
            if (t[i]%5==0)
                ot++;
        }
        System.out.println("Öttel "+ot+" db szám osztható.");
        //3.
        System.out.println("50 és 76 közötti hárommal osztható számok:");
        for (int i = 0; i < t.length; i++) {
            if (t[i]%3 == 0 && t[i]>=50 && t[i]<=76)
                System.out.println("\t"+t[i]);
        }
        //4.
        boolean tart = false;
        int index = 0;
        while (index<t.length){
            if (t[index]%7 == 0){
                tart = true;
                break;
            }
            index++;
        }
        if (tart)
            System.out.println("Van benne héttel osztható.");
        else
            System.out.println("Nincs benne héttel osztható.");
    }
    
}
