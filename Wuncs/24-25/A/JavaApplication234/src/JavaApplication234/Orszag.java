/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package JavaApplication234;

/**
 *
 * @author wuncs.david
 */
public class Orszag {
    String nev,kont;
    int nepe;

    public Orszag(String nev, int nepe, String k) {
        this.nev = nev;
        this.nepe = nepe;
        this.kont = k;
    }

    @Override
    public String toString() {
        return nev + ", " + kont + ", " + nepe;
    }
    
    
    
    
}
