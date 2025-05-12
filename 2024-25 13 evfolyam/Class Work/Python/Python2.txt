#Metódus felépítése:
'''def metódusnév(paraméterek):
    Érdemi műveletek kódja
    return eredményváltozó

print(metódusnév(KonkrétÉrtékek))
#----------------------
#Magyarázat:
def         - metódus kezdése (definiálás)
metódusnév  - érdemes beszédes módon elnevezni
paraméterek - milyen bekért értékekkel akarunk dolgozni. Változók jönnek létre a bemeneti értékek tárolására.
Érdemi kód  - tabulátorozásra figyelni kell
return      - a metódus mindig egy ilyennel végződik, mert ez íratja majd ki az eredmány változóját.
print(...)  - nem a metódus része (ezt az is mutatja, hogy ez már sor elején kezdődik). Itt csak ívatkozunk rá.
#----------------------------------------

Lista rendezése növekvő sorba:  sorted(listanév)
Új elem a lista végére:         listanév.append(ÚjElem)

A metódus egy számlistát vizsgál és visszaadja a lista ismétlődő elemeit.
def ismétlődők(lista):
    egyediek = [] #ebbe gyűlnek majd az egyedi számok
    ismétlődők = [] #ebbe gyűlnek majd a többször előforduló számok
    for i in lista: #végigmegyünk a lista számain
        if i not in egyediek: #"Ha az adott szám nincs benne az egyediek listában"
            egyediek.append(i) #akkor kerüljön bele
        else: #egyéb esetben (tehát, ha benne volt...)
            ismétlődőd.append(i) #akkor az ismétlődő számok listájába kerül
    #Az új if már a for cikluson kívül van:
    if len(ismétlődők) > 0: #Ha az "ismétlődők" lista hossza nagyobb mint 0... (tehát van tartalma, nem üres):
        return sorted(ismétlődők) #akkor sorba rendezve visszakérjük
    else: #Máskülönben egy "semmilyen" értéket adjon vissza (formaiság)
        return None
#----------------------------------------------

len()
indexelés:  listanév[indexsorszám] #1. elem = 0. index
Össze akarjuk adni egy számlista mindex x-edik elemét.
Pl.: print(xösszeg([1,2,3,4,5,6,7],2)) #--> 12

def xösszeg(lista,x):
    segéd = 1 #ez számlja majd, hogy a legutóbbi összeadás után hol járunk
    összeg = 0 #a megoldás lesz
    for i in lista:
        if segéd == x: #ha a segédváltozó elért az x. elemhez
            összeg += i #akkor az x. elem értéke hozzáadódik a MO-hoz 
            segéd = 0 #a számláló pedig visszaáll, hogy újra elszámolhassunk a következő x. elemig
        segéd += 1
    return összeg
#---------------------------------------
A vizsgált szám felírható-e 2 egymást követő egész szám összegeként?
    Értelmezés: a páratlan számokra igaz a leírás.
Pl.: print(felírható(9)) --> True
def felírható(n):
    if n%2 == 1: #Ha n osztva 2-vel maradéka 1" (tehát páratlan szám)
        return True #Akkor Igaz értéket adunk vissza
    else: #Egyéb esetben (tehát páros szám esetén) Hamis lesz a megoldás
        return False
#-----------------------------------------
A metódus vesz két számot és így számol: X osztva 2 az Y-adikonnal.

def osztás1(x,y):
    return x / (2**y)
    #magába a return műveletbe is írhatunk számolásokat
    # ** :  hatványozás
    #/ jel: sima osztás
#--- Bővítés - az eredményt kerekítse lefelé:
def osztás2(x,y):
    return x // (2**y)
    #// osztás: csak az egész részt nézi (teháta "%" ellentéte)
#---Oldjuk meg a matematika modullal:
from math import floor #"matek modulból imortálja a floor műveletet"
def osztás3(x,y):
    return floor(x/2**y)
    #floor(): lefelé kerekít egész számra
#------------------------------------------------
Feladat: A metódus egy számlistát vizsgál. 
Végeredmény: a számok összege.
Viszont, ha szerepel az 5, akkor a valódi összegtől fügetlenül 0 legyen a végeredmény.'''
def számoló(lista):
    összeg = 0 #ebbe fog gyűlni az összeg
    for i in lista: #végigmegy a lista számain
        if i == 5: #Ha az aktuális szám az épp 5
            return 0 #akkor megszakad a ciklus és 0-val zárul a metódus
        összeg += i #egyébként meg tövább jön erre
    return összeg #itt a for-on kívül visszakérjük az összeget
#A def-en kívül meghívom a metódust egy konkrét példára:
print(számoló([1,2,3,4,5]))
#-----------------------------------------------
#sorted(listanév): lista növekvő sorrendbe rendezése
#round(számérték): egész számra kerekítés
'''A metódus adja vissza a számlista mediánját.
Median: sorbarendezés után a középső elem 
    (páros elemszám esetén a két középső átlaga).'''
