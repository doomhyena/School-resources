public class Main {
    public static void main(String[] args) {
        // konzolra kiíratás
        System.out.println("Helló Világ!");
        System.out.println("Legyen szép napod!");
        System.out.println("Java-t tanulni jó!");
        System.out.println(3);
        System.out.println(345);
        System.out.println(5000);
        System.out.println(3 + 3);
        System.out.println(2 * 5);
        String nev = "Csontos Kincső";
        System.out.println(nev);
        int eletkor = 20;
        System.out.println(eletkor);
        int szam;
        szam = 15;
        System.out.println(szam);
        int myNum = 5;
        float myFloatNum = 5.99f;
        char myLetter = 'D';
        boolean myBool = true;
        String myText = "Helló";
        String firstName = "Kincső ";
        String lastName = "Csontos";
        String fullName = firstName + lastName;
        System.out.println(fullName);
        int x = 5;
        int y = 6;
        System.out.println(x + y); // 11
        System.out.println("The sum is " + x + y);   //  56
        System.out.println("The sum is " + (x + y)); // 11
        int z = 50;
        System.out.println(x + y + z);
        double asd = 19.99d;
        System.out.println(asd);
        float f1 = 35e3f;
        double d1 = 12E4d;
        System.out.println(f1);
        System.out.println(d1);
        boolean isJavaFun = true;
        boolean isPHPFun = false;
        System.out.println(isJavaFun);
        System.out.println(isPHPFun);
        char myGrade = 'A';
        System.out.println(myGrade);
        System.out.println("---");
        char myVar1 = 65, myVar2 = 66, myVar3 = 67;
        System.out.println(myVar1);
        System.out.println(myVar2);
        System.out.println(myVar3);
        String greeting = "Helló Világ";
        System.out.println(greeting);
        int items = 50;
        float costPerItem = 9.99f;
        float totalCost = items * costPerItem;
        char currency = '$';
        // Print változók
        System.out.println("Tételek száma: " + items);
        System.out.println("Tételek ára: " + costPerItem + currency);
        System.out.println("Teljes költség = " + totalCost + currency);
        /*
         * A nem primitív adattípusokat referenciatípusoknak nevezzük, mert objektumokra hivatkoznak.
         *
         * A primitív és nem primitív adattípusok közötti főbb különbségek a következők:
         *
         * A Java primitív típusai előre definiáltak és beépültek a nyelvbe, míg a nem primitív típusokat a programozó hozza létre (a String kivételével).
         * A nem primitív típusok felhasználhatók metódusok hívására bizonyos műveletek végrehajtásához, míg a primitív típusok nem.
         * Az alapvető típusok kisbetűvel kezdődnek (például int), míg a nem alapvető típusok általában nagybetűvel kezdődnek (például String).
         * Az alapvető típusok mindig tartalmaznak értéket, míg a nem alapvető típusok nullák is lehetnek.
         * A nem alapvető típusok példái a Stringek, a tömbök, az osztályok stb. Ezekről bővebben egy későbbi fejezetben olvashat.
         */
        var myNumber = 5;       // int
        var myDouble = 9.98;    // double
        var myChar = 'D';       // char
        var myBoolean = true;   // boolean
        var myString = "Hello"; // String
        int myInt = 9;
        double myDoub = myInt; // automatikus
        System.out.println(myInt);
        System.out.println(myDoub);

        // Állítsuk be a játék maximális pontszámát 500-ra.
        int maxScore = 500;
        // A felhasználó tényleges pontszáma
        int userScore = 423;
        /* Számítsuk ki a felhasználó pontszámának százalékos arányát a maximálisan elérhető pontszámhoz viszonyítva.
        Konvertáljuk a userScore értéket double típusúra, hogy a osztás pontos legyen. */
        double percentage = (double) userScore / maxScore * 100.0d; // manuális
        System.out.println("A felhasználó százalékos aránya: " + percentage);
        int sum1 = 100 + 50;        // 150 (100 + 50)
        int sum2 = sum1 + 250;      // 400 (150 + 250)
        int sum3 = sum2 + sum2;     // 800 (400 + 400)
        int a = 10;
        int b = 3;
        System.out.println(a + b); // 13
        System.out.println(a - b); // 7
        System.out.println(a * b); // 30
        System.out.println(a / b); // 3
        System.out.println(a % b); // 1
        int c = 5;
        ++c;
        System.out.println(c); // 6
        --c;
        System.out.println(c); // 5
        double d = 10.0d;
        double e = 3.0d;
        System.out.println(d / e); // 3.333...
        int f = 5;
        ++f;
        System.out.println(f); // 6
        --f;
        System.out.println(f); // 5
        int peopleInRoom = 0;

        // 3 ember belép a szobába
        peopleInRoom++;
        peopleInRoom++;
        peopleInRoom++;
        System.out.println(peopleInRoom); // 3
        // 1 ember elhagyja a szobát
        peopleInRoom--;
        System.out.println(peopleInRoom); // 2

        int savings = 100;
        savings += 50; // 50 hozzáadva a megtakarításokhoz
        System.out.println("Teljes megtakarítás: " + savings);

        int age = 18;
        System.out.println(age >= 18); // true, elég idős, hogy szavazzon
        System.out.println(age < 18);  // false, fiatal, hogy szavazzon

        int passwordLength = 5;
        System.out.println(passwordLength >= 8); // false, túl rövid
        System.out.println(passwordLength < 8);  // true, több karakterre van szükség

        boolean isLoggedIn = true;
        boolean isAdmin = false;

        System.out.println("Általános felhasználó-e: " + (isLoggedIn && !isAdmin));
        System.out.println("Hozzáférése van-e: " + (isLoggedIn || isAdmin));
        System.out.println("Nincs bejelentkezve: " + (!isLoggedIn));

        String txt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        System.out.println("A txt karakterlánc hossza: " + txt.length());

        String helloworld = "Hello World";
        System.out.println(helloworld.toUpperCase());   // "HELLO WORLD"
        System.out.println(helloworld.toLowerCase());   // "hello world"

        /*
         *
         *
         *    Kód	Eredmény
         *     \n	Új sor
         *     \t	Tab
         *     \b	"Vissza"
         *     \r	Sorköz
         *     \f	Formátumváltás
         *
         *
         */

        Math.max(5, 10);
        Math.min(5, 10);

        int g = 10;
        int h = 9;
        System.out.println(g > h); // true-t ad vissza, mert 10 nagyobb, mint 9

        int myAge = 20;
        int votingAge = 18;
        System.out.println(myAge >= votingAge);

        /*
         *
         * if (feltétel) {
         *    a feltétel teljesülése esetén végrehajtandó kódblokk
         * }
         *
         * if (feltétel) {
         *    a feltétel teljesülése esetén végrehajtandó kódblokk
         * } else {
         *   a feltétel hamis esetén végrehajtandó kódblokk
         * }
         *
         */

        boolean isRaining = true;

        if (isRaining) {
            System.out.println("Vigyél esernyőt");
        }

        boolean isRainingOrNot = false;

        if (isRainingOrNot) {
            System.out.println("Vigyél esernyőt!");
        } else {
            System.out.println("Ma nem fog esni az eső, nem kell esernyő!");
        }

        int time = 20;

        if (time < 18) {
            System.out.println("Jó napot kívánok.");
        } else {
            System.out.println("Jó estét kívánok.");
        }

        int weather = 2; // 1 = esős, 2 = napos, 3 = felhős

        if (weather == 1) {
            System.out.println("Vigyél esernyőt.");
        } else if (weather == 2) {
            System.out.println("Vegyél fel napszemüveget.");
        } else {
            System.out.println("Nem kell se esernyő, se napszemüveg.");
        }

        int timei = 14;
        if (timei < 10) {
            System.out.println("Jó reggelt.");
        } else if (timei < 18) {
            System.out.println("Jó napot.");
        } else {
            System.out.println("Jó estét.");
        }

        int timeie = 20;
        String result = (timeie < 18) ? "Jó napot." : "Jó estét.";
        System.out.println(result);


        if (a > b || a > c) {
            System.out.println("Legalább egy feltétel teljesül.");
        } else {
            System.out.println("Vagy mégsem.");
        }

        boolean isLoggedInOrNot = true;
        boolean isAdminOrNot = false;
        int securityLevel = 3;

        if (isLoggedInOrNot && (isAdminOrNot || securityLevel <= 2)) {
            System.out.println("Engedély megadva.");
        } else {
            System.out.println("Engedély megtagadva.");
        }

        int doorCode = 1337;

        if (doorCode == 1337) {
            System.out.println("Helyes kód. Az ajtó nyitva van.");
        } else {
            System.out.println("Rossz kód. Az ajtó zárva marad.");
        }

        /*
         *
         * switch(kifejezés) {
         *   case x:
         *       Kód blokk
         *        break;
         *   case y:
         *       Kód blokk
         *       break;
         *   default:
         *      Kód blokk
         * }
         *
         */
        int day = 4;
        switch (day) {
            case 1:
                System.out.println("Hétfő");
                break;
            case 2:
                System.out.println("Kedd");
                break;
            case 3:
                System.out.println("Szerda");
                break;
            case 4:
                System.out.println("Csütörtök");
                break;
            case 5:
                System.out.println("Péntek");
                break;
            case 6:
                System.out.println("Szombat");
                break;
            case 7:
                System.out.println("Vasárnap");
                break;
            default:
                System.out.println("Várjuk a hétvégét");
        }

        int i = 0;

        while (i < 5) {
            System.out.println(i);
            i++;
        }

        while (i < 5) {
            System.out.println("Ez soha nem lesz kiírva.");
        }

        int countdown = 3;

        while (countdown > 0) {
            System.out.println(countdown);
            countdown--;
        }

        System.out.println("Boldog új évet!");

        /*
         *
         * do {
         *  végrehajtandó kódblokk
         * }
         * while (feltétel);
         *
         */

        do {
            System.out.println(i);
            i++;
        }
        while (i < 5);

        do {
            System.out.println("i is " + i);
            i++;
        } while (i < 5);

        int dice = 1;

        while (dice <= 6) {
            if (dice < 6) {
                System.out.println("Nagyobbat dobtál mint 6.");
            } else {
                System.out.println("Kisebbet dobál mint 6.");
            }
            dice = dice + 1;
        }

        /*
        *
        * for (statement 1; statement 2; statement 3) {
        *  // a kód blokk le fog futni
        * }
        *
        */

        for (int j = 0; j < 5; j++) {
            System.out.println(j);
        }

        // Számok összege
        int sum = 0;
        for (int sz = 1; sz <= 5; sz++) {
            sum = sum + sz;
        }
        System.out.println("Az összeg: " + sum);

        // Visszaszámolás

        for (int v = 5; v > 0; v--) {
            System.out.println(v);
        }

        // For ciklus hamis feltétellel

        for (int zs = 10; zs < 5; zs++) {
            System.out.println("Ez soha nem lesz kiírva konzolra");
        }

        // for-each ciklus

        String[] carsi = {"Volvo", "BMW", "Ford", "Mazda"};

        for (String car : carsi) {
            System.out.println(car);
        }

        int[] numbers = {10, 20, 30, 40};

        for (int num : numbers) {
            System.out.println(num);
        }

        // Break and Continue

        for (int as = 0; as < 10; as++) {
            if (as == 4) {
                break;
            }
            System.out.println(i);
        }

        // Break Példa

        int t = 0;
        while (t < 10) {
            System.out.println(t);
            t++;
            if (t == 4) {
                break;
            }
        }

        // Continue Példa

        int u = 0;
        while (u < 10) {
            if (u == 4) {
                u++;
                continue;
            }
            System.out.println(u);
            u++;
        }

        // Real-Life Példa

        int[] num = {3, -1, 7, 0, 9};

        for (int n : num) {
            if (n < 0) {
                continue; // negatív számok kihagyása
            }
            if (n == 0) {
                break; // a loop leállítása, ha nullát talál
            }
            System.out.println(n);
        }

        // Arrays

        String[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
        System.out.println(cars[0]);

        cars[0] = "Opel";
        System.out.println(cars[0]);
        System.out.println(cars.length);

        /*
        *
        *
        * String[] cars = new String[4];
        * cars[0] = "Volvo";
        * cars[1] = "BMW";
        * cars[2] = "Ford";
        * cars[3] = "Mazda";
        * System.out.println(cars[0]);
        *
        *
        * String[] cars = new String[] {"Volvo", "BMW", "Ford", "Mazda"};
        * Mind2 formátum elfogadható
        * String[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
        *
        */

    }
}