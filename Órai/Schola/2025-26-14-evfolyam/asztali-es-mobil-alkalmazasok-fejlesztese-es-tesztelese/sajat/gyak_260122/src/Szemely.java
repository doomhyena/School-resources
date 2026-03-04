public class Szemely {
    private String nev;
    private int kor;
    private boolean nem;

    public Szemely(String nev, int kor, boolean nem) {
        this.nev = nev;
        this.kor = kor;
        this.nem = nem;
    }

    public int getKor() {
        return kor;
    }
    public void setKor(int kor) {
        this.kor = kor;
    }
    public boolean isNem() {
        return nem;
    }
    public void setNem(boolean nem) {
        this.nem = nem;
    }

    public String getNev() { return nev; }
    public void setNev(String nev) { this.nev = nev; }

    @Override
    public String toString() {
        return nev + " (" + kor + ")";
    }
}
