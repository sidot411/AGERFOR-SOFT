-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Client :  127.0.0.1
-- Généré le :  Lun 10 Décembre 2018 à 14:36
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
-- Structure de la table `acteprogramme`
--

CREATE TABLE `acteprogramme` (
  `NumActe` varchar(50) NOT NULL,
  `DateActe` varchar(50) NOT NULL,
  `DateEnrgActe` varchar(50) NOT NULL,
  `DatePubliActe` varchar(50) NOT NULL,
  `Conservation` varchar(50) NOT NULL,
  `FraisEnrg` decimal(50,4) DEFAULT NULL,
  `RefProgramme` varchar(50) NOT NULL,
  `NomProjet` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `acteprogramme`
--

INSERT INTO `acteprogramme` (`NumActe`, `DateActe`, `DateEnrgActe`, `DatePubliActe`, `Conservation`, `FraisEnrg`, `RefProgramme`, `NomProjet`) VALUES
('0000001', '10/12/2018', '10/12/2018', '10/12/2018', 'Oran ouest', '12000.0000', '', ''),
('000001', '10/12/2018', '10/12/2018', '12/12/2018', 'Oran ouest', '12000.0000', '000001', 'ADL'),
('00001', '10/12/2018', '10/12/2018', '10/12/2018', 'ES senia', '3000.0000', '00003', 'ADL'),
('000001', '10/12/2018', '10/12/2018', '10/12/2018', 'ES senia', '12220.3300', '00000001', 'ADL');

-- --------------------------------------------------------

--
-- Structure de la table `acteprojet`
--

CREATE TABLE `acteprojet` (
  `NumActe` varchar(50) NOT NULL,
  `DateActe` varchar(50) NOT NULL,
  `DateEnrgActe` varchar(50) NOT NULL,
  `DatePubliActe` varchar(50) NOT NULL,
  `Conservation` varchar(50) NOT NULL,
  `RefProjet` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `acteprojet`
--

INSERT INTO `acteprojet` (`NumActe`, `DateActe`, `DateEnrgActe`, `DatePubliActe`, `Conservation`, `RefProjet`) VALUES
('122220', '10/12/2018', '10/12/2018', '10/12/2018', 'Oran ouest', '0000001');

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
(5, '00000001', '28-11-2018', 'KHIAT', 'SIDAHMED', 'خياط', 'سيدأحمد', 'Homme', '28-11-2018', 'ORAN', 'MOUNIR', 'منير', 'FRIOUI', 'ZOULIKHA', 'فريوي', 'زليخة', '213518132', '28-11-2018', 'ORAN', 'ORAN', 'BT233 N°2 SENIA', 'INFORMATICIEN', '0661934408', 'MOUNIR', '0773201236', 'Célibataire', '', '', '', '', '', '', '');

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
-- Structure de la table `commune`
--

CREATE TABLE `commune` (
  `IdCommune` varchar(50) NOT NULL,
  `NomCommune` varchar(50) NOT NULL,
  `IdDaira` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `commune`
--

INSERT INTO `commune` (`IdCommune`, `NomCommune`, `IdDaira`) VALUES
('01', 'Oran', '01'),
('02', 'Aïn El Turk', '02'),
('03', 'Bousfer', '02'),
('03', 'El Ançor', '02'),
('04', 'Mers El Kébir', '02'),
('05', 'Arzew', '03'),
('06', 'Sidi Benyebka', '03'),
('07', 'Bethioua', '04'),
('08', 'Marsat El Hadjadj', '04'),
('09', 'Aïn El Bia', '04'),
('10', 'Es Senia', '05'),
('12', 'El Kerma', '05'),
('13', 'Sidi Chami', '05'),
('14', 'Bir El Djir', '06'),
('15', 'Hassi Ben Okba', '06'),
('16', 'Hassi Bounif', '06'),
('17', 'Boutlélis', '07'),
('18', 'Aïn El Kerma', '07'),
('19', 'Misserghin', '07'),
('20', 'Oued Tlelat', '08'),
('21', 'Boufatis', '08'),
('22', 'El Braya', '08'),
('23', 'Tafraoui', '08'),
('24', 'Gdyel', '09'),
('25', 'Ben Freha', '09'),
('26', 'Hassi Mefsoukh', '09');

-- --------------------------------------------------------

--
-- Structure de la table `conservation`
--

CREATE TABLE `conservation` (
  `IdConservation` int(5) NOT NULL,
  `NomConservation` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `conservation`
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
-- Structure de la table `daira`
--

CREATE TABLE `daira` (
  `IdDaira` varchar(50) NOT NULL,
  `NomDaira` varchar(50) NOT NULL,
  `IdWilaya` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `daira`
--

INSERT INTO `daira` (`IdDaira`, `NomDaira`, `IdWilaya`) VALUES
('01', 'ORAN', '31'),
('02', 'Aïn El Turk', '31'),
('03', 'Arzew', '31'),
('04', 'Bethioua', '31'),
('05', 'Es Sénia', '31'),
('06', 'Bir El Djir', '31'),
('07', 'Boutlélis', '31'),
('08', 'Oued Tlelat', '31'),
('09', 'Gdyel', '31');

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
-- Structure de la table `natureprogramme`
--

CREATE TABLE `natureprogramme` (
  `ID` int(11) NOT NULL,
  `NatureProgramme` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `natureprogramme`
--

INSERT INTO `natureprogramme` (`ID`, `NatureProgramme`) VALUES
(1, 'Lotissement'),
(2, 'Local'),
(3, 'Logement'),
(4, 'RHP'),
(5, 'Terrain Industriel');

-- --------------------------------------------------------

--
-- Structure de la table `permilotir`
--

CREATE TABLE `permilotir` (
  `NumPL` varchar(50) NOT NULL,
  `DatePL` varchar(50) NOT NULL,
  `FraisDiver` decimal(50,2) NOT NULL,
  `NbrIlot` varchar(50) NOT NULL,
  `NbrLots` varchar(50) NOT NULL,
  `SuperficieCG` decimal(50,2) NOT NULL,
  `SuperficieVoiries` decimal(50,2) NOT NULL,
  `SuperficieEV` decimal(50,2) NOT NULL,
  `SuperficieEquip` decimal(50,2) NOT NULL,
  `SuperficieAmenag` decimal(50,2) NOT NULL,
  `AutreSupercie` decimal(50,2) NOT NULL,
  `RefProgramme` varchar(50) NOT NULL,
  `NomProjet` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `programme`
--

CREATE TABLE `programme` (
  `NomProjet` varchar(50) NOT NULL,
  `RefProgramme` varchar(50) NOT NULL,
  `NomProgramme` varchar(50) NOT NULL,
  `Site` varchar(50) NOT NULL,
  `Daira` varchar(50) NOT NULL,
  `Commune` varchar(50) NOT NULL,
  `NatureProgramme` varchar(50) NOT NULL,
  `TypeProgramme` varchar(50) NOT NULL,
  `NombreBiens` varchar(50) NOT NULL,
  `Superficie` decimal(50,4) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `programme`
--

INSERT INTO `programme` (`NomProjet`, `RefProgramme`, `NomProgramme`, `Site`, `Daira`, `Commune`, `NatureProgramme`, `TypeProgramme`, `NombreBiens`, `Superficie`) VALUES
('ADL', '00000001', '200 LOGEMENT', 'ORAN', 'Es Sénia', 'Es Senia', 'Logement', 'Lpa', '200', '3000.0000');

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

-- --------------------------------------------------------

--
-- Structure de la table `typeprogramme`
--

CREATE TABLE `typeprogramme` (
  `ID` int(11) NOT NULL,
  `TypeProgramme` varchar(50) NOT NULL,
  `NatureProgramme` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `typeprogramme`
--

INSERT INTO `typeprogramme` (`ID`, `TypeProgramme`, `NatureProgramme`) VALUES
(1, 'Social', 'Lotissement'),
(2, 'Promoionnel', 'Lotissement'),
(3, 'Transfert de gestion', 'Lotissement'),
(4, 'Commercial', 'Local'),
(5, 'Professionnel', 'Local'),
(6, 'Centre commercial', 'Local'),
(7, 'Cave', 'Local'),
(8, 'Promotionel', 'Logement'),
(9, 'Lpa', 'Logement'),
(10, 'Lsp', 'Logement'),
(11, 'Cnl', 'Logement'),
(12, 'Fonal', 'Logement'),
(13, 'Relogement', 'RHP'),
(14, 'Restructuration', 'RHP'),
(15, 'Prévention', 'RHP'),
(16, 'Recasement', 'RHP'),
(17, 'Zone d activité', 'Terrain Industriel'),
(18, 'Zone depot', 'Terrain Industriel'),
(19, 'Zone touristique', 'Terrain Industriel'),
(20, 'Zone des sièges', 'Terrain Industriel'),
(21, 'Show room', 'Terrain Industriel');

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
-- Index pour la table `conservation`
--
ALTER TABLE `conservation`
  ADD KEY `IdConservation` (`IdConservation`);

--
-- Index pour la table `demande`
--
ALTER TABLE `demande`
  ADD PRIMARY KEY (`NumDemande`);

--
-- Index pour la table `natureprogramme`
--
ALTER TABLE `natureprogramme`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `typeprogramme`
--
ALTER TABLE `typeprogramme`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `client`
--
ALTER TABLE `client`
  MODIFY `ID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT pour la table `conservation`
--
ALTER TABLE `conservation`
  MODIFY `IdConservation` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT pour la table `demande`
--
ALTER TABLE `demande`
  MODIFY `NumDemande` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT pour la table `natureprogramme`
--
ALTER TABLE `natureprogramme`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT pour la table `typeprogramme`
--
ALTER TABLE `typeprogramme`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
