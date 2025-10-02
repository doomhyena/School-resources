public class Citromos {
    private String megnevezes;
    private double ar;
    private String kategoria;

    public Citromos(String megnevezes, double ar, String kategoria) {
        this.megnevezes = megnevezes;
        this.ar = ar;
        this.kategoria = kategoria;
    }

    public String getMegnevezes() {
        return megnevezes;
    }
    public double getAr() {
        return ar;
    }
    public String getKategoria() {
        return kategoria;
    }
}
