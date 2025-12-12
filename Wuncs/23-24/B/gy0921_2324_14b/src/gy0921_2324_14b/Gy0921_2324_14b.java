/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0921_2324_14b;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;


public class Gy0921_2324_14b {

    static HashMap<Integer,String> kutyanevek =
            new HashMap<>();
    
    static HashMap<Integer,Fajta> kutyafajtak =
            new HashMap<>();
    
    static ArrayList<Kutya> kutyak = new ArrayList<>();
    
    
    public static void main(String[] args) {
        k_nevek();
    }

    private static void k_nevek() {
        File f = new File("KutyaNevek.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
               sor = be.nextLine();
               adatok = sor.split(";");
               kutyanevek.put(Integer.parseInt(adatok[0]), adatok[1]);
            }
            
            
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }
    
}
