/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1006_2526_13a;

import java.util.Arrays;
import java.util.Random;



/**
 *
 * @author wuncs.david
 */
public class Gy1006_2526_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       int [] tomb = new int[3]; // new Random()--- new Scanner(System.in)
       //Tömböknek fix a mérete... Feltölti az adott típus default értékével
        System.out.println(tomb);
        System.out.println(Arrays.toString(tomb));
        tomb[0] = 17;
        tomb[1] = 20;
        tomb[2] = 5;
        System.out.println(Arrays.toString(tomb));
        System.out.println("Tömb első eleme: "+tomb[0]);
        System.out.println(tomb[1]);
        System.out.println(tomb[2]);
        System.out.println("A tömb mérete: "+tomb.length);
        System.out.println("A tömb utolsó eleme,mérettől függetlenül: "+tomb[tomb.length-1]);
    /*Feladat: Hozzon létre egy minimum 2, maximum 10 véletlen generált méretű
                inteket tároló tömböt!!
    A tömb első értéke legyen egy 1-10 közötti véletlen generált szám
    A tömb utolsó értéke legyen egy 50 és 100 közötti véletlen generált szám*/
        // (Felső-Alsó+1)+Alsó
        Random rnd = new Random();
        int [] t2 = new int[rnd.nextInt(10-2+1)+2];
        t2[0] = rnd.nextInt(10-1+1)+1;
        t2[t2.length-1] = rnd.nextInt(100-50+1)+50;
        System.out.println("-------------------------");
        //Töltsétek fel a tömb hiányzó helyeit (ahol most 0 van) 100-1000
        for (int i = 1; i < t2.length-1;i++) {
            t2[i] = rnd.nextInt(1000-100+1)+100;
            
        }
        
        System.out.println(Arrays.toString(t2));
        
        
        
        
        
        
    }
    
}
