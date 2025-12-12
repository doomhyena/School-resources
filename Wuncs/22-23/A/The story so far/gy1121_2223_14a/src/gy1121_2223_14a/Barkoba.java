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
public class Barkoba extends Thread{
    int szam;

    public Barkoba(int szam) {
        this.szam = szam;
    }

    @Override
    public void run() {
        System.out.println("Kérek egy számot 1 és 100 között.");
        Random rnd = new Random();
        int gondolt = rnd.nextInt(100-1+1)+1;
        while (szam == 0){
            
        }
        int db = 1;
        do{
            db++;
            if (gondolt<szam)
                System.out.println("A gondolt szám kisebb.");
            else if (gondolt>szam)
                System.out.println("A gondolt szám nagyobb.");
        }while(szam != gondolt);
        System.out.println("Gratulálok. "+gondolt);
        System.out.println(db+" tipp volt.");
    }
    
    
}
