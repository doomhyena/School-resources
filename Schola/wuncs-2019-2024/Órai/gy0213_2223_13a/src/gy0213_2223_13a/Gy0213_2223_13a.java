/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0213_2223_13a;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy0213_2223_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ArrayList<String> szavak =
        new ArrayList<>(
        Arrays.asList("alma","körte","a(z)","finom"));
        
        System.out.println(mondat(szavak));
    }

    private static String mondat(ArrayList<String> sz) {
        String m = "";
        Scanner be = new Scanner(System.in);
        Random rnd = new Random();
        System.out.print("Hossz: ");
        int h = be.nextInt();
        for (int i = 0; i < h; i++) {
            int index = rnd.nextInt((sz.size()));
            m+= " "+sz.get(index);
            sz.remove(index);
        }
        
        return m;
    }
    
}
