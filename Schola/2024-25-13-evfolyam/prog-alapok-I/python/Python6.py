'''
Feladat:
Egy adott intervallumon belül akarjuk megkeresni a legnagyobb prímszámot.
Pl.: 
lnp(2,10) --> 7 (mert 2 és 10 között 7 a legnagyobb prím)
    - Ha a nagyobb szám van hamarabb, úgy tudja értelmezni
Tippek:
    for ciklus, range(), if, %, ==, belső for ciklus
'''
def lnp(a,b):
    if a > b: #Ha a nagyobb van elől, akkor felcseréljük
        c = a
        a = b
        b = c
    for i in range(b,a-1,-1): #-1: visszafele lépkedjen a nagyobbtól
        osztókszáma = 0
        for d in range(2,int(i/2)+1):
            if i % d == 0: #Ha talál egy osztót
                osztókszáma += 1 #azt számolja fel
#Ha nem talált osztókat az adott számhoz, akkor az a megoldás
#(ennél már csak kisebbeket találhatna, mert visszafele haladunk)
        if osztókszáma == 0:
            return i
