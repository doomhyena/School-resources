/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0919_2223_13a_doga;
import java.util.Scanner;
/**
 *
 * @author wuncs.david
 */
public class Gy0919_2223_13a_doga {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in);
        
        // Háromszög
        System.out.println("Kérem a három oldalt: ");
        System.out.print("a:");
        double ha = be.nextDouble();
        System.out.print("b: ");
        double hb = be.nextDouble();
        System.out.print("c: ");
        double hc = be.nextDouble();
        
        if (ha+hb>hc && ha+hc>hb && hb+hc>ha) {
            double ker = ha+hb+hc;
            double s = ker/2;
            double ter = Math.sqrt(s*(s-ha)*(s-hb)*(s-hc));
            System.out.println("Kerület: "+ker);
            System.out.println("Terület: "+ter);
        }
        else{
            System.out.println("Ez a háromszög nem megszerkeszthető");
        }
    }
    
}
