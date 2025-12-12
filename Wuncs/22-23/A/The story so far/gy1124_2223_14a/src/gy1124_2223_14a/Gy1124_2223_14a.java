/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1124_2223_14a;

/**
 *
 * @author wuncs.david
 */
public class Gy1124_2223_14a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Szemely sz1 = new Szemely("Béla", 25);
        Szemely sz2 = new Szemely("Anna", 30);
        
        Novel_Thread n1 = new Novel_Thread(sz1);
        Novel_Thread n2 = new Novel_Thread(sz2);
        
        n1.start();
        n2.start();
    }
    
}
