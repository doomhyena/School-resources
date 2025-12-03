#Példa1: Hány nagybetű van a példaszövegben?
szoveg = "Valamilyen Szöveg"
db = 0
for karakter in szoveg: #Végigmegy a szöveg betűin
    if karakter.isupper(): #Nagybetű-e? (upperCase)
        db += 1
print(db)
#-------------------------------
#Példa2: Cseréljük ki az "a" betűket "*" jelekre:
szo = "almafa"
uj = "" #Ebbe lesz felépítve a módosított szó
for betu in szo: #végigmegyünk a szó betűin
    if betu == "a": #Ha az adott betű az "a"
        uj += "*" #"Akkor az új szóhoz egy * lesz hozzárakva
    else: #Egyéb esetben az aktuális betű
        uj += betu
print(uj)
#-------------------------------
#Feladat1: Egy sablonmondat hány szavában fordul elő az "o" betű?
mondat = "Python programozás"
szavak = mondat.split() #szóköz alapján tagol, 2 elemű szólista lesz
db = 0
for szo in szavak: #Végigmegy a szó listán
    if "o" in szo: #Ha az adott szóban talál "o" karaktert
        db += 1
print(db)
#-------------------------------
#Példa3: Igaz-e, hogy a mondat minden szava hosszabb 3 betűnél?
mondat = "Ez egy példa mondat."
szavak = mondat.split() #szavakra tagolás (lista)
mindHosszu = True #Ez fog hamisra állítódni, ha akár 1 rövid szót is találunk
for szo in szavak:
    if len(szo.strip(".,;:!?")) <= 3:
    #strip(Írásjelek): hogy azok ne számítsanak bele a szóhosszba
        mindHosszu = False
if mindHosszu == True:
    print("Igen, minden szó hosszabb 3 betűnél")
else:
    print("Nem minden szó elég hosszú")
#-------------------------------
#Feladat2: Írjuk ki egy teljes név kisbetűs mássalhangzóit egy külön stringben.
név = "Minta Elemér"
magánhangzók = "aáeéiíoóöőuúüű"
eredmeny = ""
for betu in név.lower():
    if betu not in magánhangzók:
        eredmeny += betu
print(eredmeny)
#-------------------------------
#Példa4: Egy karaktersorban lévő számok összege kell.
karakterek = "he5j8kk3f1"
osszeg = 0
for karakter in karakterek:
    if karakter.isdigit(): #Ha az adott karakter egy számjegy
        osszeg += int(karakter) #Akkor az értékét hozzáadjuk az összeghez
        #(de int fomában)
print(osszeg)
#-------------------------------
#Feladat3: Írjuk ki egy sablonmondat szavainak utolsó betűit.
mondat = "Ez egy példa mondat." #Az eredmény: "zyat" legyen
szavak = mondat.strip(".!?,;").split() #szavakra tagolás
utolsok = ""
for szo in szavak:
    utolsok += szo[-1] #[-1] index = utolsó elem
print(utolsok)
#-------------------------------
#Feladat4: A mondat hány szava kezdődik "n" betűvel?
mondat = "A Nyári szünet nagyon rövid." #Megoldás = 2
szavak = mondat.split() #A mondat szavakra tagolása
db = 0 #Ebbe számoljuk majd a talált n betűket
for szo in szavak:
    # Ha az adott szó kisbetűs változatának 1. betűje az "n":
    if szo[0].lower() == "n":
        db += 1
print(db)
