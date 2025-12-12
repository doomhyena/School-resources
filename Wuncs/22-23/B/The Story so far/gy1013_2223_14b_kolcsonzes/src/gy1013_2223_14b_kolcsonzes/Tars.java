/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1013_2223_14b_kolcsonzes;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author wuncs.david
 */
public class Tars {
    private Tulaj t_adatok;
    private Cica c_adatok;
    private Date vasarlas;
    private SimpleDateFormat sdf
        = new SimpleDateFormat("yyyy.MM.dd");

    public Tars(Tulaj t_adatok, Cica c_adatok) {
        this.t_adatok = t_adatok;
        this.c_adatok = c_adatok;
        this.vasarlas = new Date();
    }

    public Tulaj getT_adatok() {
        return t_adatok;
    }

    public void setT_adatok(Tulaj t_adatok) {
        this.t_adatok = t_adatok;
    }

    public Cica getC_adatok() {
        return c_adatok;
    }

    public void setC_adatok(Cica c_adatok) {
        this.c_adatok = c_adatok;
    }

    public Date getVasarlas() {
        return vasarlas;
    }

    public void setVasarlas(Date vasarlas) {
        this.vasarlas = vasarlas;
    }

    @Override
    public String toString() {
        return  t_adatok.getNev() +
                ";" + c_adatok.getNev() +
                ";" + sdf.format(vasarlas);
    }
    
    
    
}
