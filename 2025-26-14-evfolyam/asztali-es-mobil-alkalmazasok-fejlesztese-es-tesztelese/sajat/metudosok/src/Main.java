public class Main {
    static void myMethod() {
        System.out.println("Lefutottam%");
    }
    static void Names(String names) {
        System.out.println(names + " a neve.");
    }
    static void Person(String fname, int age) {
        System.out.println(fname + " is " + age);
    }
    // Hozz létre egy checkAge() metódust egy age nevű egész típusú változóval.
    static void checkAge(int age) {

        // Ha a kor 18 év alatti, írja ki a "hozzáférés megtagadva” feliratot.
        if (age < 18) {
            System.out.println("Hozzáférés megtagadva - Nem vagy elég idős!");

        // Ha az életkor 18 évnél nagyobb vagy azzal egyenlő, írja ki a "hozzáférés engedélyezve” feliratot.
        } else {
            System.out.println("Engedély megadva - Elég idős vagy!");
        }

    }
    static int Matek(int x) {
        return 5 + x;
    }
    static int plusMethodInt(int x, int y) {
        return x + y;
    }

    static double plusMethodDouble(double x, double y) {
        return x + y;
    }
    static int plusMethod(int x, int y) {
        return x + y;
    }

    static double plusMethod(double x, double y) {
        return x + y;
    }
    public static int sum(int k) {
        if (k > 0) {
            return k + sum(k - 1);
        } else {
            return 0;
        }
    }
    public static int sum(int start, int end) {
        if (end > start) {
            return end + sum(start, end - 1);
        } else {
            return end;
        }
    }

    public static void main(String[] args) {
        /*
        *
        * A metódus egy kódblokk, amely csak akkor fut, ha meghívják.
        * A metódusba adatokat, úgynevezett paramétereket lehet átadni.
        * A metódusokat bizonyos műveletek végrehajtására használják, és funkcióknak is nevezik őket.
        * Miért érdemes metódusokat használni? A kód újrafelhasználása érdekében: a kódot egyszer kell megírni, és többször is felhasználni lehet.
        * A metódust egy osztályon belül kell deklarálni.
        * A metódus nevével, majd zárójelekkel () kell megadni.
        * A Java néhány előre definiált metódust biztosít, például a System.out.println()-t,
        * de saját metódusokat is létrehozhat bizonyos műveletek végrehajtásához:
        *
        */
        myMethod();
        Names("Aki");
        Names("Dia");
        Names("Kincső");
        Person("Liam", 5);
        Person("Jenny", 8);
        Person("Anja", 31);
        checkAge(20); // Hívja meg a checkAge metódust, és adja meg a 20 éves kort.
        System.out.println(Matek(3));
        int myNum1 = plusMethodInt(8, 5);
        double myNum2 = plusMethodDouble(4.3, 6.26);
        System.out.println("int: " + myNum1);
        System.out.println("double: " + myNum2);
        int myNumb1 = plusMethod(8, 5);
        double myNumb2 = plusMethod(4.3, 6.26);
        System.out.println("int: " + myNumb1);
        System.out.println("double: " + myNumb2);
        int result = sum(10);
        System.out.println(result);
        int resulte = sum(5, 10);
        System.out.println(resulte);
    }
}