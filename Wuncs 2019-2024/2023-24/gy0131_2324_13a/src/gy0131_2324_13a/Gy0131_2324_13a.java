/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0131_2324_13a;

import java.util.ArrayList;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy0131_2324_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ArrayList<Integer> szamok = feltolt(20);
        System.out.println(szamok);
        masodfok(1,2,1);
    }

    private static ArrayList<Integer> feltolt(int hossz) {
        Random rnd = new Random();
        ArrayList<Integer> lista = new ArrayList<>();
        for (int i = 0; i < hossz; i++) {
            lista.add(rnd.nextInt(100-1+1)+1);
        }
        
        return lista;
    }

    private static void masodfok(double a, double b, double c) {
        if (a == 0)
            System.out.println("Ez nem másodfokú!");
        else{
            double diszkr = b*b-4*a*c;
            if (diszkr>0){
                double x1 = (-b+Math.sqrt(diszkr))/(2*a);
                double x2 = (-b-Math.sqrt(diszkr))/(2*a);
                System.out.println("x1: "+x1+", x2: "+x2);
            }
            else if (diszkr == 0){
                double x = -b/(2*a);
                System.out.println("x: "+x);
            }
            else
                System.out.println("Nincs valós megoldás!");
        }
    }
    
}
