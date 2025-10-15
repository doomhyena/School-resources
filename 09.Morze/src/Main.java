import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.*;

public class Main {

    static class MorzeABC {
        String betu;
        String kod;

        public MorzeABC(String betu, String kod) {
            this.betu = betu;
            this.kod = kod;
        }
    }

    static class Idezet {
        String szerzoKod;
        String idezetKod;

        public Idezet(String szerzoKod, String idezetKod) {
            this.szerzoKod = szerzoKod;
            this.idezetKod = idezetKod;
        }
    }

    static List<MorzeABC> morzeLista = new ArrayList<>();
    static List<Idezet> idezetLista = new ArrayList<>();
    static Map<String, String> morzeToChar = new HashMap<>();
    static Map<String, String> charToMorze = new HashMap<>();

    public static void feladat(int n) {
        System.out.println("\n" + n + ". feladat:");
    }

    public static void feltoltABC() {
        try (BufferedReader br = new BufferedReader(new InputStreamReader(
                new FileInputStream("morzeabc.txt"), StandardCharsets.UTF_8))) {

            br.readLine(); // fejléc
            String line;
            while ((line = br.readLine()) != null) {
                String[] parts = line.split("\t");
                if (parts.length != 2) continue;

                String betu = parts[0].trim();
                String kod = parts[1].trim();

                morzeLista.add(new MorzeABC(betu, kod));
                morzeToChar.put(kod, betu);
                charToMorze.put(betu, kod);
            }
            System.out.println("A fájl sikeresn beolvasva!");
        } catch (IOException e) {
            System.err.println("Hiba a morzeabc.txt beolvasásakor: " + e.getMessage());
        }
    }

    public static void feltoltIdezetek() {
        try (BufferedReader br = new BufferedReader(new InputStreamReader(
                new FileInputStream("morze.txt"), StandardCharsets.UTF_8))) {

            String line;
            while ((line = br.readLine()) != null) {
                String[] parts = line.split(";");
                if (parts.length != 2) continue;

                idezetLista.add(new Idezet(parts[0].trim(), parts[1].trim()));
            }

        } catch (IOException e) {
            System.err.println("Hiba a morze.txt beolvasásakor: " + e.getMessage());
        }
    }

    public static String morze2Szoveg(String morzeSzoveg) {
        StringBuilder sb = new StringBuilder();
        String[] szavak = morzeSzoveg.split(" {7}");
        for (String szo : szavak) {
            String[] betuk = szo.split(" {3}");
            for (String b : betuk) {
                if (morzeToChar.containsKey(b)) {
                    sb.append(morzeToChar.get(b));
                }
            }
            sb.append(" ");
        }
        return sb.toString().trim();
    }

    public static void main(String[] args) {

        feladat(2);
        feltoltABC();

        feladat(3);
        System.out.println("A morze abc " + morzeLista.size() + " db karakter kodjat tartalmazza.");

        feladat(4);
        Scanner sc = new Scanner(System.in);
        System.out.print("Kerek egy karaktert: ");
        String input = sc.nextLine().toUpperCase();

        if (charToMorze.containsKey(input)) {
            System.out.println("A " + input + " karakter morze kodja: " + charToMorze.get(input));
        } else {
            System.out.println("Nem található a kódtárban ilyen karakter!");
        }

        feltoltIdezetek();

        feladat(7);
        String elsoSzerzo = morze2Szoveg(idezetLista.get(0).szerzoKod);
        System.out.println("Az első idézet szerzője: " + elsoSzerzo);

        Idezet max = idezetLista.get(0);
        for (Idezet i : idezetLista) {
            if (morze2Szoveg(i.idezetKod).length() > morze2Szoveg(max.idezetKod).length()) {
                max = i;
            }
        }

        feladat(8);
        System.out.println("A leghosszabb idézet szerzője és az idézet:");
        System.out.println(morze2Szoveg(max.szerzoKod) + ": " + morze2Szoveg(max.idezetKod));

        feladat(9);
        System.out.println("Arisztotelész idézetei:");
        for (Idezet i : idezetLista) {
            String szerzo = morze2Szoveg(i.szerzoKod);
            if (szerzo.contains("ARISZTOTEL")) {
                System.out.println("- " + morze2Szoveg(i.idezetKod));
            }
        }

        try (PrintWriter pw = new PrintWriter("forditas.txt", StandardCharsets.UTF_8)) {
            for (Idezet i : idezetLista) {
                pw.println(morze2Szoveg(i.szerzoKod) + ":" + morze2Szoveg(i.idezetKod));
            }
        } catch (IOException e) {
            System.err.println("Hiba a forditas.txt írásakor: " + e.getMessage());
        }

    }
}
