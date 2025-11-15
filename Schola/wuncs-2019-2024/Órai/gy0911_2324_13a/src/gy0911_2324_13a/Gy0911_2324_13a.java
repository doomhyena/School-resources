/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0911_2324_13a;

/**
 *
 * @author wuncs.david
 */
public class Gy0911_2324_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int a; //Deklarálás
        a = 1; //Inicializálás
        int b = 9;
        System.out.println("a értéke: "+a);
        System.out.println("b értéke: "+b);
        System.out.println("a-b="+(a-b));
        int c = 8;
        System.out.println("c értéke: "+c);
        String szoveg = "Hello";
        System.out.println(szoveg);
        System.out.println("Változó hossza: "+szoveg.length()+" karakter.");
        double d = 5.8;
        System.out.println("d értéke: "+d);
        double e = Math.PI;
        System.out.println(e);
        //Másodfokú
        double diszkr = Math.pow(b, 2)-4*a*c;
        System.out.println("x1: "+(-b+Math.sqrt(diszkr))/(2*a));
        System.out.println("x2: "+(-b-Math.sqrt(diszkr))/(2*a));
    }
    
}
