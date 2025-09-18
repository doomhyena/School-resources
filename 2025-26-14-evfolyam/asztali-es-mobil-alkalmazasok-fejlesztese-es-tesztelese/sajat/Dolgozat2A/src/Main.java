// Behívunk mindent is -> aka a randomot és a scanner-t most
import java.util.*;

public class Main {
    public static void main(String[] args) {
        Random rand = new Random(); // random definiálása
        Scanner sc = new Scanner(System.in); // scanner definiálása

        // 1. feladat
        int n = rand.nextInt(6) + 5; // 5–10 közötti hossz
        int[] tomb = new int[n];
        for (int i = 0; i < n; i++) {
            tomb[i] = rand.nextInt(13) + 5; // 5–17 közötti számok
        }

        // a.
        int[] rendezett = tomb.clone();
        Arrays.sort(rendezett);

        // b.
        int osszeg = 0;
        for (int x : tomb) {
            if (x % 2 == 0 && x < 10) {
                osszeg += x;
            }
        }
        System.out.println("Páros, 10-nél kisebb számok összege: " + osszeg);
        // c.
        Integer legkisebbParatlan = null;
        for (int x : tomb) {
            if (x % 2 == 1) {
                if (legkisebbParatlan == null || x < legkisebbParatlan) {
                    legkisebbParatlan = x;
                }
            }
        }
        if (legkisebbParatlan != null) {
            System.out.println("Legkisebb páratlan elem: " + legkisebbParatlan);
        } else {
            System.out.println("Nincs páratlan elem a tömbben.");
        }

        System.out.println("\n--- Felhasználói bevitel feladatok ---");

        // 1. Kérjen be számokat (0 végjelig), majd írja ki hány darabot írtunk be
        List<Integer> szamok = new ArrayList<>();
        while (true) {
            System.out.print("Adj meg egy számot (0 = vége): ");
            int szam = sc.nextInt();
            if (szam == 0) break;
            szamok.add(szam);
        }
        System.out.println("Beírt számok darabszáma: " + szamok.size());

        // 2. Hányadik beadásra adtunk 10 és 20 közötti számot
        int szamlalo = 0;
        Integer talalat = null;
        while (true) {
            System.out.print("Adj meg egy számot (0 = vége): ");
            int szam = sc.nextInt();
            if (szam == 0) break;
            szamlalo++;
            if (szam >= 10 && szam <= 20 && talalat == null) {
                talalat = szamlalo;
            }
        }
        if (talalat != null) {
            System.out.println("Az első 10–20 közötti szám a(z) " + talalat + ". beadásnál volt.");
        } else {
            System.out.println("Nem adtál meg 10–20 közötti számot.");
        }

        // 3. Átlag számítása
        List<Integer> szamok2 = new ArrayList<>();
        while (true) {
            System.out.print("Adj meg egy számot (0 = vége): ");
            int szam = sc.nextInt();
            if (szam == 0) break;
            szamok2.add(szam);
        }
        if (!szamok2.isEmpty()) {
            double atlag = szamok2.stream().mapToInt(Integer::intValue).average().orElse(0);
            System.out.println("A számok átlaga: " + atlag);
        } else {
            System.out.println("Nem adtál meg számokat.");
        }

        sc.close();
    }
}
