import javax.swing.*;
import java.awt.*;
import java.util.Random;
// töbszörös hozzáadás + törlés

public class Main {

    static DefaultListModel<Integer> model = new DefaultListModel<>();
    static Random rnd = new Random();

    public static void createWindow() {
        JFrame frame = new JFrame("Órai Listbox");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        createUI(frame);
        frame.setSize(500, 250);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }

    public static void createUI(JFrame frame) {

        JPanel panel = new JPanel(new BorderLayout());

        JList<Integer> listBox = new JList<>(model);
        listBox.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);

        JScrollPane scrollPane = new JScrollPane(listBox);
        panel.add(scrollPane, BorderLayout.CENTER);

        JPanel buttonPanel = new JPanel(new FlowLayout());
        JButton addButton = new JButton("+");
        JButton removeButton = new JButton("-");

        buttonPanel.add(addButton);
        buttonPanel.add(removeButton);

        panel.add(buttonPanel, BorderLayout.SOUTH);

        addButton.addActionListener(e -> {
            int randomNumber = rnd.nextInt(100);
            model.addElement(randomNumber);
        });

        removeButton.addActionListener(e -> {
            int index = listBox.getSelectedIndex();
            if (index != -1) {
                model.remove(index);
            } else {
                JOptionPane.showMessageDialog(frame, "Nincs kijelölve elem!");
            }
        });

        frame.add(panel);
    }

    public static void main(String[] args) {

        createWindow();

    }
}