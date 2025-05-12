/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0206_2223_13a;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;



public class Gy0206_2223_13a {

    
    
    public static void main(String[] args) {
        ArrayList<String> lista =
               new ArrayList<>(Arrays.asList("a","b"));
        lista.add("a");
        System.out.println(lista);
        lista.add(1, "c"); //Az adott indexre tesz elemet.
        System.out.println(lista);
        System.out.println(lista.get(1));
        lista.set(1, "z");
        System.out.println(lista);
        lista.remove("a");
        System.out.println(lista);
        lista.remove(1);
        System.out.println(lista);
        lista.add("a");
        lista.add("a");
        ArrayList<String> ak = new ArrayList<>();
        ak.add("a");
        //Ha az össze a-t ki akarjuk venni.
        lista.removeAll(ak);
        System.out.println(lista);
        System.out.println(
        "Lista mérete: "+lista.size());
        lista.add("a");
        lista.add("b");
        lista.add("c");
        lista.add("d");
        lista.add("e");
        lista.add("f");
        lista.add("g");
        lista.add("h");
        
        for (String n : lista) {
            System.out.println(n);
        }
        
        ArrayList<Integer> szamok = new ArrayList<>();
        Scanner be = new Scanner(System.in);
        Random rnd = new Random();
        System.out.print("Kérek egy számot: ");
        int szam = be.nextInt();
        szamok.add(szam);
        for (int i = 0; i < 10; i++) {
            szamok.add(rnd.nextInt(150-5+1)+5);
        }
        System.out.println(szamok);
        
        if (szamok.contains(17))
            System.out.println("Benne van.");
        
        
    }
    
}
