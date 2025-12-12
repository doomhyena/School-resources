/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mt;

import java.awt.Color;
import java.util.Random;
import javax.swing.JFrame;

/**
 *
 * @author wuncs.david
 */
public class Csere extends Thread{
    JFrame frm;

    public Csere(JFrame frm) {
        this.frm = frm;
    }

    @Override
    public void run() {
        Random rnd = new Random();
        while(true){
        frm.getContentPane().setBackground(
        new Color(rnd.nextInt(255-0+1)+0,
                  rnd.nextInt(255-0+1)+0,
                  rnd.nextInt(255-0+1)+0));
            
            try {
                Thread.sleep(2000);
            } catch (InterruptedException ex) {}
        }
    }
    
    
}
