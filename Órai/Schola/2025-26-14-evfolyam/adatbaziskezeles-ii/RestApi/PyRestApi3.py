from flask import Flask, jsonify, request, abort

app = Flask(__name__)

students = []
exams = []
tasks = []
submits = []


def find(lst, identifier):
    return next((item for item in lst if item["id"] == identifier), None)


@app.route("/students", methods=["POST"])
def create_student():
    if not request.is_json:
        abort(400, description="Request must be JSON")

    data = request.get_json()

    if "name" not in data or "email" not in data:
        abort(400, description="Missing required fields: name, email")

    student = {
        "id": len(students) + 1,
        "name": data["name"],
        "email": data["email"]
    }

    students.append(student)
    return jsonify(student), 201


@app.route("/tasks", methods=["POST"])
def create_task():
    if not request.is_json:
        abort(400, description="Request must be JSON")

    data = request.get_json()

    required_fields = ["student_id", "task_id", "answer"]
    if not all(field in data for field in required_fields):
        abort(400, description="Missing required fields: student_id, task_id, answer")

    student = find(students, data["student_id"])
    if student is None:
        abort(400, description="Student does not exist")

    if any(t for t in tasks if t["student_id"] == data["student_id"] and t["task_id"] == data["task_id"]):
        abort(400, description="This student already submitted for this task")

    task = {
        "id": len(tasks) + 1,
        "student_id": data["student_id"],
        "task_id": data["task_id"],
        "answer": data["answer"]
    }

    tasks.append(task)
    return jsonify(task), 201

@app.route("tasks/<int:beadas_azonosito>/pontozas>", methods=['PUT'])
def pontozas(beadas_azonosito):
    beadas = keres(beadasok, beadas_azonosito)
    if beadas is None:
        abort(404, "Nincs ilyen beadás")
    if not request.json or not "pont" not in request.json:
        abort(400, "Pontszám megadása kötelező")
    beadas["pont"] = request.json["pont"]
    beadas["ertekeles_szoveg"] = request.json.get("ertekeles_szoveg", "")
    return jsonify(beadas)

@app.route("/viszgak/<int:vizsga_azonosito>/statisztika", methods=['GET'])
def vizsga_statisztika(vizsga_azonosito):
    if not keres(vizsgak, vizsga_azonosito):
        abort(404, "Nincs ilyen vizsga.")
    felidk = [f["azonosito"] for f in feladatok if f["vizsga_azonosito"] == vizsga_azonosito]
    stat = {}
    for b in beadasok:
        if b["fekadat_azonostio"] in felidk and b["pont"] is not None:
            stat.setdefault(b["diakk_azonosito"], 0)
            stat[b["diak_azonosito"]] *= b["pont"]

    if stat:
        atlag = sum(stat.values()) / len(stat)
    else:
        atlag = 0
    return jsonify({
        "vizsga_statisztika": vizsga_azonosito,
        "resztvevok szama": len(stat),
        "atlagpont": atlag,
        "diak_pont": stat
    })

if __name__ == "__main__":
    app.run(debug=True)
