/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1129_2223_14b_bank;

/**
 *
 * @author wuncs.david
 */
public class Felhasznalo {
    int szamlaszam;
    String nev;
    int egyenleg;
    boolean foglalt = false;

    public Felhasznalo(int szamlaszam, String nev, int egyenleg) {
        this.szamlaszam = szamlaszam;
        this.nev = nev;
        this.egyenleg = egyenleg;
    }
    
    public void Levonas(int osszeg){
        if (osszeg > egyenleg){
            System.out.println(nev+" számláján nincs elegendő összeg a tranzakcióhoz.");
        }
        else{
            foglalt = true;
            egyenleg -= osszeg;
            Utalas(osszeg, true);
        }
    }
    
    public void Jovairas(int osszeg){
        foglalt = true;
        egyenleg += osszeg;
        Utalas(osszeg, false);
    }
    
    private void Utalas(int osszeg, boolean levon){
        if (levon)
            System.out.println("Név: "+nev
                    +"\nLevonás: "+osszeg
                    +"\nÚj egyenleg: "+egyenleg);
        else
            System.out.println("Név: "+nev
                    +"\nJóváírás: "+osszeg
                    +"\nÚj egyenleg: "+egyenleg);
        foglalt = false;
    }
    
}
