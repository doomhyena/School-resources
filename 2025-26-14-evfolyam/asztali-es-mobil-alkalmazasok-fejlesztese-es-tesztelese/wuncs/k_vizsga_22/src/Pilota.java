public class Pilota {
    public String nev;
    private int szuletesiEv;
    public String csapat;
    private int futamokSzama;
    public int gyozelemSzama;
    private String nemzetiseg;

    public Pilota(String nev, int szuletesiEv, String csapat, int futamokSzama, int gyozelemSzama, String nemzetiseg) {
        this.nev = nev;
        this.szuletesiEv = szuletesiEv;
        this.csapat = csapat;
        this.futamokSzama = futamokSzama;
        this.gyozelemSzama = gyozelemSzama;
        this.nemzetiseg = nemzetiseg;
    }

    public String getNev() {
        return nev;
    }
    public int getSzuletesiEv() {
        return szuletesiEv;
    }
    public String getCsapat() {
        return csapat;
    }
    public int getFutamokSzama() {
        return futamokSzama;
    }
    public int getGyozelemSzama() {
        return gyozelemSzama;
    }
    public String getNemzetiseg() {
        return nemzetiseg;
    }
}
