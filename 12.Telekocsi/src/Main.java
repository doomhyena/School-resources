import java.io.*;
import java.nio.file.*;
import java.util.*;

public class Main {

    static class Auto {
        String indul;
        String cel;
        String rendszam;
        String telefon;
        int ferohely;

        Auto(String indul, String cel, String rendszam, String telefon, int ferohely) {
            this.indul = indul;
            this.cel = cel;
            this.rendszam = rendszam;
            this.telefon = telefon;
            this.ferohely = ferohely;
        }
    }

    static class Igeny {
        String azonosito;
        String indul;
        String cel;
        int szemelyek;

        Igeny(String azonosito, String indul, String cel, int szemelyek) {
            this.azonosito = azonosito;
            this.indul = indul;
            this.cel = cel;
            this.szemelyek = szemelyek;
        }
    }

    static List<Auto> autok = new ArrayList<>();

    public static void feladat(int n) {

        System.out.println("\n" + n + ". feladat:");

    }

    public static void beolvas() {
        try {
            List<String> autoSorok = Files.readAllLines(Paths.get("autok.csv"));
            for (int i = 1; i < autoSorok.size(); i++) {
                String[] adat = autoSorok.get(i).split("[;:]");
                if (adat.length < 5) continue;

                autok.add(new Auto(
                        adat[0].trim(),
                        adat[1].trim(),
                        adat[2].trim(),
                        adat[3].trim(),
                        Integer.parseInt(adat[4].trim())
                ));
            }
            System.out.println("A fájl beolvasása sikeres, " + autok.size() + " autó hirdet fuvart.");
        } catch (IOException e) {
            System.err.println("Hiba a fájl beolvasásakor: " + e.getMessage());
        }
    }

    public static void main(String[] args) {
        feladat(1);
        beolvas();

        feladat(2);
        System.out.println(autok.size() + " autós hirdet fuvart");

        feladat(3);
        int osszFerohely = 0;
        for (Auto a : autok) {
            if (a.indul.equalsIgnoreCase("Budapest") && a.cel.equalsIgnoreCase("Miskolc")) {
                osszFerohely += a.ferohely;
            }
        }
        System.out.println("Összesen " + osszFerohely +
                " férőhelyet hirdettek az autósok Budapestről Miskolcra");

        feladat(4);
        Map<String, Integer> utvonalFerohely = new HashMap<>();
        for (Auto a : autok) {
            String key = a.indul + " - " + a.cel;
            utvonalFerohely.put(key, utvonalFerohely.getOrDefault(key, 0) + a.ferohely);
        }

        String maxUtvonal = null;
        int maxFerohely = 0;
        for (var e : utvonalFerohely.entrySet()) {
            if (e.getValue() > maxFerohely) {
                maxFerohely = e.getValue();
                maxUtvonal = e.getKey();
            }
        }

        System.out.println("A legtöbb (" + maxFerohely +
                ") férőhelyet a " + maxUtvonal + " útvonalon ajánlották fel a hirdetők");


        feladat(5);
        List<Igeny> igenyek = new ArrayList<>();
        try {
            List<String> igenySorok = Files.readAllLines(Paths.get("igenyek.csv"));
            for (int i = 1; i < igenySorok.size(); i++) {
                String[] adat = igenySorok.get(i).split("[;:]");
                if (adat.length < 4) continue;
                igenyek.add(new Igeny(
                        adat[0].trim(),
                        adat[1].trim(),
                        adat[2].trim(),
                        Integer.parseInt(adat[3].trim())
                ));
            }
        } catch (IOException e) {
            System.err.println("Hiba az igények beolvasásakor: " + e.getMessage());
        }

        List<String> uzenetek = new ArrayList<>();

        for (Igeny ig : igenyek) {
            boolean talalt = false;
            for (Auto a : autok) {
                if (a.indul.equalsIgnoreCase(ig.indul)
                        && a.cel.equalsIgnoreCase(ig.cel)
                        && a.ferohely >= ig.szemelyek) {
                    System.out.println(ig.azonosito + " => " + a.rendszam);
                    uzenetek.add(ig.azonosito + ": Rendszám: " + a.rendszam +
                            ", Telefonszám: " + a.telefon);
                    talalt = true;
                    break;
                }
            }
            if (!talalt) {
                uzenetek.add(ig.azonosito + ": Sajnos nem sikerült autót találni");
            }
        }

        feladat(6);
        try {
            Files.write(Paths.get("utasuzenetek.txt"), uzenetek);
            System.out.println("A 'utasuzenetek.txt' fájl elkészült.");
        } catch (IOException e) {
            System.err.println("Hiba a fájl írásakor: " + e.getMessage());
        }
    }
}
