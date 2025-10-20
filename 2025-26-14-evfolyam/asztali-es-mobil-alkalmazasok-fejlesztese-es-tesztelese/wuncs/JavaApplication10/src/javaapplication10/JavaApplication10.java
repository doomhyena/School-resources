/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package javaapplication10;

/**
 *
 * @author wuncs.david
 */
public class JavaApplication10 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Snooker max = s.get(0);
        for (Snooker n : s){
            if (s.getNyeremeny() > max.getNyeremeny())
                max = s;
        }
        System.out.println("Max: "+(max.getNyeremeny()*380));
    }
    
}
