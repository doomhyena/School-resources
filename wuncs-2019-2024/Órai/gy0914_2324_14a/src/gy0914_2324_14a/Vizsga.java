/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0914_2324_14a;

import java.util.HashMap;

/**
 *
 * @author wuncs.david
 */
public class Vizsga {
    private String nyelv;
    private HashMap<Integer,Integer> ered =
            new HashMap<>();
    private int ossz = 0;

    public Vizsga(String sor) {
        String [] adatok = sor.split(";");
        this.nyelv = adatok[0];
        int ev = 2009;
        for (int i = 1; i < adatok.length; i++) {
            ered.put(ev, Integer.parseInt(adatok[i]));
            ev++;
            ossz += Integer.parseInt(adatok[i]);
        } 
    }

    
    public String getNyelv() {
        return nyelv;
    }

    public void setNyelv(String nyelv) {
        this.nyelv = nyelv;
    }

    public HashMap<Integer,Integer> getEred() {
        return ered;
    }

    public void setEred(HashMap<Integer,Integer> ered) {
        this.ered = ered;
    }

    public int getOssz() {
        return ossz;
    }

    public void setOssz(int ossz) {
        this.ossz = ossz;
    }
    
    
    
}
