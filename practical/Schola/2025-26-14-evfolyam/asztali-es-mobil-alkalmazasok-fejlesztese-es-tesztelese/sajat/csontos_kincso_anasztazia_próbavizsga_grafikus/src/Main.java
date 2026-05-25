import java.util.*;
import java.io.*;
import javax.swing.*;
import java.awt.*;
public class Main {
    public static final ArrayList<Pilota> pilotaList = new ArrayList<>();

    public static void feltolt() {
        try (BufferedReader br = new BufferedReader(new FileReader("pilotak.csv"))) {
            String header = br.readLine();
            String line;
            while ((line = br.readLine()) != null) {
                line = line.trim();
                if (line.isEmpty()) continue;

                String[] parts = line.split(";", -1);
                if (parts.length < 3) continue;

                pilotaList.add(new Pilota(
                        parts[0].trim(),
                        Integer.parseInt(parts[1].trim()),
                        Integer.parseInt(parts[2].trim())
                ));
            }
        } catch (FileNotFoundException e) {
            System.out.println("Hibás számformátum a fájlban: " + e.getMessage());
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static void CreateWindow() {
        JFrame frame = new JFrame("Pilóták");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(700, 500);
        CreateGUI(frame);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }

    public static void CreateGUI(JFrame frame) {
    frame.setLayout(new BorderLayout());

    DefaultListModel<Pilota> listModel = new DefaultListModel<>();
    for (Pilota p : pilotaList) listModel.addElement(p);

    JList<Pilota> pilotList = new JList<>(listModel);
    pilotList.setCellRenderer(new DefaultListCellRenderer() {
        @Override
        public Component getListCellRendererComponent(
                JList<?> list, Object value, int index, boolean isSelected, boolean cellHasFocus
        ) {
            super.getListCellRendererComponent(list, value, index, isSelected, cellHasFocus);
            setText(((Pilota) value).getName());
            return this;
        }
    });

    JScrollPane scrollPane = new JScrollPane(pilotList);
    scrollPane.setPreferredSize(new Dimension(300, 350));
    frame.add(scrollPane, BorderLayout.WEST);

    JPanel rightPanel = new JPanel(new GridBagLayout());
    rightPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));
    frame.add(rightPanel, BorderLayout.CENTER);

    JPanel centerBlock = new JPanel();
    centerBlock.setLayout(new BoxLayout(centerBlock, BoxLayout.Y_AXIS));

    JPanel topRow = new JPanel(new FlowLayout(FlowLayout.CENTER, 10, 0));

    String[] comboBoxValues = {"2000", "2010", "2020"};
    JComboBox<String> comboBox = new JComboBox<>(comboBoxValues);

    Dimension cbPref = comboBox.getPreferredSize();
    cbPref = new Dimension(cbPref.width + 40, cbPref.height);
    comboBox.setPreferredSize(cbPref);
    comboBox.setMaximumSize(cbPref);

    JLabel label = new JLabel("Nyomd meg a Számol gombot.");

    topRow.add(comboBox);
    topRow.add(label);

    JButton button = new JButton("Számol");
    button.setAlignmentX(Component.CENTER_ALIGNMENT);
    button.addActionListener(e -> {
        int decadeStart = Integer.parseInt((String) comboBox.getSelectedItem());
        int decadeEnd = (decadeStart == 2020) ? 2026 : (decadeStart + 9);

        int count = 0;
        for (Pilota p : pilotaList) {
            int y = p.getFirst_gp();
            if (y >= decadeStart && y <= decadeEnd) count++;
        }
        label.setText("Pilóták száma (" + decadeStart + "-" + decadeEnd + "): " + count);
    });

    centerBlock.add(topRow);
    centerBlock.add(Box.createRigidArea(new Dimension(0, 12)));
    centerBlock.add(button);

    GridBagConstraints gbc = new GridBagConstraints();
    gbc.gridx = 0;
    gbc.gridy = 0;
    gbc.weightx = 1.0;
    gbc.weighty = 1.0;
    gbc.anchor = GridBagConstraints.CENTER;
    gbc.fill = GridBagConstraints.NONE;

    rightPanel.add(centerBlock, gbc);
}

    public static void main(String[] args) {
        feltolt();
        CreateWindow();
    }
}