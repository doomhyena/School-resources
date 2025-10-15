public class Language {
    String name;
    int[] successful;
    int[] unsuccessful;

    public Language(String name) {
        this.name = name;
        this.successful = new int[9];
        this.unsuccessful = new int[9];
    }

    public int totalAll() {
        int sum = 0;
        for (int v : successful) sum += v;
        for (int v : unsuccessful) sum += v;
        return sum;
    }

    public int totalSuccessful() {
        int sum = 0;
        for (int v : successful) sum += v;
        return sum;
    }

    public int totalUnsuccessful() {
        int sum = 0;
        for (int v : unsuccessful) sum += v;
        return sum;
    }
}