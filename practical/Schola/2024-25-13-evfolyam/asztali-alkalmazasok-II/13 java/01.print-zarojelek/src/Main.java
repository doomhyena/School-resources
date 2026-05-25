//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
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
    }
}