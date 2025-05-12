a = 7
b = "auto"
print(a)
print(b)
a = "auto"
b = 7
print(a,b) #Ez nem konkatenálás
#print(a+b) #Ez az
'''
hahahah
ahahha
bssccy
'''

c = int(17)
print(c)
c = float(17) #Nincs double :-(
print(c)
c = str(17)
print(c)
c = bool(17)
print(c)
c = True

d = "Java a legjobb!"
D = "C# a legjobb!"
print(d,D) #Vátozók létrehozása: A-Za-z, 0-9(de nem kezdődhet számmal)--> _5
e,f,g,h = "Java","a","legjobb",7
import random as rnd
z = rnd.randint(1,10)#Alsó és felsőhatár
print("1 és 10 közötti szám: ",z)
y = min(z,h,b)
x = max(z,h,b)
print("Min: ",y,"Max",x)
w = abs(-17)
print(w)
v = pow(5,2)
print(v)
import math as m
t = m.sqrt(4)
print(t)
u = m.pi
print(u)

A = 7
B = 17

if A > B:
    print(A,"Nagyobb mint",B)
elif B > A:
    print(B,"Nagyobb mint",A)
else:
    print("A két szám egyenlő")

'''
sajatinput = input("Kérem az inputot: ")#Alapból minden inputot string-ként kezel
print("Inputod: ",sajatinput)
print("Inputod típusa: ",type(sajatinput))
si2 = int(input("Kérek egy egész számot"))
print("Új input: ",si2)
print("Típusa: ",type(si2))
'''

lista = [] #Üres lista
print(type(lista))
lista = [17, 5,6,23,75,"Lajos"] #A típusok keveredhetnek
print(lista)
print("Lista 2, eleme: ",lista[1])

if "lajos" in lista:
    print("Benne van")

lista[0] = 1
lista[1:3] = [2,3,4]
#Az leső index beleszámít, a második már nem.
#De ha több számot írunk jobbra, akkor a többlet bőviti a listát.
print(lista)
print("lista első négy eleme: ",lista[0:4]) #Itt is. Első beleszámít, második már nem.

lista2 = ["Boldog","Szülinapot"]
lista2.append("Kívánok!") #Lista végére teszünk egy elemet.
print(lista2)
lista2.insert(1,"20.") #Az 1-es indexre beteszi  a megadott elemet.
print(lista2)
lista.append(lista2) #A teljes listát beszúrja a lista utolsó indexére.
print(lista)
lista2.extend(lista2) #A lista elemeit egyesével helyezi el az idexen.
print(lista)
lista.remove(4) #A megadott elemet távolítja el.
print(lista)
lista.remove(lista2)
print(lista)
lista.pop(4) #A megadott indexet távolítja el.
print(lista)
lista2.clear() #Törli a lista elemeit. Üres listát csinál.
print("Lista utolsó eleme: ",lista[-1])
print(lista[-2], lista[-3]) #Utolsó előtti és azelőtti elemek.

lista3 = [3,2,5,8,1,4,7]
lista3.sort() #Rendezés növekvő sorrendbe.
print(lista3)
lista3.sort(reverse=True) #Rendezés csökkenőbe
print(lista3)
#lista.sort() A keveredés miatt nem tudja rendezni
lista4 = [str(3),str(2),str(6),"sajt"]
lista4.sort()
print(lista4)
print("--------------------------")
for i in range(10): #i = 0; i<10; i++
    print(i)
print("----------------------------")
for i in range(1,10): #i=1;i<10;i++
    print(i)
print("----------------------------")
for i in range(3,15,2): #i=3;i<15;i+=2
    print(i)
print("----------------------------")
for i in lista3: #i felveszi a listának az elmeit.
    print(i)
print("----------------------------")
stringem = "Ez egy string"
for i in stringem:
    print(i)
print("----------")
print(stringem[5])
print(stringem[1:5])

X = 100
Y = 80
while X != Y:
    X = X-5
    print(X)
else: #Ez csak akkor fut le ha a while feltétele miatt lép ki.
    print("Kiléptem.")