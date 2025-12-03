create table diakok
(
	diak_id integer,
	diak_neve varchar(20),
	diak_kora integer
);

insert into diakok values (1, 'Michael', 19);
insert into diakok values (2, 'Doug', 18);
insert into diakok values (3, 'Samantha', 21);
insert into diakok values (4, 'Pete', 20);
insert into diakok values (5, 'Ralph', 19);
insert into diakok values (6, 'Arnold', 22);
insert into diakok values (7, 'Michael', 19);
insert into diakok values (8, 'Jack', 19);
insert into diakok values (9, 'Rand', 17);
insert into diakok values (10, 'Sylvia', 20);

create table kurzusok
(
	kurzus_id varchar(5),
	kurzus_nev varchar(20),
	kredit integer
);

insert into kurzusok values ('CS110', 'Matematika', 4);
insert into kurzusok values ('CS180', 'Fizika', 4);
insert into kurzusok values ('CS107', 'Pszichologia', 3);
insert into kurzusok values ('CS210', 'Muveszetek', 3);
insert into kurzusok values ('CS220', 'Tortenelem', 3);

create table beiratkozasok
(
	diak_id integer,
	kurzus_id varchar(5)
);

insert into beiratkozasok values (1, 'CS110');
insert into beiratkozasok values (1, 'CS180');
insert into beiratkozasok values (1, 'CS210');
insert into beiratkozasok values (2, 'CS107');
insert into beiratkozasok values (2, 'CS220');
insert into beiratkozasok values (3, 'CS110');
insert into beiratkozasok values (3, 'CS180');
insert into beiratkozasok values (4, 'CS220');
insert into beiratkozasok values (5, 'CS110');
insert into beiratkozasok values (5, 'CS180');
insert into beiratkozasok values (5, 'CS210');
insert into beiratkozasok values (5, 'CS220');
insert into beiratkozasok values (6, 'CS110');
insert into beiratkozasok values (7, 'CS110');
insert into beiratkozasok values (7, 'CS210');


create table oktatok
(
	veznev varchar(20),
	reszleg varchar(12),
	fizetes integer,
	felvetel date
);

insert into oktatok values ('Chong', 'Science', 88000, '2006-04-18');
insert into oktatok values ('Brown', 'Math', 97000, '2002-08-22');
insert into oktatok values ('Jones', 'History', 67000, '2009-11-17');
insert into oktatok values ('Wilson', 'Astronomy', 110000, '2005-01-15');
insert into oktatok values ('Miller', 'Agriculture', 82000, '2008-05-08');
insert into oktatok values ('Williams', 'Law', 105000, '2001-06-05');

create table tanit
(
	veznev varchar(20),
	kurzus_id varchar(5)
);

insert into tanit values ('Chong', 'CS180');
insert into tanit values ('Brown', 'CS110');
insert into tanit values ('Brown', 'CS180');
insert into tanit values ('Jones', 'CS210');
insert into tanit values ('Jones', 'CS220');
insert into tanit values ('Wilson', 'CS110');
insert into tanit values ('Wilson', 'CS180');
insert into tanit values ('Williams', 'CS107');
------------------------------------------------------------------------------
--1. Listázd a Fizika vagy Történekem kurzust teljesítő diákok neveit. Ne használj JOIN-t.

SELECT diak_neve 
FROM diakok
WHERE diak_id IN (
	SELECT diak_id
	FROM beiratkozasok
	WHERE kurzus_id IN (
		SELECT kurzus_id
		FROM kurzusok
		WHERE kurzus_nev = 'Fizika' OR kurzus_nev = 'Történelems'
	)
);

--2. Ki a legidősebb diák? Ne használd a LIMIT és az ORDER BY parancsokat. 

SELECT diak_neve
FROM diakok
WHERE diak_kora = (
	SELECT MAX(diak_kora)
	FROM diakok
);

--3. Listázd a diákok neveit, az általuk látogatott kurzusoka és azok tanárait.

SELECT d.diak_neve, k.kurzus_nev, t.veznev
FROM diakok d, beiratkozasok b, kurzusok k, tanit t
WHERE d.diak_id = b.diak_id 
  AND b.kurzus_id = k.kurzus_id 
  AND k.kurzus_id = t.kurzus_id;


--4. Listázd azon diákok rekordjait, akik nem járnak a CS180 kurzusra.

SELECT *
FROM diakok 
WHERE diak_id NOT IN (
	SELECT diak_id
	FROM beiratkozasok
	WHERE kurzus_id = 'CS180'
);

--5. Listázd azon diákok rekordjait, akik CSAK a CS220-as kurzusra járnak.

SELECT * 
FROM diakok 
WHERE diak_id IN (
	SELECT diak_id
	FROM beiratkozasok
	GROUP BY diak_id
	HAVING COUNT(*) = 1 AND MAX(kurzus_id) = 'CS220'
);

--6. Listázd azon diákok rekordjait, akik pontosan 1 vagy 2 kurzusra járnak.

SELECT * 
FROM diakok 
WHERE diak_id IN (
	SELECT diak_id
	FROM beiratkozasok
	GROUP BY diak_id
	HAVING COUNT(*) = 1 OR COUNT(*) = 2
);

--7. Listázd azon diákok rekordjait, akik legfeljebb 2 másik diáknál idősebbek.

SELECT *
FROM diakok d1
WHERE (
	SELECT COUNT(*)
	FROM diakok d2
	WHERE d2.diak_kora > d1.diak_kora
) <= 2;
