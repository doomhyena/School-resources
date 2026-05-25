drop table if exists Diák;
drop table if exists Barát;
drop table if exists Kedvelés;

create table Diák(ID int, nev text, evfolyam int);
create table Barát(ID1 int, ID2 int);
create table Kedvelés(ID1 int, ID2 int);

insert into Diák values (1510, 'Jordan', 9);
insert into Diák values (1689, 'Gabriel', 9);
insert into Diák values (1381, 'Tiffany', 9);
insert into Diák values (1709, 'Cassandra', 9);
insert into Diák values (1101, 'Haley', 10);
insert into Diák values (1782, 'Andrew', 10);
insert into Diák values (1468, 'Kris', 10);
insert into Diák values (1641, 'Brittany', 10);
insert into Diák values (1247, 'Alexis', 11);
insert into Diák values (1316, 'Austin', 11);
insert into Diák values (1911, 'Gabriel', 11);
insert into Diák values (1501, 'Jessica', 11);
insert into Diák values (1304, 'Jordan', 12);
insert into Diák values (1025, 'John', 12);
insert into Diák values (1934, 'Kyle', 12);
insert into Diák values (1661, 'Logan', 12);

insert into Barát values (1510, 1381);
insert into Barát values (1510, 1689);
insert into Barát values (1689, 1709);
insert into Barát values (1381, 1247);
insert into Barát values (1709, 1247);
insert into Barát values (1689, 1782);
insert into Barát values (1782, 1468);
insert into Barát values (1782, 1316);
insert into Barát values (1782, 1304);
insert into Barát values (1468, 1101);
insert into Barát values (1468, 1641);
insert into Barát values (1101, 1641);
insert into Barát values (1247, 1911);
insert into Barát values (1247, 1501);
insert into Barát values (1911, 1501);
insert into Barát values (1501, 1934);
insert into Barát values (1316, 1934);
insert into Barát values (1934, 1304);
insert into Barát values (1304, 1661);
insert into Barát values (1661, 1025);
insert into Barát select ID2, ID1 from Barát;

insert into Kedvelés values(1689, 1709);
insert into Kedvelés values(1709, 1689);
insert into Kedvelés values(1782, 1709);
insert into Kedvelés values(1911, 1247);
insert into Kedvelés values(1247, 1468);
insert into Kedvelés values(1641, 1468);
insert into Kedvelés values(1316, 1304);
insert into Kedvelés values(1501, 1934);
insert into Kedvelés values(1934, 1501);
insert into Kedvelés values(1025, 1101);
-------------------------------------------
1. Minden esetben, mikor Diák1 kedveli Diák2-t, de 
közben Diák2 kedveli Diák3-mat, jelenjen meg mindhárom 
diák neve és évfolyama.

SELECT D1.nev, D1.evfolyam, D2.nev, D2.evfolyam, D3.nev, D3.evfolyam 
FROM Kedvelés K1 JOIN Kedvelés K2 ON K1.ID2 = K2.ID1 
JOIN Diák D1 ON K1.ID1 = D1.ID
JOIN Diák D2 ON K1.ID2 = D2.ID 
JOIN Diák D3 ON K2.ID2 = D3.ID 
WHERE D1.ID <> D3.ID;
	--Tehát itt ugyanazon táblákra hivatkozunk több példányban a szűrési logika miatt 
--------------------------------------------
2. Minden olyan diákot listázunk, akiknek a barátai mind más évfolyamra járnak.
	-- Név és évfolyam kell. 

SELECT D.nev, D.evfolyam FROM Diák D WHERE D.evfolyam NOT IN 
	(SELECT D1.evfolyam FROM Barát B JOIN Diák D1 ON B.ID2 = D1.ID 
     WHERE D.ID = B.ID1);
	--Itt tagadással szűrtünk, hiszen eltérő évfolyamokat keresünk. 
--------------------------------------------
3. Átlagban hány barátja van egy diáknak? 
	--Egy darab szám kell.
SELECT AVG(szam) FROM (SELECT COUNT(ID2) szam FROM Barát GROUP BY ID1);
--------------------------------------------
4. Hány olyan diák van, aki vagy barátja a Cassandra nevű diáknak, 
vagy pedig barátja az ő barátainak. Utóbbi esetbe maga Cassandra ne számítson be. 
SELECT (
  SELECT COUNT(B.ID2) FROM Barát B JOIN Diák D ON D.ID = B.ID1 
  WHERE D.nev = 'Cassandra'
  )
  +
  (SELECT COUNT(B2.ID2) FROM Barát B1 JOIN Barát B2 ON B1.ID2 = B2.ID1 
   AND B1.ID1 <> B2.ID2 JOIN Diák D ON B1.ID1 = D.ID 
   WHERE D.nev = 'Cassandra'
   );
--------------------------------------------
--5. Jelenjen meg a legtöbb baráttal rendelkező diák neve és évfolyama. 
SELECT D.nev, D.evfolyam FROM Diák D JOIN Barát B ON D.ID = B.ID1 
GROUP BY B.ID1 HAVING COUNT(B.ID2) = (
  SELECT MAX(szam) FROM (SELECT COUNT(ID2) szam FROM Barát GROUP BY ID1));
--------------------------------------------
--6. Ha Diák1 és Diák2 barátok egymással, és Diák1 kedveli is Diák2-t, 
	--de ez fordítva nem igaz, akkor töröljük a kapcsolódó kedvelési adatot.
DELETE FROM Kedvelés WHERE EXISTS (
  SELECT * FROM Barát B WHERE Kedvelés.ID1 = B.ID1 AND Kedvelés.I2 = B.ID2)
  AND NOT EXISTS (
    SELECT * FROM Kedvelés KK WHERE KK.ID1 = Kedvelés.ID2 AND KK.ID2 = Kedvelés.ID1);
--------------------------------------------
--7. Minden olyan esetre, ahol Diák1 barátja Diák2-nek, Diák2 pedig barátja
	--Diák3-nak, ott adj hozzá egy új barátságot Diák1 és Diák3 közé.
    	-- Ne legyenek duplikátum barátságok, vagy önmagukkal való barátságok. 
INSERT INTO Barát 
SELECT DISTINCT B1.ID1, B2.ID2 
FROM Barát B1 JOIN Barát B2 
ON B1.ID2 = B2.ID1 AND B1.ID1 <> B2.ID2 
EXCEPT SELECT * FROM Barát;

