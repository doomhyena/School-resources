/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1117_2223_14a;

import java.util.ArrayList;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy1117_2223_14a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws InterruptedException {
        Scanner be = new Scanner(System.in);
        
        Szamlal_Thread szt = new Szamlal_Thread();
        szt.start();
        
        System.out.print("Kérek egy számot: ");
        int a = be.nextInt();
        
        szt.a = a;
        
        Thread.sleep(3000);
//        Szamlal_Thread szt2 = new Szamlal_Thread();
//        szt2.start();
        if (szt.isAlive())
            szt.stop();
        System.out.println("Beadott szám: "+a);
        System.out.println("Másik szál száma: "+szt.a);
        ArrayList <Szamlal_Thread> threadek =
                new ArrayList<>();
    }
    
}
