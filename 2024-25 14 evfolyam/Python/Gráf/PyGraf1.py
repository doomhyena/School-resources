#Először importáljuk be a grafikáért felelős tkinter modult:
import tkinter as tk
from tkinter import ttk

ablak1 = tk.Tk() #ablak1 néven létrehoz egy ablak objektumot
ablak1.title("Alapok") #Ablak felső címe
ablak1.geometry('300x600') #az ablak alapmérete pxelben (Vízszintes*Függőleges)

#Ezen az ablakon fogunk pár elemet elhelyezni:
#Egy "Tesztelés" feliratú cimkénk:
cimke1 = ttk.Label(master = ablak1, text = 'Tesztelés')
cimke1.pack() #Mindig meg kell hívni a hozzá tartozó pack() függvényt, hogy meg is jelenjen majd
#cimkenév = ttk.Label(MelyikAblakhoz,MegjelenőFelirat)
#ElemNeve.pack()
#---
#Egy nagyobb szöveges mező:
nagymező = tk.Text(master = ablak1)
nagymező.pack()
#---
#Kis szövegdoboz:
kismező = ttk.Entry(master = ablak1)
kismező.pack()
#---
#Egy másik cimke, "cimke2" felirattal:
cimke2 = ttk.Label(master = ablak1, text = "Cimke2")
cimke2.pack()
#---
#Metódus, amit lejjebb meghív a gombnyomás:
def átvisz():
    dobozszoveg = kismező.get() #eltároljuk a szvegdobo tartalmát
    cimke2['text'] = dobozszoveg #a cimke szöveges tartalma legyen az eltárolt dobozszöveg
    kismező['state'] = 'disabled' #a szövegdoboz ezután ne legyen szerkeszthető
#A metódus kódja mindig a meghívás fölött legyen valahol. Alatta nem fogja látni.
#---
#Egy gomb ("Gomb" felirattal), ami kattintásra kiírja az második cimkébe a kis szövegdobozba írt szöveget, magát a szövegdobozt pedig passsziválja.
gomb1 = ttk.Button(master = ablak1, text = "Gomb", command = átvisz)
gomb1.pack()
#--
#Legyen egy Visszacsinál gomb, ami újra szerkeszthetővé teszi a dobozt, és visszarajka cimke2 eredeti feliratát.
def visszacsinal():
    cimke2['text'] = "Cimke2" #eredti szövegre
    kismező['state'] = 'enabled' #legyen újra szerkeszthető a szövegdoboz
#--
gomb2 = ttk.Button(master = ablak1, text = 'Visszacsinál', command=visszacsinal)
gomb2.pack()
#---
ablak1.mainloop() #A kód legvégére meg kell hívni az adott ablakot ténylegesen futtató parancsot
#Csak az fog lefutni, amit a mainloop fölé írunk.