#1. feladat - Fájl beolvasása:
be = open('C:\\Users\\kiss.adam\\downloads\\melyseg.txt')
sor = int(be.readline())
oszlop = int(be.readline())
adatok = [] #ebben lesz a fájl teljes tartalma
for sor in be.readlines(): #végigmegyünk a fájé sorain
    egysor = [] #soronként akarom felépíteni az adatok tömb leendő tartalmát
    x = sor.split()
    for i in x:
        egysor.append(int(i)) #felépíten am 1 darab sort
    adatok.append(egysor)
be.close() #a fájlművelet végén be kell zárni a fájlt
#----------------------------
#2. feladat - Felhasználói input alapján megadni, hogy ott milyen mély a tó:
sorid = int(input("Sor azonosítója?"))
oszlopid = int(input("Oszlop azonosítója?"))
print("Az ott mért mélység ", adatok[sorid-1][oszlopid-1], 'dm volt.')
#----------------------------
#3. feladat - A tó felszíne és átlagos mélysége:
terulet, melyseg = 0, 0
for sor in adatok:
    for i in sor:
        if i: #"Ha az érték létezik"
            terulet += 1
            melyseg += i
print("A tó felszíne: {} m2, átlag mélysége pedig {:.2f} m.". #sortörés
      format(terulet,melyseg/terulet/10)) #10-zel osztok, hogy dm helyett m érték legyen
#----------------------------
'''
enumerate() függvény: 
    - egy stringből vagy tömbből készít egy értékpár-listát
    - minden eredeti elem sorszámozásra kerül
Pl.:
stringpPélda = "abc"
listaPélda = ["egy","kettő","három"]
enumString = enumerate(stringPélda) --> [(0,'a'),(1,'b'),(2,'c')]
enumLista = enumerate(listaPélda) --> [(0,'egy'),(1,'kettő'),(2,'három')]
'''
#----------------------------
#4. feladat - A tó legmélyebb pontja:
legmelyebb = 0
for sor in adatok:
    for i in sor:
        if i > legmelyebb:
            legmelyebb += i
print("Legmélyebb rész: ", legmelyebb, " dm.")
print("Ezen legmélyebb pont koordinátái: ")
for i, sor in enumerate(adatok):
    for j, hely in enumerate(sor):
        if adatok[i][j] == legmelyebb:
            print("({}, {})".format(i+1,j+1), end=" ")
#----------------------------
#5. feladat - Tó partvonalának hossza:
hossz = 0
for i, sor in enumerate(adatok):
    for j, hely in enumerate(sor):
        if 0 < i < len(adatok) and 0 < j < len(sor) and adatok[i][j] > 0:
            if adatok[i-1][j] == 0:
                hossz += 1
            if adatok[i+1][j] == 0:
                hossz += 1
            if adatok[i][j-1] == 0:
                hossz += 1
            if adatok[i][j+1] == 0:
                hossz += 1
print("A tó partvonalának hossza: ", hossz, " m.")
#----------------------------
#6. feladat - Új fájlba írjuk a mélységeket reprezentáló * jeleket (megadott koordináta alapján).
sorid = int(input("Keresett azonosító: "))
i = 1
kimenet = open("diagram.txt", "w") #w = write = írásra nyitjuk meg
for egysor in adatok:
    print("{0:02d}".format(i)+round((egysor[sorid]/10))*'*', file=kimenet)
    i += 1
kimenet.close()
