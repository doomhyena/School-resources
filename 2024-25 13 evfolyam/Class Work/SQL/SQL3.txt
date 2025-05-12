CREATE TABLE ugynokok (
  ukod varchar(255) PRIMARY KEY,
  unev varchar(255),
  munkaterulet varchar(255),
  megbizas NUMBER(10,2), 2 tizedesre kerekített érték
  mobil varchar(255), szöveges lesz, mert kötőjel van benne
  orszag varchar(255)
);

INSERT INTO ugynokok VALUES ('A007', 'McKain', 'Washington', 15, '077-25814763', '');
INSERT INTO ugynokok VALUES ('A003', 'Alex ', 'London', 13, '075-12458969', '');
INSERT INTO ugynokok VALUES ('A008', 'Alford', 'New York', 12, '044-25874365', '');
INSERT INTO ugynokok VALUES ('A011', 'Ravi Kumar', 'Bangalore', 15, '077-45625874', '');
INSERT INTO ugynokok VALUES ('A010', 'Santakumar', 'Chennai', 14, '007-22388644', '');
INSERT INTO ugynokok VALUES ('B012', 'Lucida', 'San Jose', 12, '044-52981425', '');
INSERT INTO ugynokok VALUES ('A005', 'Anderson', 'Brisban', 13, '045-21447739', '');
INSERT INTO ugynokok VALUES ('A001', 'Subbarao', 'Washington', 14, '077-12346674', '');
INSERT INTO ugynokok VALUES ('C002', 'Mukesh', 'Mumbai', 11, '029-12358964', '');
INSERT INTO ugynokok VALUES ('A006', 'McDen', 'London', 15, '078-22255588', '');
INSERT INTO ugynokok VALUES ('A004', 'Ivan', 'Toronto', 15, '008-22544166', '');
INSERT INTO ugynokok VALUES ('A009', 'Benjamin', 'Hampshair', 11, '008-22536178', '');

SELECT * FROM ugynokok;
1. Listázzuk ki a nem A-val kezdődő kódú ügynököket. 
SELECT * FROM ugynokok WHERE NOT ukod LIKE 'A%';
	Százalékjel = határozatlan mennyiségű karakter lehet ott. 
2. Melyik városban dolgozik az az ügynök, akinek a neve 4 betű (amiből a 2. az 'v')?
SELECT munkaterulet FROM ugynokok WHERE unev LIKE '_v__';
	Alulvonás = egy darab határozatlan karaktert jelöl. 
3. Listázzuk ki az összes rekordot, de név szerint sorba rendezve. 
SELECT * FROM ugynokok ORDER BY unev;
	Találatok sorba rendezése: ORDER BY
    Alapraméretezetten szám szerint vagy abc szerint növekvőbe rendez. 
    Sorrend megforsítása: DESC a végére (ORDER BY oszlopnév DESC)
    Több oszlopot is megadhatunk (ORDER BY oszlop1, oszlop2, ...)
4. Azon ügynökök mobilszámai, akik 10-12 megbizással rendelkeznek.
SELECT mobil FROM ugynokok WHERE megbizas <= 12 AND megbizas >= 10;
SELECT mobil FROM ugynokok WHERE megbizas IN (10,11,12);
SELECT mobil FROM ugynokok WHERe megbizas BETWEEN 10 AND 12;
5. A 15 megbízással rendelkező londoni ügynök neve kell.
SELECT unev FROM ugynokok WHERE munkaterulet = 'London' AND megbizas = 15;
6. Összesen hány megbízással rendelkeznek az ügynökök? 
SELECT SUM(megbizas) FROM ugynokok;
	SUM(): összegzés. Ebben a példában összeadta minden rekord 'megbizas' oszlopának a számértékét. 
7. Hány megbízása van a londoni és torontoi ügynököknek együtt? 
SELECT SUM(megbizas) FROM ugynokok WHERE munkaterulet = 'London' OR munkaterulet = 'Toronto';
8. Mi a kódja és hol dolgozik az az ügynök, aki nevének utolsó előtti betűje 'e'?
SELECT ukod, munkaterulet FROM ugynokok WHERE unev LIKE '%e_';
9. Azon rekordok, ahol a megbízások száma nem 12 (NOT parancs használata nélkül).
SELECT * FROM ugynokok WHERE megbizas != 12;
SELECT * FROM ugynokok WHERE megbizas > 12 OR megbizas < 12;
10. Minden rekord kell az országok és mobilszámok nélkül. Név szerint visszafele rendezve.
SELECT ukod, unev, munkaterulet, megbizas FROM ugynokok ORDER BY unev DESC;
11. Ügynökkódok, város szerint növekvő, azon belül megbizasok száma szerint csökkenő sorban. 
		ASC: növekvő sor kényszerítése
SELECT ukod FROm ugynokok ORDER BY munkaterulet ASC, megbizas DESC;
12. Azon rekordok, ahol város az nem 'New valami' (pl New York, New Delhi, New Hempshire). 
SELECT * FROM ugynokok WHERE NOT munkaterulet LIKE 'New%';
