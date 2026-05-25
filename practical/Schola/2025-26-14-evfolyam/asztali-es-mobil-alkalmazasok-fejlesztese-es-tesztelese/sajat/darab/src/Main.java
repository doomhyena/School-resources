import java.io.*;
import java.util.*;

public class Main {
    static ArrayList<Nezettseg> nezettsegek = new ArrayList<>();
    // static ArrayList<Nezettseg> nezettsegek2021 = new ArrayList<>();
    // static ArrayList<Nezettseg> nezettsegek2022 = new ArrayList<>();

    public static void feladat(int n) {
        System.out.println(n + ".feladat: ");
    }
    public static void fajlbeolvas() {
        try (BufferedReader br = new BufferedReader(new FileReader("darabok.csv"))) {
            br.readLine();
            String sor;
            while ((sor = br.readLine()) != null) {
                String[] adatok = sor.split(";");
                String cim = adatok[0];
                int q1 = Integer.parseInt(adatok[1]);
                int q2 = Integer.parseInt(adatok[2]);
                int q3 = Integer.parseInt(adatok[3]);
                int q4 = Integer.parseInt(adatok[4]);
                int q5 = Integer.parseInt(adatok[5]);
                int q6 = Integer.parseInt(adatok[6]);
                int q7 = Integer.parseInt(adatok[7]);
                int q8 = Integer.parseInt(adatok[8]);
                Nezettseg nezettseg = new Nezettseg(cim, q1, q2, q3, q4, q5, q6, q7, q8);
                nezettsegek.add(nezettseg);
                /*
                * Nezettseg nezettseg1 = new Nezettseg(
                *   Integer.parseInt(adatok[5]),
                *   Integer.parseInt(adatok[6]),
                *   Integer.parseInt(adatok[7])
                * );
                * nezettsegek.add(nezettseg1);
                */
            }
            System.out.println("Az adatok sikeresen beolvasva!");
        } catch (Exception e) {
            System.out.println("Hiba történt: " + e.getMessage());
        }
    }
    public static void masodiknegyedev() {
        int ossznezo2021 = 0;
        int ossznezo2022 = 0;
        for (Nezettseg nezettseg : nezettsegek) {
            ossznezo2021 += nezettseg.getQ1();
        }
        System.out.println("2021: " + ossznezo2021);
        for (Nezettseg nezettseg : nezettsegek) {
            ossznezo2022 += nezettseg.getQ1();
        }
        System.out.println("2022: " + ossznezo2022);
    }
    public static void negyediknegyedev() {
        int atlagnezo2021 = 0;
        for (Nezettseg nezettseg : nezettsegek) {
            atlagnezo2021 += nezettseg.getQ4();
        }
        System.out.println("2021 negyedik negyedévében átlagosan" + atlagnezo2021 / nezettsegek.size() + " néző volt.");
    }
    public static void legtobbetmegnezett() {
        int legtobbetNezett2022 = 0;
        String szindarabneve = "";
        for (Nezettseg nezettseg : nezettsegek) {
            if (nezettseg.getQ1() > legtobbetNezett2022) {
                legtobbetNezett2022 = nezettseg.getQ1();
                szindarabneve = nezettseg.getSzindarabneve();
            }
        }
        System.out.println(szindarabneve + " volt a legnézetteb darab 2022 első negyedévében.");
    }
    public static void novekedes() {
        try (BufferedWriter bw = new BufferedWriter(new FileWriter("novekedes.txt"))) {
            for (Nezettseg nezettseg : nezettsegek) {
                bw.write(
                        nezettseg.getSzindarabneve() +
                        ", Q1: " + nezettseg.getQ1() +
                        ", Q2: " + nezettseg.getQ2() +
                        ", Q3: " + nezettseg.getQ3() +
                        ", Q4: " + nezettseg.getQ4() +
                        "\n");
            }
            for (Nezettseg nezettseg : nezettsegek) {
                bw.write(
                        nezettseg.getSzindarabneve() +
                        ", Q1: " + nezettseg.getQ5() +
                        ", Q2: " + nezettseg.getQ6() +
                        ", Q3: " + nezettseg.getQ7() +
                        ", Q4: " + nezettseg.getQ8() +
                        "\n");
            }
            System.out.println("A fájl sikeresen létrehozva!");
        } catch (Exception e) {
            System.out.println("Hiba történt: " + e.getMessage());
        }
    }
    public static void main(String[] args) {
        feladat(5);
        fajlbeolvas();
        feladat(6);
        masodiknegyedev();
        feladat(7);
        negyediknegyedev();
        feladat(8);
        legtobbetmegnezett();
        feladat(9);
        novekedes();
    }
}