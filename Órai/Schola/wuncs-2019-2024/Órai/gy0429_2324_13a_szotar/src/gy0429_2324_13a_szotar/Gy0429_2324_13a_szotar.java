/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0429_2324_13a_szotar;

import java.util.HashMap;


public class Gy0429_2324_13a_szotar {

    public static void main(String[] args) {
        HashMap<Integer,String> szotar = new HashMap<>();
        szotar.put(17, "Bármi");
        szotar.put(5, "Bármi2");
        szotar.put(20, "Bármi3");
        szotar.put(17, "Bármi4");
        
        System.out.println(szotar);
        System.out.println("Kulcshoz tartozó érték: "+szotar.get(17));
        
        for (Integer kulcs : szotar.keySet()){
            System.out.printf("Kulcs: %d, Érték: %s\n",kulcs,szotar.get(kulcs));
        }
    }
    
}
