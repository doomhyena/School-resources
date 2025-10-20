/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0917_2526_13a_doga;
import java.util.Scanner;
/**
 *
 * @author wuncs.david
 */
public class Gy0917_2526_13a_doga {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in);
        //Kör
        System.out.print("Kérem a sugarat: ");
        double r = be.nextDouble();
        if ( r>0 ){
            double k_ker = 2*r*Math.PI;
            double k_ter = r*r*Math.PI;
            System.out.println("Kerület: "+k_ker);
            System.out.println("Terület: "+k_ter);
        }
        else{
            System.out.println("Hibás adat!");
        }
        //Háromszög
        System.out.print("Kérem az 1. oldalt: ");
        double h_a = be.nextDouble();
        System.out.print("Kérem a 2. oldalt: ");
        double h_b = be.nextDouble();
        System.out.print("Kérem a 3. oldalt: ");
        double h_c = be.nextDouble();
        
        if (h_a+h_b>h_c && h_a+h_c>h_b && h_c+h_b>h_a){
            double h_ker = h_a+h_b+h_c;
            double s = h_ker/2;
            double h_ter = Math.sqrt(s*(s-h_a)*(s-h_b)*(s-h_c));
            System.out.println("Kerület: "+h_ker);
            System.out.println("Terület: "+h_ter);
        }
        else{
            System.out.println("Ez nem háromszög!");
        }
        
        //Négyszög
        /*
        Bekérni a felhasználótól 2 valós számot.
        Ha a két szám egyenlõ, kiírni, hogy ez NÉGYZET és a kerületet,területet
        k = 4*a t = a*a
        Ha a két szám NEM egyenlõ, kiírni, hogy ez téglalap és a kerületet,területet.
        k = 2*(a+b) t = a*b
        
        */
        System.out.print("Kérem az 1. oldalt: ");
        double n_a = be.nextDouble();
        System.out.print("Kérem a 2. oldalt: ");
        double n_b = be.nextDouble();
        
        
        if (n_a == n_b){
            System.out.println("Ez egy négyzet: ");
            double n_ker = 4*n_a;
            double n_ter = n_a*n_a;
            System.out.println("Kerület: "+n_ker);
            System.out.println("Terület: "+n_ter);
        }
        else{
            System.out.println("Ez egy téglalap: ");
            double n_ker = 2*(n_a+n_b);
            double n_ter = n_a*n_b;
            System.out.println("Kerület: "+n_ker);
            System.out.println("Terület: "+n_ter);
        }
        
        //Másodfokú
        /*
        Három érték bekérése (a,b,c)
        Meg kell vizsgálni, hogy a egyenlõ e nullával (ha igen, akkor nem másodfokú)
        Utána létre kell hozni a diszkriminánst (b*b-4*a*c)
        Diszkr > 0 --> 2 megoldás
        Diszkr = 0 --> 1 megoldás
        Diszkr < 0 --> Nincs megoldás
        */
        
        System.out.print("a: ");
        double a = be.nextDouble();
        
        if (a==0){
            System.out.println("Ez nem másodfokú egyenlet!");
        }
        else{
        System.out.print("b: ");
        double b = be.nextDouble();
        System.out.print("c: ");
        double c = be.nextDouble();
        double diszkr = b*b-4*a*c;
        if (diszkr > 0){
            double x1 = (-b+Math.sqrt(diszkr))/(2*a);
            double x2 = (-b-Math.sqrt(diszkr))/(2*a);
            System.out.println("x1: "+x1);
            System.out.println("x2: "+x2);
        }
        else if (diszkr == 0){
            double x = (-b)/(2*a);
            System.out.println("x: "+x);
        }
        else{
            System.out.println("Nincs valós megoldás!");
        }
        
        }
     
        
        
    }

   
    
}
