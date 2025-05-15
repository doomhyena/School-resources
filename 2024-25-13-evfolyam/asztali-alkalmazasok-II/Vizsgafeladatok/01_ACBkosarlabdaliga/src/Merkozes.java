public class Merkozes {
    String hazai;
    String idegen;
    int hazai_pont;
    int idegen_pont;
    String helyszin;
    String idopont;

    public Merkozes(String idopont, String helyszin, int idegen_pont, int hazai_pont, String hazai, String idegen) {
        this.idopont = idopont;
        this.helyszin = helyszin;
        this.idegen_pont = idegen_pont;
        this.hazai_pont = hazai_pont;
        this.hazai = hazai;
        this.idegen = idegen;
    }

    @Override
    public String toString() {
        return "Merkozes{" +
                "hazai='" + hazai + '\'' +
                ", idegen='" + idegen + '\'' +
                ", hazai_pont=" + hazai_pont +
                ", idegen_pont=" + idegen_pont +
                ", helyszin='" + helyszin + '\'' +
                ", idopont='" + idopont + '\'' +
                '}';
    }
}
