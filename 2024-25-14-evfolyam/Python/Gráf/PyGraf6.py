import tkinter as tk
from tkinter import ttk
from tkinter import messagebox  #Ez a hiabüzenet ablakhoz kell majd
#---
#Osztály az új ablak létrehozására:
class Extra(tk.Toplevel): #Osztály séma
    def __init__(self):
        super().__init__()
        self.title('Extra ablak') #self: adott ablak példányra utal
        self.geometry('300x400')
        #Leegyszerűsített elemlétrehozás:
        ttk.Label(self,text='Egy cimke').pack()
        ttk.Button(self,text= 'Egy gomb').pack()
#---
ablak4 = tk.Tk()
ablak4.geometry('600x400')
ablak4.title('Többablakos feladat')
#---
#Metódusok a lenti gombok működéséhez:
def üzenet():
    messagebox.showerror('Felugró ablak','Üzenet szövege')
def uj_ablak():
    global extra_ablak
    extra_ablak = Extra()
def bezárás():
    extra_ablak.destroy()
#---
#Gomb az új ablak megnyitására:
nyitGomb = ttk.Button(
    ablak4,
    text= 'Extra ablak nyitása',
    command=uj_ablak
)
nyitGomb.pack()
#---
#Gomb az új ablak bezárására:
zárGomb = ttk.Button(
    ablak4,
    text='Extra ablak bezárása',
    command=bezárás
)
zárGomb.pack()
#---
#Gomb a felugró ablakhoz:
üzenetGomb = ttk.Button(
    ablak4,
    text='Felugró üzenet',
    command=üzenet
)
üzenetGomb.pack()
#---


















#---
ablak4.mainloop()