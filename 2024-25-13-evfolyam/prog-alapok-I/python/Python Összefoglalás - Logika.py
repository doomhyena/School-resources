#Python összefoglalás - Logika:

#Metódus séma:
def metódusnév(paraméterVáltozó): #paraméterVáltozó itt egy változónév, nem egy konkrét szám/szó
    Érdemi műveletek #a bevitt értékkel végzünk számításokat
    return eredmény #a vége mindig egy return parancs

print(metódusnév(KonkrétÉrték)) #ide kell beírni a konkrét értékeket, amikkel számolnánk
#Pl.:
def kétszerez(szám): #tehát ide nem írunk olyat, hogy "5".
    ujSzám = szám * 2
    return ujSzám #a metódus mindig return sorral végződik

print(kétszerez(5)) #inkább it lent írom be a konkrét értéket
#-------------------------------------
#Feltételes elágazás séma:
if Logikai feltétel itt:
    művelet, ha teljesül a feltétel
elif Másik logikai feltétel:
    művelet, ha inkább ez a feltétel teljesül
else:
    művelet, ha nem teljesült a feltétel
#Pl.:
if 5 > 2:
    return True
else:
    return False
#-------------------------------------
#Feltételek halmozása:
if Feltétel1 and Feltétel2: #"ÉS": mindkét feltételnek teljesülnie kell
if Feltétel1 or Feltétel2 #"VAGY": elég, ha egy feltétel teljesül

#-------------------------------------
#For ciklus:
for i in adathalmaz:
    Művelet, amit elvégez a halmaz minden elemére
    #i: ez reprezentálja az aktuális elemet, ahol épp tart a ciklus
    #adathalmaz: lehet egy tömb, string vagy tól-ig érték
#-------------------------------------
#Listává alakítás:
szó = "valami"
list(szó)   #Eredmény: ["v","a","l","a","m","i"]
#-------------------------------------
A range() paraméterei:
    range(5)     --> 1-től 5-ig megy
    range(3,7)   --> 3-tól 7-ig megy
    range(3,7,2) --> 3-tól 7-ig megy, kettesével
    range(7,3,-1) --> 7-től 3-ig megy, visszafelé
#-------------------------------------
#Módosítható értékek berakása egy előre megírt sablonmondatba:
példaszöveg = "A változó értéke: {} és {} lett.".format(érték1, érték2)
    #ahol a {} jelzi, hogy hová kerülnek a format-ban megadott változók értékei
    #több {} esetén a megfelelő sorrendben fogja berakni
#-------------------------------------
#Indexek:
lista1[0] #Ez a lista1 első elemére hivatkozik (az indexek 0-val kezdődnek)
lista1[i+1] #Ez az aktuális indexű elem utáni elemre hivatkozik
lista2 = lista1[2:] #[2:] jelentése: a 2-es indexű (tehát 3.) elemtől számítva nézze
#-------------------------------------
len(változóNeve) #Megmondja, hogy hány karakterből áll egy változó/lista
listaNeve.append(újElem) #Hozzáad egy új elemet a tömb végére
sorted(listaNeve) #sorba rendezi a tömb elemeit (abc/növekvő)
floor(törtSzámérték) #lefelé kerekíti a tizedestörtet
round(milyenSzámot,HányTizedesre) #egy számérték kerekítése
int(változóNeve) #int (egész szám) típusúvá konvertálja a változót
str(változóNeve) #string (szöveg) típusúvá alakítja a változót. Használni kell, ha pl egy szám jegyein akarok végig menni.
abs(számérték) #egy szám abszolútértékét adja vissza (esetleges negatív előjel levétele). Pl. abs(-4) --> 4
isdigit(érték) #megvizsgálja, hogy számjegy-e
eval(egyenlet) #megmondja egy matematikai egyenlet eredményét
set(lista) #eredmény: az eredeti lista, de duplikátumok nélkül
Szöveg.lower() #kisbetűssé alakítás
Szöveg.upper() #nagybetűssé alakítás
Szöveg.islower() #kisbetűs-e?
Szöveg.isupper() #nagybetűs-e?
szöveg.replace(MilyenKaraktert,MilyenKarakterre) #kicseréli a szöveg bizonyos karaktereit
stringVáltozóNeve.count("Karakter")
    #Pl.: szó = "alma" --> aBetűk = szó.count("a") --> 2 lesz az eredmény
#-------------------------------------
#Matemaikai/logikai műveletek:
Hatványozás: a**b #(pl. 3^2=9)
Sima osztás: a / b #(3/2=1.5)
Csak az egész rész legyen az osztás eredményében: a // b #(pl. 3//2=1)
Csak a tört rész kell az osztás eredményéből: a % b #(pl. 3%2=0.5)
=: sima deklaráció #(pl. x = 5 --> x legyen 5)
==: egyenlőségvizsgálat #(pl. x == 5 --> x értéke 5-e?)
!=: logikai tagadás #(pl. x != 5 --> x nem egyenlő 5-tel)
+=, -=, *= műveletek: az eredeti változó múdosul #(pl. x += 5 --> x értéke 5-tel nő)
#-------------------------------------
#Példák:
Hány alkalommal futott le egy for ciklus:
    a ciklus tartalmában legyen egy segédérték, ami minden alkalommalnő 1-el (valami+=1)
Matematikai modul használata:
    import math as m
    #ezt a python kód legtetejére kell írni
    #az 'm' betű itt a matek modul rövidítése lesz, így hivatkozok rá az érdmi kódban
Szám párosságának vizsgálata:
    #elosztjuk 2-vel és megnézzük, hogy mennyi a maradék
    #ha a maradék 0, akkor páros. Ha 1, akkor páratlan.
