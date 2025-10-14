import java.nio.file.*;
import java.io.*;
import java.time.LocalDate;
import java.util.*;
import java.text.DecimalFormat;
import java.nio.charset.StandardCharsets;

public class Main {

    static List<Player> players = new ArrayList<>();

    public static void feladat(int n) {
        System.out.println("\n" + n + ". feladat:");
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


    private static int bekertEv() {
        Scanner sc = new Scanner(System.in);
        int year = -1;
        while (true) {
            System.out.print("Kérek egy évszámot (1990-1999): ");
            String line = sc.nextLine().trim();
            try {
                year = Integer.parseInt(line);
                if (1990 <= year && year <= 1999) break;
                else {
                    System.out.println("Hibás adat, kérek egy 1990 és 1999 közötti évszámot!");
                }
            } catch (NumberFormatException e) {
                System.out.println("Hibás adat, kérek egy 1990 és 1999 közötti évszámot!");
            }
        }
        return year;
    }

    public static void main(String[] args) {

        feladat(2);
        feltolt();

        feladat(3);
        System.out.println(players.size());

        feladat(4);
        DecimalFormat oneDecimal = new DecimalFormat("0.0");
        players.stream()
                .filter(p -> p.lastDate != null && p.lastDate.getYear() == 1999 && p.lastDate.getMonthValue() == 10)
                .forEach(p -> System.out.println(p.name + ": " + oneDecimal.format(p.heightCm()) + " cm"));

        feladat(5);
        int year = bekertEv();

        feladat(6);
        DecimalFormat twoDecimal = new DecimalFormat("0.00");
        List<Player> playedThatYear = new ArrayList<>();
        for (Player p : players) {
            if (p.playedInYear(year)) playedThatYear.add(p);
        }

        if (playedThatYear.isEmpty()) {
            System.out.println("Nincsenek játékosok az adott évre (" + year + ").");
        } else {
            double avg = playedThatYear.stream().mapToDouble(p -> p.weight).average().orElse(0.0);
            System.out.println("Átlag súly: " + twoDecimal.format(avg) + " font");
        }
    }
}
