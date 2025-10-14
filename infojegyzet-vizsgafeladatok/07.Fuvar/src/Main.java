import java.io.*;
import java.text.DecimalFormat;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.nio.charset.StandardCharsets;

public class Main {

    static List<Fuvar> fuvarok = new ArrayList<>();
    static List<Fuvar> hibasFuvarok = new ArrayList<>();

    public static void feladat(int n) {
        System.out.println("\n" + n + ". feladat:");
    }

    public static void feltolt() {
        try (BufferedReader br = new BufferedReader(new InputStreamReader(
                new FileInputStream("fuvar.csv"), StandardCharsets.UTF_8))) {

            br.readLine();
            String line;
            DateTimeFormatter fmt = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");

            while ((line = br.readLine()) != null) {
                String[] parts = line.split(";");
                if (parts.length != 7) continue;

                int id = Integer.parseInt(parts[0]);
                LocalDateTime indulas = LocalDateTime.parse(parts[1], fmt);
                int idotartam = Integer.parseInt(parts[2]);
                double tavolsag = Double.parseDouble(parts[3].replace(',', '.'));
                double viteldij = Double.parseDouble(parts[4].replace(',', '.'));
                double borravalo = Double.parseDouble(parts[5].replace(',', '.'));
                String fizetes = parts[6];

                fuvarok.add(new Fuvar(id, indulas, idotartam, tavolsag, viteldij, borravalo, fizetes));
            }
            System.out.println("A fájl sikeresen beolvasva!");

        } catch (IOException e) {
            System.err.println("Hiba a fájl beolvasásakor: " + e);
        }
    }

    public static void hibasSorokMentese(String file) {
        try (BufferedWriter bw = new BufferedWriter(
                new OutputStreamWriter(new FileOutputStream("fuvar.csv"), StandardCharsets.UTF_8))) {

            bw.write("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
            bw.newLine();

            hibasFuvarok.stream()
                    .sorted(Comparator.comparing(f -> f.indulas))
                    .forEach(f -> {
                        try {
                            bw.write(f.toCsvLine());
                            bw.newLine();
                        } catch (IOException e) {
                            throw new UncheckedIOException(e);
                        }
                    });

            System.out.println("hibak.txt fájl létrehozva. (" + hibasFuvarok.size() + " sor)");

        } catch (IOException e) {
            System.err.println("Nem sikerült létrehozni a hibak.txt fájlt!");
        }
    }

    public static void main(String[] args) {
        feladat(2);
        feltolt();

        feladat(3);
        System.out.println(fuvarok.size() + " fuvar");

        feladat(4);
        int taxiId = 6185;
        double osszBevetel = 0;
        int fuvarokSzama = 0;
        for (Fuvar f : fuvarok) {
            if (f.taxi_id == taxiId) {
                fuvarokSzama++;
                osszBevetel += f.viteldij + f.borravalo;
            }
        }
        DecimalFormat df2 = new DecimalFormat("0.00");
        System.out.println("A " + taxiId + "-ös taxis bevétele: " + df2.format(osszBevetel) + "$");
        System.out.println("Fuvarok száma: " + fuvarokSzama);

        feladat(5);
        Map<String, Integer> fizetesek = new TreeMap<>();
        for (Fuvar f : fuvarok) {
            fizetesek.put(f.fizetes_modja, fizetesek.getOrDefault(f.fizetes_modja, 0) + 1);
        }
        for (Map.Entry<String, Integer> e : fizetesek.entrySet()) {
            System.out.println(e.getKey() + ": " + e.getValue() + " fuvar");
        }

        feladat(6);
        double osszTavKm = fuvarok.stream().mapToDouble(f -> f.tavolsag * 1.6).sum();
        System.out.println("Összes megtett távolság: " + df2.format(osszTavKm) + " km");

        feladat(7);
        Fuvar leghosszabb = Collections.max(fuvarok, Comparator.comparingInt(f -> f.idotartam));
        System.out.println("Leghosszabb fuvar:");
        System.out.println("Fuvar hossza: " + leghosszabb.idotartam + " másodperc");
        System.out.println("Taxi azonosító: " + leghosszabb.taxi_id);
        System.out.println("Megtett távolság: " + leghosszabb.tavolsag + " mérföld");
        System.out.println("Viteldíj: " + leghosszabb.viteldij + "$");

        feladat(8);
        hibasSorokMentese("hibak.txt");
    }
}