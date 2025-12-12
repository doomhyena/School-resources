/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Graf_futok;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author wuncs.david
 */
//this.kor = TimeUnit.DAYS.convert(Math.abs(d.getTime()-szul.getTime()),TimeUnit.MILLISECONDS)/365;
public class Futo implements Comparable<Futo>{
    private String rajtszam;
    private String nev;
    private int kor;
    private String orszag;
    private Date ido;
    private Date d = new Date();
    
    private SimpleDateFormat sdf = new SimpleDateFormat("mm:ss.SS");
    @Override
    public String toString() {
        return nev + ", "+sdf.format(ido);
    }

    public Futo(String rajtszam, String nev, Date kor, String orszag, Date ido) {
        this.rajtszam = rajtszam;
        this.nev = nev;
        this.kor = (d.getYear()+1900)-(kor.getYear()+1900);
        this.orszag = orszag;
        this.ido = ido;
    }

    public Date getIdo() {
        return ido;
    }

    public void setIdo(Date ido) {
        this.ido = ido;
    }

    public String getRajtszam() {
        return rajtszam;
    }

    public void setRajtszam(String rajtszam) {
        this.rajtszam = rajtszam;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public int getKor() {
        return kor;
    }

    public void setKor(int kor) {
        this.kor = kor;
    }

    public String getOrszag() {
        return orszag;
    }

    public void setOrszag(String orszag) {
        this.orszag = orszag;
    }

    @Override
    public int compareTo(Futo t) {
        return ido.compareTo(t.ido);
    }
    
    
    
}
