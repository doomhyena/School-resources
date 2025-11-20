SELECT DISTINCT kozterulet
FROM ingatlan
ORDER BY kozterulet ASC;

SELECT i.hazszam, h.ar
FROM ingatlan i
JOIN hirdetes h ON i.id = h.ingatlanid
WHERE i.kozterulet = 'Agyagos utca';

SELECT SUM(e.ar * 0.015) AS bevetel
FROM eladas e
WHERE YEAR(e.datum) = 2021;

SELECT MAX(ar) / MIN(ar) AS arany
FROM hirdetes;

SELECT i.kozterulet, i.hazszam, e.ar
FROM ingatlan i
JOIN hirdetes h ON i.id = h.ingatlanid
JOIN eladas e ON i.id = e.ingatlan_id
WHERE h.ar = e.ar;
