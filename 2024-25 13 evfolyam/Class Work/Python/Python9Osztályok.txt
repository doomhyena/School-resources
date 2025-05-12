#1. feladat:
class Zeneszerzo:
    zszerzo = 0 #a példányok számlálója lesz
    def __init__(self,nev,orszag,mufaj):
        self.nev = nev
        self.orszag = '{}i régió'.format(orszag) #Így másképp fog megjelenni a tárolt adat
        self.mufaj = mufaj
        Zeneszerzo.zszerzo += 1 #Ezzel felszámoljuk az új példányokat

zsz1 = Zeneszerzo('XY','Magyarország','Rock') #példányosítás
print(zsz1.orszag) #ellenőrzés
#----------------------------------------
#2. feladat:
class Szamolo:
    def __init__(self, szam):
        #A generált tulajdonságok azt tárolják majd,
        #hogy az adott szám hány egésszer van meg a bevitt értékben:
        self.egyesek = szam
        self.harmasok = szam//3 #3-mal osztás egész része kell csak
        self.kilencesek = szam//9
    def kiirat(self):
        return f"Egyesek:{self.egyesek}, hármasok: {self.harmasok}, kilencesek: {self.kilencesek}."

ertek1 = Szamolo(12)
print(ertek1.kiirat())
#----------------------------------------
'''
A kedvenc ételek osztálya tárolni fogja az emberünk nevét, kedvenc ételeit 
és a nem szeretett ételeit. Egy segédfüggvény kérjen be egy fogást és 
döntse el, hogy az emberünk szereti-e azt.
'''
class KedvencEtel:
    def __init__(self,nev,szeret=[],nemszeret=[]):
        self.nev = nev
        self.szeret = szeret
        self.nemszeret = nemszeret
    #fent az '=[]' jelöli, hogy lista formátumú lesz az a változó
    #Egy külön ételről sablonmondatban megállapítjuk, hogy hogyan viszonyul hozzá az emberünk:
    def izlés(self,kaja):
        #A szöveg első fele mindenképp egyezik:
        szoveg = '{} {}-t eszik és '.format(self.nev,kaja)
        #A szöveg második fele pedig itt dől el:
        if kaja in self.szeret:
            return szoveg + 'szereti azt.'
        elif kaja in self.nemszeret:
            return szoveg + 'és ki nem állhatja.'
        else:
            return  szoveg + '!'
#Példányosítás és ellenőrzés:
evo1 = KedvencEtel("Béla",["rizs","alma"],["brokkoli","répa"])
print(evo1.izlés("alma"))
