import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Main implements ActionListener {

    static JTextField textField;
    static JFrame frame;
    static JButton button;
    static JLabel label;

    public static void createWindow() {
        frame = new JFrame("Textfield");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(300, 200);
        frame.setLocationRelativeTo(null);

        createUI(frame);
        frame.setVisible(true);
    }

    public static void createUI(JFrame frame) {
        frame.setLayout(new FlowLayout());

        label = new JLabel("Textfield alapok");
        textField = new JTextField(15);
        button = new JButton("Kattints ide!");

        button.addActionListener(new Main());

        frame.add(label);
        frame.add(textField);
        frame.add(button);
    }
    
    @Override
    public void actionPerformed(ActionEvent e) {
        label.setText(textField.getText());
        textField.setText("");
    }

    public static void main(String[] args) {
        createWindow();
    }
}
