public class Main {
    public static void main(String[] args) {

        // Egy tömb deklarálása, de még nincs benne érték
        String[] car;

        // Egy tömb létrehozása, ami 4 autómárkát tartalmaz
        String[] cars = {"Volvo", "BMW", "Ford", "Mazda"};

        // Egész számokat tartalmazó tömb
        int[] myNum = {10, 20, 30, 40};

        // A tömb első elemének kiírása (0. index = "Volvo")
        System.out.println(cars[0]); // A tömb első elemét fogja kiírni: "Volvo"

        // A tömb első elemét átírjuk "Opel"-re
        cars[0] = "Opel";

        // Kiírja a tömb hosszát (azaz hány elem van benne)
        System.out.println(cars.length); // 4

        // Hagyományos for ciklussal végigmegyünk a cars tömb minden elemén
        for (int i = 0; i < cars.length; i++) {
            System.out.println(cars[i]); // Kiírja az aktuális autómárkát
        }

        /*
         * Enhanced for loop (for-each)
         * Szintaktika: for (típus változó : tömb) {...}
         * Minden tömbelemet bejár, rövidebb és tisztább, ha nem kell index
         */
        for (String i : cars) {
            System.out.println(i); // Kiírja az összes autómárkát
        }

        // Új tömb életkorokkal
        int ages[] = {20, 22, 18, 35, 48, 26, 87, 70};

        float avg, sum = 0;
        int length = ages.length; // Elmentjük a tömb hosszát külön változóba

        // Végigmegyünk az ages tömbön, és összeadjuk az életkorokat
        for (int age : ages) {
            sum += age;
        }

        // Átlag számítása (összeg / elemszám)
        avg = sum / length;

        // Az átlag kiírása
        System.out.println("Az átlag életkor: " + avg);

        // Inicializáljuk a legalacsonyabb életkort az első elemmel
        int lowestAges = ages[0];

        // Végigmegyünk a tömbön, és megkeressük a legkisebb értéket
        for (int age : ages) {
            if (lowestAges > age) {
                lowestAges = age; // Ha találunk kisebbet, elmentjük
            }
        }

        // Kiírjuk a legkisebb életkort
        System.out.println("A legalacsonyabb életkor a tömbben: " + lowestAges);

        // Kétdimenziós tömb létrehozása
        int[][] myNumbers = {
                {1, 2, 3, 4},    // Első sor (0. index)
                {5, 6, 7, 8}     // Második sor (1. index)
        };

        // Kiírjuk a második sor harmadik elemét (1. sor, 2. oszlop = 7)
        System.out.println(myNumbers[1][2]);

        // Módosítjuk az előző elemet: 7 → 9
        myNumbers[1][2] = 9;

        // Újra kiírjuk, most már 9 lesz
        System.out.println(myNumbers[1][2]);

        // Hagyományos for ciklussal végigmegyünk a kétdimenziós tömbön
        for (int i = 0; i < myNumbers.length; ++i) { // Soronként
            for (int j = 0; j < myNumbers[i].length; ++j) { // Oszloponként
                System.out.println(myNumbers[i][j]); // Kiírjuk az elemeket sor/oszlop szerint
            }
        }

        // For-each ciklus kétdimenziós tömbhöz (sor → elem)
        for (int[] row : myNumbers) {
            for (int i : row) {
                System.out.println(i); // Kiírja az összes számot
            }
        }
    }
}
