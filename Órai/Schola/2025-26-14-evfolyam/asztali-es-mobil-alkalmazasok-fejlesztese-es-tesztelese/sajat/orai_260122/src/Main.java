import javax.swing.*;
import java.awt.*;

public class Main {
    
    public static void createWindow() {
        JFrame frame = new JFrame("Fájlbeolvasás");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        createUI(frame);
        frame.setSize(1000, 500);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }

    public static void createUI(JFrame frame) {
        JPanel szoveg = new JPanel(new BorderLayout());
        szoveg.add(new JLabel("Ez egy szöveg"));
        frame.add(szoveg);
    }

    public static void main(String[] args) {
        createWindow();
    }
}