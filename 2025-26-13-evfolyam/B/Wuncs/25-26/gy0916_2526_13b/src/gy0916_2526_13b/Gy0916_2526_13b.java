/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0916_2526_13b;
import java.util.Random;


public class Gy0916_2526_13b {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        
        int a = rnd.nextInt(10-0+1)+0;
        int b = rnd.nextInt(15-5+1)+5;
        
        System.out.println(a+", "+b);
        
        if ((a+b)%2 == 1) {
            System.out.println("Összeg: "+(a+b));
        }
        else{
            System.out.println(a+b+1);
        }
        
        System.out.println("----------------------");
        String sz = "Lajos";
        
        System.out.println(sz);
        System.out.println(sz.toLowerCase());
        System.out.println(sz.toUpperCase());
        System.out.println(sz.substring(2));
        System.out.println(sz.substring(1, 4));
        //-----Logikai vizsgálatok--------------
        
        System.out.println("Egyenlő a két String? "+sz.equals("LaJos"));
        System.out.println("Egyenlő a két String? "+sz.equalsIgnoreCase("LaJos"));
        System.out.println("Tartalmazza e? "+sz.contains("La"));
        System.out.println("Tartalmazza e? "+sz.contains("jo"));
        System.out.println("Tartalmazza e? "+"La".contains(sz));
        String sz2 = "LaJosom";
        System.out.println(sz2.toLowerCase().contains(sz.toLowerCase()));
        System.out.println("Kezdés: "+sz.startsWith("L"));
        System.out.println("Kezdés: "+sz.startsWith("La"));
        System.out.println("Vége: "+sz.endsWith("s"));
        System.out.println("Vége: "+sz.endsWith("jos"));
        
    }
    
}
