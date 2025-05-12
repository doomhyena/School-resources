/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0129_2324_13a;


public class Gy0129_2324_13a {

    static int b = 20;
    public static void main(String[] args) {
        //<editor-fold defaultstate="collapsed" desc="Lista">
        /*        ArrayList <Integer> szamok = new ArrayList<>();
        szamok.add(17); //Hozzáadás a lista végére.
        szamok.add(0, 20); //Hozzáadás a megadott indexre.
        System.out.println(szamok);
        szamok.remove(0); //Kiveszi a nullás indexen lévő értéket.
        System.out.println(szamok);
        //        szamok.remove(17); Számot nem lehet érték alapján kivenni.
        //        System.out.println(szamok);
        Random rnd = new Random();
        for (int i = 0; i < 10; i++) {
        szamok.add(rnd.nextInt(100-10+1)+10);
        }
        System.out.println(szamok);
        System.out.println(szamok.get(3)); //Hármas index kiírása
        System.out.println(szamok.size()); //Lista mérete
        System.out.println(szamok.subList(2,7));
        //Tól ig határral megadjuk, hogy melyik elemeket írja ki.
        // Az utolsó indexet már nem fogja kiírni.
        szamok.set(1, 5); //Megváltoztatja az adott indexen lévő értéket.
        System.out.println(szamok);
        //Tartalmazás
        if (szamok.contains(17))
        System.out.println("17 benne van");
        else
        System.out.println("17 nincs benne");*/
//</editor-fold>
        //<editor-fold defaultstate="collapsed" desc="Metódusok">
        /*int a = 15;
        System.out.println("b elsőre: "+b);
        System.out.println("a értéke az első metódus futása előtt main-ben: "+a);
        metodus1();
        System.out.println("b első metódus után main-ben: "+b);
        System.out.println("a értéke az első metódus futása után main-ben:"+a);
        metodus2(a);
        System.out.println("a értéke a második metódus futása után main-ben:"+a);
        System.out.println("----------------------------");
        int vt = metodus3();
        System.out.println("3. metódus eredménye: "+vt);
        int vt2 = metodus4(a);
        System.out.println("4. metódus eredménye: "+vt2);*/
//</editor-fold>
        
    }

    private static void metodus1() {
        int a = 5;
        a*=2;
        b*=2;
        System.out.println("a értéke az első metódusban: "+a);
    }

    private static void metodus2(int szam) {
        szam*=2;
        System.out.println("szám értéke a második metódusban ('a' volt a paraméter): "+szam);
    }

    private static int metodus3() {
        int a = 5;
        a*=10;
        return a;
    }

    private static int metodus4(int szam) {
        return szam*2;
    }
    
}


