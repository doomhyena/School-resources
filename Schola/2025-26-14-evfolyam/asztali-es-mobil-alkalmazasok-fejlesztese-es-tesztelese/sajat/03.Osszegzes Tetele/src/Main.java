public class Main {
    public static void main(String[] args) {
        // Összegzés - Egy tömb összes elenének összeadása
        int[] tombOsszeg = {3, 8, 2, 4, 5, 1, 6};
        int osszeg = 0;

        for (int i = 0; i < tombOsszeg.length; i++) {
            osszeg += tombOsszeg[i]; // Az aktuális elem hozzáadása az összeshez
        }

        System.out.println(osszeg); // Az összeg kiíratása
    }
}