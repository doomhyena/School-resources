/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1117_2223_14a;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author wuncs.david
 */
public class Szamlal_Thread extends Thread {
    int a = 1;

    @Override
    public void run() {
        while(true){
            System.out.println(a);
            a++;
            try {
                Thread.sleep(2000);
            } catch (InterruptedException ex) {
                System.out.println("Hiba: "+ex);
            }
        }
    }
    
}
