/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1014_2526_13b;

import java.util.Arrays;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1014_2526_13b {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int a = 17;
        int b = 5;
        System.out.println(a+", "+b);
        int csere = a;
        
        a = b;
        b = csere;
        
        System.out.println(a+", "+b);
        //-------Rendezés
        int t[] = new int[10];
        Random rnd = new Random();
        
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(100-1+1)+1;
        }
        
        System.out.println(Arrays.toString(t));
        int cs;
        for (int i = 0; i < t.length; i++) {
            for (int j = i+1; j < t.length; j++) {
                if (t[i]>t[j]){
                    cs = t[i];
                    t[i] = t[j];
                    t[j] = cs;
                }
            }
        }
        System.out.println(Arrays.toString(t));
        
        /*Hozzon létre egy inteket tároló tömböt.
        A tömb méretét a felhasználó adhassa meg!
        Töltse fel a tömböt 1 és 100 közötti számokkal!
        Írja ki a tömböt az outputra.
        Határozza meg a tömb PÁRATLAN INDEXEIN szereplõ értékek összegét
        Határozza meg a tömb legnagyobb páros számát.
        Határozza meg, hogy hány 50-nél nagyobb 3-mal osztható szám van a tömbben.
        Rendezze a tömböt csökkenõ sorrendbe%
        */
        
        
    }
    
}
