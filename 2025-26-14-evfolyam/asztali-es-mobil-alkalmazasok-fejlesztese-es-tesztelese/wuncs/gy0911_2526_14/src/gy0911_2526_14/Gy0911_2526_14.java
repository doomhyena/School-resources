package gy0911_2526_14;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

class Zene{
    private String band;
    private String song;
    private int year;
    private int streams;

    public Zene(String band, String song, int year, int streams) {
        this.band = band;
        this.song = song;
        this.year = year;
        this.streams = streams;
    }

    public String getBand() {
        return band;
    }

    public void setBand(String band) {
        this.band = band;
    }

    public String getSong() {
        return song;
    }

    public void setSong(String song) {
        this.song = song;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public int getStreams() {
        return streams;
    }

    public void setStreams(int streams) {
        this.streams = streams;
    }

    @Override
    public String toString() {
        return "Zene{" + "band=" + band + ", song=" + song + ", year=" + year + ", streams=" + streams + '}';
    }

    
}

public class Gy0911_2526_14 {

    static ArrayList <Zene> zenek = new ArrayList<>();
    public static void main(String[] args) {
        // TODO code application logic here
        feltolt();
        
//        for (Zene n : zenek) {
//            System.out.println(n);
//        }

        f6();

    }

    private static void feltolt() {
        File f = new File("eloadok.csv");
        try{
            Scanner be = new Scanner(f,"UTF-8");
            be.nextLine();
            String sor;
            String [] adatok;
            while(be.hasNextLine()){
                sor = be.nextLine();
                adatok = sor.split(";");
                zenek.add(new Zene(
                        adatok[0],
                        adatok[1],
                Integer.parseInt(adatok[2]),
                Integer.parseInt(adatok[3])));
            }
            
        }
        catch(FileNotFoundException fnf){
            System.out.println("Hiba: "+fnf);
        }
        
    }

    private static void f6() {
        Zene max = new Zene("","",0,0);
       
        for (Zene n : zenek) {
            if (n.getBand().equals("Linkin Park")
                    && n.getStreams()>max.getStreams())
                max = n;
        }
        
        System.out.println(max.getSong()+": "+max.getStreams());
        
    }
    
}
