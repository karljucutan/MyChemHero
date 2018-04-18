-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 18, 2018 at 02:09 PM
-- Server version: 10.1.9-MariaDB
-- PHP Version: 7.2.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `u951958676_mch`
--

-- --------------------------------------------------------

--
-- Table structure for table `player`
--

CREATE TABLE `player` (
  `player_Id` int(11) NOT NULL,
  `firstname` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `lastname` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(270) COLLATE utf8_unicode_ci NOT NULL,
  `hash` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `active` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `player`
--

INSERT INTO `player` (`player_Id`, `firstname`, `lastname`, `email`, `password`, `hash`, `active`) VALUES
(1, 'Karl', 'Jucutan', 'Karl@facebook.com', '', '', 'yes'),
(2, 'qwe', 'qwe', 'qwe@gmail.com', '$2y$10$Mxy3yRAn0RN4uiLdJT9It.JU00pOG1rUNqSb1SvXkMwT/iTjPXXXO', '371bce7dc83817b7893bcdeed13799b5', 'no'),
(3, 'Kealu', 'Rullamas', 'Kealu@facebook.com', '', '', 'yes'),
(4, 'kealu', 'ruls', 'kkk@yahoo.com', '$2y$10$AMdUPXSqtQ.Gjhz7V672Q.REPKVi8YMIlmEk5.3.kLiMvd1KheWee', '430c3626b879b4005d41b8a46172e0c0', 'no');

-- --------------------------------------------------------

--
-- Table structure for table `player_badge`
--

CREATE TABLE `player_badge` (
  `player_id` varchar(50) NOT NULL,
  `badge` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `player_badge`
--

INSERT INTO `player_badge` (`player_id`, `badge`) VALUES
('1', 'Nitro'),
('3', 'Salt');

-- --------------------------------------------------------

--
-- Table structure for table `player_game`
--

CREATE TABLE `player_game` (
  `player_id` varchar(50) NOT NULL,
  `team_id` int(11) NOT NULL,
  `player_points` int(11) NOT NULL,
  `player_state` varchar(50) NOT NULL,
  `helps_made` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `player_game`
--

INSERT INTO `player_game` (`player_id`, `team_id`, `player_points`, `player_state`, `helps_made`) VALUES
('1', 113, 106, 'returning', 1),
('3', 114, 28, 'returning', 1);

-- --------------------------------------------------------

--
-- Table structure for table `player_preset`
--

CREATE TABLE `player_preset` (
  `player_id` varchar(50) NOT NULL,
  `body_preset` int(11) NOT NULL,
  `hair_preset` int(11) NOT NULL,
  `eyebrows_preset` int(11) NOT NULL,
  `eyes_preset` int(11) NOT NULL,
  `nose_preset` int(11) NOT NULL,
  `mouth_preset` int(11) NOT NULL,
  `gender` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `player_preset`
--

INSERT INTO `player_preset` (`player_id`, `body_preset`, `hair_preset`, `eyebrows_preset`, `eyes_preset`, `nose_preset`, `mouth_preset`, `gender`) VALUES
('1', 1, 0, 0, 0, 0, 0, 'female'),
('3', 0, 0, 0, 0, 0, 0, 'male');

-- --------------------------------------------------------

--
-- Table structure for table `score`
--

CREATE TABLE `score` (
  `teamid` int(50) NOT NULL,
  `cityid` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `score`
--

INSERT INTO `score` (`teamid`, `cityid`) VALUES
(113, 10),
(113, 13);

-- --------------------------------------------------------

--
-- Table structure for table `sector_score`
--

CREATE TABLE `sector_score` (
  `sector_id` int(11) NOT NULL,
  `player_id` varchar(50) NOT NULL,
  `player_score` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sector_score`
--

INSERT INTO `sector_score` (`sector_id`, `player_id`, `player_score`) VALUES
(1, '', 0),
(2, '1', 5),
(3, '', 0),
(4, '', 0),
(5, '', 0),
(6, '', 0),
(7, '1', 2),
(8, '', 0),
(9, '', 0),
(10, '1', 1),
(11, '', 0),
(12, '', 0),
(13, '', 0),
(14, '', 0),
(15, '1', 2),
(16, '', 0),
(17, '', 0),
(18, '1', 4),
(19, '', 0),
(20, '', 0),
(21, '', 0),
(22, '', 0),
(23, '', 0),
(24, '', 0),
(25, '', 0),
(26, '', 0),
(27, '', 0),
(28, '', 0),
(29, '', 0),
(30, '', 0),
(31, '', 0),
(32, '', 0),
(33, '1', 4),
(34, '', 0),
(35, '', 0),
(36, '1', 2),
(37, '', 0),
(38, '', 0),
(39, '', 0),
(40, '', 0),
(41, '', 0),
(42, '', 0),
(43, '', 0),
(44, '', 0),
(45, '', 0),
(46, '', 0),
(47, '', 0),
(48, '', 0),
(49, '', 0),
(50, '', 0),
(51, '1', 12),
(52, '', 0),
(53, '', 0),
(54, '1', 1),
(55, '', 0),
(56, '', 0),
(57, '', 0),
(58, '', 0),
(59, '', 0),
(60, '', 0),
(61, '', 0),
(62, '', 0),
(63, '', 0),
(64, '', 0),
(65, '', 0),
(66, '', 0),
(67, '', 0),
(68, '', 0),
(69, '', 0),
(70, '', 0),
(71, '', 0),
(72, '', 0),
(73, '', 0),
(74, '', 0),
(75, '', 0),
(76, '', 0),
(77, '', 0),
(78, '', 0),
(79, '', 0),
(80, '', 0),
(81, '', 0),
(82, '', 0),
(83, '1', 20),
(84, '3', 10),
(85, '3', 4),
(86, '1', 2),
(87, '', 0),
(88, '', 0),
(89, '', 0),
(90, '', 0),
(91, '', 0),
(92, '', 0),
(93, '', 0),
(94, '', 0),
(95, '', 0),
(96, '', 0),
(97, '', 0),
(98, '', 0),
(99, '', 0),
(100, '', 0),
(101, '', 0),
(102, '', 0),
(103, '', 0),
(104, '', 0),
(105, '', 0),
(106, '', 0),
(107, '', 0),
(108, '', 0),
(109, '', 0),
(110, '', 0),
(111, '', 0),
(112, '', 0),
(113, '', 0),
(114, '', 0),
(115, '', 0),
(116, '', 0),
(117, '', 0),
(118, '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `team`
--

CREATE TABLE `team` (
  `team_id` int(11) NOT NULL,
  `team_name` varchar(11) COLLATE utf8_unicode_ci NOT NULL,
  `team_colorID` int(11) NOT NULL,
  `team_leader` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `team`
--

INSERT INTO `team` (`team_id`, `team_name`, `team_colorID`, `team_leader`) VALUES
(113, 'zxc', 2, 1),
(114, 'asd', 1, 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `player`
--
ALTER TABLE `player`
  ADD PRIMARY KEY (`player_Id`);

--
-- Indexes for table `player_badge`
--
ALTER TABLE `player_badge`
  ADD PRIMARY KEY (`player_id`,`badge`);

--
-- Indexes for table `player_game`
--
ALTER TABLE `player_game`
  ADD PRIMARY KEY (`player_id`,`team_id`);

--
-- Indexes for table `player_preset`
--
ALTER TABLE `player_preset`
  ADD PRIMARY KEY (`player_id`);

--
-- Indexes for table `score`
--
ALTER TABLE `score`
  ADD PRIMARY KEY (`teamid`,`cityid`);

--
-- Indexes for table `sector_score`
--
ALTER TABLE `sector_score`
  ADD PRIMARY KEY (`sector_id`,`player_id`);

--
-- Indexes for table `team`
--
ALTER TABLE `team`
  ADD PRIMARY KEY (`team_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `player`
--
ALTER TABLE `player`
  MODIFY `player_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `team`
--
ALTER TABLE `team`
  MODIFY `team_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=115;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
