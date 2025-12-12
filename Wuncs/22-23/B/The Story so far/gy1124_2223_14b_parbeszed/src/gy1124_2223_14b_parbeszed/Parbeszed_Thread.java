/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1124_2223_14b_parbeszed;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author wuncs.david
 */
public class Parbeszed_Thread extends Thread {
    Szemely partner1;
    Szemely partner2;

    public Parbeszed_Thread(Szemely partner1, Szemely partner2) {
        this.partner1 = partner1;
        this.partner2 = partner2;
    }

    @Override
    public void run() {
        
        while(partner1.foglalt || partner2.foglalt){
            if (partner1.foglalt)
                System.out.println(partner1+" beszélget.");
            else
                System.out.println(partner2+" beszélget.");
            try {
                Thread.sleep(5000);
            } catch (InterruptedException ex) {}
        }
        
        partner1.foglalt = true;
        partner2.foglalt = true;
        System.out.println(partner1+" és "+partner2+" beszélgetnek.");
        try {
                Thread.sleep(4000);
            } catch (InterruptedException ex) {}
        partner1.foglalt = false;
        partner2.foglalt = false;
        System.out.println(partner1+" és "+partner2+" végeztek.");
        
    }
    
    
}
