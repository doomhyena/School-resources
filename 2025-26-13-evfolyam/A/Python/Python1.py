'''
Python:
    - kezdőbarát, univerzális nyelv
    - alapvizsga nyelv 
'''
---------------------
#egysoros kommentek
'''
többsoros
kommentek
'''
#---------------------
'''
Kód futtatása: 
       - Program: PyCharm
       - Weboldal: programiz.com --> Python compiler
'''
#---------------------
print("Hello világ") #kiíratás konzolra

#Változók létrehozása:
a = 5 #Egy "a" nevű változó, 5 értékkel
b = 7
c = a + b #c értéke 12 lesz
print(c)
d = 2.5 #tört érték 
e = b - a 
f = a * b
g = a / b 
print(e)
print(f)
print(g)

#Alternatív osztások:
x = 13
y = 5
print(x // y) #Y hány egészszer van meg X-ben (eredmény: 2)
    #A maradékot eldobjuk
print(x % y) #Az osztás után mennyi a maradék (eredmény: 3)
    #Az egész részt eldobjuk, csak a maradék érdekel
#---------------------
#Feladat: számítsuk ki a 3 szám átlagát.
a = 1.5
b = 4.8
c = 2.2
print((a+b+c)/3)
#---------------------
szám = 17
print(szám)
szám = szám + 3 #önmagát növeljük 3-mal
print(szám)
szám = szám + 5 #újra módosítom
print(szám) #A kiírás mindig az ottani aktuális éréket tükrözi (nem a legújabbat)
#---------------------
#Feladat: legyen 2 számunk. A 2. az hány %-a az 1.-nek?
a = 10.0
b = 3.0
#Az eredmény 30 kell hogy legyen:
print((b/a)*100)
#---------------------
'''
Feladat: 
    - tetszőleges szám
    - szorozzuk meg 5-tel 
    - osszuk el 2-vel
    - csak az egész számos eredmény érdekel        '''
a = 12
a = a * 5
a = a // 2
print(a)
#---------------------
'''
Feladat: 
        - tetszőleges tört szám 
        - szorozzuk meg önmagával
        - ebből vonjunk ki 1-et     '''
a = 7.45
a = a * a 
a = a - 1
print(a)
#---------------------
#Kerekítés:
#round(MitKerekítek,HányTizedesre)
a = 4.761
b = round(a) #egész számra kerekíti
c = round(a,2) #ez 2 tizedesre kerekíti
print(c)
#---------------------
'''
Feladat:
    - tetszőleges alap és osztó számértékek
    - vegyük az egész és maradék részeit az osztásnak
    - adjuk össze ezt a 2 ereményt
    - az összeget egész számra kerekítve írjuk ki   '''
a = 5
b = 10
egész = a // b
maradék = a % b
mo = egész + maradék
print(round(mo))
#---------------------
#Egész számmá alakítás: int() #mint integer
szám = 5.87
szám2 = int(szám)
print(szám2) #Ez 5 lesz 
#---------------------
#Legkisebb/legnagybb értékek keresése egy halmazban:
#min()
#max()
a = 5
b = 7
c = 9
print(min(a,b,c)) #5 lesz 
print(max(a,b,c)) #9 lesz 
#---------------------
'''
Feladat:
    - Egy változó, 4.758 értékkel 
    - Ebből készítünk 3 féle variánst
        egy int típusú érték 
        egy egy tizedesre kerekített verzió
        egy, ami önmaga marad egy új változóban
        ezek közül írassuk ki a legkisebbet '''
alap = 4.758
szám = int(alap)
tizedes = round(alap,1)
ujszam = alap
print(min(szám,tizedes,ujszam))
#---------------------
#Feladat: Legyen egy tetszőleges tört szám. Abból vonjuk ki az egész részt.
#Pl.: 5.4 --> 0.4 lesz
tört = 7.234
egész = int(tört)
mo = tört - egész
print(mo)
#---------------------
'''
Feladat: 13 és 25 értékek. Osszuk őket mindkét irányba.
         Adjuk össze a 2 eredményt, amit 1 tizedesre kerekítve kiírunk. '''
a = 13
b = 25
c = a / b 
d = b / a 
e = c + d
e = round(e,1)
print(e)
