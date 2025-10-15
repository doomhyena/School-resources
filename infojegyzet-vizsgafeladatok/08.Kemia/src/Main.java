import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.*;
import java.util.regex.Pattern;

public class Main {

    static List<Elem> elemek = new ArrayList<>();

    public static void feladat(int n) {
        System.out.println("\n" + n + ". feladat:");
    }

    public static void feltolt() {
        try (BufferedReader br = new BufferedReader(new InputStreamReader(
                new FileInputStream("felfedezesek.csv"), StandardCharsets.UTF_8))) {

            br.readLine();
            String line;

            while ((line = br.readLine()) != null) {
                String[] parts = line.split(";");
                if (parts.length != 5) continue;

                String ev = parts[0].trim();
                String nev = parts[1].trim();
                String vegyjel = parts[2].trim();
                int rendszam = Integer.parseInt(parts[3].trim());
                String felfedezo = parts[4].trim();

                elemek.add(new Elem(ev, nev, vegyjel, rendszam, felfedezo));
            }

            System.out.println("A fájl sikeresen beolvasva! (" + elemek.size() + " elem)");

        } catch (IOException e) {
            System.err.println("Hiba a fájl beolvasásakor: " + e.getMessage());
        } catch (NumberFormatException e) {
            System.err.println("Hibás számformátum az egyik sorban: " + e.getMessage());
        }
    }


    public static void keres(String vegyjel) {
        Optional<Elem> talalat = elemek.stream()
                .filter(e -> e.vegyjel.equalsIgnoreCase(vegyjel))
                .findFirst();

        System.out.println("6. feladat: Keresés");
        if (talalat.isPresent()) {
            Elem e = talalat.get();
            System.out.println("Az elem vegyjele: " + e.vegyjel);
            System.out.println("Az elem neve: " + e.nev);
            System.out.println("Rendszáma: " + e.rendszam);
            System.out.println("Felfedezés éve: " + e.ev);
            System.out.println("Felfedező: " + e.felfedezo);
        } else {
            System.out.println("Nincs ilyen elem az adatforrásban!");
        }
    }

    public static void maxIdoszak() {
        List<Integer> evszamok = new ArrayList<>();
        for (Elem e : elemek) {
            if (!e.isOkor()) {
                try {
                    evszamok.add(Integer.parseInt(e.ev));
                } catch (NumberFormatException ignored) {}
            }
        }
        int maxKulonbseg = 0;
        for (int i = 1; i < evszamok.size(); i++) {
            int kulonbseg = evszamok.get(i) - evszamok.get(i - 1);
            if (kulonbseg > maxKulonbseg) {
                maxKulonbseg = kulonbseg;
            }
        }
        System.out.println("7. feladat: " + maxKulonbseg + " év volt a leghosszabb időszak két elem felfedezése között.");
    }

    public static void statisztika() {
        Map<String, Integer> stat = new TreeMap<>();

        for (Elem e : elemek) {
            if (!e.isOkor()) {
                stat.put(e.ev, stat.getOrDefault(e.ev, 0) + 1);
            }
        }

        System.out.println("8. feladat: Statisztika");
        for (Map.Entry<String, Integer> entry : stat.entrySet()) {
            if (entry.getValue() > 3) {
                System.out.println(entry.getKey() + ": " + entry.getValue() + " db");
            }
        }
    }
    public static void main(String[] args) {

        feladat(2);
        feltolt();

        feladat(3);
        System.out.println("3. feladat: Elemek száma: " + elemek.size());

        feladat(4);
        long okori = elemek.stream().filter(Elem::isOkor).count();
        System.out.println("4. feladat: Felfedezések száma az ókorban: " + okori);

        feladat(5);
        Scanner sc = new Scanner(System.in);
        String vegyjel;
        Pattern pattern = Pattern.compile("^[A-Za-z]{1,2}$");
        while (true) {
            System.out.print("5. feladat: Kérek egy vegyjelet: ");
            vegyjel = sc.nextLine().trim();
            if (pattern.matcher(vegyjel).matches()) {
                break;
            } else {
                System.out.println("Hibás input! (1 vagy 2 betű lehet, csak az angol ábécéből)");
            }
        }

        feladat(6);
        keres(vegyjel);

        feladat(7);
        maxIdoszak();

        feladat(8);
        statisztika();
    }
}
