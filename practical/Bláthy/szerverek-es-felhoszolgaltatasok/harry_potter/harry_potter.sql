-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Máj 10. 13:30
-- Kiszolgáló verziója: 10.4.24-MariaDB
-- PHP verzió: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `harry_potter`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `actors`
--

CREATE TABLE `actors` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `film_character` varchar(100) COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `actors`
--

INSERT INTO `actors` (`id`, `name`, `film_character`) VALUES
(1, 'Daniel Radcliffe', 'Harry Potter'),
(2, 'Rupert Grint', 'Ron Weasley'),
(3, 'Emma Watson', 'Hermione Granger'),
(4, 'Robbie Coltrane', 'Rubeus Hagrid'),
(5, 'Richard Harris', 'Albus Dumbledore'),
(6, 'Maggie Smith', 'Minerva McGalagony'),
(7, 'Alan Rickman', 'Perselus Piton'),
(8, 'Ian Hart', 'Mógus professzor'),
(9, 'Geraldine Somerville', 'Mrs. Lily Potter'),
(10, 'Adrian Rawlins', 'Mr. James Potter'),
(11, 'Fiona Shaw', 'Petunia Dursley'),
(12, 'Richard Griffiths', 'Vernon Dursley'),
(13, 'Harry Melling', 'Dudley Dursley'),
(14, 'John Cleese', 'Félig Fej Nélküli Nick'),
(15, 'Simon Fisher-Becker', 'Pufók Fráter'),
(16, 'Terence Bayler', 'Véres Báró'),
(17, 'Nina Young', 'Szürke Hölgy'),
(18, 'Ray Fearon', 'Firenze'),
(19, 'Warwick Davies', 'Filius Flitwick'),
(20, 'Zoë Wanamaker', 'Madam Hooch'),
(21, 'David Bradley', 'Argus Frics'),
(22, 'Elizabeth Spriggs', 'A Kövér Dáma'),
(23, 'Tom Felton', 'Draco Malfoy'),
(24, 'Jamie Waylett', 'Vincent Crak'),
(25, 'Josh Heardman', 'Gregory Monstro'),
(26, 'Matthew Lewis', 'Neville Longbottom'),
(27, 'Devon Murray', 'Seamus Finnigan'),
(28, 'Alfie Enoch', 'Dean Thomas'),
(29, 'Chris Rankin', 'Percy Weasley'),
(30, 'James Phelps', 'Fred Weasley'),
(31, 'Oliver Phelps', 'George Weasley'),
(32, 'Sean Biggerstaff', 'Oliver Wood'),
(33, 'Luke Youngblood', 'Lee Jordan'),
(34, 'Julie Walters', 'Molly Weasley'),
(35, 'Bonnie Wright', 'Ginny Weasley'),
(36, 'Verne Troyer', 'Ampók'),
(37, 'John Hurt', 'Mr. Ollivander'),
(38, 'Kenneth Branagh', 'Gilderoy Lockhart'),
(39, 'Christian Coulson', 'Tom Denem'),
(40, 'Mark Williams', 'Arthur Weasley'),
(41, 'Miriam Margolyes', 'Pomona Bimba'),
(42, 'Shirley Henderson', 'Hisztis Myrtl'),
(43, 'Robert Hardy', 'Cornelius Caramel'),
(44, 'Toby Jones', 'Dobby, a házimanó'),
(45, 'Jason Isaacs', 'Lucius Malfoy'),
(46, 'Michael Gambon', 'Albus Dumbledore'),
(47, 'Emma Thompson', 'Sybill Trelawney'),
(48, 'David Thewlish', 'Remus Lupin'),
(49, 'Gary Oldman', 'Sirius Black'),
(50, 'Timothy Spall', 'Peter Pettigrew'),
(51, 'Pam Ferris', 'Marge Dursley'),
(52, 'Dawn French', 'A Kövér Dáma'),
(53, 'Brendan Gleeson', 'Alastor Mordon'),
(54, 'David Tennant', 'Ifjabb Barty Kupor'),
(55, 'Ralph Fiennes', 'Voldemort'),
(56, 'Predrag Bjelat', 'Igor Karkarov'),
(57, 'Frances de la Tour', 'Olympe Maxime'),
(58, 'Roger Lloyd-Pack', 'Idősebb Barty Kupor'),
(59, 'Miranda Richardson', 'Rita Vitrol'),
(60, 'Robert Pattinson', 'Cedric Diggory'),
(61, 'Clémence Poésy', 'Fleur Delacour'),
(62, 'Stanislav Ianevski', 'Viktor Krum'),
(63, 'Jeff Rawle', 'Amos Diggory'),
(64, 'Katie Leung', 'Cho Chang'),
(65, 'Evanna Lynch', 'Luna Lovegood'),
(66, 'Natalie Tena', 'Nymphadora Tonks'),
(67, 'George Harris', 'Kingsley Shacklebolt'),
(68, 'Helena Bonham Carter', 'Bellatrix Lestrange'),
(69, 'Jessica Hynes', 'Mafalda Hopkirk'),
(70, 'Sian Thomas', 'Amelia Bones'),
(71, 'Jim McManus', 'Aberforth Dumbledore'),
(72, 'Imelda Staunton', 'Dolores Umbridge'),
(73, 'Jim Broadbent', 'Horatius Lumpsluck'),
(74, 'Helen McCrory', 'Narcissa Malfoy'),
(75, 'Dave Legeno', 'Fenrir Greyback'),
(76, 'Scarlett Byrne', 'Pansy Parkinson'),
(77, 'Georgina Leonidas', 'Katie Bell'),
(78, 'Rhys Ifans', 'Xenophilius Lovegood'),
(79, 'Bill Nighy', 'Rufus Scrimgeour'),
(80, 'Domhnall Gleeson', 'Bill Weasley'),
(81, 'Andy Linden', 'Mundungus Fletcher'),
(82, 'Michael Byrne', 'Gellert Grindelwald');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `admins`
--

