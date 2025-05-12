Autóra spórolunk (euróban). Hány nap múlva lesz meg a kocsi ára?
Félretett összegek:
    1 2 3 4 5 6 7
    2 3 4 5 6 7 8
    3 4 5 6 7 8 9 ...

Pl.: spórol(2050,1200,10) --> 53

def spórol(ár,tőke,kezd): #3 paraméter, megfelelő sorrendben
    összeg, napok = 0, 0 #1 sorban több új változó: sorrendre figyelni
    ár =- tőke #a tőke már megvan, csak az azon felüli részt kell összegyjteni
#Az alábbi ciklus addig fut le újra és újra, ameddig el nem éri az összegyűlt összeg az árat:
    while összeg < ár:
        i = kezd + napok/7 if not napok%7 else i+1
            # itt i a napi félretett összeget jelenti
            # a kérdés, hogy hét eleje van-e, mert akkor visszaugrik
        összeg += i #Hozzáadja a napi összeget
        napok += 1 #Növeli az eltelt napok számát
    return napok
#------------------------------------
Igaz-e, hogy a vizsgált számnak 1-en és önmagán kívül csak egyetlen osztója van?
Pl.: osztó(4) --> True      (mert 4 osztói: 1,2,4)

def osztó(szám):
    osztókszáma = 0
    #Ha 1-et adok meg, arra külön eset lesz:
    if szám == 1:
        return False
    i = 2 #segédváltozó a számoláshoz
    while i*i <= szám:
        if not szám % i or not szám % 10:
        #or: "VAGY" feltétel. Elég, ha az egyik teljesül.
        #% : osztás maradékát nézi
        #not: logikai tagadás ("ha nem igaz, hogy...")
            if osztókszáma == 2:
                return osztókszáma == 1 #A vizsgálat eredményét kéri vissza
            osztókszáma += 1
        i += 1
    return osztókszám == 1
#-----------------------------------------
Lista generálása másik változótípusból:
Pl.:    szó = "valami"
        list(szó)   #Eredmény: ["v","a","l","a","m","i"]
#---
A range() paraméterei:
    range(5)     --> 1-től 5-ig megy
    range(3,7)   --> 3-tól 7-ig megy
    range(3,7,2) --> 3-tól 7-ig megy, kettesével
    range(7,3,-1) --> 7-től 3-ig megy, visszafelé
#--
A metódus generáljon egy számlistát a megadott szélső értékek alapján.
Pl.: generáló(2,8) --> [2,3,4,5,6,7,8]
     generáló(8,2) --> [8,7,6,5,4,3,2]

def generáló(kezd,vég):
    if kezd < vég: #Ha növekvő lista kell
        return list(range(kezd,vég+1))
    else: #Ha csökkenő lista kell
        return list(range(kezd,vég-1,-1))
#-----------------------------
Elem megszámlálása egy összetett változóban:
    szöveg = "valami" #Meg akarom számolni az "a" betűket
    szöveg.count("a") #Változónév.count(SzámlálandóElem)
#---
A metódus megvizsgál egy listát és egy másik listában kiadja azokat az elemeket, amelyek csak egyszer fordulnak elő.
Pl.: [5,6,7,6,5,4] --> [7,4]

def egyediek(lista):
    megoldás = [] #ebbe rakjuk az egyedieket
    for i in lista: #Végigmegy a bekért list elemein (i = adott elem)
        #Megnézzük, hogy az adott "i" érték hányszor fordul elő összesen:
        if lista.count(i) == 1: #A megszámlálás eredménye 1?
            megoldás.append(i) #Akkor hozzárakjuk a megoldáslistához
    return megoldás
#A print sor már NEM a def része:
print(egyediek([5,6,7,6,5,4]))
#Konkrét számokat csak a print sorba írunk, a def-be nem
#-------------------------------------------------
#A metódus megmondja, hogy hány jegyből áll a megadott szám.
#Rosszak: tabulátorozás, kettőspontok, változók, = jelek.
def számhossz(szám):
    számol = 0
    if szám == 0:
        return 1
    else:
        while szám != 0:
            szám //= 10
            számol += 1
        return számol

print(számhossz(332))
#----------------------------------------
Az egész szám ugyanolyan jegyekből áll-e?
Pl.: egyformajegyek(66) --> True
     egyformajegyek(667) --> False

def egyformajegyek(szám):
    #String formába tudunk végigmenni a számjegyeken:
    for jegy in str(szám):
        #Minden jegyet az első jegyhez hasonlítunk:
        if jegy != str(szám)[0]:
        #str(szám)[0] jelentése: a string-ként értelmezett szám 1. jegye (0. index)
            return False
            break #ez megtöri a ciklus futását
        else:
            continue #simán folytatódik a ciklus (műveletek nélkül)
    return True #A a for cikluson belül nem triggerelte be a 'return False' műveletet, akkor jut el a 'return True'-ig
#---
#Alternatív megoldás: minden jegy után felírunk egy igaz/hamis értéket egy segédlistába. A végén, ha egy False is van a listában, akkor az egész False.
def egyformajegyek2(szám):
    szám = list(str(szám))#A számot egy string listává alakítom
    boollista = []#ebben lesznek az igaz/hamis (boolean) értékek
    for i in range(len(szám)): #a ciklus a szám hosszáig menjen
        if i >= len(szám)-1:#Ha a lista végére ér...
            break #...akkor törje meg a ciklus futását
        elif szám[i] == szám[i+1] #= az azutáni elemmel
            boolista.append(True)
        else:
            boolista.append(False)
    return False if False in boollista else True
#"Adjon vissza False-t, ha van False a boollistában, egyéb esetben True-t"
   #return Válasz1 if (LogikaiVizsgálat) igaz else Válasz2
#-------------------------------------------
A metódus vizsgálja meg, hogy számjegyek összege páros vagy páratlan.
Pl.: jegyösszeg(67) --> "Páratlan" (mert: 6+7=13, ami páratlan)

def jegyösszeg(szám):
    szám = str(szám) #a számot string-be konvertáljuk
    összeg = 0
    for i in szám: #a string-é konkertált számon megy végig
        összeg += int(i) #számjegy értékének hozzáadása az összeghez
    if összeg % 2 == 0: #vizsgálat: összeg páros-e?
        return "Páros"
    else:
        return "Páratlan"
#---------------------------------------------
Fibonacci sorozat: 0 1 1 2 3 5 8 13 21 ...
    - Az első 2 elem fixen 0 és 1
    - A többi elem mindig az előző kettő összege
A metódus kiadja, hogy mi a fibonacci sorozat adott sorszámú eleme?
Pl.: fib(20) --> 6765 (a sorzat 20. eleme az a 6765)

def fib(szám):
    if szám == 0: #1. elem esetén
        return '0'
    elif szám == 1: #2. elem esetén
        return '1'
    else: #minden más elem esetén
        #A 2 legutóbbi elemnek kell 1-1 segédváltozó:
        t1 = 0 #legutóbbi előtti elem
        t2 = 1 #legutóbbi elem
        for i in range(2,szám+1):
            összeg = t1 + t2
            t1 = t2 #t1 értéke a legutóbbi elem legyen
            t2 = összeg #t2 értéke pedig az újonnan kapott összeg
    return összeg
#-------------------------------------------

