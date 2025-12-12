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
public class Gy1129_2223_14b_Bank {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Felhasznalo f1 = new Felhasznalo(110011, "Lajos", 150000);
        
        f1.Jovairas(2000);
        System.out.println("---------");
        f1.Levonas(155);
    }
    
}
