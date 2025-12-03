CREATE TABLE Felhasznalok (
    FelhID INT PRIMARY KEY,
    FelhNev VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Nem VARCHAR(10),
    Szuletes DATE,
    Csatl DATETIME NOT NULL
    
);


Create Table Termekek(
    TermekID INT PRIMARY KEY,
    TermNev VARCHAR(100) NOT NULL,
    Ar DECIMAL(10, 2) NOT NULL)
   
   
CREATE TABLE Rendelesek (
    RendID INT PRIMARY KEY,
    FelhID INT,
    TermekID INT,
    RendDatum DATETIME NOT NULL,
    SzallDatum DATE,
    Varos VARCHAR(50),
    Orszag VARCHAR(50),
    Mennyiseg INT NOT NULL,
    TeljesOsszeg DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (FelhID) REFERENCES Felhasznalok(FelhID),
    FOREIGN KEY (TermekID) REFERENCES Termekek(TermekID))
    

Insert into Felhasznalok (FelhID, FelhNev, Email, Nem, Szuletes, Csatl)
VALUES
  (1, 'Alice Johnson', 'alice.johnson@email.com', 'No', '1990-05-15', '2021-01-01 10:30:00'),
  (2, 'Bob Williams', 'bob.williams@email.com', 'Ferfi', '1985-08-22', '2021-02-02 11:45:00'),
  (3, 'Charlie Davis', 'charlie.davis@email.com', 'Ferfi', '1992-03-10', '2021-03-15 14:20:00'),
  (4, 'Diana Rodriguez', 'diana.rodriguez@email.com', 'No', '1988-11-28', '2021-04-16 16:45:00'),
  (5, 'Eva Martin', 'eva.martin@email.com', 'No', '1994-07-02', '2021-05-20 09:15:00'),
  (6, 'Frank Smith', 'frank.smith@email.com', 'Ferfi', '1987-12-11', '2021-06-25 12:30:00'),
  (7, 'Grace Lee', 'grace.lee@email.com', 'No', '1991-09-08', '2021-07-10 14:45:00'),
  (8, 'Henry Brown', 'henry.brown@email.com', 'Ferfi', '1986-02-14', '2021-08-15 16:00:00'),
  (9, 'Ivy Taylor', 'ivy.taylor@email.com', 'No', '1993-04-30', '2021-09-20 18:15:00'),
  (10, 'Jack Moore', 'jack.moore@email.com', 'Ferfi', '1989-10-05', '2021-10-25 20:30:00'),
  (11, 'Katherine White', 'katherine.white@email.com', 'No', '1996-01-18', '2021-11-30 22:45:00'),
  (12, 'Leo Davis', 'leo.davis@email.com', 'Ferfi', '1984-06-22', '2022-01-05 09:00:00'),
  (13, 'Mia Johnson', 'mia.johnson@email.com', 'No', '1997-08-17', '2022-02-10 11:15:00'),
  (14, 'Nathan Brown', 'nathan.brown@email.com', 'Ferfi', '1983-03-26', '2022-03-15 13:30:00'),
  (15, 'Olivia Garcia', 'olivia.garcia@email.com', 'No', '1998-05-12', '2022-04-20 15:45:00'),
  (16, 'Paul Martin', 'paul.martin@email.com', 'Ferfi', '1982-09-27', '2022-05-25 18:00:00'),
  (17, 'Quinn Miller', 'quinn.miller@email.com', 'No', '1999-11-02', '2022-06-30 20:15:00'),
  (18, 'Ryan Taylor', 'ryan.taylor@email.com', 'Ferfi', '1981-04-07', '2022-08-05 22:30:00'),
  (19, 'Samantha Wilson', 'samantha.wilson@email.com', 'No', '2000-06-12', '2022-09-10 00:45:00'),
  (20, 'Tyler Harris', 'tyler.harris@email.com', 'Ferfi', '1980-12-17', '2022-10-15 03:00:00'),
  (21, 'Uma Smith', 'uma.smith@email.com', 'No', '2001-02-22', '2022-11-20 05:15:00'),
  (22, 'Victor Miller', 'victor.miller@email.com', 'Ferfi', '1979-07-29', '2022-12-25 07:30:00'),
  (23, 'Wendy Martinez', 'wendy.martinez@email.com', 'No', '2002-09-03', '2023-01-30 09:45:00'),
  (24, 'Xander Johnson', 'xander.johnson@email.com', 'Ferfi', '1978-01-08', '2023-03-06 12:00:00'),
  (25, 'Yasmine Lee', 'yasmine.lee@email.com', 'No', '2003-03-15', '2023-04-10 14:15:00'),
  (26, 'Zachary Davis', 'zachary.davis@email.com', 'Ferfi', '1977-05-20', '2023-05-15 16:30:00'),
  (27, 'Abby Wilson', 'abby.wilson@email.com', 'No', '2004-07-25', '2023-06-20 18:45:00'),
  (28, 'Brian Moore', 'brian.moore@email.com', 'Ferfi', '1976-10-30', '2023-07-25 21:00:00'),
  (29, 'Catherine Taylor', 'catherine.taylor@email.com', 'No', '2005-12-05', '2023-08-30 23:15:00'),
  (30, 'David Brown', 'david.brown@email.com', 'Ferfi', '1975-02-09', '2023-10-05 01:30:00');

