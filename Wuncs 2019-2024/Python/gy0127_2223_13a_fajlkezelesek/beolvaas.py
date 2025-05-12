f = open("kiir2.csv","r")
#print(f.read())
sorok = []
f.readline() #Ha van fejléc akkor kell mert azt nem tároljuk el.
for sor in f:
    sorok.append(sor.strip())
print(sorok)