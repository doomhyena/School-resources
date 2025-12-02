/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package javaapplication11;

/**
 *
 * @author wuncs.david
 */
public class JavaApplication11 {

    static int b = 7;
    public static void main(String[] args) {
        int a = 17;
        
        met1();
        System.out.println(a);
        
        met2(25);
        met2(10);
        met2(0);
        
        met2_b(a);
        System.out.println(a);
        int eredmeny = met3();
        System.out.println(eredmeny);
        System.out.println(met3());
        
        
        int er2 = metodus4(eredmeny);
        System.out.println(er2);
      
    }

    private static void met1() {
        int a = 5;
        System.out.println(a);
        System.out.println(b);
    }

    private static void met2(int szam) {
        System.out.println("Beadott paraméter: "+szam);
        if(szam%2 == 0)
            System.out.println("Páros szám");
        else
            System.out.println("Páratlan szám");
    }

    private static void met2_b(int szam) {
        szam *= 2;
        System.out.println(szam);
    }

    private static int met3() {
        int a = 25;
        return a;
    }

    private static int metodus4(int szam) {
        szam *= 2;
        return szam;
    }
    
}
