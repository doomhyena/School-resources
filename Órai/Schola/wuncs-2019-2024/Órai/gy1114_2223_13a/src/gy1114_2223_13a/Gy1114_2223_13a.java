/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1114_2223_13a;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

/**
 *
 * @author wuncs.david
 */
public class Gy1114_2223_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ArrayList <Integer> lista = new ArrayList<>();
        System.out.println("Lista: "+lista);
        lista.add(17); //A lista végére tesz egy elemet.
        System.out.println("Lista: "+lista);
        //Nem lehet egyszerre többet hozzáadni...lista.add(5,4,3);
        for (int i = 0; i < 4; i++) {
            lista.add(i*13);
        }
        System.out.println("Lista: "+lista);
        lista.add(0,2);//Első szám: arra az indexre fogja tenni a számot. Második: Azt a számot teszi.
        System.out.println("Lista: "+lista);
        System.out.println("Lista második eleme: "+lista.get(1));
        System.out.println("Lista mérete: "+lista.size());
        System.out.println("Lista első 3 eleme: "+lista.subList(0, 3)); //Első index beleszámít. MÁSODIK NEM!!!
        lista.remove(0); //Számlista esetén csak indexeket lehet írni.
        System.out.println("Lista: "+lista);
        lista.set(1, 5); //Az egyes indexen lévő számot 5-re állítom.
        System.out.println("Lista: "+lista);
        //int [] t = {10,20,30};
        ArrayList <Integer> l = new ArrayList<>();
        l.add(10);
        l.add(20);
        l.add(30);
        lista.addAll(l); //Egy másik LISTA összes elemét hozzáadja.
        System.out.println("Lista: "+lista);
        lista.add(10);
        System.out.println("Lista: "+lista);
        lista.removeAll(l); //Kiveszi az összes elemet amelyik szerepel az "l" nevű listában.
        System.out.println("Lista: "+lista);
        Collections.sort(lista); //Rendezi növekvő sorrendbe.
        System.out.println("Lista: "+lista);
        Collections.reverse(lista); //CSAK MEGFORDÍTJA a lista aktuális sorrendjét.
        System.out.println("Lista: "+lista);
        
        if (lista.contains(17)) //Lista tartalmazza e a beírt számot.
            System.out.println("A 17-es szám benne van.");
        
        System.out.print("Üres a lista? ");
        if (lista.isEmpty())
            System.out.println("Igen");
        else
            System.out.println("Nem");
        lista.clear(); //Üríti a teljes listát.
        System.out.println("Lista: "+lista);
        
        System.out.print("Üres a lista? ");
        if (lista.isEmpty())
            System.out.println("Igen");
        else
            System.out.println("Nem");
    }
    
}
