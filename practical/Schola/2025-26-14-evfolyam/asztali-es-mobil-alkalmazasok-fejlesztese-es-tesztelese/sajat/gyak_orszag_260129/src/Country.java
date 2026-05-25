public class Country {
    private String name;
    private int population;
    private String continent;

    public Country(String name, int population, String continent) {
        this.name = name;
        this.population = population;
        this.continent = continent;
    }

    public String getName() {
        return name;
    }

    public int getPopulation() {
        return population;
    }

    public String getContinent() {
        return continent;
    }

    @Override
    public String toString() {
        return name + " - " + population + " ezer fő - " + continent;
    }
}
