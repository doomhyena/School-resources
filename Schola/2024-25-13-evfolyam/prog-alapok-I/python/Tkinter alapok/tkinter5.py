#Tabok:
import tkinter as tk
from functools import cmp_to_key
from msilib.schema import tables
from tkinter import ttk

from a3 import tabFelület, cimke1, tab3gombja

ablak5 = tk.Tk()
ablak5.geometry('600x400')
ablak5.title('Tabok')

tabFelület = ttk.Notebook(ablak5)
#---
tab1 = ttk.Frame(tabFelület)
cimke1 = ttk.Label(tab1, text='Tab1 szövege')
cimke1.pack()
gomb1 = ttk.Button(tab1,text='Tab1 gombja')
gomb1.pack()
#---
tab2 = ttk.Frame(tabFelület)
cimke2 = ttk.Label(tab2, text='Tab2 szövege')
cimke2.pack()
szd = ttk.Entry(tab2)
szd.pack()
#---
tabFelület.add(tab1,text='Tab 1')
tabFelület.add(tab2,text='Tab 2')
tabFelület.pack()
#---
tab3 = ttk.Frame(tabFelület)
tab3gombja = ttk.Button(tab3,text='Gomb3')
tab3gombja.pack()
tabFelület.add(tab3,text='Tab3')

ablak5.mainloop()
