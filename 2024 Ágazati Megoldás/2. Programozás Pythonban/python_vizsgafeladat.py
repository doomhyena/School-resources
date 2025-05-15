#   1.feladat
## A feladatban kért ékezetes betűket a változóneveknél mellőzöm,
# a programozási alapelvek szerint csak ASCII karaktereket használok a változónevekhez.
class Hazifeladat:
    def __init__(self,tantargy,tanar,beadas,temakor):
        self.tantargy=tantargy
        self.tanar=tanar
        self.beadas=int(beadas)
        self.temakor=temakor
    def __str__(self):
        print(f"A {self.tantargy} tárgyból {self.beadas} nap múlva esedékes a házifeladat beadása.")
    def seged(szoveg):
        szoveg=szoveg.split('/')
        return Hazifeladat(szoveg[0],szoveg[1],szoveg[2],szoveg[3])
fizika="Fizika/Példa Péter/3/A Coriolis-erő"
Hazifeladat.__str__(Hazifeladat.seged(fizika))

#   2.feladat

a=int(input("Adjon meg egy számot: "))
def muvelet(szam):
    szamlalo=0
    if szam%2==0:
        while szam!=1:      ##<---- A feladat leírása alapján elvégzendő műveletek végtelen ciklust eredményezhetnek,
                            # bizonyos értékek esetén(pl.:tízzel osztható számok)!
            szam/=2
            szamlalo+=1
        return szamlalo


    else:
        while szam!=1:      #<---- A feladat leírása alapján elvégzendő műveletek végtelen ciklust eredményeznek!
            szam=szam*3+1
            szamlalo+=1
        return szamlalo

print(muvelet(a))

import math as m

def muveletek(szam1,szam2):
    szam1_2=m.pow(szam1,3)
    szam2_2=abs(m.sqrt(szam2))
    if float(szam1_2)>=float(szam2_2*25):
        return True
    else:
        return False

print(muveletek(2,1))

forras=open("C:/Tóth Roland/!alapvizsga2024/2. Programozás Pythonban/feladat.txt","r",encoding="utf-8")
gyumolcs=forras.read()
gyumolcslista=["alma","körte","narancs","eper","banán","mandarin","citrom","dinnye"]
def GyumolcsE():
    if gyumolcs in gyumolcslista:
        return "Igen"
    else:
        return "Nem gyümölcs"


print(GyumolcsE())