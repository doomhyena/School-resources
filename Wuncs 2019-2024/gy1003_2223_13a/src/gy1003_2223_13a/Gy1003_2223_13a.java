/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1003_2223_13a;
import java.util.Scanner;
import java.util.Random;
import java.util.Arrays;
/**
 *
 * @author wuncs.david
 */
public class Gy1003_2223_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in);
        Random rnd = new Random();
//        //<editor-fold defaultstate="collapsed" desc="Bevezetés">
        int [] t = new int[3];
//        t[0] = 17;
//        t[1] = rnd.nextInt(100-2+1)+2;
//        System.out.print("Kérem a 3. elemet: ");
//        t[2] = be.nextInt();
//        System.out.println(Arrays.toString(t));
//        for (int i = 0; i < 10; i++) {
//            System.out.println(i);
//        }
//        System.out.println("Második for: ");
//        for (int i = 5; i != 0; i = i*2) {
//            System.out.println(i);
//        }
//
//        System.out.println("Harmadik for: ");
//        for (int i = 0;; i++) {
//            System.out.println(i);
//        } Hiányos for... Ebben az esetben végtelen ciklus
//        System.out.println("Negyedik for: ");
//        for (int i = 0; i < 100;) {
//
//            if (i%2 == 0){
//            System.out.println(i);
//            i++;
//            }
//            else{
//                i*=4;
//            }
//    }
//        System.out.println("II. Feladat: ");
//        for (int i = 5; i <= 13; i+=3) {
//            System.out.println(i);
//        }
//
//        System.out.println("III. Feladat: ");
//        for (int i = rnd.nextInt(100-1+1)+1; i%3 == 0 ; i+=2) {
//            System.out.println(i);
//        }
//</editor-fold>
        
        int [] t2 = new int[15];
        for (int i = 0; i < t2.length; i++) {
            t2[i] = rnd.nextInt(100-1+1)+1;
        }
        
        System.out.println(Arrays.toString(t2));
        
        System.out.print("T2 páros elemei: ");
        for (int i = 0; i < t2.length; i++) {
            if (t2[i]%2 == 0)
                System.out.print(t2[i]+" ");
        }
        
    }
    
}
