/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1116_2324_14b;

import java.awt.Color;
import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JButton;

/**
 *
 * @author wuncs.david
 */
public class Csere extends Thread{
    JButton btn;
    

    public Csere(JButton btn) {
        this.btn = btn;
    }

    @Override
    public void run() {
        while (true){
            btn.setBackground(new Color(
            new Random().nextInt(255-0+1)+0,
            new Random().nextInt(255-0+1)+0,
            new Random().nextInt(255-0+1)+0));
            
            try {
                Thread.sleep(5000);
            } catch (InterruptedException ex) {
            }
            
        }
    }
    
    
    
}
