/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0116_2425_14a_grafmasodfok;

/**
 *
 * @author wuncs.david
 */
public class Egyenlet {
    private double a;
    private double b;
    private double c;

    public Egyenlet(double a, double b, double c) {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double getC() {
        return c;
    }

    public void setC(double c) {
        this.c = c;
    }

    public double getA() {
        return a;
    }

    public void setA(double a) {
        this.a = a;
    }

    public double getB() {
        return b;
    }

    public void setB(double b) {
        this.b = b;
    }
    
    public String megoldas (){
        double diszkr = b*b-4*a*c;
        
        if (diszkr > 0){
            double x1 = (-b+Math.sqrt(diszkr))/(2*a);
            double x2 = (-b-Math.sqrt(diszkr))/(2*a);
            return String.format("a: %.2f, b:%.2f, c:%.2f | x1: %.2f, x2: %.2f \n",a,b,c,x1,x2);
        }
        else if ( diszkr == 0){
            double x = (-b)/(2*a);
            return String.format("a: %.2f, b:%.2f, c:%.2f | x: %.2f  \n",a,b,c,x);
        }
        else
            return String.format("a: %.2f, b:%.2f, c:%.2f | Nincs valós megoldás  \n",a,b,c);
    }
}
