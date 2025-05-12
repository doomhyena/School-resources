/*
CREATE TABLE alkalmazottak (
  alk_id int(11) PRIMARY KEY,
  veznev VARCHAR(20) DEFAULT NULL,
  kernev VARCHAR(25) NOT NULL,
  email VARCHAR(100) NOT NULL, --NOT NULL: nem lehet itt NULL érték
  telefon VARCHAR(20) DEFAULT NULL, --DEFAULT NULL: ha nem adunk meg mást, akkor NULL lesz
  felvetel DATE NOT NULL,
  allas_id INT(11) NOT NULL,
  fizu DECIMAL(8,2) NOT NULL, --DECIMAL(8,2): 8 jegyű tizedes érték, amiből 2 jegy a tört
  menedzser_id INT(11) DEFAULT NULL,
  reszleg_id INT(11) DEFAULT NULL
 );
 
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (100,'Steven','King','steven.king@email.com','515.123.4567','1987-06-17',4,24000.00,NULL,9);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (101,'Neena','Kochhar','neena.kochhar@email.com','515.123.4568','1989-09-21',5,17000.00,100,9);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (102,'Lex','De Haan','lex.de haan@email.com','515.123.4569','1993-01-13',5,17000.00,100,9);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (103,'Alexander','Hunold','alexander.hunold@email.com','590.423.4567','1990-01-03',9,9000.00,102,6);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (104,'Bruce','Ernst','bruce.ernst@email.com','590.423.4568','1991-05-21',9,6000.00,103,6);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (105,'David','Austin','david.austin@email.com','590.423.4569','1997-06-25',9,4800.00,103,6);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (106,'Valli','Pataballa','valli.pataballa@email.com','590.423.4560','1998-02-05',9,4800.00,103,6);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (107,'Diana','Lorentz','diana.lorentz@email.com','590.423.5567','1999-02-07',9,4200.00,103,6);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (108,'Nancy','Greenberg','nancy.greenberg@email.com','515.124.4569','1994-08-17',7,12000.00,101,10);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (109,'Daniel','Faviet','daniel.faviet@email.com','515.124.4169','1994-08-16',6,9000.00,108,10);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (110,'John','Chen','john.chen@email.com','515.124.4269','1997-09-28',6,8200.00,108,10);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (111,'Ismael','Sciarra','ismael.sciarra@email.com','515.124.4369','1997-09-30',6,7700.00,108,10);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (112,'Jose Manuel','Urman','jose manuel.urman@email.com','515.124.4469','1998-03-07',6,7800.00,108,10);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (113,'Luis','Popp','luis.popp@email.com','515.124.4567','1999-12-07',6,6900.00,108,10);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (114,'Den','Raphaely','den.raphaely@email.com','515.127.4561','1994-12-07',14,11000.00,100,3);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (115,'Alexander','Khoo','alexander.khoo@email.com','515.127.4562','1995-05-18',13,3100.00,114,3);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (116,'Shelli','Baida','shelli.baida@email.com','515.127.4563','1997-12-24',13,2900.00,114,3);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (117,'Sigal','Tobias','sigal.tobias@email.com','515.127.4564','1997-07-24',13,2800.00,114,3);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (118,'Guy','Himuro','guy.himuro@email.com','515.127.4565','1998-11-15',13,2600.00,114,3);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (119,'Karen','Colmenares','karen.colmenares@email.com','515.127.4566','1999-08-10',13,2500.00,114,3);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (120,'Matthew','Weiss','matthew.weiss@email.com','650.123.1234','1996-07-18',19,8000.00,100,5);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (121,'Adam','Fripp','adam.fripp@email.com','650.123.2234','1997-04-10',19,8200.00,100,5);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (122,'Payam','Kaufling','payam.kaufling@email.com','650.123.3234','1995-05-01',19,7900.00,100,5);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (123,'Shanta','Vollman','shanta.vollman@email.com','650.123.4234','1997-10-10',19,6500.00,100,5);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (126,'Irene','Mikkilineni','irene.mikkilineni@email.com','650.124.1224','1998-09-28',18,2700.00,120,5);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (145,'John','Russell','john.russell@email.com',NULL,'1996-10-01',15,14000.00,100,8);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (146,'Karen','Partners','karen.partners@email.com',NULL,'1997-01-05',15,13500.00,100,8);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (176,'Jonathon','Taylor','jonathon.taylor@email.com',NULL,'1998-03-24',16,8600.00,100,8);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (177,'Jack','Livingston','jack.livingston@email.com',NULL,'1998-04-23',16,8400.00,100,8);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (178,'Kimberely','Grant','kimberely.grant@email.com',NULL,'1999-05-24',16,7000.00,100,8);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (179,'Charles','Johnson','charles.johnson@email.com',NULL,'2000-01-04',16,6200.00,100,8);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (192,'Sarah','Bell','sarah.bell@email.com','650.501.1876','1996-02-04',17,4000.00,123,5);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (193,'Britney','Everett','britney.everett@email.com','650.501.2876','1997-03-03',17,3900.00,123,5);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (200,'Jennifer','Whalen','jennifer.whalen@email.com','515.123.4444','1987-09-17',3,4400.00,101,1);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (201,'Michael','Hartstein','michael.hartstein@email.com','515.123.5555','1996-02-17',10,13000.00,100,2);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (202,'Pat','Fay','pat.fay@email.com','603.123.6666','1997-08-17',11,6000.00,201,2);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (203,'Susan','Mavris','susan.mavris@email.com','515.123.7777','1994-06-07',8,6500.00,101,4);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (204,'Hermann','Baer','hermann.baer@email.com','515.123.8888','1994-06-07',12,10000.00,101,7);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (205,'Shelley','Higgins','shelley.higgins@email.com','515.123.8080','1994-06-07',2,12000.00,101,11);
INSERT INTO alkalmazottak(alk_id,veznev,kernev,email,telefon,felvetel,allas_id,fizu,menedzser_id,reszleg_id) VALUES (206,'William','Gietz','william.gietz@email.com','515.123.8181','1994-06-07',1,8300.00,205,11);
*/
--Tartalom ellenőrzése:
SELECT * FROM alkalmazottak;
-----------------------------------------------
1. Jelenjen meg mindenki teljes neve, eddigi fizetése "eddigi fiztetés" és a 
kétszeresére növelt fizetés "új fizetés" néven, fizetés szerint csökkenve megjelenve.
SELECT veznev, kernev, fizu AS EddigiFizetes, fizu*2 AS EddigiFizetes;
2. Azok teljes nevei jelenjenek meg, akik a céges átlagfizetés felett keresnek.
SELECt veznev, kernev FROM alkalmazottak WHERE fizu > (SELECT AVG(fizu) FROM alkalmazottak);
3. Azok jelenjenek meg, akikhez nincs hozzárendelt menedzser.
SELECT * FROM alkalmazottak WHERE menedzser_id IS NULL;
4. Csak az ezredforduló után felvett alkalmazottak jelenjenek meg.
SELECT * FROM alkalmazottak WHERe felvetel >= '2000-01-01';
5. Csak az 5., 7., és 9. részleg vezetéknevei jelenjenek meg, ID szerint rendezve.
SELECT veznev FROM alkalmazottak WHERE reszleg_id IN (5,7,9) ORDER BY alk_id;
6. Csak azon dolgozók rekordjai jelenjenek meg, akik neve S-el kezdődik 
	és h-ra végződik.
SELECT * FROM alkalmazottak WHERE veznev LIKE 'S%' AND veznev LIKE '%h';
7. Azon ID-k, akik 7000-ret vagy 8000-ret keresnek.
SELECT alk_id FROM alkalmazottak WHERE fizu = 7000 OR fizu = 8000;
8. Töröljük az összes olyan alkalmazottat, akik a 7-esnél magasabb azonosítójú 
	részlegben dolgoznak.
DELETE FROM alkalmazottak WHERE reszleg_id > 7;

