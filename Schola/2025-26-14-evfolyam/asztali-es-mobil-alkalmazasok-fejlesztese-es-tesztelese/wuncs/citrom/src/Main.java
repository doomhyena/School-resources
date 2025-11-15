import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;

public class Main {
    public static void feladat(int n) {
        System.out.println(n + ". feladat");
    }
    public static void main(String[] args) {
        List<Citromos> lista = new ArrayList<>();

        feladat(1);
        try (BufferedReader br = new BufferedReader(new FileReader("citrom.csv"))) {
            String sor;
            boolean elsoSor = true;
            while ((sor = br.readLine()) != null) {
                if (elsoSor) { // fejléc átugrása
                    elsoSor = false;
                    continue;
                }

                String[] adatok = sor.split(";");
                String megnevezes = adatok[0];
                int ar = Integer.parseInt(adatok[1]);
                String kategoria = adatok[2];

                lista.add(new Citromos(megnevezes, ar, kategoria));
            }
        } catch (IOException e) {
            System.out.println("Hiba a fájl beolvasásakor: " + e.getMessage());
            return;
        }

        feladat(2);
        double atlagAr = lista.stream()
                .mapToDouble(Citromos::getAr)
                .average()
                .orElse(0);
        System.out.println("Átlagár: " + atlagAr + " Ft");

        feladat(3);
        Map<String, Integer> kategoriak = new HashMap<>();

        for (Citromos c : lista) {
            kategoriak.put(
                    c.getKategoria(),
                    (int) (kategoriak.getOrDefault(c.getKategoria(), 0) + c.getAr())
            );
        }

        System.out.println("\nKategóriánkénti összes ár:");
        for (Map.Entry<String, Integer> entry : kategoriak.entrySet()) {
            System.out.println(entry.getKey() + ": " + entry.getValue() + " Ft");
        }
    }
}
