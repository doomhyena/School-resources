/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1014regia;
import java.util.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.*;
/**
 *
 * @author tanuló
 */
public class Gy1014regiA {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        JFrame frmBej = new JFrame("Bejelentkezés/Regisztráció");
        frmBej.setSize(500, 500);
        frmBej.setLocationRelativeTo(null);
        frmBej.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        JLabel lNick = new JLabel("Felhasználó");
        lNick.setBounds(0, 50, 1000, 30);
        frmBej.add(lNick);
        final JTextField tfNick = new JTextField();
        tfNick.setBounds(0, 80, 100, 30);
        frmBej.add(tfNick);
        JLabel lPass = new JLabel("Jelszó");
        lPass.setBounds(0, 120, 1000, 30);
        frmBej.add(lPass);
        final JPasswordField pfPass = new JPasswordField();
        pfPass.setBounds(0, 150, 100, 30);
        frmBej.add(pfPass);
        JButton btnBevitel = new JButton("Bevitel");
        btnBevitel.setBounds(0, 190, 100, 30);
        frmBej.add(btnBevitel);
        final JLabel lAdatok = new JLabel();
        lAdatok.setBounds(130, 115, 1000, 30);
        frmBej.add(lAdatok);
        final DefaultListModel <Felhasznalo> felhasznalok = new DefaultListModel<>();
        final DefaultListModel<String> felhnevek =new DefaultListModel<>();
        JList <String> nevek = new JList<>(felhnevek);
        nevek.setBounds(300, 0, 100, 70);
        frmBej.add(nevek);
        btnBevitel.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent ae) {
                lAdatok.setText("Név: "+tfNick.getText()+", Jelszó: "+new String(pfPass.getPassword()));
                if (!felhnevek.contains(tfNick.getText())){
                felhasznalok.addElement(new Felhasznalo(tfNick.getText(), new String(pfPass.getPassword())));
                felhnevek.addElement(tfNick.getText());
                }
                }
        });
        
        
        
        
        
        frmBej.setLayout(null);
        frmBej.setVisible(true);
    }
    
}
