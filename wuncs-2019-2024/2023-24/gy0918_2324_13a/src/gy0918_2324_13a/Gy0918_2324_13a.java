/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0918_2324_13a;
//Mindig ide tesszük az importokat
import java.util.Random;
import java.util.Scanner;
import java.util.*; //Ezzel beimportál mindent ami a util állományban van.

public class Gy0918_2324_13a {


    
    public static void main(String[] args) {
        Random rnd = new Random(); //Ez a változó segít a létrehozásban
        Scanner be = new Scanner(System.in).useDelimiter("\n");
        
//        int a = rnd.nextInt(100-1+1)+1; //Ez hozza létre a számot.
//        System.out.println(a);
//        
//        //Integer beadása outputról
//        System.out.print("Kérek egy egész számot: ");
//        int b = be.nextInt();
//        System.out.println(b);
//        
//        //Double érték bekérése
//        System.out.print("Kérek egy nem egész számot: ");
//        double c = be.nextDouble();
//        System.out.println(c);
//        
//        //String érték bekérése
//        System.out.print("Kérek egy szót: ");
//        String d = be.next();
//        System.out.println(d);
//        
//        /*String mondatok bekérése.
//          Scannerbe létrehozzuk a .useDelimiter("\n") kiegészítőt.*/
//        System.out.print("Kérek egy mondatot: ");
//        String e = be.next();
//        System.out.println(e);
        
//        System.out.print("Kérem a sugarat: ");
//        double r = Math.abs(be.nextDouble());
//        
//        double ker = 2*r*Math.PI;
//        double ter = Math.pow(r, 2)*Math.PI;
//        System.out.println("Kerület: "+ker+"\nTerület: "+ter);
        
        
        int sz1 = rnd.nextInt(100-1+1)+1;
        int sz2 = rnd.nextInt(100-1+1)+1;
        int sz3 = rnd.nextInt(100-1+1)+1;
        
        System.out.println(sz1+";"+sz2);
        if (sz1>sz2){
            System.out.println("sz1 nagyobb mint sz2.");
        }
        else if (sz1 == sz2){
            System.out.println("sz1 és sz2 egyenlő.");
        }
        else{
            System.out.println("sz1 kisebb mint sz2.");
        }
    }
    
}
