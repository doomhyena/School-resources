import java.io.*;
import java.nio.file.*;
import java.util.*;

public class Main {

    public static void feladat(int n) {
        System.out.println("\n" + n + ". feladat:");
    }


    public static class Termek {
        String kod;
        String nev;
        int ar;
        int keszlet;

        Termek(String kod, String nev, int ar, int keszlet) {
            this.kod = kod;
            this.nev = nev;
            this.ar = ar;
            this.keszlet = keszlet;
        }
    }

    public static class Tetel {
        String termekKod;
        int mennyiseg;

        Tetel(String termekKod, int mennyiseg) {
            this.termekKod = termekKod;
            this.mennyiseg = mennyiseg;
        }
    }

    public static class Megrendeles {
        int id;
        String datum;
        String email;
        List<Tetel> tetelek = new ArrayList<>();

        Megrendeles(int id, String datum, String email) {
            this.id = id;
            this.datum = datum;
            this.email = email;
        }

        int osszertek(Map<String, Termek> raktar) {
            int ossz = 0;
            for (Tetel t : tetelek) {
                Termek termek = raktar.get(t.termekKod);
                if (termek != null)
                    ossz += termek.ar * t.mennyiseg;
            }
            return ossz;
        }
    }

    public static void main(String[] args) {

        try {
            feladat(1);
            Map<String, Termek> raktar = new HashMap<>();
            List<String> sorok = Files.readAllLines(Paths.get("raktar.csv"));
            for (String sor : sorok) {
                String[] adat = sor.split(";");
                if (adat.length == 4) {
                    raktar.put(adat[0].trim(),
                            new Termek(adat[0].trim(), adat[1].trim(),
                                    Integer.parseInt(adat[2].trim()),
                                    Integer.parseInt(adat[3].trim())));
                }
            }

            feladat(2);
            List<Megrendeles> rendelesek = new ArrayList<>();
            List<String> rendelesSorok = Files.readAllLines(Paths.get("rendeles.csv"));
            Megrendeles akt = null;
            for (String sor : rendelesSorok) {
                String[] adat = sor.split(";");
                if (adat[0].equals("M")) {
                    akt = new Megrendeles(Integer.parseInt(adat[2].trim()), adat[1].trim(), adat[3].trim());
                    rendelesek.add(akt);
                } else if (adat[0].equals("T") && akt != null) {
                    akt.tetelek.add(new Tetel(adat[2].trim(), Integer.parseInt(adat[3].trim())));
                }
            }

            feladat(3);
            Map<String, Integer> beszerzes = new HashMap<>();
            List<String> levelek = new ArrayList<>();
            for (Megrendeles m : rendelesek) {
                boolean teljesitheto = true;
                for (Tetel t : m.tetelek) {
                    Termek termek = raktar.get(t.termekKod);
                    if (termek == null || termek.keszlet < t.mennyiseg) {
                        teljesitheto = false;
                        int hiany = (termek == null) ? t.mennyiseg : t.mennyiseg - termek.keszlet;
                        beszerzes.put(t.termekKod, beszerzes.getOrDefault(t.termekKod, 0) + hiany);
                    }
                }

                if (teljesitheto) {
                    int ossz = m.osszertek(raktar);
                    for (Tetel t : m.tetelek) {
                        raktar.get(t.termekKod).keszlet -= t.mennyiseg;
                    }
                    levelek.add(m.email + ";A rendelését két napon belül szállítjuk. A rendelés értéke: " + ossz + " Ft");
                } else {
                    levelek.add(m.email + ";A rendelése függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról.");
                }
            }

            feladat(4);
            Files.write(Paths.get("levelek.csv"), levelek);
            List<String> beszerzesSorok = new ArrayList<>();
            for (var e : beszerzes.entrySet()) {
                beszerzesSorok.add(e.getKey() + ";" + e.getValue());
            }
            Files.write(Paths.get("beszerzes.csv"), beszerzesSorok);
            System.out.println("Feldolgozás kész! A 'levelek.csv' és 'beszerzes.csv' fájlok létrehozva.");
        } catch (IOException e) {
            System.out.println("Hiba a fájlbeolvasás során: " + e.getMessage());
        }
    }
}