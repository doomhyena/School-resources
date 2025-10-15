import java.io.*;
import java.nio.charset.StandardCharsets;
import java.text.DecimalFormat;
import java.util.*;

public class Main {

    static LinkedHashMap<String, Language> languages = new LinkedHashMap<>();

    public static void feladat(int n) {
        System.out.println("\n" + n + ". feladat:");
    }

    private static void readCounts(String filename, boolean isSuccessful) {
        try (BufferedReader br = new BufferedReader(new InputStreamReader(
                new FileInputStream(filename), StandardCharsets.UTF_8))) {

            String header = br.readLine();
            String line;
            while ((line = br.readLine()) != null) {
                if (line.trim().isEmpty()) continue;
                String[] parts = line.split(";");
                if (parts.length < 10) {
                    continue;
                }
                String langName = parts[0].trim();
                Language lang = languages.get(langName);
                if (lang == null) {
                    lang = new Language(langName);
                    languages.put(langName, lang);
                }
                for (int i = 0; i < 9; i++) {
                    String numStr = parts[i+1].trim();
                    int val = 0;
                    if (!numStr.isEmpty()) {
                        try { val = Integer.parseInt(numStr); } catch (NumberFormatException e) { val = 0; }
                    }
                    if (isSuccessful) lang.successful[i] = val;
                    else lang.unsuccessful[i] = val;
                }
            }

        } catch (FileNotFoundException e) {
            System.err.println("Nem található a fájl: " + filename);
            System.exit(1);
        } catch (IOException e) {
            System.err.println("Hiba a beolvasás során: " + e.getMessage());
            System.exit(1);
        }
    }

    private static void writeSummary(String outFile) {
        try (BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(
                new FileOutputStream(outFile), StandardCharsets.UTF_8))) {

            DecimalFormat df = new DecimalFormat("0.00");
            for (Language lang : languages.values()) {
                int total = lang.totalAll();
                double successRatio = 0.0;
                int succ = lang.totalSuccessful();
                if (total > 0) successRatio = (100.0 * succ) / total;
                String line = String.format("%s;%d;%s%%", lang.name, total, df.format(successRatio));
                bw.write(line);
                bw.newLine();
            }

        } catch (IOException e) {
            System.err.println("Hiba az osszesites.csv írásakor: " + e.getMessage());
        }
    }

    public static void main(String[] args) {

        feladat(1);
        readCounts("sikeres.csv", true);
        readCounts("sikertelen.csv", false);

        feladat(2);
        List<Language> sortedByPopularity = new ArrayList<>(languages.values());
        sortedByPopularity.sort((a,b) -> Integer.compare(b.totalAll(), a.totalAll())); // csökkenő
        System.out.println("A legnépszerűbb nyelvek:");
        for (int i = 0; i < Math.min(3, sortedByPopularity.size()); i++) {
            System.out.println(sortedByPopularity.get(i).name);
        }


        feladat(3);
        Scanner sc = new Scanner(System.in);
        int year = -1;
        while (true) {
            System.out.print("Kérek egy évszámot (2009-2017): ");
            String line = sc.nextLine().trim();
            try {
                year = Integer.parseInt(line);
                if (2009 <= year && year <= 2017) break;
                else System.out.println("Hibás év; kérek egy 2009 és 2017 közötti évszámot!");
            } catch (NumberFormatException e) {
                System.out.println("Hibás év; kérek egy 2009 és 2017 közötti évszámot!");
            }
        }
        System.out.println("Vizsgálando év: " + year);

        int idx = year - 2009;

        feladat(4);
        String worstLang = null;
        double worstRatio = -1.0;
        for (Language lang : languages.values()) {
            int fail = lang.unsuccessful[idx];
            int succ = lang.successful[idx];
            int total = fail + succ;
            if (total == 0) continue;
            double ratio = (100.0 * fail) / total;
            if (ratio > worstRatio) {
                worstRatio = ratio;
                worstLang = lang.name;
            }
        }
        if (worstLang != null) {
            System.out.printf("%d-ben %s nyelvből a sikertelen vizsgák aránya %.2f%%%n", year, worstLang, worstRatio);
        } else {
            System.out.println("Nincs elegendő adat az évben a kiszámításhoz.");
        }

        feladat(5);
        List<String> noCandidates = new ArrayList<>();
        for (Language lang : languages.values()) {
            int total = lang.successful[idx] + lang.unsuccessful[idx];
            if (total == 0) noCandidates.add(lang.name);
        }
        if (noCandidates.isEmpty()) {
            System.out.println("Minden nyelvből volt vizsgázó");
        } else {
            for (String s : noCandidates) System.out.println(s);
        }

        feladat(6);
        writeSummary("osszesites.csv");
        System.out.println("Kész. osszesites.csv létrehozva.");
    }
}
