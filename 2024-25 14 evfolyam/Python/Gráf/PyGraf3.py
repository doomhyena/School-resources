#Grafikai modulok importálása:
import tkinter as tk
from tkinter import ttk

#Alap ablak létrehozása:
ablak1 = tk.Tk()
ablak1.title('Gombok')
ablak1.geometry('600x400')
#---
#Metódus a gombnyomáshoz:
def gomb_metódus():
    print('Sima gomb megnyomva')

#Specializált segédváltozó az elemek mögöttes értékeként:
gomb_segéd = tk.StringVar(value='Gomb egy változóval')
#Egy gomb létrehozása:
gomb1 = ttk.Button(ablak1, text='Sima gomb',command=gomb_metódus,textvariable=gomb_segéd)
gomb1.pack() #pack függvény ne maradjon le, az oldalon való megjelenéshez kell
#---
#Checkbox:
pipaSeged = tk.IntVar(value=10) #Segédváltozó
#Létrehozása:
checkbox1 = ttk.Checkbutton(
    ablak1, #Melyik ablakhoz tartozik
    text = 'Checkbox1', #Felirat
    command= lambda: print(pipaSeged.get()), #Megnyomásra elvégzett művelet
    variable=pipaSeged, #Kezelt változó
    onvalue=10, #Bepipált állapotban az érték
    offvalue=5 #Nem bepipált állapotban az érték
)
checkbox1.pack()
#---
#Másik checkbox létrehozása:
checkbox2 = ttk.Checkbutton(
    ablak1,
    text='Checkbox2',
    command=lambda: pipaSeged.set(5)
)
checkbox2.pack()
#---
#Rádiógomb:
radioSegéd = tk.StringVar() #Segédváltozó, mögöttes értéknek
radio1 = ttk.Radiobutton( #Rádiógomb létrehozása
    ablak1,
    text='Rádiógomb1',
    value=1,
    variable=radioSegéd,
    command=lambda: print(radioSegéd.get())
)
radio1.pack()
#---
radio2 = ttk.Radiobutton(
    ablak1,
    text='rádiógomb2',
    value=1,
    variable=radioSegéd
)
radio2.pack()
#Az egész eddigi kód futtatásához:
ablak1.mainloop()
















