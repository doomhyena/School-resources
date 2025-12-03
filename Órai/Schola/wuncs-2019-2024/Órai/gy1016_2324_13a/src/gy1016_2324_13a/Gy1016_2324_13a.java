/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1016_2324_13a;

import java.util.Arrays;

/**
 *
 * @author wuncs.david
 */
public class Gy1016_2324_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String sz1 = "SzoveG1";
        String sz2 = "Szoveg2";
        
        //Stringek összehasonlítása
        if (sz1.equals(sz2)){
            System.out.println("Egyenlő!");
        }
        else{
            System.out.println("Nem egyenlő");
        }
        
        //Nagybetű és kisbetű figyelmen kívül hagyása
        if (sz1.equalsIgnoreCase(sz2))
            System.out.println("Egyenlő. Kis- és nagybetű nem számít");
        else
            System.out.println("Nem egyenlő. Kis- és nagybetű nem számít.");
        
        System.out.println("Szöveg hossza: "+sz1.length()); //Hány karakterből áll
        
        //Tartalmazás
        if (sz1.contains("eG"))
            System.out.println("Benne van.");
        else
            System.out.println("Nincs benne.");
        
        //Nem veszi figyelembe a kis- és nagybetűket.
        if (sz1.toLowerCase().contains("eg"))
            System.out.println("Benne van.");
        else
            System.out.println("Nincs benne.");
        
        //Tömbök
        int [] tomb = {3,4,5,2};
        System.out.println("Tömb első eleme: "+tomb[0]);
        System.out.println("Tömb hossza: "+tomb.length);
        System.out.println("Tömb második eleme: "+tomb[1]);
        System.out.println("Tömb harmadik eleme: "+tomb[2]);
        System.out.println("Tömb negyedik eleme: "+tomb[3]);
        System.out.println("Tömb utolsó eleme: "+tomb[tomb.length-1]);
        System.out.println("Tömb összes eleme: "+Arrays.toString(tomb));
        
        int [] t2 = new int[5];
        System.out.println("Második tömb: "+Arrays.toString(t2));
        t2[0] = 5;
        t2[3] = 17;
        System.out.println("Második tömb: "+Arrays.toString(t2));
        t2[0] = t2[0]+1;
        t2[0] += 1; // -= ; *= ; /= ; %=
        t2[0]++;
        System.out.println("Tömb 2 első eleme: "+t2[0]);
    }
    
}
