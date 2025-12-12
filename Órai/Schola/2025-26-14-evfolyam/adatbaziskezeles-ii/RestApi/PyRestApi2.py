from flask import Flask, jsonify, request, abort

app = Flask(__name__)

hallgatok = []
kurzusok = []
feliratkozasok = []

#Hallgatók kezelése:
def hallgatokeres(azonosito):
    return next((h for h in hallgatok if h["azonosito"] == azonosito), None)

def kurzuskeres(azonosito):
    return next((k for k in kurzusok if k["azonosito"] == azonosito), None)

@app.route("/hallgatok", methods=["GET"])
def osszes_hallgato():
    return jsonify(hallgatok)

@app.route("/hallgatok/<int:azonosito>", methods=["GET"])
def egy_hallgato(azonosito):
    h = hallgatokeres(azonosito)
    if h is None:
        abort(404, description="Nincs ilyen hallgató!")
    return jsonify(h)

@app.route("/hallgatok", methods=["POST"])
def uj_hallgato():
    if not request.json or not "nev" in request.json:
        abort(400, description="A név megadása kötelező.")
    uj_id = max([h["azonosito"] for h in hallgatok], default=0) + 1
    hallgato = {
        "azonosito": uj_id,
        "nev": request.json["nev"],
        "email": request.json.get("email", ""),
        "szak": request.json.get("szak", "")
    }
    hallgatok.append(hallgato)
    return jsonify(hallgato), 201

@app.route("/hallgatok/<int:azonosito>", methods=["PUT"])
def hallgatomodositas(azonosito):
    h = hallgatokeres(azonosito)
    if h is None:
        abort(404)
    if not request.json:
        abort(400)
    h["nev"] = request.json.get("nev", h["nev"])
    h["email"] = request.json.get("email", h["email"])
    h["szak"] = request.json.get("szak", h["szak"])
    return jsonify(h)

@app.route("/hallgatok/<int:azonosito>", methods=["DELETE"])
def hallgatotorles(azonosito):
    h = hallgatokeres(azonosito)
    if h is None:
        abort(404)
    global feliratkozasok
    feliratkozasok = [f for f in feliratkozasok if f["hallgato_id"] != azonosito]
    hallgatok.remove(h)
    return jsonify({"eredmeny": True})

#Kurzusok kezelése:
@app.route("/kurzusok", methods=["GET"])
def osszes_kurzus():
    return jsonify(kurzusok)

@app.route("/kurzusok/<int:azonosito>", methods=["GET"])
def egy_kurzus(azonosito):
    k = kurzuskeres(azonosito)
    if k is None:
        abort(404, description="Nincs ilyen kurzus!")
    return jsonify(k)

@app.route("/kurzusok", methods=["POST"])
def uj_kurzus():
    if not request.json or not all(key in request.json for key in ("nev", "kredit")):
        abort(400, description="A név és kredit megadása kötelező.")
    uj_id = max([k["azonosito"] for k in kurzusok], default=0) + 1
    kurzus = {
        "azonosito": uj_id,
        "nev": request.json["nev"],
        "kredit": request.json["kredit"],
        "oktato": request.json.get("oktato", "")
    }
    kurzusok.append(kurzus)
    return jsonify(kurzus), 201

@app.route("/kurzusok/<int:azonosito>", methods=["PUT"])
def kurzusmodositas(azonosito):
    k = kurzuskeres(azonosito)
    if k is None:
        abort(404)
    if not request.json:
        abort(400)
    k["nev"] = request.json.get("nev", k["nev"])
    k["kredit"] = request.json.get("kredit", k["kredit"])
    k["oktato"] = request.json.get("oktato", k["oktato"])
    return jsonify(k)

@app.route("/kurzusok/<int:azonosito>", methods=["DELETE"])
def kurzustorles(azonosito):
    k = kurzuskeres(azonosito)
    if k is None:
        abort(404)
    global feliratkozasok
    feliratkozasok = [f for f in feliratkozasok if f["kurzus_id"] != azonosito]
    kurzusok.remove(k)
    return jsonify({"eredmeny": True})

