#Python listák

gyümölcsök = ["alma","körte","barack","szilva"]
print(gyümölcsök)
print("Elemek száma: ", len(gyümölcsök))
print("Első elem: ", gyümölcsök[0])
print("Második elem: ", gyümölcsök[1])
print("Utolsó elem: ", gyümölcsök[-1])
gyümölcsök[2] = "cseresznye"
print(gyümölcsök[2])
gyümölcsök.append("narancs") #Új elem hozzáfűzése a lista végére
print(gyümölcsök)
del gyümölcsök[0] #Első elem törlése
print(gyümölcsök)
#-------
print("A lista elemei egyenként:")
for gyümölcs in gyümölcsök:
    print(gyümölcs)
#-------
print("Alternatív séma, indexekkel:")
for i in range(len(gyümölcsök)):
    print(i, gyümölcsök[i])
#range(): kiterjedés (mettől meddig menjen)
#---------------------------
'''Feladat: 3 tetszőleges város a listában.
    - A 2. elem kiírása
    - Hozzáadni egy várost
    - Kicserélni a 3.-at egy újra
    - Hány elem van a listában
    - Az első és utolsó város törlése után listázzuk ki
    - Kiírni az utolsó előtti városnevet
'''
városok = ["Budapest","Pécs","Szeged"]
print(városok[1])
városok.append("Győr")
városok[2] = "Debrecen"
print(len(városok))
del városok[0]
del városok[-1]
print(városok[-2])
#---------------------------
számlista = [2,4,6,8,10,12]
#Harmadik elem kétszerese:
#Az utolsó elem átvitele az első helyére:
#Jelenjenek meg azon számok egymás alá, amelyek
#   maradék nélkül oszthatók 3-mal:
print(számlista[2] * 2)
számlista[0] = számlista[-1]
del számlista[-1]
for szám in számlista:
    if szám % 3 == 0:
        print(szám)
#---------------------------
#Leghosszabb elem keresése:
szavak = ["asztal","ég","ház","ember","kontinens"]
leghosszabb = szavak[0]
for szo in szavak:
    if len(szo) > len(leghosszabb):
        leghosszabb = szo
print(leghosszabb)
#---------------------------
#Listaszámok összege:
altSzámlista = [2,4,6,8,10,12,16]
összeg = 0
for szam in altSzámlista:
    összeg += szam
print(összeg)
#---------------------------
#Írjuk ki a legnagyobb számot:
altSzámlista2 = [2,40,60,8,10,12,16]
maxszam = altSzámlista2[0]
for szam in altSzámlista2:
    if szam > maxszam:
        maxszam = szam
print(maxszam)
#---------------------------
szavak = ["asztal","ég","ház","ember","kontinens"]
#Csak azok kellenek, amikben van "e" betű
for szo in szavak:
    if "e" in szo:
        print(szo)
#---------------------------
'''
Feladat:
    - Legyen egy 5 elemű számlista.
    - Igaz-e, hogy minden elem páros?
    - (kell: for, if, segédváltozó)
'''
ujLista = [2,4,6,7,8]
mind_paros = True
for szam in ujLista:
    if szam % 2 != 0:
        mind_paros = False
if mind_paros: #itt lehagyható az "== True" rész
    print("Minden szám páros")
else:
    print("Van köztük páratlan")
