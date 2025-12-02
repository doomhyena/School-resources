from flask import Flask, jsonify, request, abort

app = Flask(__name__)

hallgatok = []
kurzosok = []
feliratkozasok = []

def hallgatokers(azonosito):
    return next((h for h in hallgatok if h['azonosito'] == azonosito), None)

def kurzuskers(azonosito):
    return next((k for k in kurzosok if k['azonosito'] == azonosito), None)

@app.route('/hallgatok', methods=['GET'])
def osszes_hallgato():
    return jsonify(hallgatok)

@app.route('/hallgatok/<int:azonosito>', methods=['GET'])
def egy_hallgato(azonosito):
    if h is None:
        abort(404, description="Hallgató nem található")
    return jsonify(h)

@app.route('/hallgatok', methods=['POST'])
def uj_hallgato():
    if not request.json or 'nev' not in request.json:
        abort(400, description="A név megadása kötelező")
    uj_id = max([h['azonosito'] for h in hallgatok], default=0) + 1
    hallgato = {
        'azonosito': uj_id,
        'nev': request.json['nev'],
        'email': request.json.get['email'],
        'szak': request.json.get['szak', '']
    }
    hallgatok.append(hallgato)
    return jsonify(hallgato), 201

@app.route('/hallgatok/<int:azonosito>', methods=['GET'])
def hallgatomodositas(azonosito):
    h = hallgatokers(azonosito)
    if h is None:
        abort(404, description="Hallgató nem található")
    if not request.json:
        abort(400, description="Érvénytelen kérés")
    h['nev'] = request.json.get('nev', h['nev'])
    h['email'] = request.json.get('email', h['email'])
    h['szak'] = request.json.get('szak', h['szak'])
    return jsonify(h)

@app.route('/hallgatok/<int:azonosito>', methods=['DELETE'])
def hallgatotorles(azonosito):
    h = hallgatokers(azonosito)
    if h is None:
        abort(404, description="Hallgató nem található")
    global feliratkozasok
    feliratkozasok = [f for f in feliratkozasok if f['hallgato_id'] != azonosito]
    hallgatok.remove(h)
    return jsonify({'eredmeny': True})