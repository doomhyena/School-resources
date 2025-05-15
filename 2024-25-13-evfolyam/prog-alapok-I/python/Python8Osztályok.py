#Ez az osztály tárolja az alkalmazott nevét, id-jét, fizetését és részlegét.
#Lehet vele fizetést számolni, részleget váltani és adatot kiírni.
class Alkalmazott:
    def __init__(self,nev,id,fizetes,reszleg):
        self.nev = nev
        self.id = id
        self.fizetes = fizetes
        self.reszleg = reszleg
    #Ez a segédmetódus kiszámolja a fizetést (a túlórákat is figyelembe veszi):
    def fizuszámol(self,fizetes,ledolgozott_orak):
        tulora = 0
        #Az 50 óra feletti órákra kapjon túlóradíjat:
        if ledolgozott_orak > 50:
            tulora = ledolgozott_orak - 50
        self.fizetes = self.fizetes + (tulora * (self.fizetes/50))
        print(self.fizetes)
    #Lehessen részleget váltani:
    def reszlegcsere(self,alk_reszleg):
        self.reszleg = alk_reszleg
        #self.reszleg: az eredeti, alk_reszleg: az új megadott érték
    #Egy segédmetúdus írja ki az alkalmazott adatait, de minden infót külön sorba:
    def adatkiir(self):
        print("\nNév: ", self.nev) #\ jel: AltGr+q
        print("\nID: ", self.id)
        print("\nFizetés: ", self.fizetes)
        print("\nRészleg: ", self.reszleg)
        print("\n------------------------")
#-----
#Példányosítás:
alkalmazott1 = Alkalmazott("Adam",1,300000,"IT")
alkalmazott2 = Alkalmazott("Bela",2,330000,"HR")
alkalmazott3 = Alkalmazott("Csaba",3,340000,"Marketing")
alkalmazott4 = Alkalmazott("Dezso",4,400000,"Sales")
#Adatok kiíratása a segédmetódussal:
alkalmazott1.adatkiir()
#Részleg megváltoztatása:
alkalmazott2.reszlegcsere("Vezetőség")
alkalmazott2.adatkiir() #ellenőrzés
#Fizetés számolása:
alkalmazott3.fizuszámol(340000,60)
#------------------------------------------------------------------------------
#Éttermes osztály, előre definiált változók nélkül:
class Etterem:
    #Példányosításkor majd nem kell beírni semmit, de ő generál magának 3 dolgot:
    def __init__(self):
        self.menu_etelek = {} #az étlap egy kezdetben üres szótártömb lesz
        self.asztalfoglalas = [] #lefoglalt asztalok számai kerülnek bele
        self.rendelesek = {}
    #Étlap feltöltése a választékkal (étel neve + ára):
    def menu_felvisz(self,etel,ar):
        self.menu_etelek[etel] = ar
    #Foglalások felvétele:
    def foglalasok(self,asztal_szam):
        # az asztalfoglalások listához fűzzük az új számot
        self.asztalfoglalas.append(asztal_szam)
    #Jelenjen meg az étlap tartalma:
    def etlap_kiir(self):
        for etel, ar in self.menu_etelek.items():
            print("{}: {} forint".format(etel,ar)) #(Fogás neve: Ár forint)
        #2 változó kell a for ciklusba, mert értékpárokon megy végig
        #items(): "elemek"
    #Egy segédfüggvény írja ki az eddigi foglalásokat:
    def asztalf_kiir(self):
        for asztal in self.asztalfoglalas:
            print("Asztak: {}".format(asztal))
    #Függvény a rendelések megjelenítésére:
    def rendeles_kiir(self):
    #Közben a rendelések listája át lett alakítva szótárrá
        for rendeles in self.rendelesek:
            print("Asztal {}: {}.".format(rendeles['asztal_szam'], rendeles['rendeles']))
