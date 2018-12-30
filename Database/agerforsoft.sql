-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  Dim 30 déc. 2018 à 12:54
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
  `NumActe` varchar(50) NOT NULL,
  `DateActe` varchar(50) NOT NULL,
  `DateEnrgActe` varchar(50) NOT NULL,
  `DatePubliActe` varchar(50) NOT NULL,
  `Conservation` varchar(50) NOT NULL,
  `RefProjet` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `biens`
--

DROP TABLE IF EXISTS `biens`;
CREATE TABLE IF NOT EXISTS `biens` (
  `RefProgramme` varchar(50) NOT NULL,
  `NomProjet` varchar(50) NOT NULL,
  `NumEdd` varchar(50) NOT NULL,
  `NumIlot` varchar(50) NOT NULL,
  `TypeBien` varchar(50) NOT NULL,
  `NumBien` varchar(50) NOT NULL,
  `Numlot` varchar(50) NOT NULL,
  `NumBloc` varchar(50) NOT NULL,
  `Niveau` varchar(50) NOT NULL,
  `NbrPiece` varchar(50) NOT NULL,
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
  `ID` int(50) NOT NULL AUTO_INCREMENT,
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
  `ProfessionConj` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`ID`, `NumClient`, `DateCreation`, `Nom`, `Prenom`, `NomAr`, `PrenomAr`, `Sexe`, `DateNaissance`, `LieuNaissance`, `PrenomPere`, `PrenomPereAr`, `NomMere`, `PrenomMere`, `NomMereAr`, `PrenomMereAr`, `Cni`, `DateCni`, `LieuCni`, `Ville`, `Adress`, `Proffession`, `Tel`, `NomContact`, `TelContact`, `Situation`, `NomConj`, `PrénomConj`, `NomConjAR`, `PrenomConjAR`, `DateNaissanceConj`, `LieuNaissanceConj`, `ProfessionConj`) VALUES
(6, '000002', '13-12-2018', 'KHIAT', 'MOUNIR', 'خياط', 'منير', 'Homme', '13-12-2018', 'ORAN', 'MOUNIR', 'منير', 'TEST', 'TEST', 'تست', 'تست', '1223666', '13-12-2018', 'ORAN', 'ORAN', 'ORAN', 'INFORMATIQUE', '053698741', 'TEST', 'TEST', 'Célibataire', '', '', '', '', '', '', ''),
(5, '00000001', '28-11-2018', 'KHIAT', 'SIDAHMED', 'خياط', 'سيدأحمد', 'Homme', '28-11-2018', 'ORAN', 'MOUNIR', 'منير', 'FRIOUI', 'ZOULIKHA', 'فريوي', 'زليخة', '213518132', '28-11-2018', 'ORAN', 'ORAN', 'BT233 N°2 SENIA', 'INFORMATICIEN', '0661934408', 'MOUNIR', '0773201236', 'Célibataire', '', '', '', '', '', '', '');

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
-- Structure de la table `commune`
--

