/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1122_2223_14b_2;

/**
 *
 * @author wuncs.david
 */
public class Random_Thread extends Thread {
    int a;
    int f;
    int szam;
    boolean stop = false;

    public Random_Thread(int a, int f) {
        this.a = a;
        this.f = f;
    }

    @Override
    public void run() {
        for (int i = a; !stop; i++) {
            szam = i;
            
            if (i == f)
                i = a;
        }
        System.out.println(szam);
    }
    
    
}
