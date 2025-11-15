/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0904_2526_13a_elagazas;

/**
 *
 * @author wuncs.david
 */
public class Gy0904_2526_13a_elagazas {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int a = 25;
        int b = 25;
        
        // Két érték egyenlőségének vizsgálata: ==
        
        if (a>b) {//Zárójelbe LOGIKAI ÁLLÍTÁS: Ha igaz lefut a kód!
            System.out.println(a+" nagyobb mint "+b);
        }
        else if (a<b){
            System.out.println(a+" kisebb mint "+b);
        }
        else{
            System.out.println(a+" egyenlő "+b);
        }
        /*
        Elágazás MINDIG 1 DARAB if-el kezdődik
        0-tól végtelenig tartalmazhat else if-et 
        A végén 0 vagy 1 darab else ága lehet!
        CSAK EGY ÁG TUD LEFUTNI!!!!
        */
        
        System.out.println("Vége az elágazásnak!");
        
        System.out.println("--------------------------");
        int p = 84;
        
        if (p%2 == 0){ //%-jel maradékos osztás. p 2-vel való osztás után mekkora maradékot ad
            System.out.println(p+" páros szám");
        }
        else {
            System.out.println(p+" páratlan szám");
        }
        
        //Összetett feltétel--> És: &&   Vagy: || (Alt Gr + W)
        
        if (p%3 == 0 && p > 30){
            System.out.println(p+" hárommal osztható 30-nál nagyobb szám");
        }
        
        System.out.println("-----------------");
        
        double h_a = 3;
        double h_b = 4;
        double h_c = 5;
        
        if (h_a+h_b > h_c && h_a+h_c > h_b && h_b+h_c > h_a){
            
            double ker = h_a+h_b+h_c;
            double s = ker/2;
            
            double ter = Math.sqrt(s*(s-h_a)*(s-h_b)*(s-h_c));
            
            System.out.println("Kerület: "+ker);
            System.out.println("Terület: "+ter);
            
        }
        else{
            System.out.println("Ez nem egy háromszög!");
        }
        
        
        /*
        Feladat: Adott egy derékszögű háromszög.
        Két befogója 7 és 10 cm hosszú. Mekkora az átfogó?
        */
        
        double b1 = 7;
        double b2 = 10;
        
        double atfogo = Math.sqrt(Math.pow(b1,2)+Math.pow(b2, 2));
        System.out.println("Átfogó: "+atfogo);
        
        System.out.println("-------------------");
        
        double r = -9;
        r = Math.abs(r);
        
        double k_ker = 2*r*Math.PI;
        double k_ter = Math.pow(r, 2)*Math.PI;
        
        System.out.println("Kerület: "+k_ker+"\nTerület: "+k_ter); // \n = sortörés
        
        /*
        Feladat: Alakítsátok át úgy a feladatot, hogy ha negatív
            számot adunk meg sugárnak, akkor az ő pozitív
            értékével, jól kiszámolja a kerületet és területet
        NEM LEHET -1-gyel megszorozni!
        */
        
      
        
    }
}
    