CREATE TABLE `admins` (
  `id` int(11) NOT NULL,
  `email` varchar(100) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `password` varchar(250) COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `admins`
--

INSERT INTO `admins` (`id`, `email`, `password`) VALUES
(1, 'hpadmin@hp-onilne.hu', '$2y$10$6OF55Ruz6VDaiA.978yvSeuoY3xYw4xQUVngBGqHWhJzjWIP2/mpu');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `books`
--

CREATE TABLE `books` (
  `id` int(11) NOT NULL,
  `title` varchar(100) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `publication_date` date DEFAULT NULL,
  `pages` int(11) DEFAULT NULL,
  `img_url` varchar(100) COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `books`
--

INSERT INTO `books` (`id`, `title`, `publication_date`, `pages`, `img_url`) VALUES
(1, 'Harry Potter és a Bölcsek Köve', '1997-06-26', 223, 'img/book1.jpg'),
(2, 'Harry Potter és a Titkok Kamrája', '1998-07-02', 251, 'img/book2.jpg'),
(3, 'Harry Potter és az Azkabani Fogoly', '1999-07-08', 317, 'img/book3.jpg'),
(4, 'Harry Potter és a Tűz Serlege', '2000-07-08', 636, 'img/book4.png'),
(5, 'Harry Potter és a Főnix Rendje', '2003-06-21', 766, 'img/book5.jpg'),
(6, 'Harry Potter és a Félvér Herceg', '2005-07-16', 608, 'img/book6.png'),
(7, 'Harry Potter és a Halál Ereklyéi', '2007-07-21', 607, 'img/book7.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `films`
--

CREATE TABLE `films` (
  `id` int(11) NOT NULL,
  `title` varchar(100) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `premier` date DEFAULT NULL,
  `director` varchar(100) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `income` int(11) DEFAULT NULL,
  `actors_id` varchar(200) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `img_url` varchar(100) COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `films`
--

INSERT INTO `films` (`id`, `title`, `premier`, `director`, `income`, `actors_id`, `img_url`) VALUES
(1, 'Harry Potter és a Bölcsek Köve', '2001-11-04', 'Chris Columbus', 976475550, '1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23;24;25;26;27;28;29;30;31;32;33;34;35;36;37', 'img/film1.jpg'),
(2, 'Harry Potter és a Titkok Kamrája', '2002-11-03', 'Chris Columbus', 876688482, '1;2;3;35;4;5;6;7;38;39;9;10;11;12;13;34;40;30;31;29;19;41;21;14;42;43;44;45', 'img/film2.jpg'),
(3, 'Harry Potter és az Azkabani Fogoly', '2004-05-23', 'Alfonso Cuarón', 795541069, '1;2;3;4;46;6;47;7;48;49;50;9;10;11;12;13;51;52;35;30;31;29;21;43;23;24;25;26;27;28', 'img/film3.jpg'),
(4, 'Harry Potter és a Tűz Serlege', '2005-04-06', 'Mike Newell', 892213036, '1;2;3;4;46;6;19;7;53;54;55;50;45;49;9;10;56;57;58;59;42;60;61;62;63;35;30;31;29;21;43;23;24;25;26;27;28;64', 'img/film4.jpg'),
(5, 'Harry Potter és a Főnix Rendje', '2007-06-28', 'David Yates', 938468864, '1;2;3;35;26;65;4;46;6;19;47;7;53;48;66;67;49;55;45;68;9;10;11;12;13;69;70;29;71;21;72;43;23;24;25;30;31;27;28;64', 'img/film5.jpg'),
(6, 'Harry Potter és a Félvér Herceg', '2009-07-07', 'David Yates', 929359401, '1;2;3;4;46;73;6;9;19;47;7;48;66;34;40;30;31;74;68;75;21;72;43;23;24;25;76;65;35;26;27;28;77', 'img/film6.jpg'),
(7, 'Harry Potter és a Halál Ereklyéi 1.', '2010-11-11', 'David Yates', 976536918, '1;2;3;4;46;78;7;9;10;34;40;37;55;53;48;79;68;50;44;45;74;11;12;13;80;30;31;35;61;36;26;23;76;64;27;65;77;67;66;81;72;69;59;75;57;82;73', 'img/film7.jpg'),
(8, 'Harry Potter és a Halál Ereklyéi 2.', '2011-07-07', 'David Yates', 1328111219, '1;2;3;4;46;6;7;55;49;9;10;45;74;68;34;40;71;48;66;67;37;80;61;29;30;31;35;21;47;73;41;36;19;26;64;65;23;25;27;28;76;77;32;75;50', 'img/film8.jpg');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `actors`
--
ALTER TABLE `actors`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `films`
--
ALTER TABLE `films`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `actors`
--
ALTER TABLE `actors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=83;

--
-- AUTO_INCREMENT a táblához `admins`
--
ALTER TABLE `admins`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT a táblához `films`
--
ALTER TABLE `films`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
