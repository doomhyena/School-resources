import javax.swing.*;
import javax.swing.border.EmptyBorder;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class Main {

    private static final List<Futo> futok = new ArrayList<>();

    public static void main(String[] args) {
        SwingUtilities.invokeLater(Main::createAndShowUI);
    }

    private static void createAndShowUI() {
        JFrame frame = new JFrame("Futóverseny - Nevek és adatok");
        frame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        frame.setSize(900, 520);
        frame.setLocationRelativeTo(null);

        DefaultListModel<String> nameListModel = new DefaultListModel<>();
        JList<String> nameList = new JList<>(nameListModel);
        nameList.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        nameList.setBorder(new EmptyBorder(8, 8, 8, 8));

        JScrollPane listScroll = new JScrollPane(nameList);

        JTextField tfRajtszam = createReadOnlyField();
        JTextField tfNev = createReadOnlyField();
        JTextField tfSzuletes = createReadOnlyField();
        JTextField tfOrszag = createReadOnlyField();
        JTextField tfIdo = createReadOnlyField();

        JPanel detailsPanel = new JPanel(new GridBagLayout());
        detailsPanel.setBorder(new EmptyBorder(10, 10, 10, 10));
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(6, 6, 6, 6);
        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.weightx = 1.0;

        addRow(detailsPanel, gbc, 0, "Rajtszám:", tfRajtszam);
        addRow(detailsPanel, gbc, 1, "Név:", tfNev);
        addRow(detailsPanel, gbc, 2, "Születési dátum:", tfSzuletes);
        addRow(detailsPanel, gbc, 3, "Ország:", tfOrszag);
        addRow(detailsPanel, gbc, 4, "Idő:", tfIdo);

        JSplitPane split = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT, listScroll, detailsPanel);
        split.setDividerLocation(320);
        frame.add(split, BorderLayout.CENTER);

        nameList.addListSelectionListener(e -> {
            if (e.getValueIsAdjusting()) return;
            int idx = nameList.getSelectedIndex();
            if (idx < 0 || idx >= futok.size()) {
                clearFields(tfRajtszam, tfNev, tfSzuletes, tfOrszag, tfIdo);
                return;
            }
            Futo f = futok.get(idx);
            tfRajtszam.setText(f.rajtszam);
            tfNev.setText(f.nev);
            tfSzuletes.setText(f.szuletesiDatum);
            tfOrszag.setText(f.orszag);
            tfIdo.setText(f.idoText);
        });

        nameList.addMouseListener(new MouseAdapter() {
            @Override
            public void mousePressed(MouseEvent e) { maybeSave(e); }

            @Override
            public void mouseReleased(MouseEvent e) { maybeSave(e); }

            private void maybeSave(MouseEvent e) {
                if (!e.isPopupTrigger()) return;
                if (futok.isEmpty()) {
                    JOptionPane.showMessageDialog(frame, "Nincs betöltött adat.", "Mentés", JOptionPane.INFORMATION_MESSAGE);
                    return;
                }

                try {
                    saveResultsToFile(new File("EREDMENYEK.txt"), getSortedByTimeDesc(futok));
                    JOptionPane.showMessageDialog(
                            frame,
                            "Mentve: EREDMENYEK.txt\n(A program munkakönyvtárába)",
                            "Mentés kész",
                            JOptionPane.INFORMATION_MESSAGE
                    );
                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(
                            frame,
                            "Hiba mentés közben:\n" + ex.getMessage(),
                            "Mentési hiba",
                            JOptionPane.ERROR_MESSAGE
                    );
                }
            }
        });

        JMenuBar menuBar = new JMenuBar();

        JMenu fileMenu = new JMenu("Fájl");
        JMenuItem openItem = new JMenuItem("Megnyit…");
        JMenuItem exitItem = new JMenuItem("Kilépés");

        JMenu viewMenu = new JMenu("Nézet");
        JMenuItem resultsItem = new JMenuItem("Eredménylista");

        openItem.addActionListener(e -> {
            JFileChooser chooser = new JFileChooser();
            chooser.setDialogTitle("futok.txt megnyitása");
            int result = chooser.showOpenDialog(frame);

            if (result == JFileChooser.APPROVE_OPTION) {
                File file = chooser.getSelectedFile();
                try {
                    List<Futo> read = readFutokFromFile(file);

                    futok.clear();
                    futok.addAll(read);

                    nameListModel.clear();
                    for (Futo f : futok) {
                        nameListModel.addElement(f.nev);
                    }

                    clearFields(tfRajtszam, tfNev, tfSzuletes, tfOrszag, tfIdo);
                    frame.setTitle("Futóverseny - " + file.getName() + " (" + futok.size() + " fő)");

                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(
                            frame,
                            "Hiba a fájl beolvasásakor:\n" + ex.getMessage(),
                            "Beolvasási hiba",
                            JOptionPane.ERROR_MESSAGE
                    );
                }
            }
        });

        resultsItem.addActionListener(e -> {
            if (futok.isEmpty()) {
                JOptionPane.showMessageDialog(frame, "Előbb tölts be egy fájlt.", "Eredménylista", JOptionPane.INFORMATION_MESSAGE);
                return;
            }
            showResultsWindow(frame, getSortedByTimeDesc(futok));
        });

        exitItem.addActionListener(e -> frame.dispose());

        fileMenu.add(openItem);
        fileMenu.addSeparator();
        fileMenu.add(exitItem);

        viewMenu.add(resultsItem);

        menuBar.add(fileMenu);
        menuBar.add(viewMenu);
        frame.setJMenuBar(menuBar);

        frame.setVisible(true);
    }

    private static void showResultsWindow(JFrame owner, List<Futo> sortedDesc) {
        JFrame win = new JFrame("Eredménylista (idő szerint csökkenő)");
        win.setSize(520, 420);
        win.setLocationRelativeTo(owner);

        DefaultTableModel model = new DefaultTableModel(new Object[]{"Név", "Idő"}, 0) {
            @Override public boolean isCellEditable(int row, int column) { return false; }
        };

        for (Futo f : sortedDesc) {
            model.addRow(new Object[]{f.nev, f.idoText});
        }

        JTable table = new JTable(model);
        table.setFillsViewportHeight(true);

        win.add(new JScrollPane(table), BorderLayout.CENTER);
        win.setVisible(true);
    }

    private static List<Futo> getSortedByTimeDesc(List<Futo> src) {
        List<Futo> copy = new ArrayList<>(src);
        copy.sort(Comparator.comparingLong((Futo f) -> f.idoMillis).reversed());
        return copy;
    }

    private static void saveResultsToFile(File outFile, List<Futo> sortedDesc) throws IOException {
        try (BufferedWriter bw = new BufferedWriter(
                new OutputStreamWriter(new FileOutputStream(outFile), StandardCharsets.ISO_8859_1)
        )) {
            for (Futo f : sortedDesc) {
                bw.write(f.nev + ";" + f.idoText);
                bw.newLine();
            }
        }
    }

    private static List<Futo> readFutokFromFile(File file) throws IOException {
        List<Futo> list = new ArrayList<>();

        try (BufferedReader br = new BufferedReader(
                new InputStreamReader(new FileInputStream(file), StandardCharsets.ISO_8859_1)
        )) {
            String line;
            while ((line = br.readLine()) != null) {
                line = line.trim();
                if (line.isEmpty()) continue;

                String[] parts = line.split(";");
                if (parts.length != 5) {
                    throw new IOException("Hibás sorformátum (várt 5 mező ';' elválasztóval): " + line);
                }

                String rajtszam = parts[0].trim();
                String nev = parts[1].trim();
                String szuletesiDatum = parts[2].trim();
                String orszag = parts[3].trim();
                String ido = parts[4].trim();

                list.add(new Futo(rajtszam, nev, szuletesiDatum, orszag, ido));
            }
        }
        return list;
    }

    private static JTextField createReadOnlyField() {
        JTextField tf = new JTextField();
        tf.setEditable(false);
        tf.setFocusable(false);
        return tf;
    }

    private static void addRow(JPanel panel, GridBagConstraints gbc, int row, String label, JComponent field) {
        gbc.gridy = row;
        gbc.gridx = 0;
        gbc.weightx = 0;
        panel.add(new JLabel(label), gbc);
        gbc.gridx = 1;
        gbc.weightx = 1;
        panel.add(field, gbc);
    }

    private static void clearFields(JTextField... fields) {
        for (JTextField f : fields) f.setText("");
    }
}






