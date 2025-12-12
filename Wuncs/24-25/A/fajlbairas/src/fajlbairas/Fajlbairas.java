/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fajlbairas;

import java.io.FileWriter;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author wuncs.david
 */
public class Fajlbairas {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try {
            FileWriter fw = new FileWriter("teszt.csv",true);
            fw.write("blá;blá;blá\n");
            fw.close();
        } catch (IOException ex) {
            System.out.println("Hiba: "+ex);
        }
    }
    
}
