/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1121_2223_14a;

import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1121_2223_14a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Barkoba b = new Barkoba(0);
        Random rnd = new Random();
        b.start();
        while(b.isAlive()){
            b.szam = rnd.nextInt(100-1+1)+1;
        }
        
    }
    
}
