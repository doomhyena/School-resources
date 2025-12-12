/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0213_2425_14a_mt;

import java.util.Random;



/**
 *
 * @author wuncs.david
 */
public class Szal extends Thread {

    int a;
    Random rnd = new Random();
    boolean siker = false;
    int szt = 0;
    @Override
    public void run() {
//        for (int i = 0; i < 10; i++) {
//            System.out.println("Szia1");
//            try {
//                Thread.sleep(1000);
//            } catch (InterruptedException ex) {
//                System.out.println(ex);
//            }
//        }
        
        while (!siker){
            a = rnd.nextInt(100-1+1);
            szt++;
        }
        
    }
    
    
    
}
