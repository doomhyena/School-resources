import tkinter as tk
from tkinter import ttk
from tkinter import scrolledtext    #A csúszkákhoz kell ez is

#Ablak létrehozása:
ablak2 = tk.Tk()
ablak2.title('Csúszkák')
#---
#Segédváltozó a csúszka értékéhez:
csúszkaSegéd = tk.DoubleVar(value=15) #double = tizedestört
csúszka = ttk.Scale(
    ablak2,
    command=lambda value: pb.stop(),
    from_ = 0, #Kezdőérték
    to = 25, #Max érték
    length=300, #Felosztás részletessége
    orient='horizontal', #Vízszintes vagy függőleges legyen
    variable=csúszkaSegéd #mögöttesen kezelt segédváltozó
)
csúszka.pack()
#---
#ProgressBar:
pb = ttk.Progressbar(
    ablak2,
    variable=csúszkaSegéd, #Így szinkronban fog mozogni a fenti csúszkával
    maximum=25,
    orient='horizontal',
    mode='indeterminate',
    length=400
)
pb.pack()
#---
'''Feladat: Függőleges progress bar, ami automatikusan töltődik 
    és egy cimke ki is írja a mögöttes értélét.'''
gyakInt = tk.IntVar()
gyakBP = ttk.Progressbar(
    ablak2,
    orient='vertical',
    variable=gyakInt
)
gyakBP.pack()
gyakBP.start() #Automatikusan tölteni kezdi magát
#A cimke írja ki számként, hogy hol tart a töltöttség
gyakCimke = ttk.Label(ablak2,textvariable=gyakInt)
gyakCimke.pack()

#Csúszka, ami követi az itteni progress bar értékét:
gyakCsúszka = ttk.Scale(ablak2,variable=gyakInt, from_ = 0, to = 100)
gyakCsúszka.pack()
#---
ablak2.mainloop()



















