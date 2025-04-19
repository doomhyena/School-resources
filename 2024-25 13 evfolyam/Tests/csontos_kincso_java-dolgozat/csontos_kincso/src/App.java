import java.util.ArrayList;
import java.util.Random;

public class App {
    public static void main(String[] args) {
        ArrayList<Sportolo> sportolok = new ArrayList<>();
        feltolt(sportolok);

        for (Sportolo sportolo : sportolok) {
            System.out.println(sportolo);
        }

        ossz(sportolok);
        jan(sportolok);
    }

    public static void feltolt(ArrayList<Sportolo> sportolok) {
        Random random = new Random();
        for (int i = 1; i <= 100; i++) {
            String name = "Név" + i;
            int january = random.nextInt(600);
            int february = random.nextInt(700);
            sportolok.add(new Sportolo(name, january, february));
        }
    }

    public static void ossz(ArrayList<Sportolo> sportolok) {
        for (Sportolo sportolo : sportolok) {
            int total = sportolo.getJanuary() + sportolo.getFebruary();
            System.out.println(sportolo.getName() + " összesen " + total + " km-t tett meg.");
        }
    }

    public static void jan(ArrayList<Sportolo> sportolok) {
        Sportolo maxSportolo = sportolok.get(0);
        for (Sportolo sportolo : sportolok) {
            if (sportolo.getJanuary() > maxSportolo.getJanuary()) {
                maxSportolo = sportolo;
            }
        }
        System.out.println("A legtöbb km-t januárban " + maxSportolo.getName() + " tette meg: " + maxSportolo.getJanuary() + " km.");
    }
}

class Sportolo {
    private String name;
    private int january;
    private int february;

    public Sportolo(String name, int january, int february) {
        this.name = name;
        this.january = january;
        this.february = february;
    }

    public String getName() {
        return name;
    }

    public int getJanuary() {
        return january;
    }

    public int getFebruary() {
        return february;
    }

    @Override
    public String toString() {
        return "Sportolo{name='" + name + "', january=" + january + ", february=" + february + "}";
    }
}