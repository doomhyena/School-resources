/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0925_2324_13a;
import java.util.Scanner;
import java.util.Random;
/**
 *
 * @author wuncs.david
 */
public class Gy0925_2324_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in);
        Random rnd = new Random();
        //sout + TAB
//        System.out.print("Kérek egy egész számot: ");
//        int a = be.nextInt();
//        int b = rnd.nextInt(75-25+1)+25;
//        System.out.println("Második szám: "+b);
//        
//        if (a>b){
//            b = (int) Math.pow(b, 3); //típuskényszerítés
//        }
//        else if (a<b){
//            a = (int) Math.sqrt(a);
//        }
//        else{
//            int c = a+b;
//            System.out.println("c: "+c);
//        }
//        System.out.println("a: "+a+", b: "+b);
        
        int sz1 = 2;
        int sz2 = 5;
        
        if (sz1>sz2 && sz1%2 == 0){
            System.out.println("sz1 páros és nagy.");
        }
        
        
        if (sz1>sz2 || sz1%2 == 0){
            System.out.println("sz1 páros vagy nagy.");
        }
        
        System.out.print("Kérek egy valós számot: ");
        double szam = be.nextDouble();
        
        if (szam%2 == 0 && szam != 0){
            System.out.println("Kérek még két számot:");
            double szam2 = be.nextDouble();
            double szam3 = be.nextDouble();  
        }
        else{
            System.out.println("A szám 0 vagy páratlan.");
        }
    }
    
}
