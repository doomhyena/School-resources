-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Máj 22. 20:11
-- Kiszolgáló verziója: 10.4.24-MariaDB
-- PHP verzió: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `commentsdb`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `comments`
--

CREATE TABLE `comments` (
  `id` int(11) NOT NULL,
  `Creator` int(11) NOT NULL,
  `Created` datetime NOT NULL,
  `TopicID` int(11) NOT NULL,
  `Text` text NOT NULL,
  `Prequel` int(11) NOT NULL,
  `Active` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `comments`
--

INSERT INTO `comments` (`id`, `Creator`, `Created`, `TopicID`, `Text`, `Prequel`, `Active`) VALUES
(2, 2, '2022-05-22 20:05:49', 2, 'Most kezdtem el foglalkozni a VS.NET -tel és a C# nyelvvel. Ha van köztetek olyan, aki ezzel foglalkozik vagy csak érdekli itt a helye.\r\n\r\nSzívesen vennék egy-két magyar nyelvű leírást, ha van valakinek. Angolul a Microsoft ellátja az embert temérdek tutoriallal meg sample progival, de magyarul eddig alig találtam valamit.\r\n\r\nNagyon tetszik egyébként a környezet, mert nem kell minden windows-os dolgot lekódolni. Egy sor alapvető műveletet kivesz a kezünkből a VS.NET.\r\nEttől függetlenül nem a legkönnyebb nyelv, mert full objektumorientált, ami (nekem) kicsit nehezebb téma a régi c++ -os tömbkezelésnél, stb.\r\n\r\nSzóval várok minden nemű írást ide, legyen az vélemény attól, aki próbálta, kódrészlet, kérdés... bármi a témában.', 0, b'1'),
(3, 2, '2022-05-22 20:06:44', 3, 'Üdvözlet mindenkinek!\r\nA témát azért nyitottam hogy a címben megnevezett programozási nyelvet kitárgyaljuk, illetve segítséget nyújtsunk azoknak akik kérnek (első vagyok e sorban :D ).\r\n\r\nA Python egy magas szintű objektum-orientált programozási nyelv, ami némileg hasonlít egyes szkriptnyelvekhez (Perlhez, Scheme-hez, TCL--hez), illetve más nyelvekhez is (Java, C). Fő előnye hogy \"könnyen\" (khm :U ) tanulható, komoly alkalmazások fejlesztésére is alkalmazható, sőt rendkívül hatékony.\r\n\r\nFőbb előnyei:\r\nhordozható, integrálható, viszonylag egyszerű, nagyteljesítményű, dinamikus, s nyílt a forráskódja.\r\n\r\nPython-ról magyarul:\r\n[Wikipédia]\r\n[Python.hu]\r\n[Python oktatás]\r\n-\r\n[Python 2.5.2 Windows operációs rendszerre]\r\n\r\nHogyan kezdjünk hozzá a tanulásához?\r\nNehéz lenne okosat mondanom, ugyanis én se vagyok a programozás nagyöregje, DE úgy látom jó úton haladok. Gérard Swinnen : Tanuljunk meg programozni Python nyelven c. könyvét nagyon ajánlom, ami ingyenesen letölthető a python.free-h.net oldalról. E mellé pedig érdemes beszerezni Brad Dayley: Python zsebköny c. csodáját, ami sok hasznos Python programrészletet foglal magában.', 0, b'1'),
(4, 2, '2022-05-22 20:07:28', 4, 'Hi!\r\n\r\nLáttam, hogy nincs igazi Java topic, ezért gondoltam, én nyitok egyet, jó lenne, ha itt kérdezgetnénk Java-s dolgokat. Szóval, hogy megnyissam a sort, lenne is egy kérdésem. Szóval van egy egyszerű Java alkalmazás, é szeretnék beolvasni az inputról. Van két {B}int tpusú változó, és {B}readCharacter(){/B} függvénnyel próbáltam beolvasni, de nem igazán ismeri a függvényt a fordító. Mit kell importálni, hogy működjön?\r\n\r\nKb. ilyen a progi:\r\nclass xy{\r\npublic static void main(String []args)\r\n{\r\nint x;\r\nint y;\r\nx=readCharacter();\r\ny=readCharacter();\r\n}\r\n}\r\n\r\nHa van ötlet, írjatok!!', 0, b'1'),
(5, 3, '2022-05-22 20:08:20', 4, 'Hali!\r\n\r\nEzt máshogy lehet csak megoldani.\r\nMost már túl álmos vagyok a válaszhoz, de addig is, amíg fel nem ébredek, töltsd le az alábbi filet:\r\nftp://ftp.gdf.hu/Public/Java/javaprog.zip\r\n\r\nEbben lesz egy Extra nevű csomag, abban egy Console nevű osztály. Abban van számbeolvasó rutin (mert amúgy csak stringbe lehetne).', 4, b'1'),
(6, 1, '2022-05-22 20:08:51', 2, 'Én a C# mesteri szinten című könyvből tanulok.\r\nKeresgéltem a neten magyar nyelvű szakirodalom után, de nem-igen találtam semmit. A könyvben az alapok elég jól benne vannak szerintem. Egyébként én is programoztam C++-ban, de szerintem C#-ben sokkal könnyebb windows ablakos progik létrehozása. Mondjuk most már c++-ban is lehet \'\'Windows Forms Application (.NET)\'\' projectet készíteni, szal nem kell az MFC-vel kínlódni.\r\n', 0, b'1'),
(7, 3, '2022-05-22 20:09:26', 2, 'hat igen, ha valamit javaban fejlesztesz, akkor azt valoban valtoztatas nelkul futtathatod MACen, linuxon, solarison, windowson is, de a .NET frameworknek csak windowsos portja van, barmilyen meglepo is ez a m$ reszerol :(\r\namugy a gombok, meg stapobbi elemmel kapcsolatban... nezd meg a borland c++ buildert, es kerdezd meg a m$ot, hogy mi tartott 10 evig? ok mar 10, de legalabb 9 eve csinalnak ilyen appokat IDEket :(\r\namugy felreertes ne essek, jo a VS 2K3, csak ha 5 evvel korabban jon, akkor meg korszerunek is mondhatnank...', 0, b'1'),
(8, 4, '2022-05-22 20:09:52', 2, 'Lenne is egy kérdésem: Kivételkezelés.\r\n\r\nSzámomra ez egy bonyolult téma. Vajon használhatok kivételt az előre várt problémákra is? Honnan tudom, hogy melyik kivétel a \'\'megfelelő\'\' az eldobhatók közül és lehet ezeket rangsorolni, hogy ne mindent dobjon el, ha már nem kell?\r\n\r\n(Lehet, hogy a kérdések buták, de igazán nem vagyok othon az ilyesmiben.)', 0, b'1');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `topics`
--

CREATE TABLE `topics` (
  `id` int(11) NOT NULL,
  `Parent` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Created` datetime NOT NULL,
  `Creator` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `topics`
--

INSERT INTO `topics` (`id`, `Parent`, `Name`, `Created`, `Creator`) VALUES
(1, 0, 'Programozás', '2022-05-22 19:44:31', 1),
(2, 1, 'C#', '2022-05-22 19:45:59', 2),
(3, 1, 'Python', '2022-05-22 19:45:59', 2),
(4, 1, 'Java', '2022-05-22 19:46:46', 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Username` varchar(25) NOT NULL,
  `Password` varchar(128) NOT NULL,
  `Role` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `Name`, `Username`, `Password`, `Role`) VALUES
(1, 'Thomas Anderson', 'Neo', '517dc00f10cb25b980e9d564baf8e65753bf0e4f97c8834937abb3337b4aa951b30eedf37b8afb4e31e5ffa388f30bdb9fdf60a96355bda552e4f892d47e4d8d', 'Admin'),
(2, 'Henry Dorsett Case', 'Case', '78a83bf4e0d8f6b2d3cae6dd7c70619e486420075b0638b95c030b4b9e5dd6aa4e0ffb04c0fc2657496aa98ea81a2ec4da7f1cc2ce46bafa25e1fc83ea144a2c', 'Editor'),
(3, 'Rick Deckard', 'Console', 'e9ba822b5ee8de40d5acd4f8654d45a24a3cc68110c8960d7f0bbc938a8fca07e78043585da5dde9fa928610999bbc4044bc3fe9b169de8aca60b27aaa342680', 'User'),
(4, 'William Henry Gates III', 'Bill', 'cab4f6f6daa9a3c167277135ede59a85480b19095887d3a2daa822a8c795252c4e628440a537daa4cda0f337c185a59acd9cfb13b8dc87a937644b7a7ec4529d', 'User');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `comments`
--
ALTER TABLE `comments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Creator` (`Creator`),
  ADD KEY `Prequel` (`Prequel`),
  ADD KEY `TopicID` (`TopicID`);

--
-- A tábla indexei `topics`
--
ALTER TABLE `topics`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Creator` (`Creator`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `comments`
--
ALTER TABLE `comments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT a táblához `topics`
--
ALTER TABLE `topics`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `comments`
--
ALTER TABLE `comments`
  ADD CONSTRAINT `comments_ibfk_1` FOREIGN KEY (`Creator`) REFERENCES `users` (`id`) ON UPDATE NO ACTION,
  ADD CONSTRAINT `comments_ibfk_3` FOREIGN KEY (`TopicID`) REFERENCES `topics` (`id`) ON UPDATE NO ACTION;

--
-- Megkötések a táblához `topics`
--
ALTER TABLE `topics`
  ADD CONSTRAINT `topics_ibfk_1` FOREIGN KEY (`Creator`) REFERENCES `users` (`id`) ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
