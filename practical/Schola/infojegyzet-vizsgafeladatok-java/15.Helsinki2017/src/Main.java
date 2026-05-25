import java.io.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.*;
import java.util.*;
import java.util.stream.Collectors;

public class Main {

    static class Versenyzo {
        String nev;
        String orszag;
        double technikai;
        double komponens;
        double hibapont;

        Versenyzo(String nev, String orszag, double technikai, double komponens, double hibapont) {
            this.nev = nev;
            this.orszag = orszag;
            this.technikai = technikai;
            this.komponens = komponens;
            this.hibapont = hibapont;
        }

        double osszPont() {
            return technikai + komponens - hibapont;
        }
    }

    static List<Versenyzo> rovidprogram = new ArrayList<>();
    static List<Versenyzo> donto = new ArrayList<>();

    static void feladat(int n) {
        System.out.println(n + ". feladat:");
    }

    static void beolvas(String fajlnev, List<Versenyzo> lista) {
        try {
            List<String> sorok = Files.readAllLines(Paths.get(fajlnev), StandardCharsets.UTF_8);
            for (int i = 1; i < sorok.size(); i++) {
                String[] s = sorok.get(i).split(";");
                if (s.length < 5) continue;
                lista.add(new Versenyzo(
                        s[0],
                        s[1],
                        Double.parseDouble(s[2].replace(",", ".")),
                        Double.parseDouble(s[3].replace(",", ".")),
                        Double.parseDouble(s[4].replace(",", "."))
                ));
            }
            System.out.println(fajlnev + " beolvasva, sorok: " + lista.size());
        } catch (IOException e) {
            System.err.println("Hiba a fájl beolvasásakor: " + e.getMessage());
        }
    }

    public static void main(String[] args) {
        feladat(2);
        beolvas("rovidprogram.csv", rovidprogram);
        beolvas("donto.csv", donto);

        System.out.println("A rövidprogramban " + rovidprogram.size() + " induló volt.");

        feladat(4);
        System.out.println("A döntőben " + donto.size() + " induló volt.");

        feladat(5);
        System.out.printf("A rövidprogramból %d versenyző jutott be a kűrbe.%n",
                donto.size());

        feladat(6);
        Scanner sc = new Scanner(System.in);
        System.out.print("Adja meg egy versenyző nevét: ");
        String keresettNev = sc.nextLine().trim();
        Versenyzo rp = rovidprogram.stream()
                .filter(v -> v.nev.equalsIgnoreCase(keresettNev))
                .findFirst().orElse(null);
        if (rp == null) {
            System.out.println("Ilyen nevű induló nem volt!");
        } else {
            Versenyzo d = donto.stream()
                    .filter(v -> v.nev.equalsIgnoreCase(keresettNev))
                    .findFirst().orElse(null);

            double pont = (d != null ? d.osszPont() : rp.osszPont());
            System.out.printf("%s összpontszáma: %.2f%n", keresettNev, pont);
        }

        feladat(7);
        Map<String, Long> orszagStat = donto.stream()
                .collect(Collectors.groupingBy(v -> v.orszag, Collectors.counting()));
        System.out.println("Országonként a döntőbe jutott versenyzők:");
        orszagStat.entrySet().stream()
                .filter(e -> e.getValue() > 1)
                .forEach(e -> System.out.println(e.getKey() + ": " + e.getValue() + " versenyző"));

        feladat(8);
        List<Versenyzo> vegeredmeny = new ArrayList<>(donto);
        vegeredmeny.sort(Comparator.comparingDouble(Versenyzo::osszPont).reversed());
        List<String> fajlSorok = new ArrayList<>();
        fajlSorok.add("Helyezes;Nev;Orszag;OsszPont");
        for (int i = 0; i < vegeredmeny.size(); i++) {
            Versenyzo v = vegeredmeny.get(i);
            fajlSorok.add((i + 1) + ";" + v.nev + ";" + v.orszag + ";" + String.format("%.2f", v.osszPont()));
        }
        try {
            Files.write(Paths.get("vegeredmeny.csv"), fajlSorok, StandardCharsets.UTF_8);
            System.out.println("A 'vegeredmeny.csv' fájl elkészült!");
        } catch (IOException e) {
            System.err.println("Hiba a fájl írásakor: " + e.getMessage());
        }
    }
}
