import java.time.LocalDate;

public class Player {
    String name;
    LocalDate firstDate;
    LocalDate lastDate;
    int weight;
    int height;

    public Player(String name, LocalDate firstDate, LocalDate lastDate, int weight, int height) {
        this.name = name;
        this.firstDate = firstDate;
        this.lastDate = lastDate;
        this.weight = weight;
        this.height = height;
    }

    public String getName() {
        return name;
    }

    public LocalDate getFirstDate() {
        return firstDate;
    }

    public LocalDate getLastDate() {
        return lastDate;
    }

    public int getWeight() {
        return weight;
    }

    public int getHeight() {
        return height;
    }

    public boolean playedInYear(int year) {
        return (firstDate != null && lastDate != null) &&
                (firstDate.getYear() <= year && year <= lastDate.getYear());
    }

    public double heightCm() {
        return height * 2.54;
    }

    @Override
    public String toString() {
        return "Player{" +
                "name='" + name + '\'' +
                ", firstDate=" + firstDate +
                ", lastDate=" + lastDate +
                ", weight=" + weight +
                ", height=" + height +
                '}';
    }
}
