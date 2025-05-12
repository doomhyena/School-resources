-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Dec 03. 09:26
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `schola_14a_repjegy`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `utak`
--

CREATE TABLE `utak` (
  `id` int(11) NOT NULL,
  `from_city` varchar(1000) NOT NULL,
  `to_city` varchar(1000) NOT NULL,
  `price` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `utak`
--

INSERT INTO `utak` (`id`, `from_city`, `to_city`, `price`) VALUES
(1, 'London', 'San Francisco', 466990),
(2, 'London', 'Delhi', 366654),
(3, 'London', 'Madrid', 347581),
(4, 'London', 'Dallas', 244635),
(5, 'London', 'São Paulo', 236127),
(6, 'New York', 'Miami', 111249),
(7, 'New York', 'Dubaj', 68963),
(8, 'New York', 'Párizs', 271626),
(9, 'New York', 'Moszkva', 398810),
(10, 'New York', 'Denver', 200285),
(11, 'Tokió', 'Peking', 79653),
(12, 'Tokió', 'Jakarta	Indonézia', 92095),
(13, 'Tokió', 'Delhi', 68590),
(14, 'Tokió', 'London', 118144),
(15, 'Tokió', 'Denver', 377150),
(16, 'Sanghaj', 'Szingapúr', 201433),
(17, 'Sanghaj', 'Denver', 72244),
(18, 'Sanghaj', 'Chicago', 98948),
(19, 'Sanghaj', 'Bangkok', 231796),
(20, 'Sanghaj', 'Peking', 104588),
(21, 'Los Angeles', 'Kuangcsou', 361655),
(22, 'Los Angeles', 'Szingapúr', 292864),
(23, 'Los Angeles', 'Delhi', 398780),
(24, 'Los Angeles', 'Hongkong', 470039),
(25, 'Los Angeles', 'Párizs', 106091),
(26, 'Párizs', 'Kuala Lumpur', 364881),
(27, 'Párizs', 'Miami', 479915),
(28, 'Párizs', 'Kuangcsou', 429657),
(29, 'Párizs', 'Frankfurt', 114852),
(30, 'Párizs', 'Tokió', 172968),
(31, 'Atlanta', 'Houston', 69012),
(32, 'Atlanta', 'Jakarta	Indonézia', 99518),
(33, 'Atlanta', 'London', 391637),
(34, 'Atlanta', 'Isztambul', 313004),
(35, 'Atlanta', 'Delhi', 364555),
(36, 'Chicago', 'São Paulo', 199245),
(37, 'Chicago', 'Hongkong', 371446),
(38, 'Chicago', 'Houston', 259404),
(39, 'Chicago', 'London', 88462),
(40, 'Chicago', 'Miami', 76150),
(41, 'Peking', 'Kuangcsou', 205959),
(42, 'Peking', 'London', 349903),
(43, 'Peking', 'Chicago', 282172),
(44, 'Peking', 'Houston', 203706),
(45, 'Peking', 'Jakarta	Indonézia', 79544),
(46, 'Dubaj', 'Moszkva', 357654),
(47, 'Dubaj', 'São Paulo', 448160),
(48, 'Dubaj', 'Dallas', 428068),
(49, 'Dubaj', 'Isztambul', 445486),
(50, 'Dubaj', 'Chicago', 123770),
(51, 'Bangkok', 'Jakarta	Indonézia', 443386),
(52, 'Bangkok', 'Delhi', 235560),
(53, 'Bangkok', 'São Paulo', 471296),
(54, 'Bangkok', 'Atlanta', 377978),
(55, 'Bangkok', 'Amszterdam', 184806),
(56, 'Isztambul', 'Bangkok', 478615),
(57, 'Isztambul', 'Los Angeles', 312089),
(58, 'Isztambul', 'Tokió', 338813),
(59, 'Isztambul', 'Amszterdam', 176396),
(60, 'Isztambul', 'Frankfurt', 85342),
(61, 'Moszkva', 'Tokió', 316312),
(62, 'Moszkva', 'Bangkok', 119653),
(63, 'Moszkva', 'Peking', 475909),
(64, 'Moszkva', 'São Paulo', 389416),
(65, 'Moszkva', 'San Francisco', 232781),
(66, 'Szöul', 'Dallas', 334120),
(67, 'Szöul', 'Dubaj', 137761),
(68, 'Szöul', 'New York', 295635),
(69, 'Szöul', 'Frankfurt', 319524),
(70, 'Szöul', 'Párizs', 93586),
(71, 'Dallas', 'Houston', 342517),
(72, 'Dallas', 'Párizs', 102893),
(73, 'Dallas', 'San Francisco', 313727),
(74, 'Dallas', 'Atlanta', 432846),
(75, 'Dallas', 'São Paulo', 69817),
(76, 'Miami', 'Delhi', 300998),
(77, 'Miami', 'Peking', 478427),
(78, 'Miami', 'London', 385009),
(79, 'Miami', 'Frankfurt', 442670),
(80, 'Miami', 'Houston', 298938),
(81, 'San Francisco', 'Sanghaj', 161957),
(82, 'San Francisco', 'Washington', 355352),
(83, 'San Francisco', 'Kuala Lumpur', 302304),
(84, 'San Francisco', 'Dubaj', 170971),
(85, 'San Francisco', 'Szöul', 369858),
(86, 'Washington', 'Tokió', 399040),
(87, 'Washington', 'Miami', 213411),
(88, 'Washington', 'Párizs', 225507),
(89, 'Washington', 'Sanghaj', 475708),
(90, 'Washington', 'Kuala Lumpur', 487720),
(91, 'Hongkong', 'London', 168899),
(92, 'Hongkong', 'Peking', 82059),
(93, 'Hongkong', 'Houston', 499177),
(94, 'Hongkong', 'Kuangcsou', 333989),
(95, 'Hongkong', 'Kuala Lumpur', 401234),
(96, 'Jakarta	Indonézia', 'Isztambul', 138683),
(97, 'Jakarta	Indonézia', 'Chicago', 169264),
(98, 'Jakarta	Indonézia', 'Frankfurt', 136532),
(99, 'Jakarta	Indonézia', 'New York', 486396),
(100, 'Jakarta	Indonézia', 'Dubaj', 491907),
(101, 'São Paulo', 'Atlanta', 258577),
(102, 'São Paulo', 'Denver', 325947),
(103, 'São Paulo', 'Hongkong', 116001),
(104, 'São Paulo', 'Isztambul', 292663),
(105, 'São Paulo', 'New York', 437225),
(106, 'Amszterdam', 'Los Angeles', 228896),
(107, 'Amszterdam', 'Hongkong', 83024),
(108, 'Amszterdam', 'Dubaj', 199352),
(109, 'Amszterdam', 'Jakarta	Indonézia', 162557),
(110, 'Amszterdam', 'Chicago', 142407),
(111, 'Frankfurt', 'Houston', 168699),
(112, 'Frankfurt', 'Tokió', 322967),
(113, 'Frankfurt', 'Denver', 168875),
(114, 'Frankfurt', 'San Francisco', 462355),
(115, 'Frankfurt', 'Sanghaj', 293644),
(116, 'Kuangcsou', 'Tokió', 343250),
(117, 'Kuangcsou', 'Szöul', 282559),
(118, 'Kuangcsou', 'Amszterdam', 487780),
(119, 'Kuangcsou', 'Dallas', 492342),
(120, 'Kuangcsou', 'Miami', 88326),
(121, 'Delhi', 'Sanghaj', 202737),
(122, 'Delhi', 'Dallas', 274716),
(123, 'Delhi', 'Hongkong', 235869),
(124, 'Delhi', 'Szingapúr', 386532),
(125, 'Delhi', 'Moszkva', 151058),
(126, 'Szingapúr', 'Kuangcsou', 299774),
(127, 'Szingapúr', 'Isztambul', 192850),
(128, 'Szingapúr', 'Peking', 132081),
(129, 'Szingapúr', 'Párizs', 390367),
(130, 'Szingapúr', 'São Paulo', 395745),
(131, 'Kuala Lumpur', 'Denver', 66740),
(132, 'Kuala Lumpur', 'Moszkva', 249946),
(133, 'Kuala Lumpur', 'New York', 490895),
(134, 'Kuala Lumpur', 'Chicago', 388168),
(135, 'Kuala Lumpur', 'Atlanta', 72120),
(136, 'Denver', 'Peking', 70250),
(137, 'Denver', 'Los Angeles', 473948),
(138, 'Denver', 'Madrid', 432523),
(139, 'Denver', 'Houston', 136791),
(140, 'Denver', 'Miami', 145295),
(141, 'Houston', 'Washington', 344427),
(142, 'Houston', 'Dubaj', 461958),
(143, 'Houston', 'São Paulo', 468795),
(144, 'Houston', 'Tokió', 298306),
(145, 'Houston', 'Kuangcsou', 418406),
(146, 'Madrid', 'Párizs', 155454),
(147, 'Madrid', 'Delhi', 470134),
(148, 'Madrid', 'Houston', 231801),
(149, 'Madrid', 'Miami', 346783),
(150, 'Madrid', 'Washington', 169625);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `utak`
--
ALTER TABLE `utak`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `utak`
--
ALTER TABLE `utak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=151;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
