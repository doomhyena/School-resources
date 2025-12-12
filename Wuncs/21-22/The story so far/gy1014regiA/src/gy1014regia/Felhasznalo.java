/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1014regia;

/**
 *
 * @author tanuló
 */
public class Felhasznalo {
    private String nev;
    private String jelszo;

    public Felhasznalo(String nev, String jelszo) {
        this.nev = nev;
        this.jelszo = jelszo;
    }

    public String getJelszo() {
        return jelszo;
    }

    public void setJelszo(String jelszo) {
        this.jelszo = jelszo;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }
    
    
}
