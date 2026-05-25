import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.Random;

public class MyFrame extends JFrame {

    Random rand = new Random();

    private int rand(int i) {
        return rand.nextInt(i);
    }

    public MyFrame() {
        this.setTitle("Idejön a cím");
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setResizable(false);
        this.setSize(420, 420);
        this.setLayout(new BorderLayout());

        JButton button = new JButton("Háttér változtatása");

        button.addActionListener(e ->
                getContentPane().setBackground(
                        new Color(rand(256), rand(256), rand(256))
                )
        );

        JButton hoverButton = new JButton("Ráhúzásra változik");

        hoverButton.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseEntered(MouseEvent e) {
                getContentPane().setBackground(
                        new Color(rand(256), rand(256), rand(256))
                );
            }
        });

        this.add(button, BorderLayout.SOUTH);
        this.add(hoverButton, BorderLayout.NORTH);

        this.getContentPane().setBackground(
                new Color(rand(256), rand(256), rand(256))
        );

        this.setVisible(true);
    }

    public static void main(String[] args) {
        new MyFrame();
    }
}


