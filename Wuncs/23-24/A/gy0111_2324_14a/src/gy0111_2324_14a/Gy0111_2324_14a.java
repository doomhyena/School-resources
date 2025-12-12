/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0111_2324_14a;

import java.sql.*;
import java.util.ArrayList;

class User{
    String id,nev,datum;

    public User(String id, String nev, String d) {
        this.id = id;
        this.nev = nev;
        this.datum = d;
    }

    @Override
    public String toString() {
        return "User{" + "id=" + id + ", nev=" + nev + ", datum=" + datum + '}';
    }
    
    
}

public class Gy0111_2324_14a {

    static String un = "root";
    static String pw = "";
    static String cs = "jdbc:mysql://localhost:3306/java_db";
    static ArrayList<User> users = new ArrayList<>();
    
    public static void main(String[] args) {
        try {
            Connection con
             = DriverManager.getConnection(cs,un,pw);
            System.out.println("Siker");
            Statement st = con.createStatement();
            String uname = "Lajos";
            String email = "Lajosmail@barmi.hu";
            String ins =
             "INSERT INTO `user` (`name`,`email`) VALUES ('"+uname+"','"+email+"')";
            st.executeUpdate(ins);
            
            ResultSet rs = st.executeQuery("Select * from `user`");
            int o = rs.getMetaData().getColumnCount();
                System.out.println(o);
            while (rs.next()){
                users.add(new User(rs.getObject(1)+"",
                        rs.getObject(2)+"",rs.getObject(4)+""));
                
            }
            for (User n : users) {
                System.out.println(n);
            }
            
        } catch (Exception e) {
            System.out.println("Hiba: "+e);
        }
    }
    
}
