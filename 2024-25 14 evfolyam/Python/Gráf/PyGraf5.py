import tkinter as tk
from tkinter import  ttk

ablak3 = tk.Tk()
ablak3.geometry('600x400')
ablak3.title('Tabok')

#Alap tab felület létrehozása:
tabFelület = ttk.Notebook(ablak3)
#---
#Első tab:
tab1 = ttk.Frame(tabFelület)
cimke1 = ttk.Label(tab1, text='Tab1 szövege')
cimke1.pack()
gomb1 = ttk.Button(tab1,text='Tab1 gombja')
gomb1.pack()
#---
#Második tab:
tab2 = ttk.Frame(tabFelület)
cimke2 = ttk.Label(tab2,text='Tab2 szövege')
cimke2.pack()
szd = ttk.Entry(tab2)
szd.pack()
#---
tabFelület.add(tab1, text='Tab 1')
tabFelület.add(tab2, text='Tab 2')
tabFelület.pack()
#---
#Harmadik tab, 1 gombbal:
tab3 = ttk.Frame(tabFelület)
tab3gombja = ttk.Button(tab3,text='Gomb3')
tab3gombja.pack()
tabFelület.add(tab3, text='Gyakorlás')
#---
ablak3.mainloop()