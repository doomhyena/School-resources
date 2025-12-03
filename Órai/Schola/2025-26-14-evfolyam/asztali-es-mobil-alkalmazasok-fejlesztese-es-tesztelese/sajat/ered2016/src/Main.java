import java.io.*;
import java.nio.file.*;
import java.util.*;

class Eredmeny {
    String nagydij;
    int rajt;
    int befutas;
    int pont;

    public Eredmeny(String nagydij, int rajt, int befutas, int pont) {
        this.nagydij = nagydij;
        this.rajt = rajt;
        this.befutas = befutas;
        this.pont = pont;
    }
}

public class Main {
    public static void main(String[] args) {
        List<Eredmeny> ric = new ArrayList<>();
        List<Eredmeny> ros = new ArrayList<>();

        try {
            List<String> sorok = Files.readAllLines(Paths.get("eredmenyek2016.csv"));

            for (int i = 2; i < sorok.size(); i++) {
                String[] adatok = sorok.get(i).split(";");
                String nagydij = adatok[0];

                int rRajt = Integer.parseInt(adatok[1]);
                int rBef = Integer.parseInt(adatok[2]);
                int rPont = Integer.parseInt(adatok[3]);
                ric.add(new Eredmeny(nagydij, rRajt, rBef, rPont));

                int oRajt = Integer.parseInt(adatok[4]);
                int oBef = Integer.parseInt(adatok[5]);
                int oPont = Integer.parseInt(adatok[6]);
                ros.add(new Eredmeny(nagydij, oRajt, oBef, oPont));
            }

        } catch (IOException e) {
            System.out.println("Hiba a fájl beolvasásakor!");
            return;
        }

        int ricPont = ric.stream().mapToInt(r -> r.pont).sum();
        int rosPont = ros.stream().mapToInt(r -> r.pont).sum();
        System.out.println("6. Feladat:");
        System.out.println("Ricciardo pontjai: " + ricPont);
        System.out.println("Rosberg pontjai: " + rosPont);
        double rosRajtAtlag = ros.stream().mapToInt(r -> r.rajt).average().orElse(0);

        System.out.println("7. Feladat:");
        System.out.println("Rosberg átlagos rajtpozíciója: " + (int)Math.round(rosRajtAtlag));

        System.out.println("8. Feladat:");
        for (int i = 0; i < ric.size(); i++) {
            Eredmeny r1 = ric.get(i);
            Eredmeny r2 = ros.get(i);

            if (r1.befutas <= 3 && r2.befutas <= 3) {
                System.out.println(r1.nagydij + " - Ricciardo: " + r1.befutas + ", Rosberg: " + r2.befutas);
            }
        }

        Map<Integer, Integer> stat = new TreeMap<>();
        for (Eredmeny r : ric) {
            stat.put(r.befutas, stat.getOrDefault(r.befutas, 0) + 1);
        }

        try (PrintWriter pw = new PrintWriter("RicStat.txt")) {
            for (Map.Entry<Integer, Integer> e : stat.entrySet()) {
                pw.println(e.getKey() + ". helyezés: " + e.getValue() + " alkalom");
            }
        } catch (IOException e) {
            System.out.println("Hiba az allomany irasakor!");
        }

        System.out.println("9. Feladat: RicStat.txt fájl létrehozva.");
    }
}