#Hallgató jelentkezése kurzusra:
@app.route("/feliratkozas", methods=["POST"])
def feliratkozas():
    if not request.json or not all(key in request.json for key in ("hallgato_id", "kurzus_id")):
        abort(400, description="Hiányzó hallgató vagy kurzus ID.")
    hallgato_id = request.json["hallgato_id"]
    kurzus_id = request.json["kurzus_id"]
    if not hallgatokeres(hallgato_id):
        abort(404, description="Nincs ilyen hallgató.")
    if not kurzuskeres(kurzus_id):
        abort(404, description="Nincs ilyen kurzus.")
    if any(f for f in feliratkozasok if f["hallgato_id"] == hallgato_id and f["kurzus_id"] == kurzus_id):
        abort(400, description="Már fel van iratkozva.")
    feliratkozasok.append({"hallgato_id": hallgato_id, "kurzus_id": kurzus_id})
    return jsonify({"eredmeny": "Sikeres feliratkozás!"})

#Hallgató leiratkozása a kurzusról:
@app.route("/leiratkozas", methods=["POST"])
def leiratkozas():
    if not request.json or not all(key in request.json for key in ("hallgato_id", "kurzus_id")):
        abort(400, description="Hiányzó hallgató vagy kurzus ID.")
    hallgato_id = request.json["hallgato_id"]
    kurzus_id = request.json["kurzus_id"]
    index = next((i for i, f in enumerate(feliratkozasok) if f["hallgato_id"] == hallgato_id and f["kurzus_id"] == kurzus_id), None)
    if index is None:
        abort(404, description="Nincs ilyen feliratkozás.")
    feliratkozasok.pop(index)
    return jsonify({"eredmeny": "Sikeres leiratkozás!"})

@app.route("/kurzusok/<int:kurzus_id>/hallgatok", methods=["GET"])
def kurzus_hallgatoi(kurzus_id):
    if not kurzuskeres(kurzus_id):
        abort(404)
    hallgatok_lista = [hallgatokeres(f["hallgato_id"]) for f in feliratkozasok if f["kurzus_id"] == kurzus_id]
    return jsonify([h for h in hallgatok_lista if h])

@app.route("/hallgatok/<int:hallgato_id>/kurzusok", methods=["GET"])
def hallgato_kurzusai(hallgato_id):
    if not hallgatokeres(hallgato_id):
        abort(404)
    kurzusok_lista = [kurzuskeres(f["kurzus_id"]) for f in feliratkozasok if f["hallgato_id"] == hallgato_id]
    return jsonify([k for k in kurzusok_lista if k])

@app.route("/kurzusok/<int:kurzus_id>/letszam", methods=["GET"])
def kurzus_letszam(kurzus_id):
    if not kurzuskeres(kurzus_id):
        abort(404)
    letszam = sum(1 for f in feliratkozasok if f["kurzus_id"] == kurzus_id)
    return jsonify({"kurzus_id": kurzus_id, "letszam": letszam})

if __name__ == "__main__":
    app.run(debug=True)

'''
Parancssorba:

Kurzus létrehozás:
curl -X POST -H "Content-Type: application/json" -d "{\"nev\": \"Adatbázisok\", \"kredit\": 5, \"oktato\": \"Dr. Példa Béla\"}" http://localhost:5000/kurzusok
Hallgató létrehozás:
curl -X POST -H "Content-Type: application/json" -d "{\"nev\": \"Kiss József\", \"email\": \"j.kiss@uni.hu\", \"szak\": \"Informatika\"}" http://localhost:5000/hallgatok
Feliratkozás:
curl -X POST -H "Content-Type: application/json" -d "{\"hallgato_id\": 1, \"kurzus_id\": 1}" http://localhost:5000/feliratkozas
Lekérdezés példa1: Kik járnak az 1-es kurzusra?
curl http://localhost:5000/kurzusok/1/hallgatok
Lekérdezés példa2: Egy hallgató milyen kurzusokra jár?
curl http://localhost:5000/hallgatok/1/kurzusok
Lekérdezés példa3: Kurzus létszám.
curl http://localhost:5000/kurzusok/1/letszam

Minden hallgató lekérdezése:
http://localhost:5000/hallgatok

Minden kurzus lekérdezése:
http://localhost:5000/kurzusok
'''