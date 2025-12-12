/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1124_2223_14a;

/**
 *
 * @author wuncs.david
 */
public class Novel_Thread extends Thread{
    Szemely sz;

    public Novel_Thread(Szemely sz) {
        this.sz = sz;
    }

    @Override
    public void run() {
        while(sz.szam <1000){
            sz.szam++;
            System.out.println(sz);
        }
        System.out.println(sz.nev+" végzett.");
    }
    
    
}
