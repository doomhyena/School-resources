/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1003_2223_13a_progtet;

import java.util.Arrays;
import java.util.Random;

/**
 *
 * @author wuncs.david
 */
public class Gy1003_2223_13a_progtet {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        
        int [] tomb = new int[5];
        for (int i = 0; i < tomb.length; i++) {
            tomb[i] = rnd.nextInt(100-1+1)+1;
        }
        System.out.println(Arrays.toString(tomb));
        //PROGRAMOZÁSI TÉTELEK
        
        //ÖSSZEGZÉS TÉTELE: ÖSSZEADJA A TÖMB ELEMEINEK ÉRTÉKÉT
        int osszeg = 0;
        for (int i = 0; i < tomb.length; i++) {
            osszeg = osszeg + tomb[i];
            
        }
        System.out.println("A tömb elemeinek összege: "+osszeg);
        
        //MAXIMUM KIVÁLASZTÁS TÉTELE: MEGHATÁROZZA A TÖMB LEGNAGYOBB ÉRTÉKÉT
        int max = tomb[0];
        for (int i = 0; i < tomb.length; i++) {
            if (tomb[i]>max)
                max = tomb[i];
        }
        System.out.println("A tömb legnagyobb értéke: "+max);
        //MINIMUM KIVÁLASZTÁS TÉTELE: MEGHATÁROZZA A TÖMB LEGKISEBB ÉRTÉKÉT
        int min = tomb[0];
        for (int i = 0; i < tomb.length; i++) {
            if (min > tomb[i])
                min = tomb[i];
        }
        System.out.println("A tömb legkisebb értéke: "+min);
        
        //MEGSZÁMLÁLÁS TÉTELE: MEGSZÁMOLJA, HOGY A FELTÉTEL HÁNYSZOR TELJESÜLT
        //KRITÉRIUM: HÁNY PÁROS SZÁM VAN A TÖMBBEN.
        int db = 0;
        for (int i = 0; i < tomb.length; i++) {
            if (tomb[i]%2==0)
                db++;
        }
        System.out.println("A tömb "+db+" db páros számot tartalmaz.");
        
        //KIVÁLOGATÁS TÉTELE: KIÍRJA AZ ÖSSZES ELEMET AMELY ELEGET TESZ A FELTÉTELNEK
        //FELTÉTEL: ÍRJA KI A PÁRATLAN SZÁMOKAT.
        System.out.print("A tömb páratlan számai: ");
        for (int i = 0; i < tomb.length; i++) {
            if (tomb[i]%2 == 1)
                System.out.print(tomb[i]+" ");
        }
        System.out.println();
        
        //Eldöntés tétele: Teljesül e a feltétel a tömbben.
        //Feltétel: Van 5-tel osztható szám?
        
        //v1
        boolean ered = false;
        int index = 0;
        while ( index < tomb.length){
            if (tomb[index]%5 == 0){
                ered = true;
                break;
            }
            index++;
        }
        if (ered)
            System.out.println("Van benne öttel osztható.");
        else
            System.out.println("Nincs benne öttel osztható.");
        //v2
        index = 0;
        while (index<tomb.length && tomb[index]%5 != 0){
            index++;
        }
        
        if (index != tomb.length)
            System.out.println("Van benne öttel osztható.");
        else
            System.out.println("Nincs benne öttel osztható.");
        
        //RENDEZÉS
        
        int csere;
        for (int i = 0; i < tomb.length-1; i++) {
            for (int j = i+1; j < tomb.length; j++) {
                if (tomb[i] > tomb[j]){
                    csere = tomb[i];
                    tomb[i] = tomb[j];
                    tomb[j] = csere;
                }
            }
        }
        System.out.println(Arrays.toString(tomb));
        
        
        
        
        
    }
    
}
