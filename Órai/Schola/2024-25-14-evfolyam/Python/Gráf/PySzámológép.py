
#Tkinter elemek, beleértve az ablak széléhez igazítás (N,E,S,W):
from tkinter import Tk, END, Entry, N, E, S, W, Button
from tkinter import font #betűtípus
from tkinter import Label #cimke
from functools import partial #számoláshoz segítség

#Beviteli értékek kezelése:
def input_kezelo(bevitt, argu):
    bevitt.insert(END, argu)

#Bevitt érték visszatörlése:
def backspace(bevitt):
    #Törli a mezőben szereplő utolsó karaktert:
    bevitt_hossza = len(bevitt.get())
    bevitt.delete(bevitt_hossza - 1)

#A teljes tartalom törlésére (C gomb):
def kiurit(bevitt):
    bevitt.delete(0, END)

#Az eredmény kiszámítása (az = jelhez):
def szamolo(bevitt):
    bevitt_info = bevitt.get()
    try: #Megpróbálja megoldani a műveletet a beépített evaluációs függvénnyel:
        megoldas = str(eval(bevitt_info.strip()))
    except ZeroDivisionError: #ha nem sikerült (mert 0-val nem osztunk):
        hibauzenet() #meghívja az erre szolgáló figyelmeztető üzenetet
        megoldas = ""
    kiurit(bevitt)
    bevitt.insert(END, megoldas)

#0-val osztásnál ez lesz a hibaüzenet:
def hibauzenet():
    hiba = Tk() #Új ablak nyitása
    hiba.resizable(0, 0)
    hiba.geometry("120x100")
    hiba.title("Figyelmeztetés")
    cimke = Label(hiba, text="Nem oszthatsz 0-val! ! \n Más számot adj meg.")
    cimke.pack(side="top", fill="x", pady=10)
    #A "Rendben" gomb bezárja az ablakot (destroy művelet):
    B1 = Button(hiba, text="Rendben", bg="#DDDDDD", command=hiba.destroy)
    B1.pack()

#Alapblak definiálása és elemek elhelyezése:
def számológép():
    alapablak = Tk()
    alapablak.title("Számológép")
    alapablak.resizable(0, 0)

    bevitt_font = font.Font(size=15)
    bevitt = Entry(alapablak, justify="right", font=bevitt_font)
    #A beviteli mező elhelyezése (0. sor, 0. oszlop, 4 egység széles, igazodjon az ablak széleihez):
    bevitt.grid(row=0, column=0, columnspan=4,
               sticky=N + W + S + E, padx=5, pady=5)
#Háttérszínek a különböző gombokhoz:
    szamolas_gomb_hatter = '#FF6600'
    szam_gomb_hatter = '#4B4B4B'
    masik_gomb_hatter = '#DDDDDD'
    text_hatter = '#FFFFFF'
    aktiv_gomb_hatter = '#C0C0C0'
#Gombok létrehozása és elhelyezése:
    szam_gomb = partial(Button, alapablak, fg=text_hatter, bg=szam_gomb_hatter,
                         padx=10, pady=3, activebackground=aktiv_gomb_hatter)
    szamolas_gomb = partial(Button, alapablak, fg=text_hatter, bg=szamolas_gomb_hatter,
                         padx=10, pady=3, activebackground=aktiv_gomb_hatter)
    gomb7 = szam_gomb(text='7', bg=szam_gomb_hatter,
                         command=lambda: input_kezelo(bevitt, '7'))
    gomb7.grid(row=2, column=0, pady=5)

    gomb8 = szam_gomb(text='8', command=lambda: input_kezelo(bevitt, '8'))
    gomb8.grid(row=2, column=1, pady=5)

    gomb9 = szam_gomb(text='9', command=lambda: input_kezelo(bevitt, '9'))
    gomb9.grid(row=2, column=2, pady=5)

    gomb10 = szamolas_gomb(text='+', command=lambda: input_kezelo(bevitt, '+'))
    gomb10.grid(row=4, column=3, pady=5)

    gomb4 = szam_gomb(text='4', command=lambda: input_kezelo(bevitt, '4'))
    gomb4.grid(row=3, column=0, pady=5)

    gomb5 = szam_gomb(text='5', command=lambda: input_kezelo(bevitt, '5'))
    gomb5.grid(row=3, column=1, pady=5)

    gomb6 = szam_gomb(text='6', command=lambda: input_kezelo(bevitt, '6'))
    gomb6.grid(row=3, column=2, pady=5)

    gomb11 = szamolas_gomb(text='-', command=lambda: input_kezelo(bevitt, '-'))
    gomb11.grid(row=3, column=3, pady=5)

    gomb1 = szam_gomb(text='1', command=lambda: input_kezelo(bevitt, '1'))
    gomb1.grid(row=4, column=0, pady=5)

    gomb2 = szam_gomb(text='2', command=lambda: input_kezelo(bevitt, '2'))
    gomb2.grid(row=4, column=1, pady=5)

    gomb3 = szam_gomb(text='3', command=lambda: input_kezelo(bevitt, '3'))
    gomb3.grid(row=4, column=2, pady=5)

    gomb12 = szamolas_gomb(text='*', command=lambda: input_kezelo(bevitt, '*'))
    gomb12.grid(row=2, column=3, pady=5)

    gomb0 = szam_gomb(text='0', command=lambda: input_kezelo(bevitt, '0'))
    gomb0.grid(row=5, column=0,  pady=5)

    gomb13 = szam_gomb(text='.', command=lambda: input_kezelo(bevitt, '.'))
    gomb13.grid(row=5, column=1, pady=5)

    gomb14 = Button(alapablak, text='/', fg=text_hatter, bg=szamolas_gomb_hatter, padx=10, pady=3,
                      command=lambda: input_kezelo(bevitt, '/'))
    gomb14.grid(row=1, column=3, pady=5)

    gomb15 = Button(alapablak, text='<-', bg=masik_gomb_hatter, padx=10, pady=3,
                      command=lambda: backspace(bevitt), activebackground=aktiv_gomb_hatter)
    gomb15.grid(row=1, column=0, columnspan=2,
                  padx=3, pady=5, sticky=N + S + E + W)

    gomb16 = Button(alapablak, text='C', bg=masik_gomb_hatter, padx=10, pady=3,
                      command=lambda: kiurit(bevitt), activebackground=aktiv_gomb_hatter)
    gomb16.grid(row=1, column=2, pady=5)

    gomb17 = Button(alapablak, text='=', fg=text_hatter, bg=szamolas_gomb_hatter, padx=10, pady=3,
                      command=lambda: szamolo(bevitt), activebackground=aktiv_gomb_hatter)
    gomb17.grid(row=5, column=3, pady=5)

    gomb18 = Button(alapablak, text='^', fg=text_hatter, bg=szamolas_gomb_hatter, padx=10, pady=3,
                      command=lambda: input_kezelo(bevitt, '**'))
    gomb18.grid(row=5, column=2, pady=5)



    def kilepes():
        exit['command'] = alapablak.quit()
    exit = Button(alapablak, text='Kilépés', fg='white', bg='black', command=kilepes, height=1, width=7)
    exit.grid(row=6, column=1)

    alapablak.mainloop()


if __name__ == '__main__':
    számológép()
