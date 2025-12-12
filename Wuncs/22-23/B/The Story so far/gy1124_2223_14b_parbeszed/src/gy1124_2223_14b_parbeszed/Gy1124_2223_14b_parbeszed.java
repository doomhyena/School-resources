/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1124_2223_14b_parbeszed;

/**
 *
 * @author wuncs.david
 */
public class Gy1124_2223_14b_parbeszed {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Szemely sz1 = new Szemely("Lajos");
        Szemely sz2 = new Szemely("Anna");
        Szemely sz3 = new Szemely("Béla");
        Szemely sz4 = new Szemely("Fruzsina");
        
        Parbeszed_Thread p1 = new Parbeszed_Thread(sz1, sz2);
        Parbeszed_Thread p2 = new Parbeszed_Thread(sz3, sz4);
        Parbeszed_Thread p3 = new Parbeszed_Thread(sz3, sz1);
        Parbeszed_Thread p4 = new Parbeszed_Thread(sz4, sz1);
        Parbeszed_Thread p5 = new Parbeszed_Thread(sz2, sz3);
        Parbeszed_Thread p6 = new Parbeszed_Thread(sz1, sz2);
        
        p1.start();
        p2.start();
        p3.start();
        p4.start();
        p5.start();
        p6.start();
    }
    
}
