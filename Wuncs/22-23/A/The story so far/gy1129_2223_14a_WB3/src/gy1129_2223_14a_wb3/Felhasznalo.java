/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1129_2223_14a_wb3;

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
    
    public void Jovairas (int osszeg){
        foglalt = true;
        egyenleg+=osszeg;
        Befejez();
    }
    public void Levonas (int osszeg){
        foglalt = true;
        if (osszeg<=egyenleg){
            egyenleg-=osszeg;            
        }
        else{
            System.out.println(szamlaszam+" számlán nincs elegendõ egyenleg.");
        }
        Befejez();
    }
    
    private void Befejez(){
        System.out.println(nev+": "+egyenleg+"ft");
        foglalt = false;
    }

    @Override
    public String toString() {
        return nev + ", Egyenleg: " + egyenleg + "ft";
    }
    
    
    
}
