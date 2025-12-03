#Python
    - vizsgatárgy
    - általános felhasználás
    - viszonylag kezdőbarát
-------------------------------------
#Egysoros komment
'''
többsoros
komment
'''
'''
print("Hello világ") #konzolra kiíratás
#Változók létrehozásánál nem kell megadni adattípust/elérhetőséget:
a = 5 #Egy "a" nevű változó, 5 értékkel
b = 7
c = a + b #tárolt érték: a művelet eredménye
print(c)
d = 2.5 #tört szám
e = b - a 
f = (e * a)
g = (a / d)
print(e)
print(f)
print(g)
'''
#Alternatív osztások (csak egész vagy maradék rész nézése):
x = 13
y = 5
print(x // y) #Y az hány egészszer van meg X-ben (2)
print(x % y) #Az osztás után mennyi a maradék (3)
-------------------
a =1.5
b = 4.8
c = 2.2
#Számítsuk ki az átlagukat.
atlag = (a + b + c) / 3
print(atlag)
-------------------
szam = 17
szam = szam + 3 #önmagát növeli 3-mal 
print(szam)
szam = szam + 5 #újra növelem, ezuttal 5-tel 
print(szam)
-------------------
Feladat: 2 szám, a 2. az hány %-a az 1.-nek?
a = 10.0
b = 3.0
#Az eredmény 30 kell legyen
print((b/a)*100) #0.3 = 30%
-------------------
Feladat:
    Legyen egy alapérték (tetszőleges szám).
    Szorozzuk meg 5-tel, az eredményt pedig osszuk el 2-vel.
    Az eredménynek csak az egész része érdekel.
szám = 10 #tetszőleges érték létrehozása
szám = szám * 5 #szorzás 5-tel
szám = szám // 2 #osztás 2-vel, de csak az egész részt tárolja
print(szám) #eredmény kiírása
-------------------
Feladat: 
    Tetszőleges tört szám.
    Szorozzuk meg önmagával.
    Vonjunk ki belőle 1-et.
a = 7.5
b = a * a
c = b - 1
print(c)
-------------------
#Kerekítés:
    - round()
a = 4.671
b = round(a) #egész számra való kerekítés
c = round(a,2) #kerekítés két tizedes jegyre (4.67 lesz)
#Séma: round(MitKerekítek,HányTizedesre)
print(a)
print(b)
print(c)
-------------------
#Feladat:
   # - nézzük külön a szám osztás utáni egész és maradék részét
   # - adjuk össze ezt a 2 ereményt 
   # - jelenjen meg egészre kerekítve
szám = 44 #alapérték 
osztó = 7 #ezzel osztjuk
egészrész = szám // osztó 
törtrész = szám % osztó 
osszeg = egészrész + törtrész
osszeg = round(osszeg)
print(osszeg)
-------------------
Egész számmá konvertálás: int() #ez a tizedes rész levágása
szám = 5.99
szám2 = int(szám) #így szám2 az 5 lesz 
-------------------
Legnagyobb/legkisebb értékek keresése:
a = 3
b = 7
c = 9
print(max(a,b,c)) #kikeresi a 3 közül a legnagyobbat és azt írom ki 
print(min(a,b,c)) #legkisebb értékre szűr
-------------------
Feladat: változó, 4.75 értékkel. Ebből készítsünk 3 féle variánst:
    - 1, ami int-ként van értelmezve
    - 1, ami egy tizedesre van kerekítve 
    - 1, ami önmaga marad 
    - Írassuk ki ezek közül a legkisebb értékűt
#Az alapváltozók:
alap = 4.75
számként = int(alap)
tizedes = round(alap,1)
önmaga = alap
#Legkisebb kiíratása:
print(min(számként, tizedes, önmaga))
