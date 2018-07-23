-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 23, 2018 at 06:01 AM
-- Server version: 5.6.34-log
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `epicodemons`
--
CREATE DATABASE IF NOT EXISTS `epicodemons` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `epicodemons`;

-- --------------------------------------------------------

--
-- Table structure for table `battle`
--

CREATE TABLE `battle` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `hitpoints` int(11) NOT NULL,
  `attack` int(11) NOT NULL,
  `defense` int(11) NOT NULL,
  `specialattack` int(11) NOT NULL,
  `specialdefense` int(11) NOT NULL,
  `speed` int(11) NOT NULL,
  `move1pp` int(11) NOT NULL,
  `move2pp` int(11) NOT NULL,
  `move3pp` int(11) NOT NULL,
  `move4pp` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mons`
--

CREATE TABLE `mons` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `hitpoints` int(11) NOT NULL,
  `attack` int(11) NOT NULL,
  `defense` int(11) NOT NULL,
  `specialattack` int(11) NOT NULL,
  `specialdefense` int(11) NOT NULL,
  `speed` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `moves`
--

CREATE TABLE `moves` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `basepower` int(11) NOT NULL,
  `attackstyle` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `secondaryeffect` varchar(255) NOT NULL,
  `powerpoints` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `types`
--

CREATE TABLE `types` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `fairy` int(11) NOT NULL,
  `steel` int(11) NOT NULL,
  `dark` int(11) NOT NULL,
  `dragon` int(11) NOT NULL,
  `ghost` int(11) NOT NULL,
  `rock` int(11) NOT NULL,
  `bug` int(11) NOT NULL,
  `psychic` int(11) NOT NULL,
  `flying` int(11) NOT NULL,
  `ground` int(11) NOT NULL,
  `poison` int(11) NOT NULL,
  `fighting` int(11) NOT NULL,
  `ice` int(11) NOT NULL,
  `grass` int(11) NOT NULL,
  `electric` int(11) NOT NULL,
  `water` int(11) NOT NULL,
  `fire` int(11) NOT NULL,
  `normal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `types`
--

INSERT INTO `types` (`id`, `name`, `fairy`, `steel`, `dark`, `dragon`, `ghost`, `rock`, `bug`, `psychic`, `flying`, `ground`, `poison`, `fighting`, `ice`, `grass`, `electric`, `water`, `fire`, `normal`) VALUES
(1, 'fairy', 0, 1, 2, 3, 0, 0, 2, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0),
(2, 'steel', 2, 2, 0, 2, 0, 2, 2, 2, 2, 1, 3, 1, 2, 2, 0, 0, 1, 2),
(3, 'dark', 1, 0, 2, 0, 2, 0, 1, 3, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0),
(4, 'dragon', 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 0),
(5, 'ghost', 0, 0, 1, 0, 1, 0, 2, 0, 0, 0, 2, 3, 0, 0, 0, 0, 0, 3),
(6, 'rock', 0, 1, 0, 0, 0, 0, 0, 0, 2, 1, 2, 1, 0, 1, 0, 1, 2, 2),
(7, 'bug', 0, 0, 0, 0, 0, 1, 0, 0, 1, 2, 0, 2, 0, 2, 0, 0, 1, 0),
(8, 'psychic', 0, 0, 1, 0, 1, 0, 1, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0),
(9, 'flying', 0, 0, 0, 0, 0, 1, 2, 0, 0, 3, 0, 2, 1, 2, 1, 0, 0, 0),
(10, 'ground', 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 1, 1, 3, 1, 0, 0),
(11, 'poison', 2, 0, 0, 0, 0, 0, 2, 0, 0, 1, 2, 2, 0, 2, 0, 0, 0, 0),
(12, 'fighting', 1, 0, 2, 0, 0, 2, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(13, 'ice', 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 0),
(14, 'grass', 0, 0, 0, 0, 0, 0, 1, 0, 1, 2, 1, 0, 1, 2, 2, 2, 1, 0),
(15, 'electric', 0, 2, 0, 0, 0, 0, 0, 0, 2, 1, 0, 0, 0, 0, 2, 0, 0, 0),
(16, 'water', 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 2, 2, 0),
(17, 'fire', 2, 2, 0, 0, 0, 1, 2, 0, 0, 1, 0, 0, 2, 2, 0, 1, 2, 0),
(18, 'normal', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `battle`
--
ALTER TABLE `battle`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mons`
--
ALTER TABLE `mons`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `moves`
--
ALTER TABLE `moves`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `types`
--
ALTER TABLE `types`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `battle`
--
ALTER TABLE `battle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `mons`
--
ALTER TABLE `mons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `moves`
--
ALTER TABLE `moves`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `types`
--
ALTER TABLE `types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
