CREATE TABLE  Ugyfel (
	ugyfkod int NOT NULL PRIMARY KEY, 
	ugyfnev varchar(40) NOT NULL, 
	ugyvvaros varchar(35), 
	munkaterulet varchar(35) NOT NULL, 
	orszag varchar(20) NOT NULL, 
	kategoria NUMBER, 
	nyitoosszeg NUMBER(12,2) NOT NULL, 
	kapottosszeg NUMBER(12,2) NOT NULL, 
	fizetettosszeg NUMBER(12,2) NOT NULL, 
	extraosszeg NUMBER(12,2) NOT NULL, 
	telefon varchar(17) NOT NULL, 
	ugynokkod varchar(6) NOT NULL
);

INSERT INTO Ugyfel VALUES (13, 'Holmes', 'London', 'London', 'UK', '2', 6000000, 5000000, 7000000, 4000000, 'BBBBBBB', '03');
INSERT INTO Ugyfel VALUES (01, 'Micheal', 'New York', 'New York', 'USA', '2', 3000000, 5000000, 2000000, 6000000, 'CCCCCCC', '08');
INSERT INTO Ugyfel VALUES (20, 'Albert', 'New York', 'New York', 'USA', '3', 5000000, 7000000, 6000000, 6000000, 'BBBBSBB', '08');
INSERT INTO Ugyfel VALUES (25, 'Ravindran', 'Bangalore', 'Bangalore', 'India', '2', 5000000, 7000000, 4000000, 8000000, 'AVAVAVA', '11');
INSERT INTO Ugyfel VALUES (24, 'Cook', 'London', 'London', 'UK', '2', 4000000, 9000000, 7000000, 6000000, 'FSDDSDF', '06');
INSERT INTO Ugyfel VALUES (15, 'Stuart', 'London', 'London', 'UK', '1', 6000000, 8000000, 3000000, 11000000, 'GFSGERS', '03');
INSERT INTO Ugyfel VALUES (02, 'Bolt', 'New York', 'New York', 'USA', '3', 5000000, 7000000, 9000000, 3000000, 'DDNRDRH', '08');
INSERT INTO Ugyfel VALUES (18, 'Fleming', 'Brisban', 'Brisban', 'Australia', '2', 7000000, 7000000, 9000000, 5000000, 'NHBGVFC', '05');
INSERT INTO Ugyfel VALUES (21, 'Jacks', 'Brisban', 'Brisban', 'Australia', '1', 7000000, 7000000, 7000000, 7000000, 'WERTGDF', '05');
INSERT INTO Ugyfel VALUES (19, 'Yearannaidu', 'Chennai', 'Chennai', 'India', '1', 8000000, 7000000, 7000000, 8000000, 'ZZZZBFV', '10');
INSERT INTO Ugyfel VALUES (05, 'Sasikant', 'Mumbai', 'Mumbai', 'India', '1', 7000000, 11000000, 7000000, 11000000, '147-25896312', '02');
INSERT INTO Ugyfel VALUES (07, 'Ramanathan', 'Chennai', 'Chennai', 'India', '1', 7000000, 11000000, 9000000, 9000000, 'GHRDWSD', '10');
INSERT INTO Ugyfel VALUES (22, 'Avinash', 'Mumbai', 'Mumbai', 'India', '2', 7000000, 11000000, 9000000, 9000000, '113-12345678','02');
INSERT INTO Ugyfel VALUES (04, 'Winston', 'Brisban', 'Brisban', 'Australia', '1', 5000000, 8000000, 7000000, 6000000, 'AAAAAAA', '05');
INSERT INTO Ugyfel VALUES (23, 'Karl', 'London', 'London', 'UK', '0', 4000000, 6000000, 7000000, 3000000, 'AAAABAA', '06');
INSERT INTO Ugyfel VALUES (06, 'Shilton', 'Torento', 'Torento', 'Canada', '1', 10000000, 7000000, 6000000, 11000000, 'DDDDDDD', '04');
INSERT INTO Ugyfel VALUES (10, 'Charles', 'Hampshair', 'Hampshair', 'UK', '3', 6000000, 4000000, 5000000, 5000000, 'MMMMMMM', '09');
INSERT INTO Ugyfel VALUES (17, 'Srinivas', 'Bangalore', 'Bangalore', 'India', '2', 8000000, 4000000, 3000000, 9000000, 'AAAAAAB', '07');
INSERT INTO Ugyfel VALUES (12, 'Steven', 'San Jose', 'San Jose', 'USA', '1', 5000000, 7000000, 9000000, 3000000, 'KRFYGJK', '12');
INSERT INTO Ugyfel VALUES (08, 'Karolina', 'Torento', 'Torento', 'Canada', '1', 7000000, 7000000, 9000000, 5000000, 'HJKORED', '04');
INSERT INTO Ugyfel VALUES (03, 'Martin', 'Torento', 'Torento', 'Canada', '2', 8000000, 7000000, 7000000, 8000000, 'MJYURFD', '04');
INSERT INTO Ugyfel VALUES (09, 'Ramesh', 'Mumbai', 'Mumbai', 'India', '3', 8000000, 7000000, 3000000, 12000000, 'Phone No', '02');
INSERT INTO Ugyfel VALUES (14, 'Rangarappa', 'Bangalore', 'Bangalore', 'India', '2', 8000000, 11000000, 7000000, 12000000, 'AAAATGF', '01');
INSERT INTO Ugyfel VALUES (16, 'Venkatpati', 'Bangalore', 'Bangalore', 'India', '2', 8000000, 11000000, 7000000, 12000000, 'JRTVFDD', '07');
INSERT INTO Ugyfel VALUES (11, 'Sundariya', 'Chennai', 'Chennai', 'India', '3', 7000000, 11000000, 7000000, 11000000, 'PPHGRTS', '10');

