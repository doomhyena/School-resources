import tkinter as tk
from doctest import master
from tkinter import ttk
#---
ablak2 = tk.Tk()
ablak2.title("VáltozóKezelés")
#Ha nem adunk meg méretet az ablaknak, akkor alaprameretezett értéket használ.
#---
#A tkinter beépített string-kezelő funkciója:
#A metódus írja ki a konzolon, hogy "megnyomva":
def kiiras():       #Ezt a későbbi gombnyomásnál hívjuk meg
    print(string_var.get())
    string_var.set('megnyomva')

string_var = tk.StringVar()

#---
#Legyen egy cimke, egy kis szövegdoboz és egy gomb:
cimke1 = ttk.Label(master=ablak2, text="Cimke1", textvariable=string_var)
cimke1.pack()

szdoboz = ttk.Entry(master=ablak2, textvariable=string_var)
szdoboz.pack()

gomb1 = ttk.Button(master = ablak2, text = "Gomb1",command=kiiras)
gomb1.pack()
#---
'''Legyen egy új cimke és két új szövegdoboz. Ha valamelyik szövegdobozba gépelünk, akkor 
mindhárom mező szinkronban kövesse a tartalomváltozást.
Ehhez össze kell kapcsolni őket egy mögöttes szövegváltozóval.'''

#Egy új speciális string, alapraméretezett tartalommal ellátva:
tartalom = tk.StringVar(value='példaszöveg') #Ennek segítségével kapcsoljuk össze a 3 alábbi mezőt.
#Szövegdoboz1:
szd1 = ttk.Entry(master=ablak2,textvariable=tartalom)
szd1.pack()
#Szövegdoboz2:
szd2 = ttk.Entry(master=ablak2,textvariable=tartalom)
szd2.pack()
#A cimke:
cimke = ttk.Label(master=ablak2,textvariable=tartalom)
cimke.pack()
#---
ablak2.mainloop()
'''
    - A változóknál meg kell adni, hogy melyik ablakhoz tartoznak, és hogy mi a feliratuk.
    - A grafikus program az csak a mainloop() feletti részt értelmezi
    - A def metódusokat mindig valahol a meghívásuk fölé kell írni (alatta nem látja)
    - Minden, az ablakon elhelyezett elem alá meg kell hívni a pack() segédparancsot is
    - A tkinter modul érzékeny a kis-nagybetűkre
    - Nem mindegy, hogy mi jön a 'tk' és mi jön a 'ttk' osztályokból
'''