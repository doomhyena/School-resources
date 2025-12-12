/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0915_2223_14b;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

class Edu{
    private String domain;
    private String ip;

    public Edu(String domain, String ip) {
        this.domain = domain;
        this.ip = ip;
    }

    public String getIp() {
        return ip;
    }

    public void setIp(String ip) {
        this.ip = ip;
    }

    public String getDomain() {
        return domain;
    }

    public void setDomain(String domain) {
        this.domain = domain;
    }
    
    
}

public class Gy0915_2223_14b {

    static ArrayList<Edu> ipk = new ArrayList<>();
    public static void main(String[] args) {
        fel();
        System.out.println("3. Feladat: "+ipk.size());
        _f5();
        _f6();
    }

    private static void fel() {
        File f = new File("csudh.txt");
        try {
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                ipk.add(new Edu(adatok[0],adatok[1]));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Hiba: "+ex);
        }
    }

    private static String domain(String dom, int s) {
        String [] szintek = dom.split("\\.");
        //System.out.println(Arrays.toString(szintek));
        Collections.reverse(Arrays.asList(szintek));
        //System.out.println(Arrays.toString(szintek));
        if (s<1 || s>szintek.length)
            return "nincs";
        return szintek[s-1];
    }

    private static void _f5() {
        System.out.println("5. Feladat. Első domain felépítése: ");
        for (int i = 0; i < 5; i++) {
            System.out.println((i+1)+". szint: "+domain(ipk.get(0).getDomain(), i+1));
        }
    }

    private static void _f6() {
        try {
            FileWriter fw = new FileWriter("table.html");
            fw.write("<table>\n<tr>\n" +
"<th style=' text-align: left'>Ssz</th>\n" +
"<th style=' text-align: left'>Host domain neve</th>\n" +
"<th style=' text-align: left'>Host IP címe</th>\n" +
"<th style=' text-align: left'>1. szint</th>\n" +
"<th style=' text-align: left'>2. szint</th>\n" +
"<th style=' text-align: left'>3. szint</th>\n" +
"<th style=' text-align: left'>4. szint</th>\n" +
"<th style=' text-align: left'>5. szint</th>\n" +
"</tr>");
            int ssz = 1;
            for (Edu n : ipk) {
                fw.write("<tr>");
                fw.write("<th style='text-align: left'>"+ssz+"</th>");
                fw.write("<td>"+n.getDomain()+"</td>");
                fw.write("<td>"+n.getIp()+"</td>");
                for (int i = 0; i < 5; i++) {
                    fw.write("<td>"+domain(n.getDomain(), i+1)+"</td>");
                }
                ssz++;
                fw.write("</tr>");
            }
            
            fw.write("</table>");
            fw.close();
        } catch (IOException ex) {
            System.out.println("Hiba: "+ex);
        }
    }
    
}
