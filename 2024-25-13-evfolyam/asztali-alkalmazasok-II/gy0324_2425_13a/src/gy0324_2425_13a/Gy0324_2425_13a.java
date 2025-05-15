/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0324_2425_13a;

import java.util.ArrayList;
import java.util.Random;

class Szemely{
    String nev;
    int kor;
    /*Konstruktor gener?l?s:
    Jobb klikk -> insert code ->
    -> constructor -> mindent pipa ?s generate*/
    public Szemely(String neve, int kora) {
        this.nev = neve;
        this.kor = kora;
    }

    @Override
    public String toString() {
        return nev + ", " + kor;
    }
}


public class Gy0324_2425_13a {

    static ArrayList<Szemely> szemelyek = new ArrayList<>();
    public static void main(String[] args) {
        Szemely sz1 = new Szemely("Béla", 40);
        
        
        System.out.println(sz1);
        System.out.println(sz1.nev);
        System.out.println(sz1.kor);
        sz1.nev = "Lajos";
        sz1.kor = 30;
        System.out.println(sz1.nev);
        System.out.println(sz1.kor);
        
        feltolt();
        System.out.println(szemelyek);
        for (Szemely n : szemelyek){
            System.out.println(n);
        }
        
        legidosebb();
        
    }

    private static void feltolt() {
        Random rnd = new Random();
        Szemely sz;
        for (int i = 0; i < 113; i++) {
            sz = new Szemely("Név"+i, rnd.nextInt(60-20+1)+20);
            szemelyek.add(sz);
            
        }
    }

    private static void legidosebb() {
        Szemely max = szemelyek.get(0);
        
        for (Szemely n : szemelyek){
            if (n.kor > max.kor)
                max = n;
        }
        
        System.out.println("Legid?sebb: "+max);
        
        
    }
    
}
