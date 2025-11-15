import java.io.FileWriter;
import java.io.IOException;
import java.util.Random;

public class Main {

    private static void kiir() {
        try {
            FileWriter fw = new FileWriter("proba.txt");
            fw.write("Csontos Kincső");
            fw.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static void main(String[] args) {
        double a = Math.E;
        int b = new Random().nextInt(0, 1000);
        String sz = "Lajos";

        System.out.printf("Valós szám: %f \nEgész szám: %d \nSzöveg: %s \n2 tizedesre kerekített valós szám: %.2f\n", a, b, sz, a);

        // -------------------- F Á J L B A  K I Í R Á S --------------------
        kiir();
    }
}