#Python összefoglalás - Osztályok:

#Osztály séma:
class Osztálynév:
    #Az osztályon belül mindig az __init__ függvénnyel kezdünk:
    def __init__(self, tulajdonság1, tulajdonság2, ...): #a self után szerepel az összes tulajdonság
        self.tulajdonság1 = tulajdonság1 #tulajdonságok "megerősítése"
        self.tulajdonság2 = tulajdonság2
        ... #ezt megcsináljuk az összes fent felsorolt tulajdonsára
    #Az __init__ után jöhet a többi segédfüggvény:
    def segédfüggvényNeve(self):
        valamilyen művelet az osztállyal kapcsolatban

#Osztály pldányosítása (létrehozok egy konkrét példányt ezzel az osztálytípussal):
példány1 = Osztálynév(konkrét tulajdonságok felsorolása)
    #ez már nem az osztály része, a példányosítás az külön művelet
print(példány1.tulajdonságNeve) #a példány egyik adatát kiíratom
print(példány1.segédfüggvényNeve()) #segédfüggvény meghívása az adott példányra
#-----------------------------------
'''
Példa1: Alkalmazott osztály, amelynék a vezeték- és keresztnevet kell megadni.
Ő ebből fog egy további teljes név és email cím tulajdonságot is generálni.
'''
class Alkalmazott:
    def __init__(self,vezetek,kereszt): #a 2 kellő tulajdonság felsorolása, megfelelő sorrendben
        self.vezetek = vezetek
        self.kereszt = kereszt
        #Teljes név generálása a 2 megadott névtag alapján:
        self.teljes = '{} {}'.format(vezetek,kereszt)
        #Email cím generálása (vezeteknev.keresztnev@email.com):
        self.email = '{}.{}@email.com'.format(vezetek,kereszt).lower()
#Készítsünk egy példányt:
alk1 = Alkalmazott('Kovács','Béla')
#Kiíratom az újonnan generált példány nevét:
print(alk1.email)
#-----------------------------------
#Példa2:
class Katona:
    #Nyilván akarjuk tartani egy segédváltozóval, hogy hány Katona osztálypáldányt generáltunk:
    katonaszam = 0
    #Tulajdonságok definiálása az init függvénnyel (név, kor, magasság, súly):
    def __init__(self,nev,kor,mag,suly):
        self.nev = nev
        self.kor = '{} év'.format(kor) #Így pl. '30' helyett '30 év' lesz a tárolt adat.
        self.mag = '{} cm'.format(mag) #Így pl. '180' helyett '180 cm' lesz a tárolt adat.
        self.suly = '{} kg'.format(suly) #Így pl. '90' helyett '90 kg' lesz a tárolt adat.
        #A generált példányokat számoló segédérték is nőjön 1-el az init függvény részeként:
        Katona.katonaszam += 1
    #Ez a segédfüggvény kiírja a katona nevét és korát egy sablonmondatban:
    def kiir(self):
        return '{} jelentkező {} éves.'.format(self.nev, self.kor)
                    #A megadott sorrend alapján az 1. {} helyére a név, a 2. {} helyére a kor értéke kerül.
    #Ez a segédfüggvény lehetővé teszi, hogy egy ':' jelekkel tagolt string alapján is lehessen példányosítani:
    def kpontbol(adat): #a meghíváskor az adat tartalma pl. 'Béla:30:180:90' lesz
        nev,kor,mag,suly = (adat).split(':') #megadom, hogy a ':' jelzi a tagolást
        return Katona(nev,kor,mag,suly) #Példányosítok az újonnan talált értékekből

#A példányosítást és a kiíratást nem kell betabulátorozni, mert már nem az osztály része:
katona1 = Katona.kpontbol('Béla:30:180:90') #Példányosítok a kettőspontos függvénnyel
print(katona1.mag) #kiíratom az új katona magasságát (a megjelenő eredmény: '180 cm' lesz).
#---------------------------------
Tehát tudni kell:
    - alaposztályt létrehozni
    - különböző adatokat kiíratni sablonmondatba fogalmazva
    - biztosítani, hogy valamilyen karakterrel tagol string alapján is lehessen példányosítani
    - legalább 1 konkrét példányt készíteni az osztályból
