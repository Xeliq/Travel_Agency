-- phpMyAdmin SQL Dump
-- version 4.9.10
-- https://www.phpmyadmin.net/
--
-- Host: mysql43.mydevil.net
-- Czas generowania: 30 Sty 2023, 02:11
-- Wersja serwera: 8.0.30
-- Wersja PHP: 7.3.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `m1366_biuro_podrozy`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `bagaze`
--

CREATE TABLE `bagaze` (
  `id` int NOT NULL,
  `podstawa` tinyint NOT NULL,
  `doplata` decimal(5,2) NOT NULL,
  `wymiary` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `bagaze`
--

INSERT INTO `bagaze` (`id`, `podstawa`, `doplata`, `wymiary`) VALUES
(1, 8, '0.00', '1x8'),
(3, 15, '80.00', '1x15'),
(5, 20, '130.00', '1x20'),
(6, 23, '200.00', '1x23'),
(7, 32, '304.00', '1x32'),
(8, 41, '440.00', '1x41'),
(9, 52, '520.00', '1x52'),
(10, 25, '0.00', '90x75x25'),
(12, 0, '0.00', 'ile pomieści bagażnik?');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dane_klienta`
--

CREATE TABLE `dane_klienta` (
  `id` int NOT NULL,
  `imie` tinytext NOT NULL,
  `nazwisko` tinytext NOT NULL,
  `data_urodzenia` date NOT NULL,
  `nr_tel` varchar(9) NOT NULL,
  `mail` tinytext NOT NULL,
  `ilosc_wycieczek` int NOT NULL,
  `nr_dokumentu` tinytext NOT NULL,
  `czy_wiza` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `dane_klienta`
--

INSERT INTO `dane_klienta` (`id`, `imie`, `nazwisko`, `data_urodzenia`, `nr_tel`, `mail`, `ilosc_wycieczek`, `nr_dokumentu`, `czy_wiza`) VALUES
(1, 'ja', 'ja', '2022-12-06', '222222222', 'dawdaw', 0, 'wqe1243152er23', 0),
(6, 'daw', 'daw', '2002-10-10', '123456789', 'dawd', 0, 'daw', 1),
(8, 'Zain', 'Din', '2003-01-01', '600100100', 'bombowiec3000@wp.pl', 0, '', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `faktura`
--

CREATE TABLE `faktura` (
  `id` int NOT NULL,
  `imie` tinytext COLLATE utf8mb4_general_ci NOT NULL,
  `nazwisko` tinytext COLLATE utf8mb4_general_ci NOT NULL,
  `nrTele` tinytext COLLATE utf8mb4_general_ci NOT NULL,
  `email` tinytext COLLATE utf8mb4_general_ci NOT NULL,
  `dataUro` tinytext COLLATE utf8mb4_general_ci NOT NULL,
  `nrDowodu` tinytext COLLATE utf8mb4_general_ci NOT NULL,
  `nrWycieczki` tinyint NOT NULL,
  `typWycieczki` tinytext COLLATE utf8mb4_general_ci NOT NULL,
  `zwierzeta` tinyint(1) NOT NULL,
  `kwotaKoncowa` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `faktura`
--

INSERT INTO `faktura` (`id`, `imie`, `nazwisko`, `nrTele`, `email`, `dataUro`, `nrDowodu`, `nrWycieczki`, `typWycieczki`, `zwierzeta`, `kwotaKoncowa`) VALUES
(7, 'Zain', 'Din', '600100100', 'muholot@wp.pl', '2003-01-01', 'ZAI213769', 16, 'zagraniczna', 0, 11609),
(8, 'Muchomor', 'Din', '600100100', 'muchomor@wp.pl', '2000-01-01', 'JDK123456', 30, 'zagraniczna', 0, 46927);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `faktury`
--

CREATE TABLE `faktury` (
  `id` int NOT NULL,
  `cena_koncowa` decimal(5,2) NOT NULL,
  `dane_klienta` int NOT NULL,
  `wycieczka` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kody_rabatowe`
--

CREATE TABLE `kody_rabatowe` (
  `id` int NOT NULL,
  `kod` tinytext COLLATE utf8mb4_general_ci NOT NULL,
  `mnoznik_znizki` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `kody_rabatowe`
--

INSERT INTO `kody_rabatowe` (`id`, `kod`, `mnoznik_znizki`) VALUES
(1, 'WAKACJE2023', 0.88),
(2, 'NEW123', 0.9),
(3, 'WYCIECZKA23', 0.95);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `konta`
--

CREATE TABLE `konta` (
  `id` int NOT NULL,
  `login` tinytext NOT NULL,
  `haslo` text NOT NULL,
  `rodzaj_konta` tinyint(1) NOT NULL,
  `dane` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `konta`
--

INSERT INTO `konta` (`id`, `login`, `haslo`, `rodzaj_konta`, `dane`) VALUES
(1, 'dawid', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 1),
(2, 'ja', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 1, 1),
(3, 'daw', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 6),
(5, 'muha', 'f760186b9a51d122e32513de4ed73c0c21066970d96ca655f44abad7ff36452f', 0, 8);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `miejsca`
--

CREATE TABLE `miejsca` (
  `id` int NOT NULL,
  `miejsca` tinytext NOT NULL,
  `dojazd` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `miejsca`
--

INSERT INTO `miejsca` (`id`, `miejsca`, `dojazd`) VALUES
(1, 'Jordania', 2),
(2, 'Alabama', 2),
(3, 'Berlin', 2),
(4, 'Warszawa', 2),
(5, 'Gdańsk', 2),
(6, 'Katowice', 2),
(7, 'Warszawa', 4),
(8, 'Gdańsk', 4),
(9, 'Katowice', 4),
(10, 'Praga', 2),
(11, '-', 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `miejsca_wycieczek`
--

CREATE TABLE `miejsca_wycieczek` (
  `id` int NOT NULL,
  `kraj` tinytext NOT NULL,
  `miasto` tinytext NOT NULL,
  `hotel` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `miejsca_wycieczek`
--

INSERT INTO `miejsca_wycieczek` (`id`, `kraj`, `miasto`, `hotel`) VALUES
(1, 'Polska', 'Warszawa', 'Faltom'),
(2, 'Niemcy', 'Berlin', 'Adlon'),
(3, 'Grecja', 'Chalkidiki', 'Xenios Port Marina'),
(4, 'Egipt', 'Marsa Alam', 'Lazuli'),
(5, 'Madera', 'Ponta Delegada', 'Monte Mar Palace'),
(6, 'Zanzibar', 'Uroa', 'Uroa Bay Beach Resort'),
(7, 'Hiszpania', 'Gran Canaria', 'Mirador Maspalomas by Dunas'),
(8, 'Grecja', 'Thassos', 'Blue Dream Palace '),
(9, 'Albania', 'Durres', 'Grand Blue Fala'),
(10, 'Włochy ', 'Rzym', 'Folia'),
(11, 'Cypr', 'Patos', 'Myfair '),
(12, 'Polska', 'Międzyzdroje', 'Vestina Wellness & SPA'),
(13, 'Polska', 'Toruń', 'Kopernik'),
(14, 'Polska', 'Czarna Góra', 'Montero Resort & SPA'),
(15, 'Polska', 'Zakopane', 'Tatra'),
(16, 'Polska', 'Racławice', 'Mercure Racławice Dosłońce SPA'),
(17, 'Polska', 'Ustronie Morskie', 'Erholungshaus Borgata'),
(18, 'Polska', 'Świeradów Zdrój', 'Medi Spa Biały Kamień'),
(19, 'Polska', 'Kraków', 'Qubus Kraków'),
(20, 'Polska', 'Gdańsk', 'Podewils'),
(21, 'Polska', 'Dąbki', 'Delfin Spa & Wellness'),
(51, 'Republika Zielonego Przylądka', 'Sal', 'Oasis Atlantico Belorizonte'),
(52, 'Indonezja ', 'Bali', 'Meliá Bali'),
(53, 'Malediwy', 'Hulhumale', 'Ahoj Malediwy!'),
(54, 'Malediwy', 'Lankanfinolhu', 'Paradise Island Resort'),
(55, 'Seszele', 'Wyspa Praslin', 'Cote D\'Or Lodge'),
(56, 'Barbados', ' Bridgetown', 'Sugar Bay Barbados'),
(57, 'Seszele ', 'Wyspa Mahe', 'Hilton Seychelles Northolme Resort & Spa'),
(58, 'Kenia', 'Wybrzeże Mombasy', 'Diamonds Leisure Beach & Golf Resort'),
(59, 'Meksyk', 'Meksyk', 'Que rico Mexico'),
(60, 'Zjednoczone Emiraty Arabskie', 'Abu Dhabi', 'Fairmont Bab Al Bahr'),
(61, 'Mauritius', 'Wybrzeże Południowe', 'Outrigger Mauritius Beach Resort');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `podania_o_zwrot`
--

CREATE TABLE `podania_o_zwrot` (
  `id` int NOT NULL,
  `zakupiona_wycieczka` int NOT NULL,
  `czy_rozpatrzony` tinyint(1) NOT NULL,
  `kwota_zwrotu` decimal(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rodzaje_dojazdow`
--

CREATE TABLE `rodzaje_dojazdow` (
  `id` int NOT NULL,
  `jaki_dojazd` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `rodzaje_dojazdow`
--

INSERT INTO `rodzaje_dojazdow` (`id`, `jaki_dojazd`) VALUES
(1, 'Autobus'),
(2, 'Samolot'),
(3, 'Własny '),
(4, 'Autokar'),
(5, 'Pociąg');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rodzaje_wyzywienia`
--

CREATE TABLE `rodzaje_wyzywienia` (
  `id` int NOT NULL,
  `rodzaj` tinytext NOT NULL,
  `cena` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `rodzaje_wyzywienia`
--

INSERT INTO `rodzaje_wyzywienia` (`id`, `rodzaj`, `cena`) VALUES
(1, 'brak', '0.00'),
(2, 'Śniadanie', '40.00'),
(3, 'Śniadanie i obiadokolacja', '100.00'),
(4, 'Pełne wyżywienie ', '120.00'),
(5, 'All inclusive', '200.00');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rodzaj_cena_wyzywienia`
--

CREATE TABLE `rodzaj_cena_wyzywienia` (
  `id` int NOT NULL,
  `rodzaj` int NOT NULL,
  `cena` decimal(5,2) NOT NULL,
  `wycieczka` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `rodzaj_cena_wyzywienia`
--

INSERT INTO `rodzaj_cena_wyzywienia` (`id`, `rodzaj`, `cena`, `wycieczka`) VALUES
(1, 1, '0.00', 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `transporty`
--

CREATE TABLE `transporty` (
  `id` int NOT NULL,
  `pojazd` tinytext NOT NULL,
  `czas` time NOT NULL,
  `bagaz` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `transporty`
--

INSERT INTO `transporty` (`id`, `pojazd`, `czas`, `bagaz`) VALUES
(1, 'Własne uznanie ', '00:00:00', 12),
(2, 'Limuzyna', '06:00:00', 3),
(3, 'Autokar', '04:30:00', 10),
(4, 'Autokar', '08:00:00', 10),
(5, 'Samolot', '02:30:00', 5),
(6, 'Samolot', '08:15:00', 3),
(7, 'Samolot', '05:30:00', 3),
(8, 'Samolot', '05:00:00', 5),
(9, 'Samolot', '10:00:00', 6),
(10, 'Samolot', '07:50:00', 5),
(11, 'Samolot', '06:45:00', 3),
(12, 'Samolot', '02:15:00', 7),
(13, 'Samolot', '02:25:00', 1),
(14, 'Samolot', '04:00:00', 6),
(15, 'Samolot', '23:00:00', 1),
(16, 'Samolot', '15:00:00', 5),
(17, 'Samolot', '15:00:00', 6),
(18, 'Samolot', '11:00:00', 5),
(19, 'Samolot', '12:00:00', 1),
(20, 'Samolot', '11:00:00', 6),
(21, 'Samolot', '11:00:00', 6),
(22, 'Samolot', '22:00:00', 6),
(23, 'Samolot', '06:00:00', 3),
(24, 'Samolot', '14:00:00', 6);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wycieczki`
--

CREATE TABLE `wycieczki` (
  `id` int NOT NULL,
  `ilosc_miejsc` int NOT NULL,
  `miejsce_zbiorki` int NOT NULL,
  `rodzaj_transportu` int NOT NULL,
  `dokad` int NOT NULL,
  `od_kiedy` date NOT NULL,
  `do_kiedy` date NOT NULL,
  `czy_zwierze` tinyint(1) NOT NULL,
  `cena_zwierze` int NOT NULL,
  `cena_dziecko` int NOT NULL,
  `cena_dorosly` int NOT NULL,
  `polisa_podstawowa` decimal(5,2) NOT NULL,
  `polisa_premium` decimal(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Zrzut danych tabeli `wycieczki`
--

INSERT INTO `wycieczki` (`id`, `ilosc_miejsc`, `miejsce_zbiorki`, `rodzaj_transportu`, `dokad`, `od_kiedy`, `do_kiedy`, `czy_zwierze`, `cena_zwierze`, `cena_dziecko`, `cena_dorosly`, `polisa_podstawowa`, `polisa_premium`) VALUES
(1, 50, 11, 1, 12, '2020-03-14', '2020-03-23', 0, 0, 0, 1120, '69.30', '132.30'),
(2, 40, 11, 1, 14, '2023-04-30', '2023-05-03', 0, 0, 0, 1188, '35.60', '75.60'),
(3, 35, 11, 1, 13, '2001-04-01', '2001-04-07', 1, 300, 0, 774, '59.40', '113.40'),
(4, 47, 11, 1, 15, '2023-06-01', '2023-06-06', 0, 0, 0, 1750, '53.40', '113.40'),
(5, 20, 11, 1, 16, '2023-05-16', '2023-05-22', 1, 450, 1620, 3240, '62.30', '132.30'),
(6, 18, 11, 1, 17, '2023-06-11', '2023-06-18', 1, 600, 1257, 2513, '71.20', '151.20'),
(7, 60, 11, 1, 18, '2023-05-04', '2023-05-07', 0, 0, 750, 1497, '35.60', '75.60'),
(8, 40, 11, 1, 19, '2023-06-30', '2023-07-02', 1, 600, 1151, 2302, '26.70', '56.70'),
(9, 50, 7, 3, 20, '2023-07-10', '2023-07-17', 0, 0, 1438, 2877, '71.20', '132.30'),
(10, 38, 9, 4, 21, '2023-08-07', '2023-08-14', 0, 0, 777, 1554, '71.20', '151.20'),
(13, 65, 7, 5, 3, '2023-09-27', '2023-10-04', 0, 0, 500, 1800, '87.20', '167.20'),
(14, 75, 4, 6, 51, '2023-07-25', '2023-08-01', 0, 0, 1000, 5039, '87.20', '167.20'),
(15, 67, 6, 7, 4, '2023-05-13', '2023-05-20', 0, 0, 1020, 3869, '87.20', '167.20'),
(16, 47, 4, 8, 5, '2023-05-06', '2023-05-13', 0, 0, 990, 3399, '87.20', '167.20'),
(17, 36, 6, 9, 6, '2023-06-19', '2023-06-26', 1, 800, 1579, 5279, '87.20', '167.20'),
(18, 23, 5, 10, 7, '2023-05-19', '2023-05-26', 1, 1299, 1800, 3749, '87.20', '167.20'),
(19, 63, 6, 11, 8, '2023-05-21', '2023-05-28', 0, 0, 1109, 3109, '87.20', '167.20'),
(20, 52, 4, 12, 9, '2023-09-24', '2023-10-01', 0, 0, 889, 2799, '87.20', '167.20'),
(21, 42, 6, 13, 10, '2023-04-30', '2023-05-06', 1, 1345, 2000, 4558, '76.30', '146.00'),
(22, 56, 5, 14, 11, '2023-04-30', '2023-05-03', 0, 0, 1200, 2379, '76.30', '146.00'),
(23, 80, 4, 15, 52, '2023-07-03', '2023-07-08', 0, 0, 4000, 10129, '76.30', '146.00'),
(24, 90, 4, 16, 53, '2023-03-08', '2023-03-16', 0, 0, 3900, 9473, '87.20', '167.20'),
(25, 56, 4, 17, 54, '2023-06-11', '2023-06-18', 0, 0, 6000, 11673, '87.20', '167.20'),
(26, 30, 4, 18, 55, '2023-03-02', '2023-03-09', 0, 0, 4999, 10419, '87.20', '167.20'),
(27, 87, 6, 19, 56, '2023-03-19', '2023-03-24', 0, 0, 6999, 12349, '65.40', '125.00'),
(29, 67, 6, 20, 57, '2023-03-15', '2023-03-21', 0, 0, 7999, 16979, '76.30', '146.00'),
(30, 85, 6, 21, 58, '2023-05-31', '2023-06-06', 0, 0, 6999, 12789, '76.30', '146.00'),
(31, 35, 6, 23, 60, '2023-05-18', '2023-05-28', 0, 0, 5895, 1999, '76.30', '146.00'),
(32, 77, 4, 24, 61, '2023-05-17', '2023-06-02', 0, 0, 7999, 16979, '174.00', '334.00'),
(33, 75, 6, 22, 59, '2023-03-31', '2023-04-13', 0, 0, 6999, 11999, '152.00', '292.60');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `zakupione_wycieczki`
--

CREATE TABLE `zakupione_wycieczki` (
  `id` int NOT NULL,
  `wycieczka` int NOT NULL,
  `konto` int NOT NULL,
  `ilos_doroslych` int NOT NULL,
  `ilosc_dzieci` int NOT NULL,
  `zaliczka` decimal(5,2) NOT NULL,
  `faktura` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `bagaze`
--
ALTER TABLE `bagaze`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `dane_klienta`
--
ALTER TABLE `dane_klienta`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `faktura`
--
ALTER TABLE `faktura`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `faktury`
--
ALTER TABLE `faktury`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ogranicenia_1` (`dane_klienta`),
  ADD KEY `ogranicenia_2` (`wycieczka`);

--
-- Indeksy dla tabeli `kody_rabatowe`
--
ALTER TABLE `kody_rabatowe`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `konta`
--
ALTER TABLE `konta`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ogranicenia_0` (`dane`);

--
-- Indeksy dla tabeli `miejsca`
--
ALTER TABLE `miejsca`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Relacja1` (`dojazd`);

--
-- Indeksy dla tabeli `miejsca_wycieczek`
--
ALTER TABLE `miejsca_wycieczek`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `podania_o_zwrot`
--
ALTER TABLE `podania_o_zwrot`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `rodzaje_dojazdow`
--
ALTER TABLE `rodzaje_dojazdow`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `rodzaje_wyzywienia`
--
ALTER TABLE `rodzaje_wyzywienia`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `rodzaj_cena_wyzywienia`
--
ALTER TABLE `rodzaj_cena_wyzywienia`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Relacja_1` (`rodzaj`),
  ADD KEY `ogranicenia_2332` (`wycieczka`);

--
-- Indeksy dla tabeli `transporty`
--
ALTER TABLE `transporty`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ograniczenie_1` (`bagaz`);

--
-- Indeksy dla tabeli `wycieczki`
--
ALTER TABLE `wycieczki`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Relacja123` (`miejsce_zbiorki`),
  ADD KEY `ogranicenia_24321` (`rodzaj_transportu`),
  ADD KEY `31213` (`dokad`);

--
-- Indeksy dla tabeli `zakupione_wycieczki`
--
ALTER TABLE `zakupione_wycieczki`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Relacja13` (`konto`),
  ADD KEY `ogranicenia_23` (`faktura`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `bagaze`
--
ALTER TABLE `bagaze`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT dla tabeli `dane_klienta`
--
ALTER TABLE `dane_klienta`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT dla tabeli `faktura`
--
ALTER TABLE `faktura`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT dla tabeli `faktury`
--
ALTER TABLE `faktury`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `kody_rabatowe`
--
ALTER TABLE `kody_rabatowe`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `konta`
--
ALTER TABLE `konta`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `miejsca`
--
ALTER TABLE `miejsca`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT dla tabeli `miejsca_wycieczek`
--
ALTER TABLE `miejsca_wycieczek`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;

--
-- AUTO_INCREMENT dla tabeli `podania_o_zwrot`
--
ALTER TABLE `podania_o_zwrot`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `rodzaje_dojazdow`
--
ALTER TABLE `rodzaje_dojazdow`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT dla tabeli `rodzaje_wyzywienia`
--
ALTER TABLE `rodzaje_wyzywienia`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT dla tabeli `rodzaj_cena_wyzywienia`
--
ALTER TABLE `rodzaj_cena_wyzywienia`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `transporty`
--
ALTER TABLE `transporty`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT dla tabeli `wycieczki`
--
ALTER TABLE `wycieczki`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT dla tabeli `zakupione_wycieczki`
--
ALTER TABLE `zakupione_wycieczki`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `faktury`
--
ALTER TABLE `faktury`
  ADD CONSTRAINT `ogranicenia_1` FOREIGN KEY (`dane_klienta`) REFERENCES `dane_klienta` (`id`),
  ADD CONSTRAINT `ogranicenia_2` FOREIGN KEY (`wycieczka`) REFERENCES `wycieczki` (`id`);

--
-- Ograniczenia dla tabeli `konta`
--
ALTER TABLE `konta`
  ADD CONSTRAINT `ogranicenia_0` FOREIGN KEY (`dane`) REFERENCES `dane_klienta` (`id`);

--
-- Ograniczenia dla tabeli `miejsca`
--
ALTER TABLE `miejsca`
  ADD CONSTRAINT `Relacja1` FOREIGN KEY (`dojazd`) REFERENCES `rodzaje_dojazdow` (`id`);

--
-- Ograniczenia dla tabeli `rodzaj_cena_wyzywienia`
--
ALTER TABLE `rodzaj_cena_wyzywienia`
  ADD CONSTRAINT `ogranicenia_2332` FOREIGN KEY (`wycieczka`) REFERENCES `wycieczki` (`id`),
  ADD CONSTRAINT `Relacja_1` FOREIGN KEY (`rodzaj`) REFERENCES `rodzaje_wyzywienia` (`id`);

--
-- Ograniczenia dla tabeli `transporty`
--
ALTER TABLE `transporty`
  ADD CONSTRAINT `ograniczenie_1` FOREIGN KEY (`bagaz`) REFERENCES `bagaze` (`id`);

--
-- Ograniczenia dla tabeli `wycieczki`
--
ALTER TABLE `wycieczki`
  ADD CONSTRAINT `31213` FOREIGN KEY (`dokad`) REFERENCES `miejsca_wycieczek` (`id`),
  ADD CONSTRAINT `ogranicenia_24321` FOREIGN KEY (`rodzaj_transportu`) REFERENCES `transporty` (`id`),
  ADD CONSTRAINT `Relacja123` FOREIGN KEY (`miejsce_zbiorki`) REFERENCES `miejsca` (`id`);

--
-- Ograniczenia dla tabeli `zakupione_wycieczki`
--
ALTER TABLE `zakupione_wycieczki`
  ADD CONSTRAINT `ogranicenia_23` FOREIGN KEY (`faktura`) REFERENCES `faktury` (`id`),
  ADD CONSTRAINT `Relacja13` FOREIGN KEY (`konto`) REFERENCES `konta` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
