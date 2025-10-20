/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0909_2526_13b_elagazasok;
import java.util.Random;
/**
 *
 * @author wuncs.david
 */
public class Gy0909_2526_13b_elagazasok {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
//        int a = 30;
//        
//        if (a > 30) {
//            System.out.println(a+" nagyobb mint 30.");
//        }
//        else if (a == 30){
//            System.out.println(a+" = 30");
//        }
//        else {
//            System.out.println(a+" kisebb 30");
//        }
        
        System.out.println("1. Elágazás vége");
        
        int x = 30;
        int y = 17;
        int z = 40;
        
        if ( x%2 == 0 && x > 20 ){
            System.out.println(x+" páros és 20-nál nagyobb");
        }
        //----------
        if (x>y || x>z) {  //Alt Gr + W = VAGY jel
            System.out.println(x+" legalább az egyik változónál nagyobb");
        } 
        
        Random rnd = new Random(); 
           int szam = rnd.nextInt(80-55+1)+55;
           System.out.println(szam);
           
        //--------------Kör----------------------
           double r = rnd.nextInt(100-1+1)+1;
           
           double k_ker = 2*r*Math.PI;
           double k_ter = Math.pow(r, 2)*Math.PI;
           System.out.println("Sugár: "+r);
           System.out.println("Kerület: "+k_ker);
           System.out.println("Terület: "+k_ter);
           
           
        //------------Háromszög--------------------
           System.out.println("--------------------------");
           double a = rnd.nextInt(100-1+1)+1;
           double b = rnd.nextInt(100-1+1)+1;
           double c = rnd.nextInt(100-1+1)+1;
           System.out.println("a: "+a+"\nb: "+b+"\nc: "+c);
           if (a+b>c && a+c>b && b+c>a){
               
               double ker = a+b+c;
               double s = ker/2;
               double ter = Math.sqrt(s*(s-a)*(s-b)*(s-c));
               System.out.println("Kerület: "+ker);
               System.out.println("Terület: "+ter);
           }
           else{
               System.out.println("Nincs ilyen háromszög");
           }
        
    }
    
}
