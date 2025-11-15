/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0910_2526_13a;
import java.util.*;
/**
 *
 * @author wuncs.david
 */
public class Gy0910_2526_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        int szam = rnd.nextInt(20-10+1)+10;
//        System.out.println(szam);
        
        /*
        Feladat: Készítsen két véletlen generált egész számot (10 és 100 között)
        és tárolja el egy-egy változóban (pl.: a és b)
        Vizsgálja meg, hogy a két szám összege nagyobb e mint 100.
            Ha igen: Írja ki az összeget az outputra
            Ha nem: Írja ki a két számot az outputra.
        
        2. Feladat: Készítsen egy harmadik véletlen generált egész számot
        ugyanazokkal a kritériumokkal mint az előző feladatban.
        Tárolja el ezt is egy változóban.
        Határozza meg melyik a legnagyobb szám
        */
        int a = 25;
        int b = 25;
        
        if (a+b > 100) {
            System.out.println("Összeg: "+(a+b));
        }
        else{
            System.out.println("a: "+a+", b: "+b);
        }
        
        int c = 10;
        
        System.out.println("a: "+a+", b: "+b+", c: "+c);
        if (a >= b && a >= c){
            System.out.println("Legnagyobb: "+a);
        }
        else if (b >= a && b >= c){
            System.out.println("Legnagyobb: "+b);
        }
        else{
            System.out.println("Legnagyobb: "+c);
        }
        
        
    }
    
}
