import java.nio.file.*;
import java.io.*;
import java.time.LocalDate;
import java.time.format.DateTimeParseException;
import java.util.*;
import java.util.stream.*;

public class Main {

    static List<Match> matches = new ArrayList<>();

    public static void feladat(int n) {
        System.out.println(n + ". feladat:");
    }

public static void feltolt() {
    String filename = "balkezesek.csv";
    Path path = Paths.get(filename);
    System.out.println("Fájl helye: " + path.toAbsolutePath());

    try (BufferedReader br = new BufferedReader(
            new InputStreamReader(new FileInputStream(filename), StandardCharsets.UTF_8))) {

        br.readLine(); 
        String line;

        while ((line = br.readLine()) != null) {
            if (line.trim().isEmpty()) continue;

            String[] parts = line.split(";");
            if (parts.length < 5) {
                System.err.println("Hibás sor, kihagyva: " + line);
                continue;
            }

            String name = parts[0].trim();
            LocalDate first = LocalDate.parse(parts[1].trim());
            LocalDate last = LocalDate.parse(parts[2].trim());
            int weight = Integer.parseInt(parts[3].trim());
            int height = Integer.parseInt(parts[4].trim());

            players.add(new Player(name, first, last, weight, height));
        }

        System.out.println("A fájl sikeresen beolvasva. (" + players.size() + " sor)");

    } catch (IOException e) {
        System.out.println("Hiba a fájl beolvasásakor!");
    } catch (Exception e) {
        System.out.println("Hiba az adatok feldolgozásakor: " + e.getMessage());
    }
}

    public static void main(String[] args) {

        feladat(2);
        feltolt();

        if (matches.isEmpty()) {
            System.out.println("Nincs adat, a program leáll.");
            return;
        }

        feladat(3);
        String teamToCheck = "Real Madrid";
        long homeCount = matches.stream().filter(m -> m.home.equalsIgnoreCase(teamToCheck)).count();
        long awayCount = matches.stream().filter(m -> m.away.equalsIgnoreCase(teamToCheck)).count();
        System.out.println(teamToCheck + " - Hazai: " + homeCount + ", Idegen: " + awayCount);

        feladat(4);
        boolean anyDraw = matches.stream().anyMatch(Match::isDraw);
        System.out.println("Volt döntetlen? " + (anyDraw ? "igen" : "nem"));

        feladat(5);
        Set<String> teamNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
        matches.forEach(m -> { teamNames.add(m.home); teamNames.add(m.away); });

        Optional<String> barcaName = teamNames.stream()
                .filter(n -> n.toLowerCase().contains("barcelona"))
                .findFirst();
        System.out.println("Barcelonai csapat neve: " + barcaName.orElse("Nem található"));

        feladat(6);
        LocalDate queryDate = LocalDate.of(2004, 11, 21);
        List<Match> matchesOnDate = matches.stream()
                .filter(m -> queryDate.equals(m.date))
                .collect(Collectors.toList());

        System.out.println(queryDate + " - mérkőzések száma: " + matchesOnDate.size());
        matchesOnDate.forEach(m -> System.out.println("   " + m.home + " " + m.homePoints + " : " + m.awayPoints + " " + m.away));

        feladat(7);
        Map<String, Long> venueCount = matches.stream()
                .collect(Collectors.groupingBy(m -> m.venue, Collectors.counting()));

        Map<String, Long> bigVenues = venueCount.entrySet().stream()
                .filter(e -> e.getValue() > 20)
                .sorted(Map.Entry.<String, Long>comparingByValue(Comparator.reverseOrder()))
                .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue,
                        (a,b)->a, LinkedHashMap::new));

        if (bigVenues.isEmpty()) {
            System.out.println("Nincs olyan stadion, amely 20-nál több meccset rendezett.");
        } else {
            for (Map.Entry<String, Long> e : bigVenues.entrySet()) {
                System.out.println(e.getKey() + ": " + e.getValue());
            }
        }
    }
}
