public class Main {
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
