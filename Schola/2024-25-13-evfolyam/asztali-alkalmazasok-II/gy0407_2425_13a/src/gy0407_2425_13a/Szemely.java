package gy0407_2425_13a;

public class Szemely {
    String nev;
    int kor;

    public Szemely(String nev, int kor) {
        this.nev = nev;
        this.kor = kor;
    }

    @Override
    public String toString() {
        return "Név: " + nev + ", Kor: " + kor;
    }
}
