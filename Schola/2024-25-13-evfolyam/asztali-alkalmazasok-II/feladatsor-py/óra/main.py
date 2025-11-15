neved = input("Kérem a neved: ") # alapvetően az input mindig mindent string-ként kezel

print(f"Téged {neved} hívnak.")

eletkorod = int(input("Kérem az életkorod: "))

print(f"Téged {neved} és {eletkorod} vagy.")
print(type(eletkorod))

ureslista = [] # Üres lista

print(type(ureslista))

lista = [17, 5, 6, 23, 75, "Lajos"] # A típusok keveredhetnek
lista2 = [1, 2, 3, 4]
print(f"A lista elemei: {lista}")

print(f"A lista második eleme {lista[2]}")

# -----------------

lista.append("Kívánok!") # Lista végére teszünk egy elemet
lista.insert(1, "20. ") # Az egyes indexre beteszi a megadott elemet.
lista.append(lista2) # A teljes listát beszúrja a lista utolsó indexére.
lista.extend(lista2) # A lista elemeit egyesével helyezi el az indexen
lista.remove(4) # Megadott elemet távolítja el.
lista.remove(lista2) # A lista elemeit egyesével helyezi el-
lista.pop(4) # a megadott indexet törli
lista.clear() # Törli a lista elemeit, üres listát csinál.
lista.sort() # Rendezés növekvő sorrendbe
lista.sort(reverse=True) # Rendezés csökkenő sorrendbe.


lista3 = [1, 2, 3, 4]


for i in range(10):  # i = 0; i < 10; i++
    print(i)
for i in range(1, 10):  # i = 1; i < 10; i++
    print(i)
for i in range(3, 15, 2):  # i = 3; i < 5; i++
    print(i)
for i in lista3:  # Az i felveszi a listának az elemit
    print(i)

stringmen = "Ez egy string"

for i in stringmen:  # Betünként sortöréssel kiírja a mondatot
    print(i)

print(stringmen[5])
print(stringmen[1:6])
