/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication232;

class Szemely{
    String nev;
    int kor;

    public Szemely(String nev, int kor) {
        this.nev = nev;
        this.kor = kor;
    }

    @Override
    public String toString() {
        return nev + "," + kor;
    }
    
    
}


public class JavaApplication232 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       Szemely sz = new Szemely("Lajos", 25);
        System.out.println(sz.nev+" "+sz.kor);
        System.out.println(sz);
    }
    
}