INSERT INTO Termekek (TermekID, TermNev, Ar)
VALUES
  (1, 'Laptop', 999.99),
  (2, 'Okostelefon', 599.99),
  (3, 'Tablet', 299.99),
  (4, 'Fejhallgato', 89.99),
  (5, 'Okosora', 129.99),
  (6, 'Digitalis Kamera', 449.99),
  (7, 'Fitness Koveto', 79.99),
  (8, 'Jatekkonzol', 299.99),
  (9, '4K TV', 799.99),
  (10, 'VezNelkuli Fulhallato', 69.99),
  (11, 'Bluetooth Speaker', 49.99),
  (12, 'Otthoni Kamera', 129.99),
  (13, 'Kulso Merevlemez', 119.99),
  (14, 'Kavefozo', 49.99),
  (15, 'Porszivo', 199.99),
  (16, 'Paratlanito', 149.99),
  (17, 'VezNelkuli Eger', 29.99),
  (18, 'Szek', 149.99),
  (19, 'Elektromos Fogkefe', 39.99),
  (20, 'Daralo', 69.99),
  (21, 'Tolto', 19.99),
  (22, 'Hatizsak', 79.99),
  (23, 'VezNelkuli Billentyuzet', 39.99),
  (24, 'LED Lampa', 29.99),
  (25, 'Ugrokotel', 14.99),
  (26, 'Yoga Matrac', 19.99),
  (27, 'Dumbbell', 49.99),
  (28, 'Bukosisak', 34.99),
  (29, 'Sportcipo', 79.99),
  (30, 'Halozsak', 49.99);

INSERT INTO Rendelesek (RendID, FelhID, TermekID, RendDatum, SzallDatum, Varos, Orszag, Mennyiseg, TeljesOsszeg)
VALUES
  (1, 1, 3, '2023-01-10 12:30:00', '2023-01-15', 'Zurich', 'Svajc', 2, 599.98),
  (2, 2, 8, '2023-02-15 14:45:00', '2023-02-20', 'Geneva', 'Svajc', 1, 299.99),
  (3, 3, 12, '2023-03-20 17:00:00', '2023-03-25', 'Bern', 'Svajc', 3, 389.97),
  (4, 4, 5, '2023-04-25 19:15:00', '2023-04-30', 'Lucerne', 'Svajc', 1, 129.99),
  (5, 5, 20, '2023-05-30 21:30:00', '2023-06-04', 'Zurich', 'Svajc', 2, 139.98),
  (6, 6, 16, '2023-07-05 23:45:00', '2023-07-10', 'Geneva', 'Svajc', 1, 149.99),
  (7, 7, 1, '2023-08-10 02:00:00', '2023-08-15', 'Bern', 'Svajc', 2, 1999.98),
  (8, 8, 9, '2023-09-15 04:15:00', '2023-09-20', 'Lucerne', 'Svajc', 1, 799.99),
  (9, 9, 14, '2023-10-20 06:30:00', '2023-10-25', 'Zurich', 'Svajc', 3, 149.97),
  (10, 10, 28, '2023-11-25 08:45:00', '2023-11-30', 'Geneva', 'Svajc', 1, 21.00),
  (11, 11, 19, '2023-12-01 11:00:00', '2023-12-06', 'Bern', 'Svajc', 2, 79.98),
  (12, 12, 27, '2023-12-01 13:15:00', '2023-12-06', 'Lucerne', 'Svajc', 1, 49.99),
  (13, 13, 4, '2023-12-01 15:30:00', '2023-12-06', 'Zurich', 'Svajc', 2, 179.98),
  (14, 14, 10, '2023-12-01 17:45:00', '2023-12-06', 'Geneva', 'Svajc', 1, 69.99),
  (15, 15, 26, '2023-12-01 20:00:00', '2023-12-06', 'Bern', 'Svajc', 3, 59.97),
  (16, 16, 7, '2023-12-01 22:15:00', '2023-12-06', 'Lucerne', 'Svajc', 1, 79.99),
  (17, 17, 15, '2023-12-01 00:30:00', '2023-12-06', 'Zurich', 'Svajc', 2, 129.98),
  (18, 18, 21, '2023-12-01 02:45:00', '2023-12-06', 'Geneva', 'Svajc', 1, 19.99),
  (19, 19, 22, '2023-12-01 05:00:00', '2023-12-06', 'Bern', 'Svajc', 2, 159.98),
  (20, 6, 22, '2023-12-01 05:00:00', '2023-12-06', 'Bern', 'Svajc', 2, 159.98),
  (21, 8, 22, '2023-12-21 05:00:00', '2023-12-26', 'Bern', 'Svajc', 2, 159.98),
  (22, 17, 15, '2023-12-01 00:30:00', '2023-12-06', 'Zurich', 'Svajc', 2, 19.98),
  (23, 2, 19, '2023-11-01 00:30:00', '2023-11-03', 'Zurich', 'Svajc', 1, 79.98)
  
