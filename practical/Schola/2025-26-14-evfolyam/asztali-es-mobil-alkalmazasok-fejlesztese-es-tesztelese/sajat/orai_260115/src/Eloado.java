public class Eloado {
    String band;
    String song;
    int year;
    int streams;

    public Eloado(String band, String song, int year, int streams) {
        this.band = band;
        this.song = song;
        this.year = year;
        this.streams = streams;
    }

    public String getBand() {
        return band;
    }

    public void setBand(String band) {
        this.band = band;
    }

    public String getSong() {
        return song;
    }

    public void setSong(String song) {
        this.song = song;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public int getStreams() {
        return streams;
    }

    public void setStreams(int streams) {
        this.streams = streams;
    }

    @Override
    public String toString() {
        return song + " (" + year + ")";
    }
}
