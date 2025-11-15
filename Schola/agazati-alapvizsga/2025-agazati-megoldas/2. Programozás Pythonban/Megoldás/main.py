import math

def feladat(n):
    print(f"{n}.feladat:")

"""
1.	Feladat: Osztályok
    a.	Készítsen egy Házifeladat nevű osztályt. Ez az osztály legyen képes kezelni a házifeladatokkal kapcsolatos adatokat, mint a tantárgy, tanár, hány nap múl-va esedékes a beadás, valamint a témakör.
    b.	Bővítse ki az osztály kódját egy segédmetódussal, amely az alábbi sablon pél-damondat szerint kiírja egy adott példány két tulajdonságát: „A matematika tárgyból 2 nap múlva esedékes a házifeladat beadása.”
    c.	Bővítse ki az osztály kódját egy olyan segédmetódussal is, amely lehetővé te-szi, hogy egy egybefüggő string szövegből is készíthessünk osztálypéldányokat. A metódus arra számítson, hogy a string-en belüli adatok ’/’ jelekkel vannak tagolva.
    d.	Példányosítsa ezt az osztályt, egy tetszőlegesen megadott darabbal.
"""


feladat(1)

class Házifeladat:
    def __init__(self, tantargy, tanar, napok, temakor):
        self.tantargy = tantargy
        self.tanar = tanar
        self.napok = napok
        self.temakor = temakor

    def kiir(self):
        print(f"A {self.tantargy} tárgyból {self.napok} nap múlva esedékes a házifeladat beadása.")

def from_string(adat):
    tantargy, tanar, napok, temakor = adat.split('/')
    return Házifeladat(tantargy, tanar, int(napok), temakor)

Házifeladat.from_string = staticmethod(from_string)

hazi = Házifeladat.from_string("Matematika/Kovács/2/Algebra")
hazi.kiir()

"""
2.	Feladat: Logika
    Itt a megoldások során nem kötelező az input parancs használata. Egyszerű metódus-paraméterként is bevihetők az értékek.
        a.	Írjon egy metódust, amely bekér egy számot. Vizsgálja meg, hogy ez a szám páros vagy páratan-e. Ha páros, akkor felezze meg. Ha páratlan, akkor szo-rozza meg hárommal, majd ehhez adjon hozzá egyet. Ez a művelet addig is-métlődön, amíg a változó értéke nem lesz pontosan 1. A metódus kimeneti ér-téke egy szám legyen, ami azt mutatja, hogy hányszor kellett a műveletet el-végezni, mire elértük az 1-et.
        b.	A Python matematikai modulját felhasználva készítsen egy metódust, amely bekér két számot a felhasználótól. Az első számot a harmadik hatványra eme-li, a másodiknak pedig a négyzetgyökét számítja ki. Egy művelet vizsgálja meg, hogy az első eredmény van-e 20-szor akkora, mint a második. Ezen mű-velet visszatérési értéke tetszőlegesen vagy True/False legyen, vagy pedig szöveges válasz.
"""


feladat(2)

def paros_paratlan_szam(szam):
    count = 0
    while szam != 1:
        if szam % 2 == 0:
            szam = szam / 2
        else:
            szam = szam * 3 + 1
        count += 1
    return count

szam = 7
eredmeny = paros_paratlan_szam(szam)

print(f"A művelet {eredmeny} alkalommal lett elvégezve, hogy elérjük az 1-et.")

def matematikai_muvelet(szam1, szam2):
    harmadik_hatvany = szam1 ** 3
    negyzetgyok = math.sqrt(szam2)

    if harmadik_hatvany == 20 * negyzetgyok:
        return True
    else:
        return False

szam1 = 2
szam2 = 8
eredmeny = matematikai_muvelet(szam1, szam2)

print(f"A művelet eredménye: {eredmeny}")

"""
3.	Feladat: Fájlkezelés.
    a.	Python paranccsal nyissa meg a pyForras.txt szövegfájlt.
    b.	Tárolja el egy ’gyumolcs’ nevű változóban a txt tartalmát.
    c.	Írjon egy ’GyümölcsE()’ metódust, amely megvizsgálja a ’gyümölcs’ változót, hogy a tartalom tényleg része-e az alább megadott gyümölcs listának. Gyümöcslista: alma, körte, narancs, eper, banán, mandarin, citrom, dinnye. Készítse el a listát.
    d.	Ha a fájlól beolvasott gyümölcsnév része a listának, akkor a visszatérési érték legyen ’Igen’, ha nem része, akkor legyen ’Nem gyümölcs’.
"""

feladat(3)

def GyumolcsE():
    gyumolcs_lista = ["alma", "körte", "narancs", "eper", "banán", "mandarin", "citrom", "dinnye"]

    fájl = open("pyForras.txt", "r")
    gyumolcs = fájl.read().strip()

    if gyumolcs in gyumolcs_lista:
        return "Igen"
    else:
        return "Nem gyümölcs"

    fájl.close()

print(GyumolcsE())

