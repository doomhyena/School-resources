import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    static class Zene {
        private String band;
        private String song;
        private int year;
        private long streams;

        public Zene(String band, String song, int year, long streams) {
            this.band = band;
            this.song = song;
            this.year = year;
            this.streams = streams;
        }

        public String getBand() {
            return band;
        }

        public void setBand(String band) {
            this.band = band;
        }

        public String getSong() {
            return song;
        }

        public void setSong(String song) {
            this.song = song;
        }

        public int getYear() {
            return year;
        }

        public void setYear(int year) {
            this.year = year;
        }

        public long getStreams() {
            return streams;
        }

        public void setStreams(long streams) {
            this.streams = streams;
        }

        @Override
        public String toString() {
            return
                    band + '\'' +
                    ", " + song + '\'' +
                    ", " + year +
                    ", " + streams;
        }
    }

    static ArrayList <Zene> zenek = new ArrayList<>();

    private static void feltolt() {
        File f = new File("eloadok.csv");

        try {
            Scanner be = new Scanner(f, "UTF-8");
            be.nextLine();
            String sor = be.nextLine();
            String[] adatok;
            while (be.hasNextLine()) {
                sor = be.nextLine();
                adatok = sor.split(";");
                zenek.add(new Zene(
                        adatok[0],
                        adatok[1],
                        Integer.parseInt(adatok[2]),
                        Integer.parseInt(adatok[3])
                ));
            }

        } catch (Exception e) {
            System.out.println("Hiba történt!: " + e);
        }
    }
    private static void linkinParkMax() {
        Zene max = null;
        for (Zene z : zenek) {
            if (z.getBand().equalsIgnoreCase("Linkin Park")) {
                if (max == null || z.getStreams() > max.getStreams()) {
                    max = z;
                }
            }
        }
        if (max != null) {
            System.out.println("6. feladat: ");
            System.out.println("A Linkin Park legtöbbet streamelt száma: " + max.getSong() + " " + (  + max.getStreams()));
        } else {
            System.out.println("6. feladat: ");
            System.out.println("A Linkin Park nincs az adatbázisban.");
        }
    }

    private static void osszesStreameles() {
        System.out.println("7.feladat:");
        Map<String, Integer> streamelesek = new HashMap<>();

        for (Zene n : zenek) {
            if (!streamelesek.containsKey(n.getBand())) {
                streamelesek.put(n.getBand(), (int) n.getStreams());
            } else {
                streamelesek.put(n.getBand(), streamelesek.get(n.getBand()) + (int) n.getStreams());
            }
            // System.out.println(streamelesek);

            for (String k : streamelesek.keySet()) {
                System.out.println(k + " : " + streamelesek.get(k));
            }
        }
    }
    private static void fajlstreamek() {
        try {
            FileWriter fw = new FileWriter("streamek.txt");
            for (Zene zene : zenek) {
                fw.write(zene+ "\n");
            }
            fw.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public static void main(String[] args) {
        feltolt();

        for (Zene n : zenek) {
            System.out.println(n);
        }
        linkinParkMax();
        osszesStreameles();
        fajlstreamek();
    }
}