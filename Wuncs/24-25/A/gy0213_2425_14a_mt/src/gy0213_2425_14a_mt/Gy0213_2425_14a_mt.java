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
public class Gy0213_2425_14a_mt {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws InterruptedException {
        Szal sz = new Szal();
        
        sz.start();
        
//        for (int i = 0; i < 10; i++) {
//            System.out.println("szia2");
//            Thread.sleep(1000);
//        }
        
        System.out.println("Gondoltam egy számra 1 és 100 között. Találd ki.");
        Random rnd = new Random();
        int szam = rnd.nextInt(100-1+1)+1;
        int tippek = 0;
        int tipp;  
        do{
            tippek++;
            tipp = sz.a;
            if (tipp < szam){
                System.out.println("A gondolt szám nagyobb mint "+tipp);
            }
            else if (tipp > szam){
                System.out.println("A gondolt szám kisebb mint "+tipp);
            }
            
        }while (tipp != szam);
        sz.siker = true;
        System.out.println("Kitaláltad. "+szam+" Tippek száma: "+tippek);
        System.out.println("Szálunkon "+sz.szt+" tippelés volt");
        
        
    }
    
}
