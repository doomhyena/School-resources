/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0904_2526_13a_valtozok;

/**
 *
 * @author wuncs.david
 */
public class Gy0904_2526_13a_valtozok {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        String a; //Deklarálás - Típus meghatározás
        // Nem lehet ismétlődés elnevezésben
        a = "Lajos"; //Inicializálás - Értékadás
        System.out.println(a); //Változó használata
        int b;
        b = 5;
        double pi;
        pi = Math.PI;
        System.out.println(pi);
        double c = b*pi;
        System.out.println(c);
        a = "Béla";
        System.out.println(a);
        
        double A = 1;
        double B = 2;
        double C = 1;
        
        System.out.println("x1: "+(-B+Math.sqrt(Math.pow(B, 2)-4*A*C))/(2*A));
        System.out.println("x2: "+(-B-Math.sqrt(Math.pow(B, 2)-4*A*C))/(2*A));
        
        
        
        
        
    }
    
}
