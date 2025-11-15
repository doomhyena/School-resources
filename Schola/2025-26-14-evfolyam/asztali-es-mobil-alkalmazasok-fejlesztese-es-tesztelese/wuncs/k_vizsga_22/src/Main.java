import java.io.*;
import java.util.*;

public class Main {
    private static List<Pilota> pilotaLista = new ArrayList<>();

    public static void feladat(int n) {
        System.out.println(n + ". feladat");
    }

    private static void feltolt() {
        pilotaLista.clear();
        try (BufferedReader br = new BufferedReader(new FileReader("Mezony.csv"))) {
            String line;
            br.readLine();
            while ((line = br.readLine()) != null) {
                String[] parts = line.split(";");
                String nev = parts[0];
                int szuletesiEv = Integer.parseInt(parts[1].substring(0, 4));
                String csapat = parts[2];
                int futamokSzama = Integer.parseInt(parts[3]);
                int gyozelemSzama = (parts[4].isEmpty()) ? 0 : Integer.parseInt(parts[4]);
                String nemzetiseg = parts[5];
                pilotaLista.add(new Pilota(nev, szuletesiEv, csapat, futamokSzama, gyozelemSzama, nemzetiseg));
            }
        } catch (IOException e) {
            System.out.println("Hiba a fájl beolvasásakor: " + e.getMessage());
        }
    }

    private static void LegtobbFutammal(List<Pilota> pilotaLista) {
        Pilota legtobbFutammal = null;
        for (Pilota p : pilotaLista) {
            if (legtobbFutammal == null || p.getFutamokSzama() > legtobbFutammal.getFutamokSzama()) {
                legtobbFutammal = p;
            }
        }
        if (legtobbFutammal != null) {
            System.out.println("A legtöbb futammal rendelkező pilóta: " + legtobbFutammal.getNev());
        }
    }
    private static void Csapatok() {
        Map<String, List<String>> csapatok = new HashMap<>();
        for (Pilota p : pilotaLista) {
            csapatok.computeIfAbsent(p.csapat, k -> new ArrayList<>()).add(p.nev);
        }
        for (Map.Entry<String, List<String>> entry : csapatok.entrySet()) {
            System.out.println(entry.getKey() + ": " + String.join(", ", entry.getValue()));
        }
    }
    private static void Futamgyozelmek() {
        List<Pilota> gyoztesek = new ArrayList<>();
        for (Pilota p : pilotaLista) {
            if (p.gyozelemSzama > 0) gyoztesek.add(p);
        }
        gyoztesek.sort((a, b) -> Integer.compare(b.gyozelemSzama, a.gyozelemSzama));
        try (PrintWriter pw = new PrintWriter("Gyoztesek.txt")) {
            for (Pilota p : gyoztesek) {
                pw.println(p.nev + " - " + p.gyozelemSzama);
            }
        } catch (IOException e) {
            System.out.println("Hiba a fájl írásakor: " + e.getMessage());
        }
    }
    public static void main(String[] args) {
        feladat(4);
        feltolt();
        feladat(5);
        LegtobbFutammal(pilotaLista);
        feladat(6);
        Csapatok();
        feladat(7);
        Futamgyozelmek();
    }
}
