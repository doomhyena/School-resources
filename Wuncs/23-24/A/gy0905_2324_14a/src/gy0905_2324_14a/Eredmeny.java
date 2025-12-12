/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0905_2324_14a;

/**
 *
 * @author wuncs.david
 */
public class Eredmeny {
    private String gp;
    private int start;
    private int finish;
    private int pts;

    public Eredmeny(String gp, int start, int finish, int pts) {
        this.gp = gp;
        this.start = start;
        this.finish = finish;
        this.pts = pts;
    }

    public int getPts() {
        return pts;
    }

    public void setPts(int pts) {
        this.pts = pts;
    }

    public String getGp() {
        return gp;
    }

    public void setGp(String gp) {
        this.gp = gp;
    }

    public int getStart() {
        return start;
    }

    public void setStart(int start) {
        this.start = start;
    }

    public int getFinish() {
        return finish;
    }

    public void setFinish(int finish) {
        this.finish = finish;
    }

    @Override
    public String toString() {
        return "Eredmeny{" + "gp=" + gp + ", start=" + start + ", finish=" + finish + ", pts=" + pts + '}';
    }
    
    
    
}
