/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0909_2223_13a;

/**
 *
 * @author wuncs.david
 */
public class Gy0909_2223_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        //<editor-fold defaultstate="collapsed" desc="Ismétlés">
        /*String a = "Ezek a szövegek";
        int b = 17;
        double c = 7.5;
        
        System.out.println(a+", "+b+", "+(c+b));
        
        System.out.println("Hatványozás: "+Math.pow(7, 2));
        System.out.println("Gyök: "+Math.sqrt(9));
        
        double aa = 1;
        double bb = 9;
        double cc = 8;
        
        double x1 = (-bb+Math.sqrt(Math.pow(bb, 2)-4*aa*cc))/(2*aa);
        double x2 = (-bb-Math.sqrt(Math.pow(bb, 2)-4*aa*cc))/(2*aa);
        
        System.out.println("x1: "+x1+"\nx2: "+x2);*/
//</editor-fold>
        
        int a = 6;
        int b = 2;
        
        if (a>b){
            System.out.println("a nagyobb mint b.");
        }
        else if (a == b){
            System.out.println("A két szám egyenlő.");
        }
        else{
            System.out.println("b nagyobb mint a.");
        }
        
        if (a>=5 && a<=10){ //ÉS kapcsolat: Mindkét állításnak igaznak kell lennie.
            System.out.println("a értéke 5 és 10 között van.");
        }
        else{
            System.out.println("a értéke nincs 5 és 10 között.");
        }
        
        if (b<5 || b>10){ //VAGY kapcsolat: Elég az egyik állításnak igaznak lennie.
            System.out.println("b kisebb mint 5 vagy nagyobb mint 10.");
        }
        else{
            System.out.println("b 5 és 10 között van.");
        }
        
        
            
  
        
        
    }
    
}
