import java.io.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.*;
import java.time.LocalDate;
import java.util.*;
import java.util.stream.Collectors;
import java.time.format.DateTimeFormatter;

public class Main {

    static public class KutyaNev {
        int id;
        String nev;

        KutyaNev(int id, String nev) {
            this.id = id;
            this.nev = nev;
        }
    }

    static public class KutyaFajta {
        int id;
        String fajtaHu;
        String fajtaEredeti;

        KutyaFajta(int id, String fajtaHu, String fajtaEredeti) {
            this.id = id;
            this.fajtaHu = fajtaHu;
            this.fajtaEredeti = fajtaEredeti;
        }
    }

    static public class Kutya {
        int vizsgalatId;
        int fajtaId;
        int nevId;
        int eletkor;
        LocalDate datum;

        Kutya(int vizsgalatId, int fajtaId, int nevId, int eletkor, LocalDate datum) {
            this.vizsgalatId = vizsgalatId;
            this.fajtaId = fajtaId;
            this.nevId = nevId;
            this.eletkor = eletkor;
            this.datum = datum;
        }
    }

    static List<KutyaNev> kutyaNevek = new ArrayList<>();
    static List<KutyaFajta> kutyaFajtak = new ArrayList<>();
    static List<Kutya> kutyak = new ArrayList<>();

    static void feladat(int n) {
        System.out.println("\n" + n + ". feladat:");
    }

    static void beolvasNevek() {
        try {
            List<String> sorok = Files.readAllLines(Paths.get("KutyaNevek.csv"), StandardCharsets.UTF_8);
            for (int i = 1; i < sorok.size(); i++) {
                String[] s = sorok.get(i).split(";");
                kutyaNevek.add(new KutyaNev(Integer.parseInt(s[0]), s[1]));
            }
            System.out.println("Kutyanevek beolvasva: " + kutyaNevek.size());
        } catch (IOException e) {
            System.err.println("Hiba a nevek beolvasásakor: " + e.getMessage());
        }
    }

    static void beolvasFajtak() {
        try {
            List<String> sorok = Files.readAllLines(Paths.get("KutyaFajtak.csv"), StandardCharsets.UTF_8);
            for (int i = 1; i < sorok.size(); i++) {
                String[] s = sorok.get(i).split(";");

                if (s.length < 3) {
                    System.err.println("Hibás sor a KutyaFajtak.csv-ben: " + sorok.get(i));
                    continue;
                }

                kutyaFajtak.add(new KutyaFajta(
                        Integer.parseInt(s[0].trim()),
                        s[1].trim(),
                        s[2].trim()
                ));
            }
            System.out.println("Kutyafajták beolvasva: " + kutyaFajtak.size());
        } catch (IOException e) {
            System.err.println("Hiba a fajták beolvasásakor: " + e.getMessage());
        }
    }


    static void beolvasKutyak() {
        try {
            List<String> sorok = Files.readAllLines(Paths.get("Kutyak.csv"), StandardCharsets.UTF_8);
            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy.MM.dd");

            for (int i = 1; i < sorok.size(); i++) {
                String[] s = sorok.get(i).split(";");
                if (s.length < 5) {
                    System.err.println("Hibás sor a Kutyak.csv-ben: " + sorok.get(i));
                    continue;
                }

                int id = Integer.parseInt(s[0].trim());
                int fajta = Integer.parseInt(s[1].trim());
                int nev = Integer.parseInt(s[2].trim());
                int kor = Integer.parseInt(s[3].trim());
                LocalDate datum = LocalDate.parse(s[4].trim(), formatter);

                kutyak.add(new Kutya(id, fajta, nev, kor, datum));
            }
            System.out.println("Kutyák beolvasva: " + kutyak.size());
        } catch (IOException e) {
            System.err.println("Hiba a kutyák beolvasásakor: " + e.getMessage());
        }
    }

    public static void main(String[] args) {
        feladat(2);

        beolvasNevek();
        beolvasFajtak();
        beolvasKutyak();

        feladat(3);
        System.out.println("Kutyanevek száma: " + kutyaNevek.size());

        feladat(6);
        double atlag = kutyak.stream()
                .mapToInt(k -> k.eletkor)
                .average()
                .orElse(0.0);
        System.out.printf("Kutyák átlagéletkora: %.2f%n", atlag);

        feladat(7);
        Kutya legidosebb = Collections.max(kutyak, Comparator.comparingInt(k -> k.eletkor));
        String legidosebbNev = kutyaNevek.stream()
                .filter(n -> n.id == legidosebb.nevId)
                .map(n -> n.nev)
                .findFirst().orElse("ismeretlen");
        String legidosebbFajta = kutyaFajtak.stream()
                .filter(f -> f.id == legidosebb.fajtaId)
                .map(f -> f.fajtaHu)
                .findFirst().orElse("ismeretlen");
        System.out.println("Legidősebb kutya neve és fajtája: " +
                legidosebbNev + ", " + legidosebbFajta);

        feladat(8);
        System.out.println("2018. január 10-én vizsgált kutyák fajtánként:");
        Map<String, Long> kutyak2018 = kutyak.stream()
                .filter(k -> k.datum.equals(LocalDate.of(2018, 1, 10)))
                .collect(Collectors.groupingBy(k -> {
                    return kutyaFajtak.stream()
                            .filter(f -> f.id == k.fajtaId)
                            .map(f -> f.fajtaHu)
                            .findFirst().orElse("ismeretlen");
                }, Collectors.counting()));

        kutyak2018.forEach((fajta, db) ->
                System.out.println(fajta + ": " + db + " kutya"));

        feladat(9);
        Map<LocalDate, Long> napok = kutyak.stream()
                .collect(Collectors.groupingBy(k -> k.datum, Collectors.counting()));
        var maxNap = Collections.max(napok.entrySet(), Map.Entry.comparingByValue());
        System.out.println("Legjobban leterhelt nap: " +
                maxNap.getKey() + ": " + maxNap.getValue() + " kutya");
        feladat(10);
        Map<String, Long> nevStat = kutyak.stream()
                .collect(Collectors.groupingBy(k -> {
                    return kutyaNevek.stream()
                            .filter(n -> n.id == k.nevId)
                            .map(n -> n.nev)
                            .findFirst().orElse("ismeretlen");
                }, Collectors.counting()));
        List<Map.Entry<String, Long>> rendezett = nevStat.entrySet().stream()
                .sorted(Map.Entry.<String, Long>comparingByValue().reversed())
                .toList();
        List<String> sorok = rendezett.stream()
                .map(e -> e.getKey() + ";" + e.getValue())
                .toList();
        try {
            Files.write(Paths.get("nevstatisztika.txt"), sorok, StandardCharsets.UTF_8);
            System.out.println("A 'nevstatisztika.txt' fájl elkészült.");
        } catch (IOException e) {
            System.err.println("Hiba a névstatisztika fájl írásakor: " + e.getMessage());
        }
    }
}
