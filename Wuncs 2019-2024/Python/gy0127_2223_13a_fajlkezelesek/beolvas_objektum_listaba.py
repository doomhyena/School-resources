class Szemely:
    def __init__(self,nev,kor):
        self.nev = nev
        self.kor = int(kor)
    def __str__(self):
        return "{}, {}".format(self.nev,self.kor)
szemelyek = []
def feltolt():
    f = open("kiir2.csv","r")
    #Van benne fejléc!
    f.readline()
    for sor in f:
        adatok = sor.split(";")
        sz = Szemely(adatok[0],adatok[1].strip())
        szemelyek.append(sz)
feltolt()
#Teljes objektum kiírása
for n in szemelyek:
    print(n)
#Csak a név tulajdonságok
print("Nevek: ")
for n in szemelyek:
    print(n.nev)
print("Korok: ")
#Csak a kor tulajdonságok
for n in szemelyek:
    print(n.kor)