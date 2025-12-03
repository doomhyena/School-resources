CREATE TABLE Író (
    ido INT PRIMARY KEY AUTO_INCREMENT,
    nev VARCHAR(100) NOT NULL,
    szuletesi_datum DATE,
    orszag VARCHAR(50)
);

CREATE TABLE Könyv (
    kid INT PRIMARY KEY AUTO_INCREMENT,
    cim VARCHAR(150) NOT NULL,
    megjelenes_ev INT,
    mufaj VARCHAR(50),
    iro_id INT,
    FOREIGN KEY (iro_id) REFERENCES Író(ido)
);

INSERT INTO Író (nev, szuletesi_datum, orszag) VALUES
('Fekete Péter',      '1975-03-12', 'Magyarország'),
('Nagy Erzsébet',     '1968-07-29', 'Magyarország'),
('Smith John',        '1955-01-15', 'USA'),
('Martínez Ana',      '1982-11-05', 'Spanyolország'),
('Kovács István',     '1990-06-21', 'Magyarország'),
('Yamamoto Hiroshi',  '1978-09-09', 'Japán'),
('Doe Jane',          '1985-02-20', 'USA'),
('Garcia Maria',      '1970-12-30', 'Spanyolország'),
('Ivanov Alekszej',   '1962-05-17', 'Oroszország'),
('Dupont Claude',     '1988-10-10', 'Franciaország');

INSERT INTO Könyv (cim, megjelenes_ev, mufaj, iro_id) VALUES
('A sötét erdő titka',           2001, 'Krimi',           1),
('Tavaszi szellő',               2005, 'Romantikus',      2),
('The Lost Legacy',              1999, 'Fantasy',         3),
('Sueños de libertad',           2010, 'Történelmi',      4),
('Versek a szerelemről',          2015, 'Vers',            2),
('Budai panoráma',               2020, 'Utazás',         5),
('Digitális forradalom',         2018, 'Ismeretterjesztő',6),
('Az eltűnt aranyváros',         2003, 'Kaland',          3),
('Éjszakai dal',                 2012, 'Dráma',           7),
('La vida es un sueño',          2008, 'Dráma',           4),
('Magányos harcos',              2019, 'Akció',           6),
('Csillagok alatt',              2016, 'Sci-Fi',          1),
('Boldogság nyomában',            2013, 'Önsegítő',        8),
('Köd a Balaton felett',         2007, 'Krimi',           5),
('Gyermekkor kertjei',           1995, 'Memoár',          9),
('Lélektánc',                    2021, 'Pszichológia',    7),
('Mon Paris',                    2014, 'Romantikus',      10),
('A tenger mélyén',              2000, 'Tudomány',        6),
('Régi mesék földje',            2017, 'Fantasy',         3),
('Egy csésze kávé Párizsban',     2022, 'Utazás',         10);


-- 1. Írj lekérdezést, amely kilistázza az összes könyvet címmel, megjelenési évvel és a hozzá tartozó író nevével.
SELECT
    k.cim,
    k.megjelenes_ev,
    i.nev AS iro_nev
FROM
    Könyv k
    INNER JOIN Író i ON k.iro_id = i.ido
ORDER BY
    k.megjelenes_ev DESC;

-- 2. Listázd ki az írók nevét és azt, hogy hány könyvet írtak összesen. Azok az írók is jelenjenek meg, akiknek épp nincs könyvük.
SELECT
    i.nev AS iro_nev,
    COUNT(k.kid) AS konyv_darab
FROM
    Író i
    LEFT JOIN Könyv k ON i.ido = k.iro_id
GROUP BY
    i.ido, i.nev
ORDER BY
    konyv_darab DESC, i.nev;

-- 3. Mely könyvek tartoznak a Romantikus műfajhoz, és kik írták ezeket?
SELECT
    k.cim,
    k.mufaj,
    i.nev AS iro_nev,
    i.orszag
FROM
    Könyv k
    INNER JOIN Író i ON k.iro_id = i.ido
WHERE
    k.mufaj = 'Romantikus'
ORDER BY
    i.nev;

-- 4. Mutasd meg azon írókat és a tőlük származó könyvek darabszámát, akik legalább két könyvet publikáltak.
SELECT
    i.nev AS iro_nev,
    COUNT(k.kid) AS konyv_darab
