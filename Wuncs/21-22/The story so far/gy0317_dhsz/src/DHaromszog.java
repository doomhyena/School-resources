/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Wuncs.David
 */
class RosszSorrend extends Exception{

    @Override
    public String toString() {
        return "RosszSorrend";
    }
    
}

class NemHaromszog extends Exception {

    @Override
    public String toString() {
        return "NemHaromszog";
    }
    
}

class NemDerek extends Exception {

    @Override
    public String toString() {
        return "NemDerek";
    }
    
}


public final class DHaromszog {
    private double aOldal;
    private double bOldal;
    private double cOldal;

    public double getA() {
        return aOldal;
    }

    public void setA(double a) {
        this.aOldal = a;
    }

    public double getB() {
        return bOldal;
    }

    public void setB(double b) {
        this.bOldal = b;
    }

    public double getC() {
        return cOldal;
    }

    public void setC(double c) {
        this.cOldal = c;
    }
    
    private boolean EllHsz(){
        return this.getA()+this.getB()>this.getC() && this.getA()+this.getC()>this.getB() && this.getB()+this.getC()>this.getA();
    }
    
    private boolean EllSor(){
        return this.getA()<=this.getB() && this.getB()<=this.getC();
    }
    
    private boolean EllDerek(){
        return Math.pow(this.getA(), 2)+Math.pow(this.getB(), 2) == Math.pow(this.getC(), 2);
    }

    @Override
    public String toString() {
        return "a: "+aOldal + ", b: " + bOldal + ", c: " + cOldal;
    }
    

    public DHaromszog(String sor) throws RosszSorrend, NemHaromszog, NemDerek {
        String [] adatok = sor.split(" ");
        this.setA(Double.parseDouble(adatok[0]));
        this.setB(Double.parseDouble(adatok[1]));
        this.setC(Double.parseDouble(adatok[2]));
        
        if (!EllSor()) throw new RosszSorrend();
        if (!EllHsz()) throw new NemHaromszog();
        if (!EllDerek()) throw new NemDerek();
    }
    
    
}
