-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  Dim 14 juil. 2019 à 09:28
-- Version du serveur :  5.7.23
-- Version de PHP :  5.6.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `agerforsoft`
--

-- --------------------------------------------------------

--
-- Structure de la table `acteprogramme`
--

DROP TABLE IF EXISTS `acteprogramme`;
CREATE TABLE IF NOT EXISTS `acteprogramme` (
  `NumActe` varchar(50) NOT NULL,
  `DateActe` varchar(50) NOT NULL,
  `DateEnrgActe` varchar(50) NOT NULL,
  `DatePubliActe` varchar(50) NOT NULL,
  `Conservation` varchar(50) NOT NULL,
  `FraisEnrg` decimal(50,2) DEFAULT NULL,
  `RefProgramme` varchar(50) NOT NULL,
  `NomProjet` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `acteprojet`
--

DROP TABLE IF EXISTS `acteprojet`;
CREATE TABLE IF NOT EXISTS `acteprojet` (
  `NumActe` int(11) NOT NULL AUTO_INCREMENT,
  `DatePubliActe` date NOT NULL,
  `Volume` varchar(50) NOT NULL,
  `RefPubli` varchar(50) NOT NULL,
  `FraisPubli` decimal(50,2) NOT NULL,
  `Pos` varchar(50) NOT NULL,
  `Conservation` varchar(50) NOT NULL,
  `RefProjet` int(255) NOT NULL,
  PRIMARY KEY (`NumActe`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `acteprojet`
--

INSERT INTO `acteprojet` (`NumActe`, `DatePubliActe`, `Volume`, `RefPubli`, `FraisPubli`, `Pos`, `Conservation`, `RefProjet`) VALUES
(1, '1995-03-08', '88', '55', '544917.80', '', '', 1);

-- --------------------------------------------------------

--
-- Structure de la table `attribution`
--

DROP TABLE IF EXISTS `attribution`;
CREATE TABLE IF NOT EXISTS `attribution` (
  `NumA` int(255) NOT NULL AUTO_INCREMENT,
  `DateAttribution` date NOT NULL,
  `NumClient` varchar(50) NOT NULL,
  `NumProjet` varchar(50) NOT NULL,
  `NumProgramme` varchar(50) NOT NULL,
  `NatureProgramme` varchar(50) NOT NULL,
  `TypeBien` varchar(50) NOT NULL,
  `NumIlot` varchar(50) NOT NULL,
  `Numlot` varchar(50) NOT NULL,
  `NumBloc` varchar(50) NOT NULL,
  `IdBien` int(255) NOT NULL,
  `DateDLE` date DEFAULT NULL,
  `DateDLR` date DEFAULT NULL,
  `RefDL` varchar(50) NOT NULL,
  PRIMARY KEY (`NumA`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `attribution`
--

INSERT INTO `attribution` (`NumA`, `DateAttribution`, `NumClient`, `NumProjet`, `NumProgramme`, `NatureProgramme`, `TypeBien`, `NumIlot`, `Numlot`, `NumBloc`, `IdBien`, `DateDLE`, `DateDLR`, `RefDL`) VALUES
(1, '2019-06-23', '83', '1', '2', 'Logement', 'Logement', '1', '16', '8', 132, '2014-01-27', '2014-01-27', '072/SEC/DLEP/2014'),
(2, '2019-06-24', '107', '1', '2', 'Logement', 'Logement', '1', '13', '8', 129, '2014-02-23', '2014-02-23', '887/SEC/DL/2014'),
(3, '2019-06-24', '84', '1', '2', 'Logement', 'Logement', '1', '19', '8', 135, '2014-01-27', '2014-01-27', '72/SEC/DLEP/2014');

-- --------------------------------------------------------

--
-- Structure de la table `bdd`
--

DROP TABLE IF EXISTS `bdd`;
CREATE TABLE IF NOT EXISTS `bdd` (
  `Server` varchar(15) NOT NULL,
  `BDDName` varchar(50) NOT NULL,
  `Port` varchar(50) NOT NULL,
  `User` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `biens`
--

DROP TABLE IF EXISTS `biens`;
CREATE TABLE IF NOT EXISTS `biens` (
  `Id` int(255) NOT NULL AUTO_INCREMENT,
  `RefProgramme` int(255) NOT NULL,
  `RefProjet` int(255) NOT NULL,
  `NumEdd` int(255) NOT NULL,
  `NumIlot` varchar(50) NOT NULL,
  `TypeBien` varchar(50) NOT NULL,
  `Numlot` varchar(50) NOT NULL,
  `NumBloc` varchar(50) NOT NULL,
  `Niveau` varchar(50) NOT NULL,
  `NbrPiece` varchar(50) NOT NULL,
  `SurH` decimal(50,2) DEFAULT NULL,
  `SurU` decimal(50,2) DEFAULT NULL,
  `PrixHT` decimal(50,2) DEFAULT NULL,
  `Tva` int(2) DEFAULT NULL,
  `PrixTTC` decimal(50,2) DEFAULT NULL,
  `LimiteNord` varchar(50) NOT NULL,
  `LimiteSud` varchar(50) NOT NULL,
  `LimiteEst` varchar(50) NOT NULL,
  `LimiteOuest` varchar(50) NOT NULL,
  `Etat` varchar(50) NOT NULL,
  `TypeVente` varchar(50) NOT NULL,
  PRIMARY KEY (`NumEdd`,`Numlot`,`NumBloc`,`Niveau`),
  UNIQUE KEY `UNIQUE` (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=141 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `biens`
--

INSERT INTO `biens` (`Id`, `RefProgramme`, `RefProjet`, `NumEdd`, `NumIlot`, `TypeBien`, `Numlot`, `NumBloc`, `Niveau`, `NbrPiece`, `SurH`, `SurU`, `PrixHT`, `Tva`, `PrixTTC`, `LimiteNord`, `LimiteSud`, `LimiteEst`, `LimiteOuest`, `Etat`, `TypeVente`) VALUES
(1, 2, 1, 2, '1', 'Logement', '1', '1', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Réservé', 'Vente Libre'),
(2, 2, 1, 2, '1', 'Logement', '2', '1', '0', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Réservé', 'Vente Libre'),
(3, 2, 1, 2, '1', 'Logement', '3', '1', '0', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre', 'Vente Libre'),
(4, 2, 1, 2, '1', 'Logement', '4', '1', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(5, 2, 1, 2, '1', 'Logement', '5', '1', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Réservé', 'Vente Libre'),
(6, 2, 1, 2, '1', 'Logement', '6', '1', '1', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre', 'Vente Libre'),
(7, 2, 1, 2, '1', 'Logement', '7', '1', '1', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre', 'Vente Libre'),
(8, 2, 1, 2, '1', 'Logement', '8', '1', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(9, 2, 1, 2, '1', 'Logement', '9', '1', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(10, 2, 1, 2, '1', 'Logement', '10', '1', '2', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre', 'Vente Libre'),
(11, 2, 1, 2, '1', 'Logement', '11', '1', '2', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre', 'Vente Libre'),
(12, 2, 1, 2, '1', 'Logement', '12', '1', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(13, 2, 1, 2, '1', 'Logement', '13', '1', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(14, 2, 1, 2, '1', 'Logement', '14', '1', '3', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre', 'Vente Libre'),
(15, 2, 1, 2, '1', 'Logement', '15', '1', '3', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre', 'Vente Libre'),
(16, 2, 1, 2, '1', 'Logement', '16', '1', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(17, 2, 1, 2, '1', 'Logement', '17', '1', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(18, 2, 1, 2, '1', 'Logement', '18', '1', '4', 'F3', '70.82', '75.43', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(19, 2, 1, 2, '1', 'Logement', '19', '1', '4', 'F3', '71.82', '81.05', '37383.18', 7, '3140622.71', '', '', '', '', 'Libre', 'Vente Libre'),
(20, 2, 1, 2, '1', 'Logement', '20', '1', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(21, 2, 1, 2, '1', 'Logement', '21', '1', '5', 'F3', '71.27', '81.79', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(22, 2, 1, 2, '1', 'Logement', '22', '1', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(23, 2, 1, 2, '1', 'Logement', '23', '1', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(24, 2, 1, 2, '1', 'Logement', '24', '1', '5', 'F3', '71.22', '81.74', '37383.18', 7, '3114385.26', '', '', '', '', 'Libre', 'Vente Libre'),
(25, 2, 1, 2, '1', 'Logement', '1', '2', '0', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(26, 2, 1, 2, '1', 'Logement', '2', '2', '0', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(27, 2, 1, 2, '1', 'Logement', '3', '2', '1', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(28, 2, 1, 2, '1', 'Logement', '4', '2', '1', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(29, 2, 1, 2, '1', 'Logement', '5', '2', '2', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(30, 2, 1, 2, '1', 'Logement', '6', '2', '2', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(31, 2, 1, 2, '1', 'Logement', '7', '2', '3', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(32, 2, 1, 2, '1', 'Logement', '8', '2', '3', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(33, 2, 1, 2, '1', 'Logement', '9', '2', '4', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(34, 2, 1, 2, '1', 'Logement', '10', '2', '4', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(35, 2, 1, 2, '1', 'Logement', '11', '2', '5', 'F3', '71.78', '79.58', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(36, 2, 1, 2, '1', 'Logement', '12', '2', '5', 'F3', '71.78', '79.58', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(37, 2, 1, 2, '1', 'Logement', '1', '3', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(38, 2, 1, 2, '1', 'Logement', '2', '3', '0', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre', 'Vente Libre'),
(39, 2, 1, 2, '1', 'Logement', '3', '3', '0', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre', 'Vente Libre'),
(40, 2, 1, 2, '1', 'Logement', '4', '3', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(41, 2, 1, 2, '1', 'Logement', '5', '3', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(42, 2, 1, 2, '1', 'Logement', '6', '3', '1', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre', 'Vente Libre'),
(43, 2, 1, 2, '1', 'Logement', '7', '3', '1', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre', 'Vente Libre'),
(44, 2, 1, 2, '1', 'Logement', '8', '3', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(45, 2, 1, 2, '1', 'Logement', '9', '3', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(46, 2, 1, 2, '1', 'Logement', '10', '3', '2', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre', 'Vente Libre'),
(47, 2, 1, 2, '1', 'Logement', '11', '3', '2', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre', 'Vente Libre'),
(48, 2, 1, 2, '1', 'Logement', '12', '3', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(49, 2, 1, 2, '1', 'Logement', '13', '3', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(50, 2, 1, 2, '1', 'Logement', '14', '3', '3', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre', 'Vente Libre'),
(51, 2, 1, 2, '1', 'Logement', '15', '3', '3', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre', 'Vente Libre'),
(52, 2, 1, 2, '1', 'Logement', '16', '3', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(53, 2, 1, 2, '1', 'Logement', '17', '3', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(54, 2, 1, 2, '1', 'Logement', '18', '3', '4', 'F3', '71.82', '81.05', '37383.18', 7, '3140622.71', '', '', '', '', 'Libre', 'Vente Libre'),
(55, 2, 1, 2, '1', 'Logement', '19', '3', '4', 'F3', '70.82', '75.43', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(56, 2, 1, 2, '1', 'Logement', '20', '3', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(57, 2, 1, 2, '1', 'Logement', '21', '3', '5', 'F3', '71.22', '81.74', '37383.18', 7, '3114385.26', '', '', '', '', 'Libre', 'Vente Libre'),
(58, 2, 1, 2, '1', 'Logement', '22', '3', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(59, 2, 1, 2, '1', 'Logement', '23', '3', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(60, 2, 1, 2, '1', 'Logement', '24', '3', '5', 'F3', '71.27', '81.79', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(61, 2, 1, 2, '1', 'Logement', '5', '5', '1', 'F3', '70.76', '75.53', '37383.18', 7, '3094269.88', '', '', '', '', '', 'Vente Libre'),
(62, 2, 1, 2, '1', 'Logement', '6', '5', '1', 'F3', '71.41', '73.71', '37383.18', 7, '3122693.79', '', '', '', '', '', 'Vente Libre'),
(63, 2, 1, 2, '1', 'Logement', '7', '5', '1', 'F3', '70.44', '72.77', '37383.18', 7, '3080276.58', '', '', '', '', '', 'Vente Libre'),
(64, 2, 1, 2, '1', 'Logement', '8', '5', '1', 'F3', '70.78', '75.55', '37383.18', 7, '3095144.47', '', '', '', '', 'Libre', 'Vente Libre'),
(65, 2, 1, 2, '1', 'Logement', '9', '5', '2', 'F3', '70.99', '78.07', '37383.18', 7, '3104327.57', '', '', '', '', 'Libre', 'Vente Libre'),
(66, 2, 1, 2, '1', 'Logement', '10', '5', '2', 'F3', '71.56', '76.20', '37383.18', 7, '3129253.15', '', '', '', '', 'Libre', 'Vente Libre'),
(67, 2, 1, 2, '1', 'Logement', '11', '5', '2', 'F3', '70.62', '75.23', '37383.18', 7, '3088147.81', '', '', '', '', 'Libre', 'Vente Libre'),
(68, 2, 1, 2, '1', 'Logement', '12', '5', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(69, 2, 1, 2, '1', 'Logement', '13', '5', '3', 'F3', '70.99', '78.07', '37383.18', 7, '3104327.57', '', '', '', '', 'Libre', 'Vente Libre'),
(70, 2, 1, 2, '1', 'Logement', '14', '5', '3', 'F3', '71.56', '76.20', '37383.18', 7, '3129253.15', '', '', '', '', 'Libre', 'Vente Libre'),
(71, 2, 1, 2, '1', 'Logement', '15', '5', '3', 'F3', '70.62', '75.23', '37383.18', 7, '3088147.81', '', '', '', '', 'Libre', 'Vente Libre'),
(72, 2, 1, 2, '1', 'Logement', '16', '5', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(73, 2, 1, 2, '1', 'Logement', '17', '5', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(74, 2, 1, 2, '1', 'Logement', '18', '5', '4', 'F3', '71.82', '78.74', '37383.18', 7, '3140622.71', '', '', '', '', 'Libre', 'Vente Libre'),
(75, 2, 1, 2, '1', 'Logement', '19', '5', '4', 'F3', '70.82', '75.43', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(76, 2, 1, 2, '1', 'Logement', '20', '5', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(77, 2, 1, 2, '1', 'Logement', '21', '5', '5', 'F3', '71.41', '81.93', '37383.18', 7, '3122693.79', '', '', '', '', 'Libre', 'Vente Libre'),
(78, 2, 1, 2, '1', 'Logement', '22', '5', '5', 'F3', '71.83', '78.86', '37383.18', 7, '3141060.00', '', '', '', '', 'Libre', 'Vente Libre'),
(79, 2, 1, 2, '1', 'Logement', '23', '5', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(80, 2, 1, 2, '1', 'Logement', '24', '5', '5', 'F3', '71.29', '81.81', '37383.18', 7, '3117446.30', '', '', '', '', 'Libre', 'Vente Libre'),
(81, 2, 1, 2, '1', 'Logement', '1', '6', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(82, 2, 1, 2, '1', 'Logement', '2', '6', '0', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre', 'Vente Libre'),
(83, 2, 1, 2, '1', 'Logement', '3', '6', '0', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre', 'Vente Libre'),
(84, 2, 1, 2, '1', 'Logement', '4', '6', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(85, 2, 1, 2, '1', 'Logement', '5', '6', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(86, 2, 1, 2, '1', 'Logement', '6', '6', '1', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre', 'Vente Libre'),
(87, 2, 1, 2, '1', 'Logement', '7', '6', '1', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre', 'Vente Libre'),
(88, 2, 1, 2, '1', 'Logement', '8', '6', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(89, 2, 1, 2, '1', 'Logement', '9', '6', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(90, 2, 1, 2, '1', 'Logement', '10', '6', '2', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre', 'Vente Libre'),
(91, 2, 1, 2, '1', 'Logement', '11', '6', '2', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre', 'Vente Libre'),
(92, 2, 1, 2, '1', 'Logement', '12', '6', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(93, 2, 1, 2, '1', 'Logement', '13', '6', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(94, 2, 1, 2, '1', 'Logement', '14', '6', '3', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre', 'Vente Libre'),
(95, 2, 1, 2, '1', 'Logement', '15', '6', '3', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre', 'Vente Libre'),
(96, 2, 1, 2, '1', 'Logement', '16', '6', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(97, 2, 1, 2, '1', 'Logement', '17', '6', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(98, 2, 1, 2, '1', 'Logement', '18', '6', '4', 'F3', '70.82', '75.43', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(99, 2, 1, 2, '1', 'Logement', '19', '6', '4', 'F3', '71.82', '81.05', '37383.18', 7, '3140622.71', '', '', '', '', 'Libre', 'Vente Libre'),
(100, 2, 1, 2, '1', 'Logement', '20', '6', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(101, 2, 1, 2, '1', 'Logement', '21', '6', '5', 'F3', '71.27', '81.79', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(102, 2, 1, 2, '1', 'Logement', '22', '6', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(103, 2, 1, 2, '1', 'Logement', '23', '6', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(104, 2, 1, 2, '1', 'Logement', '24', '6', '5', 'F3', '71.22', '81.74', '37383.18', 7, '3114385.26', '', '', '', '', 'Libre', 'Vente Libre'),
(105, 2, 1, 2, '1', 'Logement', '1', '7', '0', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(106, 2, 1, 2, '1', 'Logement', '2', '7', '0', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(107, 2, 1, 2, '1', 'Logement', '3', '7', '1', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(108, 2, 1, 2, '1', 'Logement', '4', '7', '1', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(109, 2, 1, 2, '1', 'Logement', '5', '7', '2', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(110, 2, 1, 2, '1', 'Logement', '6', '7', '2', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(111, 2, 1, 2, '1', 'Logement', '7', '7', '3', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(112, 2, 1, 2, '1', 'Logement', '8', '7', '3', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(113, 2, 1, 2, '1', 'Logement', '9', '7', '4', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(114, 2, 1, 2, '1', 'Logement', '10', '7', '4', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(115, 2, 1, 2, '1', 'Logement', '11', '7', '5', 'F3', '71.78', '79.58', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(116, 2, 1, 2, '1', 'Logement', '12', '7', '5', 'F3', '71.78', '79.58', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre', 'Vente Libre'),
(117, 2, 1, 2, '1', 'Logement', '1', '8', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(118, 2, 1, 2, '1', 'Logement', '2', '8', '0', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre', 'Vente Libre'),
(119, 2, 1, 2, '1', 'Logement', '3', '8', '0', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre', 'Vente Libre'),
(120, 2, 1, 2, '1', 'Logement', '4', '8', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(121, 2, 1, 2, '1', 'Logement', '5', '8', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(122, 2, 1, 2, '1', 'Logement', '6', '8', '1', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre', 'Vente Libre'),
(123, 2, 1, 2, '1', 'Logement', '7', '8', '1', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre', 'Vente Libre'),
(124, 2, 1, 2, '1', 'Logement', '8', '8', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre', 'Vente Libre'),
(125, 2, 1, 2, '1', 'Logement', '9', '8', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(126, 2, 1, 2, '1', 'Logement', '10', '8', '2', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre', 'Vente Libre'),
(127, 2, 1, 2, '1', 'Logement', '11', '8', '2', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre', 'Vente Libre'),
(128, 2, 1, 2, '1', 'Logement', '12', '8', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre', 'Vente Libre'),
(129, 2, 1, 2, '1', 'Logement', '13', '8', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Réservé', 'Vente Libre'),
(130, 2, 1, 2, '1', 'Logement', '14', '8', '3', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre', 'Vente Libre'),
(131, 2, 1, 2, '1', 'Logement', '15', '8', '3', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre', 'Vente Libre'),
(132, 2, 1, 2, '1', 'Logement', '16', '8', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Réservé', 'Vente Libre'),
(133, 2, 1, 2, '1', 'Logement', '17', '8', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(134, 2, 1, 2, '1', 'Logement', '18', '8', '4', 'F3', '71.82', '75.43', '37383.18', 7, '3140622.71', '', '', '', '', 'Libre', 'Vente Libre'),
(135, 2, 1, 2, '1', 'Logement', '19', '8', '4', 'F3', '70.82', '81.05', '37383.18', 7, '3096893.63', '', '', '', '', 'Réservé', 'Vente Libre'),
(136, 2, 1, 2, '1', 'Logement', '20', '8', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre'),
(137, 2, 1, 2, '1', 'Logement', '21', '8', '5', 'F3', '71.22', '81.74', '37383.18', 7, '3114385.26', '', '', '', '', 'Libre', 'Vente Libre'),
(138, 2, 1, 2, '1', 'Logement', '22', '8', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(139, 2, 1, 2, '1', 'Logement', '23', '8', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre', 'Vente Libre'),
(140, 2, 1, 2, '1', 'Logement', '24', '8', '5', 'F3', '71.27', '81.79', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre', 'Vente Libre');

-- --------------------------------------------------------

--
-- Structure de la table `cahierchargeprogramme`
--

DROP TABLE IF EXISTS `cahierchargeprogramme`;
CREATE TABLE IF NOT EXISTS `cahierchargeprogramme` (
  `NomProjet` varchar(50) NOT NULL,
  `RefProgramme` varchar(50) NOT NULL,
  `NumCahierCharge` varchar(50) NOT NULL,
  `DateEnre` varchar(50) NOT NULL,
  `Volume` varchar(50) NOT NULL,
  `NumPubli` varchar(50) NOT NULL,
  `DatePubli` varchar(50) NOT NULL,
  `Conservation` varchar(50) NOT NULL,
  `Notaire` varchar(50) NOT NULL,
  `TelNotaire` varchar(50) NOT NULL,
  `AdresseNotaire` varchar(50) NOT NULL,
  `SuperficieCessible` decimal(50,2) NOT NULL,
  `SuperficieVoirie` decimal(50,2) NOT NULL,
  `SuperficieEv` decimal(50,2) NOT NULL,
  `SuperficieEq` decimal(50,2) NOT NULL,
  `AutreSuperficie` decimal(50,2) NOT NULL,
  `NomPreomGeo` varchar(50) NOT NULL,
  `AdresseGeo` varchar(50) NOT NULL,
  `TelGeo` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `NumClient` int(255) NOT NULL AUTO_INCREMENT,
  `DateCreation` date DEFAULT NULL,
  `StatutClient` text,
  `Nom` varchar(50) DEFAULT NULL,
  `Prenom` varchar(50) DEFAULT NULL,
  `NomAr` varchar(50) DEFAULT NULL,
  `PrenomAr` varchar(50) DEFAULT NULL,
  `Sexe` varchar(50) DEFAULT NULL,
  `DateNaissance` varchar(50) DEFAULT NULL,
  `LieuNaissance` varchar(50) DEFAULT NULL,
  `PrenomPere` varchar(50) DEFAULT NULL,
  `PrenomPereAr` varchar(50) DEFAULT NULL,
  `NomMere` varchar(50) DEFAULT NULL,
  `PrenomMere` varchar(50) DEFAULT NULL,
  `NomMereAr` varchar(50) DEFAULT NULL,
  `PrenomMereAr` varchar(50) DEFAULT NULL,
  `Cni` varchar(20) DEFAULT NULL,
  `DateCni` date DEFAULT NULL,
  `LieuCni` varchar(50) DEFAULT NULL,
  `Ville` varchar(50) DEFAULT NULL,
  `Adress` varchar(2000) DEFAULT NULL,
  `Proffession` varchar(50) DEFAULT NULL,
  `Tel` varchar(15) DEFAULT NULL,
  `NomContact` varchar(50) DEFAULT NULL,
  `TelContact` varchar(50) DEFAULT NULL,
  `Situation` varchar(50) NOT NULL,
  `NomConj` varchar(50) DEFAULT NULL,
  `PrénomConj` varchar(50) DEFAULT NULL,
  `NomConjAR` varchar(50) DEFAULT NULL,
  `PrenomConjAR` varchar(50) DEFAULT NULL,
  `DateNaissanceConj` varchar(50) DEFAULT NULL,
  `LieuNaissanceConj` varchar(50) DEFAULT NULL,
  `ProfessionConj` varchar(50) DEFAULT NULL,
  `NumDeliberation` text,
  `DateDeliberation` date DEFAULT NULL,
  PRIMARY KEY (`NumClient`)
) ENGINE=MyISAM AUTO_INCREMENT=108 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`NumClient`, `DateCreation`, `StatutClient`, `Nom`, `Prenom`, `NomAr`, `PrenomAr`, `Sexe`, `DateNaissance`, `LieuNaissance`, `PrenomPere`, `PrenomPereAr`, `NomMere`, `PrenomMere`, `NomMereAr`, `PrenomMereAr`, `Cni`, `DateCni`, `LieuCni`, `Ville`, `Adress`, `Proffession`, `Tel`, `NomContact`, `TelContact`, `Situation`, `NomConj`, `PrénomConj`, `NomConjAR`, `PrenomConjAR`, `DateNaissanceConj`, `LieuNaissanceConj`, `ProfessionConj`, `NumDeliberation`, `DateDeliberation`) VALUES
(1, '2019-05-20', 'Contentieux', 'BOUCHENA ', 'LAHOUARIA ', 'بوشنة ', 'الهوارية ', 'Femme', '1974-09-02', 'ORAN', 'LAKHDER', 'لخضر ', 'BELMAHI ', 'KHIERA ', 'بلماحي ', 'خيرة', '923565', '2009-05-26', 'ORAN', 'ORAN', 'CITE HOUARI BOUMRDIENE /OUED TELILET ORAN ', 'AGENT DE CHARCUTERIE ²²²²', '-', '-', '-', 'Marié(e)', 'oueld zahra ', 'mokhtar ', 'ولد زهرة ', 'mokhtar ', '17/12/1982', 'ORAN', '-', NULL, NULL),
(2, '2019-05-20', 'Client normal', 'BELACHHEB ', 'SID AHMED ', 'بلشهب', 'سيد أحمد ', 'Homme', '1978-09-01', 'ORAN', 'ABDELKADER', 'عبد القادر', 'OUALI MHADJI ', 'KHIERA', 'والي مهاجي', 'خيرة ', '720365', '2008-07-16', 'ORAN', 'ORAN', 'CITE HAMOU BOUTLILIS / OUED TLILET', 'AGENT POLYVALENT', '-', '-', '-', 'Marié(e)', 'HOCINI', 'SAMIRA', 'حسيني ', 'SAMIRA', '21/10/1979', 'ORAN', '-', NULL, NULL),
(3, '2019-05-20', 'Client normal', 'BELGHAZALI', 'MOHAMED', 'بلغزالي', 'محمد', 'Femme', '1973-02-08', 'ORAN', 'GHERISSI', 'غريسي ', 'RAHIL', 'HORRA', 'رحيل', 'حرة ', '859257', '2009-08-05', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF OUED TLELAT', 'PES', '-', '-', '-', 'Marié(e)', 'BENAMAR', 'HALIMA', 'بن عمر', 'HALIMA', '23/12/1988', 'ORAN', '-', NULL, NULL),
(4, '2019-05-20', 'Client normal', 'DIDA', 'NOURREDINE', 'مية مفتاح', 'فاطمة ', 'Homme', '1962-01-03', 'ORAN', 'MOHAMED', 'بن عودة ', 'RAZINE', 'MERIEM', 'بوشنتوف ادريس', 'عتيقة ', '745154', '2005-03-29', 'ORAN', 'ORAN', 'CITE 71  LOG N°39 OUED TLELAT', 'AGENT POLYVALENT', '-', '-', '-', 'Marié(e)', 'KRACHE', 'NAIMA', 'كرشاش ', 'NAIMA', '21/10/1972', 'ORAN', '-', NULL, NULL),
(5, '2019-05-20', 'Client normal', 'MEHALI', 'HAFIDA', 'محلي', 'حفيظة ', 'Femme', '1971-07-24', 'ORAN', 'HABIB', 'حبيب ', 'LARAICHI ', 'MALIKA', 'لعراشي', 'مليكة ', '176667', '2007-04-23', 'ORAN', 'ORAN', 'RUE GRINE ABDELKADER OUED TLILET', 'PROF', '-', '-', '-', 'Marié(e)', 'MEHALLI', 'OMAR', 'محلي', 'OMAR', '09/09/1962', 'ORAN', '-', NULL, NULL),
(11, '2019-05-21', 'Client normal', 'HIRECH BAGHDAD', 'ALI', 'حيرش', 'علي', 'Homme', '1978-02-05', 'ORAN', 'MOHAMED', 'محمد', 'ALEM', 'KHIERA', 'عالم', 'خيرة', '129787', '2006-10-22', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF OUED TLELAT', 'AGENT INTERVENTION N1', '-', '-', '-', 'Marié(e)', 'DAHRAOUI', 'SOUAD', 'ظهراوي', 'SOUAD', '21/07/1981', 'ORAN', '-', NULL, NULL),
(6, '2019-05-20', 'Client normal', 'CHRAYETTE', 'KAMEL', 'شريط', 'كمال', 'Femme', '1980-10-02', 'ORAN', 'BACHIR', 'بن عودة ', 'YOUCEF BENKHEDA', 'ZOHRA', 'بوشنتوف ادريس', 'عتيقة ', '953704', '2007-01-30', 'ORAN', 'ORAN', 'RUE BERFAS DJILALI /OUED TLILET', 'SUPERVISEUR HSE ', '-', '-', '-', 'Marié(e)', 'BOUBEKEUR', 'ASMA', 'بوبكر', 'ASMA', '12/09/1982', 'ORAN', '-', NULL, NULL),
(7, '2019-05-20', 'Client normal', 'MIA MEFTAH', 'FATIMA', 'مية مفتاح', 'فاطمة ', 'Femme', '1986-03-30', 'ORAN', 'BENAOUDA ', 'بن عودة ', 'BOUCHENTOUF IDRIS ', 'ATIKA ', 'بوشنتوف ادريس', 'عتيقة ', '510416', '2011-05-22', 'ORAN', 'ORAN', 'DOUAR MFATHIA', 'AGENT POLYVALENT', '-', '-', '-', 'Marié(e)', 'CHELIH', 'Sofiane', 'شليح', 'Sofiane', '17/12/1982', 'ORAN', 'electricien auto', NULL, NULL),
(8, '2019-05-20', 'Client normal', 'BOUMAIZA ', 'MASSINISSA', 'بومعيزة ', 'مسينيسة ', 'Homme', '1986-01-01', 'ORAN', 'HAMID ', 'حميد ', 'KHELIFA ', 'SABIHA ', 'خليفة ', 'صبيحة ', '860050', '2009-02-24', 'ORAN', 'ORAN', 'TAMDA WAFNOUN TIZIOUZO', '-', '-', '-', '-', 'Marié(e)', 'BEGGA ', 'SARAH ', 'بقة ', 'SARAH ', '01/01/1989', 'ORAN', '-', NULL, NULL),
(9, '2019-05-20', 'Client normal', 'berrouda ', 'Sihem ', 'برودة ', 'سهام ', 'Femme', '1982-12-13', 'ORAN', 'tazi ', 'تازي ', 'benomar ', 'fatima ', 'بن عمر ', 'فاطمة ', '410032', '2007-05-26', 'ORAN', 'ORAN', 'cite mohamed boudiaf oued tlilet', 'ENSEIGNANT', '-', '-', '-', 'Marié(e)', 'hamdani ', 'farid ', 'حمداني ', 'farid ', '06/01/1983', 'ORAN', '-', NULL, NULL),
(10, '2019-05-20', 'Client normal', 'MAHRAZ', 'Ameur ', 'محراز', 'عامر', 'Femme', '1975-11-22', 'ORAN', 'bouadjmi ', 'بوعجمي ', 'lahmar ', 'khadidja ', 'لحمر ', 'خديجة ', '028410', '1975-11-22', 'ORAN', 'ORAN', 'cité mohamed boudiaf oued tlilet oran ', '-', '-', '-', '-', 'Marié(e)', 'bouledjouad ', 'karima', 'بولجواد', 'karima', '21/01/1982', 'ORAN', '-', NULL, NULL),
(12, '2019-05-21', 'Client normal', 'BROUDA ', 'MHAMMED', 'برودة', 'محمد', 'Homme', '1969-05-10', 'ORAN', 'BELKHIER', 'بلخير ', 'KERROUM', 'MAMA ', 'كروم ', 'ماما', '577366', '2013-07-23', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF', '-', '-', '-', '-', 'Marié(e)', 'AICHOUR', 'FATIMA', 'عيشور', 'FATIMA', '09/12/1971', 'ORAN', '-', NULL, NULL),
(13, '2019-05-21', 'Client normal', 'HABCHI HAMADOUCHE', 'NOUR EDDINE', 'حبشي حمادوش ', 'نور الدبن ', 'Homme', '1978-10-14', 'ORAN', 'ABDELKADER ', 'عبد القادر', 'TOLBA', 'MERIEM', 'طلبة ', 'مريم ', '721500', '2008-11-22', 'ORAN', 'ORAN', 'CITE HAMOU BOUTLILIS ', '-', '-', '-', '-', 'Marié(e)', 'FADELA', 'BOUAIT', 'فضيلة', 'BOUAIT', '21/04/1985', 'ORAN', '-', NULL, NULL),
(14, '2019-05-21', 'Client normal', 'LAKEHAL ', 'LAKHDAR', 'لكحل', 'لخضر', 'Homme', '1971-10-12', 'ORAN', 'DAHO', 'دحو ', 'BENAMARA ', 'OUALI', 'بن عمارة ', 'عوالي', '454452', '2007-10-22', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF', 'CORRESPONDANT SOCIAL', '-', '-', '-', 'Marié(e)', 'MEZOUGH', 'KARIMA', 'مزوغ', 'KARIMA', '18/07/2006', 'ORAN', '-', NULL, NULL),
(15, '2019-05-21', 'Client normal', 'OULD CHABANE', 'SLIMANE', 'ولد شعبان ', 'سليمان', 'Homme', '1969-12-07', 'ORAN', 'IZOUAOUI', 'ازواوا ', 'KAHLOUZ ', 'DJIDJIKA', 'قهلوز', 'جيجقة', '074801', '2013-05-29', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'ZEROUKI', 'GHANIA', 'زروقي ', 'GHANIA', '05/09/1980', 'ORAN', '-', NULL, NULL),
(16, '2019-05-21', 'Client normal', 'KABOUIA ', 'ZOULIKHA', 'كابوية', 'زوليخة ', 'Femme', '1957-08-26', 'ORAN', 'ABDERRAHMANE', 'عبد الرحمان', 'RABIA', 'KABOUIA', 'ربيعة ', 'كابوية', '745471', '2005-05-02', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF', 'INFERMIER', '-', '-', '-', 'Divorcé(e)', '', '', '', '', '', '', '', NULL, NULL),
(17, '2019-05-22', 'Client normal', 'KABOUIA', 'Belkhier', 'كابوية', 'بلخير ', 'Homme', '1963-12-22', 'ORAN', 'abderrahmane ', 'عبد  الرحمان', 'kabouia', 'Rabia', 'كابوية', 'ربيعة ', '129848', '2003-09-13', 'ORAN', 'ORAN', 'cite mohamed boudiaf', 'infirmier', '-', '-', '-', 'Marié(e)', 'NACER', 'LATIFA', 'ناصر', 'LATIFA', '18/07/1977', 'ORAN', 'professeur', NULL, NULL),
(18, '2019-05-22', 'Client normal', 'SI ABDRRAHMANE ', 'Mohammed Ameziane ', 'سي عبد الرحمان', 'محمد امزيان ', 'Homme', '1985-10-15', 'ORAN', 'abdelhamid', 'عبد الحميد ', 'si mhand ', 'turkia ', 'سي محند ', 'تركية ', '028392', '1985-10-15', 'ORAN', 'ORAN', 'cité 200 logt oued tlilet ', '-', '-', '-', '-', 'Marié(e)', 'silounis ', 'Amin ', 'سي لونيس ', 'Amin ', '06/10/1989', 'ORAN', '-', NULL, NULL),
(19, '2019-05-22', 'Client normal', 'HIRECHE-BAGHDAD', 'SIHEM ', 'حيرش بغداد', 'سهام ', 'Femme', '1982-01-28', 'ORAN', 'ABED', 'عابد', 'BAGHDAD ZOUGUAR ', 'KHIER ', 'بغداد زوقار ', 'خيرة ', '079056', '1982-01-28', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF ', '-', '-', '-', '-', 'Marié(e)', 'Houari', 'belhamri ', 'هواري', 'belhamri ', '29/05/1978', 'ORAN', '-', NULL, NULL),
(20, '2019-05-22', 'Client normal', 'khali ', 'djamel', 'خالي ', 'جمال ', 'Homme', '1972-07-09', 'ORAN', 'mhamed', 'محمد', 'seghir ', 'stiii ', 'صغير ', 'ستي ', '264878', '2011-03-03', 'ORAN', 'ORAN', 'cité mohamed boudiaf ', 'chauffeur ', '-', '-', '-', 'Marié(e)', 'sabeur ', 'hanen ', 'صابر ', 'hanen ', '13/02/1992', 'ORAN', '-', NULL, NULL),
(21, '2019-05-22', 'Client normal', 'zemalache megueni ', 'boulnouar ', 'زمعلاش مقني ', 'بولنوار ', 'Homme', '1976-12-18', 'ORAN', 'abdelkader ', 'عبد القادر ', 'hadj abess ', 'fadila ', 'حاج عباس ', 'فضيلة ', '859111', '2009-07-22', 'ORAN', 'ORAN', 'cité mohamed boudiaf ', 'PEM', '-', '-', '-', 'Marié(e)', 'bouslah ', 'naziha', 'بوصلاح', 'naziha', '21/10/1978', 'ORAN', 'PEM', NULL, NULL),
(22, '2019-05-22', 'Client normal', 'ahmed benabad ', 'mohammed ', 'احمد بن عابد ', 'محمد', 'Homme', '1977-04-15', 'ORAN', 'LAHOUARI ', 'لهواري', 'RAHIL', 'KHADIDJA ', 'رحيل ', 'خديجة ', '721735', '2008-12-16', 'ORAN', 'ORAN', 'RUE GARINE ABDELKADER', 'AVOCAT', '-', '-', '-', 'Marié(e)', 'LAGAGNA', 'LEILA ', 'لقانية ', 'LEILA ', '26/10/1984', 'ORAN', '-', NULL, NULL),
(23, '2019-05-23', 'Client normal', 'BAFDEL', 'KADOUR', 'بافاضل', 'قدور', 'Homme', '1987-01-17', 'ORAN', 'AHMED', 'أحمد', 'ALEM', 'BAKHTA ', 'عالم', 'بختة ', '446285', '1978-01-17', 'ORAN', 'ORAN', 'OUED TLELAT ORAN', 'AGENT INTERVENTION N1', '-', '-', '-', 'Célibataire', '', '', '', '', '', '', '', NULL, NULL),
(24, '2019-05-23', 'Client normal', 'HABRI ', 'MUSTAPHA', 'هبري', 'مصطفى ', 'Homme', '1979-09-17', 'ORAN', 'ABDELKADER', 'عبد القادر', 'AZZOUZ', 'YAMINA', 'عزوز', 'يمينة ', '522859', '2004-10-30', 'ORAN', 'ORAN', 'RUE REGUIBBA ABDELKADER', 'COMMERCE', '-', '-', '-', 'Célibataire', '', '', '', '', '', '', '', NULL, NULL),
(25, '2019-05-23', 'Client normal', 'ALEM ', 'TAIB ', 'عالم', 'طيب ', 'Homme', '1972-03-10', 'ORAN', 'MOUSTAFA', 'مصطفى ', 'SGHIR ', 'YAMINA', 'صغير ', 'يمينة ', '471580', '2002-07-29', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF', '-', '-', '-', '-', 'Marié(e)', 'BAGHDAD ZGHUAR ', 'KELTOUM', 'بغداد زقار', 'KELTOUM', '01/06/1972', 'ORAN', '-', NULL, NULL),
(26, '2019-05-27', 'Client normal', 'Chafi ', 'sid ahmed', 'شافي ', 'سيد أحمد', 'Homme', '1965-11-15', 'ORAN', 'abdelallah', 'عبد الله ', 'saltani ', 'aicha ', 'صلطني ', 'عائشة ', '514315', '2012-10-24', 'ORAN', 'ORAN', 'ilo 01 N°26 cité dhaya oran ', 'electromecanicien ', '-', '-', '-', 'Marié(e)', 'larem ', 'bensaid', 'لعارم', 'bensaid', '17/02/1977', 'ORAN', '-', NULL, NULL),
(27, '2019-05-27', 'Client normal', 'zerouali', 'adel', 'زروالي', 'عادل ', 'Homme', '1982-09-18', 'ORAN', 'essebti ', 'السبتي', 'zerouali', 'hania', 'زروالي', 'هنية ', '720348', '1982-09-18', 'ORAN', 'ORAN', 'cité 140 logment ', 'avocat ', '-', '-', '-', 'Marié(e)', 'zerrour', 'soumia', 'زرور', 'soumia', '12/12/1984', 'ORAN', 'medecin ', NULL, NULL),
(28, '2019-05-27', 'Client normal', 'BACHEMI MEFTAH', 'Ali ', 'براشمي مفتاح ', 'علي ', 'Homme', '1974-01-20', 'ORAN', 'Abdelkader', 'عبد القادر ', 'HADRI KHOUSSA', 'AICHA', 'حضري خوصة ', 'عائشة ', '938922', '1974-01-20', 'ORAN', 'ORAN', 'CITE mehdia oued tlelat oran ', 'agent ', '-', '-', '-', 'Marié(e)', 'BELGHALLAL ', 'ZOULIKHA', 'بلغلال ', 'ZOULIKHA', '08/03/1977', 'ORAN', 'PROF ', NULL, NULL),
(29, '2019-05-27', 'Client normal', 'HADRI KHOUSSA ', 'Omar', 'حضري خوصة ', 'عمر ', 'Homme', '1975-09-04', 'ORAN', 'belkhier ', 'بلخير ', 'charef afghoul', 'zohra', 'شارف افغول ', 'زهرة ', '23/14/74', '2005-08-13', 'ORAN', 'ORAN', 'cité amir abdelkader / oued tlilet ', '-', '-', '-', '-', 'Marié(e)', 'ezzegai ', 'nacera ', 'الزقاي ', 'nacera ', '03/05/1983', 'ORAN', '-', NULL, NULL),
(30, '2019-05-27', 'Client normal', 'KELLAL', 'ALI SOFIANE ', 'كلال ', 'علي سفيان ', 'Homme', '1978-10-10', 'ORAN', 'BOUABDELALLAH ', 'بوعبدالله ', 'MEZOUED ZEGUAR', 'Aicha ', 'مزود زقار ', 'عائشة ', '9354000', '1978-10-10', 'ORAN', 'ORAN', 'cité mohamed boudiaf N°206 oued tlelat /oran ', 'asst juridique et contentieux ', '-', '-', '-', 'Marié(e)', 'mokadem ', 'karima ', 'مقدم ', 'karima ', '27/08/1977', 'ORAN', '-', NULL, NULL),
(31, '2019-05-27', 'Client normal', 'ATTOU ', 'Mustapha ', 'عتو ', 'مصطفى ', 'Homme', '1980-02-25', 'ORAN', 'ABDELKADER ', 'عبد القادر ', 'BENNACER ', 'KHIERA ', 'بن ناصر ', 'خيرة ', '721781', '2008-12-21', 'ORAN', 'ORAN', '25 CITE MOHAMED BOUDIAF ', 'PROF ', '-', '-', '-', 'Marié(e)', 'BERKANI ', 'AICHA ', 'بركاني ', 'AICHA ', '13/02/1993', 'ORAN', 'PROF ', NULL, NULL),
(32, '2019-05-27', 'Client normal', 'BOBBOU ', 'DJAMEL ', 'بوبو', 'جمال ', 'Homme', '1986-01-11', 'ORAN', 'ABDELKADER ', 'عبد القادر ', 'LATA', 'FATIMA', 'لاتة ', 'فاطمة ', '251549', '2008-08-26', 'ORAN', 'ORAN', 'N°37 cité 122  logement amir abdelkader ', '-', '-', '-', '-', 'Marié(e)', 'soufal', 'khadidja ', 'سوفال', 'khadidja ', '19/06/1990', 'ORAN', '-', NULL, NULL),
(33, '2019-05-27', 'Client normal', 'HAMMADI ', 'SAID ', 'حمادي ', 'سعيد', 'Homme', '1957-03-21', 'ORAN', 'MOHAMED', 'محمد', 'KHADRI ', 'RABHA', 'خضرة ', 'رابحة ', '825781', '2011-09-06', 'ORAN', 'ORAN', 'RUE ETHAWRA - OUED TLILET ORAN ', 'Sous Directeur SNTF', '-', '-', '-', 'Marié(e)', 'BOUHACIDA', 'HAKIMA', 'بوحميدة ', 'HAKIMA', '03/01/1965', 'ORAN', 'PROF ENSEIGN', NULL, NULL),
(34, '2019-05-27', 'Client normal', 'BENAYED', 'HASSIBA ', 'بن عياد ', 'حسبة ', 'Homme', '1970-11-28', 'ORAN', 'YOUCEF ', 'يوسف ', 'SOHBI ', 'SAKINA ', 'صحبي ', 'سكينة ', '074529', '2013-05-08', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF ', 'ADJ FORMATION ', '-', '-', '-', 'Marié(e)', 'LAISSAOUI ', 'NOUR EDDINE ', 'لعيساوي ', 'NOUR EDDINE ', '03/10/1972', 'ORAN', '-', NULL, NULL),
(35, '2019-05-27', 'Client normal', 'GUENFOUD ', 'FAYCEL ', 'قنفود', 'فيصل ', 'Homme', '1978-07-29', 'ORAN', 'KADA', 'قادة ', 'BILAL', 'LHOUARIA ', 'بلال ', 'لهوارية ', '126023', '2004-11-30', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF ', 'COMPTABLE  ', '-', '-', '-', 'Marié(e)', 'TABAL', 'KHADIDJA ', 'طبال ', 'KHADIDJA ', '21/01/1985', 'ORAN', '-', NULL, NULL),
(36, '2019-05-27', 'Client normal', 'NEKROUF', 'AZIZ', 'نكروف ', 'عزيز', 'Homme', '1980-06-24', 'ORAN', 'HABIB', 'حبيب', 'NEKROUF', 'ARBIA  ', 'نكروف ', 'عربية ', '675541', '2006-03-01', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDIAF ORAN ', '-', '-', '-', '-', 'Marié(e)', 'BENTOUMI ', 'MOKHTARIA', 'بن تومي ', 'MOKHTARIA', '11/01/1988', 'ORAN', '-', NULL, NULL),
(37, '2019-05-27', 'Client normal', 'GHIS', 'DJAMEL', 'غيس', 'جمال', 'Homme', '1980-08-16', 'ORAN', 'KADI', 'قاضي', 'SAHNOUN', 'AICHA', 'سحنون', 'عائشة', '129408', '2006-09-16', 'ORAN', 'ORAN', 'RUE IBRAHIM BEN AHMED / OUED TLILET ', 'ADMISTRATEUR', '-', '-', '-', 'Marié(e)', 'KHELIFA ', 'HAKIMA', 'خليفة ', 'HAKIMA', '15/07/1982', 'ORAN', '-', NULL, NULL),
(38, '2019-05-27', 'Client normal', 'MOHAMMED KRACHI ', 'SOUED ', 'محمد كراشاي', 'سعاد', 'Femme', '1982-09-16', 'ORAN', 'ABDELKADER', 'عبد القادر', 'BELARKIK BENYAGOUB ', 'DJILALIA', 'بلعرقيق بن يعقوب ', 'جيلالية ', '028049', '2012-04-17', 'ORAN', 'ORAN', 'CITE MOHAMED BOUDAIF OUED TLILET ORAN ', 'MEDCIN', '-', '-', '-', 'Marié(e)', 'CHERGUI ', 'FARES', 'شرقي', 'FARES', '11/12/1976', 'ORAN', '-', NULL, NULL),
(39, '2019-05-27', 'Client normal', 'BENMESLEM ', 'KHADIDJA ', 'بن مسلم ', 'خديجة ', 'Femme', '1985-09-24', 'ORAN', 'BENAMAR', 'بن عمار ', 'MELAH', 'MAMA', 'ملاح', 'مامة ', '939493', '2013-02-21', 'ORAN', 'ORAN', 'RUE RAKIBA ABDELKADER OUED TLEILET ORAN ', 'SAGE FEMME', '-', '-', '-', 'Marié(e)', 'GHADBAN ', 'CHRIF ', 'غضبان ', 'CHRIF ', '02/04/1984', 'ORAN', 'MILITAIRE ', NULL, NULL),
(40, '2019-05-28', 'Client normal', 'bouguedra', 'benyagoub ', 'بوقدرة ', 'بن يعقوب ', 'Homme', '1960-12-09', 'ORAN', 'filali ', 'فيلالي', 'tabal', 'mama', 'طبال', 'مامة ', '745472', '2008-02-03', 'ORAN', 'ORAN', 'cité eltoumiate', 'labo dip etat ', '-', '-', '-', 'Marié(e)', 'chenoufi ', 'lahouaria', 'شنوفي ', 'lahouaria', '12/06/1969', 'ORAN', '-', NULL, NULL),
(41, '2019-05-28', 'Client normal', 'dahou', 'fatima', 'دحو', 'فاطمة', 'Femme', '1988-01-30', 'ORAN', 'khaled', 'خالد', 'belbouri', 'mokhtaria', 'بلبوري', 'مخطارية', '522063', '2004-08-11', 'ORAN', 'ORAN', 'cité 24 lgt oued tlilet ', 'prof d\'enseign', '-', '-', '-', 'Marié(e)', 'bouaksa', 'gherici', 'بوعكسة', 'gherici', '16/03/1982', 'ORAN', 'prof d\'enseign', NULL, NULL),
(42, '2019-05-28', 'Client normal', 'menai', 'ali', 'مناعي', 'علي', 'Homme', '1954-11-07', 'ORAN', 'bouzid', 'بوزيد', 'rahou ', 'houria ', 'راحو', 'حورية', '-', '2019-05-03', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Célibataire', '', '', '', '', '', '', '', NULL, NULL),
(43, '2019-05-28', 'Client normal', 'zemalache', 'belkhier', 'زملاش', 'بلخير', 'Homme', '1967-10-11', 'ORAN', 'bouamama', 'بوعمامة', 'megni', 'khiera', 'مقني', 'خيرة', '502322', '2012-12-02', 'ORAN', 'ORAN', 'rue hamo boutlilis oued tlilet oran ', '-', '-', '-', '-', 'Marié(e)', 'tayebi', 'sahmadia', 'طيبي', 'sahmadia', '02/04/1976', 'ORAN', 'electricien', NULL, NULL),
(44, '2019-05-28', 'Client normal', 'bouzouina', 'zohir', 'بوزوينة', 'زهير', 'Homme', '1975-09-25', 'ORAN', 'elhouari', 'الهواري', 'mahali ', 'badra', 'محلي', 'بدرة', '264041', '2010-11-28', 'ORAN', 'ORAN', 'rue rakiba abdelkader', '-', '-', '-', '-', 'Marié(e)', 'belachheb', 'sihem', 'بلشهب', 'sihem', '24/08/1985', 'ORAN', '-', NULL, NULL),
(45, '2019-05-28', 'Client normal', 'mahraz', 'Ismahane', 'محراز', 'اسمهان', 'Femme', '1981-03-22', 'ORAN', 'hadj', 'حاج', 'messamah', 'mokhtaria', 'مسامح', 'مخطارية ', '926421', '1981-03-22', 'ORAN', 'ORAN', 'cité 71 logt oued tlilet oran ', '-', '-', '-', '-', 'Marié(e)', 'benyakhlef', 'mohamed', 'بن يخلف', 'mohamed', '23/01/1977', 'ORAN', '-', NULL, NULL),
(46, '2019-05-28', 'Client normal', 'lessoued', 'mohamed', 'لسود', 'محمد', 'Homme', '1978-01-05', 'ORAN', 'abdelkder', 'عبد القادر', 'abd elmoula ', 'aicha', 'عبد المولى ', 'عيشة ', '723499', '2012-02-28', 'ORAN', 'ORAN', 'cité 180 logt oued tlilet oran', '-', '-', '-', '-', 'Marié(e)', 'benamar', 'faiza', 'بن عمار', 'faiza', '05/04/1987', 'ORAN', '-', NULL, NULL),
(47, '2019-05-28', 'Client normal', 'habib zahmani', 'hadjira', 'حبيب زحماني', 'هجيرة', 'Homme', '1968-07-16', 'ORAN', 'mohamed', 'محمد', 'habib  zahmani ', 'fatima', 'حبيب زحماني', 'فاطمة ', '129527', '2006-09-19', 'ORAN', 'ORAN', 'cite 90 logt oued tlilet oran', 'prof univ', '-', '-', '-', 'Célibataire', '', '', '', '', '', '', '', NULL, NULL),
(48, '2019-05-28', 'Client normal', 'baghdad zoggar', 'abdelkrim', 'بغداد زقار', 'عبدالكريم ', 'Homme', '1959-12-10', 'ORAN', 'djloul', 'جلول', 'benabed', 'laidia', 'بن عابد', 'لعيدية ', '410919', '2007-08-30', 'ORAN', 'ORAN', 'cité ethawra / oued tlilet', '-', '-', '-', '-', 'Marié(e)', 'smain kahili', 'zahiro', 'سماعين كحيلي', 'zahiro', '15/10/1974', 'ORAN', '-', NULL, NULL),
(49, '2019-05-28', 'Client normal', 'khelifa ', 'soraya ', 'خليفة', 'صورية ', 'Homme', '1989-03-08', 'ORAN', 'ahmed', 'أحمد', 'meddah', 'oum khier', 'مداح', 'أم خير', '-', '2019-05-15', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'benabou', 'toufik', 'بن عبو', 'toufik', '15/05/1985', 'ORAN', '-', NULL, NULL),
(50, '2019-05-28', 'Client normal', 'ghazi', 'mohamed', 'غازي', 'محمد', 'Homme', '1956-11-03', 'ORAN', 'abdelkader', 'عبد القادر', 'zenassni', 'mama', 'زناسني ', 'مامة', '745136', '2009-10-25', 'ORAN', 'ORAN', 'rue ben kadih abdelkader oued tlilet ', '-', '-', '-', '-', 'Marié(e)', 'bentouaf', 'karim', 'بن طواف ', 'karim', '11/03/1968', 'ORAN', '-', NULL, NULL),
(51, '2019-05-29', 'Client normal', 'cheklal', 'kada', 'شقلال', 'قادة', 'Homme', '1984-11-13', 'ORAN', 'allal', 'علال', 'saad chamloul ', 'yamina', 'سعد شملول', 'يمينة', '577176', '1984-11-13', 'ORAN', 'ORAN', 'cité 100 logement oued tlilet ', '-', '-', '-', '-', 'Marié(e)', 'benchikh ', 'zohra', 'بن شيخ ', 'zohra', '07/08/1988', 'ORAN', '-', NULL, NULL),
(52, '2019-05-29', 'Client normal', 'dida ', 'abdelkader ', 'ديدة', 'عبد القادر', 'Homme', '1973-12-16', 'ORAN', 'taher', 'طاهر', 'baghdad', 'maghnia', 'بغداد', 'مغنية', '793259', '2009-02-03', 'ORAN', 'ORAN', 'cité mohamed boudiaf ', '-', '-', '-', '-', 'Marié(e)', 'mia meftah', 'warida', 'مية مفتاح', 'warida', '06/06/1988', 'ORAN', '-', NULL, NULL),
(53, '2019-05-30', 'Client normal', 'samir', 'benamer', 'سمير', 'بن عمر', 'Femme', '1973-11-29', 'ORAN', 'mohamed', 'محمد', 'boukraa djloul saih', 'khiera', 'بوكراع جلول سايح ', 'خيرة', '826128', '2011-09-26', 'ORAN', 'ORAN', 'rue nakach kada oued tlelat / oran ', '-', '-', '-', '-', 'Marié(e)', ' guamra', 'khadidja', 'قمرة', 'khadidja', '11/04/1981', 'ORAN', '-', NULL, NULL),
(54, '2019-05-30', 'Client normal', 'sari ', 'aicha', 'صاري', 'عائشة ', 'Homme', '1978-12-26', 'ORAN', 'ali ', 'علي ', 'chaklalia', 'yamina', 'شقلالية ', 'يمينة ', ' 242146', '1978-12-26', 'ORAN', 'ORAN', 'rue zitouni ahmed', '-', '-', '-', '-', 'Marié(e)', 'sari', 'samir ', 'صاري', 'samir ', '28/05/1966', 'ORAN', '-', NULL, NULL),
(55, '2019-05-30', 'Client normal', 'chibani ', 'mokhtar', 'شيباني', 'مخطار', 'Homme', '1963-11-24', 'ORAN', 'mkhissi', 'مخيسي ', 'gabli', 'khiera', 'قبلي', 'خيرة ', '24/11/1963', '1963-11-24', 'ORAN', 'ORAN', 'cité ibrahim ben ahmed', '-', '-', '-', '-', 'Marié(e)', 'bendella ', 'kheira', 'بن دلة ', 'kheira', '20/02/1967', 'ORAN', '-', NULL, NULL),
(56, '2019-06-02', 'Client normal', 'TALEB ZOUGAR ', 'KARIMA', 'طالب زوقار', 'كريمة ', 'Femme', '1965-09-22', 'ORAN', 'ARBI', 'عربي ', 'BAGHDAD ZOUGAA', 'KHADIDJA ', 'بغداد زوقاع ', 'خديجة ', '446169', '2004-05-16', 'ORAN', 'ORAN', 'RUE ZITOUNI AHMED / OUED TLILET ', 'AGENT ADMINISTRATF', '-', '-', '-', 'Marié(e)', 'BELHAOUARI ', 'ABDELKADER ', 'بلهواري', 'ABDELKADER ', '01/02/1967', 'ORAN', '-', NULL, NULL),
(57, '2019-06-02', 'Client normal', 'HARRAG ', 'DJOHAR ', 'حراق ', 'جوهر ', 'Femme', '1978-03-01', 'ORAN', 'MEKHISSI ', 'مخيسي  ', 'BEN SALEM ', 'FATIMA ', 'بن سالم ', 'فاطمة ', '-', '2019-06-02', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Célibataire', '', '', '', '', '', '', '', NULL, NULL),
(58, '2019-06-02', 'Client normal', 'TEBBAL ', 'RACHID ', 'طبال ', 'رشيد ', 'Homme', '1971-10-24', 'ORAN', 'ABED ', 'عابد ', 'RACHED KHALOUFI ', 'ZAHRA  ', 'راشد خلوفي ', 'زهرة ', '522981', '1971-10-24', 'ORAN', 'ORAN', 'CITE EL DJADID ', '-', '-', '-', '-', 'Marié(e)', 'YEKHLEF ', 'FATIMA ZOHRA ', 'يخلف', 'FATIMA ZOHRA ', '10/01/1982', 'ORAN', 'COMMIS GREFFIER ', NULL, NULL),
(59, '2019-06-02', 'Client normal', 'BELKHIR ', 'KAMEL ', 'بلخير ', 'كمال ', 'Homme', '1978-03-31', 'ORAN', 'MOHAMED ', 'محمد', 'GHANIA ', 'ABESS ', 'غنية ', 'عباس ', '111796', '2003-04-19', 'ORAN', 'ORAN', '/', 'CHARGE D ETUDE ', '-', '-', '-', 'Marié(e)', 'GUEZOUL ', 'FOUZIA ', 'قزول ', 'FOUZIA ', '27/10/1985', 'ORAN', '-', NULL, NULL),
(60, '2019-06-02', 'Client normal', 'TALEB ZOUGGAR ', 'BELKHIER ', 'طالب زوقار ', 'بلخير ', 'Homme', '1980-04-27', 'ORAN', 'BOUABDALAH ', 'بوعبدالله', 'RASANI ', 'MOKHTARIA ', 'رصاني', 'مخطارية', '745528', '2008-02-05', 'ORAN', 'ORAN', 'RUE ZITOUNI AHMED', '-', '-', '-', '-', 'Marié(e)', 'FATIMA ZAHRA ', 'HADJ ALI ', 'فاطمة الزهرة ', 'HADJ ALI ', '18/06/1987', 'ORAN', '-', NULL, NULL),
(61, '2019-06-02', 'Client normal', 'derradji ', 'elhouari ', 'دراجي ', ' الهواري', 'Homme', '1981-11-03', 'ORAN', 'elamri ', 'العمري', 'djabi', 'fatima zahra ', 'جابي ', 'فاطمة الزهرة ', '953191', '2016-12-04', 'ORAN', 'ORAN', 'rue guarin abdelkader', '-', '-', '-', '-', 'Marié(e)', 'bourguiba ', 'kadia', 'بورقيبة ', 'kadia', '24/11/1984', 'ORAN', '-', NULL, NULL),
(62, '2019-06-03', 'Client normal', 'berrezoug ', 'djamila ', 'برزوق ', 'جميلة ', 'Femme', '1987-04-16', 'ORAN', 'djilali', 'جيلالي', 'bouhamar', 'zohra', 'بوحمار', 'زهرة ', '-', '2019-06-03', 'ORAN', 'ORAN', 'rue reguiba abdelkader ', 'prof ', '-', '-', '-', 'Marié(e)', 'benouda ', 'benhalima ', 'بن عودة', 'benhalima ', '05/06/2019', 'ORAN', '-', NULL, NULL),
(63, '2019-06-03', 'Client normal', 'gourara ', 'sadek', 'قورارة', 'صادق', 'Homme', '1964-11-02', 'ORAN', 'abdelkader ', 'عبد القادر ', 'hasain douadji ', 'fatima', 'حساين دواجي ', 'فاطمة ', '518411', '2008-04-27', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'habib', 'nacera', 'حبيب', 'nacera', '26/11/1969', 'ORAN', '-', NULL, NULL),
(64, '2019-06-06', 'Client normal', 'BELDJILALI ', 'ABDELKADER ', 'بلجيلالي', 'عبد القادر ', 'Homme', '1973-06-04', 'ORAN', 'MOHAMED', 'محمد', 'ZITOUNI ', 'OUM LKHIER ', 'زيتوني', 'أم الخير ', '079453', '2010-03-03', 'ORAN', 'ORAN', '-', 'AGENT', '-', '-', '-', 'Marié(e)', 'MELOUK', 'AICHA', 'ملوك ', 'AICHA', '17/10/1977', 'ORAN', '-', NULL, NULL),
(65, '2019-06-06', 'Client normal', 'GHEZAL', 'MOHAMED', 'غزال', 'محمد', 'Homme', '1966-02-27', 'ORAN', 'AHMED', 'احمد', 'ZOHRA', 'BASSIM', 'زهرة', 'باسيم', '745667', '1966-02-27', 'ORAN', 'ORAN', '-', 'CHEF SERVICE', '-', '-', '-', 'Marié(e)', 'KHALEFI', 'FATIMA', 'خالفي', 'FATIMA', '01/01/1968', 'ORAN', '-', NULL, NULL),
(66, '2019-06-06', 'Client normal', 'KEDDAR ', 'MOKHTAR ', 'قدار ', 'مخطار ', 'Homme', '1981-05-17', 'ORAN', 'KOUIDER', 'قويدر', 'GUERNOUCH', 'KHADIJA', 'قرنوس', 'خديجة ', '410108', '0191-05-17', 'ORAN', 'ORAN', 'CITE MOHAMMED BOUDIAF ', '-', '-', '-', '-', 'Marié(e)', 'BENOUZZA', 'KHADRA', 'بنوزة', 'KHADRA', '04/09/1982', 'ORAN', 'Infermier', NULL, NULL),
(67, '2019-06-06', 'Client normal', 'bensouak', 'khedidja', 'بن سواك', 'خديجة ', 'Femme', '1979-11-25', 'ORAN', 'ali', 'علي', 'boudia', 'mokhtaria', 'بودية ', 'مخطارية', '083952', '1979-11-25', 'ORAN', 'ORAN', '-', 'commis greffier', '-', '-', '-', 'Marié(e)', 'bakhti', 'abdelmadjid', 'بختي', 'abdelmadjid', '11/07/1987', 'ORAN', 'agent  de montage', NULL, NULL),
(68, '2019-06-06', 'Client normal', 'belharazem', 'meriem', 'بالحرازم', 'مريم', 'Femme', '1975-05-21', 'ORAN', 'abdelkader', 'عبد القادر', 'akrouba', 'djamaa', 'عقروبة', 'جمعة ', '459736', '0214-04-14', 'ORAN', 'ORAN', '-', 'agent administratif', '-', '-', '-', 'Célibataire', '', '', '', '', '', '', '', NULL, NULL),
(69, '2019-06-06', 'Client normal', 'hakmi', 'mohamed', 'حاكمي', 'محمد', 'Homme', '1984-06-06', 'ORAN', 'said', 'سعيد', 'bendima ', 'khadra', 'بن ديمة ', 'خضرة ', '923821', '2009-06-21', 'ORAN', 'ORAN', 'cite mohamed boudiaf oued tlilet oran ', '-', '-', '-', '-', 'Marié(e)', 'belghezzali ', 'zeyneb', 'بلغزالي', 'zeyneb', '26/03/1982', 'ORAN', '-', NULL, NULL),
(70, '2019-06-06', 'Client normal', 'belhamidi ', 'adel', 'بلحميدي ', 'عادل', 'Homme', '1985-01-26', 'ORAN', 'ahmed ', 'احمد ', 'bouzerk djloul saih ', 'khadouma', 'بورزق جلول سايح ', 'خدومة ', '859496', '2009-08-27', 'ORAN', 'ORAN', 'rue berfas djilali oued tlilet ', 'enseignant CEM', '-', '-', '-', 'Marié(e)', 'BAGHDAD ZOUGAR ', 'KARIMA', 'بغداد زوقار ', 'KARIMA', '05/10/1982', 'ORAN', 'Agent administratif ', NULL, NULL),
(71, '2019-06-06', 'Client normal', 'benamar ', 'mohammed ', 'بن عمار ', 'محمد', 'Homme', '1963-01-20', 'ORAN', 'bouadjmi ', 'بوعجمي', 'boualem ', 'mama', 'بوعلام ', 'مامة ', '123312', '2006-05-21', 'ORAN', 'ORAN', 'rue si fodhil oued tlilet', 'avocat', '-', '-', '-', 'Marié(e)', 'charif louzani ', 'lala sanaa fatima', 'شريف الوزاني', 'lala sanaa fatima', '24/09/1974', 'ORAN', '-', NULL, NULL),
(72, '2019-06-06', 'Client normal', 'el tarr', 'lahouari benyagoube', 'الطار ', 'لهواري بن يعقوب ', 'Homme', '1960-11-13', 'ORAN', 'djilali ', 'جيلالي', 'hassini ', 'bakria ', 'حسيني ', 'بكرية ', '953241', '2006-12-07', 'ORAN', 'ORAN', '43 cité amir abdelkader oued tlilet ', '-', '-', '-', '-', 'Marié(e)', 'korich ', 'laida', 'قريش ', 'laida', '09/12/1969', 'ORAN', '-', NULL, NULL),
(73, '2019-06-06', 'Client normal', 'messadi ', 'noureddine', 'مساعدي', 'نور الدين ', 'Homme', '1978-12-23', 'ORAN', 'kadour', 'قدور', 'bahilil', 'khiera', 'بهيليل', 'خيرة', '745634', '2005-05-16', 'ORAN', 'ORAN', 'N°59 cité howari boumdiane oued tlilet', '-', '-', '-', '-', 'Divorcé(e)', '', '', '', '', '', '', '', NULL, NULL),
(74, '2019-06-06', 'Client normal', 'hadjm', 'mohamed ', 'حجام', 'محمد', 'Homme', '1976-10-01', 'ORAN', 'belkhier', 'بلخير', 'hadjam', 'mohamed', 'حجام', 'محمد', '859874', '2009-10-05', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'boucif', 'abbassia', 'بوسيف', 'abbassia', '30/08/1978', 'ORAN', '-', NULL, NULL),
(75, '2019-06-09', 'Client normal', 'SI LARBI', 'AHMED ', 'سي العربي', 'أحمد', 'Homme', '1981-02-16', 'ORAN', 'TAHER ', 'طاهر ', 'LABDI', 'YAMINA', 'لبدي', 'يمينة ', '028740', '1981-02-16', 'ORAN', 'ORAN', 'CITE TOUMIATE OUED TLILET /ORAN ', 'CADRE ', '-', '-', '-', 'Marié(e)', 'BOUAISSI', 'SAMIRA', 'بوعيسي', 'SAMIRA', '23/03/1989', 'ORAN', '-', NULL, NULL),
(76, '2019-06-09', 'Client normal', 'BENMESTOURA', 'RACHID', 'بن مستورة ', 'رشيد', 'Homme', '1980-08-13', 'ORAN', 'HABIB', 'حبيب', 'OUDIA', 'AICHA', 'عودية ', 'عائشة ', '522478', '2004-09-22', 'ORAN', 'ORAN', 'OUED TLILET ORAN ', '-', '-', '-', '-', 'Marié(e)', 'ABDELLAOUI ', 'SALIMA', 'عبداللاوي', 'SALIMA', '04/01/1978', 'ORAN', '-', NULL, NULL),
(77, '2019-06-09', 'Client normal', 'KHALI', 'SALIM', 'خالي', 'سليم', 'Homme', '1974-08-04', 'ORAN', 'BELKHIER ', 'بلخير ', 'DAHO BACHIR', 'YAMINA', 'دحو بشير', 'يمينة', '926780', '2012-08-13', 'ORAN', 'ORAN', 'RUE ZITOUNI AHMED ', '-', '-', '-', '-', 'Marié(e)', 'BOUDERBALA', 'MOKHTARIA SARA', 'بودربالة ', 'MOKHTARIA SARA', '26/09/1980', 'ORAN', '-', NULL, NULL),
(78, '2019-06-09', 'Client normal', 'NOREDDINE ', 'BELAZZE', 'نورالدين', 'بلعز ', 'Homme', '1981-05-05', 'ORAN', 'CHIKH', 'شيخ', 'LADRAA', 'ZOHRA', 'لادراع', 'زهرة', '123955', '2006-07-31', 'ORAN', 'ORAN', 'RUE BENKADIH ABDELKADER ', '-', '-', '-', '-', 'Marié(e)', 'BEKKI SEBAA', 'NADIA', 'بكي السبع ', 'NADIA', '01/10/1981', 'ORAN', '-', NULL, NULL),
(79, '2019-06-09', 'Client normal', 'BENSAHA', 'MOHAMED', 'بن ساحة ', 'محمد', 'Homme', '1982-01-12', 'ORAN', 'MILOUD', 'ميلود', 'KHELFAYA ', 'FATIMA', 'خلفاية', 'فاطمة ', '028624', '2012-05-03', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Célibataire', '', '', '', '', '', '', '', NULL, NULL),
(80, '2019-06-09', 'Client normal', 'FETTAH', 'MOHAMED', 'فتاح', 'محمد', 'Homme', '1979-08-10', 'ORAN', 'MOHAMED', 'محمد', 'BENCHBRI', 'FATIMA', 'بن شبري', 'فاطمة ', '522795', '1979-08-10', 'ORAN', 'ORAN', 'CITE ELYOUMIYATE', '-', '-', '-', '-', 'Marié(e)', 'BOUMAZA', 'FATIHA', 'بومعزة', 'FATIHA', '25/03/1980', 'ORAN', '-', NULL, NULL),
(81, '2019-06-09', 'Client normal', 'DJIDI ', 'ABDELKADER', 'جيدي', 'عبد القادر ', 'Homme', '1972-10-26', 'ORAN', 'ALI', 'علي', 'BENHOSSINE', 'CHRIFA', 'بن حسين', 'شريفة', '-', '2019-06-06', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'MOUMEN', 'BADRA', 'مومن', 'BADRA', '16/08/1977', 'ORAN', '-', NULL, NULL),
(82, '2019-06-09', 'Client normal', 'OUSLIMANI', 'HAMOU', 'اوسليماني', 'حمو', 'Homme', '1963-11-11', 'ORAN', 'hocine', 'حسين', 'ayet hamlate ', 'samina', 'أيت حملات', 'سمينة ', '074414', '2013-04-29', 'ORAN', 'ORAN', 'rue  grin abdelkader oud tlilet oran ', '-', '-', '-', '-', 'Marié(e)', 'ait hamlat', 'tassadit', 'ايت حملات ', 'tassadit', '05/09/1973', 'ORAN', '-', NULL, NULL),
(83, '2019-06-10', 'Client normal', 'benabdallah ', 'khedidja', 'بن عبد الله', 'خديجة ', 'Homme', '1974-06-12', 'ORAN', 'mohamed', 'محمد', 'touzen ', 'khadra ', 'توزن', 'خضرة ', '083371', '2011-03-27', 'ORAN', 'ORAN', '-', 'prof', '-', '-', '-', 'Marié(e)', 'khedrougui', 'mohamed ', 'خدروقي', 'mohamed ', '26/04/1969', 'ORAN', '-', NULL, NULL),
(84, '2019-06-10', 'Client normal', 'cherchar', 'mohamed', 'شرشار', 'محمد', 'Homme', '1983-04-01', 'ORAN', 'marija ', 'مريجة', 'alem', 'alia', 'عالم', 'العالية', '926806', '2012-08-16', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Célibataire', '', '', '', '', '', '', '', NULL, NULL),
(85, '2019-06-12', 'Client normal', 'bendahja', 'fatima zohra ', 'بن داحة ', 'فطيمة الزهراء ', 'Homme', '1961-12-10', 'ORAN', 'kouider ', 'قويدر ', 'lachter ', 'ratiba ', 'لشطر ', 'رتيبة ', '129043', '2006-08-09', 'ORAN', 'ORAN', 'rue ibrahim ben ahmed ', '-', '-', '-', '-', 'Marié(e)', 'bencharif ', 'djloul ', 'بن شريف ', 'djloul ', '21/07/1962', 'ORAN', '-', NULL, NULL),
(86, '2019-06-12', 'Client normal', 'bali ', 'fatima zohra ', 'بالي ', 'فاطمة الزهراء ', 'Femme', '1962-09-29', 'ORAN', 'hacni ', 'حسني', 'belmechri ', 'halima ', 'بلمشري ', 'حليمة ', '083390', '2011-03-28', 'ORAN', 'ORAN', 'rue ibrahim ben ahmed oued tlilet ', '-', '-', '-', '-', 'Divorcé(e)', '', '', '', '', '', '', '', NULL, NULL),
(87, '2019-06-12', 'Client normal', 'garmouti ', 'nasr eddine ', 'قرموطي', 'نصر الدين ', 'Homme', '1973-05-23', 'ORAN', 'hanifi ', 'حنيفي', 'mzoud zoguar ', 'zoulikha', 'مزود زوقار', 'زوليخة ', '926429', '1973-05-23', 'ORAN', 'ORAN', 'rue zitouni ahmed oued tlilete ', '-', '-', ' -', '-', 'Marié(e)', 'chalgou ', 'fatima zohra', 'شالقو', 'fatima zohra', '18/05/1979', 'ORAN', '-', NULL, NULL),
(88, '2019-06-12', 'Client normal', 'bouhenni ', 'belkhier ', 'بوهني', 'بلخير ', 'Femme', '1978-05-04', 'ORAN', 'blaha ', 'بلاحة ', 'bensalem', 'badra ', 'بن سالم', 'بدرة', '510423', '2011-05-22', 'ORAN', 'ORAN', 'cité toumiate oued tlilet oran ', '-', '-', '-', '-', 'Marié(e)', 'benmessoud', 'yamina', 'بن مسعود', 'yamina', '21/11/1985', 'ORAN', '-', NULL, NULL),
(89, '2019-06-16', 'Client normal', 'BENZEROUALI', 'DJAMEL', 'بن زروالي ', 'جمال', 'Homme', '1962-07-03', 'ORAN', 'mohamed ', 'محمد', 'chamloul', 'djouher', 'شملول', 'جوهر', '410833', '1962-07-03', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'merair', 'halima', 'مراير', 'halima', '23/07/1977', 'ORAN', '-', NULL, NULL),
(90, '2019-06-16', 'Client normal', 'memdoud ', 'mokhtar', 'ممدود', 'مخطار', 'Homme', '1973-06-10', 'ORAN', 'djilali', 'جيلالي', 'hadri', 'khiera', 'حضري', 'خيرة', '381599', '2012-01-18', 'ORAN', 'ORAN', '256 rue hai daya oran ', '-', '-', '-', '-', 'Marié(e)', 'feghloul', 'wafia', 'فغلول', 'wafia', '08/10/0198', 'ORAN', '-', NULL, NULL),
(91, '2019-06-16', 'Client normal', 'HACHMANE', 'Mohammed', 'حشمان', 'محمد', 'Homme', '1966-08-02', 'ORAN', 'djilali', 'جيلالي', 'derouich', 'khiera', 'درويش', 'خيرة ', '938691', '2010-10-10', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'mohammed smaha', 'khouira', 'محمد سماحة', 'khouira', '13/06/1969', 'ORAN', '-', NULL, NULL),
(92, '2019-06-16', 'Client normal', 'chaabane', 'abdelrahmane', 'شعبان', 'عبد الرحمان', 'Homme', '1978-06-25', 'ORAN', 'abdelaziz', 'عبد العزيز', 'gheribi ', 'fouzia', 'غريبي', 'فوزية ', '675497', '0206-02-25', 'ORAN', 'ORAN', 'rue rakiba abdelkader oued tlilete', '-', '-', '-', '-', 'Marié(e)', 'bendahma', 'mama', 'بن دهمة ', 'mama', '01/02/1980', 'ORAN', '-', NULL, NULL),
(93, '2019-06-16', 'Client normal', 'BELAZZE', 'MALIKA', 'بلعز', 'مليكة', 'Femme', '1971-09-28', 'ORAN', 'CHIKH', 'شيخ', 'LADRAA', 'ZOHRA', 'لدرع', 'زهرة', '720495', '2008-07-30', 'ORAN', 'ORAN', 'RUE ben kadih abdelkader', '-', '-', '-', '-', 'Marié(e)', 'abdelkader', 'gorine', 'عبد القادر', 'gorine', '07/08/1970', 'ORAN', '-', NULL, NULL),
(94, '2019-06-16', 'Client normal', 'belkhier ', 'benamar', 'بلخير', 'بن عمر ', 'Homme', '1981-03-14', 'ORAN', 'habib', 'حبيب', 'berho messrouri', 'yamina', 'برحو مسروري', 'يمينة ', '723250', '2012-02-13', 'ORAN', 'ORAN', 'cité 90 logement oued tlilet', '-', '-', '-', '-', 'Marié(e)', 'abich', 'karima', 'عبيش', 'karima', '14/03/0191', 'ORAN', '-', NULL, NULL),
(95, '2019-06-17', 'Client normal', 'kadar', 'fethi', 'قدار', 'فتحي ', 'Homme', '1978-10-11', 'ORAN', 'mohamed', 'محمد', 'hamach', 'rabia', 'حماش  ', 'ربيعة', '410756', '1978-10-11', 'ORAN', 'ORAN', 'cité imarates  ', '-', '-', '-', '-', 'Marié(e)', 'boutaleb', 'nawel', 'بوطالب ', 'nawel', '06/03/1986', 'ORAN', '-', NULL, NULL),
(96, '2019-06-17', 'Client normal', 'bahousi', 'bouhas', 'بوحوصي', 'بحوص', 'Homme', '1976-09-27', 'ORAN', 'laid', 'لعيد', 'nokta', 'zahra', 'نقطة', 'زهرة ', '659186', '2009-12-18', 'ORAN', 'ORAN', 'oued tlilete ', 'déléguer communale', '-', '-', '-', 'Marié(e)', 'bafadel', 'nacera', 'بافضل', 'nacera', '17/04/1985', 'ORAN', '-', NULL, NULL),
(97, '2019-06-17', 'Client normal', 'belkhier ', 'benzeroual', 'بلخير', 'بنزروال', 'Homme', '1980-06-28', 'ORAN', 'mohamed', 'محمد', 'berbouche', 'ftaima zohraf', 'بربوش', 'فطيمة الزهرة', '40965', '2001-08-29', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Célibataire', '', '', '', '', '', '', '', NULL, NULL),
(98, '2019-06-17', 'Client normal', 'gourara ', 'mohamed el amine ', 'قورارة ', 'محمد الأمين ', 'Homme', '1978-09-24', 'ORAN', 'mohamed', 'محمد', 'hassain douaji ', 'yamina', 'حساين دواجي', 'يمينة ', '764641', '2008-02-25', 'ORAN', 'ORAN', 'cité mohamed boudiaf oran ', '-', '-', '-', '-', 'Marié(e)', 'hassaine daouadji', 'amina', 'حساين دواجي ', 'amina', '14/07/1989', 'ORAN', '-', NULL, NULL),
(99, '2019-06-17', 'Client normal', 'MARAZ', 'Mehdi', 'مهراز', 'مهدي', 'Homme', '1979-05-16', 'ORAN', 'benali', 'بن علي', 'sam bouafia', 'meriem', 'صام بوعافية', 'مريم', '522569', '2011-12-28', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'belghezali ', 'nor elhouda', 'بلغزالي', 'nor elhouda', '04/05/1983', 'ORAN', '-', NULL, NULL),
(100, '2019-06-17', 'Client normal', 'berrabah', 'mohamed', 'برابح', 'محمد', 'Homme', '1980-08-14', 'ORAN', 'said', 'سعيد', 'berabah ', 'hassnia', 'برابح', 'حسنية ', '176119', '2007-03-07', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'bentasbet', 'elhouaria', 'بن ثابت ', 'elhouaria', '28/08/0196', 'ORAN', '-', NULL, NULL),
(101, '2019-06-17', 'Client normal', 'AMRAOUI', 'Abdelkader', 'عمراوي', 'عبد القادر ', 'Homme', '1978-08-17', 'ORAN', 'habib', 'حبيب', 'sbite ', 'aicha', 'سبيت ', 'عائشة', '074927', '2013-06-11', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'amaria ', 'houaria', 'عمارية ', 'houaria', '23/02/1989', 'ORAN', '-', NULL, NULL),
(102, '2019-06-17', 'Client normal', 'BENMILOUD', 'YAMINA', 'بن ميلود ', 'يمينة ', 'Femme', '1967-08-11', 'ORAN', 'ABDELKADER ', 'عبد القادر ', 'LARBI', 'NOURA ', 'لعربي', 'نورة ', '721413', '2008-11-11', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'bouraada', 'mohamed', 'بورعدة', 'mohamed', '12/10/1964', 'ORAN', '-', NULL, NULL),
(103, '2019-06-17', 'Client normal', 'machou ', 'yamina', 'معاشو', 'يمينة ', 'Homme', '1966-10-10', 'ORAN', 'machou ', 'معاشو', 'medjaji ', 'mama', 'مجاجي', 'مامة ', '126021', '2004-11-30', 'ORAN', 'ORAN', 'rue rakiba abdelkader ', '-', '-', '-', '-', 'Marié(e)', 'nouni', 'lounes', 'نوني', 'lounes', '14/09/1965', 'ORAN', '-', NULL, NULL),
(104, '2019-06-18', 'Client normal', 'bekki sbaa', 'belkhier', 'بكي سبع', 'بلخير ', 'Homme', '1971-11-01', 'ORAN', 'arbi', 'العربي', 'benomer ', 'rabhia ', 'بن عمر', 'رابحية ', '028192', '1971-11-01', 'ORAN', 'ORAN', 'zahna mascara', '-', '-', '-', '-', 'Marié(e)', 'reguig ', 'amina', 'رقيق', 'amina', '10/12/1990', 'ORAN', '-', NULL, NULL),
(105, '2019-06-18', 'Client normal', 'BERROUAI', 'Nora', 'براوي', 'نورة', 'Homme', '1969-06-04', 'ORAN', 'sadaa', 'سعادة', 'rouhaoui', 'fatima', 'روحاوي', 'فاطمة', '446631', '2004-07-07', 'ORAN', 'ORAN', 'cité mohamed boudiaf', '-', '-', '-', '-', 'Divorcé(e)', '', '', '', '', '', '', '', NULL, NULL),
(106, '2019-06-18', 'Client normal', 'Belghit', 'mohamed', 'بلغيت', 'محمد', 'Homme', '1973-01-18', 'ORAN', 'abdelghani', 'عبد الغني', 'berrabah', 'fatima', 'برابح', 'فاطمة', '930744', '2009-04-26', 'ORAN', 'ORAN', '-', 'conseiller de sport', '-', '-', '-', 'Marié(e)', 'belghit', 'naziha', '-', 'naziha', '11/02/1976', 'ORAN', '-', NULL, NULL),
(107, '2019-06-18', 'Client normal', 'SAADA', 'NOREDDINE', 'سعادة', 'نور الدين', 'Homme', '1973-09-26', 'ORAN', 'BOUDISSA', 'بوديسة', 'BOUZID', 'EZZANAH', 'بوزيد', 'الزانة', '26/09/1973', '2013-05-22', 'ORAN', 'ORAN', '-', '-', '-', '-', '-', 'Marié(e)', 'TALEB', 'NOURIA', 'طالب', 'NOURIA', '15/08/1984', 'ORAN', '-', NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `cliententreprise`
--

DROP TABLE IF EXISTS `cliententreprise`;
CREATE TABLE IF NOT EXISTS `cliententreprise` (
  `NomEntreprise` varchar(50) NOT NULL,
  `NomGérant` varchar(50) NOT NULL,
  `Ville` varchar(50) NOT NULL,
  `Adresse` varchar(50) NOT NULL,
  `Tel` varchar(50) NOT NULL,
  `NomContact` varchar(50) NOT NULL,
  `TelContact` varchar(50) NOT NULL,
  `Nrc` varchar(50) NOT NULL,
  `Nif` varchar(50) NOT NULL,
  `Na` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `cnl`
--

DROP TABLE IF EXISTS `cnl`;
CREATE TABLE IF NOT EXISTS `cnl` (
  `NumCNL` int(11) NOT NULL AUTO_INCREMENT,
  `NumPayement` int(255) NOT NULL,
  `Etat` text NOT NULL,
  `NumDeci` varchar(50) NOT NULL,
  `DateDeci` date DEFAULT NULL,
  `MontantCNL` decimal(50,2) DEFAULT NULL,
  `DateConservation` date DEFAULT NULL,
  `DateControle` date DEFAULT NULL,
  `DateReserve` date DEFAULT NULL,
  PRIMARY KEY (`NumCNL`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `cnl`
--

INSERT INTO `cnl` (`NumCNL`, `NumPayement`, `Etat`, `NumDeci`, `DateDeci`, `MontantCNL`, `DateConservation`, `DateControle`, `DateReserve`) VALUES
(1, 1, 'Admis+conservation', '31111974000277', '2014-08-27', '700000.00', '2014-08-27', NULL, NULL),
(2, 2, 'Admis+conservation', '14311110314000031', '2014-05-13', '700000.00', '2014-05-13', NULL, NULL),
(3, 3, 'Admis+conservation', '1431111031400031', '2014-05-13', '700000.00', '2014-05-13', NULL, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `commune`
--

DROP TABLE IF EXISTS `commune`;
CREATE TABLE IF NOT EXISTS `commune` (
  `IdCommune` int(255) NOT NULL AUTO_INCREMENT,
  `NomCommune` varchar(50) NOT NULL,
  `IdDaira` int(255) NOT NULL,
  PRIMARY KEY (`IdCommune`)
) ENGINE=MyISAM AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `commune`
--

INSERT INTO `commune` (`IdCommune`, `NomCommune`, `IdDaira`) VALUES
(1, 'Oran', 1),
(2, 'Aïn El Turk', 2),
(3, 'Bousfer', 2),
(4, 'El Ançor', 2),
(5, 'Mers El Kébir', 2),
(6, 'Arzew', 3),
(7, 'Sidi Benyebka', 3),
(8, 'Bethioua', 4),
(9, 'Marsat El Hadjadj', 4),
(10, 'Aïn El Bia', 4),
(11, 'Es Senia', 5),
(12, 'El Kerma', 5),
(13, 'Sidi Chami', 5),
(14, 'Bir El Djir', 6),
(15, 'Hassi Ben Okba', 6),
(16, 'Hassi Bounif', 6),
(17, 'Boutlélis', 7),
(18, 'Aïn El Kerma', 7),
(19, 'Misserghin', 7),
(20, 'Oued Tlelat', 8),
(21, 'Boufatis', 8),
(22, 'El Braya', 8),
(23, 'Tafraoui', 8),
(24, 'Gdyel', 9),
(25, 'Ben Freha', 9),
(26, 'Hassi Mefsoukh', 9);

-- --------------------------------------------------------

--
-- Structure de la table `conservation`
--

DROP TABLE IF EXISTS `conservation`;
CREATE TABLE IF NOT EXISTS `conservation` (
  `IdConservation` int(5) NOT NULL AUTO_INCREMENT,
  `NomConservation` varchar(50) NOT NULL,
  KEY `IdConservation` (`IdConservation`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `conservation`
--

INSERT INTO `conservation` (`IdConservation`, `NomConservation`) VALUES
(1, 'Oran ouest'),
(2, 'Oran est'),
(3, 'ES senia'),
(4, 'Ain Turk'),
(5, 'Bir el djir'),
(6, 'Arzew'),
(7, 'oued Tlilet'),
(8, 'Bir el djir');

-- --------------------------------------------------------

--
-- Structure de la table `convention`
--

DROP TABLE IF EXISTS `convention`;
CREATE TABLE IF NOT EXISTS `convention` (
  `NomProjet` varchar(50) NOT NULL,
  `RefProgramme` varchar(50) NOT NULL,
  `NumDec` varchar(50) NOT NULL,
  `DateDec` varchar(50) NOT NULL,
  `NumAW` varchar(50) NOT NULL,
  `DateAW` varchar(50) NOT NULL,
  `DateConv` varchar(50) NOT NULL,
  `NatureA` varchar(50) NOT NULL,
  `SupT` decimal(50,2) NOT NULL,
  `PrixU` decimal(50,2) NOT NULL,
  `Majoration` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `creditb`
--

DROP TABLE IF EXISTS `creditb`;
CREATE TABLE IF NOT EXISTS `creditb` (
  `NumCB` int(11) NOT NULL AUTO_INCREMENT,
  `NumPayement` int(255) NOT NULL,
  `NumConvBan` varchar(50) NOT NULL,
  `DateConv` date DEFAULT NULL,
  `NomBanque` varchar(50) NOT NULL,
  `BIC` varchar(50) NOT NULL,
  `MontantCb` decimal(50,2) DEFAULT NULL,
  PRIMARY KEY (`NumCB`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `creditb`
--

INSERT INTO `creditb` (`NumCB`, `NumPayement`, `NumConvBan`, `DateConv`, `NomBanque`, `BIC`, `MontantCb`) VALUES
(3, 2, '', NULL, '', '', NULL),
(2, 1, '0771378', '2015-07-23', 'BNA ', '963', '1410449.64'),
(5, 3, 'BDL', '2015-08-09', 'BDL ', 'AGENCE ES SENIA', '1396000.00');

-- --------------------------------------------------------

--
-- Structure de la table `daira`
--

DROP TABLE IF EXISTS `daira`;
CREATE TABLE IF NOT EXISTS `daira` (
  `IdDaira` int(255) NOT NULL AUTO_INCREMENT,
  `NomDaira` varchar(50) NOT NULL,
  `IdWilaya` varchar(50) NOT NULL,
  PRIMARY KEY (`IdDaira`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `daira`
--

INSERT INTO `daira` (`IdDaira`, `NomDaira`, `IdWilaya`) VALUES
(1, 'ORAN', '31'),
(2, 'Aïn El Turk', '31'),
(3, 'Arzew', '31'),
(4, 'Bethioua', '31'),
(5, 'Es Sénia', '31'),
(6, 'Bir El Djir', '31'),
(7, 'Boutlélis', '31'),
(8, 'Oued Tlelat', '31'),
(9, 'Gdyel', '31');

-- --------------------------------------------------------

--
-- Structure de la table `decisionr`
--

DROP TABLE IF EXISTS `decisionr`;
CREATE TABLE IF NOT EXISTS `decisionr` (
  `CodeDec` int(50) NOT NULL AUTO_INCREMENT,
  `DateEtabliDec` date DEFAULT NULL,
  `NumR` int(50) DEFAULT NULL,
  `DateR` date DEFAULT NULL,
  `RefP` int(11) DEFAULT NULL,
  `Etat` varchar(50) NOT NULL,
  PRIMARY KEY (`CodeDec`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `decisionr`
--

INSERT INTO `decisionr` (`CodeDec`, `DateEtabliDec`, `NumR`, `DateR`, `RefP`, `Etat`) VALUES
(1, '2015-07-20', 5868, '2015-07-29', 1, 'Validée');

-- --------------------------------------------------------

--
-- Structure de la table `demande`
--

DROP TABLE IF EXISTS `demande`;
CREATE TABLE IF NOT EXISTS `demande` (
  `NumDemande` int(50) NOT NULL AUTO_INCREMENT,
  `DateDemande` date NOT NULL,
  `RefClient` varchar(50) NOT NULL,
  `Motif` text NOT NULL,
  `NatureDemande` varchar(50) NOT NULL,
  `TypeDemande` varchar(50) NOT NULL,
  `StatutDemande` varchar(50) NOT NULL,
  `DateReponse` date DEFAULT NULL,
  PRIMARY KEY (`NumDemande`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `demande`
--

INSERT INTO `demande` (`NumDemande`, `DateDemande`, `RefClient`, `Motif`, `NatureDemande`, `TypeDemande`, `StatutDemande`, `DateReponse`) VALUES
(6, '2019-05-08', '1', 'Demande LPA', 'Achat', 'Logement', 'Acceptée', '2019-05-08'),
(7, '2019-05-08', '1', '', 'Régularisation', 'Logement', 'Acceptée', '2019-05-09');

-- --------------------------------------------------------

--
-- Structure de la table `demandestatut`
--

DROP TABLE IF EXISTS `demandestatut`;
CREATE TABLE IF NOT EXISTS `demandestatut` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Statut` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `demandestatut`
--

INSERT INTO `demandestatut` (`Id`, `Statut`) VALUES
(1, 'En Cours'),
(2, 'Acceptée'),
(3, 'Non Accepté'),
(4, 'Annulée');

-- --------------------------------------------------------

--
-- Structure de la table `edd`
--

DROP TABLE IF EXISTS `edd`;
CREATE TABLE IF NOT EXISTS `edd` (
  `NumEdd` int(255) NOT NULL AUTO_INCREMENT,
  `RefProjet` int(255) NOT NULL,
  `RefProgramme` int(255) NOT NULL,
  `DatePubli` date NOT NULL,
  `Volume` varchar(50) NOT NULL,
  `RefPubli` varchar(50) NOT NULL,
  `Conservation` varchar(50) NOT NULL,
  `Notaire` varchar(50) NOT NULL,
  `TelNotaire` varchar(50) NOT NULL,
  `AdresseNotaire` text NOT NULL,
  `NomPrenomGeo` varchar(50) NOT NULL,
  `AdresseGeo` text NOT NULL,
  `TelGeo` varchar(50) NOT NULL,
  `DateEtablis` date NOT NULL,
  `Redicte` varchar(50) NOT NULL,
  `NbrLog` varchar(50) DEFAULT NULL,
  `SuperficieLog` decimal(50,2) NOT NULL,
  `NbrLoc` varchar(50) DEFAULT NULL,
  `SuperficeiLoc` decimal(50,2) NOT NULL,
  `NbrBur` varchar(50) DEFAULT NULL,
  `SuperficieBur` decimal(50,2) NOT NULL,
  `NbrCave` varchar(50) DEFAULT NULL,
  `SuperficieCave` decimal(50,2) NOT NULL,
  `NbrEQ` varchar(50) DEFAULT NULL,
  `SuperficieEQ` decimal(50,2) NOT NULL,
  `NbrPS` varchar(50) DEFAULT NULL,
  `SuperficiePS` decimal(50,2) NOT NULL,
  PRIMARY KEY (`NumEdd`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `edd`
--

INSERT INTO `edd` (`NumEdd`, `RefProjet`, `RefProgramme`, `DatePubli`, `Volume`, `RefPubli`, `Conservation`, `Notaire`, `TelNotaire`, `AdresseNotaire`, `NomPrenomGeo`, `AdresseGeo`, `TelGeo`, `DateEtablis`, `Redicte`, `NbrLog`, `SuperficieLog`, `NbrLoc`, `SuperficeiLoc`, `NbrBur`, `SuperficieBur`, `NbrCave`, `SuperficieCave`, `NbrEQ`, `SuperficieEQ`, `NbrPS`, `SuperficiePS`) VALUES
(2, 1, 2, '2015-11-16', '520', '64', 'ES senia', 'Abd el kader Hamouda', '041 70 73 14', 'Hai el chahid fares el houwari 790 logts USTO - ORAN', 'Trache Abd el latif', 'Cité 1245 logts Bloc D/450 1E9 1er Etage USTO', '041 53 82 85', '2019-04-10', '160', '160', '11313.60', '', '0.00', NULL, '0.00', NULL, '0.00', NULL, '0.00', NULL, '0.00');

-- --------------------------------------------------------

--
-- Structure de la table `fnpos`
--

DROP TABLE IF EXISTS `fnpos`;
CREATE TABLE IF NOT EXISTS `fnpos` (
  `NumFNPOS` int(11) NOT NULL AUTO_INCREMENT,
  `NumPayement` int(255) NOT NULL,
  `NumDeciF` varchar(50) DEFAULT NULL,
  `DateDeciF` date DEFAULT NULL,
  `MontantFNPOS` decimal(50,2) DEFAULT NULL,
  PRIMARY KEY (`NumFNPOS`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `fnpos`
--

INSERT INTO `fnpos` (`NumFNPOS`, `NumPayement`, `NumDeciF`, `DateDeciF`, `MontantFNPOS`) VALUES
(5, 3, '1353/FNPOS/DRO/2015', '2015-06-18', '500000.00'),
(2, 1, '1353/FNPOS/DRO/2015', '2015-06-18', '500000.00'),
(4, 2, '1620857', '2016-01-31', '500000.00');

-- --------------------------------------------------------

--
-- Structure de la table `listeilot`
--

DROP TABLE IF EXISTS `listeilot`;
CREATE TABLE IF NOT EXISTS `listeilot` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NumIlot` varchar(50) NOT NULL,
  `RefProjet` int(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `listeilot`
--

INSERT INTO `listeilot` (`Id`, `NumIlot`, `RefProjet`) VALUES
(2, '1', 1),
(3, '2', 1),
(4, '3', 1);

-- --------------------------------------------------------

--
-- Structure de la table `lot`
--

DROP TABLE IF EXISTS `lot`;
CREATE TABLE IF NOT EXISTS `lot` (
  `RefProgramme` varchar(50) NOT NULL,
  `RefProjet` varchar(50) NOT NULL,
  `NumCC` varchar(50) NOT NULL,
  `NumIlot` varchar(50) NOT NULL,
  `NumLot` varchar(50) NOT NULL,
  `Sup` decimal(50,2) NOT NULL,
  `PrixHT` decimal(50,2) NOT NULL,
  `Tva` int(2) NOT NULL,
  `PrixTTC` decimal(50,2) NOT NULL,
  `LimiteNord` varchar(50) NOT NULL,
  `LimiteSud` varchar(50) NOT NULL,
  `LimiteEst` varchar(50) NOT NULL,
  `LimiteOuest` varchar(50) NOT NULL,
  `Etat` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `mainlevee`
--

DROP TABLE IF EXISTS `mainlevee`;
CREATE TABLE IF NOT EXISTS `mainlevee` (
  `CodeML` int(11) NOT NULL AUTO_INCREMENT,
  `DateEtabliML` date DEFAULT NULL,
  `NumML` int(50) DEFAULT NULL,
  `DateML` date DEFAULT NULL,
  `RefP` int(11) DEFAULT NULL,
  `Etat` varchar(50) NOT NULL,
  `NomNotaire` text NOT NULL,
  `AdresseNotaire` text NOT NULL,
  PRIMARY KEY (`CodeML`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `mainlevee`
--

INSERT INTO `mainlevee` (`CodeML`, `DateEtabliML`, `NumML`, `DateML`, `RefP`, `Etat`, `NomNotaire`, `AdresseNotaire`) VALUES
(1, '2016-02-10', 62, '2016-02-14', 1, 'Validée', 'Abd el kader Hamouda', 'Hai el chahid fares el houwari 790 logts USTO - ORAN'),
(2, '2016-02-15', 71, '2016-02-15', 2, 'Validée', 'Abd el kader Hamouda', 'Hai el chahid fares el houwari 790 logts USTO - ORAN'),
(3, '2019-06-24', 62, '2016-02-14', 3, 'Validée', 'Abd el kader Hamouda', 'Hai el chahid fares el houwari 790 logts USTO - ORAN');

-- --------------------------------------------------------

--
-- Structure de la table `naturedemande`
--

DROP TABLE IF EXISTS `naturedemande`;
CREATE TABLE IF NOT EXISTS `naturedemande` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nature` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `naturedemande`
--

INSERT INTO `naturedemande` (`Id`, `Nature`) VALUES
(1, 'Achat'),
(2, 'Régularisation'),
(3, 'Remboursement'),
(4, 'Désistement'),
(5, 'Payement');

-- --------------------------------------------------------

--
-- Structure de la table `naturefrais`
--

DROP TABLE IF EXISTS `naturefrais`;
CREATE TABLE IF NOT EXISTS `naturefrais` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NatureF` varchar(50) NOT NULL,
  `NatureP` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `naturefrais`
--

INSERT INTO `naturefrais` (`Id`, `NatureF`, `NatureP`) VALUES
(1, 'Frais de gestion', 'Autre Frais'),
(2, 'Frais local', 'Autre Frais'),
(3, 'Frais huissier justice', 'Autre Frais'),
(4, 'Frais pénalité de retard', 'Autre Frais'),
(5, 'Frais administrateur du bien', 'Autre Frais'),
(6, 'Frais branchement gaz ', 'Autre Frais'),
(7, 'Frais d\'électricité ', 'Autre Frais'),
(8, 'Frais bornage', 'Autre Frais');

-- --------------------------------------------------------

--
-- Structure de la table `naturepayement`
--

DROP TABLE IF EXISTS `naturepayement`;
CREATE TABLE IF NOT EXISTS `naturepayement` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NatureP` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `naturepayement`
--

INSERT INTO `naturepayement` (`Id`, `NatureP`) VALUES
(1, 'Paiement logement pour habitation'),
(2, 'Paiement coût foncier'),
(3, 'Paiement terrain a batir'),
(4, 'Paiement d\'une cave'),
(5, 'Paiement local'),
(6, 'Autre frais');

-- --------------------------------------------------------

--
-- Structure de la table `natureprogramme`
--

DROP TABLE IF EXISTS `natureprogramme`;
CREATE TABLE IF NOT EXISTS `natureprogramme` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NatureProgramme` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `natureprogramme`
--

INSERT INTO `natureprogramme` (`ID`, `NatureProgramme`) VALUES
(1, 'Terrain'),
(3, 'Logement');

-- --------------------------------------------------------

--
-- Structure de la table `notaire`
--

DROP TABLE IF EXISTS `notaire`;
CREATE TABLE IF NOT EXISTS `notaire` (
  `IdNotaire` int(50) NOT NULL AUTO_INCREMENT,
  `NomNotaire` text NOT NULL,
  `AdresseNotaire` text NOT NULL,
  `TelNotaire` text NOT NULL,
  PRIMARY KEY (`IdNotaire`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `notaire`
--

INSERT INTO `notaire` (`IdNotaire`, `NomNotaire`, `AdresseNotaire`, `TelNotaire`) VALUES
(1, 'Abd el kader Hamouda', 'Hai el chahid fares el houwari 790 logts USTO - ORAN', '041 70 73 14');

-- --------------------------------------------------------

--
-- Structure de la table `ov`
--

DROP TABLE IF EXISTS `ov`;
CREATE TABLE IF NOT EXISTS `ov` (
  `NumVerssement` int(255) NOT NULL AUTO_INCREMENT,
  `NumPayement` int(255) NOT NULL,
  `NumOV` varchar(50) DEFAULT NULL,
  `DateOV` date DEFAULT NULL,
  `DateEcheance` date DEFAULT NULL,
  `MontantAV` decimal(50,2) NOT NULL,
  `Etat` varchar(50) NOT NULL,
  `DateRecu` date DEFAULT NULL,
  `NumRecu` varchar(50) NOT NULL,
  `TypePayement` varchar(50) DEFAULT NULL,
  `NaturePayement` varchar(50) DEFAULT NULL,
  `NatureFrais` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`NumVerssement`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ov`
--

INSERT INTO `ov` (`NumVerssement`, `NumPayement`, `NumOV`, `DateOV`, `DateEcheance`, `MontantAV`, `Etat`, `DateRecu`, `NumRecu`, `TypePayement`, `NaturePayement`, `NatureFrais`) VALUES
(1, 1, '92', '2014-03-18', '2014-04-18', '500000.00', 'Terminé', '2014-03-26', '111723', 'تسديد بالشطر', 'Paiement logement pour habitation', ''),
(2, 1, '2816', '2015-08-17', '2015-08-17', '60000.00', 'Terminé', '2015-08-19', '101922', 'مصاريف أخرى', 'Autre frais', 'Frais de gestion'),
(3, 2, '43', '2014-03-18', '2014-04-18', '600000.00', 'Terminé', '2014-03-25', '101032', 'تسديد بالشطر', 'Paiement logement pour habitation', ''),
(4, 2, '1939', '2014-09-17', '2014-10-17', '400000.00', 'Terminé', '2014-09-21', '111247', 'تسديد بالشطر', 'Paiement logement pour habitation', ''),
(5, 2, '2563', '2015-06-22', '2015-07-22', '910449.64', 'Terminé', '2015-06-24', '111308', 'تسديد بالشطر', 'Paiement logement pour habitation', ''),
(6, 3, '201', '2014-03-26', '2014-04-26', '500000.00', 'Terminé', '2014-04-13', '152209', 'تسديد بالشطر', 'Paiement logement pour habitation', ''),
(7, 3, '2792', '2015-08-16', '2015-09-16', '893.02', 'Terminé', '2015-08-17', '103021', 'تسديد بالشطر', 'Paiement logement pour habitation', ''),
(8, 3, '2771', '2015-08-16', '2015-09-16', '60000.00', 'Terminé', '2015-08-17', '102934', 'مصاريف أخرى', 'Autre frais', 'Frais de gestion');

-- --------------------------------------------------------

--
-- Structure de la table `ovsolde`
--

DROP TABLE IF EXISTS `ovsolde`;
CREATE TABLE IF NOT EXISTS `ovsolde` (
  `IdOvSolde` int(50) NOT NULL AUTO_INCREMENT,
  `CodeClient` int(20) NOT NULL,
  `DateOvSolde` date DEFAULT NULL,
  `DateEchOvSolde` date DEFAULT NULL,
  `NomProgramme` text NOT NULL,
  `Montant` decimal(20,2) NOT NULL,
  `EtatOvSolde` varchar(11) NOT NULL,
  `DateRecu` date DEFAULT NULL,
  `NumRecu` text,
  PRIMARY KEY (`IdOvSolde`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ovsolde`
--

INSERT INTO `ovsolde` (`IdOvSolde`, `CodeClient`, `DateOvSolde`, `DateEchOvSolde`, `NomProgramme`, `Montant`, `EtatOvSolde`, `DateRecu`, `NumRecu`) VALUES
(1, 1, '2019-07-09', '2019-07-31', 'LPA 160 logts', '500000.00', 'Terminé', '2019-07-25', '12336699'),
(2, 1, '2019-07-09', '2019-07-31', 'LPA 160 logts', '50000.00', 'Terminé', '2019-07-25', '12336699');

-- --------------------------------------------------------

--
-- Structure de la table `payement`
--

DROP TABLE IF EXISTS `payement`;
CREATE TABLE IF NOT EXISTS `payement` (
  `NumPayement` int(255) NOT NULL AUTO_INCREMENT,
  `DatePayement` date NOT NULL,
  `NumAttribution` int(255) NOT NULL,
  `NumClient` int(255) NOT NULL,
  `NomClient` varchar(50) NOT NULL,
  `PrenomClient` varchar(50) NOT NULL,
  `DateNaissance` varchar(50) NOT NULL,
  `NumCni` varchar(50) NOT NULL,
  `RefProjet` int(255) NOT NULL,
  `NomProjet` varchar(50) NOT NULL,
  `RefProgramme` int(255) NOT NULL,
  `NomProgramme` varchar(50) NOT NULL,
  `NumIlot` varchar(50) NOT NULL,
  `NumLot` varchar(50) NOT NULL,
  `TypeBien` varchar(50) NOT NULL,
  `NumBloc` varchar(50) NOT NULL,
  `Niveau` varchar(50) NOT NULL,
  `NbrP` varchar(50) NOT NULL,
  `SurH` decimal(50,2) NOT NULL,
  `SurU` decimal(50,2) NOT NULL,
  `MontantTotal` decimal(50,2) NOT NULL,
  `MontantVerse` decimal(50,2) NOT NULL,
  `Reste` decimal(50,2) NOT NULL,
  `EtatFraisGestion` text,
  PRIMARY KEY (`NumPayement`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `payement`
--

INSERT INTO `payement` (`NumPayement`, `DatePayement`, `NumAttribution`, `NumClient`, `NomClient`, `PrenomClient`, `DateNaissance`, `NumCni`, `RefProjet`, `NomProjet`, `RefProgramme`, `NomProgramme`, `NumIlot`, `NumLot`, `TypeBien`, `NumBloc`, `Niveau`, `NbrP`, `SurH`, `SurU`, `MontantTotal`, `MontantVerse`, `Reste`, `EtatFraisGestion`) VALUES
(1, '2019-06-23', 1, 83, 'benabdallah ', 'khedidja', '12/06/1974', '083371', 1, 'Oued Tlelat-ZUHN', 2, 'LPA 160 logts', '1', '16', 'Logement', '8', '3', 'F3', '71.13', '78.21', '3110449.64', '3110449.64', '0.00', 'Payé'),
(2, '2019-06-24', 2, 107, 'SAADA', 'NOREDDINE', '26/09/1973', '26/09/1973', 1, 'Oued Tlelat-ZUHN', 2, 'LPA 160 logts', '1', '13', 'Logement', '8', '3', 'F3', '71.13', '78.21', '3110449.64', '3110449.64', '0.00', 'Payé'),
(3, '2019-06-24', 3, 84, 'cherchar', 'mohamed', '01/04/1983', '926806', 1, 'Oued Tlelat-ZUHN', 2, 'LPA 160 logts', '1', '19', 'Logement', '8', '4', 'F3', '70.82', '81.05', '3096893.63', '3096893.02', '0.00', 'Payé');

-- --------------------------------------------------------

--
-- Structure de la table `permilotir`
--

DROP TABLE IF EXISTS `permilotir`;
CREATE TABLE IF NOT EXISTS `permilotir` (
  `NumPL` int(255) NOT NULL AUTO_INCREMENT,
  `DatePL` varchar(50) NOT NULL,
  `NbrIlot` varchar(50) NOT NULL,
  `NbrLots` varchar(50) NOT NULL,
  `SurfaceBrute` decimal(50,0) NOT NULL,
  `SuperficieCG` decimal(50,2) NOT NULL,
  `SuperficieVoiries` decimal(50,2) NOT NULL,
  `SuperficieEV` decimal(50,2) NOT NULL,
  `SuperficieEquip` decimal(50,2) NOT NULL,
  `SuperficieAmenag` decimal(50,2) NOT NULL,
  `AutreSupercie` decimal(50,2) NOT NULL,
  `RefProjet` int(255) NOT NULL,
  PRIMARY KEY (`NumPL`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `permisdeconstruire`
--

DROP TABLE IF EXISTS `permisdeconstruire`;
CREATE TABLE IF NOT EXISTS `permisdeconstruire` (
  `NumPermis` int(255) NOT NULL AUTO_INCREMENT,
  `DatePermisC` date NOT NULL,
  `NbrLog` varchar(50) NOT NULL,
  `SupLog` decimal(50,2) NOT NULL,
  `NbrLoc` varchar(50) NOT NULL,
  `SupLoc` decimal(50,2) NOT NULL,
  `NbrBur` varchar(50) NOT NULL,
  `SupBur` decimal(50,2) NOT NULL,
  `NbrCave` varchar(50) NOT NULL,
  `SupCave` decimal(50,2) NOT NULL,
  `NbrCC` varchar(50) NOT NULL,
  `SupCC` decimal(50,2) NOT NULL,
  `NbrPS` varchar(50) NOT NULL,
  `SupPS` decimal(50,2) NOT NULL,
  `RefProgramme` int(255) NOT NULL,
  `RefProjet` int(255) NOT NULL,
  PRIMARY KEY (`NumPermis`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `permisdeconstruire`
--

INSERT INTO `permisdeconstruire` (`NumPermis`, `DatePermisC`, `NbrLog`, `SupLog`, `NbrLoc`, `SupLoc`, `NbrBur`, `SupBur`, `NbrCave`, `SupCave`, `NbrCC`, `SupCC`, `NbrPS`, `SupPS`, `RefProgramme`, `RefProjet`) VALUES
(1, '2014-06-23', '160', '11313.60', '', '0.00', '', '0.00', '', '0.00', '', '0.00', '', '0.00', 2, 1);

-- --------------------------------------------------------

--
-- Structure de la table `programme`
--

DROP TABLE IF EXISTS `programme`;
CREATE TABLE IF NOT EXISTS `programme` (
  `RefProgramme` int(255) NOT NULL AUTO_INCREMENT,
  `RefProjet` int(255) NOT NULL,
  `NomProgramme` varchar(50) NOT NULL,
  `Site` varchar(50) NOT NULL,
  `Daira` varchar(50) NOT NULL,
  `Commune` varchar(50) NOT NULL,
  `NatureProgramme` varchar(50) NOT NULL,
  `TypeProgramme` varchar(50) NOT NULL,
  `NombreBiens` varchar(50) NOT NULL,
  `Superficie` decimal(50,4) NOT NULL,
  `TypeVente` varchar(50) NOT NULL,
  `CoutFoncier` decimal(50,2) NOT NULL,
  `TVA` int(50) NOT NULL,
  `CoutFoncierTTC` decimal(50,2) NOT NULL,
  `PrixM2` decimal(50,2) NOT NULL,
  `FraisAdm` decimal(50,2) NOT NULL,
  PRIMARY KEY (`RefProgramme`),
  KEY `RefProgramme` (`RefProgramme`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `programme`
--

INSERT INTO `programme` (`RefProgramme`, `RefProjet`, `NomProgramme`, `Site`, `Daira`, `Commune`, `NatureProgramme`, `TypeProgramme`, `NombreBiens`, `Superficie`, `TypeVente`, `CoutFoncier`, `TVA`, `CoutFoncierTTC`, `PrixM2`, `FraisAdm`) VALUES
(2, 1, 'LPA 160 logts', 'Oued Tlelat-ZUHN', 'Oued Tlelat', 'Oued Tlelat', 'Logement', 'LPA', '160', '38553.0000', 'Vente par m²', '3187.25', 17, '3729.08', '37383.18', '60000.00');

-- --------------------------------------------------------

--
-- Structure de la table `projet`
--

DROP TABLE IF EXISTS `projet`;
CREATE TABLE IF NOT EXISTS `projet` (
  `RefProjet` int(255) NOT NULL AUTO_INCREMENT,
  `NomProjet` text NOT NULL,
  `ProjetMaitre` varchar(50) NOT NULL,
  `Vendeur` varchar(50) NOT NULL,
  `Wilaya` varchar(50) NOT NULL,
  `Daira` varchar(50) NOT NULL,
  `Commune` varchar(50) NOT NULL,
  `Payement` varchar(50) NOT NULL,
  `Superficie` decimal(50,2) NOT NULL,
  `LimiteNord` text NOT NULL,
  `LimiteEst` text NOT NULL,
  `LimiteOuest` text NOT NULL,
  `LimiteSud` text NOT NULL,
  `MontantCessionB` decimal(50,2) NOT NULL,
  `MontantCession` decimal(50,2) NOT NULL,
  `NumRecu` varchar(50) NOT NULL,
  `DateRecu` date NOT NULL,
  PRIMARY KEY (`RefProjet`),
  KEY `RefProjet` (`RefProjet`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `projet`
--

INSERT INTO `projet` (`RefProjet`, `NomProjet`, `ProjetMaitre`, `Vendeur`, `Wilaya`, `Daira`, `Commune`, `Payement`, `Superficie`, `LimiteNord`, `LimiteEst`, `LimiteOuest`, `LimiteSud`, `MontantCessionB`, `MontantCession`, `NumRecu`, `DateRecu`) VALUES
(1, 'Oued Tlelat-ZUHN', 'Oued Tlelat-ZUHN', 'Direction des domaine', 'ORAN', 'Oued Tlelat', 'Oued Tlelat', 'Effectué', '471540.00', 'RN No 04 Oued Tlelat', 'Surplus du terrain', 'Oued Tlelat', 'Chemin vicinal et surplus du terrain', '27245890.00', '27790807.80', '', '1995-03-08');

-- --------------------------------------------------------

--
-- Structure de la table `projetmaitre`
--

DROP TABLE IF EXISTS `projetmaitre`;
CREATE TABLE IF NOT EXISTS `projetmaitre` (
  `NomProjetM` varchar(50) NOT NULL,
  UNIQUE KEY `NomProjetM` (`NomProjetM`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `projetmaitre`
--

INSERT INTO `projetmaitre` (`NomProjetM`) VALUES
('LPA'),
('Oued Tlelat-ZUHN');

-- --------------------------------------------------------

--
-- Structure de la table `societe`
--

DROP TABLE IF EXISTS `societe`;
CREATE TABLE IF NOT EXISTS `societe` (
  `IdSociete` int(11) NOT NULL AUTO_INCREMENT,
  `CompteB` text NOT NULL,
  `AdresseB` text NOT NULL,
  PRIMARY KEY (`IdSociete`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `societe`
--

INSERT INTO `societe` (`IdSociete`, `CompteB`, `AdresseB`) VALUES
(1, 'وكالة أحمد زبانة  144138 758 401 00420 005 BDL  ', 'رقم 04 شارع بوقطاية عبد الله ( شارع أوزنام سابق ) وهران');

-- --------------------------------------------------------

--
-- Structure de la table `tva`
--

DROP TABLE IF EXISTS `tva`;
CREATE TABLE IF NOT EXISTS `tva` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ValeurTva` int(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `tva`
--

INSERT INTO `tva` (`Id`, `ValeurTva`) VALUES
(1, 19),
(2, 17),
(3, 21),
(4, 7);

-- --------------------------------------------------------

--
-- Structure de la table `typebiens`
--

DROP TABLE IF EXISTS `typebiens`;
CREATE TABLE IF NOT EXISTS `typebiens` (
  `Id` int(50) NOT NULL AUTO_INCREMENT,
  `Type` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `typebiens`
--

INSERT INTO `typebiens` (`Id`, `Type`) VALUES
(1, 'Terrain'),
(2, 'Logement'),
(3, 'Bureau'),
(4, 'Cave');

-- --------------------------------------------------------

--
-- Structure de la table `typedemande`
--

DROP TABLE IF EXISTS `typedemande`;
CREATE TABLE IF NOT EXISTS `typedemande` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `typedemande`
--

INSERT INTO `typedemande` (`Id`, `Type`) VALUES
(1, 'Terrain'),
(2, 'Logement');

-- --------------------------------------------------------

--
-- Structure de la table `typeprogramme`
--

DROP TABLE IF EXISTS `typeprogramme`;
CREATE TABLE IF NOT EXISTS `typeprogramme` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TypeProgramme` varchar(50) NOT NULL,
  `NatureProgramme` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=45 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `typeprogramme`
--

INSERT INTO `typeprogramme` (`ID`, `TypeProgramme`, `NatureProgramme`) VALUES
(1, 'Social', 'Lotissement'),
(2, 'Promoionnel', 'Lotissement'),
(3, 'Transfert de gestion', 'Lotissement'),
(4, 'Commercial', 'Local'),
(5, 'Professionnel', 'Local'),
(6, 'Centre commercial', 'Local'),
(7, 'Cave', 'Local'),
(8, 'CNL', 'Logement'),
(9, 'LPA', 'Logement'),
(23, 'Cave/Sous-sol', 'Logement'),
(22, 'Local', 'Logement'),
(12, 'Bureau', 'Logement'),
(13, 'Relogement', 'RHP'),
(14, 'Restructuration', 'RHP'),
(15, 'Prévention', 'RHP'),
(16, 'Recasement', 'RHP'),
(17, 'Zone d activité', 'Terrain Industriel'),
(18, 'Zone depot', 'Terrain Industriel'),
(19, 'Zone touristique', 'Terrain Industriel'),
(20, 'Zone des sièges', 'Terrain Industriel'),
(21, 'Show room', 'Terrain Industriel'),
(28, 'RHP Relogement', 'Logement'),
(26, 'Equipement', 'Terrain'),
(29, 'LSP', 'Logement'),
(33, 'Promotionnel Semi Collectif', 'Logement'),
(38, 'Social', 'Terrain'),
(40, 'Investissement', 'Terrain'),
(35, 'Promotionnel Individuel', 'Logement'),
(36, 'Promotionnel Collectif', 'Logement'),
(39, 'Promotionnel', 'Terrain'),
(41, 'Fonal', 'Terrain'),
(44, 'RHP', 'Terrain');

-- --------------------------------------------------------

--
-- Structure de la table `typevente`
--

DROP TABLE IF EXISTS `typevente`;
CREATE TABLE IF NOT EXISTS `typevente` (
  `Id` int(50) NOT NULL AUTO_INCREMENT,
  `Type` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `typevente`
--

INSERT INTO `typevente` (`Id`, `Type`) VALUES
(1, 'Regularisation'),
(2, 'Vente Libre'),
(3, 'Vente par Adjudication');

-- --------------------------------------------------------

--
-- Structure de la table `vsp`
--

DROP TABLE IF EXISTS `vsp`;
CREATE TABLE IF NOT EXISTS `vsp` (
  `CodeVSP` int(50) NOT NULL AUTO_INCREMENT,
  `DateEtabliVSP` date DEFAULT NULL,
  `NumVSP` int(50) DEFAULT NULL,
  `DateVSP` date DEFAULT NULL,
  `RefP` int(50) DEFAULT NULL,
  `Etat` varchar(50) NOT NULL,
  `NomNotaire` text NOT NULL,
  `AdresseNotaire` text NOT NULL,
  PRIMARY KEY (`CodeVSP`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `vsp`
--

INSERT INTO `vsp` (`CodeVSP`, `DateEtabliVSP`, `NumVSP`, `DateVSP`, `RefP`, `Etat`, `NomNotaire`, `AdresseNotaire`) VALUES
(1, '2019-06-27', 21213, '2019-06-30', 1, 'Validée', 'Abd el kader Hamouda', 'Hai el chahid fares el houwari 790 logts USTO - ORAN'),
(2, '2019-06-27', 998566, '2019-06-30', 1, 'Validée', 'Abd el kader Hamouda', 'Hai el chahid fares el houwari 790 logts USTO - ORAN');

-- --------------------------------------------------------

--
-- Structure de la table `wilaya`
--

DROP TABLE IF EXISTS `wilaya`;
CREATE TABLE IF NOT EXISTS `wilaya` (
  `NumWilaya` varchar(50) NOT NULL,
  `NomWilaya` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `wilaya`
--

INSERT INTO `wilaya` (`NumWilaya`, `NomWilaya`) VALUES
('31', 'ORAN'),
('16', 'ALGER'),
('22', 'SIDI BEL ABBES');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
