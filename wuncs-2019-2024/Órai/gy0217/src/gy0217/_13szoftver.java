/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0217;

import java.util.Random;


public class _13szoftver implements Comparable<_13szoftver>{
    String nev;
    int kep_kezd;
    int kep_veg;
    int prog;
    int html;
    int hal;
    int oszt;
    int lany;
    int fiu;
    private Random rnd =
            new Random();

    public _13szoftver(String n) {
        this.nev = n;
        this.kep_kezd = rnd.nextInt(2023-2005+1)+2005;
        this.kep_veg = kep_kezd+2;
        this.prog = rnd.nextInt(100-50+1)+50;
        this.html = rnd.nextInt(100-50+1)+50;
        this.hal = rnd.nextInt(100-50+1)+50;
        this.oszt = rnd.nextInt(30-20+1)+20;
        this.lany = rnd.nextInt(oszt-0+1)+0;
        this.fiu = oszt-lany;
    }

    @Override
    public String toString() {
        return "Képzés: "+nev+"\n\t"+kep_kezd + " - " + kep_veg + "\n\tProgramozás: " + prog + " óra\n\tHtml: " + html + " óra\n\tHálózat: " + hal + " óra\n\tLétszám: " + oszt + " fõ\n\tLány: " + lany + " fõ\n\tFiú: " + fiu+" fõ \n-----------------------";
    }

    @Override
    public int compareTo(_13szoftver t) {
        //1,0,-1 lehet a visszatérési érték.
        //Integer rendezése
//        if (kep_kezd > t.kep_kezd)
//            return 1;
//        else if (kep_kezd == t.kep_kezd)
//            return 0;
//        else
//            return -1;
        //Stringek rendezése
        return t.nev.compareTo(nev);
    }
    
    
    
}
