-- phpMyAdmin SQL Dump
-- version 5.1.4deb1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Creato il: Apr 20, 2023 alle 14:55
-- Versione del server: 8.0.32-0ubuntu0.22.10.2
-- Versione PHP: 8.1.7-1ubuntu3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `restroomtime`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `Allievi`
--

CREATE TABLE `Allievi` (
  `IDAllievo` int NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Cognome` varchar(50) NOT NULL,
  `IDClasse` int NOT NULL,
  `IDBadge` int NOT NULL
) ENGINE=InnoDB;

--
-- Dump dei dati per la tabella `Allievi`
--

INSERT INTO `Allievi` (`IDAllievo`, `Nome`, `Cognome`, `IDClasse`, `IDBadge`) VALUES
(1, 'Michael', 'Mioni', 3, 1),
(2, 'Elia', 'Perin', 3, 2),
(3, 'Yuri', 'Scian', 1, 3),
(4, 'Alban', 'Ferizoviku', 5, 0);

-- --------------------------------------------------------

--
-- Struttura della tabella `Badge`
--

CREATE TABLE `Badge` (
  `IDBadge` int NOT NULL,
  `id1` int NOT NULL,
  `id2` int NOT NULL,
  `id3` int NOT NULL,
  `id4` int NOT NULL
) ENGINE=InnoDB;

--
-- Dump dei dati per la tabella `Badge`
--

INSERT INTO `Badge` (`IDBadge`, `id1`, `id2`, `id3`, `id4`) VALUES
(1, 231, 1, 16, 179),
(2, 218, 233, 172, 25);

-- --------------------------------------------------------

--
-- Struttura della tabella `classi`
--

CREATE TABLE `classi` (
  `IDClasse` int NOT NULL,
  `Nome` varchar(50) NOT NULL
) ENGINE=InnoDB;

--
-- Dump dei dati per la tabella `classi`
--

INSERT INTO `classi` (`IDClasse`, `Nome`) VALUES
(1, '1A IOT'),
(2, '1B IOT'),
(3, '2 IOT'),
(4, '1 MAKER'),
(5, '2 MAKER'),
(6, '3 MAKER'),
(7, '4 MAKER');

-- --------------------------------------------------------

--
-- Struttura della tabella `Movimenti`
--

CREATE TABLE `Movimenti` (
  `id_Badge` int NOT NULL,
  `id_Term` int NOT NULL,
  `id1` int NOT NULL,
  `id2` int NOT NULL,
  `id3` int NOT NULL,
  `id4` int NOT NULL,
  `Data` date DEFAULT NULL,
  `Ora` time DEFAULT NULL
) ENGINE=InnoDB;

--
-- Dump dei dati per la tabella `Movimenti`
--

INSERT INTO `Movimenti` (`id_Badge`, `id_Term`, `id1`, `id2`, `id3`, `id4`, `Data`, `Ora`) VALUES
(1, 2, 202, 119, 4, 134, '2023-04-19', NULL),
(2, 2, 202, 119, 4, 134, '2023-04-19', NULL),
(3, 2, 202, 119, 4, 134, '2023-04-19', NULL),
(4, 2, 202, 119, 4, 134, '2023-04-19', '16:36:01'),
(5, 1, 231, 1, 16, 179, '2023-04-20', '12:18:08'),
(6, 1, 218, 223, 172, 25, '2023-04-20', '12:18:14'),
(7, 1, 218, 223, 172, 25, '2023-04-20', '12:18:17'),
(8, 1, 218, 223, 172, 25, '2023-04-20', '12:18:22'),
(9, 1, 231, 1, 16, 179, '2023-04-20', '12:18:25'),
(10, 1, 218, 223, 172, 25, '2023-04-20', '12:18:27'),
(11, 1, 218, 223, 172, 25, '2023-04-20', '12:18:30'),
(12, 1, 218, 223, 172, 25, '2023-04-20', '12:18:32'),
(13, 1, 231, 1, 16, 179, '2023-04-20', '12:18:34'),
(14, 1, 231, 1, 16, 179, '2023-04-20', '12:18:36'),
(15, 1, 231, 1, 16, 179, '2023-04-20', '12:18:38'),
(16, 1, 218, 223, 172, 25, '2023-04-20', '12:18:50'),
(17, 1, 218, 223, 172, 25, '2023-04-20', '12:18:52'),
(18, 1, 218, 223, 172, 25, '2023-04-20', '12:26:01'),
(19, 1, 218, 223, 172, 25, '2023-04-20', '12:32:26'),
(20, 1, 218, 223, 172, 25, '2023-04-20', '12:32:30'),
(21, 1, 218, 223, 172, 25, '2023-04-20', '12:32:30'),
(22, 1, 218, 223, 172, 25, '2023-04-20', '12:32:33'),
(23, 1, 218, 223, 172, 25, '2023-04-20', '12:34:21'),
(24, 1, 231, 1, 16, 179, '2023-04-20', '12:34:28'),
(25, 1, 218, 223, 172, 25, '2023-04-20', '16:12:21'),
(26, 1, 218, 223, 172, 25, '2023-04-20', '16:12:35'),
(27, 1, 218, 223, 172, 25, '2023-04-20', '16:12:39'),
(28, 1, 231, 1, 16, 179, '2023-04-20', '16:13:38'),
(29, 1, 218, 223, 172, 25, '2023-04-20', '16:13:49'),
(30, 1, 218, 223, 172, 25, '2023-04-20', '16:41:41'),
(31, 1, 231, 1, 16, 179, '2023-04-20', '16:41:54'),
(32, 1, 218, 223, 172, 25, '2023-04-20', '16:43:55'),
(33, 1, 231, 1, 16, 179, '2023-04-20', '16:44:00'),
(34, 1, 231, 1, 16, 179, '2023-04-20', '16:44:02'),
(35, 1, 231, 1, 16, 179, '2023-04-20', '16:44:04'),
(36, 1, 218, 223, 172, 25, '2023-04-20', '16:46:42'),
(37, 1, 218, 223, 172, 25, '2023-04-20', '16:47:16'),
(38, 1, 231, 1, 16, 179, '2023-04-20', '16:48:44'),
(39, 1, 58, 98, 129, 127, '2023-04-20', '16:48:49'),
(40, 1, 218, 223, 172, 25, '2023-04-20', '16:51:13');

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `Allievi`
--
ALTER TABLE `Allievi`
  ADD PRIMARY KEY (`IDAllievo`);

--
-- Indici per le tabelle `Badge`
--
ALTER TABLE `Badge`
  ADD PRIMARY KEY (`IDBadge`);

--
-- Indici per le tabelle `classi`
--
ALTER TABLE `classi`
  ADD PRIMARY KEY (`IDClasse`);

--
-- Indici per le tabelle `Movimenti`
--
ALTER TABLE `Movimenti`
  ADD PRIMARY KEY (`id_Badge`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `Allievi`
--
ALTER TABLE `Allievi`
  MODIFY `IDAllievo` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT per la tabella `Badge`
--
ALTER TABLE `Badge`
  MODIFY `IDBadge` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT per la tabella `classi`
--
ALTER TABLE `classi`
  MODIFY `IDClasse` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `Movimenti`
--
ALTER TABLE `Movimenti`
  MODIFY `id_Badge` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
