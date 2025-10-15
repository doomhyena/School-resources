public class Elem {
    String ev;
    String nev;
    String vegyjel;
    int rendszam;
    String felfedezo;

    public Elem(String ev, String nev, String vegyjel, int rendszam, String felfedezo) {
        this.ev = ev;
        this.nev = nev;
        this.vegyjel = vegyjel;
        this.rendszam = rendszam;
        this.felfedezo = felfedezo;
    }

    public boolean isOkor() {
        return ev.equalsIgnoreCase("Ókor") || ev.equalsIgnoreCase("Okor");
    }
}