1. Listázz minden rekordot a '21' és '22' kódú, valamint a Londoni tartózkodási helyű ügyfeleket leszámítva.

2. Hány emberünk van az Egyesült államokban?

3. Összesen mennyi pénzt vettek ki a nem Kanadai ügyfeflek?

4. Ki fizette be a legtöbb pénzt?

5. Ki vette ki a legtöbb pénzt a 10-nél nagyobb ID-jű ügyfelek közül?

6. Hány olyan név van, amelyben 'o' a második betű?

7. Listázd ki a 4 betűs nevű emberek országait.

8. Kik azok az angolok, akik eddig több, mint 1 milliót raktak be?

9. Összesen hány ügyfelünk van itt nyilvántartva?

10. Törlődjenek azok az ügyfelek, akiket a 10-es menedzser kezel, vagy 1 milliónál többet vettek ki.

--SELECT * FROM Ugyfel WHERE ugyfkod IN (21,22) AND munkaterulet != 'London';
--SELECT COUNT(*) FROM Ugyfel WHERE orszag = 'USA';
--SELECT SUM(kapottosszeg) FROM Ugyfel WHERE orszag != 'Canada';
--SELECT ugyfnev FROM Ugyfel ORDER by fizetettosszeg DESC LIMIT 1;
--SELECT ugyfnev FROM Ugyfel WHERE ugyfkod > 10 ORDER BY kapottosszeg DESC LIMIT 1;
--SELECT COUNT(ugyfnev) FROM Ugyfel WHERE ugyfnev LIKE '_o%';
--SELECT DISTINCT orszag FROM Ugyfel WHERE ugyfnev LIKE '____';
--SELECT ugyfnev FROM Ugyfel WHERE orszag = 'UK' and fizetettosszeg > 1000000;
--SELECT COUNT(*) FROM Ugyfel;
--DELETE FROM Ugyfel WHERE ugynokkod = 10 OR kapottosszeg > 1000000;
