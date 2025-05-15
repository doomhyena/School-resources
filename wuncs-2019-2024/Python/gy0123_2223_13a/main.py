import random
l = []
def feltolt():
    lista = []
    for i in range(5):
        lista.append(random.randint(1,100))
    return lista

feltolt()
print(l)

f = open("szambe.txt","r",encoding="utf-8")
sz = int(f.read())
print(type(sz))

def vizsgal(lista,beolvasott_szam):
    for i in range(len(lista)):
        if lista[i] == beolvasott_szam:
            return "{} benne van a(z) {}. indexen.".format(beolvasott_szam,i)
    return "Nincs benne a listában."
print(vizsgal(l,sz))

def vizsgal2(lista,beolv):
    if beolv in lista:
        return "{} benne van a(z) {}. indexen.".format(beolv,lista.index(beolv))
    return " Nincs benne."
print(vizsgal2(l,sz))

l2 = feltolt()

def darabol(inputom):
    lista = inputom.split(",")
    for i in range(len(lista)):
        lista[i] = int(lista[i])
    return lista
l3 = darabol(input("Kérek 5 számot vesszővel elválasztva: "))
print(l2,l3)

def azonos(lista1,lista2):
    db = 0
    for n in lista1:
        if n in lista2:
            db+=1
    return "{}db egyezés van.".format(db)
print(azonos(l2,l3))
