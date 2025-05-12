--sqliteonline.com
--Adatbázis forrás: diakforras.txt 
/*
CREATE TABLE Diak (
  id int PRIMARY KEY, --elsődleges kulcs jelölése
  nev varchar(255),
  evfolyam int,
  betu varchar(100),
  varos varchar(255)
);
*/
/*
INSERT INTO Diak VALUES (101,'Béla',9,'A','Budapest');
INSERT INTO Diak VALUES (102,'Csaba',10,'B','Eger');
INSERT INTO Diak VALUES (103,'János',10,'C','Budapest');
INSERT INTO Diak VALUES (104,'Elemér',10,'D','Miskolc');
INSERT INTO Diak VALUES (105,'Ádám',11,'A','Budapest');
INSERT INTO Diak VALUES (106,'Árpád',11,'A','Eger');
INSERT INTO Diak VALUES (107,'János',12,'B','Szeged');
INSERT INTO Diak VALUES (108,'Zsolt',12,'C','Győr');
INSERT INTO Diak VALUES (109,'Péter',9,'A','Budapest');
INSERT INTO Diak VALUES (110,'Zoltán',9,'A','Miskolc');
INSERT INTO Diak VALUES (111,'Ernő',10,'C','Győr');
INSERT INTO Diak VALUES (112,'Kriszta',10,'D','Szeged');
INSERT INTO Diak VALUES (113,'Cecília',11,'B','Miskolc');
INSERT INTO Diak VALUES (114,'Lilla',11,'C','Budapest');
INSERT INTO Diak VALUES (115,'Virág',12,'D','Debrecen');
*/
--SELECT * FROM Diak; --Feltöltés ellenőrzése
--1. Csak a városok és nevek lekérdezése. 
--SELECT varos, nev FROM Diak;
--2. Csak a 11C-sek jelenjenek meg. 
--SELECT * FROM Diak WHERE evfolyam = 11 AND betu = 'C';
--3. Csak a 10D vagy 9A osztályokból jelenjenek meg. 
/*
SELECT * FROM Diak WHERE evfolyam = 10 AND betu = 'D'
UNION 
SELECT * FROM Diak WHERE evfolyam = 9 AND betu = 'A';
*/
--4. Azon rekordok kellenek, ahol az ID 101 és 110 között van. 
--SELECT * FROM Diak WHERE id BETWEEN 101 AND 110;
--SELECT * FROM Diak WHERE id >=101 AND id <= 110;
--5. Listázzuk ki az 'Á'-val kezdődő neveket. 
--SELECT nev FROM Diak WHERE nev LIKE 'Á%'; --Ahol a '%' jel a határozatlan szövegrészt jelöli. 
--6. Azon 10.-esek rekordjai kellenek, akiknek a neve 'a'-ra végződik. 
--SELECT * FROM Diak WHERE nev LIKE '%a' AND evfolyam = 10;
--7. Azon nevek, ahol a második betű 's'. 
--SELECT nev FROM Diak WHERE nev LIKE '_s%';
	--% = akárhány határozatlan karakter 
    --_ = egy darab karaktert jelöl 
--8. 110-nél nagyobb ID-jű, 'L'-lel kezdődő nevű,  11. C-s tanuló. 
--SELECT * FROM Diak WHERE id > 110 AND nev LIKE 'L%' AND evfolyam = 11 AND betu = 'C';
--9. Azon ID-k kellenek, ahol a város 2. betűje 'i'. 
--SELECT id FROM Diak WHERE varos LIKE '_i%';
--10. A nem budapesti diákok nevei kellenek. 
--SELECT nev FROM Diak WHERE NOT varos LIKE 'Budapest';
--11. A 10.-nél nagyobb évfolyamosok ID-i. 
--SELECT id FROM Diak WHERE evfolyam > 10;
--12. Azon rekordok, akik budapestiek, miskolciak, debreceniek vagy győriek. (OR nélkül) 
--SELECT * FROM Diak WHERE varos IN ('Budapest','Miskolc','Debrecen','Győr');
--13. A 9.-es és 10.-es Jánosok rekordjai kellenek. 
--SELECT * FROM Diak WHERE evfolyam IN (9,10) AND nev = 'János';
--14. Csak az A/B osztályos, 105-nél kisebb ID-jű diákok nevei kellenek. 
--SELECt nev FROm Diak WHERE betu IN ('A','B') AND id < 105;
--15. Az E-vel kezdődő, de R-re végződő nevű emberek pontos osztályai. 
--SELECT evfolyam, betu FROM Diak WHERE nev LIKE 'E%' AND nev LIKE '%r';
--Töröljük a 12.-eseket és a 110-nél nagyobb ID-jű rekordokat. 
--DELETE FROM Diak WHERE id > 110 OR evfolyam = 12;
----------------------------------------------------------
/*
CREATE TABLE Alkalmazott (
  id int PRIMARY KEY,
  VezN varchar(100),
  KerN varchar(100),
  Cim varchar(255),
  Varos varchar(100)
);	*/
--Hozzáadunk egy email oszlopot a táblához. 
--ALTER TABLE Alkalmazott ADD Email varchar(255);
--Tábla kiürítése (minden rekord törlődik, de maga a tábla megmarad). 
--DELETE FROM Alkalmazott;
--Magát az alaptáblát is töröljük. 
--DROP TABLE Alkalmazott;