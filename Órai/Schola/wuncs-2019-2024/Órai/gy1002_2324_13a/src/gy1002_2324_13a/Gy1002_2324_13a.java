/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1002_2324_13a;
import java.util.Scanner;
/**
 *
 * @author wuncs.david
 */
public class Gy1002_2324_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in);
        //1. Feladat: Kör
        System.out.print("Kérem a sugarat: ");
        double r = be.nextDouble();
        
        if (r != 0){
            double k_ker = 2*r*Math.PI;
            double k_ter = Math.PI*Math.pow(r, 2); //r*r*Math.PI;
            System.out.println("Kerület: "+k_ker+"\nTerület: "+k_ter);
        }
        else{
            System.out.println("Hibás adat!");
        }
        
        //2. Feladat: Háromszög
        System.out.print("Kérem 'a' értékét: ");
        double h_a = be.nextDouble();
        System.out.print("Kérem 'b' értékét: ");
        double h_b = be.nextDouble();
        System.out.print("Kérem 'c' értékét: ");
        double h_c = be.nextDouble();
        
        if (h_a + h_b >= h_c && h_a + h_c >= h_b && h_b + h_c >= h_a){
            double h_ker = h_a+h_b+h_c;
            double s = h_ker/2;
            double h_ter = Math.sqrt(s*(s-h_a)*(s-h_b)*(s-h_c));
            System.out.println("Terület: "+h_ter+"\nKerület: "+h_ker);
        }
        else{
            System.out.println("Ezt a háromszöget nem lehet megszerkeszteni!");
        }
        
        //3. Feladat: Négyszög
        System.out.print("Kérem 'a' értékét: ");
        double n_a = be.nextDouble();
        System.out.print("Kérem 'b' értékét: ");
        double n_b = be.nextDouble();
        
        if (n_a == 0 || n_b == 0){
            System.out.println("Hibás adatok!");
        }
        else{
            if (n_a == n_b){
                System.out.println("Ez egy négyzet!");
                double n_ker = 4*n_a;
                double n_ter = Math.pow(n_a, 2);
                System.out.println("Kerület: "+n_ker+"\nTerület: "+n_ter);
            }
            else{
                System.out.println("Ez egy téglalap!");
                double n_ker = 2*(n_a+n_b);
                double n_ter = n_a*n_b;
                System.out.println("Kerület: "+n_ker+"\nTerület: "+n_ter);
            }
        }
        
        
        //4. Feladat: Másodfokú
        System.out.print("Kérem 'a' értékét: ");
        double a = be.nextDouble();
        if (a != 0){
            System.out.print("Kérem 'b' értékét: ");
            double b = be.nextDouble();
            System.out.print("Kérem 'c' értékét: ");
            double c = be.nextDouble();
            
            double diszkr = b*b-4*a*c;
            if (diszkr > 0){
                double x1 = (-b+Math.sqrt(diszkr))/(2*a);
                double x2 = (-b-Math.sqrt(diszkr))/(2*a);
                System.out.println("x1: "+x1+"\nx2: "+x2);
            }
            else if (diszkr == 0){
                double x = -b/(2*a);
                System.out.println("x: "+x);
            }
            else{
                System.out.println("Nincs valós megoldás.");
            }
        }
    }
    
}
