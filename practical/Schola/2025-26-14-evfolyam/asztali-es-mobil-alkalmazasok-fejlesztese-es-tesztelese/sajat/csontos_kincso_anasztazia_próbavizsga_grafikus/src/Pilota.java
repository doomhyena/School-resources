import java.util.Collection;
import java.util.Collections;

public class Pilota {
    public String name;
    public int First_gp;
    public int Podiums;

    public Pilota(String name, int First_gp, int Podiums) {
        this.name = name;
        this.First_gp = First_gp;
        this.Podiums = Podiums;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getFirst_gp() {
        return First_gp;
    }

    public void setFirst_gp(int first_gp) {
        First_gp = first_gp;
    }

    public int getPodiums() {
        return Podiums;
    }

    public void setPodiums(int podiums) {
        Podiums = podiums;
    }

    @Override
    public String toString() {
        return name + " " + First_gp + " " + Podiums;
    }
}