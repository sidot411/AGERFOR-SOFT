-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  Dim 05 mai 2019 à 14:20
-- Version du serveur :  5.7.23
-- Version de PHP :  7.2.10

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
  PRIMARY KEY (`NumA`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `attribution`
--

INSERT INTO `attribution` (`NumA`, `DateAttribution`, `NumClient`, `NumProjet`, `NumProgramme`, `NatureProgramme`, `TypeBien`, `NumIlot`, `Numlot`, `NumBloc`, `IdBien`) VALUES
(4, '2019-04-18', '1', '1', '2', 'Logement', 'Logement', '1', '1', '1', 1),
(5, '2019-04-18', '1', '1', '2', 'Logement', 'Logement', '1', '2', '1', 2),
(6, '2019-04-18', '1', '1', '2', 'Logement', 'Logement', '1', '5', '1', 5);

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
  PRIMARY KEY (`NumEdd`,`Numlot`,`NumBloc`,`Niveau`),
  UNIQUE KEY `UNIQUE` (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=61 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `biens`
--

INSERT INTO `biens` (`Id`, `RefProgramme`, `RefProjet`, `NumEdd`, `NumIlot`, `TypeBien`, `Numlot`, `NumBloc`, `Niveau`, `NbrPiece`, `SurH`, `SurU`, `PrixHT`, `Tva`, `PrixTTC`, `LimiteNord`, `LimiteSud`, `LimiteEst`, `LimiteOuest`, `Etat`) VALUES
(1, 2, 1, 2, '1', 'Logement', '1', '1', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Réservé'),
(2, 2, 1, 2, '1', 'Logement', '2', '1', '0', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Réservé'),
(3, 2, 1, 2, '1', 'Logement', '3', '1', '0', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre'),
(4, 2, 1, 2, '1', 'Logement', '4', '1', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre'),
(5, 2, 1, 2, '1', 'Logement', '5', '1', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Réservé'),
(6, 2, 1, 2, '1', 'Logement', '6', '1', '1', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre'),
(7, 2, 1, 2, '1', 'Logement', '7', '1', '1', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre'),
(8, 2, 1, 2, '1', 'Logement', '8', '1', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre'),
(9, 2, 1, 2, '1', 'Logement', '9', '1', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre'),
(10, 2, 1, 2, '1', 'Logement', '10', '1', '2', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre'),
(11, 2, 1, 2, '1', 'Logement', '11', '1', '2', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre'),
(12, 2, 1, 2, '1', 'Logement', '12', '1', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre'),
(13, 2, 1, 2, '1', 'Logement', '13', '1', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre'),
(14, 2, 1, 2, '1', 'Logement', '14', '1', '3', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre'),
(15, 2, 1, 2, '1', 'Logement', '15', '1', '3', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre'),
(16, 2, 1, 2, '1', 'Logement', '16', '1', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre'),
(17, 2, 1, 2, '1', 'Logement', '17', '1', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre'),
(18, 2, 1, 2, '1', 'Logement', '18', '1', '4', 'F3', '70.82', '75.43', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre'),
(19, 2, 1, 2, '1', 'Logement', '19', '1', '4', 'F3', '71.82', '81.05', '37383.18', 7, '3140622.71', '', '', '', '', 'Libre'),
(20, 2, 1, 2, '1', 'Logement', '20', '1', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre'),
(21, 2, 1, 2, '1', 'Logement', '21', '1', '5', 'F3', '71.27', '81.79', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre'),
(22, 2, 1, 2, '1', 'Logement', '22', '1', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre'),
(23, 2, 1, 2, '1', 'Logement', '23', '1', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre'),
(24, 2, 1, 2, '1', 'Logement', '24', '1', '5', 'F3', '71.22', '81.74', '37383.18', 7, '3114385.26', '', '', '', '', 'Libre'),
(25, 2, 1, 2, '1', 'Logement', '1', '2', '0', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(26, 2, 1, 2, '1', 'Logement', '2', '2', '0', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(27, 2, 1, 2, '1', 'Logement', '3', '2', '1', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(28, 2, 1, 2, '1', 'Logement', '4', '2', '1', 'F3', '71.78', '74.17', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(29, 2, 1, 2, '1', 'Logement', '5', '2', '2', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(30, 2, 1, 2, '1', 'Logement', '6', '2', '2', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(31, 2, 1, 2, '1', 'Logement', '7', '2', '3', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(32, 2, 1, 2, '1', 'Logement', '8', '2', '3', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(33, 2, 1, 2, '1', 'Logement', '9', '2', '4', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(34, 2, 1, 2, '1', 'Logement', '10', '2', '4', 'F3', '71.78', '76.88', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(35, 2, 1, 2, '1', 'Logement', '11', '2', '5', 'F3', '71.78', '79.58', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(36, 2, 1, 2, '1', 'Logement', '12', '2', '5', 'F3', '71.78', '79.58', '37383.18', 7, '3138873.55', '', '', '', '', 'Libre'),
(37, 2, 1, 2, '1', 'Logement', '1', '3', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre'),
(38, 2, 1, 2, '1', 'Logement', '2', '3', '0', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre'),
(39, 2, 1, 2, '1', 'Logement', '3', '3', '0', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre'),
(40, 2, 1, 2, '1', 'Logement', '4', '3', '0', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre'),
(41, 2, 1, 2, '1', 'Logement', '5', '3', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre'),
(42, 2, 1, 2, '1', 'Logement', '6', '3', '1', 'F3', '70.64', '72.94', '37383.18', 7, '3089022.39', '', '', '', '', 'Libre'),
(43, 2, 1, 2, '1', 'Logement', '7', '3', '1', 'F3', '70.44', '72.74', '37383.18', 7, '3080276.58', '', '', '', '', 'Libre'),
(44, 2, 1, 2, '1', 'Logement', '8', '3', '1', 'F3', '70.79', '75.56', '37383.18', 7, '3095581.76', '', '', '', '', 'Libre'),
(45, 2, 1, 2, '1', 'Logement', '9', '3', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre'),
(46, 2, 1, 2, '1', 'Logement', '10', '3', '2', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre'),
(47, 2, 1, 2, '1', 'Logement', '11', '3', '2', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre'),
(48, 2, 1, 2, '1', 'Logement', '12', '3', '2', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre'),
(49, 2, 1, 2, '1', 'Logement', '13', '3', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre'),
(50, 2, 1, 2, '1', 'Logement', '14', '3', '3', 'F3', '71.62', '76.23', '37383.18', 7, '3131876.90', '', '', '', '', 'Libre'),
(51, 2, 1, 2, '1', 'Logement', '15', '3', '3', 'F3', '70.63', '75.24', '37383.18', 7, '3088585.10', '', '', '', '', 'Libre'),
(52, 2, 1, 2, '1', 'Logement', '16', '3', '3', 'F3', '71.13', '78.21', '37383.18', 7, '3110449.65', '', '', '', '', 'Libre'),
(53, 2, 1, 2, '1', 'Logement', '17', '3', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre'),
(54, 2, 1, 2, '1', 'Logement', '18', '3', '4', 'F3', '71.82', '81.05', '37383.18', 7, '3140622.71', '', '', '', '', 'Libre'),
(55, 2, 1, 2, '1', 'Logement', '19', '3', '4', 'F3', '70.82', '75.43', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre'),
(56, 2, 1, 2, '1', 'Logement', '20', '3', '4', 'F3', '71.27', '78.35', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre'),
(57, 2, 1, 2, '1', 'Logement', '21', '3', '5', 'F3', '71.22', '81.74', '37383.18', 7, '3114385.26', '', '', '', '', 'Libre'),
(58, 2, 1, 2, '1', 'Logement', '22', '3', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre'),
(59, 2, 1, 2, '1', 'Logement', '23', '3', '5', 'F3', '70.82', '77.85', '37383.18', 7, '3096893.63', '', '', '', '', 'Libre'),
(60, 2, 1, 2, '1', 'Logement', '24', '3', '5', 'F3', '71.27', '81.79', '37383.18', 7, '3116571.72', '', '', '', '', 'Libre');

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
  PRIMARY KEY (`NumClient`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`NumClient`, `DateCreation`, `Nom`, `Prenom`, `NomAr`, `PrenomAr`, `Sexe`, `DateNaissance`, `LieuNaissance`, `PrenomPere`, `PrenomPereAr`, `NomMere`, `PrenomMere`, `NomMereAr`, `PrenomMereAr`, `Cni`, `DateCni`, `LieuCni`, `Ville`, `Adress`, `Proffession`, `Tel`, `NomContact`, `TelContact`, `Situation`, `NomConj`, `PrénomConj`, `NomConjAR`, `PrenomConjAR`, `DateNaissanceConj`, `LieuNaissanceConj`, `ProfessionConj`) VALUES
(1, '2019-04-16', 'KHIAT', 'SIDAHMED', 'خياط', 'سيدأحمد', 'Homme', '01/03/2019', 'ORAN', 'MOUNIR', 'منير', 'FRIOUI', 'ZOULIKHA', 'فريوي', 'زليخة', '112233667', '2019-03-14', 'ORAN', 'ORAN', 'N°265 SIDI EL KHIAR ES-SENIA', 'INFORMATICIEN', '0661934408', 'MOUNIR', '0661934408', 'Célibataire', '', '', '', '', '', '', ''),
(2, '2019-04-16', 'BOUZOUINA', 'SALIM', 'بوزوينة', 'سليم', 'Homme', '1977-02-12', 'ORAN', 'BELKHIR', 'بلخير', 'ABD EL MALEK', 'FATIMA', 'عبد المالك', 'فاطمة', '502948', '2013-01-15', 'ORAN', 'ORAN', 'Rue korine AEK Oued Tlelate ', 'METREUR', '/', 'BELKHIR', '/', 'Marié(e)', 'KHALTI', 'SOUAD', 'خالتي', 'SOUAD', '25/06/1984', 'ORAN', 'SANS '),
(3, '2019-04-16', 'MALEK CHELIH', 'TEWFIK', 'مالك شليح', 'توفيق', 'Homme', '1978-01-07', 'ORAN', 'ABD EL KADER', 'عبد القادر', 'MECHRI', 'FATIMA', 'مشري', 'فاطمة', '659932', '2004-01-24', 'ORAN', 'ORAN', '27 Rue ibrahim ben ahmed Oued telilet', 'Enseignant', '/', 'MECHRI', '/', 'Célibataire', '', '', '', '', '', '', ''),
(4, '2019-04-16', 'BENLASRI', 'MUSTAFA', 'بن العسري', 'مصطفى', 'Homme', '1984-08-24', 'ORAN', 'ABDALLAH', 'عبد الله', 'FEKIR', 'RAHMA', 'فقير', 'رحمة', '540087', '2010-08-08', 'ORAN', 'ORAN', 'Cité 140 log Oued tlelat', 'Commerçant ', '/', 'ABDALLAH', '/', 'Célibataire', '', '', '', '', '', '', ''),
(5, '2019-04-16', 'BELLACHHEB', 'SOMIA', 'بلشهب', 'سمية', 'Femme', '02/12/1981', 'ORAN', 'ABD EL KADER', 'عبد القادر', 'MOUALI MHAJI', 'HADDA', 'موالي مهاجي', 'حدة', '577503', '2011-12-22', 'ORAN', 'ORAN', 'Cité Hammou boutlelis Oued tlelat', 'Secraitaire', '/', 'ABD EL KADER', '/', 'Marié(e)', 'SGHIR', 'HOUARI', 'سغير', 'HOUARI', '12-10-1969', 'ORAN', 'Agent de sécurité');

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
  `NumDeci` varchar(50) NOT NULL,
  `DateDeci` date NOT NULL,
  `MontantCNL` decimal(50,2) NOT NULL,
  `DateRecu` date NOT NULL,
  `NumRecu` varchar(50) NOT NULL,
  PRIMARY KEY (`NumCNL`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

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
  `DateConv` date NOT NULL,
  `NomBanque` varchar(50) NOT NULL,
  `BIC` varchar(50) NOT NULL,
  `MontantCb` decimal(50,2) NOT NULL,
  PRIMARY KEY (`NumCB`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

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
  PRIMARY KEY (`NumDemande`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

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
  `NbrLog` varchar(50) NOT NULL,
  `SuperficieLog` decimal(50,2) NOT NULL,
  `NbrLoc` varchar(50) NOT NULL,
  `SuperficeiLoc` decimal(50,2) NOT NULL,
  `NbrBur` varchar(50) NOT NULL,
  `SuperficieBur` decimal(50,2) NOT NULL,
  `NbrCave` varchar(50) NOT NULL,
  `SuperficieCave` decimal(50,2) NOT NULL,
  `NbrEQ` varchar(50) NOT NULL,
  `SuperficieEQ` decimal(50,2) NOT NULL,
  `NbrPS` varchar(50) NOT NULL,
  `SuperficiePS` decimal(50,2) NOT NULL,
  PRIMARY KEY (`NumEdd`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `edd`
--

INSERT INTO `edd` (`NumEdd`, `RefProjet`, `RefProgramme`, `DatePubli`, `Volume`, `RefPubli`, `Conservation`, `Notaire`, `TelNotaire`, `AdresseNotaire`, `NomPrenomGeo`, `AdresseGeo`, `TelGeo`, `DateEtablis`, `Redicte`, `NbrLog`, `SuperficieLog`, `NbrLoc`, `SuperficeiLoc`, `NbrBur`, `SuperficieBur`, `NbrCave`, `SuperficieCave`, `NbrEQ`, `SuperficieEQ`, `NbrPS`, `SuperficiePS`) VALUES
(2, 1, 2, '2015-11-16', '520', '64', 'ES senia', 'Abd el kader Hamouda', '041 70 73 14', 'Hai el chahid fares el houwari 790 logts USTO - ORAN', 'Trache Abd el latif', 'Cité 1245 logts Bloc D/450 1E9 1er Etage USTO', '041 53 82 85', '2019-04-10', '160', '141233', '11313.60', '', '0.00', '', '0.00', '', '0.00', '', '0.00', '', '0.00');

-- --------------------------------------------------------

--
-- Structure de la table `fnpos`
--

DROP TABLE IF EXISTS `fnpos`;
CREATE TABLE IF NOT EXISTS `fnpos` (
  `NumFNPOS` int(11) NOT NULL AUTO_INCREMENT,
  `NumPayement` int(255) NOT NULL,
  `NumDeciF` varchar(50) NOT NULL,
  `DateDeciF` date NOT NULL,
  `MontantFNPOS` decimal(50,2) NOT NULL,
  `DateRecu` date NOT NULL,
  `NumRecu` varchar(50) NOT NULL,
  PRIMARY KEY (`NumFNPOS`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

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
-- Structure de la table `ov`
--

DROP TABLE IF EXISTS `ov`;
CREATE TABLE IF NOT EXISTS `ov` (
  `NumVerssement` int(255) NOT NULL AUTO_INCREMENT,
  `NumPayement` int(255) NOT NULL,
  `NumOV` varchar(50) NOT NULL,
  `DateOV` varchar(50) NOT NULL,
  `DateEcheance` varchar(50) NOT NULL,
  `MontantAV` decimal(50,2) NOT NULL,
  `Etat` varchar(50) NOT NULL,
  `DateRecu` varchar(50) NOT NULL,
  `NumRecu` varchar(50) NOT NULL,
  PRIMARY KEY (`NumVerssement`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

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
  PRIMARY KEY (`NumPayement`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `payement`
--

INSERT INTO `payement` (`NumPayement`, `DatePayement`, `NumAttribution`, `NumClient`, `NomClient`, `PrenomClient`, `DateNaissance`, `NumCni`, `RefProjet`, `NomProjet`, `RefProgramme`, `NomProgramme`, `NumIlot`, `NumLot`, `TypeBien`, `NumBloc`, `Niveau`, `NbrP`, `SurH`, `SurU`, `MontantTotal`, `MontantVerse`, `Reste`) VALUES
(2, '2019-04-18', 1, 1, 'KHIAT', 'SIDAHMED', '01/03/2019', '112233667', 1, 'Oued Tlelat-ZUHN', 2, 'LPA 160 logts', '1', '1', 'Logement', '1', '0', 'F3', '70.79', '75.56', '3095581.76', '0.00', '3095581.76'),
(3, '2019-04-18', 5, 1, 'KHIAT', 'SIDAHMED', '01/03/2019', '112233667', 1, 'Oued Tlelat-ZUHN', 2, 'LPA 160 logts', '1', '2', 'Logement', '1', '0', 'F3', '70.44', '72.74', '3080276.58', '0.00', '3080276.58'),
(4, '2019-04-18', 6, 1, 'KHIAT', 'SIDAHMED', '01/03/2019', '112233667', 1, 'Oued Tlelat-ZUHN', 2, 'LPA 160 logts', '1', '5', 'Logement', '1', '1', 'F3', '70.79', '75.56', '3095581.76', '0.00', '3095581.76');

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
  PRIMARY KEY (`RefProgramme`),
  KEY `RefProgramme` (`RefProgramme`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `programme`
--

INSERT INTO `programme` (`RefProgramme`, `RefProjet`, `NomProgramme`, `Site`, `Daira`, `Commune`, `NatureProgramme`, `TypeProgramme`, `NombreBiens`, `Superficie`, `TypeVente`, `CoutFoncier`, `TVA`, `CoutFoncierTTC`, `PrixM2`) VALUES
(2, 1, 'LPA 160 logts', 'Oued Tlelat-ZUHN', 'Oued Tlelat', 'Oued Tlelat', 'Logement', 'LPA', '160', '38553.0000', 'Vente par m²', '3187.25', 17, '3729.08', '37383.18');

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