FROM
    Író i
    INNER JOIN Könyv k ON i.ido = k.iro_id
GROUP BY
    i.ido, i.nev
HAVING
    COUNT(k.kid) >= 2
ORDER BY
    konyv_darab DESC;

-- 5. Keresd meg azt a könyvet, amelyik a legrégebben jelent meg, és azt, amelyik a legutóbb. 
SELECT
    k1.cim,
    k1.megjelenes_ev,
    i1.nev AS iro_nev
FROM
    Könyv k1
    INNER JOIN Író i1 ON k1.iro_id = i1.ido
WHERE
    k1.megjelenes_ev = (SELECT MIN(megjelenes_ev) FROM Könyv)

UNION

SELECT
    k2.cim,
    k2.megjelenes_ev,
    i2.nev AS iro_nev
FROM
    Könyv k2
    INNER JOIN Író i2 ON k2.iro_id = i2.ido
WHERE
    k2.megjelenes_ev = (SELECT MAX(megjelenes_ev) FROM Könyv);

-- 6. Listázd ki azon írók nevét és országát, akiknek még nincs könyvük a Könyv táblában!
SELECT
    i.nev,
    i.orszag
FROM
    Író i
    LEFT JOIN Könyv k ON i.ido = k.iro_id
WHERE
    k.kid IS NULL;

-- 7. Írd meg a lekérdezést, amely kilistázza azoknak a könyveknek a címét és író nevét, amelyeknek a címében benne van a „tenger” szó.
SELECT
    k.cim,
    i.nev AS iro_nev
FROM
    Könyv k
    INNER JOIN Író i ON k.iro_id = i.ido
WHERE
    LOWER(k.cim) LIKE '%tenger%';

-- 8. Hány író van országonként? (csak azok az országok jelenjenek meg, ahol legalább egy író van.
SELECT
    ors.orszag,
    COUNT(ors.ido) AS iro_darab
FROM
    Író ors
GROUP BY
    ors.orszag
ORDER BY
    iro_darab DESC;
----------------------------------------------------------------------
-- 9. Listázd ki azoknak az íróknak a nevét és azonosítóját, akik legalább három különböző műfajban jelentettek meg könyvet.
SELECT i.ido, i.nev
FROM Író i
    INNER JOIN Könyv k ON i.ido = k.iro_id
GROUP BY i.ido, i.nev
HAVING COUNT(DISTINCT k.mufaj) >= 3;

-- 10. Minden íróhoz írd ki a legutoljára megjelenő könyv címét.
SELECT i.nev AS iro_nev, k.cim AS legutolso_konyv
FROM Író i
    LEFT JOIN Könyv k ON k.kid = (
        SELECT k2.kid
        FROM Könyv k2
        WHERE k2.iro_id = i.ido
        ORDER BY k2.megjelenes_ev DESC, k2.kid DESC
        LIMIT 1
    );

-- 11. Add vissza azon könyvek címét és az író nevét párosítva, amelyek ugyanabban a megjelenés évben jelentek meg, de a két könyvet különböző író írta. (Minden párosítást csak egyszer jeleníts meg. Ne ismételd meg fordítva.)
SELECT k1.cim AS konyv1, i1.nev AS iro1, k2.cim AS konyv2, i2.nev AS iro2, k1.megjelenes_ev
FROM Könyv k1
    INNER JOIN Könyv k2 ON k1.megjelenes_ev = k2.megjelenes_ev AND k1.kid < k2.kid AND k1.iro_id <> k2.iro_id
    INNER JOIN Író i1 ON k1.iro_id = i1.ido
    INNER JOIN Író i2 ON k2.iro_id = i2.ido
ORDER BY
    k1.megjelenes_ev, k1.cim, k2.cim;

-- 12. Számold ki országonként, hogy egy író átlagosan hány könyvet publikált. Csak azokat az országokat jelenítsd meg, ahol legalább két író van.
SELECT i.orszag, ROUND(COUNT(k.kid) * 1.0 / COUNT(DISTINCT i.ido), 2) AS atlag_konyv_iro
FROM Író i
    LEFT JOIN Könyv k ON i.ido = k.iro_id
GROUP BY i.orszag
HAVING COUNT(DISTINCT i.ido) >= 2
ORDER BY atlag_konyv_iro DESC, i.orszag;