--1. TeljesOsszeg oszlop törlése a Rendelesek táblából.
ALTER TABLE Rendelesek DROP COLUMN teljesosszeg;
---------------------------------------------------
--2. Mely felhasználók rendeltek és hányszor (rendelésszám szerint csökkenve)? 
SELECT Felhasznalok.FelhNev, Felhasznalok.Email, COUNT(Rendelesek.RendID) AS 
OsszesRendeles FROM Felhasznalok JOIN Rendelesek ON Felhasznalok.FelhID = Rendelesek.FelhID
GROUP BY Felhasznalok.FelhID ORDER BY OsszesRendeles DESC;
---------------------------------------------------
--3. Mi volt az 5 legkelendőbb termék és hányat adtak el belőlük? 
SELECT Termekek.TermNev AS Nev, Rendelesek.Mennyiseg,
(Rendelesek.Mennyiseg*Termekek.Ar) AS OsszEladas FROM Termekek
INNER JOIN Rendelesek ON Rendelesek.TermekID = Termekek.TermekID
ORDER BY Rendelesek.Mennyiseg DESC LIMIT 5;
---------------------------------------------------
SQL féle If-ELSE megoldás: CASE-WHEN 
	CASE WHEN Feltétel THEN Érték 
    WHEN MásikFeltétel THEN MásikÉrték 
    WHEN ... 
    END AS Értékek 
--4. Soroljuk be a termékeket 3 árkategóriába:
SELECT 
CASE WHEN Ar <= 150 THEN 'Olcso'	--Ezeknél ne "" hanem '' legyen
WHEN Ar <= 250 THEN 'Kozepes' 		--Lefedi az 1. feltételt, de nem probléma
WHEN Ar >= 251 THEN 'Draga' 
END AS STR_Ar, COUNT(Termekek.Ar) AS TermekSzam
FROM Termekek GROUP BY STR_Ar ORDER BY TermekSzam DESC;
---------------------------------------------------
5. Eladások száma városonként. 
		- Városnév, eladások száma
        - Csökkenő sorrendben
SELECT Rendelesek.Varos, COUNT(Rendelesek.Mennyiseg) AS OsszRendeles,
SUM(Rendelesek.Mennyiseg) AS Eladottak, SUM(Termekek.Ar*Rendelesek.Mennyiseg)
AS OsszFizetett FROM Rendelesek INNER JOIN Termekek ON Termekek.TermekID = Rendelesek.TermekID
GROUP BY Rendelesek.Varos ORDER BY OsszFizetett DESC;
---------------------------------------------------
--6. A 2-es ID-jű felhasználó mit rendelt, mikor, hányat, mennyiért? 
SELECT Felhasznalok.FelhNev, Rendelesek.RendDatum, Termekek.TermNev, Rendelesek.Mennyiseg,
(Rendelesek.Mennyiseg*Termekek.Ar) AS TeljesOsszeg FROM Rendelesek INNER JOIN 
Termekek ON Termekek.TermekID = Rendelesek.TermekID INNER JOIN Felhasznalok
ON Felhasznalok.FelhID = Rendelesek.FelhID WHERE Rendelesek.FelhID = 2;
---------------------------------------------------
--7. Mi a 3 legnépszerűbb termék Svájcban?
		-- Rendezés az eladott mennyiségek alapján 
        -- A termék neve és az eladott mennyiség jelenjen meg
SELECT Termekek.TermNev, SUM(Rendelesek.Mennyiseg) AS Mennyiseg 
FROM Rendelesek INNER JOIN Termekek ON Rendelesek.TermekID = Termekek.TermekID
WHERE Rendelesek.Orszag = 'Svajc' GROUP BY Termekek.TermNev 
ORDER BY SUM(Rendelesek.Mennyiseg) DESC LIMIT 3;
