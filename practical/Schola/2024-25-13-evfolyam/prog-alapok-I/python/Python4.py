def listátkészít(szám):
    return [[szám]*szám]*szám
#---------------------------------
A metódus döntse el, hogy igaz-e a megadott egyenlőtlenség.
Sablon: 3 szám, köztük 2 kacsacsőr, mindez szövegként.
Pl.: vizsgál("3<7<11") --> True
     vizsgál("3<2<11") --> False

def vizsgál(szöveg):
    #Készítünk egy listát a bevitt string tartalmából:
    lista = [int(i) if i.isdigit() else i for i in szöveg.split()]
        #isdigit(): megvizsgálja, hogy számjegy-e
        #split(): tagolást jelzi
        #Eredmény: "3<7<11" --> [3,"<",7,"<",11]
    for i in range(0,len(lista)-2,2):
        #itt a ciklus 2-esével lépked és a listahosszhoz képest 2-vel hamarabb ér véget (mert ugye kihagytuk a két kacsacsőrt)
        if lista[i+1] == ">": #"Ha a következő listaelem az ">":
            #"Akkor a kettővel későbbi listaelem (köv. szám) nagyobb-e?"
            if lista[i] <= lista[i+2]:
                return False #"Ha nagyobb, akkor rossz a kacsacsőr"
        #Ugyanezen logika mentén megnézzük az ellentétes irányú kacsacsőrt is:
        elif lista[i+1] == "<":
            if lista[i] >= lista[i+2]:
                return False
    return True #eddig csak akkor jut el, ha egyik korábbi if sem teljesült
#---
def vizsgál2(szöveg):
    return eval(szöveg)
'''eval():
    - evaluáció/hitelesítés
    - felismeri a matematikai műveleteket és értelmezi őket
    - megmondja, hogy helye-e a bennük lévő matematikai állítás '''
#----------------------------------
'''
A metódus megszámolja, hogy egy adott számjegy hányszor fordul elő egy adott intervallumon belül.
Pl.: hányszor(51,55,5) --> 6 
    (az 55-ben kétszer is felszámítjuk, mert jegyenként nézzük)'''

def hányszor(start,vég,jegy):
    #Lista az intervallum összes számával:
    intervallum = range(start,vég+1)
    #Megoldás, hányszor fordult elő a jegy:
    számol = 0
    for szám in intervallum: #Végigmegy az intervallum számain
        #Viszont a számokon belül az egyedi jegyeket is ellenőrizni akarjuk
        stringSzám = str(abs(szám))#esetleges negatív előjelet is vegyük le
        for karakter in stringSzám:
            if int(karakter) == jegy:
                számol += 1
            continue #a ciklus mindenképp folytatódjon
    return számol
#-----------------------------------
A metódus két listát vizsgál meg.
Feltételezzük, hogy a listák:
    - egyforma hosszúak
    - ugyanazt a 2 féle elemet tárolják
A kérdés, hogy a 2 listában mindenhol egymás ellentéteit tartalmazzák-e?
Pl.: ellentétek(["1","0","1"],["0","1","0"]) --> True #mert mindenhol ellentétes

def ellentétek(lista1, lista2):
    #Megvizsgálom, hogy ugyanazon 2 féle karakteből állnak-e:
    egyformák = set(lista1) == set(lista2) #True/False eredmény lesz
    #set() tartalma: milyen karakterekből áll a lista
    if egyformák: #Akkor jó, ha egyformák "True" értéket tartalmaz
        for i in range(0,len(lista1)): # 0-tól a lista1 vagy lista2 hosszáig menjen
            if lista1[i] == lista2[i]: #"Ha az egyik lista adott eleme egyezik a másik lista ugyanannyiadik elemével"
                return False #Hisz pont az ellentéte kée legyen a 2 tartalom
        return True
    else: #Ha "egyformák" értéke False volt
        return False #mert eleve nem egyforma karaktertípusokat tartalmaztak
#-------------------------------
'''
set():
    - eltárolja az adott listában/szóban előforduló karaktereket
    - nincsenek duplikátumok, csak a "karaktergyűjtemény" (set) marad
    - Pl.: [1,2,1,2,1] --> [1,2] vagy "valami" --> "valmi"
'''
