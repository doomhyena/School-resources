package gyak_0910;

import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

class Eredmeny {
    private String nagydij;
    private int rajt;
    private int befutas;
    private int pontszam;

    public String getNagydij() {
        return nagydij;
    }

    public void setNagydij(String nagydij) {
        this.nagydij = nagydij;
    }

    public int getRajt() {
        return rajt;
    }

    public void setRajt(int rajt) {
        this.rajt = rajt;
    }

    public int getBefutas() {
        return befutas;
    }

    public void setBefutas(int befutas) {
        this.befutas = befutas;
    }

    public int getPontszam() {
        return pontszam;
    }

    public void setPontszam(int pontszam) {
        this.pontszam = pontszam;
    }

    @Override
    public String toString() {
        return "Eredmeny{" + "nagydij=" + nagydij + ", rajt=" + rajt + ", befutas=" + befutas + ", pontszam=" + pontszam + '}';
    }

    public Eredmeny(String nagydij, int rajt, int befutas, int pontszam) {
        this.nagydij = nagydij;
        this.rajt = rajt;
        this.befutas = befutas;
        this.pontszam = pontszam;
    }
}

public class Gyak_0910 {
    
    static ArrayList<Eredmeny> ric = new ArrayList<>();
    static ArrayList<Eredmeny> ros = new ArrayList<>();

    public static void main(String[] args) {
        feltolt();
        kiir();
        pontok();
        atlag();
    }

    private static void feltolt() {
        File f = new File("eredmenyek2016.csv");
        try {
            Scanner be = new Scanner(f, "UTF-8");
            be.nextLine();
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()) {
                sor = be.nextLine();
                adatok = sor.split(";");
                
                ric.add(new Eredmeny(adatok[0], Integer.parseInt(adatok[1]), Integer.parseInt(adatok[2]), Integer.parseInt(adatok[3])));
                ros.add(new Eredmeny(adatok[0], Integer.parseInt(adatok[4]), Integer.parseInt(adatok[5]), Integer.parseInt(adatok[6])));
            }
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }

    private static void kiir() {
        for (int i = 0; i < ric.size(); i++) {
            System.out.println(ric.get(i).getNagydij()+", Ric: "+ric.get(i).getBefutas()+", Ros "+ros.get(i).getPontszam());
        }
    }

    private static void pontok() {
        int ric1 = 0;
        int ros1 = 0;
        
        int ric2 = 0;
        int ros2 = 0;
        
        for (int i = 0; i < ric.size(); i++) {
            ric1 += ric.get(i).getPontszam();
            ros1 += ros.get(i).getPontszam();
        }
        
       
        
        
        System.out.println("Ricciardo: "+ric1+" Rosberg: "+ros1);
    }

    private static void atlag() {
        int avg = 0;
        
        for (Eredmeny n : ros) {
            avg += n.getRajt();
        }
        
        avg /= ros.size();
        System.out.println("Átlagos indulás: "+avg);
    }
    
}
