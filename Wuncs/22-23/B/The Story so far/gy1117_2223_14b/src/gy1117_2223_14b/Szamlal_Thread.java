/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1117_2223_14b;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author wuncs.david
 */
public class Szamlal_Thread extends Thread{
    int a = 1;
    String nev;

    public Szamlal_Thread(String nev) {
        this.nev = nev;
    }
    
    

    @Override
    public void run() {
        while(true){
        System.out.println(nev+": "+a);
        a++;
        try {
            Thread.sleep(2000);
        } catch (InterruptedException ex) {
            
        }
        }
    }
    
    
}
