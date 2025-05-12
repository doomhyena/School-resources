drop table if exists Film;
drop table if exists Ertekelo;
drop table if exists Ertekeles;

create table Film(fID int, cim text, evszam int, rendezo text);
create table Ertekelo(ertID int, nev text);
create table Ertekeles(ertID int, fID int, csillag int, ErtekelesDatum date);

insert into Film values(101, 'Gone with the Wind', 1939, 'Victor Fleming');
insert into Film values(102, 'Star Wars', 1977, 'George Lucas');
insert into Film values(103, 'The Sound of Music', 1965, 'Robert Wise');
insert into Film values(104, 'E.T.', 1982, 'Steven Spielberg');
insert into Film values(105, 'Titanic', 1997, 'James Cameron');
insert into Film values(106, 'Snow White', 1937, null);
insert into Film values(107, 'Avatar', 2009, 'James Cameron');
insert into Film values(108, 'Raiders of the Lost Ark', 1981, 'Steven Spielberg');

insert into Ertekelo values(201, 'Sarah Martinez');
insert into Ertekelo values(202, 'Daniel Lewis');
insert into Ertekelo values(203, 'Brittany Harris');
insert into Ertekelo values(204, 'Mike Anderson');
insert into Ertekelo values(205, 'Chris Jackson');
insert into Ertekelo values(206, 'Elizabeth Thomas');
insert into Ertekelo values(207, 'James Cameron');
insert into Ertekelo values(208, 'Ashley White');

insert into Ertekeles values(201, 101, 2, '2011-01-22');
insert into Ertekeles values(201, 101, 4, '2011-01-27');
insert into Ertekeles values(202, 106, 4, null);
insert into Ertekeles values(203, 103, 2, '2011-01-20');
insert into Ertekeles values(203, 108, 4, '2011-01-12');
insert into Ertekeles values(203, 108, 2, '2011-01-30');
insert into Ertekeles values(204, 101, 3, '2011-01-09');
insert into Ertekeles values(205, 103, 3, '2011-01-27');
insert into Ertekeles values(205, 104, 2, '2011-01-22');
insert into Ertekeles values(205, 108, 4, null);
insert into Ertekeles values(206, 107, 3, '2011-01-15');
insert into Ertekeles values(206, 106, 5, '2011-01-19');
insert into Ertekeles values(207, 107, 5, '2011-01-20');
insert into Ertekeles values(208, 104, 3, '2011-01-02');

--SQL forrás 03 26
---------------------------------------------
SELECT * FROM Film;
SELECT * FROM Ertekeles;
SELECT * FROM Ertekelo;
---------------------------------------------
1. Az átlagban legmagasabb értékelésű filmek érdekelnek.
	- Listázzuk a címeket és átlagos értékelésüket.
SELECT f.cim, AVG(ertes.csillag)
FROM Film f 
JOIN Ertekeles ertes
ON f.fId = ertes.fID	--A 2 tábla összefüggésének jelölése (FilmID-k)
GROUP BY f.fID			--A filmek ID-je szerint csoportosítom 
HAVING AVG(ertes.csillag) = (	--Csak azokat szűrje, ahol az átlagos értékelés megfelel a lenti kritériumnak
  SELECT MAX(atlag)		--A max átlag érték kiválasztása 'átlag' néven (lentebb)
  FROM (
    SELECT AVG(csillag) atlag		--Egy még belsőbb al-select 
    FROM Ertekeles
    GROUP BY fid
    )
 );
----------------------------------------------
Feladat: 
2. A legrosszabb értékelésű film kiválasztása címmel és átlag csillagszámmal.
SELECT f.cim, AVG(ertes.csillag)
FROM Film f 
JOIN Ertekeles ertes
ON f.fID = ertes.fID
GROUP BY f.fID
HAVING AVG(ertes.csillag) = (
  SELECT MIN(atlag)
  FROM (
    SELECT AVG(csillag) atlag
    FROM Ertekeles
    GROUP BY fID
   	)
 );
--HAVING:
	-- A csoportosítás (GROUP BY) után szokott jön 
    -- Az értelmezésnél a találatoknak eleget kell tenniük a HAVING után megfogalmazott kritériumnak.
    -- "Csak azokat csoportosítsa, amelyek..." 
----------------------------------------------
Már meglévő tábla rekordok frissítése: UPDATE parancs. 
Pl.: UPDATE táblanév SET oszlopnév = új érték WHERE feltétel megfogalmazása. 
	--UPDATE = "Frissítsen" 
    --SET = "Állítsa be" 
3. Az átlagosan 4 vagy afeletti csillaggal rendelkező filmek megjelenési 
	éve növekedjen 25-tel. (kiegészítendő feladat).
UPDATE Film SET evszam = evszam + 25 
WHERE fID IN (
  SELECT fID 
  FROM Ertekeles 
  GROUP BY fID 
  HAVING AVG(csillag) >= 4 
  );
----------------------------------------------
4. A rendezők neve kell + az a filmcím, amire a legmagasabb 
értékelést kapták a sajátjaik közül + a csillag száma.  
Ahol nincs rendező megadva, azokat a filmeket ignoráljuk. 
SELECT f.rendezo, f.cim, MAX(ertes.csillag) --A legmagasabb csillag
FROM Film f JOIN Ertekeles ertes
ON f.fID = ertes.fID
WHERE rendezo IS NOT NULL --A nem NULL értékek miatt 
GROUP BY f.rendezo;
----------------------------------------------
Törlés a táblából: 
DELETE FROM táblanév WHERE feltétel, hogy hol/mi alapján töröljön;

5. Töröljük azokat az értékeléseket, ahol a film évszáma 1970 előtti 
vagy 2000 utáni, valamint az értékelés 4 csillagnál kevesebb.
	--Az ÉrtékErtekeles táblából törlünk, de a feltétel a Film táblához kapcsolódik. 
DELETE FROM Ertekeles WHERE fID IN (
  SELECT fID FROM Film WHERE evszam < 1970 OR evszam > 2000
  ) AND csillag < 4;
--VAGY--
DELETE FROM Ertekeles WHERE fID IN (
  SELECT fID FROM Film WHERE evszam NOT BETWEEN 1970 AND 2000
  ) AND csillag < 4;
-----------------------------------------------
