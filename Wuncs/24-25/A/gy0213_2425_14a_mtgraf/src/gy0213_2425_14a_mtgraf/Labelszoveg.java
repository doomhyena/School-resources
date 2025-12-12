/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0213_2425_14a_mtgraf;

import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JLabel;

/**
 *
 * @author wuncs.david
 */
public class Labelszoveg extends Thread {
    JLabel lbl;

    public Labelszoveg(JLabel lbl) {
        this.lbl = lbl;
    }
    
    Random rnd = new Random();

    @Override
    public void run() {
        while(true){
            
            try {
                lbl.setText("Szám: "+(rnd.nextInt(100-1+1)+1));
                Thread.sleep(1000);
            } catch (InterruptedException ex) {
                System.out.println(ex);
            }
            
        }
    }
    
    
}
