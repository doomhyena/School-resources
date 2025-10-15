import java.io.*;
import java.util.*;
import java.util.stream.Collectors;

public class Main {
    static List<Kifejezes> lista = new ArrayList<>();

    public static void feladat(int n) {
        System.out.println(n + ".feladat: ");
    }

    public static void feltolt() {
        String fileName = "kifejezesek.txt";

        try (BufferedReader br = new BufferedReader(new FileReader(fileName))) {
            String sor;
            while ((sor = br.readLine()) != null) {
                String[] reszek = sor.split(" ");
                if (reszek.length == 3) {
                    int elso = Integer.parseInt(reszek[0]);
                    String operator = reszek[1];
                    int masodik = Integer.parseInt(reszek[2]);
                    lista.add(new Kifejezes(elso, operator, masodik));
                }
            }
            System.out.println("A fájl sikeresen beolvasva! (" + lista.size() + " sor)");
        } catch (Exception e) {
            System.err.println("Hiba a fájl beolvasásakor: " + e.getMessage());
            e.printStackTrace();
        }
    }

    public static String kiertekel(int a, String op, int b) {
        try {
            switch (op) {
                case "+":
                    return String.valueOf(a + b);
                case "-":
                    return String.valueOf(a - b);
                case "*":
                    return String.valueOf(a * b);
                case "/":
                    if (b == 0) return "Egyéb hiba!";
                    return String.valueOf((double) a / b);
                case "div":
                    if (b == 0) return "Egyéb hiba!";
                    return String.valueOf(a / b);
                case "mod":
                    if (b == 0) return "Egyéb hiba!";
                    return String.valueOf(a % b);
                default:
                    return "Hibás operátor!";
            }
        } catch (ArithmeticException e) {
            return "Egyéb hiba!";
        } catch (Exception e) {
            return "Egyéb hiba!";
        }
    }

    public static void fajlbaIras(String fajlnev) {
        try (PrintWriter pw = new PrintWriter(new FileWriter(fajlnev))) {
            for (Kifejezes k : lista) {
                String eredmeny = kiertekel(k.getElsoOperandus(), k.getOperator(), k.getMasodikOperandus());
                pw.println(k.getElsoOperandus() + " " + k.getOperator() + " " + k.getMasodikOperandus() + " = " + eredmeny);
            }
        } catch (IOException e) {
            System.err.println("Hiba a fájl írása során: " + e.getMessage());
        }
    }

    public static void main(String[] args) {
        feladat(1);
        feltolt();

        feladat(2);
        System.out.println("Kifejezések száma: " + lista.size());

        feladat(3);
        int modDarab = (int) lista.stream()
                .filter(k -> "mod".equals(k.getOperator()))
                .count();
        System.out.println("Kifejezések maradékos osztással: " + modDarab);

        feladat(4);
        boolean vanTizzelOszthato = lista.stream()
                .anyMatch(k -> k.getElsoOperandus() % 10 == 0 && k.getMasodikOperandus() % 10 == 0);
        System.out.println((vanTizzelOszthato ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés!"));

        feladat(5);
        System.out.println("Statisztika");
        Map<String, Long> statisztika = lista.stream()
                .collect(Collectors.groupingBy(Kifejezes::getOperator, Collectors.counting()));

        String[] operatorok = {"mod", "/", "div", "-", "*", "+"};
        for (String op : operatorok) {
            long darab = statisztika.getOrDefault(op, 0L);
            System.out.println(op + " -> " + darab + " db");
        }

        feladat(6);
        System.out.println("Kész! (kiertekel függvény implementálva)");

        feladat(7);
        Scanner scanner = new Scanner(System.in);
        System.out.print("Kérek egy kifejezést (pl.: 1 + 1): ");
        String bemenet = scanner.nextLine();

        while (!"vége".equals(bemenet)) {
            String[] reszek = bemenet.split(" ");
            if (reszek.length == 3) {
                try {
                    int elso = Integer.parseInt(reszek[0]);
                    String op = reszek[1];
                    int masodik = Integer.parseInt(reszek[2]);
                    String eredmeny = kiertekel(elso, op, masodik);
                    System.out.println(bemenet + " = " + eredmeny);
                } catch (NumberFormatException e) {
                    System.out.println(bemenet + " = Hibás operandus!");
                }
            } else {
                System.out.println(bemenet + " = Hibás formátum!");
            }

            System.out.print("Kérek egy kifejezést (pl.: 1 + 1): ");
            bemenet = scanner.nextLine();
        }
        scanner.close();

        feladat(8);
        fajlbaIras("eredmenyek.txt");
        System.out.println("eredmenyek.txt");
    }
}