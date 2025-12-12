/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1116_2324_14a;

import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JLabel;

/**
 *
 * @author wuncs.david
 */
public class Utazo_Thread extends Thread {
    private Ember e;
    private JLabel lbl;

    public Utazo_Thread(Ember e, JLabel lbl) {
        this.e = e;
        this.lbl = lbl;
    }
    
    public JLabel getLbl() {
        return lbl;
    }

    public void setLbl(JLabel lbl) {
        this.lbl = lbl;
    }

    public Ember getE() {
        return e;
    }

    public void setE(Ember e) {
        this.e = e;
    }

    @Override
    public void run() {
        while(true){
            try {
                Thread.sleep(new Random().nextInt(10000-1000+1)+1000);
                e.utazas(new Random().nextInt(10-0+1)+0);
                if (e.getEmelet() != 0){
                System.out.println(e+"");
                lbl.setText(e+"");
                }
                else{
                    lbl.setText(e+"...Off");
                    break;
                }
            } catch (InterruptedException ex) {
                System.out.println(ex);
            }
            
        }
    }
    
    
    
}
