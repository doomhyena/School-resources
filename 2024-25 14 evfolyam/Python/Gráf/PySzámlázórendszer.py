from tkinter import*
import random
import os   #operációs rendszerrel való mögöttes interakcióhoz
from tkinter import messagebox  #felugró üzenetekhez

class SzamlaProg:
    def __init__(self, root): #root-nak nevezzük az ablakot
        self.root = root
        self.root.geometry("1350x700+0+0")
        self.root.title("Számlázó rendszer")
        bg_color = "#badc57"
        title = Label(self.root, text="Számlázó rendszer",
        font=('times new roman', 30, 'bold'), pady=2, bd=12, bg="#badc57", fg="Black", relief=GROOVE)
        #bg = háttérszín, #bd = border mérete, #relief = felület megjelenés stílusa)
        title.pack(fill=X)
    #Mögöttes segédváltozók a különböző termék- és ügyféladatokhoz (elemek közti adatkezelés):
        self.fertotlenito = IntVar()
        self.maszk = IntVar()
        self.kesztyu = IntVar()
        self.zsebkendo = IntVar()
        self.orrspray = IntVar()
        self.lazmero = IntVar()

        self.rizs = IntVar()
        self.etolaj = IntVar()
        self.magvak = IntVar()
        self.teszta = IntVar()
        self.liszt = IntVar()
        self.leveskocka = IntVar()

        self.sprite = IntVar()
        self.kofola = IntVar()
        self.asvanyviz = IntVar()
        self.coke = IntVar()
        self.fanta = IntVar()
        self.mountain_dew = IntVar()
    #Összesített végösszegek:
        self.med_ossz = StringVar()
        self.etel_ossz = StringVar()
        self.ital_ossz = StringVar()
    #Ügyfél adatai:
        self.ugyfnev = StringVar()
        self.ugyfmobil = StringVar()
        self.szlaszam = StringVar()
        x = random.randint(1000, 9999) #számlaszám: rendom szám 1000 és 9999 közt
        self.szlaszam.set(str(x)) #el is tároljuk string formában
        self.szlakeres = StringVar()
    #Adószámításhoz:
        self.med_ado = StringVar()
        self.etel_ado = StringVar()
        self.ital_ado = StringVar()
    #Ügyfél keresése a tárolt adatokban:
        F1 = LabelFrame(self.root, text="Ügyféladatok", font=('times new roman', 15, 'bold'),
            bd=10, fg="Black", bg="#badc57")
        F1.place(x=0, y=80, relwidth=1)
        #LabelFrame(): alfelület az ablakon belül
        #Cimkék és szövegdobozok a 3 kereshető adatnak:
        ugyfNevCimke = Label(F1, text="Ügyfél neve:", bg=bg_color, font=('times new roman', 15, 'bold'))
        ugyfNevCimke.grid(row=0, column=0, padx=20, pady=5) #Elhelyezés a LabelFrame rácsszerkezetén
        ugyfNevDoboz = Entry(F1, width=15, textvariable=self.ugyfnev, font='arial 15', bd=7, relief=GROOVE)
        ugyfNevDoboz.grid(row=0, column=1, pady=5, padx=10)

        ugyfTelCimke = Label(F1, text="Ügyfél mobilja:", bg="#badc57", font=('times new roman', 15, 'bold'))
        ugyfTelCimke.grid(row=0, column=2, padx=20, pady=5)
        ugyfTelDoboz = Entry(F1, width=15, textvariable=self.ugyfmobil, font='arial 15', bd=7, relief=GROOVE)
        ugyfTelDoboz.grid(row=0, column=3, pady=5, padx=10)

        szlaSzamCimke = Label(F1, text="Számlaszám:", bg="#badc57", font=('times new roman', 15, 'bold'))
        szlaSzamCimke.grid(row=0, column=4, padx=20, pady=5)
        szlaSzamDoboz = Entry(F1, width=15, textvariable=self.szlakeres, font='arial 15', bd=7, relief=GROOVE)
        szlaSzamDoboz.grid(row=0, column=5, pady=5, padx=10)
        #Keresés gomb:
        keres_gomb = Button(F1, text="Keres", command=self.szlakeres, width=10, bd=7, font=('arial', 12, 'bold'),
            relief=GROOVE)
        keres_gomb.grid(row=0, column=6, pady=5, padx=10)

    #Felület, ahol megadhatjuk, hogy melyik egészségügyi termékből hány darabot vásárolnánk:
        F2 = LabelFrame(self.root, text="Egészségügyi termékek", font=('times new roman', 15, 'bold'), bd=10, fg="Black",
        bg="#badc57")
        F2.place(x=5, y=180, width=325, height=380) #elhelyezés az ablak adott részén

        fertotlenitoCimke = Label(F2, text="Fertőtlenítő", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        fertotlenitoCimke.grid(row=0, column=0, padx=10, pady=10, sticky='W') #sticky='W' = ez az elem az ablak bal oldalához igazodik
        fertotlenitoDoboz = Entry(F2, width=10, textvariable=self.fertotlenito, font=('times new roman', 16, 'bold'),
        bd=5, relief=GROOVE)
        fertotlenitoDoboz.grid(row=0, column=1, padx=10, pady=10)

        maszkCimke = Label(F2, text="Maszk", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        maszkCimke.grid(row=1, column=0, padx=10, pady=10, sticky='W')
        maszkDoboz = Entry(F2, width=10, textvariable=self.maszk, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        maszkDoboz.grid(row=1, column=1, padx=10, pady=10)

        kesztyuCimke = Label(F2, text="Kesztyű", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        kesztyuCimke.grid(row=2, column=0, padx=10, pady=10, sticky='W')
        kesztyuDoboz = Entry(F2, width=10, textvariable=self.kesztyu, font=('times new roman', 16, 'bold'), bd=5, relief =GROOVE)
        kesztyuDoboz.grid(row=2, column=1, padx=10, pady=10)

        orrsprayCimkle = Label(F2, text="Orrspray", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        orrsprayCimkle.grid(row=3, column=0, padx=10, pady=10, sticky='W')
        orrsprayDoboz = Entry(F2, width=10, textvariable=self.zsebkendo, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        orrsprayDoboz.grid(row=3, column=1, padx=10, pady=10)

        zsebkendoCimke = Label(F2, text="Zsebkendő", font =('times new roman', 16, 'bold'), bg = "#badc57", fg = "black")
        zsebkendoCimke.grid(row=4, column=0, padx=10, pady=10, sticky='W')
        zsebkendoDoboz = Entry(F2, width=10, textvariable=self.orrspray, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        zsebkendoDoboz.grid(row=4, column=1, padx=10, pady=10)

        lazmeroCimke = Label(F2, text="Lázmérő", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        lazmeroCimke.grid(row=5, column=0, padx=10, pady=10, sticky='W')
        lazmeroDoboz = Entry(F2, width=10, textvariable=self.lazmero, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        lazmeroDoboz.grid(row=5, column=1, padx=10, pady=10)

    #Felület, ahol megadhatjuk, hogy melyik élelmiszeri termékből hány darabot vásárolnánk:
        F3 = LabelFrame(self.root, text="Élelmiszerek", font=('times new roman', 15, 'bold'), bd=10, fg="Black", bg="#badc57")
        F3.place(x=340, y=180, width=325, height=380)

        rizsCimke = Label(F3, text="Rizs", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        rizsCimke.grid(row=0, column=0, padx=10, pady=10, sticky='W')
        rizsDoboz = Entry(F3, width=10, textvariable=self.rizs, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        rizsDoboz.grid(row=0, column=1, padx=10, pady=10)

        etolajCimke = Label(F3, text="Étolaj", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        etolajCimke.grid(row=1, column=0, padx=10, pady=10, sticky='W')
        etolajDoboz = Entry(F3, width=10, textvariable=self.etolaj, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        etolajDoboz.grid(row=1, column=1, padx=10, pady=10)

        magvakCimke = Label(F3, text="Magvak", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        magvakCimke.grid(row=2, column=0, padx=10, pady=10, sticky='W')
        magvakDoboz = Entry(F3, width=10, textvariable=self.magvak, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        magvakDoboz.grid(row=2, column=1, padx=10, pady=10)

        tesztaCimke = Label(F3, text="Daal", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        tesztaCimke.grid(row=3, column=0, padx=10, pady=10, sticky='W')
        tesztaDoboz = Entry(F3, width=10, textvariable=self.teszta, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        tesztaDoboz.grid(row=3, column=1, padx=10, pady=10)

        LisztCimke = Label(F3, text="Liszt", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        LisztCimke.grid(row=4, column=0, padx=10, pady=10, sticky='W')
        lisztDoboz = Entry(F3, width=10, textvariable=self.liszt, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        lisztDoboz.grid(row=4, column=1, padx=10, pady=10)

        LeveskockaCimke = Label(F3, text="Maggi", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        LeveskockaCimke.grid(row=5, column=0, padx=10, pady=10, sticky='W')
        leveskockaDoboz = Entry(F3, width=10, textvariable=self.leveskocka, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        leveskockaDoboz.grid(row=5, column=1, padx=10, pady=10)

    #Felület, ahol megadhatjuk, hogy melyik italtermékből hány darabot vásárolnánk:
        F4 = LabelFrame(self.root, text="Üdítők", font=('times new roman', 15, 'bold'), bd=10, fg="Black", bg="#badc57")
        F4.place(x=670, y=180, width=325, height=380)

        spriteCimke = Label(F4, text="Sprite", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        spriteCimke.grid(row=0, column=0, padx=10, pady=10, sticky='W')
        spriteDoboz = Entry(F4, width=10, textvariable=self.sprite, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        spriteDoboz.grid(row=0, column=1, padx=10, pady=10)

        kofolaCimke = Label(F4, text="Kofola", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        kofolaCimke.grid(row=1, column=0, padx=10, pady=10, sticky='W')
        kofolaDoboz = Entry(F4, width=10, textvariable=self.kofola, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        kofolaDoboz.grid(row=1, column=1, padx=10, pady=10)

        asvanyvizCimke = Label(F4, text="Ásványvíz", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        asvanyvizCimke.grid(row=2, column=0, padx=10, pady=10, sticky='W')
        asvanyvizDoboz = Entry(F4, width=10, textvariable=self.asvanyviz, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        asvanyvizDoboz.grid(row=2, column=1, padx=10, pady=10)

        cokeCimke = Label(F4, text="Kóla", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        cokeCimke.grid(row=3, column=0, padx=10, pady=10, sticky='W')
        cokeDoboz = Entry(F4, width=10, textvariable=self.coke, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        cokeDoboz.grid(row=3, column=1, padx=10, pady=10)

        fantaCimke = Label(F4, text="Fanta", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        fantaCimke.grid(row=4, column=0, padx=10, pady=10, sticky='W')
        fantaDoboz = Entry(F4, width=10, textvariable=self.fanta, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        fantaDoboz.grid(row=4, column=1, padx=10, pady=10)

        mdCimke = Label(F4, text="Mountain Dew", font=('times new roman', 16, 'bold'), bg="#badc57", fg="black")
        mdCimke.grid(row=5, column=0, padx=10, pady=10, sticky='W')
        mdDoboz = Entry(F4, width=10, textvariable=self.mountain_dew, font=('times new roman', 16, 'bold'), bd=5, relief=GROOVE)
        mdDoboz.grid(row=5, column=1, padx=10, pady=10)

    #Számla részletei
        F5 = Frame(self.root, bd=10, relief=GROOVE)
        F5.place(x=1010, y=180, width=350, height=380)

        bill_title = Label(F5, text="Számla", font='arial 15 bold', bd=7, relief=GROOVE)
        bill_title.pack(fill=X)
        scroll_y = Scrollbar(F5, orient=VERTICAL)
        self.szovegter = Text(F5, yscrollcommand=scroll_y.set)
        scroll_y.pack(side=RIGHT, fill=Y)
        scroll_y.config(command=self.szovegter.yview)
        self.szovegter.pack(fill=BOTH, expand=1)

    #Gombok:
        F6 = LabelFrame(self.root, text="Számla", font=('times new roman', 14, 'bold'), bd=10, fg="Black", bg="#badc57")
        F6.place(x=0, y=560, relwidth=1, height=140)

        m1_lbl = Label(F6, text="Összesített orvosi számla", font=('times new roman', 14, 'bold'), bg="#badc57", fg="black")
        m1_lbl.grid(row=0, column=0, padx=20, pady=1, sticky='W')
        m1_txt = Entry(F6, width=18, textvariable=self.med_ossz, font='arial 10 bold', bd=7, relief=GROOVE)
        m1_txt.grid(row=0, column=1, padx=18, pady=1)

        m2_lbl = Label(F6, text="Összesített ételszámla", font=('times new roman', 14, 'bold'), bg="#badc57", fg="black")
        m2_lbl.grid(row=1, column=0, padx=20, pady=1, sticky='W')
        m2_txt = Entry(F6, width=18, textvariable=self.etel_ossz, font='arial 10 bold', bd=7, relief=GROOVE)
        m2_txt.grid(row=1, column=1, padx=18, pady=1)

        m3_lbl = Label(F6, text="Összesített italszámla", font=('times new roman', 14, 'bold'), bg="#badc57", fg="black")
        m3_lbl.grid(row=2, column=0, padx=20, pady=1, sticky='W')
        m3_txt = Entry(F6, width=18, textvariable=self.ital_ossz, font='arial 10 bold', bd=7, relief=GROOVE)
        m3_txt.grid(row=2, column=1, padx=18, pady=1)

        m4_lbl = Label(F6, text="Orvosság adó", font=('times new roman', 14, 'bold'), bg="#badc57", fg="black")
        m4_lbl.grid(row=0, column=2, padx=20, pady=1, sticky='W')
        m4_txt = Entry(F6, width=18, textvariable=self.med_ado, font='arial 10 bold', bd=7, relief=GROOVE)
        m4_txt.grid(row=0, column=3, padx=18, pady=1)

        m5_lbl = Label(F6, text="Élelmiszer adó", font=('times new roman', 14, 'bold'), bg="#badc57", fg="black")
        m5_lbl.grid(row=1, column=2, padx=20, pady=1, sticky='W')
        m5_txt = Entry(F6, width=18, textvariable=self.etel_ado, font='arial 10 bold', bd=7, relief=GROOVE)
        m5_txt.grid(row=1, column=3, padx=18, pady=1)

        m6_lbl = Label(F6, text="Ital adó", font=('times new roman', 14, 'bold'), bg="#badc57", fg="black")
        m6_lbl.grid(row=2, column=2, padx=20, pady=1, sticky='W')
        m6_txt = Entry(F6, width=18, textvariable=self.ital_ado, font='arial 10 bold', bd=7, relief=GROOVE)
        m6_txt.grid(row=2, column=3, padx=18, pady=1)

        btn_f = Frame(F6, bd=7, relief=GROOVE)
        btn_f.place(x=760, width=580, height=105)

        total_btn = Button(btn_f, command=self.összesen, text="Összesen", bg="#535C68", bd=2, fg="white", pady=15, width=12,
        font='arial 13 bold')
        total_btn.grid(row=0, column=0, padx=5, pady=5)

        generateBill_btn = Button(btn_f, command=self.szamla_felülete, text="Számlakiállítás", bd=2, bg="#535C68",
        fg="white", pady=12, width=12, font='arial 13 bold')
        generateBill_btn.grid(row=0, column=1, padx=5, pady=5)

        clear_btn = Button(btn_f, command=self.kiurites, text="Kiürít", bg="#535C68", bd=2, fg="white", pady=15,
        width=12, font='arial 13 bold')
        clear_btn.grid(row=0, column=2, padx=5, pady=5)

        exit_btn = Button(btn_f, command=self.kilepes, text="Kilép", bd=2, bg="#535C68", fg="white", pady=15,
        width=12, font='arial 13 bold')
        exit_btn.grid(row=0, column=3, padx=5, pady=5)
        self.elso_mezo()

#Összesített számla összerakása:
    def összesen(self):
        self.keszAr = self.kesztyu.get()*12
        self.fertAr = self.fertotlenito.get()*2
        self.maszkAr = self.maszk.get()*5
        self.zsebAr = self.zsebkendo.get()*30
        self.orrAr = self.orrspray.get()*5
        self.lazmAr = self.lazmero.get()*15
        self.osszMedArak = float(self.maszkAr+self.keszAr+self.zsebAr+self.orrAr+self.lazmAr+self.fertAr)

        self.med_ossz.set("HUF "+str(self.osszMedArak))
        self.orvAdo = round((self.osszMedArak*0.05), 2)
        self.med_ado.set("HUF "+str(self.orvAdo))

        self.rizsAr = self.rizs.get()*10
        self.eoAr = self.etolaj.get()*10
        self.magAr = self.magvak.get()*10
        self.teszAr = self.teszta.get()*6
        self.liAr = self.liszt.get()*8
        self.levAr = self.leveskocka.get()*5
        self.osszEtelArak = float(self.rizsAr+self.eoAr+self.magAr+self.teszAr+self.liAr+self.levAr)

        self.etel_ossz.set("HUF " + str(self.osszEtelArak))
        self.eAdo = round((self.osszEtelArak*5), 2)
        self.etel_ado.set("HUF " + str(self.eAdo))

        self.sprAr = self.sprite.get()*10
        self.kofAr = self.kofola.get()*10
        self.avAr = self.asvanyviz.get()*10
        self.cokeAr = self.coke.get()*10
        self.fantaAr = self.fanta.get()*10
        self.mdAr = self.mountain_dew.get()*10
        self.osszItalArak = float(self.sprAr+self.kofAr+self.avAr+self.cokeAr+self.fantaAr+self.mdAr)

        self.ital_ossz.set("HUF "+str(self.osszItalArak))
        self.iAdo = round((self.osszItalArak * 0.1), 2)
        self.ital_ado.set("HUF "+str(self.iAdo))

        self.teljesSzamla = float(self.osszMedArak+self.osszEtelArak+self.osszItalArak+self.orvAdo+self.eAdo+self.iAdo)
#-------------------------------------
    def elso_mezo(self): #Ügyféladatok megjelenítése az ablak jobboldalán:
        self.szovegter.delete('1.0',END) #előző adatok kiürítése
        self.szovegter.insert(END, "\tSzámla részletei")
        self.szovegter.insert(END, f"\nSzámlaszám: {self.szlaszam.get()}")
        self.szovegter.insert(END, f"\nÜgyfél: {self.ugyfnev.get()}")
        self.szovegter.insert(END, f"\nTelefon: {self.ugyfmobil.get()}")
        self.szovegter.insert(END, f"\n----------------------------")
        self.szovegter.insert(END, f"\nTermékek\t\tMenny\t\tÁr")
    #Számlafelület:
    def szamla_felülete(self):
        if self.ugyfnev.get() == " " or self.ugyfmobil.get() == " ":
            messagebox.showerror("Hoba","Hiányzó ügyféladat!") #hibaüzenet kiírás
        elif self.med_ossz.get() == "HUF 0.0" and self.etel_ossz.get() == "HUF 0.0" and self.ital_ossz.get() == "HUF 0.0": #előző sorhoz
            messagebox.showerror("Hiba","Nincs termék!")
        else:
            self.elso_mezo()
    #Termékek egyenkénti felvitele a vásárlandó listára:
    #Egészségügyiek:
        if self.fertotlenito.get() != 0: #Ha legalább 1 fertőtlenítőt vennénk
            #Akkor beleírjuk a listába a fizetendő árával együtt:
            self.szovegter.insert(END, f"\n Fertőtlenítő\t\t{self.fertotlenito.get()}\t\t{self.fertAr}")
            #és ezt minden termékre meg kell írni
        if self.maszk.get() != 0:
            self.szovegter.insert(END, f"\n Maszk\t\t{self.maszk.get()}\t\t{self.maszkAr}")
        if self.kesztyu.get() != 0:
            self.szovegter.insert(END, f"\n Kesztyű\t\t{self.kesztyu.get()}\t\t{self.keszAr}")
        if self.zsebkendo.get() != 0:
            self.szovegter.insert(END, f"\n Zsebkendő\t\t{self.zsebkendo.get()}\t\t{self.zsebAr}")
        if self.orrspray.get() != 0:
            self.szovegter.insert(END, f"\n Orrspray\t\t{self.orrspray.get()}\t\t{self.orrAr}")
        if self.lazmero.get() != 0:
            self.szovegter.insert(END , f"\n Lázmérő\t\t{self.fertotlenito.get()}\t\t{self.lazmAr}")
    #Ételek:
        if self.rizs.get() != 0:
            self.szovegter.insert(END, f"\n Rizs\t\t{self.rizs.get()}\t\t{self.rizsAr}")
        if self.etolaj.get() != 0:
            self.szovegter.insert(END, f"\n Étolaj\t\t{self.etolaj.get()}\t\t{self.eoAr}")
        if self.magvak.get() != 0:
            self.szovegter.insert(END, f"\n Magvak\t\t{self.magvak.get()}\t\t{self.magAr}")
        if self.teszta.get() != 0:
            self.szovegter.insert(END, f"\n Tészta\t\t{self.teszta.get()}\t\t{self.teszAr}")
        if self.liszt.get() != 0:
            self.szovegter.insert(END, f"\n Liszt\t\t{self.liszt.get()}\t\t{self.liAr}")
        if self.leveskocka.get() != 0:
            self.szovegter.insert(END, f"\n Leveskocka\t\t{self.leveskocka.get()}\t\t{self.levAr}")
    #Italok:
        if self.sprite.get() != 0:
            self.szovegter.insert(END, f"\n Sprite\t\t{self.sprite.get()}\t\t{self.sprAr}")
        if self.kofola.get() != 0:
            self.szovegter.insert(END, f"\n Kofola\t\t{self.kofola.get()}\t\t{self.kofAr}")
        if self.asvanyviz.get() != 0:
            self.szovegter.insert(END, f"\n Ásványvíz\t\t{self.asvanyviz.get()}\t\t{self.avAr}")
        if self.coke.get() != 0:
            self.szovegter.insert(END, f"\n Coke\t\t{self.coke.get()}\t\t{self.cokeAr}")
        if self.fanta.get() != 0:
            self.szovegter.insert(END, f"\n Fanta\t\t{self.fanta.get()}\t\t{self.fantaAr}")
        if self.mountain_dew.get() != 0:
            self.szovegter.insert(END, f"\n Mountain Dew\t\t{self.mountain_dew.get()}\t\t{self.mdAr}")
            self.szovegter.insert(END, f"\n------------------------------------")
    #Adók:
        if self.med_ado.get() != '0.0':
            self.szovegter.insert(END, f"\n Orvosi adó\t\t{self.med_ado.get()}")
        if self.etel_ado.get() != '0.0':
            self.szovegter.insert(END, f"\n Étel adó\t\t{self.etel_ado.get()}")
        if self.ital_ado.get() != '0.0':
            self.szovegter.insert(END, f"\n Ital adó\t\t{self.ital_ado.get()}")
    #Összesítve:
        self.szovegter.insert(END,f"\n Összesítve: \t\t\t HUF{self.teljesSzamla}")
        self.szovegter.insert(END, f"\n------------------------------------")
        self.szamla_ment()
    #Metódus a számla mentésére:
    def szamla_ment(self):
        kerdez = messagebox.askyesno("Mentés","Enmented a számlát?")
        if kerdez > 0: #Akkor lesz 0, ha NEM-et válaszoltunk, 1, ha igent
            #Minden releváns adatot beolvasunk egy változóba:
            self.szla_adat = self.szovegter.get('1.0',END)
            #nyitunk egy fájlt, írásra (név: számlaszám.txt a számlák mappában:
            f1 = open("szamlak/"+str(self.szlaszam.get())+".txt","w")
            f1.write(self.szla_adat)
            f1.close()
            messagebox.showinfo("Elment",f"Számla {self.szlaszam.get()} elmentve")
        #NEM válasz esetén visszatérünk a felületre mindenféle válasz és művelet nélkül:
        else:
            return
    #Minden mező kiürítése:
    def kiurites(self):
        kerdez = messagebox.askyesno("Kiürítés","Kiürítsünk minden mezőt?")
        if kerdez > 0: #Ha Igennel válaszolt
            #Ekkor minden mezőt visszaállítunk 0-ra, üres stringre:
            self.fertotlenito.set(0)
            self.maszk.set(0)
            self.kesztyu.set(0)
            self.zsebkendo.set(0)
            self.orrspray.set(0)
            self.lazmero.set(0)

            self.rizs.set(0)
            self.etolaj.set(0)
            self.magvak.set(0)
            self.teszta.set(0)
            self.liszt.set(0)
            self.leveskocka.set(0)

            self.sprite.set(0)
            self.kofola.set(0)
            self.asvanyviz.set(0)
            self.coke.set(0)
            self.fanta.set(0)
            self.mountain_dew.set(0)

            self.med_ossz.set("")
            self.etel_ossz.set("")
            self.ital_ossz.set("")

            self.med_ado.set("")
            self.etel_ado.set("")
            self.ital_ado.set("")

            self.ugyfnev.set("")
            self.ugyfmobil.set("")

            self.szlaszam.set("")
            x = random.randint(1000,9999) #rögtön legyen is egy új számlaszám a köv. ügyfélnek
            self.szlaszam.set(str(x))

            self.szlakeres.set("")
            self.elso_mezo()
    #Kilépés gomb (előtte kérdezze meg, hogy biztos kilépsz-e):
    def kilepes(self):
        kerdez = messagebox.askyesno("Kilépés","Biztosan kilépsz?") #Igen/Nem kérdés a bezárásról
        if kerdez > 0: #Ha az Igent választota
            self.root.destroy()

#program futtatása:
root = Tk()
obj = SzamlaProg(root)
root.mainloop()













