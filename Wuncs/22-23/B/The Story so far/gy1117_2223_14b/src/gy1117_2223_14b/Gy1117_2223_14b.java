/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1117_2223_14b;

import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy1117_2223_14b {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in);
        
        Szamlal_Thread szt = 
                new Szamlal_Thread("T1");
        Szamlal_Thread szt2 = 
                new Szamlal_Thread("T2");
        szt.start();
        szt2.start();
        System.out.print("Kérek egy számot: ");
        int a = be.nextInt();
        
        szt.a = a;
        
        szt.stop();
        System.out.println("Beadott szám: "+a);
        System.out.println("Másik szál száma: "+szt.a);
        
        if (!szt.isAlive())
            szt2.stop();
    }
    
}