#----
#Példányosítás:
etterem1 = Etterem()
#Étlap feltöltése:
etterem1.menu_felvisz("Hamburger",1000)
etterem1.menu_felvisz("Pizza",1500)
etterem1.menu_felvisz("Kóla",500)
#Foglaljuk le az első 3 asztalt:
etterem1.foglalasok(1)
etterem1.foglalasok(2)
etterem1.foglalasok(3)
#Étlap megjelenítése:
etterem1.etlap_kiir()
#-----------------------------------------------------------------------------------------------------
'''
Az osztály egy banki ügyfél adatait tárolja:
    - számlaszám, számlanyitás dátuma, egyenleg és az ügyfél neve
Lesz 4 segédfüggvény:
    - Egyenleg lekérdezése (pl.: "Jelenlegi egyenleg: X forint.")
    - Pénz berakása a számlára
    - Pénz kivtele a számláról (ha nincs annyi, azt külön üzenet jelezze)
    - Ügyféladatok részletes kiírása (mindet külön sorba)
'''
class BankUgyfel:
    def __init__(self,szlaszam,nyitasdatum,egyenleg, nev):
        self.szlaszam =szlaszam
        self.nyitasdatum = nyitasdatum
        self.egyenleg = egyenleg
        self.nev = nev
    def berak(self, osszeg):
        self.egyenleg += osszeg
        print(f"{osszeg} forint lett berakva.")
    def kivesz(self,osszeg):
        if osszeg > self.egyenleg:
            print("Nincs elég pénzed ehhez.")
        else:
            self.egyenleg -= osszeg
            print(f"{osszeg} forint lett kivéve.")
    def lekerdez(self):
        print(f"Jelenlegi egyenleg: {self.egyenleg} forint.")
    def reszletezes(self):
        print("\nNév: ", self.nev)
        print("\nSzámlaszám: ", self.szlaszam)
        print("\nNyitás dátuma: ", self.nyitasdatum)
        print("\nEgyenleg: ", self.egyenleg, " forint")
#-------
#Példányosítás és a függvények tesztelése:
ugyfel1 = BankUgyfel(1234,"01-01-2024",1000000,"Ernő")
ugyfel1.lekerdez()
ugyfel1.reszletezes()
ugyfel1.berak(10000)
ugyfel1.kivesz(2000000)
#-------------------------------------------------------------------------
'''
Egy leltárhoz készítünk határozatlan tartalmú osztályt. 
3 segédfüggvény lesz: leltárbővítés, meglévő elem módosítása és a termékek listázása. 
'''
class Leltar:
    def __init__(self):
        self.leltar = {} #létrehoz egy üres szótártömböt
    #Utólag rakjuk bele a tartalmat: id, megnevezés, darabszám és ár (+a konkrét értékek)
    #Új termék hozzáadása a leltárhoz:
    def hozzaad(self,elem_id,megnevezes,darabszam,ar):
        #Felviszünk egy új összetett elemet a szótárba
        self.leltar[elem_id] = {"Név":megnevezes, "Darabszám":darabszam, "Ár":ar}
    #Már meglévő termék adatainak módosítása:
    def frissit(self,elem_id, darabszam, ar):
        if elem_id in self.leltar: #ha van ilyen id-jű elem...
            #...akkor módosuljanak a szótárelem adott szegmensei:
            self.leltar[elem_id]["Darabszám"] = darabszam
            self.leltar[elem_id]["Ár"] = ar
        else: #Ha nem találta az id alapján:
            print("Nincs ilyen termék a leltárban.")
    #Segédmetódus, ami listázza 1 db termék adatait:
    def megnez(self,elem_id):
        #Ha van ilyen id-jű elem:
        if elem_id in self.leltar:
            elem = self.leltar[elem_id]
            return f"Terméknév: {elem["Név"]}, Darabszám: {elem["Darabszám"]}, Ár: {elem["Ár"]}"
        else:
            print("Nincs ilyen elem.")
#-------
leltar1 = Leltar()
leltar1.hozzaad("I001","Laptop",100,200000)
print(leltar1.frissit("I001",80,150000))
print(leltar1.megnez("I001"))
