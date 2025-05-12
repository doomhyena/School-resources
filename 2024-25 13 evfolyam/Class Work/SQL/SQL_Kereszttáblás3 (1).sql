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
-------------------------------------------------------------------------------
--1. Kik értékelték a 'Gone with the Wind' filmet? 
SELECT DISTINCT erto.nev FROM Ertekelo erto JOIN Ertekeles ertes 
ON erto.ertID = ertes.ertID JOIN Film f ON f.fID = ertes.fID 
WHERE f.cim = 'Gone with the Wind';
---------------------------------------------------------
--2. Minden értékelésnél, ahol az értékelő és a rendező személye egyezik, 
jelenjen meg az értékelő neve, a film címe és a csillagok száma.
SELECT erto.nev, f.cim, ertes.csillag 
FROM Ertekeles ertes JOIN Ertekelo erto ON erto.ertID = ertes.ertID 
JOIN Film f ON f.fID = ertes.fID WHERE f.rendezo = erto.nev;
---------------------------------------------------------
--3. Ertékelők nevei, filmcímek és a csillagok (legalacsonyabb) száma. 
SELECT erto.nev, f.cim, ertes.csillag 
FROM Ertekeles ertes JOIN Ertekelo erto ON ertes.ertID = erto.ertID 
JOIN Film f ON f.fID = ertes.fID 
WHERE ertes.csillag = (SELECT MIN(csillag) FROM Ertekeles);*/
----------------------------------------------------------
--4. Filmcímek és a rájuk adott átlagos csillagszámok. 
SELECT f.cim, AVG(ertes.csillag) FROM Film f JOIN 
Ertekeles ertes ON ertes.fID = f.fID
GROUP BY f.fID ORDER BY f.cim;
--------------------------------------------------------- 
--5. Azon értékelők nevei, akik legalább 3 értékelést végeztek. 
SELECT erto.nev FROM Ertekelo erto
WHERE 3 <= (
  SELECT COUNT(ertes.ertID) FROM Ertekeles ertes 
  WHERE ertes.ertID = erto.ertID);
---------------------------------------------------------
--6. Mely rendezőkhöz köthető több film? (rendezés: rendező neve, film címe alapján)
SELECT cim, rendezo FROM Film 
WHERE rendezo IN (
  SELECT rendezo FROM Film GROUP BY rendezo HAVING COUNT(rendezo) > 1)
ORDER BY rendezo, cim;
