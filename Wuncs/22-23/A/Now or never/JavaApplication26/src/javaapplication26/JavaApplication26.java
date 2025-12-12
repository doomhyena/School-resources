/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication26;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.logging.Level;
import java.util.logging.Logger;


/**
 *
 * @author wuncs.david
 */
public class JavaApplication26 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try {
            Class.forName("com.mysql.jdbc.Driver");
            Connection con =
                    DriverManager.getConnection("jdbc:mysql://localhost:3306/users","root","");
            Statement st = con.createStatement();
            ResultSet rs =
                    st.executeQuery("select * from user");
            while(rs.next()){
                System.out.println(rs.getInt(1)+","+rs.getString(3));
            }
            
            con.close();
        } catch (ClassNotFoundException | SQLException ex) {
            System.out.println("Hiba: "+ex);
        }
    }
    
}
