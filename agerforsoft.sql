-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Client :  127.0.0.1
-- Généré le :  Mar 27 Novembre 2018 à 14:31
-- Version du serveur :  5.7.14
-- Version de PHP :  5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
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
-- Structure de la table `acteprojet`
--

CREATE TABLE `acteprojet` (
  `NumActe` varchar(50) NOT NULL,
  `DateActe` varchar(50) NOT NULL,
  `DateEnrgActe` varchar(50) NOT NULL,
  `DatePubliActe` varchar(50) NOT NULL,
  `RefProjet` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `acteprojet`
--

INSERT INTO `acteprojet` (`NumActe`, `DateActe`, `DateEnrgActe`, `DatePubliActe`, `RefProjet`) VALUES
('0000003', '27/11/2018', '27/11/2018', '27/11/2018', '12315616565');

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

CREATE TABLE `client` (
  `ID` int(50) NOT NULL,
  `NumClient` varchar(50) NOT NULL,
  `DateCreation` varchar(50) DEFAULT NULL,
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
  `DateCni` varchar(50) DEFAULT NULL,
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
  `ProfessionConj` varchar(50) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `client`
--

INSERT INTO `client` (`ID`, `NumClient`, `DateCreation`, `Nom`, `Prenom`, `NomAr`, `PrenomAr`, `Sexe`, `DateNaissance`, `LieuNaissance`, `PrenomPere`, `PrenomPereAr`, `NomMere`, `PrenomMere`, `NomMereAr`, `PrenomMereAr`, `Cni`, `DateCni`, `LieuCni`, `Ville`, `Adress`, `Proffession`, `Tel`, `NomContact`, `TelContact`, `Situation`, `NomConj`, `PrénomConj`, `NomConjAR`, `PrenomConjAR`, `DateNaissanceConj`, `LieuNaissanceConj`, `ProfessionConj`) VALUES
(1, '0000002', '11-11-2018', 'KHIAT', 'SIDAHMED', 'خياط', 'سيدأحمد', 'Homme', '18-11-2018', 'ORAN', 'MOUNIR', 'منير', 'FRIOUI', 'ZOULIKHA', 'فريوي', 'زليخة', '3325165', '11-11-2018', 'ORAN', 'ORAN', 'N°1233 USTO', 'Informaticien', '0661934408', 'MOUNIR', '0661934408', 'Célibataire', '', '', '', '', '', '', ''),
(2, '0000033', '22-11-2018', 'MABROUK', 'SOUMIA', 'مبروك', 'سمية', 'Femme', '01-11-2018', 'ORAN', 'IBRAHIM', 'ابراهيم', 'BAGHDAD', 'DJAMILA', 'بغداد', 'جميلة', '33652269', '01-11-2018', 'ORAN', 'ORAN', 'N° 233 BT 2 USTO', 'Informaticienne', '0669855487', 'BRAHIM', '0553897456', 'Célibataire', '', '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Structure de la table `cliententreprise`
--

CREATE TABLE `cliententreprise` (
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
-- Structure de la table `demande`
--

CREATE TABLE `demande` (
  `NumDemande` int(11) NOT NULL,
  `DateDemande` varchar(50) NOT NULL,
  `RefClient` varchar(50) NOT NULL,
  `Motif` text NOT NULL,
  `TypeDemande` varchar(50) NOT NULL,
  `StatutDemande` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `demande`
--

INSERT INTO `demande` (`NumDemande`, `DateDemande`, `RefClient`, `Motif`, `TypeDemande`, `StatutDemande`) VALUES
(1, '21-11-2018', '0000002', 'Rien', 'Régularisation', 'Acceptée'),
(4, '22-11-2018', '0000002', 'RIEN', 'Régularisation', 'En cours'),
(5, '22-11-2018', '0000033', 'RIEN', 'Vente Libre', 'En cours');

-- --------------------------------------------------------

--
-- Structure de la table `projet`
--

CREATE TABLE `projet` (
  `RefProjet` varchar(50) NOT NULL,
  `NomProjet` varchar(50) NOT NULL,
  `VolProjet` varchar(50) NOT NULL,
  `Conservation` varchar(50) NOT NULL,
  `Vendeur` varchar(50) NOT NULL,
  `Wilaya` varchar(50) NOT NULL,
  `Daira` varchar(50) NOT NULL,
  `Commune` varchar(50) NOT NULL,
  `Superficie` decimal(50,4) NOT NULL,
  `NomGeometre` varchar(50) NOT NULL,
  `AdresseGeometre` varchar(50) NOT NULL,
  `NumGeometre` varchar(50) NOT NULL,
  `LimiteNord` varchar(50) NOT NULL,
  `LimiteEst` varchar(50) NOT NULL,
  `LimiteOuest` varchar(50) NOT NULL,
  `LimiteSud` varchar(50) NOT NULL,
  `PrixVente` decimal(50,4) NOT NULL,
  `NumRecu` varchar(50) NOT NULL,
  `DateRecu` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `projet`
--

INSERT INTO `projet` (`RefProjet`, `NomProjet`, `VolProjet`, `Conservation`, `Vendeur`, `Wilaya`, `Daira`, `Commune`, `Superficie`, `NomGeometre`, `AdresseGeometre`, `NumGeometre`, `LimiteNord`, `LimiteEst`, `LimiteOuest`, `LimiteSud`, `PrixVente`, `NumRecu`, `DateRecu`) VALUES
('12315616565', 'LPA', '3366699', 'ORAN', 'MABROUK', 'ORAN', 'ORAN', 'ORAN', '3366958554.2330', 'MABROUK', 'BT233 N°221 USTO', '0552369852', 'USTO NORD', 'USTO EST', 'USTO OUEST', 'USTO SUD ', '12223300000.2200', '112255', '27/11/2018'),
('12315616565', 'LPA', '3366699', 'ORAN', 'MABROUK', 'ORAN', 'ORAN', 'ORAN', '3366958554.2330', 'MABROUK', 'BT233 N°221 USTO', '0552369852', 'USTO NORD', 'USTO EST', 'USTO OUEST', 'USTO SUD ', '12223300000.2200', '112255', '27/11/2018');

-- --------------------------------------------------------

--
-- Structure de la table `wilaya`
--

CREATE TABLE `wilaya` (
  `NumWilaya` varchar(50) NOT NULL,
  `NomWilaya` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `wilaya`
--

INSERT INTO `wilaya` (`NumWilaya`, `NomWilaya`) VALUES
('31', 'ORAN'),
('16', 'ALGER'),
('22', 'SIDI BEL ABBES');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `demande`
--
ALTER TABLE `demande`
  ADD PRIMARY KEY (`NumDemande`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `client`
--
ALTER TABLE `client`
  MODIFY `ID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT pour la table `demande`
--
ALTER TABLE `demande`
  MODIFY `NumDemande` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
