/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1114_2223_13a_osszefoglalo;


import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

/**
 *
 * @author wuncs.david
 */
public class Gy1114_2223_13a_osszefoglalo {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        Scanner be = new Scanner(System.in);
        
        int [] t = new int[10];
        
        //TÖMB ÁLTALÁNOS FELTÖLTÉSE
        for (int i = 0; i < t.length; i++) {
            t[i] = rnd.nextInt(100-1+1)+1;
            
        }
        System.out.println(Arrays.toString(t));
        
        //ÖSSZEGZÉS TÉTELE
        int osszeg = 0;
        for (int i = 0; i < t.length; i++) {
            osszeg += t[i];
        }
        System.out.println("Tömb elemeinek összege: "+osszeg);
   
        //Minimum/Maximum kiválasztás tétele
        int min = t[0];
        int max = t[0];
        for (int i = 0; i < t.length; i++) {
            //Min
            if (t[i]<min)
                min = t[i];
            //Max
            if (t[i]>max)
                max = t[i];
        }
        System.out.println("Tömb legkisebb értéke: "+min);
        System.out.println("Tömb legnagyobb értéke: "+max);
        min = 102;
        for (int i = 0; i < t.length; i++) {
            //Min páros
            if (t[i]<min && t[i]%2 == 0)
                min = t[i];
        }
        if (min != 102)
            System.out.println("Legkisebb páros: "+min);
        
        //Kiválogatás tétele (páros számok)
        System.out.print("A tömb páros számai: ");
        for (int i = 0; i < t.length; i++) {
            if (t[i]%2 == 0)
                System.out.print(t[i]+" ");
        }
        System.out.println("");
        //Eldöntés tétele (20 és 30 közötti szám)
        boolean van = false;
        int index = 0;
        while(index < t.length){
            if (t[index]>=20 && t[index]<=30){
                van = true;
                break;
            }
            index++;
        }
        
        if (van)
            System.out.println("Van 20 és 30 közötti szám.");
        else
            System.out.println("Nincs 20 és 30 közötti szám.");
        
        //Rendezés
        int csere;
        for (int i = 0; i < t.length-1; i++) {
            for (int j = i+1; j < t.length; j++) {
                if (t[i] > t[j]){
                    csere = t[i];
                    t[i] = t[j];
                    t[j] = csere;
                }
            }
        }
        System.out.println(Arrays.toString(t));
        
        /*Kérjen be számokat 0 végjelig
                - Írja ki a számok összegét.
                - Írja ki a legnagyobb beírt számot (0 nem)
                - Írja ki hány darab számot adott a felhasználó.
                - Írja ki hanyadik alkalommal adott elõször
                  páros számot. (a 0 nem számít)
        */
        
        int szam;
        int ossz = 0;
        int m = Integer.MIN_VALUE;
        int db = 0;
        boolean volt = false;
        int alk = 0;
        do{
            System.out.print("Kérek egy számot (0 végjel):");
            szam = be.nextInt();
           if (szam != 0){
               db++;
               ossz += szam;
               if (szam > m)
                   m = szam;
               
               if (!volt && szam%2 == 0){
                   volt = true;
                   alk = db;
               }
               
           }
        }while(szam != 0);
        
        System.out.println("Összeg: "+ossz);
        System.out.println(db+" szám volt.");
        System.out.println("Legnagyobb szám: "+m);
        if (alk != 0)
        System.out.println(alk+". alkalommal adott páros számot.");
    }
    
}
