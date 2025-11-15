import java.util.*;
import java.io.*;

public class Main {
    public static void feladat(int n) {
        System.out.println(n + ".feladat: ");
    }
    public static void main(String[] args) {

        feladat(3);
        List<Film> filmLista = new ArrayList<>();
        try (BufferedReader br = new BufferedReader(new FileReader("movies.csv"))) {
            br.readLine();
            String sor;

            while ((sor = br.readLine()) != null) {
                String[] adat = sor.split(",");
                String name = adat[0];
                String franchise = adat[1];
                int year = Integer.parseInt(adat[2]);
                float rating = Float.parseFloat(adat[3]);
                Film film = new Film(name, franchise, year, rating);
                filmLista.add(film);
            }
        } catch (FileNotFoundException e) {
            System.out.println("A fájl nem található: " + e);
        } catch (IOException e) {
            System.out.println("Hiba történt a fájl olvasása közben: " + e);
        }

        feladat(4);
        System.out.println("Az MCU-ban összesen " + filmLista.size() + " készült.");

        feladat(5);
        Film maxRatingFilm = filmLista.get(0);
        for (Film film : filmLista) {
            if (film.getRating() > maxRatingFilm.getRating()) {
                maxRatingFilm = film;
            }
        }
        System.out.println("A legnagyobb IMDB pontszámmal rendelkező film: " + maxRatingFilm.getName());

        feladat(6);
        Map<String, Integer> franchiseMap = new HashMap<>();
        for (Film film : filmLista) {
            if (franchiseMap.containsKey(film.getFranchise())) {
                franchiseMap.put(film.getFranchise(), franchiseMap.get(film.getFranchise()) + 1);
            } else {
                franchiseMap.put(film.getFranchise(), 1);
            }
        }
        for (Map.Entry<String, Integer> entry : franchiseMap.entrySet()) {
            System.out.println(entry.getKey() + ": " + entry.getValue());
        }

        feladat(7);
        try (BufferedWriter bw = new BufferedWriter(new FileWriter("filmek.txt"))) {
            for (Film film : filmLista) {
                bw.write(film.getName() + ", " + film.getYear() + "\n");
            }
        } catch (IOException e) {
            System.out.println("Hiba történt a fájl írása közben: " + e);
        }
    }
}