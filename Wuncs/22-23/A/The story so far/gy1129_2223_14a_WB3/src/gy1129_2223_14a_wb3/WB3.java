/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1129_2223_14a_wb3;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author wuncs.david
 */
public class WB3 extends Thread {
    Felhasznalo utalo;
    Felhasznalo kedvezmenyezett;
    int osszeg;

    public WB3(Felhasznalo utalo, Felhasznalo kedvezmenyezett, int osszeg) {
        this.utalo = utalo;
        this.kedvezmenyezett = kedvezmenyezett;
        this.osszeg = osszeg;
    }

    @Override
    public void run() {
        while(utalo.foglalt || kedvezmenyezett.foglalt){
            if (utalo.foglalt)
                System.out.println(utalo.nev+" nem indíthat még tranzakciót.");
            if (kedvezmenyezett.foglalt)
                System.out.println(kedvezmenyezett.nev+" nem indíthat még tranzakciót.");
            try {
                Thread.sleep(5000);
            } catch (InterruptedException ex) {}
            
            }
        
        utalo.Levonas(osszeg);
        kedvezmenyezett.Jovairas(osszeg);
        
        }
    }
