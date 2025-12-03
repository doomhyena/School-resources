# r: Olvasunk a fájlból.
# w: Felülírja és újraírja a fájlt. Ha nem létezik, létrehozza.
# a: Bővíti a fájlt.
f = open("kiir.txt","a",encoding="utf-8")
f.write("Alma\n")
f.write("Körte")
f.close()

f = open("kiir2.csv","w") #csv esetén érdemes kihagyni az encodingot!
import random as rnd
f.write("Név;Kor\n")
for i in range(100):
    f.write("Név"+str(i)+";"+str(rnd.randint(17,50))+"\n")
f.close()