def medián(lista):
    hossz = len(lista) #eltárolom, hogy hány számból áll a lista
    rendezett = sorted(lista) #növekvőbe rendezem
    if (hossz % 2 == 1): #"Ha páratlan elemszámú a lista"
    #(Tehát ha 2-vel való osztás maradéka 1 lett)
        return rendezett[hossz//2] #Akkor visszakérem a középső elemet
    else: #páros elemszám esetén a 2 középső elem átlaga kell
        x1 = rendezett[hossz//2] #egyik középső elem
        x2 = rendezett[hossz//2+1] #másik középső elem
#A [] jelekben a "rendezett" lista adott sorszámú elemére hívatkozok
        x3 = (x1 + x2) / 2 #átlagolás
        return round(x3,1) #visszakérés, 1 tizedes pontossággal
#------------------------------------
'''
Abszolútérték: levesszük az esetleges negatív előjelet a számról
Pl.: abs(-4) --> 4 lesz belőle; abs(3-7) --> 4
Változótípus konvertálása:
str(változó) --> string (szöveg) típussá alakítás
int(változó) --> int (szám) típussá alakítás
Két számot vizsgálunk. A metódus összegzi az adott helyen lévő számjegyek különbségeit. Pl.: jegykül(234,489) --> 12 (2+5+5=12)'''

def jegykül(szám1,szám2): #2 paraméter, mert 2 szám kell
    összeg = 0 #ebbe számoljuk a jegyek különbségét
    #ahhoz, hogy egyenként belenézzünk a számjegyekbe, szöveggé kell alakítani mindkét számot:
    alt1 = str(szám1)
    alt2 = str(szám2)
    #A for ciklus annyiszor fusson le, ahány jegy van a számokban (bármelyikre hívatkozhatok, mert úgyis egyforma hosszúak):
    for i in range(len(alt1)):
        #Itt megnézem a 2 számnál az ugyanott lévő (ugyanannyiadik) jegy értékének a különbségét:
        összeg += abs(int(alt1[i]) - int(alt2[i]))
        #Ahhoz, hogy matekozzak, vissza kellett alakítanom int típusúvá
    return összeg #a ciklus végeztével visszakérem az összeget
#---------------------------------------------
'''A metódus egy számlistában fog akkumulatív összegeket számolni.
Pl.: [1,2,3,4] --> [1,3,6,10]'''

def akkumulativ(lista):
    if len(lista) == 0: #Ha üres (0 elemű) listát kap
        return [] #Akkor az eredmény is üres lista legyen
    else: #Itt lesz a feladat érdemi része:
        megoldás = [] #ebbe rakom majd be az összegeket
        összeg = 0 #segédváltozó
        for i in lista:
            összeg += i #összeg-et megnövelem az aktuális listaelem értékével
            megoldás.append(összeg) #és hozzáfűzöm a megoldáslista végéhez
    return megoldás
#---------------------------------------------
"VAGY" feltétel: amikor az if-ben egyszerre több feltételt adok meg, akkor elég, ha az egyik teljesül.
Pl.:
a = 7
if (a > 3) or (a < 1):
    return a
#Itt az első feltétel teljesült és az elég
#---
#Logikai tagadás:
#(jele: !=  "Nem egyenlő")
b = 8
if b != 3: #"Ha b értéke nem egyenlő 3-mal..."
    return b
#---
A metódus azt nézi meg, hogy az adott számlista átrendezhető-e egy egyesével növekvő számsorba.

def folynöv(lista):
    rendezett = sorted(lista) #növekvőbe rendezem
    for i in range(len(rendezett)-1): #-1 az index miatt
#"Ha az aktuális szám egyenlő a következő számmal VAGY a következő szám az NEM eggyel nagyobb a mostani számnál":
        if rendezett[i] == rendezett[i+1] or rendezett[i+1] != rendezett[i]+1:
#          AktuálisSzám    KövetkezőSzám     KövetkezőSzám     AktuálisSzám+1
            return False
#Akkor jut el az alábbi True értékig, ha egyszer sem akadt fent az if ágban:
    return True
#-------------------------------------------------------
'''
Ez a metódus is egy számlistát néz végig. A kérdés, hogy a listában előfordul-e bármilyen formában a 7-es szám?
Pl.: hetes([2,55,60,78,10]) --> "Van 7-es"'''

def hetes(lista):
#Menjünk végig az alaplistán:
    for i in lista:
#A listán belül minden számnak menjünk végig a jegyein:
#(Ehhez stringként kell értelmezni a számot, hogy belemehessünk)
        for j in str(i):
            if int(j) == 7: #"Ha bárhol talál egy 7-es számjegyet"
                return "Van hetes"
    return "Nincs hetes" #Ez minden for cikluson kívülre jön, mert csak akkor aktiválódhat, ha a metódus végignézte a teljes listát és nem talál 7-est.

# - for ciklusok halmozásakor különböző betűt használjunk
# - és különösen figyeljünk a tabulátorozásra
