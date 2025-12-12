/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1128_2425_14a_jackie_graf;

/**
 *
 * @author wuncs.david
 */
public class Jackie {
    
    private int poles;
    private int year;
    
    private int races;
    
    private int wins;
    
    private int pods;
    
    private int fastest;

    public Jackie(int year, int races, int wins, int pods, int poles, int fastest) {
        this.year = year;
        this.races = races;
        this.wins = wins;
        this.pods = pods;
        this.poles = poles;
        this.fastest = fastest;
    }

    @Override
    public String toString() {
        return year+"";
    }

    public int getFastest() {
        return fastest;
    }

    public void setFastest(int fastest) {
        this.fastest = fastest;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public int getRaces() {
        return races;
    }

    public void setRaces(int races) {
        this.races = races;
    }

    public int getWins() {
        return wins;
    }

    public void setWins(int wins) {
        this.wins = wins;
    }

    public int getPods() {
        return pods;
    }

    public void setPods(int pods) {
        this.pods = pods;
    }

    public int getPoles() {
        return poles;
    }

    public void setPoles(int poles) {
        this.poles = poles;
    }
    
    
}
