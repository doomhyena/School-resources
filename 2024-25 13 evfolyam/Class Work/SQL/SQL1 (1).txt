--sqliteonline.com VAGY programiz.com VAGY Access VAGY mycompiler.io
--Tábla, amely a Nobel-díjas emberekről szól:
/*
CREATE TABLE Nobel (
  ev int,	--oszlopnév változónév egyébParaméter
  tema varchar(255),
  nyertes varchar(255)
); --int = szám, varchar(méret) = szöveg

--Tábla feltöltése rekordokkal:
INSERT INTO Nobel VALUES (1950, 'Fizika', 'Hannes Alfven');
		-- A konkrét értékeket sorban kell írni.
        -- Szövegnél sima ' jel kell. A " nem lesz jó.
		-- Többi rekord a nobelforrás txt-ben (Adatbázisok mappa)
INSERT INTO Nobel VALUES(1950, 'Fizika','Louis Neel');
INSERT INTO Nobel VALUES(1950, 'Fizika','Albert Einstein');
INSERT INTO Nobel VALUES(1961, 'Gazdaság','John Kennedy');
INSERT INTO Nobel VALUES(1970, 'Kémia','Sir Luis Federico Leloir');
INSERT INTO Nobel VALUES(1970, 'Orvostudomány','Ulf von Euler');
INSERT INTO Nobel VALUES(1970, 'Orvostudomány','Bernard Katz');
INSERT INTO Nobel VALUES(1962, 'Irodalom','Sir Aleksandr Solzhenitsyn');
INSERT INTO Nobel VALUES(1970, 'Gazdaság','Paul Samuelson');
INSERT INTO Nobel VALUES(1971, 'Gazdaság','Jimmy Carter');
INSERT INTO Nobel VALUES(1970, 'Orvostudomány','Julius Axelrod');
INSERT INTO Nobel VALUES(1971, 'Fizika','Dennis Gabor');
INSERT INTO Nobel VALUES(1971, 'Kémia','Gerhard Herzberg');
INSERT INTO Nobel VALUES(1971, 'Béke','Willy Brandt');
INSERT INTO Nobel VALUES(1971, 'Irodalom','Pablo Neruda');
INSERT INTO Nobel VALUES(1971, 'Gazdaság','Simon Kuznets');
INSERT INTO Nobel VALUES(1978, 'Béke','Anwar al-Sadat');
INSERT INTO Nobel VALUES(1978, 'Béke','Menachem Begin');
INSERT INTO Nobel VALUES(1987, 'Kémia','Donald J. Cram');
INSERT INTO Nobel VALUES(1987, 'Kémia','Jean-Marie Lehn');
INSERT INTO Nobel VALUES(1987, 'Orvostudomány','Susumu Tonegawa');
INSERT INTO Nobel VALUES(1994, 'Gazdaság','Reinhard Selten');
INSERT INTO Nobel VALUES(1994, 'Béke','Yitzhak Rabin');
INSERT INTO Nobel VALUES(1987, 'Fizika','John Georg Bednorz');
INSERT INTO Nobel VALUES(1987, 'Irodalom','Sir Joseph Brodsky');
INSERT INTO Nobel VALUES(1987, 'Gazdaság','Robert Solow');
INSERT INTO Nobel VALUES(1994, 'Irodalom','Kenzaburo Oe');

SELECT * FROM Nobel; -- A teljes tartalom megnézése a Nobel táblában. 
*/
--1. Azon rekordok kellenek, amik 1950-hez kapcsolódna. 
--SELECT * FROM Nobel WHERE ev = 1950; --WHERE = "Ahol" és utána írjuk a szűrőfeltételt. 
--2. Ki nyert 1962-ben irodalmi nobeldíjat? 
--SELECT nyertes FROM Nobel WHERE ev = 1962 AND tema = 'Irodalom'; --egyszerre több feltétel 
--3. Albert Einstein mikor és miért kapot Nobel-díjat? 
--SELECT ev, tema FROM Nobel WHERE nyertes = 'Albert Einstein';
--4. 1970-től kezdve kik nyertek Béke-Nobel díjat? 
--SELECT nyertes FROM Nobel WHERE ev >= 1970 AND tema = 'Béke';
--5. Minden 1970 és 1979 közti Irodalmi Nobel díjas adata érdekel. 
--SELECT * FROM Nobel WHERE tema = 'Irodalom' AND ev >= 1970 AND ev <= 1979;
--6. Mit lehet tudni az elnökökről (John Kennedy és Jimmy Carter)?
--SELECT * FROM Nobel WHERE nyertes IN ('John Kennedy', 'Jimmy Carter');
	-- IN (értékek): lehetséges megoldáshalmaz megadása
--7. Listázzuk ki a John nevű emberek teljes nevét. 
--SELECT nyertes FROM Nobel WHERE nyertes LIKE 'John%';
	--Itt a % az határozatlan szövegrész, bármi lehet 
--8. Listázzuk ki az 1980-as Fizika, és az 1987-es Kémia díjasokat. 
/*
SELECT * FROM Nobel WHERE tema = 'Fizika' AND ev = 1980 
UNION 
SELECT * FROM Nobel WHERE tema = 'Kémia' AND ev = 1987;
	--Ez egyben jelenít meg 2 teljesen különálló lekérdezést. 
   */
--9. Minden érdekel, a NEM Fizikai vagy Kémiai témájú, de 1970-ből van. 
--SELECT * FROM Nobel WHERE ev = 1970 AND NOT tema IN ('Kémia','Fizika');
--10. Listázzuk ki egyben azokat a rekordokat, ahol 1960 előtt kaptak Fizikai 
--vagy 1990 után kaptak Irodalmi Nobel-díjat. 
/*
SELECT * FROM Nobel WHERE tema = 'Fizika' AND ev < 1960 
UNION 
SELECT * FROM Nobel WHERE tema = 'Irodalom' AND ev > 1990;
*/
--11. Mit lehet tudni Robert Solow-ról? 
--SELECT * FROM Nobel WHERE nyertes = 'Robert Solow';
--12. Listázzuk a nevet, évet és témát azoknál, akik nemesi származásúak 
--(tehát 'Sir'-rel kezdődik a neve).
--SELECT * FROM Nobel WHERE nyertes LIKE 'Sir%';


