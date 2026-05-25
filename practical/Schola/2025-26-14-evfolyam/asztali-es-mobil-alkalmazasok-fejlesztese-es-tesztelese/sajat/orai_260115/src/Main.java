import javax.swing.*;
import java.awt.*;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class Main {
    static DefaultListModel<Eloado> eloadok = new DefaultListModel<>();
    static JList<Eloado> lbZenek = new JList<>(eloadok);

    static DefaultListModel<Eloado> kedvencEloadok = new DefaultListModel<>();
    static JList<Eloado> lbKedvencek = new JList<>(kedvencEloadok);

    public Main() {
        feltolt();
        createWindow();
    }

    public static void feltolt() {
        try (Scanner scanner = new Scanner(new File("eloadok.csv"), "UTF-8")) {
            scanner.nextLine();

            while (scanner.hasNextLine()) {
                String line = scanner.nextLine();
                String[] parts = line.split(";");
                if (parts.length == 4) {
                    String band = parts[0];
                    String song = parts[1];
                    int year = Integer.parseInt(parts[2]);
                    int streams = Integer.parseInt(parts[3]);
                    eloadok.addElement(new Eloado(band, song, year, streams));
                }
            }
        } catch (FileNotFoundException e) {
            System.err.println("Hiba: A fájl nem található!");
        } catch (Exception e) {
            System.err.println("Hiba a beolvasás során: " + e.getMessage());
            }
    }

    public static void createWindow() {
        JFrame frame = new JFrame("Fájlbeolvasás");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        createUI(frame);
        frame.setSize(1000, 500);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }

    public static void createUI(JFrame frame) {
        JPanel mainPanel = new JPanel(new GridLayout(1, 3, 10, 0));
        mainPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));
        
        JPanel balPanel = new JPanel(new BorderLayout());
        balPanel.add(new JLabel("Számok:"), BorderLayout.NORTH);
        lbZenek.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        balPanel.add(new JScrollPane(lbZenek), BorderLayout.CENTER);

        JPanel gombPanel = new JPanel(new GridBagLayout());
        JPanel gombDoboz = new JPanel(new GridLayout(2, 1, 0, 10));
        
        JButton btnAdd = new JButton(">");
        JButton btnRemove = new JButton("Törlés");

        btnAdd.addActionListener(e -> {
            Eloado kijelolt = lbZenek.getSelectedValue();
            if (kijelolt != null) {
                if (!kedvencEloadok.contains(kijelolt)) {
                    kedvencEloadok.addElement(kijelolt);
                } else {
                    JOptionPane.showMessageDialog(frame, "Ez a szám már a kedvencek között van!");
                }
            } else {
                JOptionPane.showMessageDialog(frame, "Válassz ki egy számot a bal oldali listából!");
            }
        });

        btnRemove.addActionListener(e -> {
            int kijeloltIndex = lbKedvencek.getSelectedIndex();
            if (kijeloltIndex != -1) {
                kedvencEloadok.remove(kijeloltIndex);
            } else {
                JOptionPane.showMessageDialog(frame, "Válassz ki egy számot a kedvencek listájából!");
            }
        });

        gombDoboz.add(btnAdd);
        gombDoboz.add(btnRemove);
        gombPanel.add(gombDoboz);

        JPanel jobbPanel = new JPanel(new BorderLayout());
        jobbPanel.add(new JLabel("Kedvencek:"), BorderLayout.NORTH);
        lbKedvencek.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        jobbPanel.add(new JScrollPane(lbKedvencek), BorderLayout.CENTER);

        mainPanel.add(balPanel);
        mainPanel.add(gombPanel);
        mainPanel.add(jobbPanel);

        frame.add(mainPanel);
    }

    public static void main(String[] args) {
        new Main();
    }
}