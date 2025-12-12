/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1013_2223_14a_kolcsonzes;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.imageio.IIOImage;
import javax.imageio.ImageIO;
import javax.swing.ImageIcon;

/**
 *
 * @author wuncs.david
 */
public class Cica {
    private String nev;
    private int kor;
    private ImageIcon kep;
    private String foglalt;
    private BufferedImage img;

    public Cica(String nev, int kor, String kep, String foglalt) {
        try {
            img = ImageIO.read(new File(kep));
        } catch (IOException ex) {
            System.out.println(ex);
        }
        this.nev = nev;
        this.kor = kor;
        this.kep = new ImageIcon(img);
        this.kep.setDescription(kep);
        this.foglalt = foglalt;
        
    }

    public String getFoglalt() {
        return foglalt;
    }

    public void setFoglalt(String foglalt) {
        this.foglalt = foglalt;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public int getKor() {
        return kor;
    }

    public void setKor(int kor) {
        this.kor = kor;
    }

    public ImageIcon getKep() {
        return kep;
    }

    public void setKep(ImageIcon kep) {
        this.kep = kep;
    }

    @Override
    public String toString() {
        return nev + ": " + kor+" hónap";
    }
    
    
    
    
}
