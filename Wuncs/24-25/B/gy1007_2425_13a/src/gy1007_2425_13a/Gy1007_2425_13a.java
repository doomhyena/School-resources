package gy1007_2425_13a;
import java.util.Random;


public class Gy1007_2425_13a {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Random rnd = new Random();
        
        double a = rnd.nextInt(100-10+1)+10; //10-100
        
        double b = rnd.nextInt(100-10+1)+10;
        double c = rnd.nextInt(100-10+1)+10;
        
        if (a+b>c && a+c>b && b+c>a){
            double ker = a+b+c;
            double s = ker/2;
            double ter = Math.sqrt(s*(s-a)*(s-b)*(s-c));
            //ter = Math.pow(s*(s-a)*(s-b)*(s-c),0.5);
            System.out.println("Ker: "+ker);
            System.out.println("Ter: "+ter);
            
        }
        else{
            System.out.println("Ilyen háromszög nincs!");
        }
        
        //Kör
        double r = rnd.nextInt(100-80+1)+80;
        
        if (r  !=  0){
            double kker = 2*r*Math.PI;
            double kter = r*r*Math.PI;
            System.out.println("Ker: "+kker);
            System.out.println("Ter: "+kter);
        }
        else{
            System.out.println("Hibás adat!");
        }
        
        double d = rnd.nextInt(30-20+1)+20;
        double e = rnd.nextInt(30-20+1)+20;
        
        if (e == d){
            System.out.println("Ez egy négyzet!");
            double nker = 4*d;
            double nter = e*e;
            System.out.println("Ker: "+nker);
            System.out.println("Ter: "+nter);
        }
        else{
            System.out.println("Ez egy téglalap!");
            double nker = 2*(d+e);
            double nter = d*e;
            System.out.println("Ker: "+nker);
            System.out.println("Ter: "+nter);
        }
        
    }
    
}
