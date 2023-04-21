-- phpMyAdmin SQL Dump
-- version 5.1.4deb1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Creato il: Apr 20, 2023 alle 08:43
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `Allievi`
--

INSERT INTO `Allievi` (`IDAllievo`, `Nome`, `Cognome`, `IDClasse`, `IDBadge`) VALUES
(1, 'Michael', 'Mioni', 3, 1),
(2, 'Elia', 'Perin', 3, 0),
(3, 'Yuri', 'Scian', 1, 0),
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `Badge`
--

INSERT INTO `Badge` (`IDBadge`, `id1`, `id2`, `id3`, `id4`) VALUES
(1, 202, 119, 4, 134);

-- --------------------------------------------------------

--
-- Struttura della tabella `classi`
--

CREATE TABLE `classi` (
  `IDClasse` int NOT NULL,
  `Nome` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dump dei dati per la tabella `Movimenti`
--

INSERT INTO `Movimenti` (`id_Badge`, `id_Term`, `id1`, `id2`, `id3`, `id4`, `Data`, `Ora`) VALUES
(1, 2, 202, 119, 4, 134, '2023-04-19', NULL),
(2, 2, 202, 119, 4, 134, '2023-04-19', NULL),
(3, 2, 202, 119, 4, 134, '2023-04-19', NULL),
(4, 2, 202, 119, 4, 134, '2023-04-19', '16:36:01');

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
  MODIFY `IDBadge` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT per la tabella `classi`
--
ALTER TABLE `classi`
  MODIFY `IDClasse` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `Movimenti`
--
ALTER TABLE `Movimenti`
  MODIFY `id_Badge` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
