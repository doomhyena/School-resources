package gy0302_2223_14a_nyelv;
import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;
class Vizsga{
    String nyelv;
    HashMap<Integer, Integer> evek =
            new HashMap<>();
    int ossz = 0;

    public Vizsga(String sor) {
        String [] adatok = sor.split(";");
        this.nyelv = adatok[0];
        int ind = 1;
        for (int i = 2009; i <= 2018; i++) {
            evek.put(i, Integer.parseInt(adatok[ind]));
            ossz += Integer.parseInt(adatok[ind]);
            ind++;
        }
        
    }

    @Override
    public String toString() {
        return nyelv + ", " + ossz;
    }   
}

public class Gy0302_2223_14a_nyelv {

    static ArrayList<Vizsga> sikeres =
            new ArrayList<>();
    static ArrayList<Vizsga> sikertelen =
            new ArrayList<>();
    static int ev;
    public static void main(String[] args) {
        feltolt("sikeres.csv",sikeres);
        feltolt("sikertelen.csv",sikertelen);
        
        
        kiir(sikeres);
        kiir(sikertelen);
        _f2();
        _f3();
        _f4();
    }

    private static void feltolt(String file, ArrayList<Vizsga> lista) {
        File f = new File(file);
        try {
            Scanner be = new Scanner(f,"ISO-8859-2");
            be.nextLine();
            String sor;
            while(be.hasNextLine()){
                sor = be.nextLine();
                lista.add(new Vizsga(sor));
            }
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void kiir(ArrayList<Vizsga> lista) {
        for (Vizsga n : lista) {
            System.out.println(n);
        }
    }   

    private static void _f2() {
        ArrayList<String> helyek = new ArrayList<>();
        int max;
        String ny;
        
        for (int i = 0; i < 3; i++) {
            max = 0;
            ny = "-";
            for (int j = 0; j < sikeres.size(); j++) {
                if (sikeres.get(j).ossz+sikertelen.get(j).ossz > max
                        && !helyek.contains(sikeres.get(j).nyelv)){
                    max = sikeres.get(j).ossz+sikertelen.get(j).ossz;
                    ny = sikeres.get(j).nyelv;
                }
            }
            helyek.add(ny);
            
        }
        System.out.println(helyek);
    }

    private static void _f3() {
        Scanner be = new Scanner(System.in);
        
        System.out.print("Év 2009 és 2017 között: ");
        ev = be.nextInt();
        
        while(ev > 2017 || ev < 2009){
            System.out.print("Év 2009 és 2017 között: ");
            ev = be.nextInt();
        }
    }

    private static void _f4() {
        double max = 0;
        String ny ="-";
        double nevezo;
        
        for (int i = 0; i < sikeres.size(); i++) {
            nevezo = sikeres.get(i).evek.get(ev) + sikertelen.get(i).evek.get(ev);
            if (nevezo != 0){
                if ((double)sikertelen.get(i).evek.get(ev)/nevezo > max){
                    max = (double)sikertelen.get(i).evek.get(ev)/nevezo;
                    ny = sikertelen.get(i).nyelv;
                }
            }
        }
        
        System.out.printf("%s: %.2f%%",ny,max*100);
    }
}