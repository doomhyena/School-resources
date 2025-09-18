public class Main {

    // ------ M E T Ó D U S O K ------

    // Egy metódus, ami nem kér be semmit, csak kiír egy szöveget.
    static void myMethod() {
        System.out.println("Lefuottam!"); // Kiírja, hogy "Lefuottam!" (igen, elgépelve, de működik)
    }

    // Ez a metódus egy nevet vár (fname), és üdvözli az illetőt.
    static void Names(String fname) {
        System.out.println("Üdv, " + fname + "!"); // Szépen konkatenálja (összefűzi) a stringeket
    }

    // Ez a metódus egy nevet ÉS egy életkort vár, majd kiírja őket együtt.
    static void Datas(String name, int age) {
        System.out.println(name + " " + age + " éves"); // Pl. "Kincső 20 éves"
    }

    // Ez a metódus csak az életkort nézi meg, és kiírja, hogy megveheted-e a játékot vagy sem.
    static void Age(int age) {
        if (age < 18) { // Ha kisebb mint 18
            System.out.println("Nem vwheted meg ezt a játékot!"); // Elgépelve, de ez a tiltás szövege
        } else if (age >= 18) { // Ha 18 vagy annál idősebb
            System.out.println("Megveheted ezt a játékot!"); // Engedélyezi
        }
    }

    // Ez a metódus visszaad egy értéket: 5 + x. Tehát ha x = 3, akkor visszaadja a 8-at.
    static int Number(int x) {
        return 5 + x;
    }

    // Ez meg két számot ad össze és visszaadja az eredményt.
    static int NumberTwo(int x, int y) {
        return x + y;
    }

    // Ez a main metódus, itt indul a program.
    public static void main(String[] args) {

        // ------ V Á L T O Z Ó K ------

        // ez egy egy soros komment
        /*
         *
         * Ez
         * egy
         * több
         * soros
         * komment
         *
         */

        int dek; // deklarálás
        dek = 1; // inicializálás
        int mynum = 13; // egész számot tároló válotozó
        String mystring = "Ez egy szöveg"; // szöveget tároló változó
        boolean myboolean = true; // eldöntendő tároló változó -> értéke lehet true vagy false (MÁS NEM!)
        char mychar = 'A'; // betűt tároló változó
        float myfloet = 13.5f; // nem egész számot tároló változó
        double mydouble = 15.2; // nem egész számot tároló változó
        System.out.println(dek); // kiírja a dek változót
        System.out.println(mynum); // kiírja a mynum változót
        System.out.println(mystring); // kiírja a mystring változót
        System.out.println(myboolean); // kiírja a myboolean változót
        System.out.println(mychar); // kiírja a mychar változót
        System.out.println(myfloet); // kiírja a myfloat változót
        System.out.println(mydouble); // kiírja a mydouble változót
        System.out.println(1); // szám kiíratása közvetlenül konzolra
        System.out.println("Ez egy másik szöveg"); // szöveg kiíratása közvetlenül konzolra
        System.out.println(false); // boolean kiíratása közvetlenül konzolra
        System.out.println('B'); // char kiíratása közvetlenül konzolra
        System.out.println(1.5f); // float kiíratása közvetlenül konzolra
        System.out.println(15.3); // double kiíratása közvetlenül konzolra

        // ------ I F - E L S E ------

        /*
         * if (feltétel ha megvalósul) {
         *      ez fog történik
         * } else if (másik feltétel ha megvalósul) {
         *      más fog történni ha ez a feltétel megvalósul
         * } else {
         *      ez az ág fog megtörténni ha az előző két feltétel nem valósult meg
         * }
         */

        // matematikai feltételek

        int a = 5;
        int b = 6;

        if (a < b) { // ha 'b' nagyobb mint 'a'
            System.out.println("'b' nagyobb mint 'a'.");
        } else if (a <= b) { // ha 'b' egyenlő VAGY nagyobb mint 'a'
            System.out.println("'b' egyenlő vagy nagyobb mint 'a'.");
        } else if (a > b) { // ha 'b' kisebb mint 'a'
            System.out.println("'b' kisebb mint 'a'.");
        } else if (a == b) { // ha 'b' egyenlő VAGY kisebb mint 'a'
            System.out.println("'b' egyenlő vagy kisebb mint 'a'.");
        } else if (a != b) { // 'a' és 'b' nem egyenlő
            System.out.println("'a' és 'b' nem egyenlő");
        }

        // ------ T Ö M B Ö K ------

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

        // ------ Ö S S Z E G Z É S  T É T E L E ------

        // Összegzés - Egy tömb összes elenének összeadása
        int[] tombOsszeg = {3, 8, 2, 4, 5, 1, 6};
        int osszeg = 0;

        for (int i = 0; i < tombOsszeg.length; i++) {
            osszeg += tombOsszeg[i]; // Az aktuális elem hozzáadása az összeshez
        }

        System.out.println(osszeg); // Az összeg kiíratása

        // ------ M E T Ó D U S O K ------

        // Lefuttatjuk háromszor a myMethod-ot, szóval háromszor fog kiíródni: "Lefuottam!"
        myMethod();
        myMethod();
        myMethod();

        // Három különböző névvel meghívjuk a Names metódust
        Names("Béla");
        Names("Bence");
        Names("Jóska");

        // Egy névvel és korral meghívjuk a Datas-t
        Datas("Kincső", 20);

        // Különböző korokat adunk át az Age metódusnak, hogy megnézzük, mit ír ki
        Age(15); // Kevesebb mint 18 -> tiltás
        Age(18); // Pont 18 -> engedélyezés
        Age(20); // Nagyobb -> engedélyezés

        // Meghívjuk a Number-t 3-mal, visszaadja 5 + 3 = 8, amit kiíratunk
        System.out.println(Number(3));

        // Meghívjuk a NumberTwo-t 5 és 3 értékekkel -> 8-at ad vissza
        System.out.println(NumberTwo(5, 3));

        // Most ugyanaz, mint fent, csak az eredményt eltároljuk egy változóban
        int z = NumberTwo(5, 3); // z = 8
        System.out.println(z); // Kiíratjuk z-t, tehát 8
        
    }
}