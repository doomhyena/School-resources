from flask import Flask, jsonify, request, abort

app = Flask(__name__)

diakok = []
vizsgak = []
feladatok = []
beadasok = []

def keres(lista, azonosito):
    return next((elem for elem in lista if elem["azonosito"] == azonosito), None)

#Diákok kezelése:
@app.route("/diakok", methods=["POST"])
def uj_diak():
    if not request.json or not "nev" in request.json:
        abort(400, "Név megadása kötelező.") #400 = nem feldolgozható request
    uj_id = max([d["azonosito"] for d in diakok], default=0) + 1
    diak = {
        "azonosito": uj_id,
        "nev": request.json["nev"],
        "email": request.json.get("email", "")
    }
    diakok.append(diak)
    return jsonify(diak), 201 #201 = létrehozva

@app.route("/diakok", methods=["GET"])
def osszes_diak():
    return jsonify(diakok)

#Vizsgák kezelése:
@app.route("/vizsgak", methods=["POST"])
def uj_vizsga():
    if not request.json or not "cim" in request.json or not "idopont" in request.json:
        abort(400, "Cím és időpont megadása kötelező.")
    uj_id = max([v["azonosito"] for v in vizsgak], default=0) + 1
    vizsga = {
        "azonosito": uj_id,
        "cim": request.json["cim"],
        "idopont": request.json["idopont"]
    }
    vizsgak.append(vizsga)
    return jsonify(vizsga), 201

@app.route("/vizsgak", methods=["GET"])
def osszes_vizsga():
    return jsonify(vizsgak)

#Feladatok kezelése:
@app.route("/feladatok", methods=["POST"])
def uj_feladat():
    if not request.json or not all(k in request.json for k in ("vizsga_azonosito", "szoveg", "pontszam")):
        abort(400, "Hiányzó mezők a feladatnál.")
    if not keres(vizsgak, request.json["vizsga_azonosito"]):
        abort(404, "Nincs ilyen vizsga.")
    uj_id = max([f["azonosito"] for f in feladatok], default=0) + 1
    feladat = {
        "azonosito": uj_id,
        "vizsga_azonosito": request.json["vizsga_azonosito"],
        "szoveg": request.json["szoveg"],
        "pontszam": request.json["pontszam"]
    }
    feladatok.append(feladat)
    return jsonify(feladat), 201

@app.route("/feladatok/<int:vizsga_azonosito>", methods=["GET"])
def vizsga_feladatai(vizsga_azonosito):
    if not keres(vizsgak, vizsga_azonosito):
        abort(404, "Nincs ilyen vizsga.")
    lista = [f for f in feladatok if f["vizsga_azonosito"] == vizsga_azonosito]
    return jsonify(lista)

#Feladat beadása:
@app.route("/beadasok", methods=["POST"])
def uj_beadas():
    if not request.json or not all(k in request.json for k in ("diak_azonosito", "feladat_azonosito", "valasz")):
        abort(400, "Hiányzó mezők a beadásnál.")
    if not keres(diakok, request.json["diak_azonosito"]):
        abort(404, "Nincs ilyen diák.")
    if not keres(feladatok, request.json["feladat_azonosito"]):
        abort(404, "Nincs ilyen feladat.")
    # Egyszerűség kedvéért egy diák egy feladathoz egyszer adhat be megoldást
    if any(b for b in beadasok if b["diak_azonosito"] == request.json["diak_azonosito"] and b["feladat_azonosito"] == request.json["feladat_azonosito"]):
        abort(400, "Már van beadás erre a feladatra.")
    uj_id = max([b["azonosito"] for b in beadasok], default=0) + 1
    beadas = {
        "azonosito": uj_id,
        "diak_azonosito": request.json["diak_azonosito"],
        "feladat_azonosito": request.json["feladat_azonosito"],
        "valasz": request.json["valasz"],
        "pont": None,
        "ertekeles_szoveg": ""
    }
    beadasok.append(beadas)
    return jsonify(beadas), 201

#Értékelés:
@app.route("/beadasok/<int:beadas_azonosito>/pontozas", methods=["PUT"])
def pontozas(beadas_azonosito):
    beadas = keres(beadasok, beadas_azonosito)
    if beadas is None:
        abort(404, "Nincs ilyen beadás.")
    if not request.json or "pont" not in request.json:
        abort(400, "Pontszám megadása kötelező.")
    beadas["pont"] = request.json["pont"]
    beadas["ertekeles_szoveg"] = request.json.get("ertekeles_szoveg", "")
    return jsonify(beadas)

#Statisztikák:
@app.route("/vizsgak/<int:vizsga_azonosito>/statisztika", methods=["GET"])
def vizsga_statisztika(vizsga_azonosito):
    if not keres(vizsgak, vizsga_azonosito):
        abort(404, "Nincs ilyen vizsga.")
    felidk = [f["azonosito"] for f in feladatok if f["vizsga_azonosito"] == vizsga_azonosito]
    # Diákonként elért pontok:
    stat = {}
    for b in beadasok:
        if b["feladat_azonosito"] in felidk and b["pont"] is not None:
            stat.setdefault(b["diak_azonosito"], 0)
            stat[b["diak_azonosito"]] += b["pont"]
    # Összegzés átlaggal:
    if stat:
        atlag = sum(stat.values()) / len(stat)
    else:
        atlag = 0
    return jsonify({
        "vizsga_azonosito": vizsga_azonosito,
        "resztvevok_szama": len(stat),
        "atlagpont": atlag,
        "diak_pontok": stat
    })

if __name__ == "__main__":
    app.run(debug=True)

'''
Parancssorba:

Diák hozzáadása:
curl -X POST -H "Content-Type: application/json" -d "{\"nev\": \"Kovács Anna\", \"email\": \"anna@uni.hu\"}" http://localhost:5000/diakok
Vizsga létrehozása:
curl -X POST -H "Content-Type: application/json" -d "{\"cim\": \"Python vizsga\", \"idopont\": \"2024-06-10 10:00\"}" http://localhost:5000/vizsgak
Feladat létrehozása a vizsgához (pl. azonosító: 1):
curl -X POST -H "Content-Type: application/json" -d "{\"vizsga_azonosito\": 1, \"szoveg\": \"Mi az a lista?\", \"pontszam\": 5}" http://localhost:5000/feladatok
Beadás (megoldás beküldése):
curl -X POST -H "Content-Type: application/json" -d "{\"diak_azonosito\": 1, \"feladat_azonosito\": 1, \"valasz\": \"Olyan adatszerkezet, amely...\"}" http://localhost:5000/beadasok
Pontozás, értékelés:
curl -X PUT -H "Content-Type: application/json" -d "{\"pont\": 5, \"ertekeles_szoveg\": \"Helyes válasz!\"}" http://localhost:5000/beadasok/1/pontozas
Statisztika lekérdezése:
curl http://localhost:5000/vizsgak/1/statisztika

Minden diák lekérdezése:
http://localhost:5000/diakok

Minden vizsga lekérdezése:
http://localhost:5000/vizsgak

Feladatok egy vizsgához:
http://localhost:5000/feladatok/1
(Az 1 a vizsga azonosítója!)

Statisztika egy vizsgáról:
http://localhost:5000/vizsgak/1/statisztika
'''
