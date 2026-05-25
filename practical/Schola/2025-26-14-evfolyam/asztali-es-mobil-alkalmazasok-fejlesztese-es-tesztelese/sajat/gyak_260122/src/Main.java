import javax.swing.*;
import java.awt.*;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Locale;
import java.util.Scanner;

// Kb. ilyen szintű vizsgára lehet majd számítani pls valamit alkoss, hogy egy 4-es legyél évvégén vagy ha rágod Dávid fülét lehet, hogy 5-s is lehetsz

public class Main {

    static DefaultListModel<Szemely> fiuk = new DefaultListModel<>();
    static DefaultListModel<Szemely> lanyok = new DefaultListModel<>();
    static JList<Szemely> lst = new JList<>();
    static JLabel lblDarab = new JLabel("Darab: 0");
    static JLabel lblAtlag = new JLabel("Átlagéletkor: 0.00");
    static JRadioButton rbFiuk = new JRadioButton("Fiúk");
    static JRadioButton rbLanyok = new JRadioButton("Lányok");

    public static void feltolt() {

        try (Scanner scanner = new Scanner(new File("nevek.csv"), "UTF-8")) {
            if (scanner.hasNextLine()) scanner.nextLine();

            while (scanner.hasNextLine()) {
                String line = scanner.nextLine().trim();
                if (line.isEmpty()) continue;

                String[] p = line.split(";");
                if (p.length >= 3) {
                    String nev = p[0].trim();
                    int kor = Integer.parseInt(p[1].trim());

                    int nemErtek = Integer.parseInt(p[2].trim());
                    boolean nem = (nemErtek == 1);

                    Szemely sz = new Szemely(nev, kor, nem);

                    if (nem) fiuk.addElement(sz);
                    else lanyok.addElement(sz);
                }
            }

        } catch (FileNotFoundException e) {
            JOptionPane.showMessageDialog(null, "Hiba: a nevek.csv nem található!", "Hiba", JOptionPane.ERROR_MESSAGE);
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, "Hiba beolvasás közben: " + e.getMessage(), "Hiba", JOptionPane.ERROR_MESSAGE);
        }
    }

    public static void frissit(DefaultListModel<Szemely> model) {
        lst.setModel(model);

        int db = model.getSize();
        lblDarab.setText("Darab: " + db);

        if (db == 0) {
            lblAtlag.setText("Átlagéletkor: 0.00");
            return;
        }

        double sum = 0;
        for (int i = 0; i < db; i++) {
            sum += model.get(i).getKor();
        }
        double atlag = sum / db;

        lblAtlag.setText(String.format(Locale.US, "Átlagéletkor: %.2f", atlag));
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            feltolt();
            gui();
        });
    }

    private static void gui() {
        JFrame f = new JFrame("Nevek");
        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        f.setSize(520, 380);
        f.setLocationRelativeTo(null);

        ButtonGroup bg = new ButtonGroup();
        bg.add(rbFiuk);
        bg.add(rbLanyok);

        JPanel top = new JPanel(new FlowLayout(FlowLayout.LEFT));
        top.add(new JLabel("Nem: "));
        top.add(rbFiuk);
        top.add(rbLanyok);

        JScrollPane sp = new JScrollPane(lst);
        JPanel bottom = new JPanel(new GridLayout(2, 1));

        bottom.add(lblDarab);
        bottom.add(lblAtlag);
        f.setLayout(new BorderLayout(10, 10));
        f.add(top, BorderLayout.NORTH);
        f.add(sp, BorderLayout.CENTER);
        f.add(bottom, BorderLayout.SOUTH);
        rbFiuk.addActionListener(e -> frissit(fiuk));
        rbLanyok.addActionListener(e -> frissit(lanyok));
        rbFiuk.setSelected(true);
        frissit(fiuk);
        f.setVisible(true);
    }
}






