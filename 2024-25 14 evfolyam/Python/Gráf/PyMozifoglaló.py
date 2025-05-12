import tkinter as tk
import tkinter.ttk

filmvasznak = ["V 1", "V 2", "V 3", "V 4", "V 5", "V 6"]

filmek = {"Horror": ["The Nun", "Dracula Untold", "Feral", "Shin Godzilla", "Black Death"],
          "Akció": ["Venom", "Robin Hood", "Aquaman", "Artemis Fowl", "The Predator"],
          "Dráma": ["Creed", "Creed 2", "Outlaw King", "Peppermint", "Sicario: Day of the Soldado"],
          "Vígjáték": ["Step Brothers", "The Hangover", "Horrible Bosses", "The Other Guys", "Let's Be Cops"],
          "Sci-Fi": ["The Matrix", "Solaris", "Blade Runner", "Interstellar", "Sunshine"],
          "Romantikus": ["Ghost", "Sliding Doors", "50 Shades of Grey", "Titanic", "La La Land"]}

idopontok = ["10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00",
         "22:00", "23:00"]

ulesLista = []
megjeloltUlesek = []

class Program(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Mozijegy foglalás")
        self.segedLetrehoz()

    def filmetFrissit(self,event=None):
        self.filmCB['values'] = filmek[self.mufajCB.get()]

    def segedLetrehoz(self):
        #Fejrész:
        fejlecCimke = tk.Label(self, text="Foglalások",font="Roboto 12")
        fejlecCimke.grid(row=0,column=0,columnspan=5,padx=10, pady=10,sticky="w")
        tkinter.ttk.Separator(self,orient="horizontal").grid(row=1,column=0,columnspan=5,sticky="ew")
        #Nap szegmens:
        nap = tk.Frame(self)
        tk.Label(nap, text="________").pack()
        tk.Label(nap,text="Ma", font='Helvetica 10 underline').pack()
        tk.Label(nap, text="").pack()
        nap.grid(row=2,column=0,padx=10)
        #Műfaj választás opció:
        tk.Label(self, text="Műfaj: ").grid(row=2,column=1,padx=(10,0))
        self.mufajCB = tkinter.ttk.Combobox(self, width=15, values=list(filmek.keys()), state="readonly")
        self.mufajCB.set("Válassz")
        self.mufajCB.bind('<<ComboboxSelected>>',self.filmetFrissit)
        self.mufajCB.grid(row=2,column=2)
        #Film választása (a választott kategórián belül):
        tk.Label(self, text="Film: ").grid(row=2, column=3, padx=(10, 0))
        self.filmCB = tkinter.ttk.Combobox(width=15, state="readonly")
        self.filmCB.bind('<<ComboboxSelected>>', self.gombotLetrehoz)
        self.filmCB.set("Filmválasztás")
        self.filmCB.grid(row=2, column=4,padx=(0,10))
        #Újabb elválasztó:
        tkinter.ttk.Separator(self,orient="horizontal").grid(row=3,column=0,columnspan=5, sticky="ew")
    #Filmválasztás után listázza az időpontokat, mindegyik kapjon egy gombot:
    def gombotLetrehoz(self,event=None):
        tk.Label(self,text='Időpont választás',font='Roboto 11 bold underline').grid(row=4,column=2,columnspan=2,pady=5) #előző sorhoz
        Ido = tk.Frame(self)
        Ido.grid(row=5,column=0,columnspan=5)
        for i in range(14):
            tk.Button(Ido,text=idopontok[i],command=self.ulesValasztas).grid(row=4+i//7,column=i%7)

    def ulesValasztas(self):
        uvAblak = tk.Toplevel() #Új ülésválasztó felület jelenik meg
        uvAblak.title("Válassz ülést")
        valasztasCimke = tk.Label(uvAblak,text="Ülőhely választás",font="Roboto 12")
        valasztasCimke.grid(row=0,column=0,columnspan=5,padx=10,pady=(10,0),sticky="w")
        segedFrame = tk.Frame(uvAblak)
        segedFrame.grid(row=1,column=0)
        tk.Label(segedFrame,text='Kék - kiválasztva', fg='blue').grid(row=0,column=0,padx=10)
        tk.Label(segedFrame, text='Piros - foglalt', fg='brown').grid(row=0, column=1, padx=10)
        tk.Label(segedFrame, text='Zöld - foglalható', fg='green').grid(row=0, column=2, padx=10)
        tkinter.ttk.Separator(uvAblak,orient="horizontal").grid(row=2,column=0,padx=(0,5),sticky="ew")

        w = tk.Canvas(uvAblak,width=500,height=15)
        w.create_rectangle(10,0,490,10,fill='black')
        w.grid(row=3,column=0)
        tk.Label(uvAblak, text="Filmválaszon").grid(row=4,column=0,pady=(0,10))
        ulesek = tk.Frame(uvAblak)
        ulesek.grid(row=5,column=0)
        ulesLista.clear()
        megjeloltUlesek.clear()
        for i in range(4):
            segedLista = []
            for j in range(15):
                #'ug' mint ülés gomb
                ug = tk.Button(ulesek,bd=2,bg='Green',activebackground='forestGreen',command=lambda x=i, y=j:self.kivalasztva(x,y))
                segedLista.append(ug)
                ug.grid(row=i, column=j, padx=5,pady=5)
            ulesLista.append(segedLista)
        tk.Button(uvAblak,text="Lefoglal",bg='black',fg='white',activebackground='black',activeforeground='white',command=self.lefoglal).grid(row=6,column=0,pady=10)
    #a kiválasztva függvény átszínezi a megjelölt ülésgombokat:
    def kivalasztva(self, i, j):
        if ulesLista[i][j]['bg'] == 'blue':
            ulesLista[i][j]['bg'] = 'green'
            ulesLista[i][j]['activebackground'] = 'forestGreen'
            megjeloltUlesek.remove((i,j))
            return
        ulesLista[i][j]['bg'] = 'blue'
        ulesLista[i][j]['activebackground'] = 'blue'
        megjeloltUlesek.append((i,j))

    def lefoglal(self):
    #A "Lefoglal" gomb megnyomására a kijelölt ülések mind átszíneződnek pirosra
        for i in megjeloltUlesek:
            ulesLista[i[0]][i[1]]['bg'] = 'brown' #barnát állítunk be, de ez pirosként jelenik majd meg
            ulesLista[i[0]][i[1]]['activebackground'] = 'brown'
            ulesLista[i[0]][i[1]]['relief'] = 'sunken'

app = Program()
app.mainloop()








