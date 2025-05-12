


package gy0310_2223_13a;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;



public class Gy0310_2223_13a {

    
    static ArrayList<Integer> szamok =
            new ArrayList<>();
    public static void main(String[] args) {
        feltolt();
        kiir();
        //Írja ki, hogy hány elemet olvastunk be.
        System.out.println("Beolvasott elemek: "+szamok.size());
        //Írja ki a lista elemeinek összegét.
        System.out.println("Összeg: "+osszegzes());
        //Írja ki a lista elemeinek átlagát.
        System.out.println("Átlag: "+(osszegzes()/szamok.size()));
        //Írja ki a legnagyobb és legkisebb számot.
        //Írja ki hányszor szerepel benne a legnagyobb szám.
        minimax();
        //Írja ki, hogy az egyes számok hányszor szerepelnek benne.
        //(Minden szám egyszer szerepeljen a kiírásban)
        stat();
        
        fajlba_kiir();
    }

    private static void feltolt() {
        File f = new File("szamok.csv");
        try {
            Scanner be = new Scanner(f,"UTF-8"); //iso-8859-2
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                for (String elem : adatok)
                    szamok.add(Integer.parseInt(elem));
            }
            
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static void kiir() {
        for (Integer n : szamok) {
            System.out.println(n);
        }
    }

    private static double osszegzes() {
        double ossz = 0;
        for (Integer n : szamok)
            ossz+=n;
        return ossz;
    }

    private static void minimax() {
        int min = szamok.get(0);
        int max = szamok.get(0);
        
        int db = 1;
        
        for (Integer n : szamok) {
            if (n<min)
                min = n;
            
            if (n>max){
                max = n;
                db = 1;
            }
            else if ( n == max)
                db++;
        }
        System.out.println("Min: "+min);
        System.out.println("Max: "+max);
        System.out.println("Max db: "+db);
    }

    private static void stat() {
        ArrayList<Integer> egyszer =
                new ArrayList<>();
        for (Integer n : szamok) {
            if (!egyszer.contains(n))
                egyszer.add(n);
        }
        int db;
        for (int egyes : egyszer) {
            db = 0;
            for (int n : szamok) {
                if (egyes == n)
                    db++;
            }
            System.out.println(egyes+": "+db);
        }
        
    }

    private static void fajlba_kiir() {
        try{
            FileWriter fw = new FileWriter("elso.txt");
            fw.write("Valami...\n");
            fw.write("Valami");
            fw.close();
        }
        catch (IOException ioe){
            System.out.println("Hiba: "+ioe);
        }
        
        try {
            // Lista páros számait.
            FileWriter fw = new FileWriter("paros.txt");
            for (Integer n : szamok) {
                if (n %2 == 0)
                    fw.write(n+"\n");
            }
            fw.close();
        } catch (IOException ex) {
            System.out.println("Hiba: "+ex);
        }
        
    }
    
}