DROP TABLE IF EXISTS `commune`;
CREATE TABLE IF NOT EXISTS `commune` (
  `IdCommune` varchar(50) NOT NULL,
  `NomCommune` varchar(50) NOT NULL,
  `IdDaira` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `commune`
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
-- Structure de la table `daira`
--

DROP TABLE IF EXISTS `daira`;
CREATE TABLE IF NOT EXISTS `daira` (
  `IdDaira` varchar(50) NOT NULL,
  `NomDaira` varchar(50) NOT NULL,
  `IdWilaya` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `daira`
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

DROP TABLE IF EXISTS `demande`;
CREATE TABLE IF NOT EXISTS `demande` (
  `NumDemande` int(11) NOT NULL AUTO_INCREMENT,
  `DateDemande` varchar(50) NOT NULL,
  `RefClient` varchar(50) NOT NULL,
  `Motif` text NOT NULL,
  `TypeDemande` varchar(50) NOT NULL,
  `StatutDemande` varchar(50) NOT NULL,
  PRIMARY KEY (`NumDemande`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `demande`
--

INSERT INTO `demande` (`NumDemande`, `DateDemande`, `RefClient`, `Motif`, `TypeDemande`, `StatutDemande`) VALUES
(1, '21-11-2018', '0000002', 'Rien', 'Régularisation', 'Acceptée'),
(4, '22-11-2018', '0000002', 'RIEN', 'Régularisation', 'En cours'),
(5, '22-11-2018', '0000033', 'RIEN', 'Vente Libre', 'En cours');

-- --------------------------------------------------------

--
-- Structure de la table `edd`
--

DROP TABLE IF EXISTS `edd`;
CREATE TABLE IF NOT EXISTS `edd` (
  `NomProjet` varchar(50) NOT NULL,
  `RefProgramme` varchar(50) NOT NULL,
  `NumEdd` varchar(50) NOT NULL,
  `DateEdd` varchar(50) NOT NULL,
  `NumEnrg` varchar(50) NOT NULL,
  `DateEnrg` varchar(50) NOT NULL,
  `Volume` varchar(50) NOT NULL,
  `Conservation` varchar(50) NOT NULL,
  `Notaire` varchar(50) NOT NULL,
  `TelNotaire` varchar(50) NOT NULL,
  `AdresseNotaire` varchar(50) NOT NULL,
  `NomPrenomGeo` varchar(50) NOT NULL,
  `AdresseGeo` varchar(50) NOT NULL,
  `TelGeo` varchar(50) NOT NULL,
  `NbrLog` varchar(50) NOT NULL,
  `SuperficieLog` decimal(50,2) NOT NULL,
  `NbrLoc` varchar(50) NOT NULL,
  `SuperficeiLoc` decimal(50,2) NOT NULL,
  `NbrBur` varchar(50) NOT NULL,
  `SuperficieBur` decimal(50,2) NOT NULL,
  `NbrCave` varchar(50) NOT NULL,
  `SuperficieCave` decimal(50,2) NOT NULL,
  `NbrCC` varchar(50) NOT NULL,
  `SuperficieCC` decimal(50,2) NOT NULL,
  `NbrPS` varchar(50) NOT NULL,
  `SuperficiePS` decimal(50,2) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `lot`
--

DROP TABLE IF EXISTS `lot`;
CREATE TABLE IF NOT EXISTS `lot` (
  `RefProgramme` varchar(50) NOT NULL,
  `NomProjet` varchar(50) NOT NULL,
  `NumIlot` varchar(50) NOT NULL,
  `NumLot` varchar(50) NOT NULL,
  `Sup` decimal(50,2) NOT NULL,
  `PrixHT` decimal(50,2) NOT NULL,
  `Tva` int(2) NOT NULL,
  `PrixTTC` decimal(50,2) NOT NULL,
  `LimiteNord` varchar(50) NOT NULL,
  `LimiteSud` varchar(50) NOT NULL,
  `LimiteEst` varchar(50) NOT NULL,
  `LimiteOuest` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `lot`
--

INSERT INTO `lot` (`RefProgramme`, `NomProjet`, `NumIlot`, `NumLot`, `Sup`, `PrixHT`, `Tva`, `PrixTTC`, `LimiteNord`, `LimiteSud`, `LimiteEst`, `LimiteOuest`) VALUES
('0000001', 'LPA', '2', '1', '200.00', '1300000.00', 19, '1547000.00', '', '', '', '');

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
(1, 'Lotissement'),
(2, 'Local'),
(3, 'Logement'),
(4, 'RHP'),
(5, 'Terrain Industriel');

-- --------------------------------------------------------

--
-- Structure de la table `permilotir`
--

DROP TABLE IF EXISTS `permilotir`;
CREATE TABLE IF NOT EXISTS `permilotir` (
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
-- Structure de la table `permisdeconstruire`
--

DROP TABLE IF EXISTS `permisdeconstruire`;
CREATE TABLE IF NOT EXISTS `permisdeconstruire` (
  `NumPermis` varchar(50) NOT NULL,
  `DatePermisC` varchar(50) NOT NULL,
  `FraisDivers` decimal(50,2) NOT NULL,
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
  `RefProgramme` varchar(50) NOT NULL,
  `NomProjet` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `programme`
--

DROP TABLE IF EXISTS `programme`;
CREATE TABLE IF NOT EXISTS `programme` (
  `NomProjet` varchar(50) NOT NULL,
  `RefProgramme` varchar(50) NOT NULL,
  `NomProgramme` varchar(50) NOT NULL,
  `Site` varchar(50) NOT NULL,
  `Daira` varchar(50) NOT NULL,
  `Commune` varchar(50) NOT NULL,
  `NatureProgramme` varchar(50) NOT NULL,
  `TypeProgramme` varchar(50) NOT NULL,
  `NombreBiens` varchar(50) NOT NULL,
  `Superficie` decimal(50,4) NOT NULL,
  PRIMARY KEY (`RefProgramme`),
  KEY `RefProgramme` (`RefProgramme`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `projet`
--

DROP TABLE IF EXISTS `projet`;
CREATE TABLE IF NOT EXISTS `projet` (
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

DROP TABLE IF EXISTS `typeprogramme`;
CREATE TABLE IF NOT EXISTS `typeprogramme` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TypeProgramme` varchar(50) NOT NULL,
  `NatureProgramme` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;

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
