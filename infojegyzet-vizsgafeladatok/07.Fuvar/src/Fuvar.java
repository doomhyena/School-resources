import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class Fuvar {
    int taxi_id;
    LocalDateTime indulas;
    int idotartam;
    double tavolsag;
    double viteldij;
    double borravalo;
    String fizetes_modja;

    public Fuvar(int taxi_id, LocalDateTime indulas, int idotartam, double tavolsag,
                 double viteldij, double borravalo, String fizetes_modja) {
        this.taxi_id = taxi_id;
        this.indulas = indulas;
        this.idotartam = idotartam;
        this.tavolsag = tavolsag;
        this.viteldij = viteldij;
        this.borravalo = borravalo;
        this.fizetes_modja = fizetes_modja;
    }

    public String toCsvLine() {
        DateTimeFormatter fmt = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
        return taxi_id + ";" +
                indulas.format(fmt) + ";" +
                idotartam + ";" +
                tavolsag + ";" +
                viteldij + ";" +
                borravalo + ";" +
                fizetes_modja;
    }
}