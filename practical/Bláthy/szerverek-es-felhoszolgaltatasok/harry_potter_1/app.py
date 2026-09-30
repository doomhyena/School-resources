"""Small read-only Flask site backed by the exam's PostgreSQL database."""

import os

import psycopg
from psycopg.rows import dict_row
from flask import Flask, abort, jsonify, render_template


app = Flask(__name__)


def query(sql, params=()):
    """Use one short-lived TLS connection for each page request."""
    config = {
        "host": os.environ["DB_HOST"],
        "port": int(os.environ.get("DB_PORT", "5432")),
        "dbname": os.environ.get("DB_NAME", "harry_potter"),
        "user": os.environ["DB_USER"],
        "password": os.environ["DB_PASSWORD"],
        "sslmode": os.environ.get("DB_SSLMODE", "require"),
        "connect_timeout": 5,
        "row_factory": dict_row,
    }
    with psycopg.connect(**config) as connection:
        with connection.cursor() as cursor:
            cursor.execute(sql, params)
            return cursor.fetchall()


@app.get("/")
def home():
    return render_template("home.html", title="Főoldal")


@app.get("/books")
def books():
    rows = query("SELECT id, title, publication_date, pages, img_url FROM books ORDER BY id")
    return render_template("books.html", title="Könyvek", books=rows)


@app.get("/films")
def films():
    rows = query("SELECT id, title, premier, img_url FROM films ORDER BY id")
    return render_template("films.html", title="Filmek", films=rows)


@app.get("/films/<int:film_id>")
def film_detail(film_id):
    rows = query(
        "SELECT id, title, premier, director, income, img_url FROM films WHERE id = %s",
        (film_id,),
    )
    if not rows:
        abort(404)
    actors = query(
        "SELECT a.name, a.film_character FROM actors AS a "
        "JOIN film_cast AS fc ON fc.actor_id = a.id "
        "WHERE fc.film_id = %s ORDER BY a.id",
        (film_id,),
    )
    return render_template("film_detail.html", title=rows[0]["title"], film=rows[0], actors=actors)


@app.get("/houses")
def houses():
    return render_template("houses.html", title="Házak")


@app.get("/health")
def health():
    try:
        counts = query("SELECT (SELECT count(*) FROM books) AS books, (SELECT count(*) FROM films) AS films")
        return jsonify(status="ok", books=counts[0]["books"], films=counts[0]["films"])
    except (psycopg.Error, KeyError, ValueError):
        app.logger.exception("Database health check failed")
        return jsonify(status="error"), 503
