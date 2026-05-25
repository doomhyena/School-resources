#Ez egy REST API lesz, ami teendőket fog tárolni/módosítani:
'''
Előkészítés:
    - Python telepítés (Add to PATH és Install pip bepipálva)
    - cmd --> pip install flask (vagy pip3 install flask)
    - PyCharm-ban a hivatalos Python interpreter kiválasztása
    - Itt fut majd: http://localhost:5000/teendok
'''
from flask import Flask, jsonify, request, abort

app = Flask(__name__)

#Alap teendők, szótárlistaként:
teendok = [
    {"azonosito": 1, "cim": "Tej vásárlása", "kesz": False},
    {"azonosito": 2, "cim": "Flask telepítése", "kesz": False}
]

#Egy adott teendő megkeresése ID alapján:
def teendokeres(azonosito):
    return next((teendo for teendo in teendok if teendo["azonosito"] == azonosito), None)
    #next(): elkerüli a hibakódot, ha nem talál semmit

#Összes tárolt teendő listázása:
@app.route("/teendok", methods=["GET"]) #Ehhez az elésési úthoz hozzárendelünk egy GET műveletet
def osszes_teendo():
    return jsonify(teendok)

#Rákeresés egy konkrét feladatra:
@app.route("/teendok/<int:azonosito>", methods=["GET"]) #GET: Beolvasási művelet
def egy_teendo(azonosito):
    teendo = teendokeres(azonosito)
    if teendo is None:
        abort(404)
    return jsonify(teendo)

#Egy új teendő felvétele:
@app.route("/teendok>", methods=["POST"]) #POST: Létrehozási művelet
def uj_teendo():
    if not request.json or "cim" not in request.json:
        abort(400)
    #Kell neki egy ID, ami 1-el nagyobb a legutóbbinál (vagy 0 alapból):
    uj_azonosito = max([teendo["azonosito"] for teendo in teendok], default=0) + 1
    teendo = { #Új teendő-sablon megadása
        "azonosito": uj_azonosito,
        "cim": request.json["cim"],
        "kesz": False
    }
    teendok.append(teendo) #Létrehozott elem hozzáfűzése a listához
    return jsonify(teendo), 201 #201-es kód: "Létrehozva"

#Létező teendő módosítása:
@app.route("/teendok/<int:azonosito>", methods=["PUT"]) #PUT: módosítási művelet
def teendomodositas(azonosito): #Beazonosítás ID alapján
    teendo = teendokeres(azonosito)
    if teendo is None:
        abort(404)
    if not request.json:
        abort(400)
    teendo["cim"] = request.json.get("cim", teendo["cim"])
    teendo["kesz"] = request.json.get("kesz", teendo["kesz"])
    return jsonify(teendo)

#Teendő törlése a listából:
@app.route("/teendok/<int:azonosito>", methods=["DELETE"]) #DELETE: törlési művelet
def teendotorles(azonosito): #Beazonosítás ID alapján
    teendo = teendokeres(azonosito)
    if teendo is None: #Ha nem találja ezt a listaelemet
        abort(404) #Akkor 404-es hiát dob
    teendok.remove(teendo) #Egyébként meg vegye le a listából ezt a teendőt
    return jsonify({"eredmeny": True})

#Futtatás kezdése debugging módban:
if __name__ == "__main__":
    app.run(debug=True)
