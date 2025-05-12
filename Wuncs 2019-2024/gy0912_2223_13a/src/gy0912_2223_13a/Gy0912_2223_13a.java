/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0912_2223_13a;
import java.util.Scanner; //Beimportálja a Scannert
import java.util.*; //Beimportál mindent a util állományból
/**
 *
 * @author Wuncs.David
 */
public class Gy0912_2223_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in).useDelimiter("\n");
        System.out.print("Kérek egy egész számot: ");
        int szam = be.nextInt();
        System.out.println("Felhasználó által megadott egész szám: "+szam);
        System.out.print("Kérek egy tört számot: ");
        double tort_szam = be.nextDouble();
        System.out.println("Felhasználó által megadott tört szám: "+tort_szam);
        System.out.print("Kérek egy szöveget: ");
        String szoveg = be.next();
        System.out.println("Felhasználó által megadott szöveg: "+szoveg);
        
        
        
        double a = 4;
        double b = 5;
        double c = 6;
        
        if (a+b>c && b+c>a && a+c>b){
            double k = a+b+c;
            double s = k/2;
            double t = Math.sqrt(s*(s-a)*(s-b)*(s-c));
            System.out.println("Kerület: "+k+"\nTerület: "+t);
        }
        else{
            System.out.println("Ez a háromszög nem megszerkeszthető.");
        }
    }
    
}
