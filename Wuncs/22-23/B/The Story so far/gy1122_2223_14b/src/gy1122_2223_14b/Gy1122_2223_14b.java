/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1122_2223_14b;

/**
 *
 * @author wuncs.david
 */
public class Gy1122_2223_14b {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Szemely sz1 = new Szemely("Béla", 30);
        Szemely sz2 = new Szemely("Anna",24);
        
        Novel n1 = new Novel(sz1);
        Novel n2 = new Novel(sz2);
        
        n1.start();
        n2.start();
        
    }
    
}
