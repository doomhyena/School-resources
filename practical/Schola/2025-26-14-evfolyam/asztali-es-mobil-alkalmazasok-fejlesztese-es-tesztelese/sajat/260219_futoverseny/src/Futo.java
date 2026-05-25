import javax.swing.*;
import java.awt.*;
import java.io.*;

public class Futo {
    /**
     * Formátum: mm:ss.xx (xx = századmásodperc)
     * Példa: 40:05.18 -> 40 perc, 5 mp, 18 század
     */
    private static long parseVersenyIdoToMillis(String idoText) {
        // mm:ss.xx
        String[] minAndRest = idoText.split(":");
        if (minAndRest.length != 2) {
            throw new IllegalArgumentException("Hibás időformátum (várt mm:ss.xx): " + idoText);
        }

        int minutes = Integer.parseInt(minAndRest[0].trim());

        String[] secAndHund = minAndRest[1].split("\\.");
        if (secAndHund.length != 2) {
            throw new IllegalArgumentException("Hibás időformátum (várt mm:ss.xx): " + idoText);
        }

        int seconds = Integer.parseInt(secAndHund[0].trim());
        int hundredths = Integer.parseInt(secAndHund[1].trim());

        if (seconds < 0 || seconds > 59) {
            throw new IllegalArgumentException("Másodperc tartományhiba (0..59): " + idoText);
        }
        if (hundredths < 0 || hundredths > 99) {
            throw new IllegalArgumentException("Századmásodperc tartományhiba (0..99): " + idoText);
        }

        return minutes * 60_000L + seconds * 1_000L + hundredths * 10L;
    }

    final String rajtszam;
    final String nev;
    final String szuletesiDatum; // yyyy.MM.dd
    final String orszag;
    final String idoText; // pl. 40:05.18
    final long idoMillis; // rendezéshez/számításhoz

    Futo(String rajtszam, String nev, String szuletesiDatum, String orszag, String idoText) {
        this.rajtszam = rajtszam;
        this.nev = nev;
        this.szuletesiDatum = szuletesiDatum;
        this.orszag = orszag;
        this.idoText = idoText;
        this.idoMillis = parseVersenyIdoToMillis(idoText);
    }
}