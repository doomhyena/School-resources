/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy1122_2223_14b;

/**
 *
 * @author wuncs.david
 */
public class Novel extends Thread{
    Szemely sz;

    public Novel(Szemely sz) {
        this.sz = sz;
    }

    @Override
    public void run() {
        while(sz.szam<10){
            sz.szam++;
            System.out.println(sz);
        }
        System.out.println(sz+" eljutott 10-ig.");
        while(sz.szam<100){
            sz.szam++;
            System.out.println(sz);
        }
        System.out.println(sz+" eljutott 100-ig.");
        while(sz.szam<1000){
            sz.szam++;
            
        }
        System.out.println(sz+" eljutott 1000-ig.");
    }
    
    
        
}
