/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package rendezes;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;

class Osztaly implements Comparable<Osztaly>{
    String nev;
    int kor;
    Random rnd = new Random();

    
    public Osztaly(String nev) {
        this.nev = nev;
        this.kor = rnd.nextInt(70-20+1)+20;
    }

    @Override
    public int compareTo(Osztaly t) {
        // return kor - t.kor; Kor alapján rendezés
           return nev.compareTo(t.nev); //Név alapján rendezés
        
        
    }
    
    
}



public class Rendezes {

    static ArrayList<Osztaly> emberek = new ArrayList<>();
    public static void main(String[] args) {
        emberek.add(new Osztaly("Lajos"));
        emberek.add(new Osztaly("Bela"));
        emberek.add(new Osztaly("Akos"));
        emberek.add(new Osztaly("Anna"));
        emberek.add(new Osztaly("Fruzsina"));
        emberek.add(new Osztaly("Orsi"));
        emberek.add(new Osztaly("Imre"));
        emberek.add(new Osztaly("Karoly"));
        emberek.add(new Osztaly("Ferenc"));
        
        Collections.sort(emberek);
        
        for (Osztaly n : emberek) {
            System.out.println(n.nev+": "+n.kor);
        }
        
    }
    
}
