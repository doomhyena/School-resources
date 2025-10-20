/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0924_2526_13a;
import java.util.Scanner;
public class Gy0924_2526_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in);
//        
//        System.out.print("Kérem az 1. számot: ");
//        int a = be.nextInt();
//        System.out.print("Kérem a 2. számot: ");
//        int b = be.nextInt();
//        
//        System.out.println("Milyen mûvelet legyen? (+,-,*,/)");
//        String m = be.next();
//        
//        if (m.equals("+")){
//            System.out.println("a+b="+(a+b));
//        }
//        else if (m.equals("-")){
//            System.out.println("a-b="+(a-b));
//        }
//        else if (m.equals("*")){
//            System.out.println("a*b="+(a*b));
//        }
//        else if (m.equals("/") || m.equals(":")){
//            System.out.println(a+m+b+"="+(a/b));
//        }
//        else{
//            System.out.println("Hibás mûvelet!");
//        }
        
        int x = 10;
        int y = 20;
        
        System.out.println("Összeadjam a két számot? (igen/nem)");
        String v = be.next();
        
        if (v.equalsIgnoreCase("igen")){
            System.out.println(x+"+"+y+"="+(x+y));
        }
        else if (v.equalsIgnoreCase("nem")){
            System.out.println(x+"-"+y+"="+(x-y));
        }
        
    }
    
}
