#1. feladat: fájl beolvasása
jelek = [] #ebbe olvassuk be a fájlban tárolt adatokat:
adat = open('C:\\Users\\kiss.adam\\downloads\\jel.txt') #forrásfájl megnyitása
for sor in adat.readlines(): #menjen végig a forráson soronként
    ora, perc, mperc, x, y = sor.split() #1 sor 5 adatot tartalmaz
    jelek.append([int(ora), int(perc), int(mperc), int(x), int(y)]) #egyben hozzáfűzöm a jelek-hez
adat.close() #a művelet végén mindig lezárjuk a fájlhozzáférést
#------------------
#2. feladat: jelsorszám megadására kiírja annak x és y koordinátáit:
ssz = int(input('A jel sorszáma? ')) #input bekérés
print(f'x={jelek[ssz-1][3]} y={jelek[ssz-1][4]}')
#ahol jelek[ssz-1][3] az a jelek tömb 'sorszámadik' elemének 3. indexű ozlopa
#------------------
#3. feladat: segédfüggvények
#2 időpont között eltelt idő megmérése:
def eltelt(ido1,ido2):
    mp1 = ido1[0] * 3600 + ido1[1] * 60 + ido1[2] #óra, perc, mperc értékek mpercbe konvertálása
    mp2 = ido2[0] * 3600 + ido2[1] * 60 + ido2[2]
    return abs(mp2 - mp1) #abszolútértéket számolunk, mert lehet a kivont időérték a nagyobb
#megadott másodperc érték kiírása 'óra:perc:mperc' formában:
def időbe(mperc):
    ora = mperc // 3600
    perc = (mperc % 3600) // 60
    mp = mperc % 60
    return str(ora) + ':' + str(perc) + ':' + str(mp)
#jeltávolság számítása:
def tavolsag(jel1,jel2):
    return ((jel2[3]-jel1[3])**2 + (jel2[4]-jel1[4])**2) ** 0.5 #képlet a feladatból
#időváltozás hibaszáma:
def idovaltozas_hibaszam(jel1,jel2):
    return (eltelt(jel2[:3], jel1[:3]) + 299) // 300 - 1
#koordinátaváltozás:
def koordinata_hibaszam(jel1,jel2):
    xh = (abs(jel2[3] - jel1[3])+9) // 10 - 1
    yh = (abs(jel2[4] - jel1[4])+9) // 10 - 1
    return max(xh,yh) #ez visszaadja a legnagyobbikat a felsorolt paraméterek közül
def hiba(jel1,jel2):
    if idovaltozas_hibaszam(jel1,jel2) or koordinata_hibaszam(jel1,jel2):
        ido = str(jel2[0]) + ' ' + str(jel2[1]) + ' ' + str(jel2[2])
        if idovaltozas_hibaszam(jel1,jel2) > koordinata_hibaszam(jel1,jel2):
            return ido + ' ' + 'időeltérés' + str(idovaltozas_hibaszam(jel1,jel2))
        else:
            return ido + ' ' + 'koord. eltérés' + str(koordinata_hibaszam(jel1, jel2))
    else:
        return False
#------------------
#4. feladat
print("Időtartam: ", időbe(eltelt(jelek[-1][:3], jelek[0][:3])))
#[-1] index: utolsó elem. Negatív indexelsnél hátulról számoljuk. Ott 0 helyett 1-el kezdjük.
#------------------
#5. feladat: koordináta rendszer 4 pontja a téglalap sarkaihoz
minx = min([jel for jel in jelek], key=lambda x: x[3])[3]
miny = min([jel for jel in jelek], key=lambda x: x[4])[4]
maxx = max([jel for jel in jelek], key=lambda x: x[3])[3]
maxy = max([jel for jel in jelek], key=lambda x: x[4])[4]
print(f"Bal alsó: {minx} {miny}, jobb felső: {maxx} {maxy}")
#------------------
#6. feladat: elmozdulások
elmozdulas = 0
for i in range(len(jelek)-1):
    elmozdulas += tavolsag(jelek[i], jelek[i+1]) #erre kellett a korábban megírt függvény
print(f"Elmozdulás: {elmozdulas:.3f}") #.3f = 3 tizedesre kerekítés
#------------------
#7. feladat: kimaradt értékek kiírása külön fájlba:
kimeneti = open('kimaradt.txt','w')
    #így létrejön egy 'kimaradt.txt' fájl a projekt mappájában
    #'w' = write, tehát írásra nyitottam meg
for i in range(len(jelek)-1): #for ciklus, ami végigmegy a jelek lista hosszán
    if hiba(jelek[i], jelek[i+1]):
        print(hiba(jelek[i], jelek[i+1]), file=kimeneti)
kimeneti.close() #bezárás a fájlművelet végén
