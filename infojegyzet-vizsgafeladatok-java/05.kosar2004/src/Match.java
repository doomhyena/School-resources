import java.time.LocalDate;

public class Match {
    String home;
    String away;
    int homePoints;
    int awayPoints;
    String venue;
    LocalDate date;

    public Match(String home, String away, int homePoints, int awayPoints, String venue, LocalDate date) {
        this.home = home;
        this.away = away;
        this.homePoints = homePoints;
        this.awayPoints = awayPoints;
        this.venue = venue;
        this.date = date;
    }


    public String getHome() {
        return home;
    }

    public String getAway() {
        return away;
    }

    public int getHomePoints() {
        return homePoints;
    }

    public int getAwayPoints() {
        return awayPoints;
    }

    public String getVenue() {
        return venue;
    }

    public LocalDate getDate() {
        return date;
    }

    boolean isDraw() {
        return homePoints == awayPoints;
    }

    @Override
    public String toString() {
        return String.format("%s - %s (%d:%d) @ %s %s",
                home, away, homePoints, awayPoints, venue, date == null ? "" : date.toString());
    }
}
