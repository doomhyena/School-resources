/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package donttouchthis;

/**
 *
 * @author wuncs.david
 */
public class Film {
    private String cim;
    private int ev;
    private int hossz;

    public Film(String cim, int ev, int hossz) {
        this.cim = cim;
        this.ev = ev;
        this.hossz = hossz;
    }

    public int getHossz() {
        return hossz;
    }

    public void setHossz(int hossz) {
        this.hossz = hossz;
    }

    public String getCim() {
        return cim;
    }

    public void setCim(String cim) {
        this.cim = cim;
    }

    public int getEv() {
        return ev;
    }

    public void setEv(int ev) {
        this.ev = ev;
    }

    @Override
    public String toString() {
        return cim;
    }
    
    
}
