/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1017_2223_13a;

import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy1017_2223_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner be = new Scanner(System.in);
        System.out.print("Kérek egy számot: ");
        int szam = be.nextInt();
        int osztok = 0;
        for (int i = 2; i <= Math.sqrt(szam); i++) {
            if (szam%i == 0)
                osztok++;
        }
        if (osztok==0 && szam>1)
            System.out.println("Prím!");
        else
            System.out.println("Nem prím.");
        
        int oszt = 2;
        boolean prim = true;
        while(oszt<=Math.sqrt(szam)){
            if (szam%oszt == 0){
                prim =false;
                break;
            }
            oszt++;
        }
        if (prim)
            System.out.println("Prím.");
        else
            System.out.println("Nem prím.");
        
        oszt = 2;
        while (oszt<=Math.sqrt(szam) && szam%oszt != 0){
            oszt++;
        }
        Double o = Math.sqrt(szam);
        if (oszt == o.intValue()+1)
            System.out.println("Prím");
        else
            System.out.println("Nem prím.");
    
    }
    
}
