public class Main {
    public static void main(String[] args) {
        alkalmazott a;

        a = new alkalmazott();

        a.nev = "Kovács János";
        a.fizetes = 50000;
        a.fizetesEmel(6300);

        System.out.println(a.nev + " " + a.fizetes);
    }
}