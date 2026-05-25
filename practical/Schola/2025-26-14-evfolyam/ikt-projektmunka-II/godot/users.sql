-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Ápr 23. 10:48
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
-- Adatbázis: `2025_14b_godot`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(1000) NOT NULL,
  `password` varchar(1000) NOT NULL,
  `credit` int(11) NOT NULL,
  `perk` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `credit`, `perk`) VALUES
(1, 'Humbi', '$2y$10$58zlZUTQJeBh0z0Tqc74cuMwF0vbxugfG8ozdS8e6myWXjlBmS4H2', 52500, 50),
(2, 'Humbi2', '$2y$10$ABBsJMBbNDt7i9J.vU0QXeMXQnkHNyNGXxnMSBPP1yR/S/lBkIhl6', 0, 1),
(3, 'Humbi3', '$2y$10$YE1b4heqO.ACHD1zSxQdruKT5k4Bk5xm0cCejRB1v25h754rBihF.', 0, 1),
(4, 'humbi4', '$2y$10$u5LqB5mRdNVWGc5k4Zvqlu78oK8yVjv8S29bsKE3/pcSwmpQPHrO6', 0, 1),
(5, 'nigga', '$2y$10$A4eG69ir.qAVZ8x.FAHJdueMKZ2p1HB4K8W5PPHsUlaYYw4N5EO2G', -999999979, 2),
(6, 'balint', '$2y$10$nL6RCrvuQgjtb.uJ0pyf9.aSBrOvClAlLKC8hbdeTTcyPpiggagDK', 15799, 50),
(7, 'Zsolt', '$2y$10$SfuDMboE1r018SuHPNdwLOUHipVCmCtMZBzZo.C2SfNbwwrcBrJMS', 248602, 50),
(8, 'DBenjamin', '$2y$10$tU8OS57GC0gEiq497BVbquf4WctezTmWg8/TkuVyX9eNSzJRQXDJW', 58332, 50),
(9, 'marrkobacsi', '$2y$10$Soht9tJTS8Dkz01APQVBKOuh9VY1kHMZamVOlZ.LODSYFdqErrjv6', 850, 50),
(10, 'peti.', '$2y$10$WGU7ym3p8GB7N9fQESvam.HjwzdNbR.gxtXTAlKM67dIfm5ZAKofa', 150250, 50),
(11, 'doomhyena', '$2y$10$xjROhkoh9cFH/mdFOKYseuPbR2sTYV2sSFCsCthU3AYXpYAK9IpaC', 379016, 50),
(12, 'markkobacsi', '$2y$10$fyYMUKy99RqrkfBxmu2sPuE/KckQ9p1Q84mAnKz1mYxGPo73t7Ux2', 0, 1);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
