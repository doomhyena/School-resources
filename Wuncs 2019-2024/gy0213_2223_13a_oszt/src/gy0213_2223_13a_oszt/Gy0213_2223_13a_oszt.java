/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0213_2223_13a_oszt;
class Szemely{
    String nev;
    int kor;

    public Szemely(String nev, int kor) {
        this.nev = nev;
        this.kor = kor;
    }

    public Szemely() {
    }
    
    
    
}


public class Gy0213_2223_13a_oszt {

    
    public static void main(String[] args) {
        Szemely sz = new Szemely();
        System.out.println(sz.nev);
        System.out.println(sz.kor);
        sz.nev = "Lajos";
        sz.kor = 30;
        System.out.println(sz.nev);
        Szemely sz2 = new Szemely("Anna", 30);
        System.out.println(sz2.nev);
        System.out.println(sz2.kor);
    }
    
}
