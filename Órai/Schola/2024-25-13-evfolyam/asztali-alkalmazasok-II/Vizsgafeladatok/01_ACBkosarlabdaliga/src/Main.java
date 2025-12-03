import java.io.File;
import java.nio.channels.MembershipKey;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    static ArrayList<Merkozes> merkozesek = new ArrayList<>();

    public static void main(String[] args) {
        feltolt();
        feladat3();
        System.out.println(feladat4());
        System.out.println(feladat5());
    }

    private static void feltolt() {
        File f = new File("eredmenyek.csv");
        try {
            Scanner be = new Scanner(f, "ISO-8859-2");
            be.nextLine();
            String sor;
            String[] adatok;

            while (be.hasNextLine()) {
                sor = be.nextLine();
                // System.out.println(sor);
                // System.out.println("--------");
                adatok = sor.split(";");

                merkozesek.add(
                        new Merkozes(
                                adatok[0],
                                adatok[1],
                                Integer.parseInt(adatok[2]),
                                Integer.parseInt(adatok[3]),
                                adatok[4],
                                adatok[5]
                        )
                );
            }
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    private static void feladat3() {
        System.out.println("-- 3. feladat --");
        int hazai = 0;
        int vendeg = 0;

        for (Merkozes n : merkozesek) {
            if (n.hazai.contains("Real Madrid")) {
                hazai++;
            } else if (n.idegen.contains("Real Madrid")) {
                vendeg++;
            }
        }
        System.out.println("Hazai szereplés: " + hazai);
        System.out.println("Vendég szereplés: " + vendeg);
    }

    private static String feladat4() {
        System.out.println("-- 4.feladat --");

        for (Merkozes n : merkozesek) {
            if (n.hazai_pont == n.idegen_pont) {
                return "Volt döntetlen? Igen.";
            }
        }
        return "Volt döntetlen? Nem.";
    }
    private static String feladat5() {
        System.out.println("-- 5.feladat --");

        for (Merkozes n : merkozesek) {
            if(n.hazai.contains("Barcelona")) {
                return n.hazai;
            }
        }
        return "Nincs ilyen csapat!";
    }
}