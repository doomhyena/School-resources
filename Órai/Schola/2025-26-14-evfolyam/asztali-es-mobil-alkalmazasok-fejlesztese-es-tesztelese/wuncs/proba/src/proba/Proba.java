/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package proba;

/**
 *
 * @author wuncs.david
 */
public class Proba {

    /**
     * @param args the command line arguments
     */
    static int b = 1;
    public static void main(String[] args) {
        int a = 17;
        
        met1();
        System.out.println(a);
        System.out.println(b);
        met2(a);
        int eredmeny = met3();
        System.out.println(eredmeny);
        System.out.println(met3()+10);
        
        
    }

    private static void met1() {
        int a = 20;
        System.out.println(a);
        System.out.println(b);
        b= 5;
    }

    private static void met2(int szam) {
        szam *= 2;
        System.out.println(szam);
    }

    private static int met3() {
        int a = 75;
        a /= 15;
        return a;
    }
    
}
