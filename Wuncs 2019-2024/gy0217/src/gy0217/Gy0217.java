/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0217;

import java.util.ArrayList;
import java.util.Collections;

/**
 *
 * @author wuncs.david
 */
public class Gy0217 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ArrayList<_13szoftver> kepzesek =
                new ArrayList<>();
        
        feltolt(kepzesek);
        kiir(kepzesek);
        //rendezes(kepzesek);
        //Rendezze a listát a képzés kezdése szerint.
        System.out.println("--Rendezés--");
        Collections.sort(kepzesek);
        kiir(kepzesek);
    }

    private static void feltolt(ArrayList<_13szoftver> lista) {
        ArrayList<Integer> evek = new ArrayList<>();
        _13szoftver k;
        for (int i = 0; i < 10; i++) {
            k = new _13szoftver("Szoftver"+i);
            while(evek.contains(k.kep_kezd))
                k = new _13szoftver("Szoftver"+i);
            evek.add(k.kep_kezd);
            lista.add(k);
        }
    }

    private static void kiir(ArrayList<_13szoftver> lista) {
        for (_13szoftver n : lista) {
            System.out.println(n);
        }
    }

    private static void rendezes(ArrayList<_13szoftver> lista) {
        _13szoftver csere;
        for (int i = 0; i < lista.size()-1; i++) {
            for (int j = i+1; j < lista.size(); j++) {
                if (lista.get(i).kep_kezd > lista.get(j).kep_kezd){
                    csere = lista.get(i);
                    lista.set(i, lista.get(j));
                    lista.set(j, csere);
                }
            }
        }
    }
    
}
