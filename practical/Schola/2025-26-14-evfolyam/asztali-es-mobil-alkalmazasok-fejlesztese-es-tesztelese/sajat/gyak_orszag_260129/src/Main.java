import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static List<Country> loadFromFile(String fileName) throws IOException {

        List<Country> countries = new ArrayList<>();

        try (BufferedReader br = new BufferedReader(
                new InputStreamReader(new FileInputStream(fileName), StandardCharsets.UTF_8))) {

            String name;
            while ((name = br.readLine()) != null) {
                String popLine = br.readLine();
                String contLine = br.readLine();
                if (popLine == null || contLine == null) {
                    break;
                }

                int population = Integer.parseInt(popLine.trim());
                String continent = contLine.trim();

                countries.add(new Country(name.trim(), population, continent));
            }
        }
        return countries;
    }

    public static void saveEuropeans(List<Country> countries, String fileName) throws IOException {
        try (BufferedWriter bw = new BufferedWriter(
                new OutputStreamWriter(new FileOutputStream(fileName), StandardCharsets.UTF_8))) {
            for (Country c : countries) {
                if (c.getContinent().equalsIgnoreCase("Európa")) {
                    bw.write(c.getName());
                    bw.newLine();
                    bw.write(Integer.toString(c.getPopulation()));
                    bw.newLine();
                    bw.write(c.getContinent());
                    bw.newLine();
                }
            }
        }
    }

    public static void main(String[] args) {

    }
}
