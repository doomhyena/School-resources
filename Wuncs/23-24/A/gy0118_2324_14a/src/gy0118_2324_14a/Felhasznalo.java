/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0118_2324_14a;

/**
 *
 * @author wuncs.david
 */
public class Felhasznalo {
    String nev,mail,csatl;

    public Felhasznalo(String nev, String mail, String csatl) {
        this.nev = nev;
        this.mail = mail;
        this.csatl = csatl;
    }

    @Override
    public String toString() {
        return nev;
    }
    
    
}
